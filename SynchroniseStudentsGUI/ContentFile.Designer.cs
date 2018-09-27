namespace SynchroniseStudentsGUI
{
    partial class ContentFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentFile));
            this.rtfFile = new System.Windows.Forms.RichTextBox();
            this.statusFile = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdSave = new System.Windows.Forms.ToolStripSplitButton();
            this.statusFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfFile
            // 
            this.rtfFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfFile.Location = new System.Drawing.Point(0, 0);
            this.rtfFile.Name = "rtfFile";
            this.rtfFile.Size = new System.Drawing.Size(842, 329);
            this.rtfFile.TabIndex = 0;
            this.rtfFile.Text = "";
            // 
            // statusFile
            // 
            this.statusFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.cmdSave});
            this.statusFile.Location = new System.Drawing.Point(0, 307);
            this.statusFile.Name = "statusFile";
            this.statusFile.Size = new System.Drawing.Size(842, 22);
            this.statusFile.TabIndex = 1;
            this.statusFile.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(136, 17);
            this.lblStatus.Text = "Aucune action effectuée";
            // 
            // cmdSave
            // 
            this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSave.Image = global::SynchroniseStudentsGUI.Properties.Resources.disk;
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(32, 20);
            this.cmdSave.Text = "Enregistrer le fichier";
            this.cmdSave.ButtonClick += new System.EventHandler(this.cmdSave_ButtonClick);
            // 
            // ContentFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 329);
            this.Controls.Add(this.statusFile);
            this.Controls.Add(this.rtfFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContentFile";
            this.Text = "ContentFile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContentFile_Load);
            this.statusFile.ResumeLayout(false);
            this.statusFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfFile;
        private System.Windows.Forms.StatusStrip statusFile;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSplitButton cmdSave;
    }
}