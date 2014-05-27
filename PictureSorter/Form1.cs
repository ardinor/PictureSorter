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

    public class saveDirectoryButton : System.Windows.Forms.Button
    {
        public int ID;
        public string folderPath;
    }

    public partial class Form1 : Form
    {
        List<string> pictureList;
        Dictionary<int, saveDirectoryButton> saveDirectoryButtons;
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
            Image image;
            using (FileStream fs = new FileStream(pictureList[index], FileMode.Open, FileAccess.Read))
            {
                image = Image.FromStream(fs);
            }
            //Image image = Image.FromFile(pictureList[index]);
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
                tooltipStrip.Text = tooltipStrip.Text + "   Zoom: " + image.Height / activePictureBox.Size.Height + "%";
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
                        saveDirectoryButtons = new Dictionary<int, saveDirectoryButton>();
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
                            sortDirectoriesLabel.Visible = true;
                            addDirectoryButton.Visible = true;
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

            e.Handled = true;

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

                case Keys.D1:
                case Keys.NumPad1:
                case Keys.Oem1:
                    if (saveDirectoryButtons.ContainsKey(1))
                        saveDirectoryButtons[1].PerformClick();                
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

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Open a directory you wish to move pictures to";
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string folder = dialog.SelectedPath;
                        string dirName = new DirectoryInfo(folder).Name;

                        int newID;
                        if (saveDirectoryButtons.Count > 0)
                        {
                            newID = saveDirectoryButtons.Keys.Max() + 1;
                        }
                        else
                        {
                            newID = 1;
                        }


                        saveDirectoryButton directoryButton;
                        directoryButton = new saveDirectoryButton();
                        directoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        directoryButton.Location = addDirectoryButton.Location;
                        directoryButton.Name = dirName + "Button";
                        directoryButton.Size = new System.Drawing.Size(41, 26);
                        directoryButton.TabIndex = addDirectoryButton.TabIndex -1;
                        directoryButton.AutoSize = true;
                        directoryButton.Text = dirName;
                        directoryButton.folderPath = folder;
                        directoryButton.ID = newID;
                        directoryButton.Visible = true;
                        directoryButton.UseVisualStyleBackColor = true;
                        directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
                        this.Controls.Add(directoryButton);

                        System.Windows.Forms.Label directoryButtonLabel;
                        directoryButtonLabel = new System.Windows.Forms.Label();
                        directoryButtonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        directoryButtonLabel.AutoSize = true;
                        directoryButtonLabel.Location = new System.Drawing.Point(directoryButton.Location.X + ((directoryButton.Size.Width/2)-5), 
                            directoryButton.Location.Y + directoryButton.Size.Height + 5);
                        directoryButtonLabel.Size = new System.Drawing.Size(10, 10);
                        directoryButtonLabel.Text = newID.ToString();
                        this.Controls.Add(directoryButtonLabel);

                        saveDirectoryButtons.Add(newID, directoryButton);

                        //addDirectoryButton.Visible = false;
                        addDirectoryButton.Location = new System.Drawing.Point(addDirectoryButton.Location.X + directoryButton.Size.Width + 10, addDirectoryButton.Location.Y);
                        addDirectoryButton.TabIndex = addDirectoryButton.TabIndex + 1;
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed to open directory: " + ex.Message);
            //}

        }
        private void directoryButton_Click(object sender, EventArgs e)
        {
            //move the picture to the directory here
            //var buttonID = saveDirectoryButtons.FirstOrDefault(x => x.Value == sender).Key;
            saveDirectoryButton button = sender as saveDirectoryButton;
            if (button != null)
            {
                string activePicture = pictureList[activeIndex];
                try
                {                    
                    pictureList.Remove(activePicture);
                    SetActivePicture(pictureList, activeIndex + 1);
                    File.Copy(activePicture, button.folderPath + Path.DirectorySeparatorChar + Path.GetFileName(activePicture));
                    // It still has the file open...
                    File.Delete(activePicture);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Failed to move picture: " + ex.Message);
                }
            }
        }

    }
}
