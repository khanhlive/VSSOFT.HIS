using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Common;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_HUYEN : ucBaseBasicView
    {
        private Actions.ucAddDIC_HUYEN addDic_huyen;

        public ucDIC_HUYEN()
        {
            this.addDic_huyen = new Actions.ucAddDIC_HUYEN();
            InitializeComponent();
            this.SetViewData(this.addDic_huyen);
        }
        
        protected override void SetDataSource()
        {
            DIC_HUYEN specialtyProvider = new DIC_HUYEN();
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
                    case "MaHuyen":
                        dt.Columns[i].Caption = "Mã huyện";
                        dt.Columns[i].Width = 20;
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
