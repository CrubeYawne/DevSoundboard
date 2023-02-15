using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
    public partial class Form1 : Form
    {
        private Button last_hit;
        private int button_size = 300;
        private int height = 25;

        private System.Media.SoundPlayer player;

        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Value = button_size;

            player = new System.Media.SoundPlayer();
        }


        private void CreateButton(Panel targetDestination, string fname, string text, int idx, Color forec)
        {
            Button new_button = new Button();
            new_button.Click += new_button_Click;
            new_button.ForeColor = forec;
            new_button.Tag = fname;
            new_button.Top = height * idx;
            new_button.Width = button_size;
            new_button.Height = height;
            new_button.TextAlign = ContentAlignment.MiddleRight;
            new_button.Text = text;
            targetDestination.Controls.Add(new_button);
        }

        private void LoadFolder(string fn)
        {

            if(!System.IO.Directory.Exists(fn))
            {

                MessageBox.Show("Directory does not exist");
                return;
            }

            pnlButtons.Controls.Clear();
            pnlFiles.Controls.Clear();

            int idx = 0;

            lblCurrentDirectory.Text = fn;

            CreateButton(pnlButtons,Directory.GetParent(fn).FullName, "Parent" , ++idx, Color.Yellow);
            
            string[] dirs = Directory.GetDirectories(fn);

            char lastChar = ' ';

            foreach (string f in dirs)
            {
                var filename = Path.GetFileName(f);

                CreateButton(pnlButtons, f, filename, ++idx, Color.Green);

            }

            lblFolders.Text = string.Format("Directories: {0}", dirs.Count());

            string[] files = Directory.GetFiles(fn);

            lastChar = ' ';


            lblFiles.Text = string.Format("Files: {0}", files.Count());

            foreach (string f in files)
            {
                var filename = Path.GetFileName(f);               

                CreateButton(pnlFiles, f, filename, ++idx, Color.Black);
            }

            
        }

        private void CreateLabel(Panel targetPanel, string label)
        {
            Label lblHeading = new Label();
            lblHeading.Text = label;
            
            targetPanel.Controls.Add(lblHeading);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = txtFolderName.Text;

            if (string.IsNullOrEmpty(fname))
                MessageBox.Show("No path provided");
            else
                LoadFolder(fname);
                
        }

        void new_button_Click(object sender, EventArgs e)
        {

            string tag = (sender as Button).Tag.ToString();

            if (Directory.Exists(tag))
            {
                lblCurrentDirectory.Text = tag;
                LoadFolder(tag);
            }
            else
            {
                if (last_hit != null)
                    last_hit.BackColor = Color.Transparent;



                player.Stop();
                player.SoundLocation = (sender as Button).Tag.ToString();
                player.Play();


                last_hit = (sender as Button);

                last_hit.BackColor = Color.Yellow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button_size = (int)numericUpDown1.Value;
            foreach (Control c in pnlButtons.Controls)
                c.Width = (int)numericUpDown1.Value;
        }

        private void lblCurrentDirectory_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText((sender as Label).Text);
        }
    }
}
