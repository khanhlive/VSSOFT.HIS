using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Data.Enum;
using Vssoft.Common;
using DevExpress.XtraEditors;
using Vssoft.Common.Common.Class;
using System.Drawing;

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
            if (picAvatar.Image != null)
                canbo.Image = DataConverter.GetBytesFromImage(picAvatar.Image);
            return canbo;
        }

        protected override void Init()
        {
            cmbDepartment.Properties.ValueMember = "MaPhongBan";
            cmbDepartment.Properties.DisplayMember = "TenPhongBan";
            cmbDepartment.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenPhongBan", "TenPhongBan"));
            cmbDepartment.Properties.ShowHeader = false;
            cmbEthnic.Properties.ValueMember = "MaDanToc";
            cmbEthnic.Properties.DisplayMember = "TenDanToc";
            cmbEthnic.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDanToc", "TenDanToc"));
            cmbEthnic.Properties.ShowHeader = false;
            cmbDepartment.Properties.DataSource = this.phongbans;
            cmbEthnic.Properties.DataSource = this.dantocs;
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
            picAvatar.ReadOnly = readOnly;
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
            if (canbo.Image != null)
                picAvatar.Image = DataConverter.GetImageFromBytes(canbo.Image);
            else picAvatar.Image = null;
            txtID.ReadOnly = true;
            this.isUpdated = true;
            this.ClearError(this.layoutControl1);
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_CANBO canbo = (DIC_CANBO)this.Model;
                    SqlResultType resultType = new DIC_CANBO().Delete(canbo);
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
            picAvatar.Image = null;
            this.isUpdated = true;
            this.ClearError(this.layoutControl1);
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_CANBO canbo = (DIC_CANBO)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new DIC_CANBO().Insert(canbo);
                else flag = new DIC_CANBO().Update(canbo);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = canbo;
                args.Action = this.actions;
                args.Message = "Không lưu được thông tin can bo";
                this.SaveCompleteSuccess(canbo, args);
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
            if (!string.IsNullOrEmpty(txtPhone.EditValue.ToString())&& !string.IsNullOrWhiteSpace(txtPhone.EditValue.ToString()))
            {
                this.Validate_EmptyStringRule(txtPhone);
            }
            this.Validate_EmptyStringRule(cmbDepartment);
            this.Validate_EmptyStringRule(cmbEthnic);
            this.Validate_EmptyStringRule(txtDate);
            this.Validate_EmptyStringRule(rdgGender);
            //bool flag2 = this.txtCode.DoValidate();
            //if (!flag2) this.isValidModel = false;
            return this.isValidModel;
        }

        private void txtID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.isEdited)
            {
                this.isEdited = true;
            }
        }

        private void control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Validate_EmptyStringRule((BaseEdit)sender);
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (!((BaseEdit)sender).ReadOnly)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "*.png|*.jpg";
                fileDialog.Title = "Chọn ảnh đại diện";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = DataConverter.GetBytesFromImagePath(fileDialog.FileName);

                    picAvatar.Image = DataConverter.GetImageFromBytes(bytes);
                }
            }
        }
    }
}
