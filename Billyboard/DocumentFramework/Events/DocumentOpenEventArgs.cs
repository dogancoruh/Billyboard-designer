using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFramework.Events
{
    public class DocumentOpenEventArgs : EventArgs
    {
        public bool isHandled { get; set; }
    }
}
