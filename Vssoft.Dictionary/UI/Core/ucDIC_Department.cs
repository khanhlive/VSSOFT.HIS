using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.Core.Ado;
using Vssoft.Dictionary.UI.Core.Actions;

namespace Vssoft.Dictionary.UI.Core
{
    public class ucDIC_Department : Common.ucBaseBasicView
    {
        private ucAddDepartment addDepartment;

        public ucDIC_Department()
        {
            this.addDepartment = new ucAddDepartment();
            //InitializeComponent();
            this.SetViewData(this.addDepartment);
        }

        protected override void SetDataSource()
        {
            DepartmentProvider departmentProvider = new DepartmentProvider();
            this.dataSource = departmentProvider.GetAll();
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemCheckEdit ckbStatus = new RepositoryItemCheckEdit();
            ckbStatus.ValueChecked = 1;
            ckbStatus.ValueUnchecked = 0;
            ckbStatus.ValueGrayed = null;
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
                        dt.Columns[i].Caption = "Nhóm";
                        continue;
                    case "ChuyenKhoa":
                        dt.Columns[i].Caption = "Chuyên khoa";
                        continue;
                    case "PhanLoai":
                        dt.Columns[i].Caption = "Phân loại";
                        continue;
                    case "MaQuyetDinh":
                        dt.Columns[i].Caption = "Mã QĐ";
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
