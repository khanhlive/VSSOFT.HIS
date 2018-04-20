namespace Vssoft.Common.Base
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using Vssoft.Common;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class XucBaseBasicC : xucBase
    {
        protected bool _search;
        private string _Title = "";
        private IContainer components = null;
        protected RowClickEventArgs MRowClickEventArgs = new RowClickEventArgs();
        protected Actions MStatus;
        protected XucToolBarC ucToolBar;

        public event ButtonClickEventHander CloseClick;

        public event ListKeyDownEventHander ListKeyDown;

        public event RowClickEventHander RowClick;

        public event RowClickEventHander RowDoubleClick;

        public XucBaseBasicC()
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
            this.Delete();
        }

        protected virtual void bbiDeleteAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Clear();
        }

        protected virtual void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Change();
        }

        protected virtual void bbiExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.Export();
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

        protected virtual void Clear()
        {
        }

        public virtual void Construct()
        {
        }

        protected virtual void Copy()
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

        protected virtual void EditUnitConvert()
        {
        }

        protected virtual void GroupChange()
        {
        }

        protected virtual void History()
        {
        }

        protected virtual void IdChanged()
        {
        }

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
            this.ucToolBar.HistoryClick += new ButtonClickEventHander(this.ucToolBar_HistoryClick);
            this.ucToolBar.GroupChanged += new ButtonClickEventHander(this.ucToolBar_GroupChanged);
            this.ucToolBar.StockChanged += new ButtonClickEventHander(this.ucToolBar_StockChanged);
            this.ucToolBar.MergeChanged += new ButtonClickEventHander(this.ucToolBar_MergeChanged);
            this.ucToolBar.IdChanged += new ButtonClickEventHander(this.ucToolBar_IdChanged);
            this.ucToolBar.EditUnitConvert += new ButtonClickEventHander(this.ucToolBar_EditUnitConvert);
            this.ReLoad();
            this.MStatus = Actions.None;
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
            this.ucToolBar = new XucToolBarC();
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
            this.ucToolBar.Size = new Size(0x2f9, 0x1a);
            this.ucToolBar.Status = Actions.Add;
            this.ucToolBar.TabIndex = 0;
            this.ucToolBar.Title = "";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.ucToolBar);
            this.DoubleBuffered = true;
            base.Name = "XucBaseBasicC";
            base.Size = new Size(0x2f9, 0x298);
            base.ResumeLayout(false);
        }

        protected virtual void ItemSelectd(RowClickEventArgs ex)
        {
        }

        protected virtual void List_Init(AdvBandedGridView dt)
        {
        }

        protected virtual void MergeChanged()
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

        private void RaiseListKeyDownEventHander(KeyEventArgs key, RowClickEventArgs e)
        {
            if (this.ListKeyDown != null)
            {
                this.ListKeyDown(this, key, e);
            }
        }

        private void RaiseRowClickEventHander(RowClickEventArgs e)
        {
            if (this.RowClick != null)
            {
                this.RowClick(this, e);
            }
        }

        private void RaiseRowDoubleClickEventHander(RowClickEventArgs e)
        {
            if (this.RowDoubleClick != null)
            {
                this.RowDoubleClick(this, e);
            }
        }

        public virtual void ReLoad()
        {
        }

        protected virtual void Search()
        {
            XtraMessageBox.Show("T\x00ednh năng n\x00e0y kh\x00f4ng được hỗ trợ!");
        }

        protected virtual void Select()
        {
        }

        protected virtual void SetMenu(RowClickEventArgs e)
        {
        }

        public virtual void SetSearch(RowClickEventArgs e)
        {
        }

        protected virtual void StockChange()
        {
        }

        private void ucToolBar_AddClick(object sender)
        {
            this.Add();
        }

        private void ucToolBar_ClearClick(object sender)
        {
            this.Clear();
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
            this.Copy();
        }

        private void ucToolBar_DeleteClick(object sender)
        {
            this.Delete();
        }

        private void ucToolBar_EditClick(object sender)
        {
            this.Change();
        }

        private void ucToolBar_EditUnitConvert(object sender)
        {
            this.EditUnitConvert();
        }

        private void ucToolBar_Export(object sender)
        {
            base.Export();
        }

        private void ucToolBar_GroupChanged(object sender)
        {
            this.GroupChange();
        }

        private void ucToolBar_HelpClick(object sender)
        {
            Process.Start("http://www.Vssoft.com.vn/huong-dan-su-dung-phan-mem-quan-ly-doanh-nghiep-perfect-erp.htm");
        }

        private void ucToolBar_HistoryClick(object sender)
        {
            this.History();
        }

        private void ucToolBar_IdChanged(object sender)
        {
            this.IdChanged();
        }

        private void ucToolBar_ImportClick(object sender)
        {
            this.Import();
        }

        private void ucToolBar_MergeChanged(object sender)
        {
            this.MergeChanged();
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

        private void ucToolBar_SelectClick(object sender)
        {
            this.Select();
        }

        private void ucToolBar_StockChanged(object sender)
        {
            this.StockChange();
        }

        protected virtual void UpdateRow(object Item, RowClickEventArgs e)
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

