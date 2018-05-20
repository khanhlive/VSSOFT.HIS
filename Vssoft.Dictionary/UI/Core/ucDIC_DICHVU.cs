using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Forms;
using Vssoft.Common.Common.Class;
using Vssoft.Data.Enum;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Dictionary.UI.Core.Actions;

namespace Vssoft.Dictionary.UI.Core
{
    public class ucDIC_DICHVU : Common.xucBaseBasic
    {
        frmAddDIC_DICHVU frmAdd_dichvu;
        private object m_Dichvu = null;

        public event FocusedRowChangedEventHandler FocusedRowChanged;
        public ucDIC_DICHVU()
        {
            base.ucToolBar.SetInterface();
            this.gbList.FocusedRowChanged += new FocusedRowChangedEventHandler(this.gbList_FocusedRowChanged);
            
        }
        protected override void List_Init(AdvBandedGridView dt)
        {
            dt.OptionsView.ColumnAutoWidth = false;
            base.gbList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            GridBand band1 = null;
            foreach (GridBand band in dt.Bands)
            {
                if (band.Name == "band1")
                {
                    band1 = band;
                    break;
                }
            }
            if (band1 == null)
            {
                band1 = new GridBand();
                band1.Name = "band1";
                band1.Width = 350;
                band1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                dt.Bands.Add(band1);
            }
            else
            {
                band1.Columns.Clear();
            }
            
            RepositoryItemLookUpEdit lookup = new RepositoryItemLookUpEdit();
            new TrongDanhMuc().AddRepositoryLookupEdit(lookup);
            RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit();
            checkEdit.ValueChecked = 1;
            checkEdit.ValueUnchecked = 0;
            checkEdit.ValueGrayed= null;
            RepositoryItemLookUpEdit lookupTieunhom = new RepositoryItemLookUpEdit();
            using (DIC_TIEUNHOMDICHVU dic_tieunhomdichvu=new DIC_TIEUNHOMDICHVU())
            {
                dic_tieunhomdichvu.AddRepositoryLookupEdit(lookupTieunhom);
            }
            RepositoryItemLookUpEdit lookupNhom = new RepositoryItemLookUpEdit();
            using (DIC_NHOMDICHVU dic_nhom = new DIC_NHOMDICHVU())
            {
                dic_nhom.AddRepositoryLookupEdit(lookupNhom);
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].OptionsColumn.ReadOnly = true;
                dt.Columns[i].OptionsColumn.AllowEdit = false;
                dt.Columns[i].OptionsColumn.AllowGroup = DefaultBoolean.False;
                dt.Columns[i].OptionsColumn.FixedWidth = true;
                switch (dt.Columns[i].FieldName)
                {
                    case "MaDichVu":
                        {
                            if (band1 != null)
                                band1.Columns.Add(dt.Columns[i]);
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            dt.Columns[i].Caption = "Mã";
                            dt.Columns[i].Width = 50;
                            continue;
                        }
                    case "TenDichVu":
                        {
                            if (band1 != null)
                                band1.Columns.Add(dt.Columns[i]);
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            dt.Columns[i].Caption = "Tên dịch vụ";
                            dt.Columns[i].Width = 250;
                            continue;
                        }
                    case "DonViTinh":
                        {
                            if (band1 != null)
                                band1.Columns.Add(dt.Columns[i]);
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            dt.Columns[i].Caption = "Đơn vị tính";
                            dt.Columns[i].Width = 90;
                            continue;
                        }
                    case "TrongDanhMuc":
                        {
                            dt.Columns[i].Caption = "Trong danh mục";
                            dt.Columns[i].Width = 120;
                            dt.Columns[i].ColumnEdit = lookup;
                            continue;
                        }
                    case "BaoHiemThanhToan":
                        {
                            dt.Columns[i].Caption = "BHTT";
                            dt.Columns[i].Width = 55;
                            continue;
                        }
                    case "DichVuKyThuatCao":
                        {
                            dt.Columns[i].Caption = "Dịch vụ kỹ thuật cao";
                            dt.Columns[i].Width = 120;
                            dt.Columns[i].ColumnEdit = checkEdit;
                            continue;
                        }
                    case "MaTieuNhomDichVu":
                        {
                            dt.Columns[i].Caption = "Tiểu nhóm";
                            dt.Columns[i].Width = 150;
                            dt.Columns[i].ColumnEdit = lookupTieunhom;
                            continue;
                        }
                    case "MaQuyetDinh":
                        {
                            dt.Columns[i].Caption = "Mã quyết định";
                            dt.Columns[i].Width = 105;
                            continue;
                        }
                    case "TenRutGon":
                        {
                            dt.Columns[i].Caption = "Tên rút gọn";
                            dt.Columns[i].Width = 150;
                            continue;
                        }
                    case "SoThuTu":
                        {
                            dt.Columns[i].Caption = "STT";
                            dt.Columns[i].Width = 55;
                            continue;
                        }
                    case "SoThuTuQuyetDinh":
                        {
                            dt.Columns[i].Caption = "STT Quyết định";
                            dt.Columns[i].Width = 105;
                            continue;
                        }
                    case "MaNhom":
                        {
                            dt.Columns[i].Caption = "Nhóm";
                            dt.Columns[i].Width = 125;
                            dt.Columns[i].ColumnEdit = lookupNhom;
                            continue;
                        }
                    case "SoQuyetDinh":
                        {
                            dt.Columns[i].Caption = "Số quyết định";
                            dt.Columns[i].Width = 105;
                            continue;
                        }
                    case "Status":
                        {
                            dt.Columns[i].Caption = "Sử dụng";
                            dt.Columns[i].Width = 80;
                            dt.Columns[i].ColumnEdit = checkEdit;
                            continue;
                        }
                    case "DonGia":
                        {
                            dt.Columns[i].Caption = "Đơn giá";
                            dt.Columns[i].Width = 100;
                            dt.Columns[i].DisplayFormat.FormatString = "##,###";
                            dt.Columns[i].DisplayFormat.FormatType = FormatType.Custom;
                            continue;
                        }
                    case "DonGia2":
                        {
                            dt.Columns[i].Caption = "Đơn giá(TT37-2)";
                            dt.Columns[i].Width = 100;
                            dt.Columns[i].DisplayFormat.FormatString = "##,###";
                            dt.Columns[i].DisplayFormat.FormatType = FormatType.Custom;
                            continue;
                        }
                    case "DonGiaBHYT":
                        {
                            dt.Columns[i].Caption = "Đơn giá BHYT";
                            dt.Columns[i].Width = 100;
                            dt.Columns[i].DisplayFormat.FormatString = "##,###";
                            dt.Columns[i].DisplayFormat.FormatType = FormatType.Custom;
                            continue;
                        }
                    case "GiaDichVuDot2":
                        {
                            dt.Columns[i].Caption = "Đơn giá(đợt 2)";
                            dt.Columns[i].Width = 100;
                            dt.Columns[i].DisplayFormat.FormatString = "##,###";
                            dt.Columns[i].DisplayFormat.FormatType = FormatType.Custom;
                            continue;
                        }
                    case "DongiaT7":
                        {
                            dt.Columns[i].Caption = "Đơn giá T7";
                            dt.Columns[i].Width = 100;
                            dt.Columns[i].DisplayFormat.FormatString = "##,###";
                            dt.Columns[i].DisplayFormat.FormatType = FormatType.Custom;
                            continue;
                        }
                    case "MaTam":
                        {
                            dt.Columns[i].Caption = "Mã Quyết định";
                            dt.Columns[i].Width = 100;
                            dt.Columns[i].OptionsColumn.FixedWidth = true;
                            continue;
                        }

                }
                dt.Columns[i].Visible = false;
            }
        }

        private void RaiseAddedEventHander(object sender, DIC_DICHVU model)
        {
            
            this.ReLoad();
        }
        private void RaiseUpdatedEventHander(object sender, DIC_DICHVU model)
        {
            this.ReLoad();
        }
        protected override void Add()
        {
            this.frmAdd_dichvu = new frmAddDIC_DICHVU( Common.Common.Class.Actions.Add);
            this.frmAdd_dichvu.Added += new frmAddDIC_DICHVU.AddedEventHander(this.RaiseAddedEventHander);
            this.frmAdd_dichvu.ShowDialog();
        }

        public override void Change()
        {
            object keyModel = this.gbList.GetRow(this.gbList.FocusedRowHandle);
            if (keyModel != null)
            {
                this.frmAdd_dichvu = new frmAddDIC_DICHVU(Common.Common.Class.Actions.Update,(DIC_DICHVU)keyModel);
                this.frmAdd_dichvu.Updated += new frmAddDIC_DICHVU.UpdatedEventHander(this.RaiseUpdatedEventHander);
                this.frmAdd_dichvu.ShowDialog();
            }
        }
        public override void Delete()
        {
            if (this.m_Dichvu!=null)
            {
                DIC_DICHVU dichvu = (DIC_DICHVU)this.m_Dichvu;
                var flag = dichvu.Delete();
                if (flag== SqlResultType.OK)
                {
                    this.ReLoad();
                }
                else if(flag!= SqlResultType.None)
                {
                    XtraMessageBox.Show("Không xóa được dịch vụ này", "Xóa dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void gbList_MouseDown(object sender, MouseEventArgs e)
        {
            AdvBandedGridView view = (AdvBandedGridView)sender;
            var info = view.CalcHitInfo(e.X, e.Y);
            RowClickEventArgs args = new RowClickEventArgs((view == null) ? -1 : view.FocusedRowHandle, (view.FocusedColumn == null) ? -1 : view.FocusedColumn.ColumnHandle, (view.FocusedColumn == null) ? "" : view.FocusedColumn.FieldName);
            base.m_RowClickEventArgs = args;
            object cellValue = base.GetCellValue(args.RowIndex, "MaDichVu");
            base.DisableMenu(false);
            if (cellValue == null)
            {
                base.DisableMenu(true);
            }
        }

        protected virtual void gbList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.FocusedRowChanged?.Invoke(sender, e);
            this.m_Dichvu = this.gbList.GetRow(e.FocusedRowHandle);

            if (this.m_Dichvu == null)
            {
                this.DisableMenu(true);
            }
            else
            {
                this.DisableMenu(false);
            }
        }

        public override void ReLoad()
        {
            base.SetWaitDialogCaption("Đang nạp dữ liệu...");
            using (DIC_DICHVU duocProvider = new DIC_DICHVU())
            {
                base.gcList.DataSource = duocProvider.GetAllDichVu2(PhanLoaiDichVu.DichVu);
            }
            base.SetWaitDialogCaption("Đang nạp cấu hình...");
            this.List_Init(base.gbList);
            base.SetWaitDialogCaption("Nạp quyền sử dụng...");
            base.SetWaitDialogCaption("Đã xong...");
            this.DoHide();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucToolBar
            // 
            this.ucToolBar.Size = new System.Drawing.Size(1009, 43);
            // 
            // ucDIC_DICHVU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ucDIC_DICHVU";
            this.Size = new System.Drawing.Size(1009, 559);
            this.ResumeLayout(false);

        }
    }
}
