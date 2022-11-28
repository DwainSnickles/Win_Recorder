using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using AForge.Video.DirectShow;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;

namespace Win_Recorder
{
    public partial class frmWebCamera : Form
    {
        private Point _mouseLoc;
        public static bool isRecording;
        private frmToolbar mainForm = null;

        Boolean FormShown = false;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public static ComboBox cmbRecorders = new ComboBox();

        public frmWebCamera()
        {
            InitializeComponent();
        }

        public frmWebCamera(Form CallingForm)
        {
            mainForm = CallingForm as frmToolbar;

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cmbRecorders.Items.Add(filterInfo.Name);
            }

            cmbRecorders.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void frmWebCamera_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.ControlBox = false;
            this.Text = "";
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

            if (value == "WebCam")
            {
                if (this.FormShown)
                {
                    this.Hide(); FormShown = false;
                }
                else
                {
                    this.Show();
                    FormShown = true;
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbRecorders.SelectedIndex].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                }
            }
            
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void frmWebCamera_MouseEnter(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
