namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class XucBaseBasicF : xucBase
    {
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        public BarButtonItem bbiCopy;
        public BarButtonItem bbiDelete;
        public BarButtonItem bbiExport;
        public BarButtonItem bbiImport;
        public BarButtonItem bbiPrint;
        public BarButtonItem bbiRefresh;
        public BarButtonItem bbiView;
        public BarManager bm;
        private IContainer components = null;
        public GridColumn gridLookupID;
        public GridColumn gridLookupName;
        private DevExpress.Utils.ImageCollection imgToolBar;
        public PopupMenu pm;
        public RepositoryItemComboBox repDateTimeSelect;
        public RepositoryItemDateEdit repFromDate;
        public RepositoryItemTimeEdit repMonth;
        public RepositoryItemTextEdit repName;
        private GridView repTableListGridLookupSelect;
        public RepositoryItemGridLookUpEdit repTableListSelect;
        public RepositoryItemDateEdit repToDate;
        public RepositoryItemTimeEdit repYear;

        public XucBaseBasicF()
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
        }

        private void _exportView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (base._exportView.RowCount != 0)
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
                this.Add();
            }
            else if ((e.KeyCode == Keys.Alt) | (e.KeyCode == Keys.T))
            {
                this.Add();
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
                if (base._exportView.RowCount != 0)
                {
                    this.Delete();
                }
            }
            else if (((e.KeyCode == Keys.Alt) | (e.KeyCode == Keys.X)) && (base._exportView.RowCount != 0))
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

        protected virtual void Add()
        {
        }

        protected virtual void AfterInitializeComponent()
        {
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

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Help();
        }

        private void bbiImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Import();
        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Print();
        }

        private void bbiReCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ReCreate();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Reload();
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
                this.bbiCopy.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiImport.Enabled = false;
                this.bbiExport.Enabled = false;
                this.bbiPrint.Enabled = false;
                this.bbiRefresh.Enabled = false;
            }
            else if (base._exportControl.DataSource == null)
            {
                this.CustomizeToolBar(-1);
            }
            else if (base._exportView.RowCount <= 1)
            {
                this.bbiCopy.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiImport.Enabled = true;
                this.bbiExport.Enabled = false;
                this.bbiPrint.Enabled = true;
                this.bbiRefresh.Enabled = true;
            }
            else
            {
                this.bbiCopy.Enabled = true;
                this.bbiDelete.Enabled = true;
                this.bbiImport.Enabled = true;
                this.bbiExport.Enabled = true;
                this.bbiPrint.Enabled = true;
                this.bbiRefresh.Enabled = true;
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

        protected virtual void Help()
        {
        }

        public virtual void Import()
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(XucBaseBasicF));
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
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
            this.bm = new BarManager(this.components);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.imgToolBar = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiDelete = new BarButtonItem();
            this.bbiRefresh = new BarButtonItem();
            this.bbiExport = new BarButtonItem();
            this.bbiCopy = new BarButtonItem();
            this.bbiPrint = new BarButtonItem();
            this.bbiImport = new BarButtonItem();
            this.bbiView = new BarButtonItem();
            this.repYear = new RepositoryItemTimeEdit();
            this.repName = new RepositoryItemTextEdit();
            this.repDateTimeSelect = new RepositoryItemComboBox();
            this.repFromDate = new RepositoryItemDateEdit();
            this.repToDate = new RepositoryItemDateEdit();
            this.repMonth = new RepositoryItemTimeEdit();
            this.repTableListSelect = new RepositoryItemGridLookUpEdit();
            this.repTableListGridLookupSelect = new GridView();
            this.gridLookupID = new GridColumn();
            this.gridLookupName = new GridColumn();
            this.pm = new PopupMenu(this.components);
            this.bm.BeginInit();
            this.imgToolBar.BeginInit();
            this.repYear.BeginInit();
            this.repName.BeginInit();
            this.repDateTimeSelect.BeginInit();
            this.repFromDate.BeginInit();
            this.repFromDate.VistaTimeProperties.BeginInit();
            this.repToDate.BeginInit();
            this.repToDate.VistaTimeProperties.BeginInit();
            this.repMonth.BeginInit();
            this.repTableListSelect.BeginInit();
            this.repTableListGridLookupSelect.BeginInit();
            this.pm.BeginInit();
            base.SuspendLayout();
            this.bm.AllowCustomization = false;
            this.bm.AllowMoveBarOnToolbar = false;
            this.bm.AllowQuickCustomization = false;
            this.bm.AllowShowToolbarsPopup = false;
            this.bm.AutoSaveInRegistry = true;
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.DockWindowTabFont = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.bm.Form = this;
            this.bm.Images = this.imgToolBar;
            this.bm.Items.AddRange(new BarItem[] { this.bbiDelete, this.bbiRefresh, this.bbiExport, this.bbiCopy, this.bbiPrint, this.bbiImport, this.bbiView });
            this.bm.LargeImages = this.imgToolBar;
            this.bm.MaxItemId = 0x4b;
            this.bm.RepositoryItems.AddRange(new RepositoryItem[] { this.repYear, this.repName, this.repDateTimeSelect, this.repFromDate, this.repToDate, this.repMonth, this.repTableListSelect });
            this.bm.ShowFullMenusAfterDelay = false;
            this.imgToolBar.ImageStream = (ImageCollectionStreamer) manager.GetObject("imgToolBar.ImageStream");
            this.bbiDelete.Caption = "&Xo\x00e1";
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageIndex = 13;
            this.bbiDelete.ItemShortcut = new BarShortcut(Keys.Delete);
            this.bbiDelete.Name = "bbiDelete";
            item.Text = "Alt-X\r\nDelete\r\nX\x00f3a";
            tip.Items.Add(item);
            this.bbiDelete.SuperTip = tip;
            this.bbiDelete.ItemClick += new ItemClickEventHandler(this.bbiDelete_ItemClick);
            this.bbiRefresh.Caption = "&Nạp Lại";
            this.bbiRefresh.Id = 4;
            this.bbiRefresh.ImageIndex = 0x2a;
            this.bbiRefresh.ItemShortcut = new BarShortcut(Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            item2.Text = "F5\r\nNạp Lại";
            tip2.Items.Add(item2);
            this.bbiRefresh.SuperTip = tip2;
            this.bbiRefresh.ItemClick += new ItemClickEventHandler(this.bbiRefresh_ItemClick);
            this.bbiExport.Caption = "Xuất ";
            this.bbiExport.Id = 0x13;
            this.bbiExport.ImageIndex = 0x37;
            this.bbiExport.ItemShortcut = new BarShortcut(Keys.Control | Keys.E);
            this.bbiExport.LargeImageIndex = 0x37;
            this.bbiExport.Name = "bbiExport";
            item3.Text = "Ctrl+E";
            tip3.Items.Add(item3);
            this.bbiExport.SuperTip = tip3;
            this.bbiExport.ItemClick += new ItemClickEventHandler(this.bbiExport_ItemClick);
            this.bbiCopy.Caption = "Sao Ch\x00e9p";
            this.bbiCopy.Id = 0x2b;
            this.bbiCopy.ImageIndex = 8;
            this.bbiCopy.ItemShortcut = new BarShortcut(Keys.Control | Keys.Shift | Keys.C);
            this.bbiCopy.Name = "bbiCopy";
            this.bbiCopy.ItemClick += new ItemClickEventHandler(this.bbiCopy_ItemClick);
            this.bbiPrint.Caption = "In";
            this.bbiPrint.Id = 0x2c;
            this.bbiPrint.ImageIndex = 9;
            this.bbiPrint.ItemShortcut = new BarShortcut(Keys.Control | Keys.P);
            this.bbiPrint.Name = "bbiPrint";
            item4.Text = "Ctrl+P\r\nIn";
            tip4.Items.Add(item4);
            this.bbiPrint.SuperTip = tip4;
            this.bbiPrint.ItemClick += new ItemClickEventHandler(this.bbiPrint_ItemClick);
            this.bbiImport.Caption = "Nạp >";
            this.bbiImport.Id = 0x39;
            this.bbiImport.ImageIndex = 0x39;
            this.bbiImport.ItemShortcut = new BarShortcut(Keys.Control | Keys.I);
            this.bbiImport.Name = "bbiImport";
            item5.Text = "Ctrl+I\r\nNạp";
            tip5.Items.Add(item5);
            this.bbiImport.SuperTip = tip5;
            this.bbiImport.ItemClick += new ItemClickEventHandler(this.bbiImport_ItemClick);
            this.bbiView.Caption = "Xem";
            this.bbiView.Id = 0x3e;
            this.bbiView.ImageIndex = 3;
            this.bbiView.LargeImageIndex = 3;
            this.bbiView.Name = "bbiView";
            this.bbiView.ItemClick += new ItemClickEventHandler(this.bbiView_ItemClick);
            this.repYear.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repYear.Appearance.Options.UseFont = true;
            this.repYear.AutoHeight = false;
            this.repYear.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repYear.Mask.EditMask = "yyyy";
            this.repYear.Mask.UseMaskAsDisplayFormat = true;
            this.repYear.Name = "repYear";
            this.repName.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repName.Appearance.Options.UseFont = true;
            this.repName.AutoHeight = false;
            this.repName.Name = "repName";
            this.repName.ReadOnly = true;
            this.repDateTimeSelect.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repDateTimeSelect.Appearance.Options.UseFont = true;
            this.repDateTimeSelect.AppearanceDropDown.Font = new Font("Tahoma", 9.25f, FontStyle.Bold);
            this.repDateTimeSelect.AppearanceDropDown.Options.UseFont = true;
            this.repDateTimeSelect.AutoHeight = false;
            this.repDateTimeSelect.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repDateTimeSelect.Items.AddRange(new object[] { 
                "H\x00f4m nay", "Tuần n\x00e0y", "Th\x00e1ng n\x00e0y", "Qu\x00fd n\x00e0y", "Năm nay", "Th\x00e1ng 1", "Th\x00e1ng 2", "Th\x00e1ng 3", "Th\x00e1ng 4", "Th\x00e1ng 5", "Th\x00e1ng 6", "Th\x00e1ng 7", "Th\x00e1ng 8", "Th\x00e1ng 9", "Th\x00e1ng 10", "Th\x00e1ng 11",
                "Th\x00e1ng 12", "Qu\x00fd 1", "Qu\x00fd 2", "Qu\x00fd 3", "Qu\x00fd 4"
            });
            this.repDateTimeSelect.Name = "repDateTimeSelect";
            this.repFromDate.AutoHeight = false;
            this.repFromDate.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repFromDate.Name = "repFromDate";
            this.repFromDate.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repToDate.AutoHeight = false;
            this.repToDate.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repToDate.Name = "repToDate";
            this.repToDate.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repMonth.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repMonth.Appearance.Options.UseFont = true;
            this.repMonth.AutoHeight = false;
            this.repMonth.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repMonth.Mask.EditMask = "MM";
            this.repMonth.Mask.UseMaskAsDisplayFormat = true;
            this.repMonth.Name = "repMonth";
            this.repTableListSelect.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.repTableListSelect.Appearance.Options.UseFont = true;
            this.repTableListSelect.AutoHeight = false;
            this.repTableListSelect.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, (Image) manager.GetObject("repTableListSelect.Buttons"), new KeyShortcut(Keys.None), appearance, "", null, null, true) });
            this.repTableListSelect.Name = "repTableListSelect";
            this.repTableListSelect.NullText = "[Chưa chọn dữ liệu]";
            this.repTableListSelect.View = this.repTableListGridLookupSelect;
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
            this.pm.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.bbiDelete), new LinkPersistInfo(this.bbiCopy), new LinkPersistInfo(this.bbiExport, true), new LinkPersistInfo(this.bbiPrint), new LinkPersistInfo(this.bbiRefresh, true) });
            this.pm.Manager = this.bm;
            this.pm.Name = "pm";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            base.Name = "XucBaseBasicF";
            base.Size = new Size(0x2d4, 0x1dd);
            this.bm.EndInit();
            this.imgToolBar.EndInit();
            this.repYear.EndInit();
            this.repName.EndInit();
            this.repDateTimeSelect.EndInit();
            this.repFromDate.VistaTimeProperties.EndInit();
            this.repFromDate.EndInit();
            this.repToDate.VistaTimeProperties.EndInit();
            this.repToDate.EndInit();
            this.repMonth.EndInit();
            this.repTableListSelect.EndInit();
            this.repTableListGridLookupSelect.EndInit();
            this.pm.EndInit();
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CustomizeToolBar(-1);
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

        protected virtual void Print()
        {
        }

        protected virtual void ReCreate()
        {
        }

        protected virtual void Reload()
        {
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

