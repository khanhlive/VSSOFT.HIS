namespace XtraReportsDemos
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils.WXPaint;
    using DevExpress.XtraBars;
    using System;

    public class BarLookAndFeelUseWindowsXPThemeItem : BarLookAndFeelItem
    {
        public BarLookAndFeelUseWindowsXPThemeItem(BarManager manager, bool privateItem) : base(manager, privateItem)
        {
        }

        public override void ApplyChanges(UserLookAndFeel lookAndFeel)
        {
            lookAndFeel.UseWindowsXPTheme = true;
        }

        public override void UpdateState(UserLookAndFeel lookAndFeel)
        {
            this.Down = lookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.WindowsXP;
            this.Enabled = Painter.ThemesEnabled;
        }
    }
}

