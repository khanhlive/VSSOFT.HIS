using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using Vssoft.Data.Core.Ado;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_ICD10 : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_ICD10 addDIC_ICD;

        public ucDIC_ICD10()
        {
            this.addDIC_ICD = new Actions.ucAddDIC_ICD10();
            InitializeComponent();
            this.SetViewData(this.addDIC_ICD);
        }

        protected override void SetDataSource()
        {
            using (ICD10Provider hospitalProvider = new ICD10Provider())
            {
                this.dataSource = hospitalProvider.GetAll();
            }
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
                    case "MaICD":
                        dt.Columns[i].Caption = "Mã";
                        dt.Columns[i].Width = 25;
                        continue;
                    case "TenICD":
                        dt.Columns[i].Caption = "Tên bệnh";
                        continue;
                    case "MaChuongBenh":
                        dt.Columns[i].Caption = "Mã chương bệnh";
                        continue;
                    case "TenChuongBenh":
                        dt.Columns[i].Caption = "Tên chương bệnh";
                        continue;
                    case "TenWHO":
                        dt.Columns[i].Caption = "Tên WHO(Tiếng Việt)";
                        continue;
                    case "TenWHOe":
                        dt.Columns[i].Caption = "Tên WHO(Tiếng Anh)";
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
