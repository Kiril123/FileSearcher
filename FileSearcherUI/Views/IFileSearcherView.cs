using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcherUI.Views
{
    public interface IFileSearcherView:IView
    {
        string DirectoryPath { get; set; }
        string FileNamePattern { get; set; }
        string AllowedSymbols { get; set; }
        string SecondsPassed { get; set; }
        string CurrentFile { get; set; }
        string FilesProccessed { get; set; }
        TreeView SearchResultsTreeView { get; }
        string StartButtonText { get; set; }
        string PauseButtonText { get; set; }

        bool StartButtonEnabled { get; set; }

        event Action Start;
        event Action Pause;

    }
}
