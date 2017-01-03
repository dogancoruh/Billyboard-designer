using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFramework.Events
{
    public class DocumentSaveAsEventArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
