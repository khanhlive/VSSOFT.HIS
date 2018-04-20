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

    public class XucBaseBasicB : xucBase
    {
        protected bool _search;
        private string _Title = "";
        private IContainer components = null;
        protected RowClickEventArgs MRowClickEventArgs = new RowClickEventArgs();
        protected Actions MStatus;
        protected XucToolBar ucToolBar;

        public event ButtonClickEventHander CloseClick;

        public event ListKeyDownEventHander ListKeyDown;

        public event RowClickEventHander RowClick;

        public event RowClickEventHander RowDoubleClick;

        public XucBaseBasicB()
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
            this.ucToolBar = new XucToolBar();
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
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.ucToolBar);
            this.DoubleBuffered = true;
            base.Name = "XucBaseBasicB";
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

