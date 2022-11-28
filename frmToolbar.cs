using AForge.Video.DirectShow;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        //Web Cam Variables
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public delegate void SetValueDelegate(string value);
        public SetValueDelegate CallWebCamForm;

        public frmToolbar(Form callingForm)
        {
            //create a instace of frmRecord to access it using mainform
            mainForm = callingForm as frmRecorder;
            InitializeComponent();
            frmWebCam frmWCam = new frmWebCam(this);
            this.CallWebCamForm += new SetValueDelegate(frmWCam.SetValueCallback);
        }

        private void frmToolbar_Load(object sender, EventArgs e)
        {
            LoadRecentVideos();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboCameras.Items.Add(filterInfo.Name);
            }
            this.Top += 40;
            this.Left += 20;
            cboCameras.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
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
            if (File.Exists(Properties.Settings.Default._VideoFolder + "\\" + itemText))
            {
                Process.Start(Properties.Settings.Default._VideoFolder + "\\" + itemText);
            }
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
                    //mainForm.CountDown == 5;
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

        private void customSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuCustomSize.Checked = true;
            mnuFullScreen.Checked = false;
            mainForm.RecordFullscreen = false;

            if (ckbUseWebCam.Checked)
            {
                btnStartWebCam.PerformClick();
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuCustomSize.Checked = false;
            mnuFullScreen.Checked = true;
            mainForm.RecordFullscreen = true;

            if (ckbUseWebCam.Checked)
            {
                btnStartWebCam.PerformClick();
            }
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
            //if (mnuCustomSize.Checked) { return; }

            if (v.StartsWith("CameraIndex"))
            {
                String[] index = v.Split('_');
                cboCameras.SelectedItem = index[1];
                return;
            }

            switch (v)
            {
                case "Normal":
                    mainForm.WindowState = FormWindowState.Minimized;
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

        private void btnStartWebCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ckbUseWebCam.Checked) { MessageBox.Show("Please check the Use Web Camera Checkbox to enable camera usage", "Camera not enabled", MessageBoxButtons.OK); return; }

                if (mnuFullScreen.Checked) //use external form
                {
                    CallWebCamForm("EnableWebCam");
                    mainForm.webCam1.Visible = false;

                }
                else
                {
                    CallWebCamForm("DisableWebCam");
                    //Use recorder forms Web Cam picturebox
                    mainForm.StartWebCam(cboCameras.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmToolbar_MouseEnter(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void cboCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallWebCamForm("CameraIndex__" + cboCameras.SelectedIndex);
            mainForm.SetCboIndex(cboCameras.SelectedIndex);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ckbUseWebCam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbUseWebCam.Checked == false)
            {
                mainForm.DiableWebCam(); 
                CallWebCamForm("DisableWebCam");
            }
            else { btnStartWebCam.PerformClick(); }
        }

        private void mnuRecentVideos_MouseEnter(object sender, EventArgs e)
        {
            LoadRecentVideos();
        }
    }
}
