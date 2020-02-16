namespace FileSearcherUI.Models
{
    public interface IFileNameValidator
    {
        string NamePattern { get; set; }
        bool Validate(string fileName);
    }
}