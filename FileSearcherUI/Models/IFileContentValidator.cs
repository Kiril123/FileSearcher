using System.Collections.Generic;

namespace FileSearcherUI.Models
{
    /// <summary>
    /// Checks if all characters in a file are valid.
    /// </summary>
    public interface IFileContentValidator
    {
        /// <summary>
        /// Allowed characters.
        /// </summary>
        List<char> AllowedCharacters { get; set; }
        /// <summary>
        /// Checks if a file contains only valid characters.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the file contains only valid characters else false.</returns>
        bool Validate(string filePath);
    }
}