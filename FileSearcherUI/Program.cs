using FileSearcherUI.Models;
using FileSearcherUI.Presenters;
using FileSearcherUI.Utility;
using FileSearcherUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcherUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = new FileSearcherPresenter(
                new FileSearcherForm(),
                new ConfigurationSaver(),
                new FileSearcherModel(
                    new FileContentValidator(),
                    new FileNameValidator()
                    )
                );
            presenter.Run();
        }
    }
}
