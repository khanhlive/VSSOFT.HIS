using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Common.Common.Class;

using Vssoft.Data.Enum;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_DANTOC : ucBaseView
    {
        public ucAddDIC_DANTOC()
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
            txtDescription.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_DANTOC dantoc = (DIC_DANTOC)this.Model;
            txtID.Text = dantoc.MaDanToc;
            txtName.Text = dantoc.TenDanToc;
            txtDescription.Text = dantoc.MoTa;
            ckbStatus.Checked = dantoc.Status == 1 ;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_DANTOC danToc = (DIC_DANTOC)this.Model;
                    SqlResultType resultType = new DIC_DANTOC().Delete(danToc);
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
            DIC_DANTOC danToc = new DIC_DANTOC();
            danToc.MaDanToc = txtID.EditValue.ToString();
            danToc.TenDanToc = txtName.Text;
            danToc.MoTa = txtDescription.Text;
            danToc.Status = ckbStatus.Checked ? 1 : 0;
            return danToc;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_DANTOC danToc = (DIC_DANTOC)this.GetModel();
                SqlResultType flag;
                if(this.actions== Common.Common.Class.Actions.AddNew) flag = new DIC_DANTOC().Insert(danToc);
                else flag = new DIC_DANTOC().Update(danToc);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag== SqlResultType.OK;
                args.Model = danToc;
                args.Action = this.actions;
                args.Message = "Không xóa được thông tin dân tộc";
                this.SaveCompleteSuccess(danToc, args);
            }
            else
            {
                XtraMessageBox.Show("Thông tin chưa hợp lệ kiểm tra lại thông tin.");
            }
        }

        public override bool Validation()
        {
            bool flag1 = this.Validate_EmptyStringRule(txtID);
            bool flag2 = this.Validate_EmptyStringRule(txtName);
            bool flag3 = this.txtID.DoValidate();
            
            if (flag1&&flag2&&flag3)
            {
                return true;
            }
            return false;
        }

        private void control_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.isEdited)
            {
                this.isEdited = true;
            }
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Validate_EmptyStringRule(txtName);
        }

        private void txtID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Validate_EmptyStringRule(txtID);
        }
    }
}
