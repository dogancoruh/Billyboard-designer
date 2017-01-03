using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFramework.Events
{
    public class DocumentCloseEventArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
