using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        event Action Start;
        event Action Pause;

    }
}
