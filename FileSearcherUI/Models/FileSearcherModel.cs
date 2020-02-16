using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcherUI.Models
{
    /// <summary>
    /// Searches for all valid files in directory.
    /// </summary>
    public class FileSearcherModel : IFileSearcherModel
    {
        IFileContentValidator contentValidator;
        IFileNameValidator nameValidator;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="contentvalidator">Interface used for file content validation.</param>
        /// <param name="nameValidator">Interface used for file name validation.</param>
        public FileSearcherModel(IFileContentValidator contentvalidator, IFileNameValidator nameValidator)
        {
            this.contentValidator = contentvalidator;
            this.nameValidator = nameValidator;
        }
        /// <summary>
        /// File name Pattern.
        /// </summary>
        public string NamePattern
        {
            get
            {
                return nameValidator.NamePattern;
            }
            set
            {
                nameValidator.NamePattern = value;
            }
        }
        /// <summary>
        /// Allowed characters in content.
        /// </summary>
        public List<char> AllowedCharacters
        {
            get
            {
                return contentValidator.AllowedCharacters;
            }
            set
            {
                contentValidator.AllowedCharacters = value;
            }
        }
        /// <summary>
        /// Checks if the file is valid.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>True if the file is valid, else false.</returns>
        private bool isValid(string filePath)
        {
            // TO DO Update proccessed file field.
            if (!nameValidator.Validate(filePath))
            {
                //To DO Increase proccessed count
                return false;
            }
            if (!contentValidator.Validate(filePath))
            {
                //TO DO Increase proccessed count
                return false;
            }
            //TO DO Increase proccessed count
            return true;
        }

        /// <summary>
        /// Searches given directory for all valid files.
        /// </summary>
        /// <param name="root">Directory root.</param>
        public void Search(string root)
        {
            if (!Directory.Exists(root))
            {
                throw new ArgumentException($"{root} Doesn't exist.");
            }
            Stack<string> directories = new Stack<string>();
            directories.Push(root);
            while (directories.Count > 0)
            {
                string currentDirectory = directories.Pop();
                string[] subDirectories;
                string[] files;
                try
                {
                    subDirectories = Directory.GetDirectories(currentDirectory);
                    files = Directory.GetFiles(currentDirectory);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }
                foreach (string file in files)
                {
                    isValid(file);
                    //TO DO if is valid update ui.
                }
                foreach (string subDirectory in subDirectories)
                {
                    directories.Push(subDirectory);
                }
            }
        }
    }
}
