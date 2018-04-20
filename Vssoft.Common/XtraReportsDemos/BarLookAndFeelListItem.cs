namespace XtraReportsDemos
{
    using DevExpress.LookAndFeel;
    using DevExpress.Skins;
    using DevExpress.XtraBars;
    using System;
    using System.ComponentModel;

    public class BarLookAndFeelListItem : BarLinkContainerItem
    {
        private UserLookAndFeel lookAndFeel;
        private BarSubItem skinSubMenuItem;

        public BarLookAndFeelListItem(UserLookAndFeel lookAndFeel)
        {
            this.lookAndFeel = lookAndFeel;
            this.skinSubMenuItem = new BarSubItem();
            this.skinSubMenuItem.Caption = "Skin";
        }

        private void AddBarLookAndFeelItem(BarLinksHolder holder, BarLookAndFeelItem item, string caption)
        {
            item.Caption = caption;
            item.ItemClick += new ItemClickEventHandler(this.OnItemClick);
            item.UpdateState(this.lookAndFeel);
            holder.AddItem(item);
        }

        protected override void OnGetItemData()
        {
            this.UpdateLookAndFeelItemsState(this);
            base.OnGetItemData();
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            BarLookAndFeelItem item = e.Item as BarLookAndFeelItem;
            if (item != null)
            {
                item.ApplyChanges(this.lookAndFeel);
            }
        }

        protected override void OnManagerChanged()
        {
            base.OnManagerChanged();
            if (base.Manager != null)
            {
                this.BeginUpdate();
                this.ClearLinks();
                try
                {
                    this.skinSubMenuItem.ClearLinks();
                    this.AddBarLookAndFeelItem(this, new BarLookAndFeelUseWindowsXPThemeItem(base.Manager, true), "Use WindowsXP Theme");
                    this.AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(base.Manager, true, ActiveLookAndFeelStyle.Flat, LookAndFeelStyle.Flat), "Flat Style");
                    this.AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(base.Manager, true, ActiveLookAndFeelStyle.Office2003, LookAndFeelStyle.Office2003), "Office2003 Style");
                    this.AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(base.Manager, true, ActiveLookAndFeelStyle.Style3D, LookAndFeelStyle.Style3D), "Style3D");
                    this.AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(base.Manager, true, ActiveLookAndFeelStyle.UltraFlat, LookAndFeelStyle.UltraFlat), "UltraFlat Style");
                    this.AddItem(this.skinSubMenuItem);
                    foreach (SkinContainer container in SkinManager.Default.Skins)
                    {
                        this.AddBarLookAndFeelItem(this.skinSubMenuItem, new BarLookAndFeelSkinNameItem(base.Manager, true, container.SkinName), container.SkinName);
                    }
                }
                finally
                {
                    base.CancelUpdate();
                }
            }
        }

        private void UpdateLookAndFeelItemsState(BarLinksHolder holder)
        {
            foreach (BarItemLink link in holder.ItemLinks)
            {
                if (link.Item is BarLookAndFeelItem)
                {
                    ((BarLookAndFeelItem) link.Item).UpdateState(this.lookAndFeel);
                }
                if (link.Item is BarLinksHolder)
                {
                    this.UpdateLookAndFeelItemsState(link.Item as BarLinksHolder);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override BarItemLinkCollection ItemLinks =>
            base.ItemLinks;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override LinksInfo LinksPersistInfo
        {
            get => 
                null;
            set
            {
            }
        }
    }
}

