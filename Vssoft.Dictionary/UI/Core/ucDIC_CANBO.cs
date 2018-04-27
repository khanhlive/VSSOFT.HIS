using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using Vssoft.Common;
using Vssoft.Dictionary.UI.Core.Actions;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_CANBO : ucBaseBasicView
    {

        private ucAddEmployee addEmployee;
        public ucDIC_CANBO()
        {
            InitializeComponent();
            this.addEmployee = new ucAddEmployee();
            this.SetViewData(this.addEmployee);
        }

        private void ucCanBo_Load(object sender, EventArgs e)
        {
            
        }

        public override void ReLoad()
        {
            base.SetWaitDialogCaption("Đang nạp dữ liệu...");
            base.gcList.DataSource = this.GetList();
            base.SetWaitDialogCaption("Đang nạp cấu hình...");
            this.List_Init(base.gbList);
            base.SetWaitDialogCaption("Nạp quyền sử dụng...");
            base.SetWaitDialogCaption("Đã xong...");
            this.DoHide();
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemLookUpEdit lupGender = new RepositoryItemLookUpEdit();
            lupGender.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = "Text", Caption = "Gender" });
            lupGender.ShowHeader = false;
            lupGender.ValueMember = "Value";
            lupGender.DisplayMember = "Text";
            lupGender.DataSource = new List<object> { new { Value = "0", Text = "Nữ" }, new { Value = "1", Text = "Nam" } };
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].OptionsColumn.ReadOnly = true;
                dt.Columns[i].OptionsColumn.AllowEdit = false;
                //dt.Columns[i].OptionsColumn.FixedWidth = true;
                dt.Columns[i].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                switch (dt.Columns[i].FieldName)
                {
                    case "MaCB":
                        dt.Columns[i].Caption = "Mã cán bộ";
                        continue;
                    case "TenCB":
                        dt.Columns[i].Caption = "Họ tên";
                        continue;
                    case "TenKP":
                        dt.Columns[i].Caption = "Phòng ban";
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
                    case "SoDT":
                        dt.Columns[i].Caption = "Số điện thoại";
                        continue;
                    case "GioiTinh":
                        dt.Columns[i].Caption = "Giới tính";
                        dt.Columns[i].ColumnEdit = lupGender;
                        continue;
                    case "TenDT":
                        dt.Columns[i].Caption = "Dân tộc";
                        continue;
                    default:
                        break;
                }
                
                dt.Columns[i].Visible = false;
            }
        }
        
        private List<CanBo> GetList()
        {
            Data.Core.Ado.EmployeeProvider employeeProvider = new Data.Core.Ado.EmployeeProvider();
            return employeeProvider.GetAll();
        }
    }
}
