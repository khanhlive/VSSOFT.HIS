using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections.Generic;
using System.Linq;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.Dictionary.UI.Core.Actions;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core
{
    public class ucDIC_PHONGBAN : Common.ucBaseBasicView
    {
        private ucAddDIC_PHONGBAN addDepartment;

        public ucDIC_PHONGBAN()
        {
            this.addDepartment = new ucAddDIC_PHONGBAN();
            this.SetViewData(this.addDepartment);
        }

        protected override void SetDataSource()
        {
            using (DepartmentProvider departmentProvider = new DepartmentProvider())
            {
                
                this.dataSource = departmentProvider.GetAll();
            }
            
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemCheckEdit ckbStatus = new RepositoryItemCheckEdit();
            RepositoryItemLookUpEdit lookEdit = new RepositoryItemLookUpEdit();
            lookEdit.ValueMember = "MaPhongBan";
            lookEdit.DisplayMember = "TenPhongBan";
            lookEdit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenPhongBan", "Tên phòng ban"));
            lookEdit.ShowHeader = false;
            using (DepartmentProvider departmentProvider = new DepartmentProvider())
            {
                List<DIC_PHONGBAN> phongban = new List<DIC_PHONGBAN>();
                phongban.Add(new DIC_PHONGBAN { MaPhongBan = 0, TenPhongBan = "Không" });
                phongban.AddRange(departmentProvider.GetAllActive().Where(p => p.PhanLoai == LoaiPhongBan.PhongBan[0] || p.PhanLoai == LoaiPhongBan.PhongBan[3]).ToList());
                lookEdit.DataSource = phongban;
            }
            ckbStatus.ValueChecked = 1;
            ckbStatus.ValueUnchecked = 0;
            ckbStatus.ValueGrayed = null;
            //chuyen khoa
            RepositoryItemLookUpEdit lookEditChuyenkhoa = new RepositoryItemLookUpEdit();
            lookEditChuyenkhoa.ValueMember = "MaChuyenKhoa";
            lookEditChuyenkhoa.DisplayMember = "TenChuyenKhoa";
            lookEditChuyenkhoa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChuyenKhoa", "Tên chuyên khoa"));
            lookEditChuyenkhoa.ShowHeader = false;
            using (SpecialtyProvider specialtyProvider=new SpecialtyProvider())
            {
                lookEditChuyenkhoa.DataSource = specialtyProvider.GetAll();
            }

            //benh vien
            RepositoryItemLookUpEdit lookEditBenhvien = new RepositoryItemLookUpEdit();
            lookEditBenhvien.ValueMember = "MaBenhVien";
            lookEditBenhvien.DisplayMember = "TenBenhVien";
            lookEditBenhvien.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenBenhVien", "Tên bệnh viện"));
            lookEditBenhvien.ShowHeader = false;
            using (HospitalProvider hospitalProvider = new HospitalProvider())
            {
                lookEditBenhvien.DataSource = hospitalProvider.GetAll();
            }
            //phân loại
            RepositoryItemLookUpEdit lookEditphanloai = new RepositoryItemLookUpEdit();
            lookEditphanloai.ValueMember = "ID";
            lookEditphanloai.DisplayMember = "PhanLoai";
            lookEditphanloai.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PhanLoai", "Tên"));
            lookEditphanloai.ShowHeader = false;
            using (PhanLoaiPhongBanProvider provider= new PhanLoaiPhongBanProvider())
            {
                lookEditphanloai.DataSource = provider.GetAll();
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].OptionsColumn.ReadOnly = true;
                dt.Columns[i].OptionsColumn.AllowEdit = false;
                dt.Columns[i].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                switch (dt.Columns[i].FieldName)
                {
                    case "MaPhongBan":
                        dt.Columns[i].Caption = "Mã";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenPhongBan":
                        dt.Columns[i].Caption = "Tên";
                        continue;
                    case "NhomPhongBan":
                        dt.Columns[i].Caption = "Nhóm phòng";
                        dt.Columns[i].ColumnEdit = lookEdit;
                        continue;
                    case "MaChuyenKhoa":
                        dt.Columns[i].Caption = "Chuyên khoa";
                        dt.Columns[i].ColumnEdit = lookEditChuyenkhoa;
                        continue;
                    case "PhanLoai_ID":
                        dt.Columns[i].Caption = "Phân loại";
                        dt.Columns[i].ColumnEdit = lookEditphanloai;
                        continue;
                    case "TrongBenhVien":
                        dt.Columns[i].Caption = "Trong bệnh viện";
                        dt.Columns[i].ColumnEdit = ckbStatus;
                        dt.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        dt.Columns[i].Width = 35;
                        continue;
                    case "DiaChi":
                        dt.Columns[i].Caption = "Địa chỉ";
                        continue;
                    case "MaBenhVien":
                        dt.Columns[i].Caption = "Đơn vị";
                        dt.Columns[i].ColumnEdit = lookEditBenhvien;
                        continue;
                    case "Status":
                        dt.Columns[i].Caption = "Sử dụng";
                        dt.Columns[i].ColumnEdit = ckbStatus;
                        dt.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        dt.Columns[i].Width = 20;
                        continue;
                    default:
                        break;
                }
                dt.Columns[i].Visible = false;
            }
        }
    }
}
