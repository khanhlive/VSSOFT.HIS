namespace XtraReportsDemos
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraBars;
    using System;
    using System.ComponentModel;

    [ToolboxItem(false), DesignTimeVisible(false)]
    public class BarLookAndFeelItem : BarButtonItem
    {
        public BarLookAndFeelItem(BarManager manager, bool privateItem)
        {
            base.fIsPrivateItem = privateItem;
            base.Manager = manager;
            this.ButtonStyle = BarButtonStyle.Check;
        }

        public virtual void ApplyChanges(UserLookAndFeel lookAndFeel)
        {
        }

        public virtual void UpdateState(UserLookAndFeel lookAndFeel)
        {
        }
    }
}

