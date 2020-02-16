namespace FileSearcherUI.Models
{
    /// <summary>
    /// Checks if the file name is valid.
    /// </summary>
    public interface IFileNameValidator
    {
        /// <summary>
        /// Name pattern.
        /// </summary
        string NamePattern { get; set; }
        /// <summary>
        /// Checks if the file name is valid using the set pattern.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>True if valid file name else false.</returns>
        bool Validate(string fileName);
    }
}