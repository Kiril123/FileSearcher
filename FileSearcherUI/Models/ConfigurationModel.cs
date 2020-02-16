using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcherUI.Models
{
    public class ConfigurationModel
    {
        private string directoryPath;
        private string fileNamePattern;
        private string allowedCharacters;
        public ConfigurationModel()
        {
        }
        public ConfigurationModel(string directoryPath, string fileNamePattern, string allowedCharacters)
        {
            this.directoryPath = directoryPath;
            this.fileNamePattern = fileNamePattern;
            this.allowedCharacters = allowedCharacters;
        }

        public string DirectoryPath { 
            get => directoryPath;
            set => directoryPath = value;
        }
        public string FileNamePattern { 
            get => fileNamePattern;
            set => fileNamePattern = value;
        }
        public string AllowedCharacters { 
            get => allowedCharacters;
            set => allowedCharacters = value;
        }
    }
}
