
namespace Win_Recorder
{
    partial class frmToolbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToolbar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.ImageButton();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSpeaker = new System.Windows.Forms.ImageButton();
            this.btnOpenVideoPath = new System.Windows.Forms.ImageButton();
            this.btnMic = new System.Windows.Forms.ImageButton();
            this.txtVideoName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.ImageButton();
            this.btnPause = new System.Windows.Forms.ImageButton();
            this.tmrElapsedTime = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuRecentVideos = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomSize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSpeaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenVideoPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPause)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.pnlControls);
            this.panel1.Controls.Add(this.txtVideoName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelTimestamp);
            this.panel1.Controls.Add(this.btnStartStop);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 40);
            this.panel1.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.DownImage = null;
            this.btnExit.HoverImage = null;
            this.btnExit.Location = new System.Drawing.Point(329, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.NormalImage = global::Win_Recorder.Properties.Resources.Exit;
            this.btnExit.Size = new System.Drawing.Size(40, 30);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExit.TabIndex = 35;
            this.btnExit.TabStop = false;
            this.btnExit.Tag = "Start";
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnSpeaker);
            this.pnlControls.Controls.Add(this.btnOpenVideoPath);
            this.pnlControls.Controls.Add(this.btnMic);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(102, 38);
            this.pnlControls.TabIndex = 34;
            // 
            // btnSpeaker
            // 
            this.btnSpeaker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSpeaker.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSpeaker.DownImage = null;
            this.btnSpeaker.HoverImage = null;
            this.btnSpeaker.Location = new System.Drawing.Point(3, 4);
            this.btnSpeaker.Name = "btnSpeaker";
            this.btnSpeaker.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSpeaker.NormalImage")));
            this.btnSpeaker.Size = new System.Drawing.Size(30, 30);
            this.btnSpeaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSpeaker.TabIndex = 27;
            this.btnSpeaker.TabStop = false;
            this.btnSpeaker.Click += new System.EventHandler(this.btnSpeaker_Click);
            // 
            // btnOpenVideoPath
            // 
            this.btnOpenVideoPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnOpenVideoPath.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOpenVideoPath.DownImage = null;
            this.btnOpenVideoPath.HoverImage = null;
            this.btnOpenVideoPath.Location = new System.Drawing.Point(67, 4);
            this.btnOpenVideoPath.Name = "btnOpenVideoPath";
            this.btnOpenVideoPath.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnOpenVideoPath.NormalImage")));
            this.btnOpenVideoPath.Size = new System.Drawing.Size(30, 30);
            this.btnOpenVideoPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnOpenVideoPath.TabIndex = 29;
            this.btnOpenVideoPath.TabStop = false;
            this.btnOpenVideoPath.Click += new System.EventHandler(this.btnSaveVideoPath_Click);
            // 
            // btnMic
            // 
            this.btnMic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMic.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMic.DownImage = null;
            this.btnMic.HoverImage = null;
            this.btnMic.Location = new System.Drawing.Point(35, 4);
            this.btnMic.Name = "btnMic";
            this.btnMic.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnMic.NormalImage")));
            this.btnMic.Size = new System.Drawing.Size(30, 30);
            this.btnMic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMic.TabIndex = 28;
            this.btnMic.TabStop = false;
            this.btnMic.Click += new System.EventHandler(this.btnMic_Click);
            // 
            // txtVideoName
            // 
            this.txtVideoName.Location = new System.Drawing.Point(177, 16);
            this.txtVideoName.Name = "txtVideoName";
            this.txtVideoName.Size = new System.Drawing.Size(77, 20);
            this.txtVideoName.TabIndex = 11;
            this.txtVideoName.Text = "VideoName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Video Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Video Name";
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTimestamp.Location = new System.Drawing.Point(111, 19);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(51, 15);
            this.labelTimestamp.TabIndex = 26;
            this.labelTimestamp.Text = "00:00:00";
            this.labelTimestamp.TextChanged += new System.EventHandler(this.labelTimestamp_TextChanged);
            // 
            // btnStartStop
            // 
            this.btnStartStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnStartStop.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartStop.DownImage = null;
            this.btnStartStop.HoverImage = null;
            this.btnStartStop.Location = new System.Drawing.Point(297, 4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnStartStop.NormalImage")));
            this.btnStartStop.Size = new System.Drawing.Size(30, 30);
            this.btnStartStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnStartStop.TabIndex = 32;
            this.btnStartStop.TabStop = false;
            this.btnStartStop.Tag = "Start";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPause.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPause.DownImage = null;
            this.btnPause.HoverImage = null;
            this.btnPause.Location = new System.Drawing.Point(264, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnPause.NormalImage")));
            this.btnPause.Size = new System.Drawing.Size(30, 30);
            this.btnPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPause.TabIndex = 31;
            this.btnPause.TabStop = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tmrElapsedTime
            // 
            this.tmrElapsedTime.Tick += new System.EventHandler(this.tmrElapsedTime_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRecentVideos,
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuRecentVideos
            // 
            this.mnuRecentVideos.Name = "mnuRecentVideos";
            this.mnuRecentVideos.Size = new System.Drawing.Size(121, 20);
            this.mnuRecentVideos.Text = "View Recent Videos";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCustomSize,
            this.mnuFullScreen});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // mnuCustomSize
            // 
            this.mnuCustomSize.Checked = true;
            this.mnuCustomSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuCustomSize.Name = "mnuCustomSize";
            this.mnuCustomSize.Size = new System.Drawing.Size(139, 22);
            this.mnuCustomSize.Text = "Custom Size";
            this.mnuCustomSize.Click += new System.EventHandler(this.customSizeToolStripMenuItem_Click);
            // 
            // mnuFullScreen
            // 
            this.mnuFullScreen.Name = "mnuFullScreen";
            this.mnuFullScreen.Size = new System.Drawing.Size(139, 22);
            this.mnuFullScreen.Text = "Full Screen";
            this.mnuFullScreen.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 67);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Recorder Idle";
            // 
            // frmToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 83);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmToolbar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmToolbar_FormClosing);
            this.Load += new System.EventHandler(this.frmToolbar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmToolbar_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSpeaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenVideoPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPause)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageButton btnPause;
        private System.Windows.Forms.ImageButton btnOpenVideoPath;
        private System.Windows.Forms.ImageButton btnMic;
        private System.Windows.Forms.ImageButton btnSpeaker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVideoName;
        public System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.Timer tmrElapsedTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentVideos;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomSize;
        private System.Windows.Forms.ToolStripMenuItem mnuFullScreen;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.ImageButton btnStartStop;
        public System.Windows.Forms.ImageButton btnExit;
    }
}