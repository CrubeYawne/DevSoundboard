namespace SoundBoard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.btnLoadFolder = new System.Windows.Forms.Button();
            this.btnStopSFX = new System.Windows.Forms.Button();
            this.numVolume = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.pnlFiles = new System.Windows.Forms.Panel();
            this.lblFolders = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.folderBrowserMain = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlButtons.AutoScroll = true;
            this.pnlButtons.Location = new System.Drawing.Point(12, 92);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(468, 305);
            this.pnlButtons.TabIndex = 0;
            // 
            // txtFolderName
            // 
            this.txtFolderName.AccessibleDescription = "Directory";
            this.txtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFolderName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtFolderName.Location = new System.Drawing.Point(97, 12);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(616, 20);
            this.txtFolderName.TabIndex = 0;
            // 
            // btnLoadFolder
            // 
            this.btnLoadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFolder.Location = new System.Drawing.Point(719, 12);
            this.btnLoadFolder.Name = "btnLoadFolder";
            this.btnLoadFolder.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFolder.TabIndex = 1;
            this.btnLoadFolder.Text = "Load";
            this.btnLoadFolder.UseVisualStyleBackColor = true;
            this.btnLoadFolder.Click += new System.EventHandler(this.btnLoadFolder_Click);
            // 
            // btnStopSFX
            // 
            this.btnStopSFX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopSFX.Location = new System.Drawing.Point(800, 12);
            this.btnStopSFX.Name = "btnStopSFX";
            this.btnStopSFX.Size = new System.Drawing.Size(75, 23);
            this.btnStopSFX.TabIndex = 2;
            this.btnStopSFX.Text = "Stop SFX";
            this.btnStopSFX.UseVisualStyleBackColor = true;
            this.btnStopSFX.Click += new System.EventHandler(this.btnStopSFX_Click);
            // 
            // numVolume
            // 
            this.numVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numVolume.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numVolume.Location = new System.Drawing.Point(882, 14);
            this.numVolume.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numVolume.Name = "numVolume";
            this.numVolume.Size = new System.Drawing.Size(54, 20);
            this.numVolume.TabIndex = 3;
            this.numVolume.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numVolume.Visible = false;
            this.numVolume.ValueChanged += new System.EventHandler(this.numVolume_ValueChanged);
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(12, 50);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(86, 13);
            this.lblCurrentDirectory.TabIndex = 4;
            this.lblCurrentDirectory.Text = "Current Directory";
            this.lblCurrentDirectory.Click += new System.EventHandler(this.lblCurrentDirectory_Click);
            // 
            // pnlFiles
            // 
            this.pnlFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiles.AutoScroll = true;
            this.pnlFiles.Location = new System.Drawing.Point(486, 92);
            this.pnlFiles.Name = "pnlFiles";
            this.pnlFiles.Size = new System.Drawing.Size(451, 305);
            this.pnlFiles.TabIndex = 0;
            // 
            // lblFolders
            // 
            this.lblFolders.AutoSize = true;
            this.lblFolders.Location = new System.Drawing.Point(12, 76);
            this.lblFolders.Name = "lblFolders";
            this.lblFolders.Size = new System.Drawing.Size(57, 13);
            this.lblFolders.TabIndex = 5;
            this.lblFolders.Text = "Directories";
            // 
            // lblFiles
            // 
            this.lblFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(483, 76);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(28, 13);
            this.lblFiles.TabIndex = 5;
            this.lblFiles.Text = "Files";
            this.lblFiles.Click += new System.EventHandler(this.lblFiles_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 409);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.lblFolders);
            this.Controls.Add(this.lblCurrentDirectory);
            this.Controls.Add(this.numVolume);
            this.Controls.Add(this.btnStopSFX);
            this.Controls.Add(this.btnLoadFolder);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.pnlFiles);
            this.Controls.Add(this.pnlButtons);
            this.Name = "Form1";
            this.Text = "Sound Board";
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Button btnLoadFolder;
        private System.Windows.Forms.Button btnStopSFX;
        private System.Windows.Forms.NumericUpDown numVolume;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.Panel pnlFiles;
        private System.Windows.Forms.Label lblFolders;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserMain;
        private System.Windows.Forms.Button btnBrowse;
    }
}

