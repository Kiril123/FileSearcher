using System;
using System.Windows.Forms;

namespace FileSearcherUI.Views
{
    /// <summary>
    /// File searcher view interface.
    /// </summary>
    public interface IFileSearcherView:IView
    {
        /// <summary>
        /// Directory to proccess.
        /// </summary>
        string DirectoryPath { get; set; }
        /// <summary>
        /// Valid file name.
        /// </summary>
        string FileNamePattern { get; set; }
        /// <summary>
        /// Allowed symbols in file.
        /// </summary>
        string AllowedSymbols { get; set; }
        /// <summary>
        /// Seconds passed since start.
        /// </summary>
        string SecondsPassed { get; set; }
        /// <summary>
        /// File currently being proccessed.
        /// </summary>
        string CurrentFile { get; set; }
        /// <summary>
        /// Number of files proccessed.
        /// </summary>
        string FilesProccessed { get; set; }
        /// <summary>
        /// Tree of valid files and their absolute path.
        /// </summary>
        TreeView SearchResultsTreeView { get; }
        /// <summary>
        /// Start button text.
        /// </summary>
        string StartButtonText { get; set; }
        /// <summary>
        /// Pause button text.
        /// </summary>
        string PauseButtonText { get; set; }
        /// <summary>
        /// Start button click event.
        /// </summary>
        event Action Start;
        /// <summary>
        /// Pause button click event.
        /// </summary>
        event Action Pause;

    }
}
