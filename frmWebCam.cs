using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Win_Recorder
{
    public partial class frmWebCam : Form
    {
        private Point _mouseLoc;
        public static bool isRecording;
        private frmToolbar TbarForm = null;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public static ComboBox cmbRecorders = new ComboBox();

        public frmWebCam()
        {
            InitializeComponent();
        }

        public frmWebCam(Form CallingForm)
        {
            InitializeComponent();
            TbarForm = CallingForm as frmToolbar;

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cmbRecorders.Items.Add(filterInfo.Name);
            }

            cmbRecorders.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void frmWebCamera_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void frmWebCamera_MouseHover(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                this.Cursor = Cursors.Hand;

            }
        }

        private void frmWebCamera_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        internal void SetValueCallback(string value)
        {
            if (value.StartsWith("CameraIndex"))
            {
                string[] CamIndex = value.Split('_');
                int index = Int16.Parse(CamIndex[2]);
                cmbRecorders.SelectedIndex = index;
            }

            if (value == "EnableWebCam")
            {
                this.Show();
                this.ControlBox = false;
                videoCaptureDevice.Start();
            }

            if (value == "DisableWebCam")
            {
                videoCaptureDevice.Stop();
                this.Hide();
                this.ControlBox = false;
            }

        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            picCam.Image = (Bitmap)eventArgs.Frame.Clone();
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void frmWebCamera_MouseEnter(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void frmWebCam_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cmbRecorders.Items.Add(filterInfo.Name);
            }

            cmbRecorders.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbRecorders.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void picCam_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void picCam_MouseHover(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                this.Cursor = Cursors.Hand;

            }
        }

        private void picCam_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void picCam_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picCam_MouseEnter(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
