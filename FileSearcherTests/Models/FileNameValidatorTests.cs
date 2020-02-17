using FileSearcherUI.Models;
using System.Collections.Generic;
using Xunit;

namespace FileSearcherTests.Models
{
    /// <summary>
    /// Unit tests for file anme validator class.
    /// </summary>
    public class FileNameValidatorTests
    {
        IFileNameValidator nameValidator;
        public FileNameValidatorTests()
        {
            nameValidator = new FileNameValidator(".*");
        }

        [Theory]
        [InlineData("data")]
        [InlineData("File.xml")]
        [InlineData("SomeFile")]
        public void FileNameValidator_ValidateShouldReturnTrueRegexAllCharacters(string fileName)
        {
            nameValidator.NamePattern = ".*";
            Assert.True(nameValidator.Validate(fileName));
        }

        [Fact]
        public void FileNameValidator_ValidateShouldReturnFalseForEmptyOrNull()
        {
            nameValidator.NamePattern = ".*";
            List<string> nullEmpty = new List<string>()
            {
                null,
                ""
            };
            Assert.All(nullEmpty, x => nameValidator.Validate(x));
        }

        [Theory]
        [InlineData(".*\\.xml","file.xml")]
        [InlineData(".*\\.txt","some file.txt")]
        [InlineData(".*txt","filename.txt")]
        [InlineData("txt", "file.txt")]
        [InlineData("file\\..*", "file.txt")]
        public void FileNameValidator_ValidateShouldReturnTrueForValidRegex(string pattern,string filename)
        {
            nameValidator.NamePattern = pattern;
            Assert.True(nameValidator.Validate(filename));
        }

        [Theory]
        [InlineData(".*txt","file.xml")]
        [InlineData("\\.txt", "txt.xml")]
        [InlineData("file\\..*","file1.xml") ]
        [InlineData("^file.xml$","file.xml.xml")]

        public void FileNameValidator_ValidateShouldReturnFalseForInvalidFiles(string pattern,string filename)
        {
            nameValidator.NamePattern = pattern;
            Assert.False(nameValidator.Validate(filename));
        }
    }
}
