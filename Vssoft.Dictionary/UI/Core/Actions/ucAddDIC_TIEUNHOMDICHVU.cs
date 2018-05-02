using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Common.Common.Class;

using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_TIEUNHOMDICHVU : ucBaseView
    {
        public ucAddDIC_TIEUNHOMDICHVU()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (DIC_NHOMDICHVU provider=new DIC_NHOMDICHVU())
            {
                lookupNhom.Properties.DataSource = provider.GetAllActive();
            }
        }

        public override void UpdateModel()
        {
            base.UpdateModel();
            this.txtID.ReadOnly = true;
        }

        public override void DisabledLayout(bool readOnly)
        {
            txtID.ReadOnly = readOnly;
            txtName.ReadOnly = readOnly;
            txtTenRutgon.ReadOnly = readOnly;
            lookupNhom.ReadOnly = readOnly;
            speOrder.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_TIEUNHOMDICHVU tieunhom = (DIC_TIEUNHOMDICHVU)this.Model;
            txtID.Text = tieunhom.MaTieuNhom.ToString();
            txtName.Text = tieunhom.TenTieuNhom;
            txtTenRutgon.Text = tieunhom.TenRutGon;
            lookupNhom.EditValue = tieunhom.MaNhom;
            speOrder.EditValue = tieunhom.STT;
            ckbStatus.Checked = tieunhom.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_TIEUNHOMDICHVU tieunhom = (DIC_TIEUNHOMDICHVU)this.Model;
                    SqlResultType resultType = new DIC_TIEUNHOMDICHVU().Delete(tieunhom);
                    if (resultType == SqlResultType.OK)
                    {
                        this.ClearModel();
                        this.DisabledLayout(true);
                    }
                    return resultType == SqlResultType.OK ? UserActionType.Success : UserActionType.Failed;
                }
                else return UserActionType.None;
            }
            return UserActionType.None;
        }

        public override void AddNew()
        {
            base.AddNew();
            txtID.ReadOnly = false;
        }

        public override object GetModel()
        {
            DIC_TIEUNHOMDICHVU tieunhom = new DIC_TIEUNHOMDICHVU();
            tieunhom.MaTieuNhom = DataConverter.StringToInt(txtID.EditValue as string);
            tieunhom.TenTieuNhom = txtName.Text;
            tieunhom.TenRutGon = txtTenRutgon.Text;
            tieunhom.MaNhom = DataConverter.ToInt(lookupNhom.EditValue as string);
            tieunhom.STT = DataConverter.ToByte(speOrder.EditValue.ToString());
            tieunhom.Status = ckbStatus.Checked ? 1 : 0;
            return tieunhom;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTenRutgon.Text = string.Empty;
            lookupNhom.EditValue = null;
            speOrder.EditValue = null;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_TIEUNHOMDICHVU tieunhom = (DIC_TIEUNHOMDICHVU)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new DIC_TIEUNHOMDICHVU().Insert(tieunhom);
                else flag = new DIC_TIEUNHOMDICHVU().Update(tieunhom);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = tieunhom;
                args.Action = this.actions;
                args.Message = "Không cập nhật được thông tin tiểu nhóm dịch vụ";
                this.SaveCompleteSuccess(tieunhom, args);
            }
            else
            {
                XtraMessageBox.Show("Thông tin chưa hợp lệ kiểm tra lại thông tin.");
            }
        }

        public override bool Validation()
        {
            this.isValidModel = true;
            this.Validate_EmptyStringRule(this.txtID);
            bool flag = this.txtID.DoValidate();
            if (!flag) this.isValidModel = false;
            this.Validate_EmptyStringRule(txtName);
            return this.isValidModel;
        }

        private void control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Validate_EmptyStringRule((BaseEdit)sender);
        }

        private void control_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.isEdited)
            {
                this.isEdited = true;
            }
        }
    }
}
