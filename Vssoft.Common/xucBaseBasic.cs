﻿namespace Vssoft.Common
{
    using DevExpress.Data;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Menu;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Grid.ViewInfo;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Vssoft.Common.Base;
    using Vssoft.Common.Common.Class;
    using Vssoft.Common.Report;

    public class xucBaseBasic : xucBase
    {
        protected bool _search;
        private string _Title = "";
        private IContainer components = null;
        private BaseView exportView;
        public AdvBandedGridView gbList;
        public GridControl gcList;
        public GridBand gridBand1;
        protected Vssoft.Common.Common.Class.RowClickEventArgs m_RowClickEventArgs = new Vssoft.Common.Common.Class.RowClickEventArgs();
        protected Actions m_Status = Actions.Add;
        protected XucToolBar ucToolBar;

        public event ButtonClickEventHander CloseClick;

        public event ListKeyDownEventHander ListKeyDown;

        public event RowClickEventHander RowClick;

        public event RowClickEventHander RowDoubleClick;

        public xucBaseBasic()
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

        protected virtual bool ExportPermision() => 
            true;

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
            Vssoft.Common.MenuButton menuButton1 = new Vssoft.Common.MenuButton();
            Vssoft.Common.ItemCommand itemCommand1 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand2 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand3 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand4 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand5 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand6 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand7 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand8 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand9 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand10 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand11 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand12 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand13 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand14 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand15 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand16 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand17 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand18 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand19 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand20 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand21 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand22 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand23 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand24 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand25 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand26 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand27 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand28 = new Vssoft.Common.ItemCommand();
            Vssoft.Common.ItemCommand itemCommand29 = new Vssoft.Common.ItemCommand();
            this.ucToolBar = new Vssoft.Common.Base.XucToolBar();
            this.gbList = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gbList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucToolBar
            // 
            this.ucToolBar.ButtonAdd = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucToolBar.ButtonCancel = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucToolBar.ButtonChange = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucToolBar.ButtonDelete = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucToolBar.ButtonEdit = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucToolBar.ButtonExport = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucToolBar.ButtonOption = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucToolBar.ButtonPrint = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ucToolBar.ButtonSave = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucToolBar.ButtonSaveNew = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ucToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolBar.IsClose = Vssoft.Common.Common.Class.CloseOrNew.None;
            this.ucToolBar.Location = new System.Drawing.Point(0, 0);
            this.ucToolBar.Name = "ucToolBar";
            this.ucToolBar.NotSave = false;
            itemCommand1.Caption = "";
            itemCommand1.Enable = false;
            itemCommand1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Add = itemCommand1;
            itemCommand2.Caption = "";
            itemCommand2.Enable = false;
            itemCommand2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Cancel = itemCommand2;
            itemCommand3.Caption = "";
            itemCommand3.Enable = false;
            itemCommand3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Change = itemCommand3;
            itemCommand4.Caption = "";
            itemCommand4.Enable = false;
            itemCommand4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Close = itemCommand4;
            itemCommand5.Caption = "";
            itemCommand5.Enable = false;
            itemCommand5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Custom = itemCommand5;
            itemCommand6.Caption = "";
            itemCommand6.Enable = false;
            itemCommand6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Delete = itemCommand6;
            itemCommand7.Caption = "";
            itemCommand7.Enable = false;
            itemCommand7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Export = itemCommand7;
            itemCommand8.Caption = "";
            itemCommand8.Enable = false;
            itemCommand8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Filter = itemCommand8;
            itemCommand9.Caption = "";
            itemCommand9.Enable = false;
            itemCommand9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.FilterCustomer = itemCommand9;
            itemCommand10.Caption = "";
            itemCommand10.Enable = false;
            itemCommand10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.FilterStock = itemCommand10;
            itemCommand11.Caption = "";
            itemCommand11.Enable = false;
            itemCommand11.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Find = itemCommand11;
            menuButton1.GClose = false;
            menuButton1.GCommand = false;
            menuButton1.GExport = false;
            itemCommand12.Caption = "";
            itemCommand12.Enable = false;
            itemCommand12.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Go = itemCommand12;
            menuButton1.GOption = false;
            menuButton1.GPrint = false;
            menuButton1.GRecords = false;
            menuButton1.GSearchBar = false;
            menuButton1.GSettings = false;
            menuButton1.GVaildation = false;
            itemCommand13.Caption = "";
            itemCommand13.Enable = false;
            itemCommand13.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Import = itemCommand13;
            itemCommand14.Caption = "";
            itemCommand14.Enable = false;
            itemCommand14.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Next = itemCommand14;
            itemCommand15.Caption = "";
            itemCommand15.Enable = false;
            itemCommand15.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.PageSetup = itemCommand15;
            menuButton1.PHome = false;
            itemCommand16.Caption = "";
            itemCommand16.Enable = false;
            itemCommand16.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Previous = itemCommand16;
            itemCommand17.Caption = "";
            itemCommand17.Enable = false;
            itemCommand17.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Print = itemCommand17;
            itemCommand18.Caption = "";
            itemCommand18.Enable = false;
            itemCommand18.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.PrintPreview = itemCommand18;
            menuButton1.PTool = false;
            itemCommand19.Caption = "";
            itemCommand19.Enable = false;
            itemCommand19.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Redo = itemCommand19;
            itemCommand20.Caption = "";
            itemCommand20.Enable = false;
            itemCommand20.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Refresh = itemCommand20;
            itemCommand21.Caption = "";
            itemCommand21.Enable = false;
            itemCommand21.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Save = itemCommand21;
            itemCommand22.Caption = "";
            itemCommand22.Enable = false;
            itemCommand22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.SaveAndClose = itemCommand22;
            itemCommand23.Caption = "";
            itemCommand23.Enable = false;
            itemCommand23.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.SaveAndNew = itemCommand23;
            itemCommand24.Caption = "";
            itemCommand24.Enable = false;
            itemCommand24.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Search = itemCommand24;
            itemCommand25.Caption = "";
            itemCommand25.Enable = false;
            itemCommand25.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.SearchText = itemCommand25;
            itemCommand26.Caption = "";
            itemCommand26.Enable = false;
            itemCommand26.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Task = itemCommand26;
            itemCommand27.Caption = "";
            itemCommand27.Enable = false;
            itemCommand27.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Undo = itemCommand27;
            itemCommand28.Caption = "";
            itemCommand28.Enable = false;
            itemCommand28.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.Vaildate = itemCommand28;
            itemCommand29.Caption = "";
            itemCommand29.Enable = false;
            itemCommand29.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            menuButton1.View = itemCommand29;
            this.ucToolBar.RibbonBar = menuButton1;
            this.ucToolBar.Size = new System.Drawing.Size(761, 43);
            this.ucToolBar.Status = Vssoft.Common.Common.Class.Actions.Add;
            this.ucToolBar.TabIndex = 0;
            this.ucToolBar.Title = "";
            // 
            // gbList
            // 
            this.gbList.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gbList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gbList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gbList.GridControl = this.gcList;
            this.gbList.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gbList.IndicatorWidth = 45;
            this.gbList.Name = "gbList";
            this.gbList.OptionsPrint.ExpandAllDetails = true;
            this.gbList.OptionsPrint.PrintDetails = true;
            this.gbList.OptionsPrint.PrintFilterInfo = true;
            this.gbList.OptionsPrint.PrintPreview = true;
            this.gbList.OptionsSelection.InvertSelection = true;
            this.gbList.OptionsSelection.MultiSelect = true;
            this.gbList.OptionsView.ColumnAutoWidth = true;
            this.gbList.OptionsView.EnableAppearanceEvenRow = true;
            this.gbList.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gbList.OptionsView.ShowAutoFilterRow = true;
            this.gbList.OptionsView.ShowBands = false;
            this.gbList.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gbList.OptionsView.ShowDetailButtons = false;
            this.gbList.OptionsView.ShowGroupPanel = false;
            this.gbList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gbList_RowCellClick);
            this.gbList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gbList_CustomDrawRowIndicator);
            this.gbList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gbList_KeyDown);
            this.gbList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gbList_MouseDown);
            this.gbList.Click += new System.EventHandler(this.gbList_Click);
            this.gbList.DoubleClick += new System.EventHandler(this.gbList_DoubleClick);
            this.gbList.Layout += new System.EventHandler(this.gbList_Layout);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "DANH MỤC";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.ShowCaption = false;
            this.gridBand1.ToolTip = "DANH MỤC";
            this.gridBand1.VisibleIndex = 0;
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcList.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.gcList.Location = new System.Drawing.Point(0, 43);
            this.gcList.MainView = this.gbList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(761, 454);
            this.gcList.TabIndex = 10;
            this.gcList.UseEmbeddedNavigator = true;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gbList});
            // 
            // xucBaseBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcList);
            this.Controls.Add(this.ucToolBar);
            this.DoubleBuffered = true;
            this.Name = "xucBaseBasic";
            this.Size = new System.Drawing.Size(761, 497);
            ((System.ComponentModel.ISupportInitialize)(this.gbList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            this.ResumeLayout(false);

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
            new xfmReport("Danh Mục").ShowPrintPreview(this.gcList);
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
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
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
            if (!Directory.Exists(Application.StartupPath + @"\Layout"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Layout");
            }
            try
            {
                this.gbList.SaveLayoutToXml(Application.StartupPath + @"\Layout\" + name + ".xml");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Lỗi:\n\t" + exception.Message, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            if (base.ParentForm != null)
            {
                base.ParentForm.Close();
            }
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
            this.exportView = this.gbList;
            this.Export(this.gbList);
        }

        private void ucToolBar_HelpClick(object sender)
        {
            Process.Start("http://www.Vssoft.com.vn/huong-dan-su-dung-phan-mem-quan-ly-doanh-nghiep-perfect-erp.htm");
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

        public string Title
        {
            set
            {
                this._Title = value;
            }
        }
    }
}

