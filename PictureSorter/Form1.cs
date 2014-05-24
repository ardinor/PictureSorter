using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureSorter
{
    public partial class Form1 : Form
    {
        List<string> pictureList;
        int activeIndex;

        static List<string> ImageFormats = new List<string>
        {
            ".jpeg",
            ".jpg",
            ".png",
            ".gif",
            ".bmp",
            ".tiff",
        };

        public Form1()
        {
            InitializeComponent();          
        }

        private bool CheckValidImage(string filePath)
        {
            try
            {
                Image image = Image.FromFile(filePath);
            }
            catch (OutOfMemoryException ex)
            {
                return false;
            }
            return true;
        }

        private bool CheckValid(string filePath)
        {
            return File.Exists(filePath) && CheckValidImage(filePath);
        }

        private void SetActivePicture(List<string> pictureList, int index)
        {
            bool zoomed = false;
            Image image = Image.FromFile(pictureList[index]);
            activeIndex = index;
            activePictureBox.Image = image;
            if (activePictureBox.Size.Height < image.Height || activePictureBox.Size.Width < image.Width)
            {
                activePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                zoomed = true;
            }
            else
            {
                activePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            tooltipStrip.Text = "File: " + Path.GetFileName(pictureList[index]) +
                "   Height: " + image.Height + "   Width: " + image.Width;
            if (zoomed)
            {
                tooltipStrip.Text = tooltipStrip.Text + "   Zoom: " + image.Height / activePictureBox.Size.Height;
            }
        }

        private void HandleNext()
        {
            if (pictureList != null && pictureList.Count - 1 >= activeIndex + 1)
            {
                SetActivePicture(pictureList, activeIndex + 1);
                if (activeIndex == pictureList.Count - 1)
                {
                    nextButton.Visible = false;
                }
                if (previousButton.Visible == false)
                {
                    previousButton.Visible = true;
                }
            }
        }

        private void HandlePrevious()
        {
            if (pictureList != null && pictureList.Count - 1 >= activeIndex - 1 && activeIndex - 1 != -1)
            {
                SetActivePicture(pictureList, activeIndex - 1);

                if (activeIndex == 0)
                {
                    previousButton.Visible = false;
                }
                if (nextButton.Visible == false)
                {
                    nextButton.Visible = true;
                }
            }
        }

        private void directorySelect_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Open a directory holding the pictures you wish to sort";
                    dialog.ShowNewFolderButton = false;
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string folder = dialog.SelectedPath;
                        directoryLabel.Text = "Now sorting - " + folder;
                        pictureList = new List<string>();
                        foreach (string path in Directory.GetFiles(folder))
                        {
                            if (ImageFormats.Contains(Path.GetExtension(path), StringComparer.OrdinalIgnoreCase) && CheckValid(path))
                            {
                                pictureList.Add(path);
                            }
                        }
                        if (pictureList.Count > 0)
                        {
                            fileCount.Text = "Total images: " + pictureList.Count;
                            //imageDetailsLabel.Visible = true;
                            nextButton.Visible = true;                            
                            SetActivePicture(pictureList, 0);
                        }                    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open directory: " + ex.Message);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //need to override IsInputKey
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keydown%28v=vs.110%29.aspx

            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    HandleNext();              
                    break;

                case Keys.Left:
                case Keys.Down:
                    HandlePrevious();
                    break;
            }            
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            HandleNext();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            HandlePrevious();
        }
    }
}
