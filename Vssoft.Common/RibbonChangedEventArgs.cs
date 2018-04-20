namespace Vssoft.Common
{
    using System;

    public class RibbonChangedEventArgs : EventArgs
    {
        private MenuButton m_ribbon;

        public RibbonChangedEventArgs(MenuButton mRibbon)
        {
            this.m_ribbon = mRibbon;
        }

        public MenuButton Ribbon =>
            this.m_ribbon;
    }
}

