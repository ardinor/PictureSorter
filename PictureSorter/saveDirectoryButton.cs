using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureSorter
{
    public class saveDirectoryButton : System.Windows.Forms.Button
    {
        public int ID;
        public string folderPath;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
