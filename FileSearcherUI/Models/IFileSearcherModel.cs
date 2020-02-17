using FileSearcherUI.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSearcherUI.Models
{
    /// <summary>
    /// Searches for all valid files in directory.
    /// </summary>
    public interface IFileSearcherModel
    {
        /// <summary>
        /// Allowed characters in content.
        /// </summary>
        HashSet<char> AllowedCharacters { get; set; }
        /// <summary>
        /// File name Pattern.
        /// </summary>
        string NamePattern { get; set; }
        /// <summary>
        /// Searches given directory for all valid files.
        /// </summary>
        /// <param name="root">Directory root.</param>
        /// <param name="progress">Syncronization progress reporter.</param>
        /// <param name="syncToken">Token to cancel or pause the operation.</param>
        Task Search(string root, IProgress<FileSearchProgressModel> progress, PauseOrCancelToken syncToken);
    }
}