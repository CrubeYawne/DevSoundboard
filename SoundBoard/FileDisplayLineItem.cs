using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
    public partial class FileDisplayLineItem : UserControl
    {
        private string FilePath;
        
        public delegate void PlaySoundEvent(FileDisplayLineItem targetFileItem);

        public event PlaySoundEvent PlaySoundNow; 

        public void SetAltBackground()
        {
            this.BackColor = Color.White;
        }

        public void SetPlaying()
        {
            btnPlaySound.BackColor = Color.Yellow;
        }

        public void SetNotPlaying()
        {
            btnPlaySound.BackColor = Color.White;
        }

        public String GetFilePath()
        {
            return FilePath;
        }

        public void SetFilePath(string fPath)
        {
            FilePath = fPath;
            lblFileName.Text = System.IO.Path.GetFileName(fPath);
        }

        public FileDisplayLineItem()
        {
            InitializeComponent();
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (PlaySoundNow != null)
                PlaySoundNow.Invoke(this);
        }
    }
}
