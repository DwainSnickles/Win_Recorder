using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Recorder
{
    public partial class frmToolbar : Form
    {

        private frmRecorder mainForm = null;
        private String videoFolder;

        public bool SpeakersOn { get; private set; }
        public bool MicrophoneOn { get; private set; }
        public bool IsRecording { get; private set; }

        public frmToolbar(Form callingForm)
        {
            //create a instace of frmRecord to access it using mainform
            mainForm = callingForm as frmRecorder;
            InitializeComponent();
        }

        private void LoadRecentVideos()
        {
            mnuRecentVideos.DropDownItems.Clear();

            string[] Videos = GetFiles(Properties.Settings.Default._VideoFolder);

            if (Videos.Count() > 5)
            {
                Videos.Reverse();
                for (int i = 0; i < 5; i++)
                {
                    mnuRecentVideos.DropDownItems.Add(Path.GetFileName(Videos[i].ToString()), Properties.Resources.Picture, nmnuRecentVideos_Click);
                }
            }
            else
            {
                foreach (var item in Videos)
                {
                    mnuRecentVideos.DropDownItems.Add(Path.GetFileName(item.ToString()), Properties.Resources.Picture, nmnuRecentVideos_Click);
                }

                if (Videos.Count() == 0)
                {
                    mnuRecentVideos.DropDownItems.Add("No videos found");
                }
            }
        }

        //starts the default pcs video player
        private void nmnuRecentVideos_Click(object sender, EventArgs e)
        {
            var itemText = (sender as ToolStripMenuItem).Text;

            if (itemText == "Recent Videos") { return; }

            Process.Start(Properties.Settings.Default._VideoFolder + "\\" + itemText);
        }

        private static string[] GetFiles(string path)
        {
            var todaysFiles = Directory.GetFiles(path)
                 .Where(x => new FileInfo(x).CreationTime.Date == DateTime.Today.Date);

            return todaysFiles.ToArray();
        }

        private void btnSpeaker_Click(object sender, EventArgs e)
        {
            if (frmRecorder.IsRecording) { return; }

            switch (Properties.Settings.Default._SpeakersOn)
            {
                case true:
                    Properties.Settings.Default._SpeakersOn = false;
                    btnSpeaker.NormalImage = Properties.Resources.SpeakerMute;
                    SpeakersOn = false;
                    break;

                case false:
                    Properties.Settings.Default._SpeakersOn = true;
                    btnSpeaker.NormalImage = Properties.Resources.SpeakerOn;
                    SpeakersOn = true;
                    break;

                default:
                    break;
            }

            Properties.Settings.Default.Save();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mainForm.PauseVideo();
        }

        private void btnSaveVideo_Click(object sender, EventArgs e)
        {
            if (frmRecorder.IsRecording) { return; }
           
        }

        private void btnSaveVideoPath_Click(object sender, EventArgs e)
        {
            if (frmRecorder.IsRecording) { return; }
            mainForm.TopMost = false;
            if (videoFolder == null)
            {
                videoFolder = Path.Combine(Application.ExecutablePath, "\\Videos");
            }
            if (!Directory.Exists(videoFolder))
            {
                Directory.CreateDirectory(videoFolder);
            }
            System.Diagnostics.Process.Start(videoFolder);
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            if (frmRecorder.IsRecording) { return; }

            switch (Properties.Settings.Default._MicOn)
            {
                case true:
                    Properties.Settings.Default._MicOn = false;
                    btnMic.NormalImage = Properties.Resources.MicMute;
                    MicrophoneOn = false;
                    break;

                case false:
                    Properties.Settings.Default._MicOn = true;
                    btnMic.NormalImage = Properties.Resources.micOn;
                    MicrophoneOn = true;
                    break;

                default:
                    break;
            }

            Properties.Settings.Default.Save();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            mainForm.FormActivated = 0;

            switch (btnStartStop.Tag)
            {
                case "Stop":
                    IsRecording = false;
                    this.TopMost = false;
                    btnStartStop.Tag = "Start";
                    btnStartStop.NormalImage = Properties.Resources.RecoderStopped;
                    tmrElapsedTime.Stop();
                    Properties.Settings.Default._ElapsedTime = TimeSpan.Zero;
                    Properties.Settings.Default.Save();
                    IsRecording = false;
                    mainForm.CleanupResources();
                    break;

                case "Start":
                    IsRecording = true;
                    if (mainForm.RecordFullscreen)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    this.TopMost = true;
                    btnStartStop.Tag = "Stop";
                    btnStartStop.NormalImage = Properties.Resources.RecStarted;
                    tmrElapsedTime.Enabled = true;
                    //Turn off form move and resize this sub will start recorder after that
                    mainForm.AllowResizing();
                    break;

                default:
                    break;
            }
        }

        private void tmrElapsedTime_Tick(object sender, EventArgs e)
        {
            labelTimestamp.Text = Properties.Settings.Default._ElapsedTime.ToString();
        }

        private void frmToolbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmToolbar_Load(object sender, EventArgs e)
        {
            LoadRecentVideos();
        }

        private void customSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuCustomSize.Checked = true;
            mnuFullScreen.Checked = false;
            mainForm.RecordFullscreen = false;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuCustomSize.Checked = false;
            mnuFullScreen.Checked = true;
            mainForm.RecordFullscreen = true;
        }

        private void frmToolbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (mnuCustomSize.Checked) { return; }
           
            if (e.KeyCode == Keys.M && e.Control)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    SetValueCallback("Normal");
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    SetValueCallback("Minimized");
                    this.WindowState = FormWindowState.Minimized;
                    //this.Activate();
                }
            }

        }

        /// <summary>
        /// Receive commands from frmRecorder
        /// </summary>
        /// <param name="v"></param>
        public void SetValueCallback(string v)
        {
            if (mnuCustomSize.Checked) { return; }

            switch (v)
            {
                case "Normal":
                    mainForm.WindowState = FormWindowState.Minimized;
                    //if (IsRecording) { btnStartStop.PerformClick(); }
                    btnStartStop.PerformClick();
                    this.WindowState = FormWindowState.Normal;
                    break;

                case "Minimized":
                    mainForm.WindowState = FormWindowState.Normal;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// to ensure hotkey M works make mainform active to receive hotkey M command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTimestamp_TextChanged(object sender, EventArgs e)
        {
            mainForm.Activate();
        }
    }
}
