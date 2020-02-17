using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcherUI.Views
{
    public partial class FileSearcherForm : Form,IFileSearcherView
    {

        public event Action Start;
        public event Action Pause;
        public FileSearcherForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public string DirectoryPath
        {
            get{
                return directoryTextbox.Text;
            }
            set{
                directoryTextbox.Text = value;
            }
        }
        public string FileNamePattern
        {
            get{
                return fileNamePatternTextBox.Text;
            }
            set{
                fileNamePatternTextBox.Text = value;
            }
        }
        public string AllowedSymbols
        {
            get{
                return allowedSymbolsTextBox.Text;
            }
            set{
                allowedSymbolsTextBox.Text = value;
            }
        }
        
        public string SecondsPassed {
            get {
                return secondsPassedValueLabel.Text;
            }
            set {
                secondsPassedValueLabel.Text = value;
            }
        }
        public string CurrentFile {
            get {
                return currentFileValueLabel.Text;
            }
            set {
                currentFileValueLabel.Text = value;
            }
        }
        public string FilesProccessed {
            get {
                return totalFilesValueLabel.Text;
            }
            set {
                totalFilesValueLabel.Text = value;
            }
        }
        public TreeView SearchResultsTreeView
        {
            get{
                return searchResultsTreeView;
            }
        }

        public string StartButtonText {
            get { 
                return startButton.Text;
            }
            set{
                startButton.Text = value;
            }
        }
        public string PauseButtonText { 
            get{
                return pauseButton.Text;
            }
            set{
                pauseButton.Text = value;
            }
        }

        public bool StartButtonEnabled {
            get{
                return startButton.Enabled;
            }
            set{
                startButton.Enabled = value;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            Pause();
        }
    }
}
