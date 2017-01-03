using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFramework.Events
{
    public class ProjectOpenPromptEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public bool IsHandled { get; set; }
    }
}
