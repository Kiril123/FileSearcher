namespace FileSearcherUI.Views
{
    partial class FileSearcherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryPathLabel = new System.Windows.Forms.Label();
            this.filePatternLabel = new System.Windows.Forms.Label();
            this.allowedSymbolsLabel = new System.Windows.Forms.Label();
            this.allowedSymbolsTextBox = new System.Windows.Forms.TextBox();
            this.directoryTextbox = new System.Windows.Forms.TextBox();
            this.fileNamePatternTextBox = new System.Windows.Forms.TextBox();
            this.searchResultsTreeView = new System.Windows.Forms.TreeView();
            this.metaResultPanel = new System.Windows.Forms.Panel();
            this.currentFileValueLabel = new System.Windows.Forms.Label();
            this.secondsPassedValueLabel = new System.Windows.Forms.Label();
            this.totalFilesValueLabel = new System.Windows.Forms.Label();
            this.totalFilesLabel = new System.Windows.Forms.Label();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.secondsPassedLabel = new System.Windows.Forms.Label();
            this.setupGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.treeResultPanel = new System.Windows.Forms.Panel();
            this.metaResultPanel.SuspendLayout();
            this.setupGroupBox.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.treeResultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryPathLabel
            // 
            this.directoryPathLabel.AutoSize = true;
            this.directoryPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directoryPathLabel.Location = new System.Drawing.Point(6, 26);
            this.directoryPathLabel.Name = "directoryPathLabel";
            this.directoryPathLabel.Size = new System.Drawing.Size(69, 17);
            this.directoryPathLabel.TabIndex = 1;
            this.directoryPathLabel.Text = "Directory:";
            // 
            // filePatternLabel
            // 
            this.filePatternLabel.AutoSize = true;
            this.filePatternLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePatternLabel.Location = new System.Drawing.Point(6, 52);
            this.filePatternLabel.Name = "filePatternLabel";
            this.filePatternLabel.Size = new System.Drawing.Size(83, 17);
            this.filePatternLabel.TabIndex = 2;
            this.filePatternLabel.Text = "File pattern:";
            // 
            // allowedSymbolsLabel
            // 
            this.allowedSymbolsLabel.AutoSize = true;
            this.allowedSymbolsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allowedSymbolsLabel.Location = new System.Drawing.Point(6, 74);
            this.allowedSymbolsLabel.Name = "allowedSymbolsLabel";
            this.allowedSymbolsLabel.Size = new System.Drawing.Size(115, 17);
            this.allowedSymbolsLabel.TabIndex = 3;
            this.allowedSymbolsLabel.Text = "Allowed symbols:";
            // 
            // allowedSymbolsTextBox
            // 
            this.allowedSymbolsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allowedSymbolsTextBox.Location = new System.Drawing.Point(122, 77);
            this.allowedSymbolsTextBox.Name = "allowedSymbolsTextBox";
            this.allowedSymbolsTextBox.Size = new System.Drawing.Size(389, 20);
            this.allowedSymbolsTextBox.TabIndex = 4;
            // 
            // directoryTextbox
            // 
            this.directoryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directoryTextbox.Location = new System.Drawing.Point(122, 25);
            this.directoryTextbox.Name = "directoryTextbox";
            this.directoryTextbox.Size = new System.Drawing.Size(389, 20);
            this.directoryTextbox.TabIndex = 5;
            // 
            // fileNamePatternTextBox
            // 
            this.fileNamePatternTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNamePatternTextBox.Location = new System.Drawing.Point(122, 51);
            this.fileNamePatternTextBox.Name = "fileNamePatternTextBox";
            this.fileNamePatternTextBox.Size = new System.Drawing.Size(389, 20);
            this.fileNamePatternTextBox.TabIndex = 5;
            // 
            // searchResultsTreeView
            // 
            this.searchResultsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResultsTreeView.Location = new System.Drawing.Point(0, 0);
            this.searchResultsTreeView.Name = "searchResultsTreeView";
            this.searchResultsTreeView.Size = new System.Drawing.Size(538, 435);
            this.searchResultsTreeView.TabIndex = 0;
            // 
            // metaResultPanel
            // 
            this.metaResultPanel.AutoSize = true;
            this.metaResultPanel.Controls.Add(this.currentFileValueLabel);
            this.metaResultPanel.Controls.Add(this.secondsPassedValueLabel);
            this.metaResultPanel.Controls.Add(this.totalFilesValueLabel);
            this.metaResultPanel.Controls.Add(this.totalFilesLabel);
            this.metaResultPanel.Controls.Add(this.currentFileLabel);
            this.metaResultPanel.Controls.Add(this.secondsPassedLabel);
            this.metaResultPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.metaResultPanel.Location = new System.Drawing.Point(3, 22);
            this.metaResultPanel.Name = "metaResultPanel";
            this.metaResultPanel.Size = new System.Drawing.Size(538, 58);
            this.metaResultPanel.TabIndex = 1;
            // 
            // currentFileValueLabel
            // 
            this.currentFileValueLabel.AutoSize = true;
            this.currentFileValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFileValueLabel.Location = new System.Drawing.Point(160, 41);
            this.currentFileValueLabel.Name = "currentFileValueLabel";
            this.currentFileValueLabel.Size = new System.Drawing.Size(42, 17);
            this.currentFileValueLabel.TabIndex = 5;
            this.currentFileValueLabel.Text = "None";
            // 
            // secondsPassedValueLabel
            // 
            this.secondsPassedValueLabel.AutoSize = true;
            this.secondsPassedValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondsPassedValueLabel.Location = new System.Drawing.Point(160, 4);
            this.secondsPassedValueLabel.Name = "secondsPassedValueLabel";
            this.secondsPassedValueLabel.Size = new System.Drawing.Size(16, 17);
            this.secondsPassedValueLabel.TabIndex = 4;
            this.secondsPassedValueLabel.Text = "0";
            // 
            // totalFilesValueLabel
            // 
            this.totalFilesValueLabel.AutoSize = true;
            this.totalFilesValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalFilesValueLabel.Location = new System.Drawing.Point(160, 24);
            this.totalFilesValueLabel.Name = "totalFilesValueLabel";
            this.totalFilesValueLabel.Size = new System.Drawing.Size(16, 17);
            this.totalFilesValueLabel.TabIndex = 3;
            this.totalFilesValueLabel.Text = "0";
            // 
            // totalFilesLabel
            // 
            this.totalFilesLabel.AutoSize = true;
            this.totalFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalFilesLabel.Location = new System.Drawing.Point(4, 24);
            this.totalFilesLabel.Name = "totalFilesLabel";
            this.totalFilesLabel.Size = new System.Drawing.Size(150, 17);
            this.totalFilesLabel.TabIndex = 2;
            this.totalFilesLabel.Text = "Total files proccessed:";
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.AutoSize = true;
            this.currentFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFileLabel.Location = new System.Drawing.Point(4, 41);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(85, 17);
            this.currentFileLabel.TabIndex = 1;
            this.currentFileLabel.Text = "Current File:";
            // 
            // secondsPassedLabel
            // 
            this.secondsPassedLabel.AutoSize = true;
            this.secondsPassedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondsPassedLabel.Location = new System.Drawing.Point(4, 4);
            this.secondsPassedLabel.Name = "secondsPassedLabel";
            this.secondsPassedLabel.Size = new System.Drawing.Size(118, 17);
            this.secondsPassedLabel.TabIndex = 0;
            this.secondsPassedLabel.Text = "Seconds Passed:";
            // 
            // setupGroupBox
            // 
            this.setupGroupBox.AutoSize = true;
            this.setupGroupBox.Controls.Add(this.allowedSymbolsLabel);
            this.setupGroupBox.Controls.Add(this.filePatternLabel);
            this.setupGroupBox.Controls.Add(this.allowedSymbolsTextBox);
            this.setupGroupBox.Controls.Add(this.fileNamePatternTextBox);
            this.setupGroupBox.Controls.Add(this.directoryPathLabel);
            this.setupGroupBox.Controls.Add(this.directoryTextbox);
            this.setupGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.setupGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setupGroupBox.Location = new System.Drawing.Point(0, 0);
            this.setupGroupBox.Name = "setupGroupBox";
            this.setupGroupBox.Size = new System.Drawing.Size(544, 122);
            this.setupGroupBox.TabIndex = 2;
            this.setupGroupBox.TabStop = false;
            this.setupGroupBox.Text = "Setup";
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.AutoSize = true;
            this.resultsGroupBox.Controls.Add(this.treeResultPanel);
            this.resultsGroupBox.Controls.Add(this.metaResultPanel);
            this.resultsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultsGroupBox.Location = new System.Drawing.Point(0, 122);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(544, 518);
            this.resultsGroupBox.TabIndex = 3;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Results";
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.pauseButton);
            this.controlsPanel.Controls.Add(this.startButton);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsPanel.Location = new System.Drawing.Point(0, 608);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(544, 32);
            this.controlsPanel.TabIndex = 4;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(89, 4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // treeResultPanel
            // 
            this.treeResultPanel.AutoSize = true;
            this.treeResultPanel.Controls.Add(this.searchResultsTreeView);
            this.treeResultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeResultPanel.Location = new System.Drawing.Point(3, 80);
            this.treeResultPanel.Name = "treeResultPanel";
            this.treeResultPanel.Size = new System.Drawing.Size(538, 435);
            this.treeResultPanel.TabIndex = 2;
            // 
            // FileSearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(544, 640);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.setupGroupBox);
            this.Name = "FileSearcherForm";
            this.Text = "File Searcher";
            this.metaResultPanel.ResumeLayout(false);
            this.metaResultPanel.PerformLayout();
            this.setupGroupBox.ResumeLayout(false);
            this.setupGroupBox.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.resultsGroupBox.PerformLayout();
            this.controlsPanel.ResumeLayout(false);
            this.treeResultPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox fileNamePatternTextBox;
        private System.Windows.Forms.TextBox directoryTextbox;
        private System.Windows.Forms.TextBox allowedSymbolsTextBox;
        private System.Windows.Forms.Label allowedSymbolsLabel;
        private System.Windows.Forms.Label filePatternLabel;
        private System.Windows.Forms.Label directoryPathLabel;
        private System.Windows.Forms.TreeView searchResultsTreeView;
        private System.Windows.Forms.Panel metaResultPanel;
        private System.Windows.Forms.Label currentFileValueLabel;
        private System.Windows.Forms.Label secondsPassedValueLabel;
        private System.Windows.Forms.Label totalFilesValueLabel;
        private System.Windows.Forms.Label totalFilesLabel;
        private System.Windows.Forms.Label currentFileLabel;
        private System.Windows.Forms.Label secondsPassedLabel;
        private System.Windows.Forms.GroupBox setupGroupBox;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel treeResultPanel;
    }
}

