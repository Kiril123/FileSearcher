namespace FileSearcherUI.Models
{
	/// <summary>
	/// Progress report for directory search operation.
	/// </summary>
    public class FileSearchProgressModel
    {
		private string currentFile;
		private bool isFinished;
		private bool isValid;
		/// <summary>
		/// Constructor.
		/// </summary>
		public FileSearchProgressModel()
		{
		}
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="currentFile">Which file is being proccessed.</param>
		/// <param name="isFinished">Is proccessing finished.</param>
		/// <param name="isValid">Is the file valid.</param>
		public FileSearchProgressModel(string currentFile, bool isFinished, bool isValid)
		{
			this.currentFile = currentFile;
			this.isFinished = isFinished;
			this.isValid = isValid;
		}
		/// <summary>
		/// Which file is being proccessed.
		/// </summary>
		public string CurrentFile
		{
			get { return currentFile; }
			set { currentFile = value; }
		}
		/// <summary>
		/// Is proccessing finished.
		/// </summary>
		public bool IsFinished
		{
			get { return isFinished; }
			set { isFinished = value; }
		}
		/// <summary>
		/// Is the file valid.
		/// </summary>
		public bool IsValid
		{
			get { return isValid; }
			set { isValid = value; }
		}

	}
}
