namespace Vssoft.Common
{
    using System;

    public class SaveChangedEventArgs : EventArgs
    {
        private bool m_notsave;

        public bool NotSave =>
            this.m_notsave;
    }
}

