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
                //this caused the file to lock
                //Image image = Image.FromFile(filePath);
                Image image;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    image = Image.FromStream(fs);
                }
            }
            catch (ArgumentException ex)
            {
                return false;
            }
            //catch (OutOfMemoryException ex)
            //{
            //    return false;
            //}
            return true;
        }

        private bool CheckValid(string filePath)
        {
            return File.Exists(filePath) && CheckValidImage(filePath);
        }

        private void SetActivePicture(List<string> pictureList, int index)
        {
            if (pictureList.Count > 0)
            {

                bool zoomed = false;
                activePictureBox.Image = null;
                Image image;
                using (FileStream fs = new FileStream(pictureList[index], FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
                {
                    image = Image.FromStream(fs);                
                }
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
                    double perc = (double)activePictureBox.Size.Height / image.Height;
                    perc = perc * 100;
                    tooltipStrip.Text = tooltipStrip.Text + "   Zoom: " + String.Format("{0:0.##}", perc) + "%";
                }
            }
            else
            {
                activePictureBox.Image = null;
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

        private void UndoMove(undoMenuItem menuItem)
        {
            //undo move
            File.Copy(menuItem.newPath, menuItem.oldPath);
            File.Delete(menuItem.newPath);
            pictureList.Insert(activeIndex, menuItem.oldPath);
            SetActivePicture(pictureList, activeIndex);
            fileCount.Text = "Total images: " + pictureList.Count;
            this.undoToolStripMenuItem.DropDownItems.Remove(menuItem);
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
                            fileCount.Visible = true;
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

        private void button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void button_KeyDown(object sender, KeyEventArgs e)
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

        private void form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (this.undoToolStripMenuItem.DropDownItems.Count > 0)
                {
                    undoMenuItem lastAdded = (undoMenuItem)this.undoToolStripMenuItem.DropDownItems[this.undoToolStripMenuItem.DropDownItems.Count-1];
                    UndoMove(lastAdded);
                }
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
            try
            {
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
                        directoryButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_KeyDown);
                        directoryButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button_PreviewKeyDown);
                        // Add the event handler to allow changing the directory of the folder
                        directoryButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.directoryButton_MouseUp);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open directory: " + ex.Message);
            }

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
                    SetActivePicture(pictureList, activeIndex);             
                    fileCount.Text = "Total images: " + pictureList.Count;
                    File.Copy(activePicture, button.folderPath + Path.DirectorySeparatorChar + Path.GetFileName(activePicture));
                    File.Delete(activePicture);

                    this.undoToolStripMenuEntry = new undoMenuItem();
                    this.undoToolStripMenuEntry.Name = Path.GetFileName(activePicture);
                    this.undoToolStripMenuEntry.Size = new System.Drawing.Size(124, 22);
                    this.undoToolStripMenuEntry.Text = Path.GetFileName(activePicture) + "  ->  " + button.folderPath;
                    this.undoToolStripMenuEntry.oldPath = activePicture;
                    this.undoToolStripMenuEntry.newPath = button.folderPath + Path.DirectorySeparatorChar + Path.GetFileName(activePicture);
                    this.undoToolStripMenuEntry.Click += new System.EventHandler(this.undoToolStripMenuEntry_Click);

                    this.undoToolStripMenuItem.DropDownItems.Add(this.undoToolStripMenuEntry);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Failed to move picture: " + ex.Message);
                }
            }
        }

        private void directoryButton_MouseUp(object sender, MouseEventArgs e)
        {
            // When we right click on a button, allow the user to change the save directory
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                saveDirectoryButton button = sender as saveDirectoryButton;
                if (button != null)
                {
                    try
                    {
                        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                        {
                            dialog.Description = "Open a directory you wish to move pictures to";
                            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                string folder = dialog.SelectedPath;
                                string dirName = new DirectoryInfo(folder).Name;
                                button.Text = dirName;
                                button.folderPath = folder;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuEntry_Click(object sender, EventArgs e)
        {
            undoMenuItem senderItem = sender as undoMenuItem;
            UndoMove(senderItem);
        }
    }
}
