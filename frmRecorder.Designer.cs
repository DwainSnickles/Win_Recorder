
namespace Win_Recorder
{
    partial class frmRecorder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecorder));
            this.lblMessage = new System.Windows.Forms.Label();
            this.tmrCountDown = new System.Windows.Forms.Timer(this.components);
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lblFullScreenMessage = new System.Windows.Forms.Label();
            this.webCam1 = new System.Windows.Forms.PictureBox();
            this.cboCameras = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.webCam1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMessage.Location = new System.Drawing.Point(112, 97);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(315, 31);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Recording Will Start In:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // tmrCountDown
            // 
            this.tmrCountDown.Interval = 1000;
            this.tmrCountDown.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCountDown
            // 
            this.lblCountDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCountDown.Location = new System.Drawing.Point(236, 128);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(99, 108);
            this.lblCountDown.TabIndex = 2;
            this.lblCountDown.Text = "5";
            this.lblCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountDown.Visible = false;
            // 
            // lblFullScreenMessage
            // 
            this.lblFullScreenMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullScreenMessage.AutoSize = true;
            this.lblFullScreenMessage.BackColor = System.Drawing.Color.Yellow;
            this.lblFullScreenMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullScreenMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullScreenMessage.Location = new System.Drawing.Point(118, 36);
            this.lblFullScreenMessage.Name = "lblFullScreenMessage";
            this.lblFullScreenMessage.Size = new System.Drawing.Size(294, 22);
            this.lblFullScreenMessage.TabIndex = 4;
            this.lblFullScreenMessage.Text = "To stop recording press M (HotKey)";
            this.lblFullScreenMessage.Visible = false;
            // 
            // webCam1
            // 
            this.webCam1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.webCam1.BackColor = System.Drawing.Color.Snow;
            this.webCam1.Location = new System.Drawing.Point(397, 210);
            this.webCam1.Name = "webCam1";
            this.webCam1.Size = new System.Drawing.Size(175, 139);
            this.webCam1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webCam1.TabIndex = 11;
            this.webCam1.TabStop = false;
            // 
            // cboCameras
            // 
            this.cboCameras.FormattingEnabled = true;
            this.cboCameras.Location = new System.Drawing.Point(360, 12);
            this.cboCameras.Name = "cboCameras";
            this.cboCameras.Size = new System.Drawing.Size(197, 21);
            this.cboCameras.TabIndex = 12;
            this.cboCameras.Visible = false;
            this.cboCameras.SelectedIndexChanged += new System.EventHandler(this.cboCameras_SelectedIndexChanged);
            // 
            // frmRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblFullScreenMessage);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.webCam1);
            this.Controls.Add(this.cboCameras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRecorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Recorder Screen";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Snow;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecorder_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecorder_KeyDown);
            this.MouseEnter += new System.EventHandler(this.frmRecorder_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.webCam1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer tmrCountDown;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Label lblFullScreenMessage;
        internal System.Windows.Forms.PictureBox webCam1;
        public System.Windows.Forms.ComboBox cboCameras;
    }
}