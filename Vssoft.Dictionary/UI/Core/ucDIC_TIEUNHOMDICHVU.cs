using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_TIEUNHOMDICHVU : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_TIEUNHOMDICHVU dic_tieunhomdichvu;

        public ucDIC_TIEUNHOMDICHVU()
        {
            this.dic_tieunhomdichvu = new Actions.ucAddDIC_TIEUNHOMDICHVU();
            InitializeComponent();
            this.SetViewData(this.dic_tieunhomdichvu);
        }

        protected override void SetDataSource()
        {
            DIC_TIEUNHOMDICHVU provider = new DIC_TIEUNHOMDICHVU();
            this.dataSource = provider.GetAll();
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemCheckEdit ckbStatus = new RepositoryItemCheckEdit();
            RepositoryItemLookUpEdit lookUpEditHuyen = new RepositoryItemLookUpEdit();
            lookUpEditHuyen.ValueMember = "MaNhom";
            lookUpEditHuyen.DisplayMember = "TenNhom";
            lookUpEditHuyen.ShowHeader = false;
            lookUpEditHuyen.DropDownRows = 12;
            lookUpEditHuyen.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = "TenNhom", Caption = "Tên nhóm" });
            using (DIC_NHOMDICHVU provider = new DIC_NHOMDICHVU())
            {
                lookUpEditHuyen.DataSource = provider.GetAll();
            }

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
                    case "MaTieuNhom":
                        dt.Columns[i].Caption = "Mã tiểu nhóm";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenTieuNhom":
                        dt.Columns[i].Caption = "Tên tiểu nhóm";
                        continue;
                    case "MaNhom":
                        dt.Columns[i].Caption = "Nhóm";
                        dt.Columns[i].ColumnEdit = lookUpEditHuyen;
                        continue;
                    case "TenRutGon":
                        dt.Columns[i].Caption = "Tên rút gọn";
                        continue;
                    case "STT":
                        dt.Columns[i].Caption = "Thứ tự";
                        dt.Columns[i].Width = 15;
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
