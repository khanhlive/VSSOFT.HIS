namespace Perfect.Dictionary
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using Vssoft.Common;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Vssoft.ERP;

    public class xucPosition : xucBaseBasic
    {
        private IContainer components = null;

        public xucPosition()
        {
            this.InitializeComponent();
            base.ucToolBar.SetInterface();
        }

        protected override void Add()
        {
            //if (MyRule.Get(MyLogin.RoleId, "bbiPosition") == "OK")
            //{
            //    if (!MyRule.AllowAdd)
            //    {
            //        MyRule.Notify();
            //    }
            //    else
            //    {
            //        xfmPositionAdd add = new xfmPositionAdd(Actions.Add);
            //        add.Added += new xfmPositionAdd.AddedEventHander(this.frm_Added);
            //        add.ShowDialog();
            //    }
            //}
        }

        private void AddRow(DIC_POSITION Item)
        {
            AdvBandedGridView gbList = base.gbList;
            int focusedRowHandle = gbList.FocusedRowHandle;
            gbList.AddNewRow();
            focusedRowHandle = gbList.FocusedRowHandle;
            gbList.SetRowCellValue(focusedRowHandle, "Active", Item.Active);
            gbList.SetRowCellValue(focusedRowHandle, "PositionCode", Item.PositionCode);
            gbList.SetRowCellValue(focusedRowHandle, "PositionName", Item.PositionName);
            gbList.SetRowCellValue(focusedRowHandle, "IsManager", Item.IsManager);
            gbList.SetRowCellValue(focusedRowHandle, "Description", Item.Description);
            gbList.UpdateCurrentRow();
        }

        public override void Change()
        {
            //if (MyRule.Get(MyLogin.RoleId, "bbiPosition") == "OK")
            //{
            //    if (!MyRule.AllowAccess)
            //    {
            //        MyRule.Notify();
            //    }
            //    else
            //    {
            //        DIC_POSITION item = new DIC_POSITION();
            //        object cellValue = base.GetCellValue(base.m_RowClickEventArgs.RowIndex, "PositionCode");
            //        if (cellValue != null)
            //        {
            //            base.SetWaitDialogCaption("Đang kiểm tra dữ liệu....");
            //            if (item.Get(cellValue.ToString()) != "OK")
            //            {
            //                this.DoHide();
            //                XtraMessageBox.Show("Dữ liệu kh\x00f4ng tồn tại", "Th\x00f4ng B\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            }
            //            else
            //            {
            //                this.DoHide();
            //                xfmPositionAdd add = new xfmPositionAdd(Actions.Update, item);
            //                add.Updated += new xfmPositionAdd.UpdatedEventHander(this.frm_Updated);
            //                add.Added += new xfmPositionAdd.AddedEventHander(this.frm_Added);
            //                add.ShowDialog();
            //            }
            //        }
            //    }
            //}
        }

        public override void Delete()
        {
            //if (MyRule.Get(MyLogin.RoleId, "bbiPosition") == "OK")
            //{
            //    if (!MyRule.AllowDelete)
            //    {
            //        MyRule.Notify();
            //    }
            //    else if (!ClsOption.System2.IsQuestion || (XtraMessageBox.Show("Bạn c\x00f3 muốn x\x00f3a kh\x00f4ng?", "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No))
            //    {
            //        object cellValue;
            //        base.SetWaitDialogCaption("Đang x\x00f3a...");
            //        string str = "";
            //        bool flag = false;
            //        AdvBandedGridView gbList = base.gbList;
            //        int[] selectedRows = gbList.GetSelectedRows();
            //        DIC_POSITION dic_position = new DIC_POSITION();
            //        for (int i = selectedRows.Length; i > 0; i--)
            //        {
            //            flag = true;
            //            cellValue = base.GetCellValue(selectedRows[i - 1], "PositionCode");
            //            if (cellValue != null)
            //            {
            //                SYS_LOG.Insert("Danh Mục Chức Vụ", "Xo\x00e1", cellValue.ToString());
            //                str = dic_position.Delete(cellValue.ToString());
            //                if (str == "OK")
            //                {
            //                    gbList.DeleteRow(selectedRows[i - 1]);
            //                }
            //                else if (str != "OK")
            //                {
            //                    MessageBox.Show("Th\x00f4ng tin kh\x00f4ng được x\x00f3a\n" + str, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //                }
            //            }
            //        }
            //        this.DoHide();
            //        if (!flag && (gbList.DataSource != null))
            //        {
            //            RowClickEventArgs args = new RowClickEventArgs((gbList == null) ? -1 : gbList.FocusedRowHandle, (gbList.FocusedColumn == null) ? -1 : gbList.FocusedColumn.ColumnHandle, (gbList.FocusedColumn == null) ? "" : gbList.FocusedColumn.FieldName);
            //            base.m_RowClickEventArgs = args;
            //            cellValue = null;
            //            cellValue = base.GetCellValue(args.RowIndex, "PositionCode");
            //            if (cellValue != null)
            //            {
            //                SYS_LOG.Insert("Danh Mục Chức Vụ", "Xo\x00e1", cellValue.ToString());
            //                base.SetWaitDialogCaption("Đang x\x00f3a...");
            //                str = dic_position.Delete(cellValue.ToString());
            //                if (str == "OK")
            //                {
            //                    gbList.DeleteRow(args.RowIndex);
            //                }
            //                else if (str != "OK")
            //                {
            //                    MessageBox.Show("Th\x00f4ng tin kh\x00f4ng được x\x00f3a\n" + str, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //                }
            //                this.DoHide();
            //            }
            //        }
            //    }
            //}
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override bool ExportPermision()
        {
            //if (MyRule.Get(MyLogin.RoleId, "bbiPosition") != "OK")
            //{
            //    return false;
            //}
            //if (!MyRule.AllowExport)
            //{
            //    MyRule.Notify();
            //    return false;
            //}
            //SYS_LOG.Insert("Danh Mục Chức Vụ", "Xuất");
            return base.ExportPermision();
        }

        //private void frm_Added(object sender, DIC_POSITION e)
        //{
        //    this.AddRow(e);
        //}

        //private void frm_Updated(object sender, DIC_POSITION Item)
        //{
        //    this.UpdateRow(Item, base.m_RowClickEventArgs);
        //}

        protected override void gbList_MouseDown(object sender, MouseEventArgs e)
        {
            AdvBandedGridView view = (AdvBandedGridView) sender;
            var info = view.CalcHitInfo(e.X, e.Y);
            
            RowClickEventArgs args = new RowClickEventArgs((view == null) ? -1 : view.FocusedRowHandle, (view.FocusedColumn == null) ? -1 : view.FocusedColumn.ColumnHandle, (view.FocusedColumn == null) ? "" : view.FocusedColumn.FieldName);
            base.m_RowClickEventArgs = args;
            object cellValue = base.GetCellValue(args.RowIndex, "PositionCode");
            base.DisableMenu(false);
            if (cellValue == null)
            {
                base.DisableMenu(true);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucToolBar
            // 
            this.ucToolBar.Size = new System.Drawing.Size(1040, 43);
            // 
            // xucPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "xucPosition";
            this.Size = new System.Drawing.Size(1040, 547);
            this.ResumeLayout(false);

        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                switch (dt.Columns[i].FieldName)
                {
                    case "PositionCode":
                        {
                            dt.Columns[i].OptionsColumn.ReadOnly = true;
                            dt.Columns[i].OptionsColumn.AllowEdit = false;
                            dt.Columns[i].OptionsColumn.AllowGroup = DefaultBoolean.False;
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            if (true)//SysOption.Language == "VN")
                            {
                                dt.Columns[i].Caption = "Ma";// MultiLanguages.GetString("tbl_FormBasic", "ID", "M\x00e3");
                            }
                            dt.Columns[i].Width = 60;
                            continue;
                        }
                    case "PositionName":
                        {
                            dt.Columns[i].OptionsColumn.ReadOnly = true;
                            dt.Columns[i].OptionsColumn.AllowEdit = false;
                            dt.Columns[i].OptionsColumn.AllowGroup = DefaultBoolean.False;
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            if (true)//SysOption.Language == "VN")
                            {
                                dt.Columns[i].Caption = "Chuc danh";// MultiLanguages.GetString("tbl_FormBasic", "Name", "Chức danh");
                            }
                            dt.Columns[i].Width = 180;
                            continue;
                        }
                    case "IsManager":
                        {
                            dt.Columns[i].OptionsColumn.ReadOnly = true;
                            dt.Columns[i].OptionsColumn.AllowEdit = false;
                            dt.Columns[i].OptionsColumn.AllowGroup = DefaultBoolean.False;
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            if (true)//SysOption.Language == "VN")
                            {
                                dt.Columns[i].Caption = "Cap quan ly";// MultiLanguages.GetString("tbl_FormBasic", "Manager", "Cấp quản l\x00fd");
                            }
                            dt.Columns[i].Width = 180;
                            continue;
                        }
                    case "Description":
                        {
                            dt.Columns[i].OptionsColumn.ReadOnly = true;
                            dt.Columns[i].OptionsColumn.AllowEdit = false;
                            dt.Columns[i].OptionsColumn.AllowGroup = DefaultBoolean.False;
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            if (true)//SysOption.Language == "VN")
                            {
                                dt.Columns[i].Caption = "Ghi chu";// MultiLanguages.GetString("tbl_FormBasic", "Description", "Ghi ch\x00fa");
                            }
                            dt.Columns[i].Width = 150;
                            continue;
                        }
                }
                dt.Columns[i].Visible = false;
            }
        }

        protected override void Print()
        {
            //if (MyRule.Get(MyLogin.RoleId, "bbiPosition") == "OK")
            //{
            //    if (!MyRule.AllowPrint)
            //    {
            //        MyRule.Notify();
            //    }
            //    else
            //    {
            //        SYS_LOG.Insert("Danh Mục Chức Vụ", "In");
            //        base.Print();
            //    }
            //}
        }

        public override void ReLoad()
        {
            base.SetWaitDialogCaption("Đang nạp dữ liệu...");
            base.gcList.DataSource = new DIC_POSITION().GetList();
            base.SetWaitDialogCaption("Đang nạp cấu h\x00ecnh...");
            this.List_Init(base.gbList);
            base.SetWaitDialogCaption("Nạp quyền sử dụng...");
            //MyRule.Get(MyLogin.RoleId, "bbiPosition");
            //if (!MyRule.AllowPrint)
            //{
            //    base.ucToolBar.bbiPrint.Visibility = BarItemVisibility.Never;
            //}
            //MyRule.Get(MyLogin.RoleId, "bbiPosition");
            //if (!MyRule.AllowExport)
            //{
            //    base.ucToolBar.bbiExport.Visibility = BarItemVisibility.Never;
            //}
            //MyRule.Get(MyLogin.RoleId, "bbiPosition");
            //if (!MyRule.AllowAdd)
            //{
            //    base.ucToolBar.bbiAdd.Visibility = BarItemVisibility.Never;
            //}
            //MyRule.Get(MyLogin.RoleId, "bbiPosition");
            //if (!MyRule.AllowDelete)
            //{
            //    base.ucToolBar.bbiDelete.Visibility = BarItemVisibility.Never;
            //}
            //MyRule.Get(MyLogin.RoleId, "bbiPosition");
            //if (!MyRule.AllowEdit)
            //{
            //    base.ucToolBar.bbiEdit.Visibility = BarItemVisibility.Never;
            //}
            base.SetWaitDialogCaption("Đ\x00e3 xong...");
            this.DoHide();
        }

        private void UpdateRow(DIC_POSITION item, RowClickEventArgs e)
        {
            AdvBandedGridView gbList = base.gbList;
            int rowIndex = e.RowIndex;
            gbList.SetRowCellValue(rowIndex, "Active", item.Active);
            gbList.SetRowCellValue(rowIndex, "PositionCode", item.PositionCode);
            gbList.SetRowCellValue(rowIndex, "PositionName", item.PositionName);
            gbList.SetRowCellValue(rowIndex, "IsManager", item.IsManager);
            gbList.SetRowCellValue(rowIndex, "Description", item.Description);
            gbList.UpdateCurrentRow();
        }
    }
}

