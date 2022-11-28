
namespace Win_Recorder
{
    partial class frmWebCam
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
            this.picCam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCam)).BeginInit();
            this.SuspendLayout();
            // 
            // picCam
            // 
            this.picCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCam.Location = new System.Drawing.Point(0, 0);
            this.picCam.Name = "picCam";
            this.picCam.Size = new System.Drawing.Size(131, 175);
            this.picCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCam.TabIndex = 0;
            this.picCam.TabStop = false;
            this.picCam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCam_MouseDown);
            this.picCam.MouseEnter += new System.EventHandler(this.picCam_MouseEnter);
            this.picCam.MouseLeave += new System.EventHandler(this.picCam_MouseLeave);
            this.picCam.MouseHover += new System.EventHandler(this.picCam_MouseHover);
            this.picCam.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCam_MouseMove);
            // 
            // frmWebCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(131, 175);
            this.ControlBox = false;
            this.Controls.Add(this.picCam);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmWebCam";
            this.Load += new System.EventHandler(this.frmWebCam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCam;
    }
}