using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Common.Common.Class;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_TINHTHANH : ucBaseView
    {
        public ucAddDIC_TINHTHANH()
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
            ckbStatus.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_TINH tinhthanh = (DIC_TINH)this.Model;
            txtID.Text = tinhthanh.MaTinh.ToString();
            txtName.Text = tinhthanh.TenTinh;
            ckbStatus.Checked = tinhthanh.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_TINH tinhthanh = (DIC_TINH)this.Model;
                    SqlResultType resultType = new ProvinceProvider().Delete(tinhthanh);
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
            DIC_TINH tinhthanh = new DIC_TINH();
            tinhthanh.MaTinh = txtID.EditValue as string;
            tinhthanh.TenTinh = txtName.Text;
            tinhthanh.Status = ckbStatus.Checked ? 1 : 0;
            return tinhthanh;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_TINH tinhthanh = (DIC_TINH)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new ProvinceProvider().Insert(tinhthanh);
                else flag = new ProvinceProvider().Update(tinhthanh);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = tinhthanh;
                args.Message = "Không lưu được thông tin tỉnh thành";
                this.SaveCompleteSuccess(tinhthanh, args);
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
