using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using Vssoft.Data.Core.Ado;
using Vssoft.Dictionary.UI.Core.Actions;

namespace Vssoft.Dictionary.UI.Core
{
    public class ucDIC_DoiTuong : Common.ucBaseBasicView
    {
        private ucAdd_Doituong add_Doituong;
        public ucDIC_DoiTuong()
        {
            this.add_Doituong = new ucAdd_Doituong();
            //InitializeComponent();
            this.SetViewData(this.add_Doituong);
        }
        protected override void SetDataSource()
        {
            ObjectProvider objectProvider = new ObjectProvider();
            this.dataSource = objectProvider.GetAll();
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
                    case "MaDoiTuong":
                        dt.Columns[i].Caption = "Mã";
                        dt.Columns[i].Width = 20;
                        dt.Columns[i].VisibleIndex = 0;
                        continue;
                    case "TenDoiTuong":
                        dt.Columns[i].Caption = "Tên";
                        dt.Columns[i].VisibleIndex = 1;
                        continue;
                    case "NhomDoiTuong":
                        dt.Columns[i].Caption = "Nhóm";
                        dt.Columns[i].VisibleIndex = 2;
                        dt.Columns[i].Width = 40;
                        continue;
                    case "VanChuyen":
                        dt.Columns[i].Caption = "Hưởng vận chuyển";
                        dt.Columns[i].VisibleIndex = 3;
                        dt.Columns[i].ColumnEdit = ckbStatus;
                        dt.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        dt.Columns[i].Width = 20;
                        continue;
                    case "MaMuc":
                        dt.Columns[i].Caption = "Mức hưởng";
                        dt.Columns[i].VisibleIndex = 4;
                        dt.Columns[i].Width = 20;
                        continue;
                    case "MucCu":
                        dt.Columns[i].Caption = "Mức cũ";
                        dt.Columns[i].VisibleIndex = 5;
                        dt.Columns[i].Width = 20;
                        continue;
                    case "Status":
                        dt.Columns[i].Caption = "Sử dụng";
                        dt.Columns[i].VisibleIndex = 9;
                        dt.Columns[i].ColumnEdit = ckbStatus;
                        dt.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        dt.Columns[i].Width = 20;
                        continue;
                    default:
                        break;
                }
                dt.Columns[i].Visible = false;
            }
        }
    }
}
