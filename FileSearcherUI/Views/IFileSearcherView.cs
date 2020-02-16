using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcherUI.Views
{
    public interface IFileSearcherView:IView
    {
        string DirectoryPath { get; }
        string FileNamePattern { get; }
        string AllowedSymbols { get; }

    }
}
