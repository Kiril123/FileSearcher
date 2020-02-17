using FileSearcherUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FileSearcherTests.Models
{
    public class FileContentValidatorTests
    {
        IFileContentValidator validator;
        private string testingDirectoryPath = "";

        public FileContentValidatorTests()
        {
            this.validator = new FileContentValidator();
            string bin = Environment.CurrentDirectory;
            testingDirectoryPath = Directory.GetParent(bin).Parent.FullName + "\\TestingDirectory\\";
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("IDontExist.txt")]
        public void FileContentValidator_ValidateShouldReturnFalseFullNullOrNonExistingFiles(string fileName)
        {
            Assert.False(validator.Validate(fileName));
        }
        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "SubDirectory1\\FileContainingLettersDotAndSlash.txt")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "XMLSubDirectory\\SimpleXML.xml")]
        public void FileContentValidator_ValidateShouldReturnFalseForFilesContainingInvalidCharacters(string allowedChars,string fileName)
        {
            validator.AllowedCharacters = new HashSet<char>(allowedChars.ToCharArray());
            Assert.False(validator.Validate(testingDirectoryPath + fileName));
        }
        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "SubDirectory1\\FileContainingCapitalLetters.txt")]
        [InlineData("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789<>:/\\.\"?=-", "XMLSubDirectory\\SimpleXML.xml")]
        public void FileContentValidator_ValidateShouldReturnTrueForFilesContainingValidCharacters(string allowedChars, string fileName)
        {
            validator.AllowedCharacters = new HashSet<char>(allowedChars.ToCharArray());
            Assert.True(validator.Validate(testingDirectoryPath + fileName));
        }

    }
}
