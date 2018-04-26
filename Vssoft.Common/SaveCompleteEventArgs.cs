namespace Vssoft.Common
{
    using System;
    using Vssoft.Common.Common.Class;

    public class SaveCompleteEventArgs : EventArgs
    {
        public bool Result { get; set; }
        public object Model { get; set; }
        public string Message { get; set; }
        public Actions Action { get; set; }
    }
}

