using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Windows.Forms;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Dictionary.UI.Core.Actions;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDIC_DANTOC : Common.ucBaseBasicView
    {
        private ucAddDIC_DANTOC addEthnic;
        public ucDIC_DANTOC()
        {
            this.addEthnic = new ucAddDIC_DANTOC();
            InitializeComponent();
            this.SetViewData(this.addEthnic);
        }

        protected override void SetDataSource()
        {
            DIC_DANTOC nationProvider = new DIC_DANTOC();
            this.dataSource = nationProvider.GetAll();
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
                    case "MaDanToc":
                        dt.Columns[i].Caption = "Mã dân tộc";
                        continue;
                    case "TenDanToc":
                        dt.Columns[i].Caption = "Tên dân tộc";
                        continue;
                    case "MoTa":
                        dt.Columns[i].Caption = "Ghi chú";
                        continue;
                    case "Status":
                        dt.Columns[i].Caption = "Sử dụng";
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
