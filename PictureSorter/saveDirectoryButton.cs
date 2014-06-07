using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureSorter
{
    public class saveDirectoryButton : Button
    {
        public int ID;
        public string folderPath;
        public System.Windows.Forms.Label saveDirectoryButtonLabel;

        //protected override bool IsInputKey(Keys keyData)
        //{
            //if (keyData == Keys.Up)
            //{
            //    return true;
            //}
            //else if (keyData == Keys.Down)
            //{
            //    return true;
            //}
            //else if (keyData == Keys.Left)
            //{
            //    return true;
            //}
            //else if (keyData == Keys.Right)
            //{
            //    return true;
            //}
            //else
            //{
            //    return base.IsInputKey(keyData);
            //}
        //}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }

    public class undoMenuItem : ToolStripMenuItem
    {
        public string oldPath;
        public string newPath;
    }


        //private System.Windows.Forms.Label directoryLabel;
        //private System.Windows.Forms.Label fileCount;
        //private System.Windows.Forms.StatusStrip statusStrip1;
        //private System.Windows.Forms.ToolStripStatusLabel tooltipStrip;
        //private System.Windows.Forms.Label sortDirectoriesLabel;
}
