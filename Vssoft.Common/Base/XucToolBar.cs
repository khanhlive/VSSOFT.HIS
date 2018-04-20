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

    public class XucToolBar : xucBase
    {
        private Bar barAccount;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarSubItem barSubItem1;
        public BarLargeButtonItem bbiAdd;
        public BarLargeButtonItem bbiCancel;
        public BarLargeButtonItem bbiChange;
        public BarButtonItem bbiChangeId;
        public BarLargeButtonItem bbiClose;
        public BarLargeButtonItem bbiConstruct;
        public BarLargeButtonItem bbiCopy;
        public BarLargeButtonItem bbiDelete;
        public BarLargeButtonItem bbiDeleteAll;
        public BarLargeButtonItem bbiDouble;
        public BarLargeButtonItem bbiEdit;
        public BarButtonItem bbiEditUnitConvret;
        public BarLargeButtonItem bbiExport;
        public BarButtonItem bbiGroup;
        public BarLargeButtonItem bbiHelp;
        public BarButtonItem bbiHistory;
        public BarSubItem bbiInterface;
        public BarButtonItem bbiMerge;
        public BarLargeButtonItem bbiOption;
        public BarSubItem bbiOther;
        public BarLargeButtonItem bbiPermision;
        public BarLargeButtonItem bbiPrint;
        public BarLargeButtonItem bbiRefresh;
        public BarLargeButtonItem bbiSave;
        public BarLargeButtonItem bbiSaveNew;
        public BarLargeButtonItem bbiSearch;
        public BarButtonItem bbiStock;
        public BarSubItem bbiUtils;
        public BarManager bm;
        private IContainer components = null;
        public DevExpress.Utils.ImageCollection imageCollection2;
        public PopupMenu pm;
        private RepositoryItemButtonEdit repositoryItemButtonEdit2;

        public event ButtonClickEventHander AddClick;

        public event ButtonClickEventHander CancelClick;

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

        public XucToolBar()
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XucToolBar));
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
            this.bm = new DevExpress.XtraBars.BarManager(this.components);
            this.barAccount = new DevExpress.XtraBars.Bar();
            this.bbiAdd = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiChange = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiDouble = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiPermision = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiConstruct = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiSaveNew = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiCancel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiOption = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiHelp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bbiSearch = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiCopy = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiDeleteAll = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiOther = new DevExpress.XtraBars.BarSubItem();
            this.bbiInterface = new DevExpress.XtraBars.BarSubItem();
            this.bbiHistory = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUtils = new DevExpress.XtraBars.BarSubItem();
            this.bbiGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMerge = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangeId = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditUnitConvret = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pm = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pm)).BeginInit();
            this.SuspendLayout();
            // 
            // bm
            // 
            this.bm.AllowCustomization = false;
            this.bm.AllowMoveBarOnToolbar = false;
            this.bm.AllowQuickCustomization = false;
            this.bm.AllowShowToolbarsPopup = false;
            this.bm.AutoSaveInRegistry = true;
            this.bm.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barAccount});
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.DockWindowTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bm.Form = this;
            this.bm.Images = this.imageCollection2;
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAdd,
            this.bbiEdit,
            this.bbiChange,
            this.bbiDelete,
            this.bbiRefresh,
            this.bbiClose,
            this.barSubItem1,
            this.bbiOption,
            this.bbiSearch,
            this.bbiHelp,
            this.bbiExport,
            this.bbiSave,
            this.bbiCancel,
            this.bbiSaveNew,
            this.bbiPermision,
            this.bbiConstruct,
            this.bbiCopy,
            this.bbiDouble,
            this.bbiPrint,
            this.bbiDeleteAll,
            this.bbiOther,
            this.bbiInterface,
            this.bbiHistory,
            this.bbiUtils,
            this.bbiGroup,
            this.bbiStock,
            this.bbiMerge,
            this.bbiChangeId,
            this.bbiEditUnitConvret});
            this.bm.LargeImages = this.imageCollection2;
            this.bm.MainMenu = this.barAccount;
            this.bm.MaxItemId = 57;
            this.bm.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2});
            this.bm.ShowFullMenusAfterDelay = false;
            // 
            // barAccount
            // 
            this.barAccount.BarName = "Main menu";
            this.barAccount.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barAccount.DockCol = 0;
            this.barAccount.DockRow = 0;
            this.barAccount.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barAccount.FloatLocation = new System.Drawing.Point(83, 126);
            this.barAccount.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.KeyTip))), this.bbiAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph, "ALT-T", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiChange, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDouble, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPermision, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiConstruct, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCancel),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiOption, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiHelp, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barAccount.OptionsBar.AllowQuickCustomization = false;
            this.barAccount.OptionsBar.DrawDragBorder = false;
            this.barAccount.OptionsBar.RotateWhenVertical = false;
            this.barAccount.OptionsBar.UseWholeRow = true;
            this.barAccount.Text = "Main menu";
            // 
            // bbiAdd
            // 
            this.bbiAdd.Caption = "&Thêm";
            this.bbiAdd.Id = 0;
            this.bbiAdd.ImageOptions.ImageIndex = 0;
            this.bbiAdd.ImageOptions.LargeImageIndex = 0;
            this.bbiAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.bbiAdd.Name = "bbiAdd";
            toolTipItem1.Text = "Alt-T\r\nCtrl+N";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiAdd.SuperTip = superToolTip1;
            this.bbiAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdd_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "&Sửa Chữa";
            this.bbiEdit.Enabled = false;
            this.bbiEdit.Id = 1;
            this.bbiEdit.ImageOptions.ImageIndex = 1;
            this.bbiEdit.ImageOptions.LargeImageIndex = 1;
            this.bbiEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiEdit.Name = "bbiEdit";
            toolTipItem2.Text = "F2\r\nEnter";
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiEdit.SuperTip = superToolTip2;
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiChange
            // 
            this.bbiChange.Caption = "T&hay Đổi";
            this.bbiChange.Enabled = false;
            this.bbiChange.Id = 2;
            this.bbiChange.ImageOptions.ImageIndex = 2;
            this.bbiChange.ImageOptions.LargeImageIndex = 2;
            this.bbiChange.Name = "bbiChange";
            this.bbiChange.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            toolTipItem3.Text = "F2\r\nCtrl+E\r\nEnter";
            superToolTip3.Items.Add(toolTipItem3);
            this.bbiChange.SuperTip = superToolTip3;
            this.bbiChange.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChange_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "&Xoá";
            this.bbiDelete.Enabled = false;
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageOptions.ImageIndex = 3;
            this.bbiDelete.ImageOptions.LargeImageIndex = 3;
            this.bbiDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete));
            this.bbiDelete.Name = "bbiDelete";
            toolTipItem4.Text = "Alt-X\r\nDelete";
            superToolTip4.Items.Add(toolTipItem4);
            this.bbiDelete.SuperTip = superToolTip4;
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiDouble
            // 
            this.bbiDouble.Caption = "Nhân Bản";
            this.bbiDouble.Enabled = false;
            this.bbiDouble.Id = 43;
            this.bbiDouble.ImageOptions.ImageIndex = 4;
            this.bbiDouble.ImageOptions.LargeImageIndex = 4;
            this.bbiDouble.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.C));
            this.bbiDouble.Name = "bbiDouble";
            this.bbiDouble.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDouble.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDouble_ItemClick);
            // 
            // bbiPermision
            // 
            this.bbiPermision.Caption = "Phân Quyền";
            this.bbiPermision.Id = 40;
            this.bbiPermision.ImageOptions.ImageIndex = 5;
            this.bbiPermision.ImageOptions.LargeImageIndex = 5;
            this.bbiPermision.Name = "bbiPermision";
            this.bbiPermision.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiPermision.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPermision_ItemClick);
            // 
            // bbiConstruct
            // 
            this.bbiConstruct.Caption = "Cấu Tạo";
            this.bbiConstruct.Id = 41;
            this.bbiConstruct.ImageOptions.ImageIndex = 63;
            this.bbiConstruct.ImageOptions.LargeImageIndex = 63;
            this.bbiConstruct.Name = "bbiConstruct";
            this.bbiConstruct.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiConstruct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConstruct_ItemClick);
            // 
            // bbiSaveNew
            // 
            this.bbiSaveNew.Caption = "Lưu && Thêm";
            this.bbiSaveNew.Id = 24;
            this.bbiSaveNew.ImageOptions.ImageIndex = 6;
            this.bbiSaveNew.ImageOptions.LargeImageIndex = 6;
            this.bbiSaveNew.Name = "bbiSaveNew";
            toolTipItem5.Text = "F2\r\nCtrl+ Shift+S\r\nCtrl+W";
            superToolTip5.Items.Add(toolTipItem5);
            this.bbiSaveNew.SuperTip = superToolTip5;
            this.bbiSaveNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveNew_ItemClick);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "&Lưu && Đóng";
            this.bbiSave.Id = 22;
            this.bbiSave.ImageOptions.ImageIndex = 6;
            this.bbiSave.ImageOptions.LargeImageIndex = 6;
            this.bbiSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiCancel
            // 
            this.bbiCancel.Caption = "Hủy bỏ";
            this.bbiCancel.Id = 23;
            this.bbiCancel.ImageOptions.ImageIndex = 13;
            this.bbiCancel.ImageOptions.LargeImageIndex = 13;
            this.bbiCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
            this.bbiCancel.Name = "bbiCancel";
            toolTipItem6.Text = "ESC";
            superToolTip6.Items.Add(toolTipItem6);
            this.bbiCancel.SuperTip = superToolTip6;
            this.bbiCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCancel_ItemClick);
            // 
            // bbiOption
            // 
            this.bbiOption.Caption = "Lựa Chọn";
            this.bbiOption.Id = 15;
            this.bbiOption.ImageOptions.ImageIndex = 7;
            this.bbiOption.ImageOptions.LargeImageIndex = 7;
            this.bbiOption.Name = "bbiOption";
            toolTipItem7.Text = "Ctrl+O";
            superToolTip7.Items.Add(toolTipItem7);
            this.bbiOption.SuperTip = superToolTip7;
            this.bbiOption.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiOption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOption_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "&Nạp Lại";
            this.bbiRefresh.Id = 4;
            this.bbiRefresh.ImageOptions.ImageIndex = 8;
            this.bbiRefresh.ImageOptions.LargeImageIndex = 8;
            this.bbiRefresh.Name = "bbiRefresh";
            toolTipItem8.Text = "F5";
            superToolTip8.Items.Add(toolTipItem8);
            this.bbiRefresh.SuperTip = superToolTip8;
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bbiPrint
            // 
            this.bbiPrint.Caption = "In";
            this.bbiPrint.Enabled = false;
            this.bbiPrint.Id = 44;
            this.bbiPrint.ImageOptions.ImageIndex = 9;
            this.bbiPrint.ImageOptions.LargeImageIndex = 9;
            this.bbiPrint.Name = "bbiPrint";
            this.bbiPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrint_ItemClick);
            // 
            // bbiExport
            // 
            this.bbiExport.Caption = "Xuất ";
            this.bbiExport.Enabled = false;
            this.bbiExport.Id = 19;
            this.bbiExport.ImageOptions.ImageIndex = 10;
            this.bbiExport.ImageOptions.LargeImageIndex = 10;
            this.bbiExport.Name = "bbiExport";
            toolTipItem9.Text = "Ctrl+E";
            superToolTip9.Items.Add(toolTipItem9);
            this.bbiExport.SuperTip = superToolTip9;
            this.bbiExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExport_ItemClick);
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "Trợ Giúp";
            this.bbiHelp.Id = 18;
            this.bbiHelp.ImageOptions.ImageIndex = 11;
            this.bbiHelp.ImageOptions.LargeImageIndex = 11;
            this.bbiHelp.Name = "bbiHelp";
            toolTipItem10.Text = "F1";
            superToolTip10.Items.Add(toolTipItem10);
            this.bbiHelp.SuperTip = superToolTip10;
            this.bbiHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHelp_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "&Đóng";
            this.bbiClose.Id = 6;
            this.bbiClose.ImageOptions.ImageIndex = 12;
            this.bbiClose.ImageOptions.LargeImageIndex = 12;
            this.bbiClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.bbiClose.Name = "bbiClose";
            toolTipItem11.Text = "F10";
            superToolTip11.Items.Add(toolTipItem11);
            this.bbiClose.SuperTip = superToolTip11;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bm;
            this.barDockControlTop.Size = new System.Drawing.Size(1236, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1);
            this.barDockControlBottom.Manager = this.bm;
            this.barDockControlBottom.Size = new System.Drawing.Size(1236, 42);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.bm;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1236, 0);
            this.barDockControlRight.Manager = this.bm;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1);
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.InsertGalleryImage("new_16x16.png", "office2013/actions/new_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/new_16x16.png"), 0);
            this.imageCollection2.Images.SetKeyName(0, "new_16x16.png");
            this.imageCollection2.InsertGalleryImage("replace_16x16.png", "office2013/format/replace_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/format/replace_16x16.png"), 1);
            this.imageCollection2.Images.SetKeyName(1, "replace_16x16.png");
            this.imageCollection2.InsertGalleryImage("changetextcase_16x16.png", "images/richedit/changetextcase_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/richedit/changetextcase_16x16.png"), 2);
            this.imageCollection2.Images.SetKeyName(2, "changetextcase_16x16.png");
            this.imageCollection2.InsertGalleryImage("delete_16x16.png", "office2013/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/edit/delete_16x16.png"), 3);
            this.imageCollection2.Images.SetKeyName(3, "delete_16x16.png");
            this.imageCollection2.InsertGalleryImage("copy_16x16.png", "images/edit/copy_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/copy_16x16.png"), 4);
            this.imageCollection2.Images.SetKeyName(4, "copy_16x16.png");
            this.imageCollection2.InsertGalleryImage("role_16x16.png", "images/people/role_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/role_16x16.png"), 5);
            this.imageCollection2.Images.SetKeyName(5, "role_16x16.png");
            this.imageCollection2.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 6);
            this.imageCollection2.Images.SetKeyName(6, "save_16x16.png");
            this.imageCollection2.InsertGalleryImage("checkbuttons_16x16.png", "images/filter%20elements/checkbuttons_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/filter%20elements/checkbuttons_16x16.png"), 7);
            this.imageCollection2.Images.SetKeyName(7, "checkbuttons_16x16.png");
            this.imageCollection2.InsertGalleryImage("refreshallpivottable_16x16.png", "images/spreadsheet/refreshallpivottable_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/refreshallpivottable_16x16.png"), 8);
            this.imageCollection2.Images.SetKeyName(8, "refreshallpivottable_16x16.png");
            this.imageCollection2.InsertGalleryImage("print_16x16.png", "office2013/print/print_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/print/print_16x16.png"), 9);
            this.imageCollection2.Images.SetKeyName(9, "print_16x16.png");
            this.imageCollection2.InsertGalleryImage("exporttoxlsx_16x16.png", "office2013/export/exporttoxlsx_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/export/exporttoxlsx_16x16.png"), 10);
            this.imageCollection2.Images.SetKeyName(10, "exporttoxlsx_16x16.png");
            this.imageCollection2.InsertGalleryImage("index_16x16.png", "images/support/index_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/index_16x16.png"), 11);
            this.imageCollection2.Images.SetKeyName(11, "index_16x16.png");
            this.imageCollection2.InsertGalleryImage("close_16x16.png", "office2013/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/close_16x16.png"), 12);
            this.imageCollection2.Images.SetKeyName(12, "close_16x16.png");
            this.imageCollection2.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 13);
            this.imageCollection2.Images.SetKeyName(13, "cancel_16x16.png");
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Xuất khẩu";
            this.barSubItem1.Id = 7;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "Tìm";
            this.bbiSearch.Id = 17;
            this.bbiSearch.ImageOptions.ImageIndex = 3;
            this.bbiSearch.Name = "bbiSearch";
            toolTipItem12.Text = "Ctrl+F";
            superToolTip12.Items.Add(toolTipItem12);
            this.bbiSearch.SuperTip = superToolTip12;
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSearch_ItemClick);
            // 
            // bbiCopy
            // 
            this.bbiCopy.Caption = "Chép vào ClipBoard";
            this.bbiCopy.Enabled = false;
            this.bbiCopy.Id = 42;
            this.bbiCopy.ImageOptions.ImageIndex = 1;
            this.bbiCopy.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.C));
            this.bbiCopy.Name = "bbiCopy";
            this.bbiCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCopy_ItemClick);
            // 
            // bbiDeleteAll
            // 
            this.bbiDeleteAll.Caption = "Xoá tất cả";
            this.bbiDeleteAll.Id = 46;
            this.bbiDeleteAll.ImageOptions.ImageIndex = 3;
            this.bbiDeleteAll.ImageOptions.LargeImageIndex = 3;
            this.bbiDeleteAll.Name = "bbiDeleteAll";
            this.bbiDeleteAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClear_ItemClick);
            // 
            // bbiOther
            // 
            this.bbiOther.Caption = "Khác";
            this.bbiOther.Id = 47;
            this.bbiOther.ImageOptions.ImageIndex = 7;
            this.bbiOther.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOption, true)});
            this.bbiOther.Name = "bbiOther";
            // 
            // bbiInterface
            // 
            this.bbiInterface.Caption = "Giao Diện";
            this.bbiInterface.Id = 48;
            this.bbiInterface.Name = "bbiInterface";
            // 
            // bbiHistory
            // 
            this.bbiHistory.Caption = "Lịch Sử Giao Dịch";
            this.bbiHistory.Id = 49;
            this.bbiHistory.ImageOptions.ImageIndex = 24;
            this.bbiHistory.Name = "bbiHistory";
            this.bbiHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHistory_ItemClick);
            // 
            // bbiUtils
            // 
            this.bbiUtils.Caption = "Tiện ích";
            this.bbiUtils.Id = 50;
            this.bbiUtils.ImageOptions.ImageIndex = 60;
            this.bbiUtils.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiGroup),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStock),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMerge),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiChangeId)});
            this.bbiUtils.Name = "bbiUtils";
            this.bbiUtils.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiGroup
            // 
            this.bbiGroup.Caption = "Thay Đổi Nhóm";
            this.bbiGroup.Id = 51;
            this.bbiGroup.ImageOptions.ImageIndex = 8;
            this.bbiGroup.Name = "bbiGroup";
            this.bbiGroup.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGroup_ItemClick);
            // 
            // bbiStock
            // 
            this.bbiStock.Caption = "Thay Đổi Kho";
            this.bbiStock.Id = 52;
            this.bbiStock.ImageOptions.ImageIndex = 27;
            this.bbiStock.Name = "bbiStock";
            this.bbiStock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStock_ItemClick);
            // 
            // bbiMerge
            // 
            this.bbiMerge.Caption = "Gộp";
            this.bbiMerge.Id = 53;
            this.bbiMerge.ImageOptions.ImageIndex = 14;
            this.bbiMerge.Name = "bbiMerge";
            this.bbiMerge.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiMerge.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMerge_ItemClick);
            // 
            // bbiChangeId
            // 
            this.bbiChangeId.Caption = "Đổi Mã";
            this.bbiChangeId.Id = 54;
            this.bbiChangeId.ImageOptions.ImageIndex = 37;
            this.bbiChangeId.Name = "bbiChangeId";
            this.bbiChangeId.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiChangeId.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangeId_ItemClick);
            // 
            // bbiEditUnitConvret
            // 
            this.bbiEditUnitConvret.Caption = "Bảng Quy Đổi Đơn Vị";
            this.bbiEditUnitConvret.Id = 55;
            this.bbiEditUnitConvret.ImageOptions.ImageIndex = 40;
            this.bbiEditUnitConvret.Name = "bbiEditUnitConvret";
            this.bbiEditUnitConvret.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditUnitConvret_ItemClick);
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // pm
            // 
            this.pm.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDeleteAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDouble),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOther),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPermision, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiConstruct, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiHelp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose, true)});
            this.pm.Manager = this.bm;
            this.pm.Name = "pm";
            // 
            // XucToolBar
            // 
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XucToolBar";
            this.Size = new System.Drawing.Size(1236, 43);
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
            if (this.CancelClick != null)
            {
                this.CancelClick(this);
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

        [Category("Design"), DefaultValue(false), Description("Button Add")]
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

        [Category("Design"), DefaultValue(false), Description("Button Change")]
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

        [DefaultValue(false), Description("Button Delete"), Category("Design")]
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

        [Category("Design"), DefaultValue(false), Description("Button Delete")]
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

        [DefaultValue(false), Category("Design"), Description("Button Save")]
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

        [Category("Design"), DefaultValue(false), Description("Button SaveNew")]
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

