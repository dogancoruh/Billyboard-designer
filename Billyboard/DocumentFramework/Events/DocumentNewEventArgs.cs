using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFramework.Events
{
    public class DocumentNewEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public bool Handled { get; set; }
    }
}
