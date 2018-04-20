namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using Microsoft.VisualBasic;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class XucBaseBasicE : xucBase
    {
        public Bar barAccount;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        public BarEditItem bbeDateTimeSelect;
        public BarEditItem bbeFromDate;
        public BarEditItem bbeMonth;
        public BarEditItem bbeName;
        public BarEditItem bbeTableListSelect;
        public BarEditItem bbeToDate;
        public BarEditItem bbeYear;
        public BarButtonItem bbiActionPlusWithData;
        public BarButtonItem bbiAdd;
        public BarButtonItem bbiClose;
        public BarButtonItem bbiCopy;
        public BarButtonItem bbiCreate;
        public BarButtonItem bbiDelete;
        public BarButtonItem bbiEdit;
        public BarButtonItem bbiExport;
        public BarButtonItem bbiFinish;
        public BarButtonItem bbiHelp;
        public BarButtonItem bbiImport;
        public BarButtonItem bbiLock;
        public BarButtonItem bbiNameListOption;
        public BarButtonItem bbiOpen;
        public BarButtonItem bbiPrint;
        public BarButtonItem bbiQuickAdd;
        public BarButtonItem bbiReCreate;
        public BarButtonItem bbiRefresh;
        public BarButtonItem bbiSendMail;
        public BarButtonItem bbiView;
        public BarManager bm;
        private IContainer components = null;
        public GridColumn gridLookupID;
        public GridColumn gridLookupName;
        private DevExpress.Utils.ImageCollection imgToolBar;
        protected System.DateTime m_FromDate;
        protected bool m_IsFinish = false;
        protected bool m_IsFirstLoad = true;
        protected bool m_IsLock = false;
        protected int m_Month = 0;
        protected System.DateTime m_ToDate;
        protected int m_Year = 0;
        public PopupMenu pm;
        public RepositoryItemComboBox repDateTimeSelect;
        public RepositoryItemDateEdit repFromDate;
        public RepositoryItemTimeEdit repMonth;
        public RepositoryItemTextEdit repName;
        private GridView repTableListGridLookupSelect;
        public RepositoryItemGridLookUpEdit repTableListSelect;
        public RepositoryItemDateEdit repToDate;
        public RepositoryItemTimeEdit repYear;

        public XucBaseBasicE()
        {
            this.InitializeComponent();
        }

        private void _exportView_Click(object sender, EventArgs e)
        {
        }

        private void _exportView_DataSourceChanged(object sender, EventArgs e)
        {
            this.CustomizeToolBar(0);
        }

        private void _exportView_DoubleClick(object sender, EventArgs e)
        {
            if ((base._exportView.RowCount != 0) && this.bbiEdit.Enabled)
            {
                this.Change();
            }
        }

        private void _exportView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if ((base._exportView.RowCount != 0) && this.bbiEdit.Enabled)
                {
                    this.Change();
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.Reload();
            }
            else if ((e.KeyCode == Keys.Control) | (e.KeyCode == Keys.N))
            {
                if (this.bbiAdd.Enabled)
                {
                    this.Add();
                }
            }
            else if ((e.KeyCode == Keys.Alt) | (e.KeyCode == Keys.T))
            {
                if (this.bbiAdd.Enabled)
                {
                    this.Add();
                }
            }
            else if ((e.KeyCode == Keys.Control) | (e.KeyCode == Keys.E))
            {
                base.Export();
            }
            else if ((e.KeyCode == Keys.Control) | (e.KeyCode == Keys.P))
            {
                this.Print();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if ((base._exportView.RowCount != 0) && this.bbiDelete.Enabled)
                {
                    this.Delete();
                }
            }
            else if ((((e.KeyCode == Keys.Alt) | (e.KeyCode == Keys.X)) && (base._exportView.RowCount != 0)) && this.bbiDelete.Enabled)
            {
                this.Delete();
            }
        }

        private void _exportView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                base.DoShowMenu(base._exportView.CalcHitInfo(new Point(e.X, e.Y)), base._exportView, this);
            }
        }

        private void _exportView_RowCountChanged(object sender, EventArgs e)
        {
            this.CustomizeToolBar(0);
        }

        protected virtual void ActionPlusWithData()
        {
        }

        protected virtual void Add()
        {
        }

        protected virtual void AfterInitializeComponent()
        {
        }

        private void bbeDateTimeSelect_EditValueChanged(object sender, EventArgs e)
        {
            this.SetDateTime(this.bbeDateTimeSelect.EditValue.ToString());
        }

        protected virtual void bbeTableListSelect_EditValueChanged()
        {
        }

        private void bbeTableListSelect_EditValueChanged(object sender, EventArgs e)
        {
            this.bbeTableListSelect_EditValueChanged();
        }

        private void bbiActionPlusWithData_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ActionPlusWithData();
        }

        private void bbiAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Add();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Copy();
        }

        private void bbiCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Create();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Delete();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Change();
        }

        private void bbiExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.Export();
        }

        private void bbiFinish_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Finish();
            this.CustomizeToolBar(0);
        }

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Help();
        }

        private void bbiImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Import();
        }

        private void bbiLock_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Lock();
            this.CustomizeToolBar(0);
        }

        protected virtual void bbiNameListOption_ItemClick()
        {
        }

        private void bbiNameListOption_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.bbiNameListOption_ItemClick();
        }

        private void bbiOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Open();
            this.CustomizeToolBar(0);
        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Print();
        }

        private void bbiQuickAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.QuickAdd();
        }

        private void bbiReCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ReCreate();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Reload();
        }

        private void bbiSendMail_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.SendMail();
        }

        private void bbiView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.View();
        }

        protected virtual void Change()
        {
        }

        protected virtual void Close()
        {
            base.ParentForm.Close();
        }

        protected virtual void Copy()
        {
            if (base._exportView != null)
            {
                Clipboard.SetText(base._exportView.GetFocusedValue().ToString());
            }
        }

        protected virtual void Create()
        {
        }

        public virtual void CustomizeComponent()
        {
        }

        protected void CustomizeToolBar(int TypeToolBar)
        {
            if (TypeToolBar == -1)
            {
                this.bbiAdd.Enabled = false;
                this.bbiQuickAdd.Enabled = false;
                this.bbiReCreate.Enabled = false;
                this.bbiSendMail.Enabled = false;
                this.bbiEdit.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiImport.Enabled = false;
                this.bbiExport.Enabled = false;
                this.bbiPrint.Enabled = false;
                this.bbiLock.Enabled = false;
                this.bbiOpen.Enabled = false;
                this.bbiFinish.Enabled = false;
                this.bbiActionPlusWithData.Enabled = false;
            }
            else if (base._exportControl.DataSource == null)
            {
                this.CustomizeToolBar(-1);
            }
            else if (!(!this.m_IsLock || this.m_IsFinish))
            {
                this.bbiAdd.Enabled = false;
                this.bbiQuickAdd.Enabled = false;
                this.bbiReCreate.Enabled = false;
                this.bbiSendMail.Enabled = true;
                this.bbiEdit.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiImport.Enabled = false;
                this.bbiExport.Enabled = true;
                this.bbiPrint.Enabled = true;
                this.bbiLock.Enabled = false;
                this.bbiOpen.Enabled = true;
                this.bbiFinish.Enabled = true;
                this.bbiActionPlusWithData.Enabled = false;
            }
            else if (this.m_IsLock && this.m_IsFinish)
            {
                this.bbiAdd.Enabled = false;
                this.bbiQuickAdd.Enabled = false;
                this.bbiReCreate.Enabled = false;
                this.bbiSendMail.Enabled = true;
                this.bbiEdit.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiImport.Enabled = false;
                this.bbiExport.Enabled = true;
                this.bbiPrint.Enabled = true;
                this.bbiLock.Enabled = false;
                this.bbiOpen.Enabled = false;
                this.bbiFinish.Enabled = false;
                this.bbiActionPlusWithData.Enabled = false;
            }
            else if (base._exportView.RowCount == 0)
            {
                this.bbiAdd.Enabled = true;
                this.bbiQuickAdd.Enabled = true;
                this.bbiReCreate.Enabled = true;
                this.bbiSendMail.Enabled = false;
                this.bbiEdit.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiImport.Enabled = true;
                this.bbiExport.Enabled = false;
                this.bbiPrint.Enabled = true;
                this.bbiLock.Enabled = true;
                this.bbiOpen.Enabled = true;
                this.bbiFinish.Enabled = true;
                this.bbiActionPlusWithData.Enabled = true;
            }
            else
            {
                this.bbiAdd.Enabled = true;
                this.bbiQuickAdd.Enabled = true;
                this.bbiReCreate.Enabled = true;
                this.bbiSendMail.Enabled = true;
                this.bbiEdit.Enabled = true;
                this.bbiDelete.Enabled = true;
                this.bbiImport.Enabled = true;
                this.bbiExport.Enabled = true;
                this.bbiPrint.Enabled = true;
                this.bbiLock.Enabled = true;
                this.bbiOpen.Enabled = true;
                this.bbiFinish.Enabled = true;
                this.bbiActionPlusWithData.Enabled = true;
            }
        }

        protected virtual void Delete()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected virtual void Finish()
        {
        }

        protected virtual void Help()
        {
        }

        protected virtual void Import()
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(XucBaseBasicE));
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
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
            this.bm = new BarManager(this.components);
            this.barAccount = new Bar();
            this.bbeDateTimeSelect = new BarEditItem();
            this.repDateTimeSelect = new RepositoryItemComboBox();
            this.bbeFromDate = new BarEditItem();
            this.repFromDate = new RepositoryItemDateEdit();
            this.bbeToDate = new BarEditItem();
            this.repToDate = new RepositoryItemDateEdit();
            this.bbeTableListSelect = new BarEditItem();
            this.repTableListSelect = new RepositoryItemGridLookUpEdit();
            this.repTableListGridLookupSelect = new GridView();
            this.gridLookupID = new GridColumn();
            this.gridLookupName = new GridColumn();
            this.bbeMonth = new BarEditItem();
            this.repMonth = new RepositoryItemTimeEdit();
            this.bbeYear = new BarEditItem();
            this.repYear = new RepositoryItemTimeEdit();
            this.bbeName = new BarEditItem();
            this.repName = new RepositoryItemTextEdit();
            this.bbiNameListOption = new BarButtonItem();
            this.bbiView = new BarButtonItem();
            this.bbiReCreate = new BarButtonItem();
            this.bbiCreate = new BarButtonItem();
            this.bbiActionPlusWithData = new BarButtonItem();
            this.bbiQuickAdd = new BarButtonItem();
            this.bbiAdd = new BarButtonItem();
            this.bbiImport = new BarButtonItem();
            this.bbiEdit = new BarButtonItem();
            this.bbiDelete = new BarButtonItem();
            this.bbiPrint = new BarButtonItem();
            this.bbiExport = new BarButtonItem();
            this.bbiSendMail = new BarButtonItem();
            this.bbiLock = new BarButtonItem();
            this.bbiOpen = new BarButtonItem();
            this.bbiFinish = new BarButtonItem();
            this.bbiRefresh = new BarButtonItem();
            this.bbiClose = new BarButtonItem();
            this.bbiHelp = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.imgToolBar = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiCopy = new BarButtonItem();
            this.pm = new PopupMenu(this.components);
            this.bm.BeginInit();
            this.repDateTimeSelect.BeginInit();
            this.repFromDate.BeginInit();
            this.repFromDate.VistaTimeProperties.BeginInit();
            this.repToDate.BeginInit();
            this.repToDate.VistaTimeProperties.BeginInit();
            this.repTableListSelect.BeginInit();
            this.repTableListGridLookupSelect.BeginInit();
            this.repMonth.BeginInit();
            this.repYear.BeginInit();
            this.repName.BeginInit();
            this.imgToolBar.BeginInit();
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
            this.bm.Images = this.imgToolBar;
            this.bm.Items.AddRange(new BarItem[] { 
                this.bbiAdd, this.bbiEdit, this.bbiDelete, this.bbiRefresh, this.bbiClose, this.bbiHelp, this.bbiExport, this.bbiCopy, this.bbiPrint, this.bbiImport, this.bbeYear, this.bbeName, this.bbiCreate, this.bbiView, this.bbeDateTimeSelect, this.bbeFromDate,
                this.bbeToDate, this.bbeMonth, this.bbiLock, this.bbiOpen, this.bbiFinish, this.bbiQuickAdd, this.bbeTableListSelect, this.bbiReCreate, this.bbiNameListOption, this.bbiSendMail, this.bbiActionPlusWithData
            });
            this.bm.LargeImages = this.imgToolBar;
            this.bm.MaxItemId = 0x4d;
            this.bm.RepositoryItems.AddRange(new RepositoryItem[] { this.repYear, this.repName, this.repDateTimeSelect, this.repFromDate, this.repToDate, this.repMonth, this.repTableListSelect });
            this.bm.ShowFullMenusAfterDelay = false;
            this.barAccount.BarName = "Custom 3";
            this.barAccount.DockCol = 0;
            this.barAccount.DockRow = 0;
            this.barAccount.DockStyle = BarDockStyle.Top;
            this.barAccount.LinksPersistInfo.AddRange(new LinkPersistInfo[] { 
                new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeDateTimeSelect, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeFromDate, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeToDate, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeTableListSelect, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeMonth, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeYear, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbeName, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiNameListOption, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiView, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiReCreate, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiCreate, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiActionPlusWithData, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiQuickAdd, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.KeyTip | BarLinkUserDefines.PaintStyle, this.bbiAdd, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph, "", ""), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiImport, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiEdit, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph),
                new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiDelete, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiPrint, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiExport, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiSendMail, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiLock, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiOpen, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiFinish, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiRefresh, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiClose, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.bbiHelp, BarItemPaintStyle.CaptionGlyph)
            });
            this.barAccount.OptionsBar.AllowCollapse = true;
            this.barAccount.OptionsBar.UseWholeRow = true;
            this.barAccount.Text = "Custom 3";
            this.bbeDateTimeSelect.Caption = "Khoảng thời gian:";
            this.bbeDateTimeSelect.Edit = this.repDateTimeSelect;
            this.bbeDateTimeSelect.Id = 0x3f;
            this.bbeDateTimeSelect.Name = "bbeDateTimeSelect";
            this.bbeDateTimeSelect.Width = 110;
            this.bbeDateTimeSelect.EditValueChanged += new EventHandler(this.bbeDateTimeSelect_EditValueChanged);
            this.repDateTimeSelect.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repDateTimeSelect.Appearance.Options.UseFont = true;
            this.repDateTimeSelect.AppearanceDropDown.Font = new Font("Tahoma", 9.25f, FontStyle.Bold);
            this.repDateTimeSelect.AppearanceDropDown.Options.UseFont = true;
            this.repDateTimeSelect.AutoHeight = false;
            this.repDateTimeSelect.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repDateTimeSelect.Items.AddRange(new object[] { 
                "T\x00f9y chọn", "H\x00f4m nay", "Tuần n\x00e0y", "Th\x00e1ng n\x00e0y", "Qu\x00fd n\x00e0y", "Năm nay", "Th\x00e1ng 1", "Th\x00e1ng 2", "Th\x00e1ng 3", "Th\x00e1ng 4", "Th\x00e1ng 5", "Th\x00e1ng 6", "Th\x00e1ng 7", "Th\x00e1ng 8", "Th\x00e1ng 9", "Th\x00e1ng 10",
                "Th\x00e1ng 11", "Th\x00e1ng 12", "Qu\x00fd 1", "Qu\x00fd 2", "Qu\x00fd 3", "Qu\x00fd 4"
            });
            this.repDateTimeSelect.Name = "repDateTimeSelect";
            this.repDateTimeSelect.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.bbeFromDate.Caption = "Từ ng\x00e0y:";
            this.bbeFromDate.Edit = this.repFromDate;
            this.bbeFromDate.Id = 0x40;
            this.bbeFromDate.Name = "bbeFromDate";
            this.bbeFromDate.Width = 90;
            this.repFromDate.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repFromDate.Appearance.Options.UseFont = true;
            this.repFromDate.AutoHeight = false;
            this.repFromDate.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repFromDate.Name = "repFromDate";
            this.repFromDate.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.bbeToDate.Caption = "Đến ng\x00e0y:";
            this.bbeToDate.Edit = this.repToDate;
            this.bbeToDate.Id = 0x41;
            this.bbeToDate.Name = "bbeToDate";
            this.bbeToDate.Width = 90;
            this.repToDate.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repToDate.Appearance.Options.UseFont = true;
            this.repToDate.AutoHeight = false;
            this.repToDate.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repToDate.Name = "repToDate";
            this.repToDate.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.bbeTableListSelect.Caption = "Chọn:";
            this.bbeTableListSelect.Edit = this.repTableListSelect;
            this.bbeTableListSelect.Id = 0x48;
            this.bbeTableListSelect.Name = "bbeTableListSelect";
            this.bbeTableListSelect.Width = 170;
            this.bbeTableListSelect.EditValueChanged += new EventHandler(this.bbeTableListSelect_EditValueChanged);
            this.repTableListSelect.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repTableListSelect.Appearance.Options.UseFont = true;
            this.repTableListSelect.AutoHeight = false;
            this.repTableListSelect.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, (Image) manager.GetObject("repTableListSelect.Buttons"), new KeyShortcut(Keys.None), appearance, "", null, null, true) });
            this.repTableListSelect.Name = "repTableListSelect";
            this.repTableListSelect.NullText = "[Chưa chọn dữ liệu]";
            this.repTableListSelect.View = this.repTableListGridLookupSelect;
            this.repTableListSelect.EditValueChanging += new ChangingEventHandler(this.repTableListSelect_EditValueChanging);
            this.repTableListSelect.ButtonClick += new ButtonPressedEventHandler(this.repTableListSelect_ButtonClick);
            this.repTableListGridLookupSelect.Columns.AddRange(new GridColumn[] { this.gridLookupID, this.gridLookupName });
            this.repTableListGridLookupSelect.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.repTableListGridLookupSelect.Name = "repTableListGridLookupSelect";
            this.repTableListGridLookupSelect.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repTableListGridLookupSelect.OptionsView.ShowGroupPanel = false;
            this.gridLookupID.Caption = "M\x00e3";
            this.gridLookupID.FieldName = "ID";
            this.gridLookupID.Name = "gridLookupID";
            this.gridLookupName.Caption = "T\x00ean";
            this.gridLookupName.Name = "gridLookupName";
            this.gridLookupName.Visible = true;
            this.gridLookupName.VisibleIndex = 0;
            this.bbeMonth.Caption = "Th\x00e1ng:";
            this.bbeMonth.Edit = this.repMonth;
            this.bbeMonth.Id = 0x42;
            this.bbeMonth.Name = "bbeMonth";
            this.repMonth.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repMonth.Appearance.Options.UseFont = true;
            this.repMonth.AutoHeight = false;
            this.repMonth.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repMonth.Mask.EditMask = "MM";
            this.repMonth.Mask.UseMaskAsDisplayFormat = true;
            this.repMonth.Name = "repMonth";
            this.bbeYear.Caption = "Năm:";
            this.bbeYear.Edit = this.repYear;
            this.bbeYear.Id = 0x3b;
            this.bbeYear.Name = "bbeYear";
            this.bbeYear.Width = 60;
            this.repYear.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repYear.Appearance.Options.UseFont = true;
            this.repYear.AutoHeight = false;
            this.repYear.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repYear.Mask.EditMask = "yyyy";
            this.repYear.Mask.UseMaskAsDisplayFormat = true;
            this.repYear.Name = "repYear";
            this.bbeName.Caption = "T\x00ean:";
            this.bbeName.Edit = this.repName;
            this.bbeName.Id = 60;
            this.bbeName.Name = "bbeName";
            this.bbeName.Width = 120;
            this.repName.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repName.Appearance.Options.UseFont = true;
            this.repName.AutoHeight = false;
            this.repName.Name = "repName";
            this.repName.ReadOnly = true;
            this.bbiNameListOption.Id = 0x4a;
            this.bbiNameListOption.ImageIndex = 0x40;
            this.bbiNameListOption.Name = "bbiNameListOption";
            this.bbiNameListOption.ItemClick += new ItemClickEventHandler(this.bbiNameListOption_ItemClick);
            this.bbiView.Caption = "Xem";
            this.bbiView.Id = 0x3e;
            this.bbiView.ImageIndex = 3;
            this.bbiView.LargeImageIndex = 3;
            this.bbiView.Name = "bbiView";
            this.bbiView.ItemClick += new ItemClickEventHandler(this.bbiView_ItemClick);
            this.bbiReCreate.Caption = "T\x00ednh Lại";
            this.bbiReCreate.Id = 0x49;
            this.bbiReCreate.ImageIndex = 0x21;
            this.bbiReCreate.Name = "bbiReCreate";
            this.bbiReCreate.ItemClick += new ItemClickEventHandler(this.bbiReCreate_ItemClick);
            this.bbiCreate.Caption = "Tạo";
            this.bbiCreate.Id = 0x3d;
            this.bbiCreate.ImageIndex = 1;
            this.bbiCreate.LargeImageIndex = 1;
            this.bbiCreate.Name = "bbiCreate";
            this.bbiCreate.ItemClick += new ItemClickEventHandler(this.bbiCreate_ItemClick);
            this.bbiActionPlusWithData.Caption = "#";
            this.bbiActionPlusWithData.Id = 0x4c;
            this.bbiActionPlusWithData.ImageIndex = 30;
            this.bbiActionPlusWithData.Name = "bbiActionPlusWithData";
            this.bbiActionPlusWithData.Visibility = BarItemVisibility.Never;
            this.bbiActionPlusWithData.ItemClick += new ItemClickEventHandler(this.bbiActionPlusWithData_ItemClick);
            this.bbiQuickAdd.Caption = "Ch\x00e8n Nhanh";
            this.bbiQuickAdd.Id = 0x47;
            this.bbiQuickAdd.ImageIndex = 0x2c;
            this.bbiQuickAdd.Name = "bbiQuickAdd";
            this.bbiQuickAdd.ItemClick += new ItemClickEventHandler(this.bbiQuickAdd_ItemClick);
            this.bbiAdd.Caption = "&Th\x00eam";
            this.bbiAdd.Id = 0;
            this.bbiAdd.ImageIndex = 6;
            this.bbiAdd.ItemShortcut = new BarShortcut(Keys.Control | Keys.N);
            this.bbiAdd.LargeImageIndex = 6;
            this.bbiAdd.Name = "bbiAdd";
            item.Text = "Alt-T\r\nCtrl+N\r\nTh\x00eam";
            tip.Items.Add(item);
            this.bbiAdd.SuperTip = tip;
            this.bbiAdd.ItemClick += new ItemClickEventHandler(this.bbiAdd_ItemClick);
            this.bbiImport.Caption = "Nạp >";
            this.bbiImport.Id = 0x39;
            this.bbiImport.ImageIndex = 0x39;
            this.bbiImport.ItemShortcut = new BarShortcut(Keys.Control | Keys.I);
            this.bbiImport.Name = "bbiImport";
            item2.Text = "Ctrl+I\r\nNạp";
            tip2.Items.Add(item2);
            this.bbiImport.SuperTip = tip2;
            this.bbiImport.ItemClick += new ItemClickEventHandler(this.bbiImport_ItemClick);
            this.bbiEdit.Caption = "&Sửa";
            this.bbiEdit.Id = 1;
            this.bbiEdit.ImageIndex = 14;
            this.bbiEdit.ItemShortcut = new BarShortcut(Keys.F2);
            this.bbiEdit.LargeImageIndex = 14;
            this.bbiEdit.Name = "bbiEdit";
            item3.Text = "F2\r\nCtrl+Enter\r\nSửa";
            tip3.Items.Add(item3);
            this.bbiEdit.SuperTip = tip3;
            this.bbiEdit.ItemClick += new ItemClickEventHandler(this.bbiEdit_ItemClick);
            this.bbiDelete.Caption = "&Xo\x00e1";
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageIndex = 13;
            this.bbiDelete.ItemShortcut = new BarShortcut(Keys.Delete);
            this.bbiDelete.Name = "bbiDelete";
            item4.Text = "Alt-X\r\nDelete\r\nX\x00f3a";
            tip4.Items.Add(item4);
            this.bbiDelete.SuperTip = tip4;
            this.bbiDelete.ItemClick += new ItemClickEventHandler(this.bbiDelete_ItemClick);
            this.bbiPrint.Caption = "In";
            this.bbiPrint.Id = 0x2c;
            this.bbiPrint.ImageIndex = 9;
            this.bbiPrint.ItemShortcut = new BarShortcut(Keys.Control | Keys.P);
            this.bbiPrint.Name = "bbiPrint";
            item5.Text = "Ctrl+P\r\nIn";
            tip5.Items.Add(item5);
            this.bbiPrint.SuperTip = tip5;
            this.bbiPrint.ItemClick += new ItemClickEventHandler(this.bbiPrint_ItemClick);
            this.bbiExport.Caption = "Xuất ";
            this.bbiExport.Id = 0x13;
            this.bbiExport.ImageIndex = 0x37;
            this.bbiExport.ItemShortcut = new BarShortcut(Keys.Control | Keys.E);
            this.bbiExport.LargeImageIndex = 0x37;
            this.bbiExport.Name = "bbiExport";
            item6.Text = "Ctrl+E";
            tip6.Items.Add(item6);
            this.bbiExport.SuperTip = tip6;
            this.bbiExport.ItemClick += new ItemClickEventHandler(this.bbiExport_ItemClick);
            this.bbiSendMail.Caption = "Gửi Mail";
            this.bbiSendMail.Id = 0x4b;
            this.bbiSendMail.ImageIndex = 0x41;
            this.bbiSendMail.Name = "bbiSendMail";
            this.bbiSendMail.ItemClick += new ItemClickEventHandler(this.bbiSendMail_ItemClick);
            this.bbiLock.Caption = "Kh\x00f3a Sổ";
            this.bbiLock.Id = 0x44;
            this.bbiLock.ImageIndex = 0x3e;
            this.bbiLock.Name = "bbiLock";
            this.bbiLock.ItemClick += new ItemClickEventHandler(this.bbiLock_ItemClick);
            this.bbiOpen.Caption = "Mở Sổ";
            this.bbiOpen.Id = 0x45;
            this.bbiOpen.ImageIndex = 0x2e;
            this.bbiOpen.Name = "bbiOpen";
            this.bbiOpen.ItemClick += new ItemClickEventHandler(this.bbiOpen_ItemClick);
            this.bbiFinish.Caption = "Ho\x00e0n Th\x00e0nh";
            this.bbiFinish.Id = 70;
            this.bbiFinish.ImageIndex = 12;
            this.bbiFinish.Name = "bbiFinish";
            this.bbiFinish.ItemClick += new ItemClickEventHandler(this.bbiFinish_ItemClick);
            this.bbiRefresh.Caption = "&Nạp Lại";
            this.bbiRefresh.Id = 4;
            this.bbiRefresh.ImageIndex = 0x2a;
            this.bbiRefresh.ItemShortcut = new BarShortcut(Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            item7.Text = "F5\r\nNạp Lại";
            tip7.Items.Add(item7);
            this.bbiRefresh.SuperTip = tip7;
            this.bbiRefresh.ItemClick += new ItemClickEventHandler(this.bbiRefresh_ItemClick);
            this.bbiClose.Caption = "&Đ\x00f3ng";
            this.bbiClose.Id = 6;
            this.bbiClose.ImageIndex = 0x16;
            this.bbiClose.Name = "bbiClose";
            item8.Text = "F10";
            tip8.Items.Add(item8);
            this.bbiClose.SuperTip = tip8;
            this.bbiClose.ItemClick += new ItemClickEventHandler(this.bbiClose_ItemClick);
            this.bbiHelp.Caption = "Trợ Gi\x00fap";
            this.bbiHelp.Id = 0x12;
            this.bbiHelp.ImageIndex = 0x19;
            this.bbiHelp.Name = "bbiHelp";
            item9.Text = "F1";
            tip9.Items.Add(item9);
            this.bbiHelp.SuperTip = tip9;
            this.bbiHelp.Visibility = BarItemVisibility.Never;
            this.bbiHelp.ItemClick += new ItemClickEventHandler(this.bbiHelp_ItemClick);
            this.imgToolBar.ImageStream = (ImageCollectionStreamer) manager.GetObject("imgToolBar.ImageStream");
            this.bbiCopy.Caption = "Sao Ch\x00e9p";
            this.bbiCopy.Id = 0x2b;
            this.bbiCopy.ImageIndex = 8;
            this.bbiCopy.ItemShortcut = new BarShortcut(Keys.Control | Keys.C);
            this.bbiCopy.Name = "bbiCopy";
            this.bbiCopy.ItemClick += new ItemClickEventHandler(this.bbiCopy_ItemClick);
            this.pm.LinksPersistInfo.AddRange(new LinkPersistInfo[] { 
                new LinkPersistInfo(this.bbiCreate), new LinkPersistInfo(this.bbiQuickAdd), new LinkPersistInfo(this.bbiReCreate), new LinkPersistInfo(this.bbiAdd), new LinkPersistInfo(this.bbiImport), new LinkPersistInfo(this.bbiEdit), new LinkPersistInfo(this.bbiDelete), new LinkPersistInfo(this.bbiCopy), new LinkPersistInfo(this.bbiPrint, true), new LinkPersistInfo(this.bbiExport), new LinkPersistInfo(this.bbiSendMail), new LinkPersistInfo(this.bbiOpen, true), new LinkPersistInfo(this.bbiLock), new LinkPersistInfo(this.bbiFinish), new LinkPersistInfo(this.bbiRefresh, true), new LinkPersistInfo(this.bbiHelp, true),
                new LinkPersistInfo(this.bbiClose, true)
            });
            this.pm.Manager = this.bm;
            this.pm.Name = "pm";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            base.Name = "XucBaseBasicE";
            base.Size = new Size(0x9bd, 0x298);
            this.bm.EndInit();
            this.repDateTimeSelect.EndInit();
            this.repFromDate.VistaTimeProperties.EndInit();
            this.repFromDate.EndInit();
            this.repToDate.VistaTimeProperties.EndInit();
            this.repToDate.EndInit();
            this.repTableListSelect.EndInit();
            this.repTableListGridLookupSelect.EndInit();
            this.repMonth.EndInit();
            this.repYear.EndInit();
            this.repName.EndInit();
            this.imgToolBar.EndInit();
            this.pm.EndInit();
            base.ResumeLayout(false);
        }

        protected virtual void Lock()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CustomizeToolBar(-1);
            this.repMonth.EditValueChanging += new ChangingEventHandler(this.repMonth_EditValueChanging);
            this.repMonth.EditValueChanged += new EventHandler(this.repMonth_EditValueChanged);
            this.repYear.EditValueChanging += new ChangingEventHandler(this.repYear_EditValueChanging);
            this.repYear.EditValueChanged += new EventHandler(this.repYear_EditValueChanged);
            this.repFromDate.EditValueChanging += new ChangingEventHandler(this.repFromDate_EditValueChanging);
            this.repFromDate.EditValueChanged += new EventHandler(this.repFromDate_EditValueChanged);
            this.repToDate.EditValueChanging += new ChangingEventHandler(this.repToDate_EditValueChanging);
            this.repToDate.EditValueChanged += new EventHandler(this.repToDate_EditValueChanged);
            clsAllOption option = new clsAllOption();
            this.m_Month = option.MonthDefault.Month;
            this.m_Year = option.MonthDefault.Year;
            this.bbeMonth.EditValue = option.MonthDefault;
            this.bbeYear.EditValue = option.MonthDefault;
            if (base._exportView != null)
            {
                base.RestoreLayout(base._exportView, this);
                base._exportView.Click += new EventHandler(this._exportView_Click);
                base._exportView.DoubleClick += new EventHandler(this._exportView_DoubleClick);
                base._exportView.KeyDown += new KeyEventHandler(this._exportView_KeyDown);
                base._exportView.MouseDown += new MouseEventHandler(this._exportView_MouseDown);
                base._exportView.DataSourceChanged += new EventHandler(this._exportView_DataSourceChanged);
                base._exportView.RowCountChanged += new EventHandler(this._exportView_RowCountChanged);
                base._exportView.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.XucBaseBasicE_CustomDrawRowIndicator);
            }
            if (base._exportControl != null)
            {
                this.bm.SetPopupContextMenu(base._exportControl, this.pm);
            }
            this.Reload();
        }

        protected virtual void Open()
        {
        }

        protected virtual void Print()
        {
        }

        protected virtual void QuickAdd()
        {
        }

        protected virtual void ReCreate()
        {
        }

        protected virtual void Reload()
        {
        }

        private void repFromDate_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void repFromDate_EditValueChanging(object sender, ChangingEventArgs e)
        {
            this.m_FromDate = System.DateTime.Parse(e.NewValue.ToString());
        }

        protected virtual void repMonth_EditValueChanged()
        {
        }

        private void repMonth_EditValueChanged(object sender, EventArgs e)
        {
            this.repYear_EditValueChanged();
        }

        protected virtual void repMonth_EditValueChanging()
        {
        }

        private void repMonth_EditValueChanging(object sender, ChangingEventArgs e)
        {
            this.m_Month = System.DateTime.Parse(e.NewValue.ToString()).Month;
            this.repYear_EditValueChanging();
        }

        protected virtual void repTableListSelect_ButtonClick()
        {
        }

        private void repTableListSelect_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                this.repTableListSelect_ButtonClick();
            }
        }

        protected virtual void repTableListSelect_EditValueChanging(ChangingEventArgs e)
        {
        }

        private void repTableListSelect_EditValueChanging(object sender, ChangingEventArgs e)
        {
            this.repTableListSelect_EditValueChanging(e);
        }

        private void repToDate_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void repToDate_EditValueChanging(object sender, ChangingEventArgs e)
        {
            this.m_ToDate = System.DateTime.Parse(e.NewValue.ToString());
        }

        protected virtual void repYear_EditValueChanged()
        {
        }

        private void repYear_EditValueChanged(object sender, EventArgs e)
        {
            this.repYear_EditValueChanged();
        }

        protected virtual void repYear_EditValueChanging()
        {
        }

        private void repYear_EditValueChanging(object sender, ChangingEventArgs e)
        {
            this.m_Year = System.DateTime.Parse(e.NewValue.ToString()).Year;
            this.repYear_EditValueChanging();
        }

        protected virtual void SendMail()
        {
        }

        private void SetDateTime(string text)
        {
            if ((this.bbeFromDate.EditValue != null) && (this.bbeToDate.EditValue != null))
            {
                this.m_FromDate = System.DateTime.Parse(this.bbeFromDate.EditValue.ToString());
                this.m_ToDate = System.DateTime.Parse(this.bbeToDate.EditValue.ToString());
            }
            else
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            if (text == "H\x00f4m nay")
            {
                this.m_FromDate = System.DateTime.Now;
                this.m_ToDate = System.DateTime.Now;
            }
            else if (text == "Tuần n\x00e0y")
            {
                this.m_FromDate = DateAndTime.DateAdd(DateInterval.Day, (double) -DateAndTime.Weekday(System.DateTime.Now, FirstDayOfWeek.Monday), System.DateTime.Now);
                this.m_ToDate = DateAndTime.DateAdd(DateInterval.Day, (double) DateAndTime.Weekday(System.DateTime.Now, FirstDayOfWeek.Monday), System.DateTime.Now);
            }
            else if (text == "Th\x00e1ng n\x00e0y")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd n\x00e0y")
            {
                if ((System.DateTime.Now.Month >= 1) & (System.DateTime.Now.Month <= 3))
                {
                    this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 1, 1);
                    this.m_ToDate = this.m_FromDate.AddMonths(4).AddDays(-1.0);
                }
                else if ((System.DateTime.Now.Month >= 4) & (System.DateTime.Now.Month <= 6))
                {
                    this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 4, 1);
                    this.m_ToDate = this.m_FromDate.AddMonths(4).AddDays(-1.0);
                }
                else if ((System.DateTime.Now.Month >= 7) & (System.DateTime.Now.Month <= 9))
                {
                    this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 9, 1);
                    this.m_ToDate = this.m_FromDate.AddMonths(4).AddDays(-1.0);
                }
                else
                {
                    this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 10, 1);
                    this.m_ToDate = this.m_FromDate.AddMonths(4).AddDays(-1.0);
                }
            }
            else if (text == "Năm nay")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 1, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(12).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 1")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 1, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 2")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 2, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 3")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 3, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 4")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 4, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 5")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 5, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 6")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 6, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 7")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 7, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 8")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 8, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 9")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 9, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 10")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 10, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 11")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 11, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 12")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 12, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 1")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 1, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(3).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 2")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 4, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(3).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 3")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 7, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(3).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 4")
            {
                this.m_FromDate = new System.DateTime(System.DateTime.Now.Year, 10, 1);
                this.m_ToDate = this.m_FromDate.AddMonths(3).AddDays(-1.0);
            }
            this.bbeFromDate.EditValue = this.m_FromDate;
            this.bbeToDate.EditValue = this.m_ToDate;
        }

        protected virtual void View()
        {
        }

        private void XucBaseBasicE_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle == -2147483648)
            {
                e.Handled = true;
                e.Painter.DrawObject(e.Info);
                Rectangle bounds = e.Bounds;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0x3f, 0xa5, 0xa5, 0)), bounds);
                bounds.Height--;
                bounds.Width--;
                e.Graphics.DrawRectangle(Pens.Blue, bounds);
            }
            int rowHandle = e.RowHandle;
            if (rowHandle >= 0)
            {
                rowHandle++;
                e.Info.DisplayText = rowHandle.ToString();
            }
        }
    }
}

