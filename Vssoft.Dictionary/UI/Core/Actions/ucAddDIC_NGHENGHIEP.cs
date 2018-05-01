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
using Vssoft.Common.Common.Class;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using DevExpress.XtraEditors;
using Vssoft.Common;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_NGHENGHIEP : Common.ucBaseView
    {
        public ucAddDIC_NGHENGHIEP()
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
            txtMota.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_NGHENGHIEP nghenghiep = (DIC_NGHENGHIEP)this.Model;
            txtID.Text = nghenghiep.MaNgheNghiep.ToString();
            txtName.Text = nghenghiep.TenNgheNghiep;
            txtMota.Text= nghenghiep.MoTa;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_NGHENGHIEP nghenghiep = (DIC_NGHENGHIEP)this.Model;
                    SqlResultType resultType = new JobProvider().Delete(nghenghiep);
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
            DIC_NGHENGHIEP nghenghiep = new DIC_NGHENGHIEP();
            nghenghiep.MaNgheNghiep = txtID.EditValue as string;
            nghenghiep.TenNgheNghiep = txtName.Text;
            nghenghiep.MoTa = txtMota.Text;
            return nghenghiep;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMota.Text= string.Empty;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_NGHENGHIEP nghenghiep = (DIC_NGHENGHIEP)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new JobProvider().Insert(nghenghiep);
                else flag = new JobProvider().Update(nghenghiep);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = nghenghiep;
                args.Action = this.actions;
                args.Message = "Không xóa được thông tin nghề nghiệp";
                this.SaveCompleteSuccess(nghenghiep, args);
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
