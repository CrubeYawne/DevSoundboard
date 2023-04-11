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

        private const string _currentDirectory = "[Copy To Clipboard] Current Directory: {0}";

        public Form1()
        {
            InitializeComponent();

            numVolume.Value = button_size;

            player = new System.Media.SoundPlayer();
        }

        /// <summary>
        /// Create Audio player button
        /// </summary>
        /// <param name="targetDestination">Button Parent</param>
        /// <param name="fname">File/folder name to assign the button</param>
        /// <param name="text">Text to display on the button</param>
        /// <param name="idx">item index for height placement</param>
        /// <param name="forec">button fore colour</param>
        private void CreateButton(Panel targetDestination, string fname, string text, int idx, Color forec)
        {
            Button new_button = new Button();
            
            //display/visual code
            new_button.ForeColor = forec;            
            new_button.Top = height * idx;
            new_button.Width = button_size;
            new_button.Height = height;
            new_button.TextAlign = ContentAlignment.MiddleRight;
            new_button.Text = text;

            //functional code
            new_button.Click += btnGeneratedButton_Click;
            new_button.Tag = fname;

            targetDestination.Controls.Add(new_button);
        }

        /// <summary>
        /// Load a folder from the system
        /// </summary>
        /// <param name="fn">string full directory path to load</param>
        private void LoadFolder(string fn)
        {

            //if something weird happens
            if(!System.IO.Directory.Exists(fn))
            {

                MessageBox.Show("Directory does not exist");
                return;
            }

            //remove existing buttons from last directory
            pnlButtons.Controls.Clear();
            pnlFiles.Controls.Clear();

            int idx = 0;

            lblCurrentDirectory.Text = string.Format(_currentDirectory , fn);

            //create button to traverse up one directory to the parent
            CreateButton(pnlButtons,Directory.GetParent(fn).FullName, "Parent" , ++idx, Color.Yellow);
            
            string[] dirs = Directory.GetDirectories(fn);

            //loop over all folders in the directory and create button for each directory
            foreach (string f in dirs)
            {
                var filename = Path.GetFileName(f);

                CreateButton(pnlButtons, f, filename, ++idx, Color.Green);

            }

            lblFolders.Text = string.Format("Directories: {0}", dirs.Count());

            string[] files = Directory.GetFiles(fn);

            lblFiles.Text = string.Format("Files: {0}", files.Count());

            //loop over all files in the directory and create button for each file
            foreach (string f in files)
            {
                var filename = Path.GetFileName(f);               

                CreateButton(pnlFiles, f, filename, ++idx, Color.Black);
            }

            
        }

        /// <summary>
        /// Create a label and add to target panel
        /// </summary>
        /// <param name="targetPanel">target parent panel to attach to</param>
        /// <param name="label">text label value</param>
        private void CreateLabel(Panel targetPanel, string label)
        {
            Label lblHeading = new Label();
            lblHeading.Text = label;
            
            targetPanel.Controls.Add(lblHeading);
        }

        /// <summary>
        /// react to user clicking on a folder button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFolder_Click(object sender, EventArgs e)
        {
            string fname = txtFolderName.Text;

            if (string.IsNullOrEmpty(fname))
                MessageBox.Show("No path provided");
            else
                LoadFolder(fname);
                
        }

        void btnGeneratedButton_Click(object sender, EventArgs e)
        {

            string tag = (sender as Button).Tag.ToString();

            //if the tag matches a directory, load the directory
            if (Directory.Exists(tag))
            {
                lblCurrentDirectory.Text = string.Format(_currentDirectory , tag);
                LoadFolder(tag);
            }
            else//the tag should point to a raw (sound) file
            {
                
                if (last_hit != null)//discolor last selected button
                    last_hit.BackColor = Color.Transparent;
                                
                player.Stop();//stop existing play
                player.SoundLocation = (sender as Button).Tag.ToString();//load new sound file
                player.Play();//play sound


                last_hit = (sender as Button);

                last_hit.BackColor = Color.Yellow;//Color selected button
            }
        }

        private void btnStopSFX_Click(object sender, EventArgs e)
        {
            player.Stop();
        }


        /// <summary>
        /// Change the volume of the media player
        /// </summary>
        /// <remarks>Sadly, the current player doesn't support setting volume options</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numVolume_ValueChanged(object sender, EventArgs e)
        {
            button_size = (int)numVolume.Value;
            foreach (Control c in pnlButtons.Controls)
                c.Width = (int)numVolume.Value;
        }

        /// <summary>
        /// Copy the current directory to the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCurrentDirectory_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText((sender as Label).Text);
        }
    }
}
