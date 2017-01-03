using System;

namespace DocumentFramework.Events
{
    public class DocumentFileNameChangedEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}
