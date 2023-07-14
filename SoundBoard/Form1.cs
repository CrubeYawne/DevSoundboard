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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SoundBoard
{
    public partial class Form1 : Form
    {
        private FileDisplayLineItem last_hit;
        private int button_size = 300;
        private int height = 25;

        private int fileLineHeight = 30;

        private System.Media.SoundPlayer player;

        private const string _currentDirectory = "[Copy To Clipboard] Current Directory: {0}";

        public Form1()
        {
            InitializeComponent();

            numVolume.Value = button_size;

            player = new System.Media.SoundPlayer();

            if(!String.IsNullOrEmpty(Properties.Settings.Default.LastFolderUsed))
            {
                txtFolderName.Text = Properties.Settings.Default.LastFolderUsed;
            }

        }

        /// <summary>
        /// Create Audio player button
        /// </summary>
        /// <param name="targetDestination">Button Parent</param>
        /// <param name="fname">File/folder name to assign the button</param>
        /// <param name="text">Text to display on the button</param>
        /// <param name="idx">item index for height placement</param>
        /// <param name="forec">button fore colour</param>
        private void CreateFolderItem(Panel targetDestination, string fname, string text, int idx, Color forec)
        {
            System.Windows.Forms.Button new_button = new System.Windows.Forms.Button();
            
            //display/visual code
            new_button.ForeColor = forec;            
            new_button.Top = height * idx;
            new_button.Width = button_size;
            new_button.Height = height;
            new_button.TextAlign = ContentAlignment.MiddleRight;
            new_button.Text = text;

            //functional code
            new_button.Click += btnGeneratedFolder_Click;
            new_button.Tag = fname;

            targetDestination.Controls.Add(new_button);
        }

        /// <summary>
        /// Create Audio player button
        /// </summary>
        /// <param name="targetDestination">Button Parent</param>
        /// <param name="fname">File/folder name to assign the button</param>
        /// <param name="text">Text to display on the button</param>
        /// <param name="idx">item index for height placement</param>
        /// <param name="forec">button fore colour</param>
        private void CreateFileItem(Panel targetDestination, string fname, string text, int idx, Color forec)
        {
            FileDisplayLineItem new_file_item = new FileDisplayLineItem();
            new_file_item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            new_file_item.Top = fileLineHeight * idx;
            new_file_item.Width = targetDestination.Width - 50;
            new_file_item.Height = fileLineHeight;

            new_file_item.SetFilePath(fname);
            new_file_item.PlaySoundNow += PlaySoundNow;

            if ((float)idx % 2.0f != 1)
                new_file_item.SetAltBackground();

            targetDestination.Controls.Add(new_file_item);
        }

        public void PlaySoundNow(FileDisplayLineItem targetFileItem)
        {
            if (last_hit != null)//discolor last selected button
                last_hit.SetNotPlaying();

            player.Stop();//stop existing play
            player.SoundLocation = targetFileItem.GetFilePath();//load new sound file

            try
            {
                player.Play();//play sound
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to play file [{0}]: {1}", targetFileItem.GetFilePath(), ex.Message));

            }

            last_hit = targetFileItem;

            last_hit.SetPlaying();
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

            Properties.Settings.Default.LastFolderUsed = fn;
            Properties.Settings.Default.Save();

            //remove existing buttons from last directory
            pnlButtons.Controls.Clear();
            pnlFiles.Controls.Clear();

            int idx = 0;

            lblCurrentDirectory.Text = string.Format(_currentDirectory , fn);
            clipboard_directory = fn;

            //create button to traverse up one directory to the parent
            CreateFolderItem(pnlButtons,Directory.GetParent(fn).FullName, "Parent" , ++idx, Color.Yellow);
            
            string[] dirs = Directory.GetDirectories(fn);

            //loop over all folders in the directory and create button for each directory
            foreach (string f in dirs)
            {
                var filename = Path.GetFileName(f);

                CreateFolderItem(pnlButtons, f, filename, ++idx, Color.Green);

            }

            lblFolders.Text = string.Format("Directories: {0}", dirs.Count());

            string[] files = Directory.GetFiles(fn);

            lblFiles.Text = string.Format("Files: {0}", files.Count());

            int file_idx = 0;

            System.Text.RegularExpressions.Regex whiteListMatch = new System.Text.RegularExpressions.Regex(Properties.Settings.Default.Whitelist, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Regex blackListMatch = new System.Text.RegularExpressions.Regex(Properties.Settings.Default.Blacklist, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            
            //loop over all files in the directory and create button for each file
            foreach (string f in files)
            {
                var filename = Path.GetFileName(f);

                var createLineItem = false;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.Blacklist))//if the file path DOES NOT match the black list
                {
                    createLineItem = !blackListMatch.IsMatch(f);
                }

                if (!string.IsNullOrEmpty(Properties.Settings.Default.Whitelist))// if the file path MATCHES the white list
                {
                    createLineItem =  whiteListMatch.IsMatch(f);
                }
                
                
                //if neither whitelist or blacklist is set, flag item to show
                if(string.IsNullOrEmpty(Properties.Settings.Default.Whitelist) && string.IsNullOrEmpty(Properties.Settings.Default.Blacklist))
                {
                    createLineItem = true;
                }


                if (createLineItem)
                {
                    CreateFileItem(pnlFiles, f, filename, file_idx, Color.Black);
                    ++file_idx;
                }

                
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

        void btnGeneratedFolder_Click(object sender, EventArgs e)
        {

            string tag = (sender as System.Windows.Forms.Button).Tag.ToString();

            //if the tag matches a directory, load the directory
            if (Directory.Exists(tag))
            {
                clipboard_directory = tag;
                lblCurrentDirectory.Text = string.Format(_currentDirectory, tag);
                LoadFolder(tag);
            }
            else
                MessageBox.Show(string.Format("Folder Does not exist: {0}", tag));
            
        }

        private string clipboard_directory;

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
            System.Windows.Forms.Clipboard.SetText(clipboard_directory);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folder_result = folderBrowserMain.ShowDialog();

            if(folder_result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                txtFolderName.Text = folderBrowserMain.SelectedPath;
            }
        }

        private void lblFiles_Click(object sender, EventArgs e)
        {

        }

        private void btnWhiteList_Click(object sender, EventArgs e)
        {
            frmColourListEditor fcl = new frmColourListEditor();

            fcl.ShowDialog();

            
        }

        
    }
}
