namespace Vssoft.Common
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
    using Vssoft.Common.Base;
    using Vssoft.Common.Common.Class;
    using Vssoft.Common.Report;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucBaseBasicD : xucBase
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

        public xucBaseBasicD()
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
            MenuButton button = new MenuButton();
            ItemCommand command = new ItemCommand();
            ItemCommand command2 = new ItemCommand();
            ItemCommand command3 = new ItemCommand();
            ItemCommand command4 = new ItemCommand();
            ItemCommand command5 = new ItemCommand();
            ItemCommand command6 = new ItemCommand();
            ItemCommand command7 = new ItemCommand();
            ItemCommand command8 = new ItemCommand();
            ItemCommand command9 = new ItemCommand();
            ItemCommand command10 = new ItemCommand();
            ItemCommand command11 = new ItemCommand();
            ItemCommand command12 = new ItemCommand();
            ItemCommand command13 = new ItemCommand();
            ItemCommand command14 = new ItemCommand();
            ItemCommand command15 = new ItemCommand();
            ItemCommand command16 = new ItemCommand();
            ItemCommand command17 = new ItemCommand();
            ItemCommand command18 = new ItemCommand();
            ItemCommand command19 = new ItemCommand();
            ItemCommand command20 = new ItemCommand();
            ItemCommand command21 = new ItemCommand();
            ItemCommand command22 = new ItemCommand();
            ItemCommand command23 = new ItemCommand();
            ItemCommand command24 = new ItemCommand();
            ItemCommand command25 = new ItemCommand();
            ItemCommand command26 = new ItemCommand();
            ItemCommand command27 = new ItemCommand();
            ItemCommand command28 = new ItemCommand();
            ItemCommand command29 = new ItemCommand();
            this.ucToolBar = new XucToolBar();
            this.gbList = new AdvBandedGridView();
            this.gridBand1 = new GridBand();
            this.gcList = new GridControl();
            this.gbList.BeginInit();
            this.gcList.BeginInit();
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
            this.ucToolBar.NotSave = false;
            command.Caption = "";
            command.Enable = false;
            command.Visibility = BarItemVisibility.Never;
            button.Add = command;
            command2.Caption = "";
            command2.Enable = false;
            command2.Visibility = BarItemVisibility.Never;
            button.Cancel = command2;
            command3.Caption = "";
            command3.Enable = false;
            command3.Visibility = BarItemVisibility.Never;
            button.Change = command3;
            command4.Caption = "";
            command4.Enable = false;
            command4.Visibility = BarItemVisibility.Never;
            button.Close = command4;
            command5.Caption = "";
            command5.Enable = false;
            command5.Visibility = BarItemVisibility.Never;
            button.Custom = command5;
            command6.Caption = "";
            command6.Enable = false;
            command6.Visibility = BarItemVisibility.Never;
            button.Delete = command6;
            command7.Caption = "";
            command7.Enable = false;
            command7.Visibility = BarItemVisibility.Never;
            button.Export = command7;
            command8.Caption = "";
            command8.Enable = false;
            command8.Visibility = BarItemVisibility.Never;
            button.Filter = command8;
            command9.Caption = "";
            command9.Enable = false;
            command9.Visibility = BarItemVisibility.Never;
            button.FilterCustomer = command9;
            command10.Caption = "";
            command10.Enable = false;
            command10.Visibility = BarItemVisibility.Never;
            button.FilterStock = command10;
            command11.Caption = "";
            command11.Enable = false;
            command11.Visibility = BarItemVisibility.Never;
            button.Find = command11;
            button.GClose = false;
            button.GCommand = false;
            button.GExport = false;
            command12.Caption = "";
            command12.Enable = false;
            command12.Visibility = BarItemVisibility.Never;
            button.Go = command12;
            button.GOption = false;
            button.GPrint = false;
            button.GRecords = false;
            button.GSearchBar = false;
            button.GSettings = false;
            button.GVaildation = false;
            command13.Caption = "";
            command13.Enable = false;
            command13.Visibility = BarItemVisibility.Never;
            button.Import = command13;
            command14.Caption = "";
            command14.Enable = false;
            command14.Visibility = BarItemVisibility.Never;
            button.Next = command14;
            command15.Caption = "";
            command15.Enable = false;
            command15.Visibility = BarItemVisibility.Never;
            button.PageSetup = command15;
            button.PHome = false;
            command16.Caption = "";
            command16.Enable = false;
            command16.Visibility = BarItemVisibility.Never;
            button.Previous = command16;
            command17.Caption = "";
            command17.Enable = false;
            command17.Visibility = BarItemVisibility.Never;
            button.Print = command17;
            command18.Caption = "";
            command18.Enable = false;
            command18.Visibility = BarItemVisibility.Never;
            button.PrintPreview = command18;
            button.PTool = false;
            command19.Caption = "";
            command19.Enable = false;
            command19.Visibility = BarItemVisibility.Never;
            button.Redo = command19;
            command20.Caption = "";
            command20.Enable = false;
            command20.Visibility = BarItemVisibility.Never;
            button.Refresh = command20;
            command21.Caption = "";
            command21.Enable = false;
            command21.Visibility = BarItemVisibility.Never;
            button.Save = command21;
            command22.Caption = "";
            command22.Enable = false;
            command22.Visibility = BarItemVisibility.Never;
            button.SaveAndClose = command22;
            command23.Caption = "";
            command23.Enable = false;
            command23.Visibility = BarItemVisibility.Never;
            button.SaveAndNew = command23;
            command24.Caption = "";
            command24.Enable = false;
            command24.Visibility = BarItemVisibility.Never;
            button.Search = command24;
            command25.Caption = "";
            command25.Enable = false;
            command25.Visibility = BarItemVisibility.Never;
            button.SearchText = command25;
            command26.Caption = "";
            command26.Enable = false;
            command26.Visibility = BarItemVisibility.Never;
            button.Task = command26;
            command27.Caption = "";
            command27.Enable = false;
            command27.Visibility = BarItemVisibility.Never;
            button.Undo = command27;
            command28.Caption = "";
            command28.Enable = false;
            command28.Visibility = BarItemVisibility.Never;
            button.Vaildate = command28;
            command29.Caption = "";
            command29.Enable = false;
            command29.Visibility = BarItemVisibility.Never;
            button.View = command29;
            this.ucToolBar.RibbonBar = button;
            this.ucToolBar.Size = new Size(0x2f9, 0x2b);
            this.ucToolBar.Status = Actions.Add;
            this.ucToolBar.TabIndex = 0;
            this.ucToolBar.Title = "";
            this.ucToolBar.Visible = false;
            this.gbList.Bands.AddRange(new GridBand[] { this.gridBand1 });
            this.gbList.BorderStyle = BorderStyles.NoBorder;
            this.gbList.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gbList.GridControl = this.gcList;
            this.gbList.GroupSummary.AddRange(new GridSummaryItem[] { new GridGroupSummaryItem(SummaryItemType.None, "", null, "") });
            this.gbList.IndicatorWidth = 0x2d;
            this.gbList.Name = "gbList";
            this.gbList.OptionsPrint.ExpandAllDetails = true;
            this.gbList.OptionsPrint.PrintDetails = true;
            this.gbList.OptionsPrint.PrintFilterInfo = true;
            this.gbList.OptionsPrint.PrintPreview = true;
            this.gbList.OptionsSelection.InvertSelection = true;
            this.gbList.OptionsSelection.MultiSelect = true;
            this.gbList.OptionsView.ColumnAutoWidth = true;
            this.gbList.OptionsView.EnableAppearanceEvenRow = true;
            this.gbList.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
            this.gbList.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.gbList.OptionsView.ShowBands = false;
            this.gbList.OptionsView.ShowDetailButtons = false;
            this.gbList.OptionsView.ShowGroupPanel = false;
            this.gbList.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
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
            this.gcList.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcList.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcList.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.gcList.Location = new Point(0, 0x2b);
            this.gcList.LookAndFeel.SkinName = "Office 2007 Black";
            this.gcList.MainView = this.gbList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new Size(0x2f9, 0x1c6);
            this.gcList.TabIndex = 10;
            this.gcList.UseEmbeddedNavigator = true;
            this.gcList.ViewCollection.AddRange(new BaseView[] { this.gbList });
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.gcList);
            base.Controls.Add(this.ucToolBar);
            this.DoubleBuffered = true;
            base.Name = "xucBaseBasicD";
            base.Size = new Size(0x2f9, 0x1f1);
            this.gbList.EndInit();
            this.gcList.EndInit();
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
            Process.Start("http://www.Vssoft.com.vn/huong-dan-su-dung-phan-mem-quan-ly-doanh-nghiep-Vssoft-erp.htm");
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

