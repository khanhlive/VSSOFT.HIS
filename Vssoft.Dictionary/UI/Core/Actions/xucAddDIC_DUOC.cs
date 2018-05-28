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
    public partial class xucAddDIC_DUOC : Common.UserControls.ucBaseAdd
    {
        public new delegate void SuccessEventHander(object sender, DIC_DICHVU model);
        public new event SuccessEventHander Success;
        public xucAddDIC_DUOC()
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
                        SqlResultType resultType = dichvu.Delete();
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
            lookupNhomDichVu.ReadOnly = true;
        }

        public override void Add()
        {
            base.Add();
            txtID.ReadOnly = true;
            lookupNhomDichVu.ReadOnly = true;
        }

        public override bool Validation()
        {
            this.isValidModel = true;
            this.Validate_EmptyStringRule(this.txtMaNoiBo);
            this.Validate_EmptyStringRule(this.lookupTieuNhom);
            this.Validate_EmptyStringRule(this.lookupNhaSanXuat);
            this.Validate_EmptyStringRule(this.cmbDonViNhap);
            this.Validate_EmptyStringRule(this.cmbDonViSuDung);
            this.Validate_EmptyStringRule(this.txtTyLeQuyDoi);
            this.Validate_EmptyStringRule(this.lookupTrongDM);
            this.ValidateYHCT();
            if (this.actions == Common.Common.Class.Actions.Update)
            {
                this.Validate_EmptyStringRule(this.txtID);
                bool flag = this.txtID.DoValidate();
                if (!flag) this.isValidModel = false;
            }
            bool flag2 = this.txtMaNoiBo.DoValidate();
            if (!flag2) this.isValidModel = false;
            if (this.txtMaQDBYT.EditValue!=null && !string.IsNullOrEmpty(this.txtMaQDBYT.EditValue.ToString())&& !string.IsNullOrWhiteSpace(this.txtMaQDBYT.EditValue.ToString()))
            {
                bool flag = this.txtMaQDBYT.DoValidate();
                if (!flag) this.isValidModel = false;
            }
            this.Validate_EmptyStringRule(txtTenDuoc);
            return this.isValidModel;
        }

        private void ValidateYHCT()
        {
            if (this.ckbYHCT.Checked)
            {
                this.Validate_EmptyStringRule(this.cmbTTNhap);
                this.Validate_EmptyStringRule(this.cmbYHCT_NguonGoc);
                this.Validate_EmptyStringRule(this.cmbYeuCauSD);
                this.Validate_EmptyStringRule(this.cmbBPDung);
                this.Validate_EmptyStringRule(this.txtTyLeSP);
                this.Validate_EmptyStringRule(this.txtTyLeBQ);
            }
            else
            {
                this.ClearErrorControl(this.cmbTTNhap);
                this.ClearErrorControl(this.cmbYHCT_NguonGoc);
                this.ClearErrorControl(this.cmbYeuCauSD);
                this.ClearErrorControl(this.cmbBPDung);
                this.ClearErrorControl(this.txtTyLeSP);
                this.ClearErrorControl(this.txtTyLeBQ);
            }
        }

        public override object GetModel()
        {
            using (DIC_DICHVU dichvu = new DIC_DICHVU())
            {
                if (this.actions == Common.Common.Class.Actions.Update)
                    dichvu.MaDichVu = DataConverter.StringToInt(txtID.EditValue);
                dichvu.TenDichVu = txtTenDuoc.Text;
                dichvu.TenHoatChat = txtHoatChat.Text;
                dichvu.MaTam = txtMaNoiBo.Text;
                dichvu.MaTieuNhomDichVu = DataConverter.StringToInt(lookupTieuNhom.EditValue);
                dichvu.MaNhom = DataConverter.StringToInt(lookupNhomDichVu.EditValue);
                dichvu.HamLuong = txtHamLuong.Text;
                dichvu.SoDangKy = txtSoDangKy.Text;
                dichvu.SoThuTuQuyetDinh = txtSoTTT_Tu.Text;
                if (lookupDuongDung.EditValue != null)
                {
                    dichvu.MaDuongDung = lookupDuongDung.EditValue.ToString();
                    dichvu.DuongDung = lookupDuongDung.SelectedText;
                }
                dichvu.PhanLoaiDichVu = 1;
                dichvu.MaQuyetDinh = txtMaQDBYT.Text;
                dichvu.NuocSanXuat = txtNuocSanXuat.Text;
                if (lookupNhaSanXuat.EditValue != null)
                    dichvu.NhaSanXuat = lookupNhaSanXuat.EditValue.ToString();
                dichvu.TieuChuan = txtTieuChuan.Text;
                dichvu.NguonGoc = cmbNguonGoc.Text;
                dichvu.QuyCachPhamChat = txtQuyCachPhamChat.Text;
                dichvu.DangBaoChe = txtDangBaoChe.Text;
                dichvu.SoLuongMin = (int)(speSoLuongMin.Value);
                dichvu.DinhMuc = DataConverter.ToInt(txtDinhMuc.EditValue);
                if (txtTTBietDuoc.EditValue != null && !string.IsNullOrEmpty(txtTTBietDuoc.Text) && !string.IsNullOrWhiteSpace(txtTTBietDuoc.Text))
                    dichvu.SoThuTu = DataConverter.StringToInt(txtTTBietDuoc.EditValue);
                if (lookupTrongDM.EditValue != null)
                    dichvu.TrongDanhMuc = (DataConverter.ToInt(lookupTrongDM.EditValue));
                dichvu.Status = ckbSuDung.Checked ? 1 : 0;
                dichvu.DonGia = DataConverter.ConvertToDoubleNullable(txtDonGiaBHTT.EditValue);
                dichvu.DonGia2 = DataConverter.ConvertToDoubleNullable(txtDonGiaDichVu.EditValue);
                dichvu.DonGiaGioiHanTT04= DataConverter.ConvertToDoubleNullable(txtGiaGioiHanTT04.EditValue);
                dichvu.BaoHiemThanhToan = (int)speBHTT.Value;
                dichvu.DonViNhap = cmbDonViNhap.Text;
                dichvu.DonViTinh = cmbDonViSuDung.Text;
                dichvu.TyLeSuDung = DataConverter.StringToInt(txtTyLeQuyDoi.Text.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                dichvu.SoLuong = DataConverter.ConvertToDoubleNullable(txtSoLuongThau.EditValue);
                dichvu.GoiThau = txtGoiThau.Text;
                dichvu.SoQuyetDinh = txtSoQuyetDinh.Text;
                if (dtNgayCongBo.EditValue != null)
                    dichvu.NgayQuyetDinh = dtNgayCongBo.DateTime;
                dichvu.LoaiThau = txtLoaiThau.Text;
                if (lookupNhaThau.EditValue != null)
                {
                    dichvu.MaNhaCungCap = lookupNhaThau.EditValue.ToString();
                    dichvu.NhaThau = lookupNhaThau.Text;
                }
                dichvu.LoaiThau = txtLoaiThau.Text;
                dichvu.NhomThau = txtNhomThau.Text;
                dichvu.DongY = ckbYHCT.Checked;
                if (ckbYHCT.Checked)
                {
                    dichvu.TinhTrangNhap = cmbTTNhap.Text;
                    dichvu.NguonGoc = cmbYHCT_NguonGoc.Text;
                    dichvu.YCSD = cmbYeuCauSD.Text;
                    dichvu.BoPhanDung = cmbBPDung.Text;
                    dichvu.TyLeSoChePhucChe = (double)(txtTyLeSP.Value);
                    dichvu.TyLeBaoQuan = (double)(txtTyLeBQ.Value);
                }
                string phongbans = "";
                for (int i = 0; i < ckblPhongbanSD.CheckedItems.Count; i++)
                {
                    phongbans += string.Format("{0};", ckblPhongbanSD.CheckedItems[i]);
                }
                dichvu.MaPhongBanSD = phongbans;
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
                    flag = dichvu.Insert_DUOC();
                else
                    if (this.actions == Common.Common.Class.Actions.Update) flag = dichvu.Update_DUOC();
                else
                    flag = SqlResultType.None;
                if (flag == SqlResultType.OK)
                {
                    this.Success?.Invoke(this, dichvu);
                }
                else if (flag != SqlResultType.None)
                {
                    XtraMessageBox.Show("Không lưu được thông tin thuốc, kiểm tra lại thông tin.");
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
                txtID.EditValue = dichvu.MaDichVu;
                txtTenDuoc.EditValue = dichvu.TenDichVu;
                txtHoatChat.EditValue = dichvu.TenHoatChat;
                txtMaNoiBo.EditValue = dichvu.MaTam;
                lookupTieuNhom.EditValue = dichvu.MaTieuNhomDichVu;
                lookupNhomDichVu.EditValue = dichvu.MaNhom;
                txtHamLuong.EditValue = dichvu.HamLuong;
                txtSoDangKy.EditValue = dichvu.SoDangKy;
                txtSoTTT_Tu.EditValue = dichvu.SoThuTuQuyetDinh;
                lookupDuongDung.EditValue = dichvu.MaDuongDung;
                txtMaQDBYT.EditValue = dichvu.MaQuyetDinh;
                txtNuocSanXuat.EditValue = dichvu.NuocSanXuat;
                lookupNhaSanXuat.EditValue = dichvu.NhaSanXuat;
                txtTieuChuan.EditValue = dichvu.TieuChuan;
                cmbNguonGoc.EditValue = dichvu.NguonGoc;
                txtQuyCachPhamChat.EditValue = dichvu.QuyCachPhamChat;
                txtDangBaoChe.EditValue = dichvu.DangBaoChe;
                speSoLuongMin.Value = dichvu.SoLuongMin==null?0:(decimal)dichvu.SoLuongMin.Value;
                txtDinhMuc.EditValue = dichvu.DinhMuc;
                txtTTBietDuoc.EditValue = dichvu.SoThuTu;
                lookupTrongDM.EditValue = dichvu.TrongDanhMuc;
                ckbSuDung.Checked = dichvu.Status==1;
                txtDonGiaBHTT.EditValue = dichvu.DonGia;
                txtDonGiaDichVu.EditValue = dichvu.DonGia2;
                txtGiaGioiHanTT04.EditValue = dichvu.DonGiaGioiHanTT04;
                speBHTT.EditValue = dichvu.BaoHiemThanhToan;
                cmbDonViNhap.EditValue = dichvu.DonViNhap;
                cmbDonViSuDung.EditValue = dichvu.DonViTinh;
                txtTyLeQuyDoi.EditValue = string.Format("1/{0}", dichvu.TyLeSuDung);
                txtSoLuongThau.EditValue = dichvu.SoLuong;
                txtGoiThau.EditValue = dichvu.GoiThau;
                txtSoQuyetDinh.EditValue = dichvu.SoQuyetDinh;
                if (dichvu.NgayQuyetDinh != null)
                    dtNgayCongBo.DateTime = dichvu.NgayQuyetDinh.Value;
                else dtNgayCongBo.EditValue= null;
                txtLoaiThau.EditValue = dichvu.LoaiThau;
                lookupNhaThau.EditValue = dichvu.MaNhaCungCap;
                txtLoaiThau.EditValue = dichvu.LoaiThau;
                txtNhomThau.EditValue = dichvu.NhomThau;
                ckbYHCT.Checked = dichvu.DongY == true ;
                cmbTTNhap.EditValue = dichvu.TinhTrangNhap;
                cmbYHCT_NguonGoc.EditValue = dichvu.NguonGoc;
                cmbYeuCauSD.EditValue = dichvu.YCSD;
                cmbBPDung.EditValue = dichvu.BoPhanDung;
                txtTyLeSP.EditValue = dichvu.TyLeSoChePhucChe;
                txtTyLeBQ.EditValue = dichvu.TyLeBaoQuan;

                this.ChangeYHCT(dichvu.DongY == null ? false : dichvu.DongY.Value);
                if (!string.IsNullOrEmpty(dichvu.MaPhongBanSD) && !string.IsNullOrWhiteSpace(dichvu.MaPhongBanSD))
                {
                    //string[] dtbns = dichvu.DanhSachDoiTuongBenhNhan.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < ckblPhongbanSD.ItemCount; i++)
                    {
                        if (dichvu.MaPhongBanSD.Contains(string.Format(";{0};", ckblPhongbanSD.GetItemValue(i))))
                            ckblPhongbanSD.SetItemCheckState(i, CheckState.Checked);
                        else
                            ckblPhongbanSD.SetItemCheckState(i, CheckState.Unchecked);
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

            txtID.EditValue = string.Empty;
            txtTenDuoc.EditValue = string.Empty;
            txtHoatChat.EditValue = string.Empty;
            txtMaNoiBo.EditValue = string.Empty;
            lookupTieuNhom.EditValue = null;
            lookupNhomDichVu.EditValue = null;
            txtHamLuong.EditValue = string.Empty;
            txtSoDangKy.EditValue = string.Empty;
            txtSoTTT_Tu.EditValue = string.Empty;
            lookupDuongDung.EditValue = null;
            txtMaQDBYT.EditValue = string.Empty;
            txtNuocSanXuat.EditValue = string.Empty;
            lookupNhaSanXuat.EditValue = null;
            txtTieuChuan.EditValue = string.Empty;
            cmbNguonGoc.EditValue = null;
            txtQuyCachPhamChat.EditValue = string.Empty;
            txtDangBaoChe.EditValue = string.Empty;
            speSoLuongMin.Value = 0;
            txtDinhMuc.EditValue = string.Empty;
            txtTTBietDuoc.EditValue = string.Empty;
            lookupTrongDM.EditValue= 1;
            ckbSuDung.Checked = false;
            txtDonGiaBHTT.EditValue = string.Empty;
            txtDonGiaDichVu.EditValue = string.Empty;
            txtGiaGioiHanTT04.EditValue = string.Empty;
            speBHTT.EditValue = 0;
            cmbDonViNhap.EditValue = string.Empty;
            cmbDonViSuDung.EditValue = string.Empty;
            txtTyLeQuyDoi.EditValue = string.Empty;
            txtSoLuongThau.EditValue = string.Empty;
            txtGoiThau.EditValue = string.Empty;
            txtSoQuyetDinh.EditValue = string.Empty;
            dtNgayCongBo.EditValue = null;
            txtLoaiThau.EditValue = string.Empty;
            lookupNhaThau.EditValue = null;
            txtLoaiThau.EditValue = string.Empty;
            txtNhomThau.EditValue = string.Empty;
            ckbYHCT.Checked = false;
            cmbTTNhap.EditValue = null;
            cmbYHCT_NguonGoc.EditValue = null;
            cmbYeuCauSD.EditValue = null;
            cmbBPDung.EditValue = null;
            txtTyLeSP.EditValue = 0;
            txtTyLeBQ.EditValue = 0;
            this.ChangeYHCT(false);
            //
            ckblPhongbanSD.UnCheckAll();
            this.isUpdated = true;
        }

        protected override void Init()
        {
            new TrongDanhMuc(PhanLoaiDichVu.Duoc).AddLookupEdit(this.lookupTrongDM);
            using (DIC_NHOMDICHVU dic_nhomdichvu = new DIC_NHOMDICHVU())
            {
                dic_nhomdichvu.AddLookupEdit(lookupNhomDichVu);
            }
            using (DIC_TIEUNHOMDICHVU dic_tieunhomdichvu = new DIC_TIEUNHOMDICHVU())
            {
                dic_tieunhomdichvu.AddLookupEdit(lookupTieuNhom);
            }
            using (DIC_PHONGBAN dic_phongban = new DIC_PHONGBAN())
            {
                dic_phongban.AddCheckBoxListEdit(ckblPhongbanSD);
            }
            using (DIC_NHACUNGCAP nhacungcap=new DIC_NHACUNGCAP())
            {
                nhacungcap.AddLookupEdit(lookupNhaThau);
            }
            using (DIC_NHACUNGCAP nhacungcap = new DIC_NHACUNGCAP())
            {
                nhacungcap.AddLookupEdit(lookupNhaSanXuat);
            }
        }

        private void lookupTieuNhom_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated)
            {
                if (lookupTieuNhom.EditValue != null && lookupTieuNhom.EditValue.ToString() != "")
                {
                    object manhom = lookupTieuNhom.GetColumnValue("MaNhom");
                    lookupNhomDichVu.EditValue = manhom;
                }
                else
                {
                    lookupNhomDichVu.EditValue = null;
                }
            }
            if (this.isUpdated && !this.IsEdited)
            {
                this.IsEdited = true;
            }
        }

        private void ChangeYHCT(bool dongy)
        {
            cmbTTNhap.ReadOnly = !dongy;
            cmbYHCT_NguonGoc.ReadOnly = !dongy;
            cmbYeuCauSD.ReadOnly = !dongy;
            cmbBPDung.ReadOnly = !dongy;
            txtTyLeSP.ReadOnly = !dongy;
            txtTyLeBQ.ReadOnly = !dongy;
            if (!dongy)
            {
                cmbTTNhap.EditValue = null;
                cmbYHCT_NguonGoc.EditValue = null;
                cmbYeuCauSD.EditValue = null;
                cmbBPDung.EditValue = null;
                txtTyLeSP.EditValue = 0;
                txtTyLeBQ.EditValue = 0;
            }
        }

        private void ckbYHCT_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeYHCT(((CheckEdit)sender).Checked);
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

        private void ckblPhongbanSD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.IsEdited)
            {
                this.IsEdited = true;
            }
        }

        private void cmbTTNhap_Validated(object sender, EventArgs e)
        {
            if (this.ckbYHCT.Checked)
            {
                this.Validate_EmptyStringRule((BaseEdit)sender);
            }
            else
            {
                this.ClearErrorControl((BaseEdit)sender);
            }
        }
    }
}
