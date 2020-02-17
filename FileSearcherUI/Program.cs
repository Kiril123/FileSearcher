using FileSearcherUI.Models;
using FileSearcherUI.Presenters;
using FileSearcherUI.Utility;
using FileSearcherUI.Views;
using System;
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
                    ),
                new TimeCalculator()
                );
            presenter.Run();
        }
    }
}
