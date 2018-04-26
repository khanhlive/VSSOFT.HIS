using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.ERP.ERP;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_XAPHUONG : ucBaseView
    {
        public ucAddDIC_XAPHUONG()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (DistrictProvider provider=new DistrictProvider())
            {
                cmbDistrict.Properties.DataSource = provider.GetAllActive();
            }
            using (ProvinceProvider provider = new ProvinceProvider())
            {
                cmbProvince.Properties.DataSource = provider.GetAllActive();
            }
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
            cmbDistrict.ReadOnly = readOnly;
            cmbProvince.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        private void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_XAPHUONG xa = (DIC_XAPHUONG)this.Model;
            txtID.Text = xa.MaXa.ToString();
            txtName.Text = xa.TenXa;
            cmbDistrict.EditValue = xa.MaHuyen;
            cmbProvince.EditValue = xa.MaTinh;
            ckbStatus.Checked = xa.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override bool DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_XAPHUONG xa = (DIC_XAPHUONG)this.Model;
                    SqlResultType resultType = new RuralCommuneProvider().Delete(xa);
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
            DIC_XAPHUONG xa = new DIC_XAPHUONG();
            xa.MaXa = txtID.EditValue as string;
            xa.TenXa = txtName.Text;
            xa.MaHuyen = cmbDistrict.EditValue as string;
            xa.MaTinh = cmbProvince.EditValue as string;
            xa.Status = ckbStatus.Checked ? 1 : 0;
            return xa;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbDistrict.EditValue = null;
            cmbProvince.EditValue = null;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_XAPHUONG xa = (DIC_XAPHUONG)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new RuralCommuneProvider().Insert(xa);
                else flag = new RuralCommuneProvider().Update(xa);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = xa;
                args.Message = "Không lưu được thông tin xã phường";
                this.SaveCompleteSuccess(xa, args);
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
