using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Dictionary.UI.Core.Actions;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_NGHENGHIEP : Common.ucBaseBasicView
    {
        private ucAddDIC_NGHENGHIEP dic_nghenghiep;
        public ucDIC_NGHENGHIEP()
        {
            this.dic_nghenghiep = new ucAddDIC_NGHENGHIEP();
            InitializeComponent();
            this.SetViewData(this.dic_nghenghiep);
        }

        protected override void SetDataSource()
        {
            using (DIC_NGHENGHIEP jobProvider = new DIC_NGHENGHIEP())
            {
                this.dataSource = jobProvider.GetAll();
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
                    case "MaNgheNghiep":
                        dt.Columns[i].Caption = "Mã";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenNgheNghiep":
                        dt.Columns[i].Caption = "Tên nghề nghiệp";
                        continue;
                    case "MoTa":
                        dt.Columns[i].Caption = "Ghi chú";
                        continue;
                    default:
                        break;
                }

                dt.Columns[i].Visible = false;
            }
        }
    }
}
