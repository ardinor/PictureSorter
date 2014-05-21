﻿using System;
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
                activePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                zoomed = true;
            }
            else
            {
                activePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            //imageHeightLabel.Text = "H: " + image.Height;
            //imageWidthLabel.Text = "W: " + image.Width;
            //imageInfoLabel
            //imageInfoLabel.Visible = true;
            tooltipStrip.Text = "File: " + Path.GetFileName(pictureList[index]) +
                "   Height: " + image.Height + "   Width: " + image.Width;
            if (zoomed)
            {
                tooltipStrip.Text = tooltipStrip.Text + "   Zoom: " + image.Height / activePictureBox.Size.Height;
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
                    if (pictureList.Count <= activeIndex + 1)
                    {
                        SetActivePicture(pictureList, activeIndex + 1);
                        e.Handled = true;
                    }               
                    break;

                case Keys.Left:
                case Keys.Down:
                    if (pictureList.Count >= activeIndex -1)
                    {
                        SetActivePicture(pictureList, activeIndex - 1);
                        e.Handled = true;
                    }
                    break;
            }            
        }
    }
}
