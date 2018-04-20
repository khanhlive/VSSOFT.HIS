using System;
using System.Windows.Forms;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddEmployee : Common.ucBaseView
    {
        private bool isUpdated = false;

        public ucAddEmployee()
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

        public override object GetModel()
        {
            CanBo canbo = new CanBo();
            canbo.MaCB = txtID.Text;
            canbo.TenCB = txtName.Text;
            canbo.NgaySinh = txtDate.DateTime;
            canbo.GioiTinh = rdgGender.SelectedIndex == 1 ? 0 : 1;
            canbo.MaKP = DataConverter.ToInt(cmbDepartment.EditValue.ToString());
            canbo.MaDT = cmbEthnic.EditValue.ToString();
            canbo.ChucVu = txtPosition.Text;
            canbo.CapBac = txtRank.Text;
            canbo.Khoa = ckbLock.Checked ? 1 : 0;
            canbo.KhoaChungTu = ckbLock.Checked;
            canbo.SoDT = txtPhone.Text;
            canbo.DiaChi = txtAddress.Text;
            canbo.BangCap = txtCertificate.Text;
            return canbo;
        }

        protected override void Init()
        {
            DepartmentProvider departmentProvider = new DepartmentProvider();
            EthnicProvider nationProvider = new EthnicProvider();
            cmbDepartment.Properties.DataSource = departmentProvider.GetAllActive();
            cmbDepartment.Properties.ValueMember = "MaKP";
            cmbDepartment.Properties.DisplayMember = "TenKP";
            cmbEthnic.Properties.DataSource = nationProvider.GetAllActive();
            cmbEthnic.Properties.ValueMember = "MaDT";
            cmbEthnic.Properties.DisplayMember = "TenDT";
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
            txtDate.ReadOnly = readOnly;
            rdgGender.ReadOnly = readOnly;
            cmbDepartment.ReadOnly = readOnly;
            cmbEthnic.ReadOnly = readOnly;
            txtPosition.ReadOnly = readOnly;
            txtRank.ReadOnly = readOnly;
            ckbLock.ReadOnly = readOnly;
            txtPhone.ReadOnly = readOnly;
            txtAddress.ReadOnly = readOnly;
            txtCertificate.ReadOnly = readOnly;
        }

        private void BindingModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            CanBo canbo = (CanBo)this.Model;
            txtID.Text = canbo.MaCB;
            txtName.Text = canbo.TenCB;
            txtDate.DateTime = DateTime.Now ;
            rdgGender.SelectedIndex = canbo.GioiTinh == 1 ? 0 : 1;
            cmbDepartment.EditValue= canbo.MaKP;
            cmbEthnic.EditValue= canbo.MaDT;
            txtPosition.Text = canbo.ChucVu;
            txtRank.Text = canbo.CapBac;
            ckbLock.CheckState= canbo.Khoa==1? CheckState.Checked: CheckState.Unchecked;
            txtPhone.Text = canbo.SoDT;
            txtAddress.Text = canbo.DiaChi;
            txtCertificate.Text = canbo.BangCap;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override void AddNew()
        {
            base.AddNew();
            txtID.ReadOnly = false;
        }

        public override void ClearModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDate.DateTime = DateTime.Now;
            rdgGender.SelectedIndex = 1;
            cmbDepartment.EditValue = null;
            cmbEthnic.EditValue = null;
            txtPosition.Text = string.Empty;
            txtRank.Text = string.Empty;
            ckbLock.CheckState = CheckState.Unchecked;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCertificate.Text = string.Empty;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            base.SaveModel();
            MessageBox.Show("Test");
        }

        public override bool Validation()
        {
            dxErrorProvider1.SetError(txtID, "String not empty");
            return base.Validation();
        }

        private void txtID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.isEdited)
            {
                this.isEdited = true;
            }
        }
    }
}
