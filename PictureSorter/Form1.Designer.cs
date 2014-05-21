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
            ((System.ComponentModel.ISupportInitialize)(this.activePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // activePictureBox
            // 
            this.activePictureBox.Location = new System.Drawing.Point(1, 53);
            this.activePictureBox.Name = "activePictureBox";
            this.activePictureBox.Size = new System.Drawing.Size(762, 520);
            this.activePictureBox.TabIndex = 0;
            this.activePictureBox.TabStop = false;
            // 
            // directorySelect
            // 
            this.directorySelect.Location = new System.Drawing.Point(627, 15);
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
            this.directoryLabel.Text = "Select a directory to being";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 609);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.directorySelect);
            this.Controls.Add(this.activePictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.activePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox activePictureBox;
        private System.Windows.Forms.Button directorySelect;
        private System.Windows.Forms.Label directoryLabel;
    }
}

