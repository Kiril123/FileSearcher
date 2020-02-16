using FileSearcherUI.Models;
using FileSearcherUI.Utility;
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
        private IConfigurationSaver configurationSaver;
        private IFileSearcherModel fileSearcher;

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

        private void Start(string directoryPath,string fileNamePattern,string allowedCharacters)
        {
            configurationSaver.Save(new ConfigurationModel(directoryPath, fileNamePattern, allowedCharacters));
            fileSearcher.AllowedCharacters = new List<char>(allowedCharacters.ToCharArray());
            fileSearcher.NamePattern = fileNamePattern;
            fileSearcher.Search(directoryPath);
        }

        private void Pause()
        {
            throw new NotImplementedException();
        }

    }
}
