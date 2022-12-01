using AForge.Video;
using AForge.Video.DirectShow;
using ControlManager;
using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Win_Recorder
{
    public partial class frmRecorder : Form
    {
        #region Widows specific click through eg

        int CountDown = 5;
        public enum GWL
        {
            ExStyle = -20
        }

        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);

        void ClickThrough()
        {
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
        }

        //ReSize resize = new ReSize();
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 4;   // Caption bar height;
        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_TRANSPARENT = 0x20;

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        protected override void OnPaint(PaintEventArgs e)
        {

            Color theColor = Color.FromArgb(10, 20, 20, 20);
            theColor = Color.DarkBlue;
            int BORDER_SIZE = 4;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,
                                         theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,
                                         theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,
                                         theColor, BORDER_SIZE, ButtonBorderStyle.Dashed);


            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ScreenRectangle = rc;
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Black, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);

            base.OnPaint(e);
        }

        //set MinimumSize to Form
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = new Size(179, 51);
            }
        }

        public bool? SpeakersOn { get; private set; }
        public bool? MicrophoneOn { get; private set; }
       

        #endregion
        #region Screen Recorder Classes

        private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                string filePath = e.FilePath;
                CallToolbarForm("msg_Recording Completed");
                Properties.Settings.Default._isRecording = false;
                Properties.Settings.Default.Save();
                CleanupResources();
            })));
        }

        private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                Properties.Settings.Default._isRecording = false;
                Properties.Settings.Default.Save();
                CallToolbarForm("msg_Recording Failed");
                CleanupResources();
            })));
        }

        private void _rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                //labelError.Visible = false;
                switch (e.Status)
                {
                    case RecorderStatus.Idle:
                        //this.labelStatus.Text = "Idle";
                        break;

                    case RecorderStatus.Recording:
                        if (_progressTimer != null)
                        _progressTimer.Enabled = true;
                        break;

                    case RecorderStatus.Paused:
                        if (_progressTimer != null)
                            _progressTimer.Enabled = false;
                        break;

                    case RecorderStatus.Finishing:
                        break;

                    default:
                        break;
                }
            })));
        }

        private void _rec_OnSnapshotSaved(object sender, SnapshotSavedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _progressTimer_Tick(object sender, EventArgs e)
        {
            _secondsElapsed++;
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            this.TopMost = true;

            Properties.Settings.Default._ElapsedTime = TimeSpan.FromSeconds(_secondsElapsed);
            Properties.Settings.Default.Save();
        }

        public void CleanupResources()
        {
            _progressTimer?.Stop();
            _progressTimer = null;
            _secondsElapsed = 0;
            _rec?.Dispose();
            _rec = null;
            IsRecording = false;

        }

        #endregion

        private Timer _progressTimer;
        private int _secondsElapsed;
        private string videoFolder;
        private Point formStartPosition;
        private Rectangle ScreenRectangle { get; set; }
        private double ScreenLeft { get; set; }
        private double ScreenTop { get; set; }
        private double ScreenWidth { get; set; }
        private double ScreenHeight { get; set; }

        public Recorder _rec;
        public static Boolean IsRecording { get; set; } = false;
        public string _ElapsedTime { get; set; }
        public bool RecordFullscreen { get; internal set; }
        public int FormActivated { get; set; }

        //used for passing variables to toolbar form
        public delegate void SetValueDelegate(string value);
        public SetValueDelegate CallToolbarForm;

        public FilterInfoCollection filterInfoCollection { get; internal set; }

        VideoCaptureDevice videoCaptureDevice;

        public frmRecorder()
        {
            InitializeComponent();
            frmToolbar frm = new frmToolbar(this);
            this.CallToolbarForm += new SetValueDelegate(frm.SetValueCallback);
            //Position toolbarl to top left of recorder screen
            frm.Left = this.Left + frm.Width - 110;
            frm.Top = this.Bottom - frm.Height + 40;
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //lblCountDown.Visible = false;
            //lblMessage.Visible = false;
            videoFolder = Path.Combine(Application.ExecutablePath, "\\Videos");
            Properties.Settings.Default._VideoFolder = videoFolder;
            Properties.Settings.Default.Save();
            RecordFullscreen = false;
            formStartPosition = this.Location;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboCameras.Items.Add(filterInfo.Name);
            }

            cboCameras.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
            ControlMoverOrResizer.Init(webCam1);
            CallToolbarForm("msg_Recorder Ready");
        }

        public void PauseVideo()
        {
            if (IsRecording != true)  { return; }
          
                if (_rec.Status == RecorderStatus.Paused)
                {
                CallToolbarForm("msg_Video No Longer Paused");
                _rec.Resume();
                    return;
                }
            _rec.Pause();
        }

        internal void DisableWebCam()
        {
            webCam1.Visible = false;
            videoCaptureDevice.Stop();
            CallToolbarForm("msg_WebCan Disabled");
        }

        internal void EnableWebCam()
        {
            webCam1.Visible = true;
            //CallToolbarForm("msg_Recording Completed");
        }

        internal void Record()
        {
            if (_rec != null)
            {
                _rec.Stop();
                _progressTimer?.Stop();
                _progressTimer = null;
                _secondsElapsed = 0;
                IsRecording = false; ;
                this.TopMost = false;

                return;
            }
            
            UpdateProgress();
            CallToolbarForm("msg_Recording Started");
            String videoName = Properties.Settings.Default._VideoName;

            if (Properties.Settings.Default._VideoName == "VideoName")
            {
                Properties.Settings.Default._VideoCount += 1;
                videoName += Properties.Settings.Default._VideoCount;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default._videoFullPath = Path.Combine(Application.ExecutablePath, "\\Videos", videoName + ".mp4");

            _progressTimer = new Timer();
            _progressTimer.Tick += _progressTimer_Tick;
            _progressTimer.Interval = 1000;
            _progressTimer.Start();

            if (_rec == null)
            {
                List<AudioDevice> inputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices);
                List<AudioDevice> outputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices);
                AudioDevice selectedOutputDevice = outputDevices.FirstOrDefault();//select one of the devices.. Passing empty string or null uses system default playback device.
                AudioDevice selectedInputDevice = inputDevices.FirstOrDefault();//select one of the devices.. Passing empty string or null uses system default recording device.
                Debug.Write(selectedOutputDevice);
                Debug.Write(selectedInputDevice);

                RecorderOptions options = new RecorderOptions
                {
                    AudioOptions = new AudioOptions
                    {
                        //Bitrate = AudioBitrate.bitrate_128kbps,
                        //Channels = AudioChannels.Stereo,
                        IsAudioEnabled = true,
                        IsOutputDeviceEnabled = SpeakersOn,
                        IsInputDeviceEnabled = MicrophoneOn,
                        AudioOutputDevice = selectedOutputDevice.DeviceName,
                        AudioInputDevice = selectedInputDevice.DeviceName,
                        InputVolume = 1,
                        OutputVolume = 1,
                    },
                    OutputOptions = new OutputOptions
                    {
                        RecorderMode = RecorderMode.Video,
                        //This sets a custom size of the video output, in pixels.
                        OutputFrameSize = new ScreenSize(1920, 1080),
                        //Stretch controls how the resizing is done, if the new aspect ratio differs.
                        Stretch = StretchMode.Uniform,
                        //ternary-operator if fullscreen use null else use the forms location adjusted to exclude the blue recording rectangle
                        SourceRect = RecordFullscreen ? null : new ScreenRect(this.Left + 15, this.Top + 35, this.Width - 30, this.Height - 50)
                       
                        
                    },
                };

                _rec = Recorder.CreateRecorder(options);
                _rec.OnRecordingComplete += Rec_OnRecordingComplete;
                _rec.OnRecordingFailed += Rec_OnRecordingFailed;
                _rec.OnStatusChanged += _rec_OnStatusChanged;
                _rec.OnSnapshotSaved += _rec_OnSnapshotSaved;
            }

            _rec.Record(Properties.Settings.Default._videoFullPath);
            _secondsElapsed = 0;
            IsRecording = true;

            Properties.Settings.Default._isRecording = true;
            Properties.Settings.Default.Save();
            this.Activate();
        }

        internal void DiableWebCam()
        {
            webCam1.Visible = false;
        }

        internal void SetCboIndex(int cboIndex)
        {
            try
            {
                if (cboCameras.SelectedIndex > -1)
                {
                    cboCameras.SelectedIndex = cboIndex;
                    CallToolbarForm("msg_Camera Changed " + cboCameras.SelectedItem.ToString() );
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal void AllowResizing()
        {
            if (RecordFullscreen)
            {
                Screen screen = Screen.PrimaryScreen;
                ScreenLeft = screen.Bounds.X;
                ScreenTop = screen.Bounds.Y;
                ScreenWidth = screen.Bounds.Width;
                ScreenHeight = screen.Bounds.Height;
                //reset form to keep countdown message displayed correctly
                this.Location = new Point(formStartPosition.X, formStartPosition.Y);
                this.Size = new Size(600, 400);
                lblFullScreenMessage.Visible = true;
                CallToolbarForm("msg_Recorder Is Set For Fullscreen");
            }
            else
            {
                ScreenLeft = ScreenRectangle.X;
                ScreenTop = ScreenRectangle.Y;
                ScreenWidth = ScreenRectangle.Width;
                ScreenHeight = ScreenRectangle.Height;
                lblFullScreenMessage.Visible = false;
                CallToolbarForm("msg_Recorder Will Use Form For Video");
            }
            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT);
            lblCountDown.Visible = true;
            lblMessage.Visible = true;
            tmrCountDown.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //This is the 5 sec Count down timer before recording (tmrCountDown)
            CountDown--;
            lblCountDown.Text = CountDown.ToString();

            if (CountDown == 0)
            {
                lblCountDown.Visible = false;
                lblMessage.Visible = false;
                lblFullScreenMessage.Visible = false;
                tmrCountDown.Stop();
                CountDown = 5;
                if (RecordFullscreen)
                {
                    this.WindowState = FormWindowState.Minimized;
                    lblFullScreenMessage.Visible = false;
                }

                Record();
            }
        }

        public TimeSpan elapsed()
        {
            return Properties.Settings.Default._ElapsedTime;
        }

        private void frmRecorder_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrCountDown.Enabled = false;
            tmrCountDown.Dispose();
            
            if (IsRecording)
            {
                videoCaptureDevice.Stop();
            }

            Application.Exit();
        }
        
        public void SetValueFunction(string value)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    CallToolbarForm("Minimized");
                    break;
                case FormWindowState.Minimized:
                    CallToolbarForm("Normal");
                    break;
                case FormWindowState.Maximized:
                    break;
                default:
                    break;
            }
        }

        private void frmRecorder_KeyDown(object sender, KeyEventArgs e)
        {
            if (RecordFullscreen && IsRecording)
            {
                if (e.KeyCode == Keys.M)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        CallToolbarForm("Normal");
                        this.WindowState = FormWindowState.Normal;
                        CallToolbarForm("StopRecording");
                    }
                    else
                    {
                        CallToolbarForm("Minimized");
                        this.WindowState = FormWindowState.Minimized;
                        this.Activate();
                    }
                }
            }
        }

        //Start Web Cam Code

        internal void StartWebCam(string WebCamName)
        {
            videoCaptureDevice = new VideoCaptureDevice();
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCameras.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            webCam1.Visible = true;
            CallToolbarForm("msg_Forms WebCam Active");
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                webCam1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmRecorder_MouseEnter(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void cboCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallToolbarForm("CameraIndex_" + cboCameras.SelectedItem);
        }

    }
}
