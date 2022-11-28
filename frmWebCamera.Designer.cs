
namespace Win_Recorder
{
    partial class frmWebCamera
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
            this.SuspendLayout();
            // 
            // frmWebCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(120, 141);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.Name = "frmWebCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmWebCamera_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmWebCamera_MouseDown);
            this.MouseEnter += new System.EventHandler(this.frmWebCamera_MouseEnter);
            this.MouseHover += new System.EventHandler(this.frmWebCamera_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmWebCamera_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}