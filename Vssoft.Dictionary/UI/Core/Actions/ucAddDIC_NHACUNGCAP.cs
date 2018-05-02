using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Common.Common.Class;

using Vssoft.Data.Enum;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_NHACUNGCAP : Common.ucBaseView
    {
        public ucAddDIC_NHACUNGCAP()
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
            txtDiachi.ReadOnly = readOnly;
            txtDienthoai.ReadOnly = readOnly;
            txtNguoiDaiDien.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_NHACUNGCAP nhacungcap = (DIC_NHACUNGCAP)this.Model;
            txtID.Text = nhacungcap.MaNhaCungCap;
            txtName.Text = nhacungcap.TenNhaCungCap;
            txtDiachi.Text= nhacungcap.DiaChi;
            txtDienthoai.Text = nhacungcap.DienThoai;
            txtNguoiDaiDien.Text = nhacungcap.NguoiDaiDien;
            ckbStatus.Checked = nhacungcap.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_NHACUNGCAP nhacungcap = (DIC_NHACUNGCAP)this.Model;
                    SqlResultType resultType = new DIC_NHACUNGCAP().Delete(nhacungcap);
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
            DIC_NHACUNGCAP nhacungcap = new DIC_NHACUNGCAP();
            nhacungcap.DiaChi = txtDiachi.Text;
            nhacungcap.DienThoai = txtDienthoai.Text;
            nhacungcap.NguoiDaiDien = txtNguoiDaiDien.Text;
            nhacungcap.TenNhaCungCap = txtName.Text;
            nhacungcap.MaNhaCungCap = txtID.EditValue as string;
            nhacungcap.Status = ckbStatus.Checked ? 1 : 0;
            return nhacungcap;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDiachi.Text = string.Empty;
            txtDienthoai.Text = string.Empty;
            txtNguoiDaiDien.Text = string.Empty;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_NHACUNGCAP nhacungcap = (DIC_NHACUNGCAP)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new DIC_NHACUNGCAP().Insert(nhacungcap);
                else flag = new DIC_NHACUNGCAP().Update(nhacungcap);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = nhacungcap;
                args.Action = this.actions;
                this.SaveCompleteSuccess(nhacungcap, args);
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
            if (!this.txtID.DoValidate()) this.isValidModel = false;
            this.Validate_EmptyStringRule(txtName);
            if (!string.IsNullOrEmpty(txtDienthoai.Text))
                if (!this.txtDienthoai.DoValidate())
                    this.isValidModel = false;
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
