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
        }

        public void Run()
        {
            view.Show();
        }

    }
}
