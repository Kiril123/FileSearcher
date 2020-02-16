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
            this.setupPanel = new System.Windows.Forms.Panel();
            this.setupLabel = new System.Windows.Forms.Label();
            this.directoryPathLabel = new System.Windows.Forms.Label();
            this.filePatternLabel = new System.Windows.Forms.Label();
            this.allowedSymbolsLabel = new System.Windows.Forms.Label();
            this.allowedSymbolsTextBox = new System.Windows.Forms.TextBox();
            this.directoryTextbox = new System.Windows.Forms.TextBox();
            this.fileNamePatternTextBox = new System.Windows.Forms.TextBox();
            this.setupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // setupPanel
            // 
            this.setupPanel.Controls.Add(this.fileNamePatternTextBox);
            this.setupPanel.Controls.Add(this.directoryTextbox);
            this.setupPanel.Controls.Add(this.allowedSymbolsTextBox);
            this.setupPanel.Controls.Add(this.allowedSymbolsLabel);
            this.setupPanel.Controls.Add(this.filePatternLabel);
            this.setupPanel.Controls.Add(this.directoryPathLabel);
            this.setupPanel.Location = new System.Drawing.Point(13, 31);
            this.setupPanel.Name = "setupPanel";
            this.setupPanel.Size = new System.Drawing.Size(519, 100);
            this.setupPanel.TabIndex = 0;
            // 
            // setupLabel
            // 
            this.setupLabel.AutoSize = true;
            this.setupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setupLabel.Location = new System.Drawing.Point(12, 9);
            this.setupLabel.Name = "setupLabel";
            this.setupLabel.Size = new System.Drawing.Size(56, 20);
            this.setupLabel.TabIndex = 0;
            this.setupLabel.Text = "Setup:";
            // 
            // directoryPathLabel
            // 
            this.directoryPathLabel.AutoSize = true;
            this.directoryPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directoryPathLabel.Location = new System.Drawing.Point(5, 12);
            this.directoryPathLabel.Name = "directoryPathLabel";
            this.directoryPathLabel.Size = new System.Drawing.Size(69, 17);
            this.directoryPathLabel.TabIndex = 1;
            this.directoryPathLabel.Text = "Directory:";
            // 
            // filePatternLabel
            // 
            this.filePatternLabel.AutoSize = true;
            this.filePatternLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePatternLabel.Location = new System.Drawing.Point(5, 38);
            this.filePatternLabel.Name = "filePatternLabel";
            this.filePatternLabel.Size = new System.Drawing.Size(83, 17);
            this.filePatternLabel.TabIndex = 2;
            this.filePatternLabel.Text = "File pattern:";
            // 
            // allowedSymbolsLabel
            // 
            this.allowedSymbolsLabel.AutoSize = true;
            this.allowedSymbolsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allowedSymbolsLabel.Location = new System.Drawing.Point(5, 64);
            this.allowedSymbolsLabel.Name = "allowedSymbolsLabel";
            this.allowedSymbolsLabel.Size = new System.Drawing.Size(115, 17);
            this.allowedSymbolsLabel.TabIndex = 3;
            this.allowedSymbolsLabel.Text = "Allowed symbols:";
            // 
            // allowedSymbolsTextBox
            // 
            this.allowedSymbolsTextBox.Location = new System.Drawing.Point(126, 64);
            this.allowedSymbolsTextBox.Name = "allowedSymbolsTextBox";
            this.allowedSymbolsTextBox.Size = new System.Drawing.Size(389, 20);
            this.allowedSymbolsTextBox.TabIndex = 4;
            // 
            // directoryTextbox
            // 
            this.directoryTextbox.Location = new System.Drawing.Point(127, 12);
            this.directoryTextbox.Name = "directoryTextbox";
            this.directoryTextbox.Size = new System.Drawing.Size(389, 20);
            this.directoryTextbox.TabIndex = 5;
            // 
            // fileNamePatternTextBox
            // 
            this.fileNamePatternTextBox.Location = new System.Drawing.Point(126, 38);
            this.fileNamePatternTextBox.Name = "fileNamePatternTextBox";
            this.fileNamePatternTextBox.Size = new System.Drawing.Size(389, 20);
            this.fileNamePatternTextBox.TabIndex = 5;
            // 
            // FileSearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.setupPanel);
            this.Controls.Add(this.setupLabel);
            this.Name = "FileSearcherForm";
            this.Text = "File Searcher";
            this.setupPanel.ResumeLayout(false);
            this.setupPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel setupPanel;
        private System.Windows.Forms.TextBox fileNamePatternTextBox;
        private System.Windows.Forms.TextBox directoryTextbox;
        private System.Windows.Forms.TextBox allowedSymbolsTextBox;
        private System.Windows.Forms.Label allowedSymbolsLabel;
        private System.Windows.Forms.Label filePatternLabel;
        private System.Windows.Forms.Label directoryPathLabel;
        private System.Windows.Forms.Label setupLabel;
    }
}

