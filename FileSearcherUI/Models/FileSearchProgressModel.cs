using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcherUI.Models
{
    public class FileSearchProgressModel
    {
		private string currentFile;
		private bool isFinished;
		private bool isValid;

		public FileSearchProgressModel()
		{
		}

		public FileSearchProgressModel(string currentFile, bool isFinished, bool isValid)
		{
			this.currentFile = currentFile;
			this.isFinished = isFinished;
			this.isValid = isValid;
		}
		public string CurrentFile
		{
			get { return currentFile; }
			set { currentFile = value; }
		}
		public bool IsFinished
		{
			get { return isFinished; }
			set { isFinished = value; }
		}
		public bool IsValid
		{
			get { return isValid; }
			set { isValid = value; }
		}

	}
}
