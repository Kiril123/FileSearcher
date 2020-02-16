using System.Text.RegularExpressions;

namespace FileSearcherUI.Models
{
    public class FileNameValidator : IFileNameValidator
    {
        private string namePattern;
        public FileNameValidator()
        {
        }
        public FileNameValidator(string namePattern)
        {
            this.NamePattern = namePattern;
        }

        public string NamePattern {
            get { 
                return namePattern;
            }
            set{
                namePattern = value;
            }
        }

        public bool Validate(string fileName)
        {
            Regex rx = new Regex(NamePattern);
            return rx.IsMatch(fileName);
        }
    }
}
