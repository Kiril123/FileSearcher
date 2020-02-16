using FileSearcherUI.Models;
using FileSearcherUI.Utility;
using FileSearcherUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcherUI.Presenters
{
    public class FileSearcherPresenter:IPresenter
    {
        private readonly IFileSearcherView view;
        private static readonly char pathSeparator='\\';
        private IConfigurationSaver configurationSaver;
        private IFileSearcherModel fileSearcher;
        private int counter;

        public FileSearcherPresenter(IFileSearcherView view,IConfigurationSaver configurationSaver,IFileSearcherModel fileSearcher)
        {
            this.view = view;
            this.configurationSaver = configurationSaver;
            this.fileSearcher = fileSearcher;
            view.Start += () => Start(view.DirectoryPath, view.FileNamePattern, view.AllowedSymbols);
            view.Pause += () => Pause();
            ConfigurationModel savedConfig = configurationSaver?.Load();
            if (savedConfig != null)
            {
                view.AllowedSymbols = savedConfig.AllowedCharacters;
                view.DirectoryPath = savedConfig.DirectoryPath;
                view.FileNamePattern = savedConfig.FileNamePattern;
            }
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

        private async void Start(string directoryPath,string fileNamePattern,string allowedCharacters)
        {
            counter = 0;
            view.FilesProccessed = counter.ToString();
            configurationSaver.Save(new ConfigurationModel(directoryPath, fileNamePattern, allowedCharacters));
            fileSearcher.AllowedCharacters = new List<char>(allowedCharacters.ToCharArray());
            fileSearcher.NamePattern = fileNamePattern;
            Progress<FileSearchProgressModel> searchProgress = new Progress<FileSearchProgressModel>();
            searchProgress.ProgressChanged += ReportSearchProgress;
            await Task.Run(()=>fileSearcher.Search(directoryPath,searchProgress));
            view.CurrentFile = "None";
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
            throw new NotImplementedException();
        }

    }
}
