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
    public partial class frmColourListEditor : Form
    {
        public frmColourListEditor()
        {
            InitializeComponent();
        }

        private void frmColourListEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Whitelist = txtWhiteList.Text;

            Properties.Settings.Default.Blacklist = txtBlackList.Text;
            
        }

        private void frmColourListEditor_Load(object sender, EventArgs e)
        {
            txtWhiteList.Text = Properties.Settings.Default.Whitelist;

            txtBlackList.Text = Properties.Settings.Default.Blacklist;
        }
    }
}
