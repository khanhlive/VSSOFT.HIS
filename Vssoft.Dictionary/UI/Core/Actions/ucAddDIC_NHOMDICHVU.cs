using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Common.Common.Class;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_NHOMDICHVU : ucBaseView
    {
        public ucAddDIC_NHOMDICHVU()
        {
            InitializeComponent();
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
            txtDetail.ReadOnly = readOnly;
            speOrder.ReadOnly = readOnly;
            cmbPhanLoai.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_NHOMDICHVU nhom = (DIC_NHOMDICHVU)this.Model;
            txtID.Text = nhom.MaNhom.ToString();
            txtName.Text = nhom.TenNhom;
            txtDetail.Text = nhom.TenNhomChiTiet;
            speOrder.EditValue = nhom.STT;
            cmbPhanLoai.SelectedIndex = nhom.Status;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_NHOMDICHVU nhom = (DIC_NHOMDICHVU)this.Model;
                    SqlResultType resultType = new NhomDichVuProvider().Delete(nhom);
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
            DIC_NHOMDICHVU nhom = new DIC_NHOMDICHVU();
            nhom.MaNhom = DataConverter.StringToInt(txtID.EditValue as string);
            nhom.TenNhom = txtName.Text;
            nhom.TenNhomChiTiet = txtDetail.Text;
            nhom.STT = DataConverter.ToInt(speOrder.EditValue.ToString());
            nhom.Status = cmbPhanLoai.SelectedIndex;
            return nhom;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDetail.Text = string.Empty;
            speOrder.EditValue = null;
            cmbPhanLoai.SelectedIndex = 0;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_NHOMDICHVU nhom = (DIC_NHOMDICHVU)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new NhomDichVuProvider().Insert(nhom);
                else flag = new NhomDichVuProvider().Update(nhom);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = nhom;
                args.Action = this.actions;
                args.Message = "Không cập nhật được thông tin nhóm dịch vụ";
                this.SaveCompleteSuccess(nhom, args);
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
