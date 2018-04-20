namespace Vssoft.Common
{
    using DevExpress.Data;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Menu;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Grid.ViewInfo;
    using DevExpress.XtraTreeList;
    using Vssoft.Common.Base;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucBaseBasicA : xucBase
    {
        protected bool _search;
        private IContainer components = null;
        protected AdvBandedGridView gbList;
        protected GridControl gcList;
        protected GridBand gridBand1;
        protected Vssoft.Common.Common.Class.RowClickEventArgs m_RowClickEventArgs = new Vssoft.Common.Common.Class.RowClickEventArgs();
        protected Actions m_Status = Actions.Add;
        private PanelControl panelControl1;
        protected TreeList tList;
        protected XucToolBar ucToolBar;

        public event ButtonClickEventHander CloseClick;

        public event ListKeyDownEventHander ListKeyDown;

        public event RowClickEventHander RowClick;

        public event RowClickEventHander RowDoubleClick;

        public xucBaseBasicA()
        {
            this.InitializeComponent();
            this._search = false;
            this.DisableMenu(true);
        }

        protected virtual void Add()
        {
        }

        protected virtual void AddRow(object Item)
        {
        }

        protected virtual void bbiAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Add();
        }

        protected virtual void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RaiseCloseClickEventHander();
        }

        protected virtual void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gbList.RowCount != 0)
            {
                this.Delete();
                this.SetMenu(this.m_RowClickEventArgs);
            }
        }

        protected virtual void bbiDeleteAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gbList.RowCount != 0)
            {
                this.gbList.SelectAll();
                this.Delete();
                this.SetMenu(this.m_RowClickEventArgs);
            }
        }

        protected virtual void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gbList.RowCount != 0)
            {
                this.Change();
            }
        }

        protected virtual void bbiExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Export(this.gbList);
        }

        protected virtual void bbiPermision_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        protected virtual void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Print();
        }

        protected virtual void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ReLoad();
        }

        public virtual void Change()
        {
        }

        public virtual void Construct()
        {
        }

        public virtual void Delete()
        {
        }

        public void DisableMenu(bool disable)
        {
            this.ucToolBar.bbiEdit.Enabled = !disable;
            this.ucToolBar.bbiDelete.Enabled = !disable;
            this.ucToolBar.bbiDeleteAll.Enabled = !disable;
            this.ucToolBar.bbiPermision.Enabled = !disable;
            this.ucToolBar.bbiCopy.Enabled = !disable;
            this.ucToolBar.bbiPrint.Enabled = !disable;
            this.ucToolBar.bbiExport.Enabled = !disable;
        }

        public void DisableMenuNoData(bool disable)
        {
            this.DisableMenu(disable);
            this.ucToolBar.bbiPrint.Enabled = !disable;
            this.ucToolBar.bbiExport.Enabled = !disable;
            this.ucToolBar.bbiCopy.Enabled = !disable;
            this.ucToolBar.bbiEdit.Enabled = !disable;
            this.ucToolBar.bbiDelete.Enabled = !disable;
            this.ucToolBar.bbiDeleteAll.Enabled = !disable;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void DoShowMenu(GridHitInfo hi)
        {
            if (hi.HitTest == GridHitTest.ColumnButton)
            {
                GridViewMenu menu = new GridViewColumnButtonMenu(this.gbList);
                menu.Init(hi);
                menu.Show(hi.HitPoint);
            }
        }

        protected virtual void gbList_Click(object sender, EventArgs e)
        {
            if (sender is AdvBandedGridView)
            {
                AdvBandedGridView view = (AdvBandedGridView) sender;
                Vssoft.Common.Common.Class.RowClickEventArgs args = new Vssoft.Common.Common.Class.RowClickEventArgs((view == null) ? -1 : view.FocusedRowHandle, (view.FocusedColumn == null) ? -1 : view.FocusedColumn.ColumnHandle, (view.FocusedColumn == null) ? "" : view.FocusedColumn.FieldName);
                this.m_RowClickEventArgs = args;
                this.RaiseRowClickEventHander(args);
                this.ItemSelectd(args);
            }
            else
            {
                XtraMessageBox.Show("Object is not AdvBandedGridView");
            }
        }

        private void gbList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        protected virtual void gbList_DoubleClick(object sender, EventArgs e)
        {
            if (sender is AdvBandedGridView)
            {
                AdvBandedGridView view = (AdvBandedGridView) sender;
                Vssoft.Common.Common.Class.RowClickEventArgs args = new Vssoft.Common.Common.Class.RowClickEventArgs((view == null) ? -1 : view.FocusedRowHandle, (view.FocusedColumn == null) ? -1 : view.FocusedColumn.ColumnHandle, (view.FocusedColumn == null) ? "" : view.FocusedColumn.FieldName);
                this.m_RowClickEventArgs = args;
                if (!this._search)
                {
                    if (this.gbList.RowCount != 0)
                    {
                        this.RaiseRowDoubleClickEventHander(args);
                        this.Change();
                    }
                }
                else
                {
                    this.SetSearch(args);
                }
            }
            else
            {
                XtraMessageBox.Show("Object is not AdvBandedGridView");
            }
        }

        protected virtual void gbList_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is AdvBandedGridView)
            {
                AdvBandedGridView view = (AdvBandedGridView) sender;
                Vssoft.Common.Common.Class.RowClickEventArgs args = new Vssoft.Common.Common.Class.RowClickEventArgs((view == null) ? -1 : view.FocusedRowHandle, (view.FocusedColumn == null) ? -1 : view.FocusedColumn.ColumnHandle, (view.FocusedColumn == null) ? "" : view.FocusedColumn.FieldName);
                this.RaiseRowClickEventHander(args);
                this.RaiseListKeyDownEventHander(e, args);
                this.ucList_ListKeyDown(sender, e);
                this.m_RowClickEventArgs = args;
                if ((e.KeyCode == Keys.Delete) && (this.gbList.RowCount != 0))
                {
                    this.Delete();
                    this.SetMenu(this.m_RowClickEventArgs);
                }
            }
            else
            {
                XtraMessageBox.Show("Object is not AdvBandedGridView");
            }
        }

        protected virtual void gbList_Layout(object sender, EventArgs e)
        {
            this.SaveLayout();
        }

        protected virtual void gbList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoShowMenu(this.gbList.CalcHitInfo(new Point(e.X, e.Y)));
            }
            AdvBandedGridView view = (AdvBandedGridView) sender;
            Vssoft.Common.Common.Class.RowClickEventArgs args = new Vssoft.Common.Common.Class.RowClickEventArgs((view == null) ? -1 : view.FocusedRowHandle, (view.FocusedColumn == null) ? -1 : view.FocusedColumn.ColumnHandle, (view.FocusedColumn == null) ? "" : view.FocusedColumn.FieldName);
            this.m_RowClickEventArgs = args;
            this.SetMenu(args);
            this.RaiseRowClickEventHander(args);
        }

        protected virtual void gbList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Vssoft.Common.Common.Class.RowClickEventArgs args = new Vssoft.Common.Common.Class.RowClickEventArgs(e.RowHandle, e.Column.ColumnHandle);
            this.m_RowClickEventArgs = args;
            this.RaiseRowClickEventHander(args);
            this.ItemSelectd(args);
            this.SetMenu(args);
            this.SetSearch(args);
        }

        public object GetCellValue(Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
            AdvBandedGridView gbList = this.gbList;
            GridColumn column = new GridColumn();
            if (e.ColumnIndex != -1)
            {
                column = gbList.Columns[e.ColumnIndex];
            }
            else
            {
                column = gbList.Columns[e.FieldName];
            }
            return gbList.GetRowCellValue(e.RowIndex, column);
        }

        public object GetCellValue(int RowIndex, int ColumIndex) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(RowIndex, ColumIndex));

        public object GetCellValue(int RowIndex, string FieldName) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(RowIndex, FieldName));

        public virtual void Import()
        {
        }

        private void Init()
        {
            this.ucToolBar.AddClick += new ButtonClickEventHander(this.ucToolBar_AddClick);
            this.ucToolBar.EditClick += new ButtonClickEventHander(this.ucToolBar_EditClick);
            this.ucToolBar.DeleteClick += new ButtonClickEventHander(this.ucToolBar_DeleteClick);
            this.ucToolBar.SearchClick += new ButtonClickEventHander(this.ucToolBar_SearchClick);
            this.ucToolBar.PrintClick += new ButtonClickEventHander(this.ucToolBar_PrintClick);
            this.ucToolBar.RefreshClick += new ButtonClickEventHander(this.ucToolBar_RefreshClick);
            this.ucToolBar.OptionClick += new ButtonClickEventHander(this.ucToolBar_OptionClick);
            this.ucToolBar.ExportClick += new ButtonClickEventHander(this.ucToolBar_Export);
            this.ucToolBar.HelpClick += new ButtonClickEventHander(this.ucToolBar_HelpClick);
            this.ucToolBar.CloseClick += new ButtonClickEventHander(this.ucToolBar_CloseClick);
            this.ucToolBar.ImportClick += new ButtonClickEventHander(this.ucToolBar_ImportClick);
            this.ucToolBar.PermisionClick += new ButtonClickEventHander(this.ucToolBar_PermisionClick);
            this.ucToolBar.ConstructClick += new ButtonClickEventHander(this.ucToolBar_ConstructClick);
            this.ucToolBar.CopyClick += new ButtonClickEventHander(this.ucToolBar_CopyClick);
            this.ucToolBar.MirrorClick += new ButtonClickEventHander(this.ucToolBar_MirrorClick);
            this.ucToolBar.ClearClick += new ButtonClickEventHander(this.ucToolBar_ClearClick);
            this.ReLoad();
            this.m_Status = Actions.None;
            this.ucToolBar.bm.SetPopupContextMenu(this.gcList, this.ucToolBar.pm);
        }

        private void InitializeComponent()
        {
            this.ucToolBar = new XucToolBar();
            this.tList = new TreeList();
            this.gbList = new AdvBandedGridView();
            this.gridBand1 = new GridBand();
            this.gcList = new GridControl();
            this.panelControl1 = new PanelControl();
            this.tList.BeginInit();
            this.gbList.BeginInit();
            this.gcList.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.ucToolBar.ButtonAdd = BarItemVisibility.Always;
            this.ucToolBar.ButtonCancel = BarItemVisibility.Never;
            this.ucToolBar.ButtonChange = BarItemVisibility.Never;
            this.ucToolBar.ButtonDelete = BarItemVisibility.Always;
            this.ucToolBar.ButtonEdit = BarItemVisibility.Always;
            this.ucToolBar.ButtonExport = BarItemVisibility.Always;
            this.ucToolBar.ButtonOption = BarItemVisibility.Never;
            this.ucToolBar.ButtonPrint = BarItemVisibility.Always;
            this.ucToolBar.ButtonSave = BarItemVisibility.Never;
            this.ucToolBar.ButtonSaveNew = BarItemVisibility.Never;
            this.ucToolBar.Dock = DockStyle.Top;
            this.ucToolBar.IsClose = CloseOrNew.None;
            this.ucToolBar.Location = new Point(0, 0);
            this.ucToolBar.Name = "ucToolBar";
            this.ucToolBar.Size = new Size(0x2f9, 0x2b);
            this.ucToolBar.Status = Actions.Add;
            this.ucToolBar.TabIndex = 0;
            this.ucToolBar.Title = "";
            this.tList.Dock = DockStyle.Left;
            this.tList.Location = new Point(0, 0x2b);
            this.tList.Name = "tList";
            this.tList.Size = new Size(270, 0x1c6);
            this.tList.TabIndex = 11;
            this.gbList.Bands.AddRange(new GridBand[] { this.gridBand1 });
            this.gbList.GridControl = this.gcList;
            this.gbList.GroupSummary.AddRange(new GridSummaryItem[] { new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "") });
            this.gbList.IndicatorWidth = 0x2d;
            this.gbList.Name = "gbList";
            this.gbList.OptionsPrint.ExpandAllDetails = true;
            this.gbList.OptionsPrint.PrintDetails = true;
            this.gbList.OptionsPrint.PrintFilterInfo = true;
            this.gbList.OptionsPrint.PrintPreview = true;
            this.gbList.OptionsSelection.InvertSelection = true;
            this.gbList.OptionsSelection.MultiSelect = true;
            this.gbList.OptionsView.ColumnAutoWidth = true;
            this.gbList.OptionsView.ShowAutoFilterRow = true;
            this.gbList.OptionsView.ShowBands = false;
            this.gbList.OptionsView.ShowDetailButtons = false;
            this.gbList.OptionsView.ShowFooter = true;
            this.gbList.OptionsView.ShowGroupPanel = false;
            this.gbList.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gbList.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.gbList_CustomDrawRowIndicator);
            this.gbList.KeyDown += new KeyEventHandler(this.gbList_KeyDown);
            this.gbList.Click += new EventHandler(this.gbList_Click);
            this.gbList.Layout += new EventHandler(this.gbList_Layout);
            this.gbList.MouseDown += new MouseEventHandler(this.gbList_MouseDown);
            this.gbList.DoubleClick += new EventHandler(this.gbList_DoubleClick);
            this.gbList.RowCellClick += new RowCellClickEventHandler(this.gbList_RowCellClick);
            this.gridBand1.Caption = "DANH MỤC";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.ShowCaption = false;
            this.gridBand1.ToolTip = "DANH MỤC";
            this.gcList.Dock = DockStyle.Fill;
            this.gcList.Location = new Point(2, 2);
            this.gcList.LookAndFeel.SkinName = "Office 2007 Black";
            this.gcList.MainView = this.gbList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new Size(0x1e7, 450);
            this.gcList.TabIndex = 10;
            this.gcList.ViewCollection.AddRange(new BaseView[] { this.gbList });
            this.panelControl1.Controls.Add(this.gcList);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(270, 0x2b);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x1eb, 0x1c6);
            this.panelControl1.TabIndex = 12;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.tList);
            base.Controls.Add(this.ucToolBar);
            this.DoubleBuffered = true;
            base.Name = "xucBaseBasicA";
            base.Size = new Size(0x2f9, 0x1f1);
            this.tList.EndInit();
            this.gbList.EndInit();
            this.gcList.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        protected virtual void ItemSelectd(Vssoft.Common.Common.Class.RowClickEventArgs ex)
        {
        }

        protected virtual void List_Init(AdvBandedGridView dt)
        {
        }

        public virtual void Mirror()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();
            base.OnLoad(e);
        }

        public virtual void Permision()
        {
        }

        protected virtual void Print()
        {
            this.gcList.ShowPrintPreview();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.RaiseCloseClickEventHander();
                    return true;

                case Keys.F1:
                    this.ucToolBar_HelpClick(this.ucToolBar);
                    return true;

                case Keys.F5:
                    this.ReLoad();
                    return true;

                case (Keys.Control | Keys.E):
                    this.ucToolBar_Export(this.ucToolBar);
                    return true;

                case (Keys.Control | Keys.F):
                    this.ucToolBar_SearchClick(this.ucToolBar);
                    return true;

                case (Keys.Control | Keys.N):
                    this.ucToolBar_AddClick(this.ucToolBar);
                    return true;

                case (Keys.Control | Keys.O):
                    this.ucToolBar_OptionClick(this.ucToolBar);
                    return true;

                case (Keys.Control | Keys.P):
                    this.ucToolBar_PrintClick(this.ucToolBar);
                    return true;

                case (Keys.Control | Keys.T):
                    this.ucToolBar_AddClick(this.ucToolBar);
                    return true;

                case (Keys.Alt | Keys.D):
                    MessageBox.Show("You are stupid");
                    return true;

                case (Keys.Alt | Keys.X):
                    this.RaiseCloseClickEventHander();
                    return true;
            }
            return false;
        }

        private void RaiseCloseClickEventHander()
        {
            if (this.CloseClick != null)
            {
                this.CloseClick(this);
            }
        }

        private void RaiseListKeyDownEventHander(KeyEventArgs key, Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
            if (this.ListKeyDown != null)
            {
                this.ListKeyDown(this, key, e);
            }
        }

        private void RaiseRowClickEventHander(Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
            if (this.RowClick != null)
            {
                this.RowClick(this, e);
            }
        }

        private void RaiseRowDoubleClickEventHander(Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
            if (this.RowDoubleClick != null)
            {
                this.RowDoubleClick(this, e);
            }
        }

        public virtual void ReadLayout()
        {
            this.ReadLayout(base.Name);
        }

        public virtual void ReadLayout(string name)
        {
            FileInfo info = new FileInfo(Application.StartupPath + @"\Layout\" + name + ".xml");
            if (info.Exists)
            {
                try
                {
                    this.gbList.RestoreLayoutFromXml(info.FullName);
                }
                catch
                {
                }
            }
        }

        public virtual void ReLoad()
        {
        }

        public virtual void SaveLayout()
        {
            this.SaveLayout(base.Name);
        }

        public virtual void SaveLayout(string name)
        {
        }

        protected virtual void Search()
        {
            XtraMessageBox.Show("T\x00ednh năng n\x00e0y kh\x00f4ng được hỗ trợ!");
        }

        protected virtual void SetMenu(Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
        }

        public virtual void SetSearch(Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
        }

        private void ucList_ListKeyDown(object sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.F2)
            {
                if (this.gbList.RowCount != 0)
                {
                    this.Change();
                }
            }
            else if ((key.KeyCode == Keys.Control) | (key.KeyCode == Keys.E))
            {
                if (this.gbList.RowCount != 0)
                {
                    this.Change();
                }
            }
            else if (key.KeyCode == Keys.Enter)
            {
                if (this.gbList.RowCount != 0)
                {
                    this.Change();
                }
            }
            else if (key.KeyCode == Keys.F5)
            {
                this.ReLoad();
            }
            else if ((key.KeyCode == Keys.Control) | (key.KeyCode == Keys.N))
            {
                this.Add();
            }
            else if ((key.KeyCode == Keys.Control) | (key.KeyCode == Keys.T))
            {
                this.Add();
            }
        }

        private void ucToolBar_AddClick(object sender)
        {
            this.Add();
        }

        private void ucToolBar_ClearClick(object sender)
        {
            if (this.gbList.RowCount != 0)
            {
                this.gbList.SelectAll();
                this.Delete();
                this.SetMenu(this.m_RowClickEventArgs);
            }
        }

        private void ucToolBar_CloseClick(object sender)
        {
            this.RaiseCloseClickEventHander();
        }

        private void ucToolBar_ConstructClick(object sender)
        {
            this.Construct();
        }

        private void ucToolBar_CopyClick(object sender)
        {
            this.gbList.CopyToClipboard();
        }

        private void ucToolBar_DeleteClick(object sender)
        {
            if (this.gbList.RowCount != 0)
            {
                this.Delete();
                this.SetMenu(this.m_RowClickEventArgs);
            }
        }

        private void ucToolBar_EditClick(object sender)
        {
            if (this.gbList.RowCount != 0)
            {
                this.Change();
            }
        }

        private void ucToolBar_Export(object sender)
        {
            this.Export(this.gbList);
        }

        private void ucToolBar_HelpClick(object sender)
        {
            XtraMessageBox.Show("T\x00ednh năng n\x00e0y kh\x00f4ng được hỗ trợ!");
        }

        private void ucToolBar_ImportClick(object sender)
        {
            this.Import();
        }

        private void ucToolBar_MirrorClick(object sender)
        {
            this.Mirror();
        }

        private void ucToolBar_OptionClick(object sender)
        {
            XtraMessageBox.Show("T\x00ednh năng n\x00e0y kh\x00f4ng được hỗ trợ!");
        }

        private void ucToolBar_PermisionClick(object sender)
        {
            this.Permision();
        }

        private void ucToolBar_PrintClick(object sender)
        {
            this.Print();
        }

        private void ucToolBar_RefreshClick(object sender)
        {
            this.ReLoad();
        }

        private void ucToolBar_SearchClick(object sender)
        {
            this.Search();
        }

        protected virtual void UpdateRow(object Item, Vssoft.Common.Common.Class.RowClickEventArgs e)
        {
        }

        public bool IsSearch
        {
            get => 
                this._search;
            set
            {
                this._search = value;
            }
        }
    }
}

