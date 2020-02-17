using FileSearcherUI.Models;
using FileSearcherUI.Utility;
using FileSearcherUI.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcherUI.Presenters
{
    /// <summary>
    /// File searcher presenter class.
    /// </summary>
    public class FileSearcherPresenter:IPresenter
    {
        #region Fields
        /// <summary>
        /// View interface.
        /// </summary>
        private readonly IFileSearcherView view;
        /// <summary>
        /// Interface that saves and laod search configurations.
        /// </summary>
        private IConfigurationSaver configurationSaver;
        /// <summary>
        /// Buisness logic interface (model).
        /// </summary>
        private IFileSearcherModel fileSearcher;
        /// <summary>
        /// Timer interface.
        /// </summary>
        private ITimeCalculator timer;
        //Check this. TO DO
        private static readonly char pathSeparator='\\';
        /// <summary>
        /// Synchronization token. Pauses or cancels tasks.
        /// </summary>
        private PauseOrCancelTokenSource searchOperationToken;
        /// <summary>
        /// Number of files proccessed.
        /// </summary>
        private int counter;
        /// <summary>
        /// Is a search operation running.
        /// </summary>
        private bool searchOperationRunning;
        //Setting to get update event every 100ms and update form every second.
        /// <summary>
        /// Default timer frequency.
        /// </summary>
        private static int frequency = 100;
        /// <summary>
        /// Default events before updating counter.
        /// </summary>
        private static int countEvents = 10;
        #endregion
        #region Constructor and intialization
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="view">View interface.</param>
        /// <param name="configurationSaver">Interface that saves and laod search configurations.</param>
        /// <param name="fileSearcher">Buisness logic interface (model).</param>
        /// <param name="timer">Timer interface.</param>
        public FileSearcherPresenter(IFileSearcherView view,IConfigurationSaver configurationSaver,IFileSearcherModel fileSearcher,ITimeCalculator timer)
        {
            //Set interfaces.
            this.view = view;
            this.configurationSaver = configurationSaver;
            this.fileSearcher = fileSearcher;
            this.timer = timer;

            //Event hookup and default value initialization.
            initTimer();
            view.Start += () => Start(view.DirectoryPath, view.FileNamePattern, view.AllowedSymbols);
            view.Pause += () => Pause();
            initConfig();
            searchOperationRunning = false;
        }
        /// <summary>
        /// Intializes timer with default values.
        /// </summary>
        private void initTimer()
        {
            timer.TimerTickedEvent += Timer_TimerTickedEvent;
            timer.TimeEvents = countEvents;
            timer.TimeInterval = frequency;
        }
        /// <summary>
        /// Load configuration.
        /// </summary>
        private void initConfig()
        {
            ConfigurationModel savedConfig = configurationSaver?.Load();
            if (savedConfig != null)
            {
                view.AllowedSymbols = savedConfig.AllowedCharacters;
                view.DirectoryPath = savedConfig.DirectoryPath;
                view.FileNamePattern = savedConfig.FileNamePattern;
            }
        }
        #endregion
        #region public methods
        /// <summary>
        /// Shows the form.
        /// </summary>
        public void Run()
        {
            view.Show();
        }
        #endregion
        #region private functions
        /// <summary>
        /// Updates tree view with found valid files.
        /// </summary>
        /// <param name="path">Absolute path to file.</param>
        private void updateTreeView(string path)
        {
            TreeNode lastNode = null;
            string subPathAggregation = "";
            foreach (string subPath in path.Split(pathSeparator))
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
        /// <summary>
        /// Starts file search (main functionality).
        /// </summary>
        /// <param name="directoryPath">Path to directory.</param>
        /// <param name="fileNamePattern">Valid file name pattern.</param>
        /// <param name="allowedCharacters">Allowed characters in file.</param>
        private async void startSearch(string directoryPath, string fileNamePattern, string allowedCharacters)
        {
            //Initial setup.
            searchOperationRunning = true;
            counter = 0;
            view.FilesProccessed = counter.ToString();
            configurationSaver.Save(new ConfigurationModel(directoryPath, fileNamePattern, allowedCharacters));
            fileSearcher.AllowedCharacters = new HashSet<char>(allowedCharacters.ToCharArray());
            fileSearcher.NamePattern = fileNamePattern;
            //Main operation
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
            //Cleanup
            view.CurrentFile = "None";
            view.StartButtonText = "Start";
            timer.Stop();
        }
        /// <summary>
        /// Cancel operation.
        /// </summary>
        private void cancelSearch()
        {
            searchOperationToken.Cancel();
            searchOperationRunning = false;
            view.PauseButtonText = "Pause";
            searchOperationToken.Dispose();
        }
        #endregion
        #region Event functions.

        /// <summary>
        /// Timer update event.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Current event number.</param>
        private void Timer_TimerTickedEvent(object sender, int e)
        {
            view.SecondsPassed = e.ToString();
        }

        /// <summary>
        /// Start button press event.
        /// </summary>
        /// <param name="directoryPath">Path to directory.</param>
        /// <param name="fileNamePattern">File name pattern.</param>
        /// <param name="allowedCharacters">Allowed characters in file.</param>
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
        /// <summary>
        /// Search report progress event.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="progress">Operation status.</param>
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
        /// <summary>
        /// Pause event.
        /// </summary>
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
        #endregion
    }
}
