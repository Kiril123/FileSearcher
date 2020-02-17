using FileSearcherUI.Models;
using FileSearcherUI.Utility;
using FileSearcherUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FileSearcherUI.Presenters
{
    public class FileSearcherPresenter:IPresenter
    {
        private readonly IFileSearcherView view;
        private static readonly char pathSeparator='\\';
        private IConfigurationSaver configurationSaver;
        private IFileSearcherModel fileSearcher;
        private ITimeCalculator timer;
        private PauseOrCancelTokenSource searchOperationToken;
        private int counter;
        private bool searchOperationRunning;

        private static int frequency = 100;
        private static int countEvents = 10;

        public FileSearcherPresenter(IFileSearcherView view,IConfigurationSaver configurationSaver,IFileSearcherModel fileSearcher,ITimeCalculator timer)
        {
            this.view = view;
            this.configurationSaver = configurationSaver;
            this.fileSearcher = fileSearcher;
            this.timer = timer;
            timer.TimerTickedEvent += Timer_TimerTickedEvent;
            timer.TimeEvents = countEvents;
            timer.TimeInterval = frequency;
            view.Start += () => Start(view.DirectoryPath, view.FileNamePattern, view.AllowedSymbols);
            view.Pause += () => Pause();
            ConfigurationModel savedConfig = configurationSaver?.Load();
            if (savedConfig != null)
            {
                view.AllowedSymbols = savedConfig.AllowedCharacters;
                view.DirectoryPath = savedConfig.DirectoryPath;
                view.FileNamePattern = savedConfig.FileNamePattern;
            }
            searchOperationRunning = false;
        }

        private void Timer_TimerTickedEvent(object sender, int e)
        {
            view.SecondsPassed = e.ToString();
        }

        public void Run()
        {
            view.Show();
        }

        private void updateTreeView(string path)
        {
            TreeNode lastNode = null;
            string subPathAggregation = "";
            foreach(string subPath in path.Split(pathSeparator))
            {
                subPathAggregation += subPath + pathSeparator;
                TreeNode[] nodes = view.SearchResultsTreeView.Nodes.Find(subPathAggregation, true);
                if (nodes.Length == 0)
                {
                    if (lastNode == null)
                    {
                        lastNode = view.SearchResultsTreeView.Nodes.Add(subPathAggregation, subPath);
                    }
                    else
                    {
                        lastNode = lastNode.Nodes.Add(subPathAggregation, subPath);
                    }
                }
                else
                {
                    lastNode = nodes[0];
                }
            }
        }

        private async void startSearch(string directoryPath, string fileNamePattern, string allowedCharacters)
        {
            searchOperationRunning = true;
            counter = 0;
            view.FilesProccessed = counter.ToString();
            configurationSaver.Save(new ConfigurationModel(directoryPath, fileNamePattern, allowedCharacters));
            fileSearcher.AllowedCharacters = new HashSet<char>(allowedCharacters.ToCharArray());
            fileSearcher.NamePattern = fileNamePattern;
            Progress<FileSearchProgressModel> searchProgress = new Progress<FileSearchProgressModel>();
            searchProgress.ProgressChanged += ReportSearchProgress;
            try
            {
                searchOperationToken = new PauseOrCancelTokenSource();
                await Task.Run(() => fileSearcher.Search(directoryPath, searchProgress, searchOperationToken.Token));
            }
            catch (OperationCanceledException)
            {
            }
            view.CurrentFile = "None";
            view.StartButtonText = "Start";
            timer.Stop();
        }

        private void cancelSearch()
        {
            searchOperationToken.Cancel();
            searchOperationRunning = false;
            view.PauseButtonText = "Pause";
            searchOperationToken.Dispose();
        }

        private void Start(string directoryPath,string fileNamePattern,string allowedCharacters)
        {
            if (!searchOperationRunning)
            {
                view.StartButtonText = "Cancel";
                view.SecondsPassed = "0";
                timer.Start();
                startSearch(directoryPath, fileNamePattern, allowedCharacters);
            }
            else
            {
                view.StartButtonText = "Start";
                cancelSearch();
                timer.Stop();
            }
        }

        private void ReportSearchProgress(object sender,FileSearchProgressModel progress)
        {
            if (!progress.IsFinished)
            {
                view.CurrentFile = progress.CurrentFile;
            }
            else
            {
                counter++;
                view.FilesProccessed = counter.ToString();
                if (progress.IsValid)
                {
                    updateTreeView(progress.CurrentFile);
                }
            }
        }

        private void Pause()
        {
            if (searchOperationToken == null || searchOperationToken.IsDisposed())
            {
                return;
            }
            if (!searchOperationToken.IsPaused())
            {
                searchOperationToken.Pause();
                timer.Pause();
                view.PauseButtonText = "Resume";
            }
            else
            {
                searchOperationToken.Unpause();
                timer.Unpause();
                view.PauseButtonText = "Pause";
            }
        }
    }
}
