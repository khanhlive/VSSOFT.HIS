using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Data.ERP.Dictionary;
using DevExpress.XtraEditors;
using Vssoft.Data.Enum;

using Vssoft.Common;
using Vssoft.Common.Common.Class;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_ICD10 : Common.ucBaseView
    {
        public ucAddDIC_ICD10()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
            txtMaChuongBenh.ReadOnly = readOnly;
            txtTenChuongBenh.ReadOnly = readOnly;
            txtTenWHO.ReadOnly = readOnly;
            txtTenWHOe.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_ICD10 icd10 = (DIC_ICD10)this.Model;
            txtID.Text = icd10.MaICD;
            txtName.Text = icd10.TenICD;
            txtMaChuongBenh.Text = icd10.MaChuongBenh;
            txtTenChuongBenh.Text = icd10.TenChuongBenh;
            txtTenWHO.Text = icd10.TenWHO;
            txtTenWHOe.Text = icd10.TenWHOe;
            ckbStatus.Checked = icd10.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_ICD10 icd10 = (DIC_ICD10)this.Model;
                    SqlResultType resultType = new DIC_ICD10().Delete(icd10);
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
            DIC_ICD10 icd10 = new DIC_ICD10();
            icd10.MaICD = txtID.Text;
            icd10.TenICD = txtName.Text;
            icd10.MaChuongBenh = txtMaChuongBenh.Text;
            icd10.TenChuongBenh = txtTenChuongBenh.Text;
            icd10.TenWHO = txtTenWHO.Text;
            icd10.TenWHOe = txtTenWHOe.Text;
            icd10.Status = ckbStatus.Checked ? 1 : 0;
            return icd10;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMaChuongBenh.Text = string.Empty;
            txtTenChuongBenh.Text = string.Empty;
            txtTenWHO.Text = string.Empty;
            txtTenWHOe.Text = string.Empty;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_ICD10 icd10 = (DIC_ICD10)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new DIC_ICD10().Insert(icd10);
                else flag = new DIC_ICD10().Update(icd10);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = icd10;
                args.Action = this.actions;
                args.Message = "Không lưu được thông tin ICD";
                this.SaveCompleteSuccess(icd10, args);
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
            this.Validate_EmptyStringRule(txtMaChuongBenh);
            bool flag2 = this.txtMaChuongBenh.DoValidate();
            if (!flag2) this.isValidModel = false;
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
