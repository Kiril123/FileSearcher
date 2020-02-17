using System.Text.RegularExpressions;

namespace FileSearcherUI.Models
{
    /// <summary>
    /// Checks if the file name is valid.
    /// </summary>
    public class FileNameValidator : IFileNameValidator
    {
        private string namePattern;
        /// <summary>
        /// Name pattern for regex.
        /// </summary>
        public string NamePattern
        {
            get{
                return namePattern;
            }
            set{
                namePattern = value;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public FileNameValidator()
        {
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="namePattern">Name pattern for the file.</param>
        public FileNameValidator(string namePattern)
        {
            this.NamePattern = namePattern;
        }
        /// <summary>
        /// Checks if the file name is valid using the set pattern.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>True if valid file name else false.</returns>
        public bool Validate(string fileName)
        {
            if (fileName == null||fileName=="") { return false; }
            Regex rx = new Regex(NamePattern);
            return rx.IsMatch(fileName);
        }
    }
}
