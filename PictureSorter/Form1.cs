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

        private enum ImageFormats
        {
            jpeg,
            jpg,
            png,
            gif,
            bmp,
            tiff,
        }

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
            Image image = Image.FromFile(pictureList[index]);
            activeIndex = index;
            activePictureBox.Image = image;
            if (activePictureBox.Size.Height < image.Height || activePictureBox.Size.Width < image.Width)
            {
                activePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                activePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
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
                            if (CheckValid(path))
                            {
                                pictureList.Add(path);
                            }
                        }
                        if (pictureList.Count > 0)
                        {
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
    }
}
