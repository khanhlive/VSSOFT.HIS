using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Data.Core.Ado;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.Enum;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_NHOMDICHVU : Common.ucBaseBasicView
    {
        private List<LookUpEditItem> phanloais;
        private Actions.ucAddDIC_NHOMDICHVU addDic_nhomdichvu;

        public ucDIC_NHOMDICHVU()
        {
            this.addDic_nhomdichvu = new Actions.ucAddDIC_NHOMDICHVU();
            InitializeComponent();
            this.SetViewData(this.addDic_nhomdichvu);
            this.phanloais = new List<LookUpEditItem>();
            this.phanloais.Add(new LookUpEditItem(0, "Không sử dụng"));
            this.phanloais.Add(new LookUpEditItem(1, "Dược"));
            this.phanloais.Add(new LookUpEditItem(2, "Tài sản"));
        }

        protected override void SetDataSource()
        {
            NhomDichVuProvider nhomDichVuProvider = new NhomDichVuProvider();
            this.dataSource = nhomDichVuProvider.GetAll();
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemLookUpEdit lookEdit = new RepositoryItemLookUpEdit();
            lookEdit.ValueMember = "Value";
            lookEdit.DisplayMember = "Text";
            lookEdit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text"));
            lookEdit.ShowHeader = false;
            lookEdit.DataSource = this.phanloais;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].OptionsColumn.ReadOnly = true;
                dt.Columns[i].OptionsColumn.AllowEdit = false;
                dt.Columns[i].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                switch (dt.Columns[i].FieldName)
                {
                    case "MaNhom":
                        dt.Columns[i].Caption = "Mã nhóm";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenNhom":
                        dt.Columns[i].Caption = "Tên nhóm";
                        continue;
                    case "TenNhomChiTiet":
                        dt.Columns[i].Caption = "Mô tả";
                        continue;
                    case "STT":
                        dt.Columns[i].Caption = "Thứ tự";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "Status":
                        dt.Columns[i].Caption = "Phân loại";
                        dt.Columns[i].Width = 20;
                        dt.Columns[i].ColumnEdit = lookEdit;
                        continue;
                    default:
                        break;
                }

                dt.Columns[i].Visible = false;
            }
        }
    }
}
