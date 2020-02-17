using FileSearcherUI.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcherUI.Models
{
    /// <summary>
    /// Checks if all characters in a text file are valid.
    /// </summary>
    public class FileContentValidator : IFileContentValidator
    {
        private HashSet<char> allowedCharacters;
        /// <summary>
        /// Constructor
        /// </summary>
        public FileContentValidator()
        {
            this.allowedCharacters = new HashSet<char>();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="allowedCharacters">List of allowed characters.</param>
        public FileContentValidator(char[] allowedCharacters)
        {
            this.allowedCharacters = new HashSet<char>(allowedCharacters);
        }
        /// <summary>
        /// Allowed characters.
        /// </summary>
        public HashSet<char> AllowedCharacters
        {
            get
            {
                return allowedCharacters;
            }
            set
            {
                allowedCharacters = value;
            }
        }
        /// <summary>
        /// Checks if the given character is matches any of the allowed characters.
        /// newline and whitespace are valid by default.
        /// </summary>
        /// <param name="c">Character to check.</param>
        /// <returns>True if the character is valid else false.</returns>
        private bool isLegalCharacter(char c)
        {
            if (c == ' ' || c == '\n' || c == '\r')
            {
                return true;
            }
            return AllowedCharacters.Contains(c);
        }

        /// <summary>
        /// Checks if a file contains only valid characters.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the file contains only valid characters else false.</returns>
        public bool Validate(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {

                    while (reader.Peek() >= 0)
                    {
                        if (!isLegalCharacter((char)reader.Read()))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if a file contains only valid characters.
        /// Checks synchronization every line read.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the file contains only valid characters else false.</returns>
        public async Task<bool> Validate(string filePath,PauseOrCancelToken syncToken)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {

                    while (reader.Peek() >= 0)
                    {
                        await syncToken.PauseOrCancel();
                        string line = reader.ReadLine();
                        foreach(char c in line)
                        {
                            if (!isLegalCharacter(c))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
