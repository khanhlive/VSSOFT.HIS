using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Windows.Forms;
using Vssoft.Data.Core.Ado;
using Vssoft.Dictionary.UI.Core.Actions;

namespace Vssoft.Dictionary.UI.Core
{
    public partial class ucDanToc : Common.ucBaseBasicView
    {
        private ucAddEthnic addEthnic;
        public ucDanToc()
        {
            this.addEthnic = new ucAddEthnic();
            InitializeComponent();
            this.SetViewData(this.addEthnic);
        }

        protected override void SetDataSource()
        {
            EthnicProvider nationProvider = new EthnicProvider();
            this.dataSource = nationProvider.GetAll();
        }

        protected override void gbList_MouseDown(object sender, MouseEventArgs e)
        {
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
                    case "MaDT":
                        dt.Columns[i].Caption = "Mã dân tộc";
                        continue;
                    case "TenDT":
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
