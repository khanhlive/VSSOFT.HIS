using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.ERP.ERP;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_DTBN : Common.ucBaseView
    {
        public ucAddDIC_DTBN()
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
            cmbFormPayment.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        private void BindingModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            DIC_DTBN doituongbenhnhan = (DIC_DTBN)this.Model;
            txtID.Text = doituongbenhnhan.IDDTBN.ToString();
            txtName.Text = doituongbenhnhan.TenDTBN;
            txtDescription.Text = doituongbenhnhan.MoTa;
            cmbFormPayment.SelectedIndex = doituongbenhnhan.HinhThucThanhToan;
            ckbStatus.Checked = doituongbenhnhan.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override bool DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_DTBN doituongbenhnhan = (DIC_DTBN)this.Model;
                    SqlResultType resultType = new PatientObjectProvider().Delete(doituongbenhnhan);
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
            DIC_DTBN doituongbenhnhan = new DIC_DTBN();
            doituongbenhnhan.IDDTBN = Convert.ToByte(txtID.EditValue);
            doituongbenhnhan.TenDTBN = txtName.Text;
            doituongbenhnhan.MoTa= txtDescription.Text;
            doituongbenhnhan.HinhThucThanhToan= (byte)cmbFormPayment.SelectedIndex;
            doituongbenhnhan.Status = ckbStatus.Checked ? 1 : 0;
            return doituongbenhnhan;
        }

        public override void ClearModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbFormPayment.SelectedIndex= 0;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_DTBN doituongbenhnhan = (DIC_DTBN)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new PatientObjectProvider().Insert(doituongbenhnhan);
                else flag = new PatientObjectProvider().Update(doituongbenhnhan);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = doituongbenhnhan;
                args.Message = "Không lưu được thông tin đối tượng bệnh nhân";
                this.SaveCompleteSuccess(doituongbenhnhan, args);
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
            //this.Validate_EmptyStringRule(txtCode);
            //bool flag2 = this.txtCode.DoValidate();
            //if (!flag2) this.isValidModel = false;
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

        private void ucAddDIC_DTBN_Load(object sender, EventArgs e)
        {
            foreach (var item in new HinhThucThanhToan().GetList())
            {
                cmbFormPayment.Properties.Items.Add(item.Name);
            }
        }
    }
}
