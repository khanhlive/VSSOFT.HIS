namespace Vssoft.Common
{
    using DevExpress.XtraBars;
    using System;

    public class ItemCommand
    {
        private string m_caption = "";
        private bool m_enable = false;
        private BarItemVisibility m_visibility = BarItemVisibility.Never;

        public string Caption
        {
            get => 
                this.m_caption;
            set
            {
                this.m_caption = value;
            }
        }

        public bool Enable
        {
            get => 
                this.m_enable;
            set
            {
                this.m_enable = value;
            }
        }

        public BarItemVisibility Visibility
        {
            get => 
                this.m_visibility;
            set
            {
                this.m_visibility = value;
            }
        }
    }
}

