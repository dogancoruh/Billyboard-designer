using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFramework.Events
{
    public class DocumentSaveEventArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
