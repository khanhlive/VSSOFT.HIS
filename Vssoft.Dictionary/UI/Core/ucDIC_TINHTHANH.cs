using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using Vssoft.Data.Core.Ado;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_TINHTHANH : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_TINHTHANH addDic_tinhthanh;

        public ucDIC_TINHTHANH()
        {
            this.addDic_tinhthanh= new Actions.ucAddDIC_TINHTHANH();
            InitializeComponent();
            this.SetViewData(this.addDic_tinhthanh);
        }
        
        protected override void SetDataSource()
        {
            ProvinceProvider specialtyProvider = new ProvinceProvider();
            this.dataSource = specialtyProvider.GetAll();
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
                    case "MaTinh":
                        dt.Columns[i].Caption = "Mã tỉnh";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenTinh":
                        dt.Columns[i].Caption = "Tên tỉnh";
                        //dt.Columns[i].Width = 50;
                        continue;
                    case "Status":
                        dt.Columns[i].Caption = "Sử dụng";
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
