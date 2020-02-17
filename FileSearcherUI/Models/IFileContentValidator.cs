using FileSearcherUI.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        HashSet<char> AllowedCharacters { get; set; }
        /// <summary>
        /// Checks if a file contains only valid characters.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the file contains only valid characters else false.</returns>
        bool Validate(string filePath);
        /// <summary>
        /// Checks if a file contains only valid characters.
        /// With syncronizattion.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the file contains only valid characters else false.</returns>
        Task<bool> Validate(string filePath, PauseOrCancelToken syncToken);
    }
}