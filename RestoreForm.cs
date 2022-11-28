using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Recorder
{
    public static class RestoreForm
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;

        public static void Restore(this Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(form.Handle, SW_RESTORE);
            }
        }

        public static void CreateOrRestoreForm<T>() where T : Form
        {
            Form form = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (form == null)
            {
                form = Activator.CreateInstance<T>();
                form.Show();
            }
            else
            {
                form.Restore();
                form.Focus();
            }
        }
    }
}
