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
            ((System.ComponentModel.ISupportInitialize)(this.activePictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // activePictureBox
            // 
            this.activePictureBox.Location = new System.Drawing.Point(-1, 42);
            this.activePictureBox.Name = "activePictureBox";
            this.activePictureBox.Size = new System.Drawing.Size(763, 520);
            this.activePictureBox.TabIndex = 0;
            this.activePictureBox.TabStop = false;
            // 
            // directorySelect
            // 
            this.directorySelect.Location = new System.Drawing.Point(628, 12);
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
            this.fileCount.Location = new System.Drawing.Point(13, 42);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(0, 13);
            this.fileCount.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltipStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
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
            // Form1
            // 
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 652);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fileCount);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.directorySelect);
            this.Controls.Add(this.activePictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Picture Sorter";
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
    }
}

