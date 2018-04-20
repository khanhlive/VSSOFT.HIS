namespace Vssoft.Common
{
    using System;

    public class SaveCompleteEventArgs : EventArgs
    {
        public bool Result { get; set; }
        public object Model { get; set; }
        public string Message { get; set; }
    }
}

