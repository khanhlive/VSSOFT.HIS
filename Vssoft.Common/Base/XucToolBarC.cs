namespace Vssoft.Common.Base
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using Vssoft.Common;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class XucToolBarC : xucBase
    {
        private Bar barAccount;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarSubItem barSubItem1;
        public BarButtonItem bbiAdd;
        public BarButtonItem bbiCancel;
        public BarButtonItem bbiChange;
        public BarButtonItem bbiChangeId;
        public BarButtonItem bbiClose;
        public BarButtonItem bbiConstruct;
        public BarButtonItem bbiCopy;
        public BarButtonItem bbiDelete;
        public BarButtonItem bbiDeleteAll;
        public BarButtonItem bbiDouble;
        public BarButtonItem bbiEdit;
        public BarButtonItem bbiEditUnitConvret;
        public BarButtonItem bbiExport;
        public BarButtonItem bbiGroup;
        public BarButtonItem bbiHelp;
        public BarButtonItem bbiHistory;
        public BarSubItem bbiInterface;
        public BarButtonItem bbiMerge;
        public BarButtonItem bbiOption;
        public BarSubItem bbiOther;
        public BarButtonItem bbiPermision;
        public BarButtonItem bbiPrint;
        public BarButtonItem bbiRefresh;
        public BarButtonItem bbiSave;
        public BarButtonItem bbiSaveNew;
        public BarButtonItem bbiSearch;
        public BarButtonItem bbiStock;
        public BarSubItem bbiUtils;
        public BarManager bm;
        private IContainer components = null;
        public DevExpress.Utils.ImageCollection imageCollection2;
        public PopupMenu pm;
        private RepositoryItemButtonEdit repositoryItemButtonEdit2;

        public event ButtonClickEventHander AddClick;

        public event ButtonClickEventHander CancleClick;

        public event ButtonClickEventHander ChangeClick;

        public event ButtonClickEventHander ClearClick;

        public event ButtonClickEventHander CloseClick;

        public event ButtonClickEventHander ConstructClick;

        public event ButtonClickEventHander CopyClick;

        public event ButtonClickEventHander DeleteClick;

        public event ButtonClickEventHander EditClick;

        public event ButtonClickEventHander EditUnitConvert;

        public event ButtonClickEventHander ExportClick;

        public event ButtonClickEventHander GroupChanged;

        public event ButtonClickEventHander HelpClick;

        public event ButtonClickEventHander HistoryClick;

        public event ButtonClickEventHander IdChanged;

        public event ButtonClickEventHander ImportClick;

        public event ButtonClickEventHander MergeChanged;

        public event ButtonClickEventHander MirrorClick;

        public event ButtonClickEventHander OptionClick;

        public event ButtonClickEventHander PermisionClick;

        public event ButtonClickEventHander PrintClick;

        public event ButtonClickEventHander RefreshClick;

        public event ButtonClickEventHander SaveClick;

        public event ButtonClickEventHander SaveNewClick;

        public event ButtonClickEventHander SearchClick;

        public event ButtonClickEventHander StockChanged;

        public XucToolBarC()
        {
            this.InitializeComponent();
            this.InitMultiLanguages();
        }

        private void bbiAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseAddClickEventHander();
        }

        private void bbiCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseCancleClickEventHander();
        }

        private void bbiChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseChangeClickEventHander();
        }

        private void bbiChangeId_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseIdChanged();
        }

        private void bbiClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseClearClickEventHander();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseCloseClickEventHander();
        }

        private void bbiConstruct_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseConstructClickEventHander();
        }

        private void bbiCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseCopyClickEventHander();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseDeleteClickEventHander();
        }

        private void bbiDouble_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseMirrorClickEventHander();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseEditClickEventHander();
        }

        private void bbiEditUnitConvret_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseEditUnitConvert();
        }

        private void bbiExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseExportEventHander();
        }

        private void bbiExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseExportEventHander();
        }

        private void bbiGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseGroupChanged();
        }

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseHelpClickEventHander();
        }

        private void bbiHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseHistoryClick();
        }

        private void bbiImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseImportClickEventHander();
        }

        private void bbiMerge_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseMergeChanged();
        }

        private void bbiOption_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseOptionClickEventHander();
        }

        private void bbiPermision_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaisePermisionClickEventHander();
        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaisePrintClickEventHander();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseRefreshClickEventHander();
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseSaveClickEventHander();
        }

        private void bbiSaveNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseSaveNewClickEventHander();
        }

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseSearchClickEventHander();
        }

        private void bbiStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseStockChanged();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipItem item3 = new ToolTipItem();
            SuperToolTip tip4 = new SuperToolTip();
            ToolTipItem item4 = new ToolTipItem();
            SuperToolTip tip5 = new SuperToolTip();
            ToolTipItem item5 = new ToolTipItem();
            SuperToolTip tip6 = new SuperToolTip();
            ToolTipItem item6 = new ToolTipItem();
            SuperToolTip tip7 = new SuperToolTip();
            ToolTipItem item7 = new ToolTipItem();
            SuperToolTip tip8 = new SuperToolTip();
            ToolTipItem item8 = new ToolTipItem();
            SuperToolTip tip9 = new SuperToolTip();
            ToolTipItem item9 = new ToolTipItem();
            SuperToolTip tip10 = new SuperToolTip();
            ToolTipItem item10 = new ToolTipItem();
            SuperToolTip tip11 = new SuperToolTip();
            ToolTipItem item11 = new ToolTipItem();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(XucToolBarC));
            SuperToolTip tip12 = new SuperToolTip();
            ToolTipItem item12 = new ToolTipItem();
            this.bm = new BarManager(this.components);
            this.barAccount = new Bar();
            this.bbiAdd = new BarButtonItem();
            this.bbiEdit = new BarButtonItem();
            this.bbiChange = new BarButtonItem();
            this.bbiDelete = new BarButtonItem();
            this.bbiDouble = new BarButtonItem();
            this.bbiPermision = new BarButtonItem();
            this.bbiConstruct = new BarButtonItem();
            this.bbiSaveNew = new BarButtonItem();
            this.bbiSave = new BarButtonItem();
            this.bbiCancel = new BarButtonItem();
            this.bbiOption = new BarButtonItem();
            this.bbiRefresh = new BarButtonItem();
            this.bbiPrint = new BarButtonItem();
            this.bbiExport = new BarButtonItem();
            this.bbiClose = new BarButtonItem();
            this.bbiHelp = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.barSubItem1 = new BarSubItem();
            this.bbiSearch = new BarButtonItem();
            this.bbiCopy = new BarButtonItem();
            this.bbiDeleteAll = new BarButtonItem();
            this.bbiOther = new BarSubItem();
            this.bbiInterface = new BarSubItem();
            this.bbiHistory = new BarButtonItem();
            this.bbiUtils = new BarSubItem();
            this.bbiGroup = new BarButtonItem();
            this.bbiStock = new BarButtonItem();
            this.bbiMerge = new BarButtonItem();
            this.bbiChangeId = new BarButtonItem();
            this.bbiEditUnitConvret = new BarButtonItem();
            this.repositoryItemButtonEdit2 = new RepositoryItemButtonEdit();
            this.pm = new PopupMenu(this.components);
            this.bm.BeginInit();
            this.imageCollection2.BeginInit();
            this.repositoryItemButtonEdit2.BeginInit();
            this.pm.BeginInit();
            base.SuspendLayout();
            this.bm.AllowCustomization = false;
            this.bm.AllowMoveBarOnToolbar = false;
            this.bm.AllowQuickCustomization = false;
            this.bm.AllowShowToolbarsPopup = false;
            this.bm.AutoSaveInRegistry = true;
            this.bm.Bars.AddRange(new Bar[] { this.barAccount });
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.DockWindowTabFont = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.bm.Form = this;
            this.bm.Images = this.imageCollection2;
            this.bm.Items.AddRange(new BarItem[] { 
                this.bbiAdd, this.bbiEdit, this.bbiChange, this.bbiDelete, this.bbiRefresh, this.bbiClose, this.barSubItem1, this.bbiOption, this.bbiSearch, this.bbiHelp, this.bbiExport, this.bbiSave, this.bbiCancel, this.bbiSaveNew, this.bbiPermision, this.bbiConstruct,
                this.bbiCopy, this.bbiDouble, this.bbiPrint, this.bbiDeleteAll, this.bbiOther, this.bbiInterface, this.bbiHistory, this.bbiUtils, this.bbiGroup, this.bbiStock, this.bbiMerge, this.bbiChangeId, this.bbiEditUnitConvret
            });
            this.bm.LargeImages = this.imageCollection2;
            this.bm.MaxItemId = 0x39;
            this.bm.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemButtonEdit2 });
            this.bm.ShowFullMenusAfterDelay = false;
            this.barAccount.BarName = "Custom 3";
            this.barAccount.DockCol = 0;
            this.barAccount.DockRow = 0;
            this.barAccount.DockStyle = BarDockStyle.Top;
            this.barAccount.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(BarLinkUserDefines.KeyTip | BarLinkUserDefines.PaintStyle, this.bbiAdd, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph, "", ""), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiEdit, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiChange, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiDelete, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiDouble, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiPermision, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiConstruct, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiSaveNew, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiSave, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiCancel, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiOption, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiRefresh, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiPrint, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiExport, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiClose, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiHelp, BarItemPaintStyle.CaptionGlyph) });
            this.barAccount.OptionsBar.UseWholeRow = true;
            this.barAccount.Text = "Custom 3";
            this.bbiAdd.Caption = "&Th\x00eam";
            this.bbiAdd.Id = 0;
            this.bbiAdd.ImageIndex = 6;
            this.bbiAdd.ItemShortcut = new BarShortcut(Keys.Control | Keys.N);
            this.bbiAdd.LargeImageIndex = 6;
            this.bbiAdd.Name = "bbiAdd";
            item.Text = "Alt-T\r\nCtrl+N";
            tip.Items.Add(item);
            this.bbiAdd.SuperTip = tip;
            this.bbiAdd.ItemClick += new ItemClickEventHandler(this.bbiAdd_ItemClick);
            this.bbiEdit.Caption = "&Sửa Chữa";
            this.bbiEdit.Enabled = false;
            this.bbiEdit.Id = 1;
            this.bbiEdit.ImageIndex = 14;
            this.bbiEdit.ItemShortcut = new BarShortcut(Keys.F2);
            this.bbiEdit.LargeImageIndex = 14;
            this.bbiEdit.Name = "bbiEdit";
            item2.Text = "F2\r\nEnter";
            tip2.Items.Add(item2);
            this.bbiEdit.SuperTip = tip2;
            this.bbiEdit.ItemClick += new ItemClickEventHandler(this.bbiEdit_ItemClick);
            this.bbiChange.Caption = "T&hay Đổi";
            this.bbiChange.Enabled = false;
            this.bbiChange.Id = 2;
            this.bbiChange.ImageIndex = 14;
            this.bbiChange.Name = "bbiChange";
            this.bbiChange.PaintStyle = BarItemPaintStyle.CaptionInMenu;
            item3.Text = "F2\r\nCtrl+E\r\nEnter";
            tip3.Items.Add(item3);
            this.bbiChange.SuperTip = tip3;
            this.bbiChange.Visibility = BarItemVisibility.Never;
            this.bbiChange.ItemClick += new ItemClickEventHandler(this.bbiChange_ItemClick);
            this.bbiDelete.Caption = "&Xo\x00e1";
            this.bbiDelete.Enabled = false;
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageIndex = 13;
            this.bbiDelete.ItemShortcut = new BarShortcut(Keys.Control | Keys.Delete);
            this.bbiDelete.Name = "bbiDelete";
            item4.Text = "Alt-X\r\nDelete";
            tip4.Items.Add(item4);
            this.bbiDelete.SuperTip = tip4;
            this.bbiDelete.ItemClick += new ItemClickEventHandler(this.bbiDelete_ItemClick);
            this.bbiDouble.Caption = "Nh\x00e2n Bản";
            this.bbiDouble.Enabled = false;
            this.bbiDouble.Id = 0x2b;
            this.bbiDouble.ImageIndex = 8;
            this.bbiDouble.ItemShortcut = new BarShortcut(Keys.Control | Keys.Shift | Keys.C);
            this.bbiDouble.Name = "bbiDouble";
            this.bbiDouble.Visibility = BarItemVisibility.Never;
            this.bbiDouble.ItemClick += new ItemClickEventHandler(this.bbiDouble_ItemClick);
            this.bbiPermision.Caption = "Ph\x00e2n Quyền";
            this.bbiPermision.Id = 40;
            this.bbiPermision.ImageIndex = 0x3e;
            this.bbiPermision.LargeImageIndex = 0x3e;
            this.bbiPermision.Name = "bbiPermision";
            this.bbiPermision.Visibility = BarItemVisibility.Never;
            this.bbiPermision.ItemClick += new ItemClickEventHandler(this.bbiPermision_ItemClick);
            this.bbiConstruct.Caption = "Cấu Tạo";
            this.bbiConstruct.Id = 0x29;
            this.bbiConstruct.ImageIndex = 0x3f;
            this.bbiConstruct.LargeImageIndex = 0x3f;
            this.bbiConstruct.Name = "bbiConstruct";
            this.bbiConstruct.Visibility = BarItemVisibility.Never;
            this.bbiConstruct.ItemClick += new ItemClickEventHandler(this.bbiConstruct_ItemClick);
            this.bbiSaveNew.Caption = "Lưu && Th\x00eam";
            this.bbiSaveNew.Id = 0x18;
            this.bbiSaveNew.ImageIndex = 0x15;
            this.bbiSaveNew.LargeImageIndex = 10;
            this.bbiSaveNew.Name = "bbiSaveNew";
            item5.Text = "F2\r\nCtrl+ Shift+S\r\nCtrl+W";
            tip5.Items.Add(item5);
            this.bbiSaveNew.SuperTip = tip5;
            this.bbiSaveNew.ItemClick += new ItemClickEventHandler(this.bbiSaveNew_ItemClick);
            this.bbiSave.Caption = "&Lưu && Đ\x00f3ng";
            this.bbiSave.Id = 0x16;
            this.bbiSave.ImageIndex = 10;
            this.bbiSave.LargeImageIndex = 10;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new ItemClickEventHandler(this.bbiSave_ItemClick);
            this.bbiCancel.Caption = "Bỏ Qua";
            this.bbiCancel.Id = 0x17;
            this.bbiCancel.ImageIndex = 0x26;
            this.bbiCancel.LargeImageIndex = 0x29;
            this.bbiCancel.Name = "bbiCancel";
            item6.Text = "ESC";
            tip6.Items.Add(item6);
            this.bbiCancel.SuperTip = tip6;
            this.bbiCancel.ItemClick += new ItemClickEventHandler(this.bbiCancel_ItemClick);
            this.bbiOption.Caption = "Lựa Chọn";
            this.bbiOption.Id = 15;
            this.bbiOption.ImageIndex = 60;
            this.bbiOption.LargeImageIndex = 60;
            this.bbiOption.Name = "bbiOption";
            item7.Text = "Ctrl+O";
            tip7.Items.Add(item7);
            this.bbiOption.SuperTip = tip7;
            this.bbiOption.Visibility = BarItemVisibility.Never;
            this.bbiOption.ItemClick += new ItemClickEventHandler(this.bbiOption_ItemClick);
            this.bbiRefresh.Caption = "&Nạp Lại";
            this.bbiRefresh.Id = 4;
            this.bbiRefresh.ImageIndex = 0x2a;
            this.bbiRefresh.Name = "bbiRefresh";
            item8.Text = "F5";
            tip8.Items.Add(item8);
            this.bbiRefresh.SuperTip = tip8;
            this.bbiRefresh.ItemClick += new ItemClickEventHandler(this.bbiRefresh_ItemClick);
            this.bbiPrint.Caption = "In";
            this.bbiPrint.Enabled = false;
            this.bbiPrint.Id = 0x2c;
            this.bbiPrint.ImageIndex = 9;
            this.bbiPrint.Name = "bbiPrint";
            this.bbiPrint.ItemClick += new ItemClickEventHandler(this.bbiPrint_ItemClick);
            this.bbiExport.Caption = "Xuất ";
            this.bbiExport.Enabled = false;
            this.bbiExport.Id = 0x13;
            this.bbiExport.ImageIndex = 0x37;
            this.bbiExport.LargeImageIndex = 0x37;
            this.bbiExport.Name = "bbiExport";
            item9.Text = "Ctrl+E";
            tip9.Items.Add(item9);
            this.bbiExport.SuperTip = tip9;
            this.bbiExport.ItemClick += new ItemClickEventHandler(this.bbiExport_ItemClick);
            this.bbiClose.Caption = "&Đ\x00f3ng";
            this.bbiClose.Id = 6;
            this.bbiClose.ImageIndex = 0x16;
            this.bbiClose.Name = "bbiClose";
            item10.Text = "F10";
            tip10.Items.Add(item10);
            this.bbiClose.SuperTip = tip10;
            this.bbiClose.ItemClick += new ItemClickEventHandler(this.bbiClose_ItemClick);
            this.bbiHelp.Caption = "Trợ Gi\x00fap";
            this.bbiHelp.Id = 0x12;
            this.bbiHelp.ImageIndex = 0x19;
            this.bbiHelp.Name = "bbiHelp";
            item11.Text = "F1";
            tip11.Items.Add(item11);
            this.bbiHelp.SuperTip = tip11;
            this.bbiHelp.Visibility = BarItemVisibility.Never;
            this.bbiHelp.ItemClick += new ItemClickEventHandler(this.bbiHelp_ItemClick);
            //this.imageCollection2.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection2.ImageStream");
            //this.imageCollection2.Images.SetKeyName(0x3d, "Vista (35).ico");
            //this.imageCollection2.Images.SetKeyName(0x3e, "Security.ico");
            //this.imageCollection2.Images.SetKeyName(0x3f, "RibbonPrintPreview_DocumentMapLarge.png");
            this.barSubItem1.Caption = "Xuất khẩu";
            this.barSubItem1.Id = 7;
            this.barSubItem1.Name = "barSubItem1";
            this.bbiSearch.Caption = "T\x00ecm";
            this.bbiSearch.Id = 0x11;
            this.bbiSearch.ImageIndex = 3;
            this.bbiSearch.Name = "bbiSearch";
            item12.Text = "Ctrl+F";
            tip12.Items.Add(item12);
            this.bbiSearch.SuperTip = tip12;
            this.bbiSearch.ItemClick += new ItemClickEventHandler(this.bbiSearch_ItemClick);
            this.bbiCopy.Caption = "Ch\x00e9p v\x00e0o ClipBoard";
            this.bbiCopy.Enabled = false;
            this.bbiCopy.Id = 0x2a;
            this.bbiCopy.ImageIndex = 1;
            this.bbiCopy.ItemShortcut = new BarShortcut(Keys.Control | Keys.Shift | Keys.C);
            this.bbiCopy.Name = "bbiCopy";
            this.bbiCopy.ItemClick += new ItemClickEventHandler(this.bbiCopy_ItemClick);
            this.bbiDeleteAll.Caption = "Xo\x00e1 tất cả";
            this.bbiDeleteAll.Id = 0x2e;
            this.bbiDeleteAll.ImageIndex = 13;
            this.bbiDeleteAll.Name = "bbiDeleteAll";
            this.bbiDeleteAll.ItemClick += new ItemClickEventHandler(this.bbiClear_ItemClick);
            this.bbiOther.Caption = "Kh\x00e1c";
            this.bbiOther.Id = 0x2f;
            this.bbiOther.ImageIndex = 7;
            this.bbiOther.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.bbiCopy), new LinkPersistInfo(this.bbiPrint), new LinkPersistInfo(this.bbiExport), new LinkPersistInfo(this.bbiOption, true) });
            this.bbiOther.Name = "bbiOther";
            this.bbiInterface.Caption = "Giao Diện";
            this.bbiInterface.Id = 0x30;
            this.bbiInterface.Name = "bbiInterface";
            this.bbiHistory.Caption = "Lịch Sử Giao Dịch";
            this.bbiHistory.Id = 0x31;
            this.bbiHistory.ImageIndex = 0x18;
            this.bbiHistory.Name = "bbiHistory";
            this.bbiHistory.ItemClick += new ItemClickEventHandler(this.bbiHistory_ItemClick);
            this.bbiUtils.Caption = "Tiện \x00edch";
            this.bbiUtils.Id = 50;
            this.bbiUtils.ImageIndex = 60;
            this.bbiUtils.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.bbiGroup), new LinkPersistInfo(this.bbiStock), new LinkPersistInfo(this.bbiMerge), new LinkPersistInfo(this.bbiChangeId) });
            this.bbiUtils.Name = "bbiUtils";
            this.bbiUtils.Visibility = BarItemVisibility.Never;
            this.bbiGroup.Caption = "Thay Đổi Nh\x00f3m";
            this.bbiGroup.Id = 0x33;
            this.bbiGroup.ImageIndex = 8;
            this.bbiGroup.Name = "bbiGroup";
            this.bbiGroup.Visibility = BarItemVisibility.Never;
            this.bbiGroup.ItemClick += new ItemClickEventHandler(this.bbiGroup_ItemClick);
            this.bbiStock.Caption = "Thay Đổi Kho";
            this.bbiStock.Id = 0x34;
            this.bbiStock.ImageIndex = 0x1b;
            this.bbiStock.Name = "bbiStock";
            this.bbiStock.Visibility = BarItemVisibility.Never;
            this.bbiStock.ItemClick += new ItemClickEventHandler(this.bbiStock_ItemClick);
            this.bbiMerge.Caption = "Gộp";
            this.bbiMerge.Id = 0x35;
            this.bbiMerge.ImageIndex = 14;
            this.bbiMerge.Name = "bbiMerge";
            this.bbiMerge.Visibility = BarItemVisibility.Never;
            this.bbiMerge.ItemClick += new ItemClickEventHandler(this.bbiMerge_ItemClick);
            this.bbiChangeId.Caption = "Đổi M\x00e3";
            this.bbiChangeId.Id = 0x36;
            this.bbiChangeId.ImageIndex = 0x25;
            this.bbiChangeId.Name = "bbiChangeId";
            this.bbiChangeId.Visibility = BarItemVisibility.Never;
            this.bbiChangeId.ItemClick += new ItemClickEventHandler(this.bbiChangeId_ItemClick);
            this.bbiEditUnitConvret.Caption = "Bảng Quy Đổi Đơn Vị";
            this.bbiEditUnitConvret.Id = 0x37;
            this.bbiEditUnitConvret.ImageIndex = 40;
            this.bbiEditUnitConvret.Name = "bbiEditUnitConvret";
            this.bbiEditUnitConvret.ItemClick += new ItemClickEventHandler(this.bbiEditUnitConvret_ItemClick);
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.pm.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.bbiAdd), new LinkPersistInfo(this.bbiEdit), new LinkPersistInfo(this.bbiDelete), new LinkPersistInfo(this.bbiDeleteAll), new LinkPersistInfo(this.bbiEditUnitConvret), new LinkPersistInfo(this.bbiDouble), new LinkPersistInfo(this.bbiRefresh, true), new LinkPersistInfo(this.bbiUtils), new LinkPersistInfo(this.bbiOther), new LinkPersistInfo(this.bbiHistory, true), new LinkPersistInfo(this.bbiPermision, true), new LinkPersistInfo(this.bbiConstruct, true), new LinkPersistInfo(this.bbiHelp, true), new LinkPersistInfo(this.bbiClose, true) });
            this.pm.Manager = this.bm;
            this.pm.Name = "pm";
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "XucToolBarC";
            base.Size = new Size(0x4d4, 0x1a);
            this.bm.EndInit();
            this.imageCollection2.EndInit();
            this.repositoryItemButtonEdit2.EndInit();
            this.pm.EndInit();
            base.ResumeLayout(false);
        }

        private void InitMultiLanguages()
        {
            //this.bbiAdd.Caption = MultiLanguages.GetString("tbl_ToolBar", "Add", this.bbiAdd.Caption);
            //this.bbiEdit.Caption = MultiLanguages.GetString("tbl_ToolBar", "Edit", this.bbiEdit.Caption);
            //this.bbiDelete.Caption = MultiLanguages.GetString("tbl_ToolBar", "Delete", this.bbiDelete.Caption);
            //this.bbiRefresh.Caption = MultiLanguages.GetString("tbl_ToolBar", "Refresh", this.bbiRefresh.Caption);
            //this.bbiPrint.Caption = MultiLanguages.GetString("tbl_ToolBar", "Print", this.bbiPrint.Caption);
            //this.bbiExport.Caption = MultiLanguages.GetString("tbl_ToolBar", "Export", this.bbiExport.Caption);
            //this.bbiHelp.Caption = MultiLanguages.GetString("tbl_ToolBar", "Help", this.bbiHelp.Caption);
            //this.bbiClose.Caption = MultiLanguages.GetString("tbl_ToolBar", "Close", this.bbiClose.Caption);
        }

        public virtual void MakerInterface()
        {
        }

        private void RaiseAddClickEventHander()
        {
            if (this.AddClick != null)
            {
                this.AddClick(this);
            }
        }

        private void RaiseCancleClickEventHander()
        {
            if (this.CancleClick != null)
            {
                this.CancleClick(this);
            }
        }

        private void RaiseChangeClickEventHander()
        {
            if (this.ChangeClick != null)
            {
                this.ChangeClick(this);
            }
        }

        private void RaiseClearClickEventHander()
        {
            if (this.ClearClick != null)
            {
                this.ClearClick(this);
            }
        }

        private void RaiseCloseClickEventHander()
        {
            if (this.CloseClick != null)
            {
                this.CloseClick(this);
            }
        }

        private void RaiseConstructClickEventHander()
        {
            if (this.ConstructClick != null)
            {
                this.ConstructClick(this);
            }
        }

        private void RaiseCopyClickEventHander()
        {
            if (this.CopyClick != null)
            {
                this.CopyClick(this);
            }
        }

        private void RaiseDeleteClickEventHander()
        {
            if (this.DeleteClick != null)
            {
                this.DeleteClick(this);
            }
        }

        private void RaiseEditClickEventHander()
        {
            if (this.EditClick != null)
            {
                this.EditClick(this);
            }
        }

        private void RaiseEditUnitConvert()
        {
            ButtonClickEventHander editUnitConvert = this.EditUnitConvert;
            if (editUnitConvert != null)
            {
                editUnitConvert(this);
            }
        }

        private void RaiseExportEventHander()
        {
            if (this.ExportClick != null)
            {
                this.ExportClick(this);
            }
        }

        private void RaiseGroupChanged()
        {
            ButtonClickEventHander groupChanged = this.GroupChanged;
            if (groupChanged != null)
            {
                groupChanged(this);
            }
        }

        private void RaiseHelpClickEventHander()
        {
            if (this.HelpClick != null)
            {
                this.HelpClick(this);
            }
        }

        private void RaiseHistoryClick()
        {
            ButtonClickEventHander historyClick = this.HistoryClick;
            if (historyClick != null)
            {
                historyClick(this);
            }
        }

        private void RaiseIdChanged()
        {
            ButtonClickEventHander idChanged = this.IdChanged;
            if (idChanged != null)
            {
                idChanged(this);
            }
        }

        private void RaiseImportClickEventHander()
        {
            if (this.ImportClick != null)
            {
                this.ImportClick(this);
            }
        }

        private void RaiseMergeChanged()
        {
            ButtonClickEventHander mergeChanged = this.MergeChanged;
            if (mergeChanged != null)
            {
                mergeChanged(this);
            }
        }

        private void RaiseMirrorClickEventHander()
        {
            if (this.MirrorClick != null)
            {
                this.MirrorClick(this);
            }
        }

        private void RaiseOptionClickEventHander()
        {
            if (this.OptionClick != null)
            {
                this.OptionClick(this);
            }
        }

        private void RaisePermisionClickEventHander()
        {
            if (this.PermisionClick != null)
            {
                this.PermisionClick(this);
            }
        }

        private void RaisePrintClickEventHander()
        {
            if (this.PrintClick != null)
            {
                this.PrintClick(this);
            }
        }

        private void RaiseRefreshClickEventHander()
        {
            if (this.RefreshClick != null)
            {
                this.RefreshClick(this);
            }
        }

        private void RaiseSaveClickEventHander()
        {
            if (this.SaveClick != null)
            {
                this.SaveClick(this);
            }
        }

        private void RaiseSaveNewClickEventHander()
        {
            if (this.SaveNewClick != null)
            {
                this.SaveNewClick(this);
            }
        }

        private void RaiseSearchClickEventHander()
        {
            if (this.SearchClick != null)
            {
                this.SearchClick(this);
            }
        }

        private void RaiseStockChanged()
        {
            ButtonClickEventHander stockChanged = this.StockChanged;
            if (stockChanged != null)
            {
                stockChanged(this);
            }
        }

        public virtual void SetInterface()
        {
        }

        [DefaultValue(false), Category("Design"), Description("Button Add")]
        public BarItemVisibility ButtonAdd
        {
            get => 
                this.bbiAdd.Visibility;
            set
            {
                this.bbiAdd.Visibility = value;
                base.Update();
            }
        }

        [DefaultValue(false), Description("Button Cancel"), Category("Design")]
        public BarItemVisibility ButtonCancel
        {
            get => 
                this.bbiCancel.Visibility;
            set
            {
                this.bbiCancel.Visibility = value;
                base.Show();
                this.barAccount.Reset();
            }
        }

        [Category("Design"), Description("Button Change"), DefaultValue(false)]
        public BarItemVisibility ButtonChange
        {
            get => 
                this.bbiChange.Visibility;
            set
            {
                this.bbiChange.Visibility = value;
                base.Update();
            }
        }

        [DefaultValue(false), Category("Design"), Description("Button Delete")]
        public BarItemVisibility ButtonDelete
        {
            get => 
                this.bbiDelete.Visibility;
            set
            {
                this.bbiDelete.Visibility = value;
                base.Update();
            }
        }

        [DefaultValue(false), Category("Design"), Description("Button Edit")]
        public BarItemVisibility ButtonEdit
        {
            get => 
                this.bbiEdit.Visibility;
            set
            {
                this.bbiEdit.Visibility = value;
                base.Update();
            }
        }

        [DefaultValue(false), Category("Design"), Description("Button Delete")]
        public BarItemVisibility ButtonExport
        {
            get => 
                this.bbiExport.Visibility;
            set
            {
                this.bbiExport.Visibility = value;
                base.Update();
            }
        }

        [Category("Design"), DefaultValue(false), Description("Button Delete")]
        public BarItemVisibility ButtonOption
        {
            get => 
                this.bbiOption.Visibility;
            set
            {
                this.bbiOption.Visibility = value;
                base.Update();
            }
        }

        [Category("Design"), DefaultValue(false), Description("Button Print")]
        public BarItemVisibility ButtonPrint
        {
            get => 
                this.bbiPrint.Visibility;
            set
            {
                this.bbiPrint.Visibility = value;
                base.Update();
            }
        }

        [Category("Design"), Description("Button Save"), DefaultValue(false)]
        public BarItemVisibility ButtonSave
        {
            get => 
                this.bbiSave.Visibility;
            set
            {
                this.bbiSave.Visibility = value;
                base.Show();
                this.barAccount.Reset();
            }
        }

        [DefaultValue(false), Category("Design"), Description("Button SaveNew")]
        public BarItemVisibility ButtonSaveNew
        {
            get => 
                this.bbiSaveNew.Visibility;
            set
            {
                this.bbiSaveNew.Visibility = value;
                base.Show();
                this.barAccount.Reset();
            }
        }
    }
}

