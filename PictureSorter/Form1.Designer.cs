namespace PictureSorter
{
    partial class Form1
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
            this.activePictureBox = new System.Windows.Forms.PictureBox();
            this.directorySelect = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.fileCount = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tooltipStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.sortDirectoriesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.activePictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // activePictureBox
            // 
            this.activePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activePictureBox.Location = new System.Drawing.Point(0, 42);
            this.activePictureBox.Name = "activePictureBox";
            this.activePictureBox.Size = new System.Drawing.Size(762, 526);
            this.activePictureBox.TabIndex = 0;
            this.activePictureBox.TabStop = false;
            // 
            // directorySelect
            // 
            this.directorySelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.directorySelect.Location = new System.Drawing.Point(628, 8);
            this.directorySelect.Name = "directorySelect";
            this.directorySelect.Size = new System.Drawing.Size(123, 27);
            this.directorySelect.TabIndex = 1;
            this.directorySelect.Text = "Select Directory";
            this.directorySelect.UseVisualStyleBackColor = true;
            this.directorySelect.Click += new System.EventHandler(this.directorySelect_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(12, 15);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(130, 13);
            this.directoryLabel.TabIndex = 2;
            this.directoryLabel.Text = "Select a directory to begin";
            // 
            // fileCount
            // 
            this.fileCount.AutoSize = true;
            this.fileCount.Location = new System.Drawing.Point(331, 15);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(54, 13);
            this.fileCount.TabIndex = 3;
            this.fileCount.Text = "File Count";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltipStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 636);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(763, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "Ready";
            // 
            // tooltipStrip
            // 
            this.tooltipStrip.Name = "tooltipStrip";
            this.tooltipStrip.Size = new System.Drawing.Size(36, 17);
            this.tooltipStrip.Text = "Ready";
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(726, 586);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(36, 26);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = "→";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Visible = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousButton.Location = new System.Drawing.Point(0, 586);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(36, 26);
            this.previousButton.TabIndex = 9;
            this.previousButton.Text = "←";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Visible = false;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // addDirectoryButton
            // 
            this.addDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addDirectoryButton.Location = new System.Drawing.Point(45, 587);
            this.addDirectoryButton.Name = "addDirectoryButton";
            this.addDirectoryButton.Size = new System.Drawing.Size(41, 26);
            this.addDirectoryButton.TabIndex = 10;
            this.addDirectoryButton.Text = "+ ";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Visible = false;
            this.addDirectoryButton.Click += new System.EventHandler(this.addDirectoryButton_Click);
            // 
            // sortDirectoriesLabel
            // 
            this.sortDirectoriesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sortDirectoriesLabel.AutoSize = true;
            this.sortDirectoriesLabel.Location = new System.Drawing.Point(42, 571);
            this.sortDirectoriesLabel.Name = "sortDirectoriesLabel";
            this.sortDirectoriesLabel.Size = new System.Drawing.Size(79, 13);
            this.sortDirectoriesLabel.TabIndex = 11;
            this.sortDirectoriesLabel.Text = "Sort Directories";
            this.sortDirectoriesLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 658);
            this.Controls.Add(this.sortDirectoriesLabel);
            this.Controls.Add(this.addDirectoryButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fileCount);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.directorySelect);
            this.Controls.Add(this.activePictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Picture Sorter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.activePictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox activePictureBox;
        private System.Windows.Forms.Button directorySelect;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Label fileCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tooltipStrip;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.Label sortDirectoriesLabel;
    }
}

