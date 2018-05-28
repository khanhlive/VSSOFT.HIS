using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common.Common.Class;
using Vssoft.Data;
using Vssoft.Data.Enum;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Data.Extension;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class xucAddDIC_DICHVU : Common.UserControls.ucBaseAdd
    {
        public new delegate void SuccessEventHander(object sender, DIC_DICHVU model);
        public new event SuccessEventHander Success;
        public xucAddDIC_DICHVU()
        {
            InitializeComponent();
            this.Init();
        }

        private void RaiseSuccessEventHander(DIC_DICHVU model)
        {
            this.Success?.Invoke(this, model);
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_DICHVU dichvu = (DIC_DICHVU)this.Model;
                    using (DIC_DICHVU dic_dichvu = new DIC_DICHVU())
                    {
                        SqlResultType resultType = new DIC_DICHVU().Delete(dichvu);
                        if (resultType == SqlResultType.OK)
                        {
                            this.ClearModel();
                            this.DisabledLayout(true);
                        }
                        return resultType == SqlResultType.OK ? UserActionType.Success : UserActionType.Failed;
                    }
                }
                else return UserActionType.None;
            }
            return UserActionType.None;
            //this.Success?.Invoke(this, null);
            //return base.DeleteModel();
        }

        public override void UpdateModel()
        {
            base.UpdateModel();
            this.txtID.ReadOnly = true;
        }

        public override void Add()
        {
            base.Add();
            txtID.ReadOnly = true;
        }

        public override bool Validation()
        {
            this.isValidModel = true;

            this.Validate_EmptyStringRule(this.txtMaNoiBo);
            this.Validate_EmptyStringRule(this.txtSoTTQD);
            this.Validate_EmptyStringRule(this.txtSoQDTT37);
            this.Validate_EmptyStringRule(this.txtTenNoiBo);
            this.Validate_EmptyStringRule(this.txtSoTTQD);
            this.Validate_EmptyStringRule(this.txtSoTTQD);
            this.Validate_EmptyStringRule(this.lookupNhomDichvu);
            this.Validate_EmptyStringRule(this.lookupTieunhom);
            if (this.actions == Common.Common.Class.Actions.Update)
            {
                this.Validate_EmptyStringRule(this.txtID);
                bool flag = this.txtID.DoValidate();
                if (!flag) this.isValidModel = false;
            }
            this.Validate_EmptyStringRule(txtName);

            return this.isValidModel;
        }

        public override object GetModel()
        {
            using (DIC_DICHVU dichvu = new DIC_DICHVU())
            {
                if (this.actions == Common.Common.Class.Actions.Update)
                    dichvu.MaDichVu = DataConverter.StringToInt(txtID.EditValue);
                dichvu.MaTam = txtMaNoiBo.Text;
                dichvu.TenDichVu = txtName.Text;
                dichvu.SoThuTuQuyetDinh = txtSoTTQD.Text;
                dichvu.SoQuyetDinh = txtSoQDTT37.Text;
                dichvu.MaQuyetDinh = txtMaQD_BYT.Text;
                dichvu.TenRutGon = txtTenNoiBo.Text;
                dichvu.SoThuTu = (int)speSoTT.Value;
                dichvu.DonViTinh = cmbDonvitinh.Text;
                dichvu.PhanLoaiDichVu = DataConverter.ToInt(cmbPhanLoai.Text);
                dichvu.MaNhom = DataConverter.StringToInt(lookupNhomDichvu.EditValue);
                dichvu.DichVuKyThuatCao = ckbDichvuKTC.Checked ? 1 : 0;
                dichvu.BaoHiemThanhToan = (int)speTyLeBHTT.Value;
                dichvu.Loai = DataConverter.ToInt(cmbLoai.Text);
                dichvu.MaTieuNhomDichVu = DataConverter.ToInt(lookupTieunhom.EditValue);
                dichvu.TrongDanhMuc = ckbTrongDM.Checked ? 1 : 0;
                dichvu.Status = ckbStatus.Checked ? 1 : 0;
                if (txtGiaTT37_d1.EditValue != null)
                    dichvu.DonGia = DataConverter.ConvertToDoubleNullable(txtGiaTT37_d1.EditValue);
                if (txtGiaTT37_d2.EditValue != null)
                    dichvu.DonGiaBHYT = DataConverter.ConvertToDouble(txtGiaTT37_d2.EditValue);
                if (txtGiaDichvu.EditValue != null)
                    dichvu.DonGia2 = DataConverter.ConvertToDoubleNullable(txtGiaDichvu.EditValue);
                if (txtGiaDichvu_d2.EditValue != null)
                    dichvu.GiaDichVuDot2 = DataConverter.ConvertToDoubleNullable(txtGiaDichvu_d2.EditValue);
                if (txtGiaGioiHan.EditValue != null)
                    dichvu.DongiaT7 = DataConverter.ConvertToDoubleNullable(txtGiaGioiHan.EditValue);
                if (txtGiaPhuThu.EditValue != null)
                    dichvu.GiaPhuThu = DataConverter.ConvertToDoubleNullable(txtGiaPhuThu.EditValue);
                string dtbns = "";
                for (int i = 0; i < ckblDoiTuongBenhNhan.CheckedItems.Count; i++)
                {
                    dtbns += string.Format("{0};", ckblDoiTuongBenhNhan.CheckedItems[i]);
                }
                string phongbans = "";
                for (int i = 0; i < ckblPhongbanSudung.CheckedItems.Count; i++)
                {
                    phongbans += string.Format("{0};", ckblPhongbanSudung.CheckedItems[i]);
                }
                dichvu.MaPhongBanSD = phongbans;
                dichvu.DanhSachDoiTuongBenhNhan = dtbns;
                return dichvu;
            }
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_DICHVU dichvu = (DIC_DICHVU)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew ||
                    this.actions == Common.Common.Class.Actions.Add)
                    flag = dichvu.Insert();
                else
                    if (this.actions == Common.Common.Class.Actions.Update) flag = dichvu.Update();
                else
                    flag = SqlResultType.None;
                if (flag == SqlResultType.OK)
                {
                    this.Success?.Invoke(this, dichvu);
                }
                else if (flag != SqlResultType.None)
                {
                    XtraMessageBox.Show("Không lưu được thông tin dịch vụ, kiểm tra lại thông tin.");
                }

            }
            else
            {
                XtraMessageBox.Show("Thông tin chưa hợp lệ kiểm tra lại thông tin.");
            }
        }

        protected override void BindingModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.ClearModel();
            if (this.Model != null)
            {
                this.isUpdated = false;
                this.IsEdited = false;
                DIC_DICHVU dichvu = (DIC_DICHVU)this.Model;
                txtMaNoiBo.EditValue = dichvu.MaTam;
                txtID.EditValue = dichvu.MaDichVu.ToString();
                txtName.EditValue = dichvu.TenDichVu;
                txtSoTTQD.EditValue = dichvu.SoThuTuQuyetDinh;
                txtSoQDTT37.EditValue = dichvu.SoQuyetDinh;
                txtMaQD_BYT.EditValue = dichvu.MaQuyetDinh;
                txtTenNoiBo.EditValue = dichvu.TenRutGon;
                speSoTT.EditValue = dichvu.SoThuTu;
                cmbDonvitinh.EditValue = dichvu.DonViTinh;
                cmbPhanLoai.EditValue = dichvu.PhanLoaiDichVu;
                lookupNhomDichvu.EditValue = dichvu.MaNhom;
                ckbDichvuKTC.Checked = dichvu.DichVuKyThuatCao == 1;
                speTyLeBHTT.EditValue = dichvu.BaoHiemThanhToan;
                cmbLoai.EditValue = dichvu.Loai;
                lookupTieunhom.EditValue = dichvu.MaTieuNhomDichVu;
                ckbTrongDM.Checked = dichvu.TrongDanhMuc == 1;
                ckbStatus.Checked = dichvu.Status == 1;
                ////gia
                txtGiaTT37_d1.EditValue = dichvu.DonGia;
                txtGiaTT37_d2.EditValue = dichvu.DonGiaBHYT;
                txtGiaDichvu.EditValue = dichvu.DonGia2;
                txtGiaDichvu_d2.EditValue = dichvu.GiaDichVuDot2;
                txtGiaGioiHan.EditValue = dichvu.DongiaT7;
                txtGiaPhuThu.EditValue = dichvu.GiaPhuThu;
                if (!string.IsNullOrEmpty(dichvu.DanhSachDoiTuongBenhNhan) && !string.IsNullOrWhiteSpace(dichvu.DanhSachDoiTuongBenhNhan))
                {
                    //string[] dtbns = dichvu.DanhSachDoiTuongBenhNhan.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < ckblDoiTuongBenhNhan.ItemCount; i++)
                    {
                        if (dichvu.DanhSachDoiTuongBenhNhan.Contains(string.Format(";{0};", ckblDoiTuongBenhNhan.GetItemValue(i))))
                            ckblDoiTuongBenhNhan.SetItemCheckState(i, CheckState.Checked);
                        else
                            ckblDoiTuongBenhNhan.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                if (!string.IsNullOrEmpty(dichvu.MaPhongBanSD) && !string.IsNullOrWhiteSpace(dichvu.MaPhongBanSD))
                {
                    //string[] dtbns = dichvu.DanhSachDoiTuongBenhNhan.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < ckblPhongbanSudung.ItemCount; i++)
                    {
                        if (dichvu.MaPhongBanSD.Contains(string.Format(";{0};", ckblPhongbanSudung.GetItemValue(i))))
                            ckblPhongbanSudung.SetItemCheckState(i, CheckState.Checked);
                        else
                            ckblPhongbanSudung.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                txtID.ReadOnly = true;
                this.isUpdated = true;
            }
        }

        public override void ClearModel()
        {
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.IsEdited = false;

            txtMaNoiBo.EditValue = string.Empty;
            txtID.EditValue = string.Empty;
            txtName.EditValue = string.Empty;
            txtSoTTQD.EditValue = string.Empty;
            txtSoQDTT37.EditValue = string.Empty;
            txtMaQD_BYT.EditValue = string.Empty;
            txtTenNoiBo.EditValue = string.Empty;
            speSoTT.EditValue = string.Empty;
            cmbDonvitinh.EditValue = string.Empty;
            cmbPhanLoai.EditValue = string.Empty;
            lookupNhomDichvu.EditValue = null;
            ckbDichvuKTC.Checked = false;
            speTyLeBHTT.EditValue = string.Empty;
            cmbLoai.EditValue = string.Empty;
            lookupTieunhom.EditValue = string.Empty;
            ckbTrongDM.Checked = false;
            ckbStatus.Checked = false;
            ////gia
            txtGiaTT37_d1.EditValue = string.Empty;
            txtGiaTT37_d2.EditValue = string.Empty;
            txtGiaDichvu.EditValue = string.Empty;
            txtGiaDichvu_d2.EditValue = string.Empty;
            txtGiaGioiHan.EditValue = string.Empty;
            txtGiaPhuThu.EditValue = string.Empty;

            //
            ckblDoiTuongBenhNhan.UnCheckAll();
            ckblPhongbanSudung.UnCheckAll();
            this.isUpdated = true;
        }

        protected override void Init()
        {
            cmbDonvitinh.Properties.Items.AddRange(CommonVariable.DonViTinhs);
            cmbPhanLoai.Properties.Items.AddRange(new string[] { "2", "3" });
            using (DIC_NHOMDICHVU dic_nhomdichvu = new DIC_NHOMDICHVU())
            {
                dic_nhomdichvu.AddLookupEdit(lookupNhomDichvu);
            }
            using (DIC_TIEUNHOMDICHVU dic_tieunhomdichvu = new DIC_TIEUNHOMDICHVU())
            {
                dic_tieunhomdichvu.AddLookupEdit(lookupTieunhom);
            }
            using (DIC_DTBN dic_dtbn = new DIC_DTBN())
            {
                dic_dtbn.AddCheckBoxListEdit(ckblDoiTuongBenhNhan);
            }
            using (DIC_PHONGBAN dic_phongban = new DIC_PHONGBAN())
            {
                dic_phongban.AddCheckBoxListEdit(ckblPhongbanSudung);
            }
        }

        private void control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Validate_EmptyStringRule((BaseEdit)sender);
        }

        private void control_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.IsEdited)
            {
                this.IsEdited = true;
            }
        }

        private void cmbLoai_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void lookupTieunhom_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated)
            {
                cmbLoai.Properties.Items.Clear();
                if (lookupTieunhom.EditValue != null && lookupTieunhom.EditValue.ToString() != "")
                {
                    object manhom = lookupTieunhom.GetColumnValue("MaNhom");
                    lookupNhomDichvu.EditValue = manhom;
                    string tenrg = "";
                    if (lookupTieunhom.GetColumnValue("TenRutGon") != null)
                        tenrg = lookupTieunhom.GetColumnValue("TenRutGon").ToString();
                    switch (tenrg)
                    {
                        case "X-Quang":
                            layoutControlItem_Loai.Text = "S.Lượng phim";
                            cmbLoai.Properties.Items.Add(0);
                            cmbLoai.Properties.Items.Add(1);
                            cmbLoai.Properties.Items.Add(2);
                            cmbLoai.Properties.Items.Add(3);
                            cmbLoai.Properties.Items.Add(4);
                            break;
                        case "Siêu âm":
                            layoutControlItem_Loai.Text = "Loại siêu âm";
                            cmbLoai.Properties.Items.Add(PhanLoaiSieuAm.Sa2D);
                            cmbLoai.Properties.Items.Add(PhanLoaiSieuAm.SaMau);
                            cmbLoai.Properties.Items.Add(PhanLoaiSieuAm.Sa3D_4D);
                            break;
                        default:
                            layoutControlItem_Loai.Text = "Loại";
                            for (int i = 0; i < 50; i++)
                                cmbLoai.Properties.Items.Add(i);
                            break;
                    }

                }
                else
                {
                    lookupNhomDichvu.EditValue = "";
                }
            }
            if (this.isUpdated && !this.IsEdited)
            {
                this.IsEdited = true;
            }
        }

        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdated && cmbLoai.SelectedIndex == 0)
            {
                DialogResult _result = XtraMessageBox.Show("Phân loại là 3 chỉ dùng cho dịch vụ phục vụ trong đơn vị sử dụng chức năng nhập chi phí BHYT của các TYT XP, Bạn vẫn muốn thay đổi?", "Thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            }
        }
    }
}
