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
    public partial class ucAddDIC_BENHVIEN : ucBaseView
    {
        public ucAddDIC_BENHVIEN()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            using (ProvinceProvider provinceProvider = new ProvinceProvider())
            {
                cmbTinh.Properties.DataSource = provinceProvider.GetAllActive();
            }
            using (DistrictProvider provider = new DistrictProvider())
            {
                cmbHuyen.Properties.DataSource = provider.GetAllActive();
            }
        }
        
        public override void UpdateModel()
        {
            base.UpdateModel();
            this.txtMaso.ReadOnly = true;
        }

        public override void DisabledLayout(bool readOnly)
        {
            txtMaso.ReadOnly = readOnly;
            txtName.ReadOnly = readOnly;
            txtDiachi.ReadOnly = readOnly;
            txtChuquan.ReadOnly = readOnly;
            txtLevel.ReadOnly = readOnly;
            txtTuyen.ReadOnly = readOnly;
            ckbConnect.ReadOnly = readOnly;
            cmbHuyen.ReadOnly = readOnly;
            cmbTinh.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_BENHVIEN benhvien = (DIC_BENHVIEN)this.Model;
            txtMaso.Text = benhvien.MaBenhVien.ToString();
            txtName.Text = benhvien.TenBenhVien;
            txtDiachi.Text = benhvien.DiaChi;
            cmbHuyen.EditValue= benhvien.MaHuyen;
            txtTuyen.EditValue= benhvien.TuyenBenhVien;
            txtLevel.SelectedIndex = benhvien.HangBenhVien;
            txtChuquan.Text = benhvien.MaChuQuan;
            ckbConnect.Checked= benhvien.Connect;
            cmbTinh.EditValue = benhvien.MaTinh;
            ckbStatus.Checked = benhvien.Status == 1;
            txtMaso.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_BENHVIEN benhvien = (DIC_BENHVIEN)this.Model;
                    SqlResultType resultType = new HospitalProvider().Delete(benhvien);
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
            txtMaso.ReadOnly = false;
        }

        public override object GetModel()
        {
            DIC_BENHVIEN benhvien = new DIC_BENHVIEN();
            benhvien.MaBenhVien = txtMaso.EditValue as string;
            benhvien.TenBenhVien = txtName.Text;
            benhvien.MaTinh = cmbTinh.EditValue as string;
            benhvien.MaHuyen = cmbHuyen.EditValue as string;
            benhvien.DiaChi = txtDiachi.Text;
            benhvien.TuyenBenhVien = txtTuyen.EditValue as string;
            benhvien.HangBenhVien= txtLevel.SelectedIndex;
            benhvien.Connect =ckbConnect.Checked;
            benhvien.Status = ckbStatus.Checked ? 1 : 0;
            benhvien.MaChuQuan= txtChuquan.EditValue as string;
            return benhvien;
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtMaso.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbTinh.EditValue = null;
            ckbStatus.CheckState = CheckState.Unchecked;
            txtDiachi.Text = string.Empty;
            cmbHuyen.EditValue = null;
            txtTuyen.EditValue =null;
            txtLevel.SelectedIndex = 0;
            txtChuquan.Text = string.Empty;
            ckbConnect.Checked = false;
            cmbTinh.EditValue = null;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_BENHVIEN benhvien = (DIC_BENHVIEN)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new HospitalProvider().Insert(benhvien);
                else flag = new HospitalProvider().Update(benhvien);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Action = this.actions;
                args.Model = benhvien;
                this.SaveCompleteSuccess(benhvien, args);
            }
            else
            {
                XtraMessageBox.Show("Thông tin chưa hợp lệ kiểm tra lại thông tin.");
            }
        }

        public override bool Validation()
        {
            this.isValidModel = true;
            this.Validate_EmptyStringRule(this.txtMaso);
            this.Validate_EmptyStringRule(this.cmbTinh);
            this.Validate_EmptyStringRule(this.cmbHuyen);
            bool flag2 = true;
            if (!string.IsNullOrEmpty(this.txtChuquan.Text) && !string.IsNullOrWhiteSpace(this.txtChuquan.Text))
            {
                flag2 = this.txtChuquan.DoValidate();
            }
            bool flag = this.txtMaso.DoValidate();
            if (!flag || !flag2) this.isValidModel = false;
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

        private void cmbTinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTinh.EditValue != null)
            {
                using (DistrictProvider provider = new DistrictProvider())
                {
                    cmbHuyen.Properties.DataSource = provider.GetAllHuyenbyTinh(cmbTinh.EditValue as string);
                }
            }
            else cmbHuyen.Properties.DataSource = null;



            this.control_EditValueChanged(sender, e);
        }
    }
}
