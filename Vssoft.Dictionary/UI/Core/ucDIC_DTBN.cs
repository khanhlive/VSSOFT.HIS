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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_DTBN : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_DTBN dic_dtbn;
        public ucDIC_DTBN()
        {
            this.dic_dtbn = new Actions.ucAddDIC_DTBN();
            InitializeComponent();
            this.SetViewData(this.dic_dtbn);
        }

        protected override void SetDataSource()
        {
            PatientObjectProvider patientObjectProvider = new PatientObjectProvider();
            this.dataSource = patientObjectProvider.GetAll();
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
                    case "IDDTBN":
                        dt.Columns[i].Caption = "Mã đối tượng";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenDTBN":
                        dt.Columns[i].Caption = "Tên đối tượng";
                        continue;
                    case "MoTa":
                        dt.Columns[i].Caption = "Mô tả";
                        continue;
                    case "HinhThucThanhToan":
                        dt.Columns[i].Caption = "Hình thức thanh toán";
                        continue;
                    case "Status":
                        dt.Columns[i].Caption = "Sử dụng";
                        //dt.Columns[i].OptionsColumn.= DevExpress.Utils.HorzAlignment.Center;
                        dt.Columns[i].Width = 20;
                        dt.Columns[i].ColumnEdit = ckbStatus;
                        continue;
                    default:
                        break;
                }

                dt.Columns[i].Visible = false;
            }
        }
    }
}
