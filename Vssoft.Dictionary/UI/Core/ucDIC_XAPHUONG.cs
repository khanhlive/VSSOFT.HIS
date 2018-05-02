using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Common;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_XAPHUONG : ucBaseBasicView
    {
        private Actions.ucAddDIC_XAPHUONG addDic_xaphuong;

        public ucDIC_XAPHUONG()
        {
            this.addDic_xaphuong = new Actions.ucAddDIC_XAPHUONG();
            InitializeComponent();
            this.SetViewData(this.addDic_xaphuong);
        }
        
        protected override void SetDataSource()
        {
            using (DIC_XAPHUONG specialtyProvider = new DIC_XAPHUONG())
            {
                this.dataSource = specialtyProvider.GetAll();
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
                    case "MaXa":
                        dt.Columns[i].Caption = "Mã xã";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenXa":
                        dt.Columns[i].Caption = "Tên xã";
                        continue;
                    case "TenHuyen":
                        dt.Columns[i].Caption = "Tên huyện";
                        continue;
                    case "TenTinh":
                        dt.Columns[i].Caption = "Tên tỉnh";
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
