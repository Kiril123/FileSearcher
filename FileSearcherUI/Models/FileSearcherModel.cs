using FileSearcherUI.Utility;
using System;
using System.Collections.Generic;
using System.IO;
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
        public HashSet<char> AllowedCharacters
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
            if (!nameValidator.Validate(filePath))
            {
                return false;
            }
            return contentValidator.Validate(filePath);

        }
        /// <summary>
        /// Checks if the file is valid.
        /// With synchronization
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>True if the file is valid, else false.</returns>
        private async Task<bool> isValid(string filePath,PauseOrCancelToken syncToken)
        {
            if (!nameValidator.Validate(filePath))
            {
                return false;
            }
            return await contentValidator.Validate(filePath, syncToken);
        }

        /// <summary>
        /// Searches given directory for all valid files.
        /// </summary>
        /// <param name="root">Directory root.</param>
        /// <param name="progress">Syncronization progress reporter.</param>
        /// <param name="syncToken">Token to cancel or pause the operation.</param>
        public async Task Search(string root,IProgress<FileSearchProgressModel> progress,PauseOrCancelToken syncToken)
        {
            await syncToken.PauseOrCancel();
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
                    await syncToken.PauseOrCancel();
                    progress.Report(new FileSearchProgressModel(file,false,false));
                    await syncToken.PauseOrCancel();
                    bool valid = await isValid(file,syncToken);
                    progress.Report(new FileSearchProgressModel(file, true,valid));
                }
                foreach (string subDirectory in subDirectories)
                {
                    directories.Push(subDirectory);
                }
            }
        }
    }
}
