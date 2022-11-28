using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_Recorder
{
    public class AdviseParentEventArgs : EventArgs
    {
        private readonly string adviseText;

        public AdviseParentEventArgs(string adviseText)
        {
            this.adviseText = adviseText;
        }

        public string AdviseText
        {
            get { return adviseText; }
        }
    }
}
