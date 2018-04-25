using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Common;
using Vssoft.Data.Core.Ado;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_BENHVIEN : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_BENHVIEN addDic_benhvien;

        public ucDIC_BENHVIEN()
        {
            this.addDic_benhvien = new Actions.ucAddDIC_BENHVIEN();
            InitializeComponent();
            this.SetViewData(this.addDic_benhvien);
        }

        protected override void SetDataSource()
        {
            HospitalProvider hospitalProvider = new HospitalProvider();
            this.dataSource = hospitalProvider.GetAll();
        }

        protected override void List_Init(AdvBandedGridView dt)
        {
            RepositoryItemCheckEdit ckbStatus = new RepositoryItemCheckEdit();
            RepositoryItemCheckEdit ckbConnect = new RepositoryItemCheckEdit();
            RepositoryItemLookUpEdit lookUpEditHuyen = new RepositoryItemLookUpEdit();
            lookUpEditHuyen.ValueMember = "MaHuyen";
            lookUpEditHuyen.DisplayMember = "TenHuyen";
            lookUpEditHuyen.ShowHeader = false;
            lookUpEditHuyen.DropDownRows = 12;
            using (DistrictProvider provider=new DistrictProvider())
            {
                lookUpEditHuyen.DataSource = provider.GetAll();
            }
            RepositoryItemLookUpEdit lookUpEditTinh = new RepositoryItemLookUpEdit();
            lookUpEditTinh.ValueMember = "MaTinh";
            lookUpEditTinh.DisplayMember = "TenTinh";
            lookUpEditTinh.ShowHeader = false;
            lookUpEditTinh.DropDownRows = 12;
            using (ProvinceProvider provider = new ProvinceProvider())
            {
                lookUpEditTinh.DataSource = provider.GetAll();
            }
            ckbConnect.ValueChecked = true;
            ckbConnect.ValueUnchecked = false;
            
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
                    case "MaBenhVien":
                        dt.Columns[i].Caption = "Mã bệnh viện";
                        dt.Columns[i].Width = 25;
                        continue;
                    case "TenBenhVien":
                        dt.Columns[i].Caption = "Tên bệnh viện";
                        continue;
                    case "MaChuQuan":
                        dt.Columns[i].Caption = "Mã chủ quản";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TuyenBenhVien":
                        dt.Columns[i].Caption = "Tuyến";
                        dt.Columns[i].Width = 15;
                        continue;
                    case "HangBenhVien":
                        dt.Columns[i].Caption = "Hạng";
                        dt.Columns[i].Width = 15;
                        continue;
                    case "MaHuyen":
                        dt.Columns[i].Caption = "Tên huyện";
                        dt.Columns[i].ColumnEdit = lookUpEditHuyen;
                        continue;
                    case "MaTinh":
                        dt.Columns[i].Caption = "Tên tỉnh";
                        dt.Columns[i].ColumnEdit = lookUpEditTinh;
                        continue;
                    case "DiaChi":
                        dt.Columns[i].Caption = "Địa chỉ";
                        continue;
                    case "Connect":
                        dt.Columns[i].Caption = "Đã kết nối";
                        dt.Columns[i].ColumnEdit = ckbConnect;
                        dt.Columns[i].Width = 20;
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
