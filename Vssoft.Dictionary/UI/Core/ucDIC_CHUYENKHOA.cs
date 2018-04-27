using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.Core.Ado;

namespace Vssoft.Dictionary.UI.Core
{

    /// <summary>
    /// DANH MỤC CHUYÊN KHOA
    /// </summary>
    public partial class ucDIC_CHUYENKHOA : Common.ucBaseBasicView
    {
        private Actions.ucAddDIC_CHUYENKHOA addSpecialty;
        public ucDIC_CHUYENKHOA()
        {
            this.addSpecialty = new Actions.ucAddDIC_CHUYENKHOA();
            InitializeComponent();
            this.SetViewData(this.addSpecialty);
        }
        protected override void SetDataSource()
        {
            SpecialtyProvider specialtyProvider = new SpecialtyProvider();
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
                    case "MaCK":
                        dt.Columns[i].Caption = "Mã chuyên khoa";
                        dt.Columns[i].Width = 20;
                        continue;
                    case "TenCK":
                        dt.Columns[i].Caption = "Tên chuyên khoa";
                        continue;
                    case "TenChiTiet":
                        dt.Columns[i].Caption = "Nội dung chi tiết";
                        continue;
                    case "MaQuyetDinh":
                        dt.Columns[i].Caption = "Mã quyết định";
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
