namespace Vssoft.Common
{
    using System;

    public class SaveChangingEventArgs : EventArgs
    {
        private string m_caption;
        private int m_percent;

        public int Percent =>
            this.m_percent;

        public string Status =>
            this.m_caption;
    }
}

