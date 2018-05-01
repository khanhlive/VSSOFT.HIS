using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections.Generic;
using Vssoft.Common;
using Vssoft.Dictionary.UI.Core.Actions;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_CANBO : ucBaseBasicView
    {

        private ucAddDIC_CANBO addEmployee;
        IEnumerable<DIC_DANTOC> dantocs;
        IEnumerable<DIC_PHONGBAN> phongbans;
         
        public ucDIC_CANBO()
        {
            InitializeComponent();
            this.addEmployee = new ucAddDIC_CANBO();
            this.SetViewData(this.addEmployee);
            this.InitComponent();
        }
        protected override void InitComponent()
        {
            using (Data.Core.Ado.DepartmentProvider provider = new Data.Core.Ado.DepartmentProvider())
            {
                this.phongbans = provider.GetAll();
            }
            using (Data.Core.Ado.EthnicProvider provider = new Data.Core.Ado.EthnicProvider())
            {
                this.dantocs = provider.GetAll();
            }
            this.addEmployee.SetDataSource(this.phongbans);
            this.addEmployee.SetDataSource(this.dantocs);
        }
        protected override void SetDataSource()
        {
            using (Data.Core.Ado.EmployeeProvider employeeProvider = new Data.Core.Ado.EmployeeProvider())
            {
                this.dataSource = employeeProvider.GetAll();
            }
            
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemLookUpEdit lupGender = new RepositoryItemLookUpEdit();
            lupGender.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = "Text", Caption = "Gender" });
            lupGender.ShowHeader = false;
            lupGender.ValueMember = "Value";
            lupGender.DisplayMember = "Text";
            lupGender.DataSource = new List<object> { new { Value = "0", Text = "Nữ" }, new { Value = "1", Text = "Nam" } };
            //
            RepositoryItemLookUpEdit lookUpPhongban = new RepositoryItemLookUpEdit();
            lookUpPhongban.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = "TenPhongBan", Caption = "Tên phòng ban" });
            lookUpPhongban.ShowHeader = false;
            lookUpPhongban.ValueMember = "MaPhongBan";
            lookUpPhongban.DisplayMember = "TenPhongBan";
            lookUpPhongban.DataSource = this.phongbans;
            RepositoryItemLookUpEdit lookUpDantoc = new RepositoryItemLookUpEdit();
            lookUpDantoc.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = "TenDanToc", Caption = "Dân tộc" });
            lookUpDantoc.ShowHeader = false;
            lookUpDantoc.ValueMember = "MaDanToc";
            lookUpDantoc.DisplayMember = "TenDanToc";
            lookUpDantoc.DataSource = this.dantocs;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].OptionsColumn.ReadOnly = true;
                dt.Columns[i].OptionsColumn.AllowEdit = false;
                dt.Columns[i].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                switch (dt.Columns[i].FieldName)
                {
                    case "MaCanBo":
                        dt.Columns[i].Caption = "Mã cán bộ";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenCanBo":
                        dt.Columns[i].Caption = "Họ tên";
                        continue;
                    case "MaPhongBan":
                        dt.Columns[i].Caption = "Phòng ban";
                        dt.Columns[i].ColumnEdit = lookUpPhongban;
                        continue;
                    case "ChucVu":
                        dt.Columns[i].Caption = "Chức vụ";
                        continue;
                    case "CapBac":
                        dt.Columns[i].Caption = "Cấp bậc";
                        continue;
                    case "DiaChi":
                        dt.Columns[i].Caption = "Địa chỉ";
                        continue;
                    case "SoDienThoai":
                        dt.Columns[i].Caption = "Số điện thoại";
                        continue;
                    case "GioiTinh":
                        dt.Columns[i].Caption = "Giới tính";
                        dt.Columns[i].ColumnEdit = lupGender;
                        dt.Columns[i].Width = 20;
                        continue;
                    case "MaDanToc":
                        dt.Columns[i].Caption = "Dân tộc";
                        dt.Columns[i].ColumnEdit = lookUpDantoc;
                        continue;
                    default:
                        break;
                }
                
                dt.Columns[i].Visible = false;
            }
        }
        
        
    }
}
