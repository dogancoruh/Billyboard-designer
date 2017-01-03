using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFramework.Events
{
    public class DocumentModifiedEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public bool IsModified { get; set; }
    }
}
