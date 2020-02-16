using FileSearcherUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcherUI.Presenters
{
    public class FileSearcherPresenter:IPresenter
    {
        private readonly IFileSearcherView view;


        public FileSearcherPresenter(IFileSearcherView view)
        {
            this.view = view;
            view.Start += () => Start(view.DirectoryPath, view.FileNamePattern, view.AllowedSymbols);
            view.Pause += () => Pause();
        }

        public void Run()
        {
            view.Show();
        }

        private void Start(string directoryPath,string fileNamePattern,string allowedCharacters)
        {
            throw new NotImplementedException();
        }

        private void Pause()
        {
            throw new NotImplementedException();
        }

    }
}
