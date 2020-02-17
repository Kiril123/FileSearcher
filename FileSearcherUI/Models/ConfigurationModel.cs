namespace FileSearcherUI.Models
{
    /// <summary>
    /// Model used to configure file searcher.
    /// </summary>
    public class ConfigurationModel
    {
        private string directoryPath;
        private string fileNamePattern;
        private string allowedCharacters;
        /// <summary>
        /// Constructor.
        /// </summary>
        public ConfigurationModel()
        {
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="directoryPath">Path to start directory.</param>
        /// <param name="fileNamePattern">Valid file names.</param>
        /// <param name="allowedCharacters">Characters that are allowed in a file.</param>
        public ConfigurationModel(string directoryPath, string fileNamePattern, string allowedCharacters)
        {
            this.directoryPath = directoryPath;
            this.fileNamePattern = fileNamePattern;
            this.allowedCharacters = allowedCharacters;
        }
        /// <summary>
        /// Path to start directory.
        /// </summary>
        public string DirectoryPath { 
            get => directoryPath;
            set => directoryPath = value;
        }
        /// <summary>
        /// Valid file names.
        /// </summary>
        public string FileNamePattern { 
            get => fileNamePattern;
            set => fileNamePattern = value;
        }
        /// <summary>
        /// Characters that are allowed in a file.
        /// </summary>
        public string AllowedCharacters { 
            get => allowedCharacters;
            set => allowedCharacters = value;
        }
    }
}
