using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.Core.Ado;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_NHACUNGCAP : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_NHACUNGCAP addDic_nhacungcap;

        public ucDIC_NHACUNGCAP()
        {
            this.addDic_nhacungcap = new Actions.ucAddDIC_NHACUNGCAP();
            InitializeComponent();
            this.SetViewData(this.addDic_nhacungcap);
        }

        protected override void SetDataSource()
        {
            PupplierProvider pupplierProvider = new PupplierProvider();
            this.dataSource = pupplierProvider.GetAll();
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
                    case "MaNhaCungCap":
                        dt.Columns[i].Caption = "Mã";
                        dt.Columns[i].Width = 25;
                        continue;
                    case "TenNhaCungCap":
                        dt.Columns[i].Caption = "Tên nhà cung cấp";
                        continue;
                    case "DienThoai":
                        dt.Columns[i].Caption = "Điện thoại";
                        continue;
                    case "DiaChi":
                        dt.Columns[i].Caption = "Địa chỉ";
                        continue;
                    case "NguoiDaiDien":
                        dt.Columns[i].Caption = "Người đại diện";
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
