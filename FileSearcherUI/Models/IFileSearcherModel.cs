using System;
using System.Collections.Generic;

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
        List<char> AllowedCharacters { get; set; }
        /// <summary>
        /// File name Pattern.
        /// </summary>
        string NamePattern { get; set; }
        /// <summary>
        /// Searches given directory for all valid files.
        /// </summary>
        /// <param name="root">Directory root.</param>
        void Search(string root, IProgress<FileSearchProgressModel> progress);
    }
}