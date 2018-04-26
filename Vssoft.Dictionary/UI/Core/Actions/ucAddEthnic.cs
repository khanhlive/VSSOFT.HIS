using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddEthnic : ucBaseView
    {
        public ucAddEthnic()
        {
            InitializeComponent();
        }
        
        public override void SetModel(object model)
        {
            this.Model = model;
            if (this.Model == null)
            {
                this.ClearModel();
            }
            else
            {
                BindingModel();
            }
            this.Update();
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

        private void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DanToc dantoc = (DanToc)this.Model;
            txtID.Text = dantoc.MaDT;
            txtName.Text = dantoc.TenDT;
            txtDescription.Text = dantoc.MoTa;
            ckbStatus.Checked = dantoc.Status == 1 ;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override bool DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DanToc danToc = (DanToc)this.Model;
                    SqlResultType resultType = new EthnicProvider().Delete(danToc);
                    if (resultType == SqlResultType.OK)
                    {
                        this.ClearModel();
                        this.DisabledLayout(true);
                    }
                    return resultType == SqlResultType.OK;
                }
            }
            return false;
        }

        public override void AddNew()
        {
            base.AddNew();
            txtID.ReadOnly = false;
        }

        public override object GetModel()
        {
            DanToc danToc = new DanToc();
            danToc.MaDT = txtID.EditValue.ToString();
            danToc.TenDT = txtName.Text;
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
                DanToc danToc = (DanToc)this.GetModel();
                SqlResultType flag;
                if(this.actions== Common.Common.Class.Actions.AddNew) flag = new EthnicProvider().Insert(danToc);
                else flag = new EthnicProvider().Update(danToc);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag== SqlResultType.OK;
                args.Model = danToc;
                args.Message = "Không lưu được thông tin dân tộc";
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
