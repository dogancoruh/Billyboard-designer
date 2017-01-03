using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFramework.Enums;

namespace DocumentFramework.Events
{
    public class DocumentNewPromptEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public DialogResult DialogResult { get; set; }
    }
}
