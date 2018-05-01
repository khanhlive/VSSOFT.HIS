using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class ucAddDIC_CANBO : Common.ucBaseView
    {
        private IEnumerable<DIC_PHONGBAN> phongbans;
        private IEnumerable<DIC_DANTOC> dantocs;
        public ucAddDIC_CANBO()
        {
            InitializeComponent();
        }
        public void SetDataSource(IEnumerable<DIC_PHONGBAN> enumerable)
        {
            this.phongbans = enumerable;
        }
        public void SetDataSource(IEnumerable<DIC_DANTOC> enumerable)
        {
            this.dantocs = enumerable;
        }


        public override object GetModel()
        {
            DIC_CANBO canbo = new DIC_CANBO();
            canbo.MaCanBo = txtID.Text;
            canbo.TenCanBo = txtName.Text;
            canbo.NgaySinh = txtDate.DateTime;
            canbo.GioiTinh = rdgGender.SelectedIndex == 1 ? 0 : 1;
            canbo.MaPhongBan = DataConverter.StringToInt(cmbDepartment.EditValue.ToString());
            canbo.MaDanToc = cmbEthnic.EditValue.ToString();
            canbo.ChucVu = txtPosition.Text;
            canbo.CapBac = txtRank.Text;
            canbo.KhoaChungTu = ckbLock.Checked;
            canbo.SoDienThoai = txtPhone.Text;
            canbo.DiaChi = txtAddress.Text;
            canbo.BangCap = txtCertificate.Text;
            return canbo;
        }

        protected override void Init()
        {
            //using (DepartmentProvider departmentProvider = new DepartmentProvider())
            //{
            //    cmbDepartment.Properties.DataSource = departmentProvider.GetAllActive();
            //    cmbDepartment.Properties.ValueMember = "MaPhongBan";
            //    cmbDepartment.Properties.DisplayMember = "TenPhongBan";
            //}
            //using (EthnicProvider nationProvider = new EthnicProvider())
            //{
            //    cmbEthnic.Properties.DataSource = nationProvider.GetAllActive();
            //    cmbEthnic.Properties.ValueMember = "MaDanToc";
            //    cmbEthnic.Properties.DisplayMember = "TenDanToc";
            //}
            //cmbDepartment.Properties.DataSource = this.phongbans;
            cmbEthnic.Properties.DataSource = this.dantocs;
            DIC_PHONGBAN dic_phongban = new DIC_PHONGBAN();
            dic_phongban.AddLookupEdit(this.cmbDepartment);
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

        protected override void BindingModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            DIC_CANBO canbo = (DIC_CANBO)this.Model;
            txtID.Text = canbo.MaCanBo;
            txtName.Text = canbo.TenCanBo;
            txtDate.DateTime = DateTime.Now ;
            rdgGender.SelectedIndex = canbo.GioiTinh == 1 ? 0 : 1;
            cmbDepartment.EditValue= canbo.MaPhongBan;
            cmbEthnic.EditValue= canbo.MaDanToc;
            txtPosition.Text = canbo.ChucVu;
            txtRank.Text = canbo.CapBac;
            ckbLock.CheckState= canbo.KhoaChungTu? CheckState.Checked: CheckState.Unchecked;
            txtPhone.Text = canbo.SoDienThoai;
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
