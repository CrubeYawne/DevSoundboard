
namespace SoundBoard
{
    partial class frmColourListEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWhiteList = new System.Windows.Forms.TextBox();
            this.txtBlackList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "White List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Black List";
            // 
            // txtWhiteList
            // 
            this.txtWhiteList.Location = new System.Drawing.Point(16, 25);
            this.txtWhiteList.Multiline = true;
            this.txtWhiteList.Name = "txtWhiteList";
            this.txtWhiteList.Size = new System.Drawing.Size(772, 63);
            this.txtWhiteList.TabIndex = 2;
            // 
            // txtBlackList
            // 
            this.txtBlackList.Location = new System.Drawing.Point(16, 107);
            this.txtBlackList.Multiline = true;
            this.txtBlackList.Name = "txtBlackList";
            this.txtBlackList.Size = new System.Drawing.Size(769, 63);
            this.txtBlackList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "!Uses regex!";
            // 
            // frmColourListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 183);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBlackList);
            this.Controls.Add(this.txtWhiteList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmColourListEditor";
            this.Text = "List Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmColourListEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmColourListEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWhiteList;
        private System.Windows.Forms.TextBox txtBlackList;
        private System.Windows.Forms.Label label3;
    }
}