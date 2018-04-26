using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.ERP.ERP;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_HUYEN : ucBaseView
    {
        public ucAddDIC_HUYEN()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            using (ProvinceProvider provinceProvider = new ProvinceProvider())
            {
                cmbProvince.Properties.DataSource = provinceProvider.GetAllActive();
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
            cmbProvince.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        private void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_HUYEN huyen = (DIC_HUYEN)this.Model;
            txtID.Text = huyen.MaHuyen.ToString();
            txtName.Text = huyen.TenHuyen;
            cmbProvince.EditValue = huyen.MaTinh;
            ckbStatus.Checked = huyen.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override bool DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_HUYEN tinhthanh = (DIC_HUYEN)this.Model;
                    SqlResultType resultType = new DistrictProvider().Delete(tinhthanh);
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
            DIC_HUYEN huyen = new DIC_HUYEN();
            huyen.MaHuyen = txtID.EditValue as string;
            huyen.TenHuyen = txtName.Text;
            huyen.MaTinh = cmbProvince.EditValue as string;
            huyen.Status = ckbStatus.Checked ? 1 : 0;
            return huyen;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbProvince.EditValue = null;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_HUYEN huyen = (DIC_HUYEN)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new DistrictProvider().Insert(huyen);
                else flag = new DistrictProvider().Update(huyen);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = huyen;
                args.Message = "Không lưu được thông tin huyện";
                this.SaveCompleteSuccess(huyen, args);
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
