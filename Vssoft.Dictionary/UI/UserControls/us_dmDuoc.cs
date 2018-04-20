﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
//using QLBV.FormNhap;
using Vssoft.ERP.Models;
using Vssoft.Data.Core;
using Vssoft.Data.Extension.Class;

namespace Vssoft.Dictionary.UI.UserControls
{
    public partial class us_dmDuoc : DevExpress.XtraEditors.XtraUserControl
    {
        public us_dmDuoc()
        {
            InitializeComponent();
        }
        int TTLuu = 0;
        int _madv = 0;
        List<DichVu> _ldichvu = new List<DichVu>();
        private void EnableButton(bool t)
        {
            btnLuu.Enabled = !t;
            btnMoi.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btn5084.Enabled = !t;
            //txtMaDV.Properties.ReadOnly = t;
            txtTenDV.Properties.ReadOnly = t;
            txtTenHC.Properties.ReadOnly = t;
            txtHamLuong.Properties.ReadOnly = t;
            txtDonGia.Properties.ReadOnly = t;
            txtDuongDung.Properties.ReadOnly = t;
            lupNhom.Properties.ReadOnly = t;
            lupMaCC.Properties.ReadOnly = t;
            lupPhanLoai.Properties.ReadOnly = true;
            cboDonVi.Properties.ReadOnly = t;
            txtNuocSX.Properties.ReadOnly = t;
            cboTrongDM.Properties.ReadOnly = t;
            chkStatus.Properties.ReadOnly = t;
            txtSoDK.Properties.ReadOnly = t;
            cbo_NhaSX.Properties.ReadOnly = t;
            txtQCPC.Properties.ReadOnly = t;
            txtDangBC.Properties.ReadOnly = t;
            txtMaQD.Properties.ReadOnly = t;
            cboTTNhap.Properties.ReadOnly = t;
            cboNguonGoc.Properties.ReadOnly = t;
            cboBPDung.Properties.ReadOnly = t;
            cboYCSD.Properties.ReadOnly = t;
            txtTLHH.Properties.ReadOnly = t;
            txtTLBQ.Properties.ReadOnly = t;
            chkDY.Properties.ReadOnly = t;
            txtSoTTqd.Properties.ReadOnly = t;
            grcDichVu.Enabled = t;
            txtBHTT.Properties.ReadOnly = t;
            cboNguonGocnb.Properties.ReadOnly = t;
            txtDonGia2.Properties.ReadOnly = t;
            txtMin.Properties.ReadOnly = t;
            cboDonViN.Properties.ReadOnly = t;
            txtTyLe.Properties.ReadOnly = t;
            txtMaTam.Properties.ReadOnly = t;
            cklKP.Enabled = !t;
            dt_NgayCB.Properties.ReadOnly = t;
            txtSoQD.Properties.ReadOnly = t;
            txtTuoiTho.Properties.ReadOnly = t;
            txtTieuChuan.Properties.ReadOnly = t;
            txtSoLuongThau.Properties.ReadOnly = t;
            lup_MaDuongD.Properties.ReadOnly = t;
            txtSoTT.Properties.ReadOnly = t;

            txtLoaiThuoc.Properties.ReadOnly = t;
            txtLoaiThau.Properties.ReadOnly = t;
            txtNhomThau.Properties.ReadOnly = t;
            txtMaNhom.Properties.ReadOnly = t;
            txtGiaBHGioiHanTT.Properties.ReadOnly = t;

        }
        private void resetcontrol()
        {
            txtMaQD.Text = "";
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtTenHC.Text = "";
            txtHamLuong.Text = "";
            txtDonGia.Text = "";
            txtDuongDung.Text = "";

            lupNhom.EditValue = "";
            lupPhanLoai.EditValue = "";
            cboDonVi.Text = "";
            txtNuocSX.Text = "";
            txtSoDK.Text = "";
            cbo_NhaSX.Text = "";
            txtQCPC.Text = "";
            txtDangBC.Text = "";
            cboTrongDM.SelectedIndex = -1;
            chkStatus.Checked = true;
            cboTTNhap.Text = "";
            cboNguonGoc.Text = "";
            cboYCSD.Text = "";
            cboBPDung.Text = "";
            txtTLHH.Text = "";
            txtTLBQ.Text = "";
            txtMin.ResetText();
            txtMaTam.ResetText();
            txtSoQD.ResetText();
            txtTuoiTho.ResetText();
            txtTieuChuan.ResetText();
            txtSoLuongThau.ResetText();
            lup_MaDuongD.ResetText();
            txtSoTT.ResetText();
            mm_TenRG.ResetText();
            txtLoaiThuoc.ResetText();
            txtLoaiThau.ResetText();
            txtNhomThau.ResetText();
            txtMaNhom.ResetText();
            txtGiaBHGioiHanTT.ResetText();
        }
        private bool Ktra()
        {
            int ot;
            int _int_MaDuoc = 0;
            if (Int32.TryParse(txtMaDV.Text, out ot))
                _int_MaDuoc = Convert.ToInt32(txtMaDV.Text);

            //if (_int_MaDuoc<=0)
            //{
            //    MessageBox.Show("Bạn chưa nhập mã dược");
            //    txtMaDV.Focus();
            //    return false;
            //}
            //else
            //{
            if (TTLuu == 1)
            {
                //var ktra = _data.DichVus.Where(p => p.MaDV ==  _int_MaDuoc).ToList();
                //if (ktra.Count > 0)
                //{
                //    MessageBox.Show("Mã số đã tồn tại, hãy nhập mã khác");
                //    txtMaDV.Focus();
                //    txtMaDV.SelectAll();
                //    return false;
                //}

                bool t = false;
                string _timkiem = "";
                if (!string.IsNullOrEmpty(txtTenDV.Text))
                    _timkiem = txtTenDV.Text.ToLower();
                ;
                if (_ldichvu.Where(p => p.TenDV.ToLower().Contains(_timkiem.ToLower())).ToList().Count > 0)
                    t = true;
                if (t)
                {
                    DialogResult _result = MessageBox.Show("Thuốc: " + _timkiem + " đã có, bạn vẫn muốn thêm mới?", "Hỏi lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_result == DialogResult.No)
                    {
                        txtTenDV.Focus();
                        txtTenDV.SelectAll();
                        return false;
                    }
                }

            }
            //}
            if (!string.IsNullOrEmpty(txtMaTam.Text))
            {
                if (TTLuu == 1)
                {
                    var ktra_matam = _data.DichVus.Where(p => p.MaTam == txtMaTam.Text.Trim()).ToList();
                    if (ktra_matam.Count > 0)
                    {
                        MessageBox.Show("Mã số đã tồn tại, hãy nhập mã khác");
                        txtMaTam.Focus();
                        txtMaTam.SelectAll();
                        return false;
                    }
                }
                if (TTLuu == 2)
                {
                    var ktra_matam = _data.DichVus.Where(p => p.MaTam == txtMaTam.Text.Trim() && p.MaDV != _int_MaDuoc).ToList();
                    if (ktra_matam.Count > 0)
                    {
                        MessageBox.Show("Mã số đã tồn tại, hãy nhập mã khác");
                        txtMaTam.Focus();
                        txtMaTam.SelectAll();
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã nội bộ");
                txtMaTam.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên dược");
                txtTenDV.Focus();
                return false;
            }
            if (lupNhom.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn nhóm dịch vụ");
                lupNhom.Focus();
                return false;
            }
            if (lupPhanLoai.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn nhóm dịch vụ");
                lupPhanLoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboDonVi.Text))
            {
                MessageBox.Show("Bạn chưa chọn đơn vị");
                cboDonVi.Focus();
                return false;
            }
            if (lupMaCC.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp");
                lupMaCC.Focus();
                return false;
            }
            if (chkDY.Checked == true)
            {
                if (string.IsNullOrEmpty(cboTTNhap.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tình trạng nhập của dịch vụ!");
                    cboTTNhap.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cboNguonGoc.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tình nguồn gốc của dịch vụ!");
                    cboNguonGoc.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cboBPDung.Text))
                {
                    MessageBox.Show("Bạn chưa nhập bộ phận dùng của dịch vụ!");
                    cboBPDung.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cboYCSD.Text))
                {
                    MessageBox.Show("Bạn chưa nhập yêu cầu sử dụng của dịch vụ!");
                    cboYCSD.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTLHH.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tỷ lệ hư hao khi sơ chế hay phức chế!");
                    txtTLHH.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTLBQ.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tỷ lệ bảo quản!");
                    txtTLBQ.Focus();
                    return false;
                }

            }


            return true;
        }
        Hospital _data = new Hospital();
        List<NhomDV> _lNhom = new List<NhomDV>();
        List<usDichVu.KhoaPhong> _lKPsd = new List<usDichVu.KhoaPhong>();
        List<DuongDung> _lddung = new List<DuongDung>();
        private void us_dmDuoc_Load(object sender, EventArgs e)
        {
            //    try
            //    {
            lupMaCC.Properties.DataSource = _data.NhaCCs.OrderBy(p => p.TenCC).ToList();
            if (PermissionProvider.CheckQuyenFalse("us_dmDuoc")[0])
                EnableButton(true);
            else
                EnableButton(false);
            List<string> _nhasx = _data.DonVis.Select(p => p.TenDonVi).ToList();
            cbo_NhaSX.Properties.Items.AddRange(_nhasx);
            _lKPsd = (from kp in _data.KPhongs.Where(p => p.PLoai == KhoaPhongPL.CanLamSang || p.PLoai == KhoaPhongPL.LamSang || p.PLoai == KhoaPhongPL.PhongKham || p.PLoai == KhoaPhongPL.KhoaDuoc)
                      select new usDichVu.KhoaPhong()
                      {
                          Check = false,
                          MaKP = kp.MaKP,
                          TenKP = kp.TenKP
                      }).Distinct().OrderBy(p => p.TenKP).ToList();
            cklKP.DataSource = _lKPsd;
            _lNhom = _data.NhomDVs.Where(p => p.Status == 1).ToList();
            _lddung = _data.DuongDungs.OrderBy(p => p.DuongDung1).ToList();
            lup_MaDuongD.Properties.DataSource = _lddung;
            var _tnhom = (from nhom in _data.NhomDVs.Where(p => p.Status == 1)
                          join tn in _data.TieuNhomDVs on nhom.IDNhom equals tn.IDNhom
                          select new { nhom.TenNhom, tn.TenTN, tn.IdTieuNhom, nhom.IDNhom }).ToList();
            //List<string> _lsDM5084 = new List<string>();
            //_lsDM5084 = _data.C5084.Where(p => p.Bang != 5).OrderBy(p => p.TenDV).Select(p=>p.TenDV).ToList();
            lupNhom.Properties.DataSource = _tnhom.ToList();
            lupPhanLoai.Properties.DataSource = _lNhom;
            lupIDNhom.DataSource = _lNhom.ToList();
            luptieunhom.DataSource = _tnhom.ToList();
            _ldichvu = _data.DichVus.Where(p => p.PLoai == 1).ToList();
            grcDichVu.DataSource = _ldichvu;
            //}
            chkDY.Checked = false;
            panelControl3.Visible = false;






            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            //}
        }


        private void btnMoi_Click(object sender, EventArgs e)
        {
            if (Vssoft.Data.Common.MaBV == "12001")
            {
                if (!PermissionProvider.CheckQuyenFalse("us_dmDuoc")[0])
                {
                    MessageBox.Show("Bạn chưa được cấp quyền thêm mới thuốc, VTYT ! \nLiên hệ với admin để được cấp quyền");
                    return;
                }
            }
            TTLuu = 1;
            EnableButton(false);
            resetcontrol();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Ktra())
            {
                switch (TTLuu)
                {
                    case 1:
                        //try
                        {
                            DichVu _newDV = new DichVu();
                            _newDV.MaTam = txtMaTam.Text;
                            _newDV.TenDV = txtTenDV.Text.Trim();
                            _newDV.PLoai = 1;
                            _newDV.IdTieuNhom = Convert.ToInt32(lupNhom.EditValue);
                            _newDV.IDNhom = Convert.ToInt32(lupPhanLoai.EditValue);
                            if (!string.IsNullOrEmpty(txtDonGia.Text))
                                _newDV.DonGia = double.Parse(txtDonGia.Text);
                            _newDV.DonVi = cboDonVi.Text.Trim();
                            _newDV.HamLuong = txtHamLuong.Text.Trim();

                            _newDV.DuongD = txtDuongDung.Text.Trim();
                            _newDV.NuocSX = txtNuocSX.Text.Trim();
                            _newDV.TenHC = txtTenHC.Text.Trim();
                            _newDV.MaQD = txtMaQD.Text.Trim();
                            _newDV.SoDK = txtSoDK.Text.Trim();
                            _newDV.DangBC = txtDangBC.Text.Trim();
                            _newDV.NhaSX = cbo_NhaSX.Text.Trim();
                            _newDV.QCPC = txtQCPC.Text.Trim();
                            if (!String.IsNullOrEmpty(txtDinhMuc.Text))
                                _newDV.DinhMuc = Convert.ToInt32(txtDinhMuc.Text);
                            if (lupMaCC.EditValue != null)
                                _newDV.MaCC = lupMaCC.EditValue.ToString();
                            _newDV.TrongDM = cboTrongDM.SelectedIndex;
                            if (chkStatus.Checked == true)
                                _newDV.Status = 1;
                            else
                                _newDV.Status = 0;
                            if (chkDY.Checked == true)
                                _newDV.DongY = 1;
                            else _newDV.DongY = 0;
                            _newDV.TinhTNhap = cboTTNhap.Text.Trim();
                            if (chkDY.Checked)
                                _newDV.NguonGoc = cboNguonGoc.Text.Trim();
                            else
                                _newDV.NguonGoc = cboNguonGocnb.Text.Trim();
                            if (!string.IsNullOrEmpty(txtTLHH.Text))
                                _newDV.TyLeSP = double.Parse(txtTLHH.Text);
                            if (!string.IsNullOrEmpty(txtTLBQ.Text))
                            {
                                _newDV.TyLeBQ = double.Parse(txtTLBQ.Text);
                            }
                            else _newDV.TyLeBQ = 0;
                            _newDV.BPDung = cboBPDung.Text.Trim();
                            _newDV.YCSD = cboYCSD.Text;
                            if (!string.IsNullOrEmpty(txtBHTT.Text))
                                _newDV.BHTT = Convert.ToInt32(txtBHTT.Text);
                            else
                                _newDV.BHTT = 100;
                            _newDV.SoTTqd = txtSoTTqd.Text;
                            if (!string.IsNullOrEmpty(txtDonGia2.Text))
                            {
                                _newDV.DonGia2 = Convert.ToDouble(txtDonGia2.Text);
                                if (lupPhanLoai.EditValue != null && Convert.ToInt32(lupPhanLoai.EditValue) == 7 && txtTenHC.Text == "VM." + Vssoft.Data.Common.MaBV)// nếu là chi phí vận chuyển máu (gán giá bh = giá dịch vụ luôn
                                {
                                    _newDV.DonGiaBHYT = Convert.ToDouble(txtDonGia2.Text);
                                }

                            }
                            else
                            {
                                _newDV.DonGia2 = 0;
                            }
                            int _soLuongMin = 0;
                            try
                            {
                                if (!string.IsNullOrEmpty(txtMin.Text))
                                {
                                    _soLuongMin = Convert.ToInt32(txtMin.Text.Trim());
                                }
                            }
                            catch (Exception)
                            {
                                _soLuongMin = 0;
                            }
                            _newDV.SLMin = _soLuongMin;
                            _newDV.DonViN = cboDonViN.Text.Trim();
                            string[] tyle = new string[2] { "1", "1" };
                            tyle = QLBV_Library.QLBV_Ham.LayChuoi('/', txtTyLe.Text);
                            _newDV.TyLeSD = Convert.ToInt32(tyle[1]);
                            string _makpsd = ";";
                            for (int i = 0; i < cklKP.ItemCount; i++)
                            {
                                if (cklKP.GetItemCheckState(i) == CheckState.Checked)
                                    _makpsd += cklKP.GetItemValue(i) + ";";
                            }

                            _newDV.MaKPsd = _makpsd;
                            if (!string.IsNullOrEmpty(dt_NgayCB.Text))
                                _newDV.NgayQD = dt_NgayCB.DateTime;
                            _newDV.SoQD = txtSoQD.Text.Trim();
                            if (!string.IsNullOrEmpty(txtSoLuongThau.Text))
                                _newDV.SLuong = Convert.ToInt32(txtSoLuongThau.Text);
                            else
                                _newDV.SLuong = 0;
                            _newDV.TieuChuan = txtTieuChuan.Text.Trim();
                            if (!string.IsNullOrEmpty(txtLoaiThuoc.Text))
                                _newDV.LThuoc = Convert.ToInt32(txtLoaiThuoc.Text);
                            else
                                _newDV.LThuoc = 1;
                            _newDV.NhomThau = txtNhomThau.Text;
                            _newDV.MaNhom = txtMaNhom.Text; // gói thầu
                            if (!string.IsNullOrEmpty(txtLoaiThau.Text))
                                _newDV.LThau = Convert.ToInt32(txtLoaiThau.Text);
                            else
                                _newDV.LThau = 1;
                            //txtLoaiThuoc.Properties.ReadOnly = t;
                            //txtLoaiThau.Properties.ReadOnly = t;
                            //txtNhomThau.Properties.ReadOnly = t;
                            _newDV.TuoiTho = txtTuoiTho.Text;
                            _newDV.MaDuongDung = lup_MaDuongD.Text;
                            if (!string.IsNullOrEmpty(txtSoTT.Text))
                                _newDV.SoTT = Convert.ToInt32(txtSoTT.Text);
                            else
                                _newDV.SoTT = 0;
                            _newDV.DSDonGia = "";
                            _newDV.TenRG = mm_TenRG.Text;
                            if (!string.IsNullOrEmpty(txtGiaBHGioiHanTT.Text))
                                _newDV.GiaBHGioiHanTT = Convert.ToDouble(txtGiaBHGioiHanTT.Text);
                            _data.DichVus.Add(_newDV);
                            if (_data.SaveChanges() == 1)
                            {
                                MessageBox.Show("Thêm mới thành công");
                                timkiem();
                                TTLuu = 0;
                                if (PermissionProvider.CheckQuyenFalse("us_dmDuoc")[0])
                                    EnableButton(true);
                                else
                                    EnableButton(false);
                            }
                        }
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Lỗi không tạo mới được: " + ex.Message);
                        //}
                        break;
                    case 2:
                        //try
                        {
                            var _suaDV = _data.DichVus.Single(p => p.MaDV == _madv);
                            _suaDV.MaTam = txtMaTam.Text;
                            _suaDV.TenDV = txtTenDV.Text.Trim();
                            _suaDV.PLoai = 1;
                            _suaDV.IdTieuNhom = Convert.ToInt32(lupNhom.EditValue);
                            _suaDV.IDNhom = Convert.ToInt32(lupPhanLoai.EditValue);
                            if (!string.IsNullOrEmpty(txtDonGia.Text))
                                _suaDV.DonGia = double.Parse(txtDonGia.Text);
                            _suaDV.DonVi = cboDonVi.Text;
                            _suaDV.HamLuong = txtHamLuong.Text.Trim();
                            _suaDV.DuongD = txtDuongDung.Text.Trim();
                            _suaDV.NuocSX = txtNuocSX.Text.Trim();
                            _suaDV.TenHC = txtTenHC.Text.Trim();
                            var suamaqd = _data.DichVus.Where(p => p.MaQD == txtMaQD.Text.Trim()).Where(p => p.TenDV == txtTenDV.Text).ToList();
                            if (suamaqd.Count > 0)
                            {
                                foreach (var a in suamaqd)
                                {
                                    var suaqd = _data.DichVus.Single(p => p.MaDV == a.MaDV);
                                    suaqd.MaQD = txtMaQD.Text.Trim();
                                    _data.SaveChanges();
                                }

                            }
                            if (!String.IsNullOrEmpty(txtDinhMuc.Text))
                                _suaDV.DinhMuc = Convert.ToInt32(txtDinhMuc.Text);
                            _suaDV.MaQD = txtMaQD.Text.Trim();
                            _suaDV.SoDK = txtSoDK.Text.Trim();
                            _suaDV.DangBC = txtDangBC.Text.Trim();
                            _suaDV.NhaSX = cbo_NhaSX.Text.Trim();
                            _suaDV.MaCC = lupMaCC.EditValue.ToString();
                            _suaDV.QCPC = txtQCPC.Text.Trim();
                            _suaDV.TenRG = mm_TenRG.Text;
                            _suaDV.TrongDM = cboTrongDM.SelectedIndex;
                            if (chkStatus.Checked == true)
                                _suaDV.Status = 1;
                            else
                                _suaDV.Status = 0;
                            if (chkDY.Checked == true)
                                _suaDV.DongY = 1;
                            else _suaDV.DongY = 0;
                            _suaDV.TinhTNhap = cboTTNhap.Text;
                            if (chkDY.Checked)
                                _suaDV.NguonGoc = cboNguonGoc.Text.Trim();
                            else
                                _suaDV.NguonGoc = cboNguonGocnb.Text.Trim();
                            _suaDV.SoTTqd = txtSoTTqd.Text;
                            if (!string.IsNullOrEmpty(txtTLHH.Text))
                                _suaDV.TyLeSP = double.Parse(txtTLHH.Text);
                            if (!string.IsNullOrEmpty(txtTLBQ.Text))
                            {
                                _suaDV.TyLeBQ = double.Parse(txtTLBQ.Text);
                            }
                            else { _suaDV.TyLeBQ = 0; }
                            _suaDV.BPDung = cboBPDung.Text;
                            _suaDV.YCSD = cboYCSD.Text;
                            if (!string.IsNullOrEmpty(txtBHTT.Text))
                                _suaDV.BHTT = Convert.ToInt32(txtBHTT.Text);
                            else
                                _suaDV.BHTT = 100;
                            if (!string.IsNullOrEmpty(txtDonGia2.Text))
                            {
                                _suaDV.DonGia2 = Convert.ToDouble(txtDonGia2.Text);

                            }
                            else
                            {
                                _suaDV.DonGia2 = 0;
                            }
                            int _soLuongMin = 0;
                            try
                            {
                                if (!string.IsNullOrEmpty(txtMin.Text))
                                {
                                    _soLuongMin = Convert.ToInt32(txtMin.Text.Trim());
                                }
                            }
                            catch (Exception)
                            {
                                _soLuongMin = 0;
                            }

                            _suaDV.SLMin = _soLuongMin;
                            _suaDV.DonViN = cboDonViN.Text.Trim();
                            string[] tyle = new string[2] { "1", "1" };
                            tyle = QLBV_Library.QLBV_Ham.LayChuoi('/', txtTyLe.Text);
                            _suaDV.TyLeSD = Convert.ToInt32(tyle[1]);
                            string _makpsd = ";";
                            for (int i = 0; i < cklKP.ItemCount; i++)
                            {
                                if (cklKP.GetItemCheckState(i) == CheckState.Checked)
                                    _makpsd += cklKP.GetItemValue(i) + ";";
                            }

                            _suaDV.MaKPsd = _makpsd;
                            if (!string.IsNullOrEmpty(dt_NgayCB.Text))
                                _suaDV.NgayQD = dt_NgayCB.DateTime;
                            else
                                _suaDV.NgayQD = null;
                            _suaDV.SoQD = txtSoQD.Text.Trim();
                            if (!string.IsNullOrEmpty(txtSoLuongThau.Text))
                                _suaDV.SLuong = Convert.ToInt32(txtSoLuongThau.Text);
                            else
                                _suaDV.SLuong = 0;
                            _suaDV.TieuChuan = txtTieuChuan.Text.Trim();
                            if (!string.IsNullOrEmpty(txtLoaiThuoc.Text))
                                _suaDV.LThuoc = Convert.ToInt32(txtLoaiThuoc.Text);
                            else
                                _suaDV.LThuoc = 1;
                            _suaDV.NhomThau = txtNhomThau.Text;
                            _suaDV.MaNhom = txtMaNhom.Text;
                            if (!string.IsNullOrEmpty(txtLoaiThau.Text))
                                _suaDV.LThau = Convert.ToInt32(txtLoaiThau.Text);
                            else
                                _suaDV.LThau = 1;
                            _suaDV.TuoiTho = txtTuoiTho.Text;
                            _suaDV.MaDuongDung = lup_MaDuongD.Text;
                            if (!string.IsNullOrEmpty(txtSoTT.Text))
                                _suaDV.SoTT = Convert.ToInt32(txtSoTT.Text);
                            if (!string.IsNullOrEmpty(txtGiaBHGioiHanTT.Text))
                                _suaDV.GiaBHGioiHanTT = Convert.ToDouble(txtGiaBHGioiHanTT.Text);
                            if (_data.SaveChanges() == 1)
                            //_data.SaveChanges();
                            {
                                TTLuu = 0;
                                MessageBox.Show("Sửa thành công");
                                timkiem();
                                if (PermissionProvider.CheckQuyenFalse("us_dmDuoc")[0])
                                    EnableButton(true);
                                else
                                    EnableButton(true);
                            }
                        }
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Không sửa được! " + ex.Message);
                        //}
                        break;
                }
            }
        }

        private void txtMaDV_Leave(object sender, EventArgs e)
        {
            int ot;
            int _int_MmaDV = 0;
            if (Int32.TryParse(txtMaDV.Text, out ot))
                _int_MmaDV = Convert.ToInt32(txtMaDV.Text);
            try
            {
                if (TTLuu == 1)
                {
                    if (_int_MmaDV > 0)
                    {
                        var kt = _data.DichVus.Where(p => p.MaDV == _int_MmaDV).ToList();
                        if (kt.Count > 0)
                        {
                            MessageBox.Show("Mã dược đã tồn tại, hãy nhập mã khác!");
                            txtMaDV.Focus();
                            txtMaDV.SelectAll();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã dược: " + ex.Message);
            }
        }

        private void txtTenDV_Leave(object sender, EventArgs e)
        {

            int ot;
            int _int_MmaDV = 0;
            if (Int32.TryParse(txtMaDV.Text, out ot))
                _int_MmaDV = Convert.ToInt32(txtMaDV.Text);
            try
            {
                if (_int_MmaDV > 0)
                {
                    var kt = _data.DichVus.Where(p => p.MaDV == _int_MmaDV).ToList();
                    if (kt.Count > 0)
                    {
                        MessageBox.Show("Tên dược đã tồn tại, hãy nhập tên khác!");
                        txtTenDV.Focus();
                        txtTenDV.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tên dược: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Vssoft.Data.Common.MaBV == "12001")
            {
                if (!PermissionProvider.CheckQuyenFalse("us_dmDuoc")[1])
                {
                    MessageBox.Show("Bạn chưa được cấp quyền sửa thuốc, VTYT ! \nLiên hệ với admin để được cấp quyền");
                    return;
                }
            }
            int ot;
            int _int_MmaDV = 0;
            if (Int32.TryParse(txtMaDV.Text, out ot))
                _int_MmaDV = Convert.ToInt32(txtMaDV.Text);
            txtMaDV.Properties.ReadOnly = true;
            txtMaDV.Properties.AllowFocused = false;
            if (_int_MmaDV > 0)
            {
                TTLuu = 2;
                EnableButton(false);
            }
            else
            {
                MessageBox.Show("không có dược để sửa");
            }
        }

        private void lupNhom_EditValueChanged(object sender, EventArgs e)
        {
            if (lupNhom.EditValue != null && lupNhom.EditValue.ToString() != "")
                lupPhanLoai.EditValue = lupNhom.GetColumnValue("IDNhom");
            else
                lupPhanLoai.EditValue = "";
        }
        private void grvDichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (grvDichVu.GetFocusedRowCellValue(colMaDV) != null)
            {
                _madv = Convert.ToInt32(grvDichVu.GetFocusedRowCellValue(colMaDV));
                if (_ldichvu.Where(p => p.MaDV == _madv).Count() > 0)
                {
                    txtMaTam.Text = _ldichvu.Where(p => p.MaDV == _madv).First().MaTam;
                    txtMaDV.Text = _madv.ToString();
                    txtTenDV.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TenDV;
                    txtTenHC.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TenHC;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().DinhMuc != null)
                        txtDinhMuc.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DinhMuc.ToString();
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().TrongDM != null)
                    {
                        cboTrongDM.SelectedIndex = _ldichvu.Where(p => p.MaDV == _madv).First().TrongDM.Value;
                    }
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().Status != null)
                    {
                        if (_ldichvu.Where(p => p.MaDV == _madv).First().Status == 1)
                            chkStatus.Checked = true;
                        else
                            chkStatus.Checked = false;
                    }
                    txtHamLuong.Text = _ldichvu.Where(p => p.MaDV == _madv).First().HamLuong;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().IdTieuNhom != null && _ldichvu.Where(p => p.MaDV == _madv).First().IdTieuNhom.ToString() != "")
                        lupNhom.EditValue = _ldichvu.Where(p => p.MaDV == _madv).First().IdTieuNhom.Value;
                    else
                        lupNhom.EditValue = -1;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().IDNhom != null && _ldichvu.Where(p => p.MaDV == _madv).First().IDNhom.ToString() != "")
                        lupPhanLoai.EditValue = _ldichvu.Where(p => p.MaDV == _madv).First().IDNhom.Value;
                    else
                        lupPhanLoai.EditValue = -1;
                    txtMaQD.Text = _ldichvu.Where(p => p.MaDV == _madv).First().MaQD;
                    txtQCPC.Text = _ldichvu.Where(p => p.MaDV == _madv).First().QCPC;
                    cbo_NhaSX.Text = _ldichvu.Where(p => p.MaDV == _madv).First().NhaSX;
                    txtDangBC.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DangBC;
                    txtNuocSX.Text = _ldichvu.Where(p => p.MaDV == _madv).First().NuocSX;
                    txtDuongDung.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DuongD;
                    txtSoTTqd.Text = _ldichvu.Where(p => p.MaDV == _madv).First().SoTTqd;
                    cboDonVi.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DonVi;
                    lupMaCC.EditValue = _ldichvu.Where(p => p.MaDV == _madv).First().MaCC;
                    txtSoDK.Text = _ldichvu.Where(p => p.MaDV == _madv).First().SoDK;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().DonGia != null)
                        txtDonGia.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DonGia.ToString();
                    else
                        txtDonGia.Text = "";
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().DongY != null && _ldichvu.Where(p => p.MaDV == _madv).First().DongY == 1)
                    {
                        chkDY.Checked = true;
                    }
                    else { panelControl3.Visible = false; chkDY.Checked = false; }
                    cboTTNhap.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TinhTNhap;
                    cboNguonGoc.Text = _ldichvu.Where(p => p.MaDV == _madv).First().NguonGoc;
                    cboBPDung.Text = _ldichvu.Where(p => p.MaDV == _madv).First().BPDung;
                    cboYCSD.Text = _ldichvu.Where(p => p.MaDV == _madv).First().YCSD;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().TyLeSP != null)
                        txtTLHH.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TyLeSP.ToString();
                    else
                        txtTLHH.Text = "";
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().TyLeBQ != null)
                        txtTLBQ.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TyLeBQ.ToString();
                    else
                        txtTLBQ.Text = "";
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().BHTT != null)
                    {
                        txtBHTT.Text = _ldichvu.Where(p => p.MaDV == _madv).First().BHTT.ToString();
                    }
                    else
                    {
                        txtBHTT.Text = "";
                    }
                    txtDonGia2.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DonGia2.ToString();

                    if (_ldichvu.Where(p => p.MaDV == _madv).First().SLMin != null)
                        txtMin.Text = _ldichvu.Where(p => p.MaDV == _madv).First().SLMin.ToString();
                    else txtMin.Text = "";
                    cboDonViN.Text = _ldichvu.Where(p => p.MaDV == _madv).First().DonViN;
                    txtTyLe.Text = "1/" + _ldichvu.Where(p => p.MaDV == _madv).First().TyLeSD;
                    txtSoQD.Text = _ldichvu.Where(p => p.MaDV == _madv).First().SoQD;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().NgayQD != null)
                        dt_NgayCB.DateTime = _ldichvu.Where(p => p.MaDV == _madv).First().NgayQD.Value;
                    else
                        dt_NgayCB.ResetText();
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().SLuong != null)
                        txtSoLuongThau.Text = _ldichvu.Where(p => p.MaDV == _madv).First().SLuong.ToString();
                    else
                        txtSoLuongThau.Text = "0";
                    txtTieuChuan.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TieuChuan;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().LThau != null && _ldichvu.Where(p => p.MaDV == _madv).First().LThau.ToString().Trim() != "")
                        txtLoaiThau.Text = _ldichvu.Where(p => p.MaDV == _madv).First().LThau.Value.ToString();
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().LThuoc != null && _ldichvu.Where(p => p.MaDV == _madv).First().LThuoc.ToString().Trim() != "")
                        txtLoaiThuoc.Text = _ldichvu.Where(p => p.MaDV == _madv).First().LThuoc.Value.ToString();
                    txtNhomThau.Text = _ldichvu.Where(p => p.MaDV == _madv).First().NhomThau;
                    txtMaNhom.Text = _ldichvu.Where(p => p.MaDV == _madv).First().MaNhom;
                    txtTuoiTho.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TuoiTho;
                    lup_MaDuongD.EditValue = _ldichvu.Where(p => p.MaDV == _madv).First().MaDuongDung;
                    if (_ldichvu.Where(p => p.MaDV == _madv).First().SoTT != null)
                        txtSoTT.Text = _ldichvu.Where(p => p.MaDV == _madv).First().SoTT.ToString();
                    else
                        txtSoTT.Text = "";
                    mm_TenRG.Text = _ldichvu.Where(p => p.MaDV == _madv).First().TenRG;
                    txtGiaBHGioiHanTT.Text = _ldichvu.Where(p => p.MaDV == _madv).First().GiaBHGioiHanTT.ToString();
                    usDichVu._loadKPsd(_ldichvu.Where(p => p.MaDV == _madv).First().MaKPsd, _lKPsd, cklKP);
                    List<string> dsgia = _ldichvu.Where(p => p.MaDV == _madv).First().DSDonGia.Split(';').ToList();
                    List<dsgia> _ldsgia = (from a in dsgia select new dsgia { Gia = a }).ToList();
                    grcDSGia.DataSource = null;
                    grcDSGia.DataSource = _ldsgia;
                }
            }
            else
            {
                resetcontrol();
            }

        }
        class dsgia
        {
            string gia;

            public string Gia
            {
                get { return gia; }
                set { gia = value; }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Vssoft.Data.Common.MaBV == "12001")
            {
                if (!PermissionProvider.CheckQuyenFalse("us_dmDuoc")[2])
                {
                    MessageBox.Show("Bạn chưa được cấp quyền xóa thuốc, VTYT ! \nLiên hệ với admin để được cấp quyền");
                    return;
                }
            }
            int ot;
            int madv = 0;
            if (Int32.TryParse(txtMaDV.Text, out ot))
                madv = Convert.ToInt32(txtMaDV.Text);
            var kt = _data.NhapDcts.Where(p => p.MaDV == madv).ToList();
            if (kt.Count > 0)
            {
                MessageBox.Show("thuốc đã được sử dụng, bạn không thể xóa");
            }
            else
            {
                DialogResult _result = MessageBox.Show("Bạn muốn xóa thuốc: " + txtTenDV.Text, "Hỏi xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_result == DialogResult.Yes)
                {
                    var xoa = _data.DichVus.Single(p => p.MaDV == madv);
                    _data.DichVus.Remove(xoa);
                    _data.SaveChanges();
                    us_dmDuoc_Load(sender, e);
                }

            }

        }

        private void grvDichVu_DataSourceChanged(object sender, EventArgs e)
        {

            grvDichVu_FocusedRowChanged(null, null);
        }

        private void chkDY_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDY.Checked == true)
            {
                panelControl3.Visible = true;
            }
            else
            {
                panelControl3.Visible = false;
            }

        }
        private void lupMaCC_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (TTLuu == 2 && Vssoft.Data.Common.MaBV != "06007")
            {
                int ot;
                int madv = 0;
                if (Int32.TryParse(txtMaDV.Text, out ot))
                    madv = Convert.ToInt32(txtMaDV.Text);
                if (lupMaCC.EditValue != null && lupMaCC.EditValue.ToString() != "")
                {
                    var kt = _data.NhapDcts.Where(p => p.MaDV == madv).ToList();
                    if (kt.Count > 0)
                    {
                        DialogResult _result = MessageBox.Show("thuốc đã được sử dụng, bạn vẫn muốn sửa nhà CC", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (_result == DialogResult.No)
                            e.Cancel = true;
                    }
                }
            }
        }

        private void btnKluu_Click(object sender, EventArgs e)
        {
            TTLuu = 0;
            us_dmDuoc_Load(sender, e);

        }

        private void chkDY_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (TTLuu == 2)
            {
                int ot;
                int madv = 0;
                if (Int32.TryParse(txtMaDV.Text, out ot))
                    madv = Convert.ToInt32(txtMaDV.Text);
                if (chkDY.Checked)
                {
                    var kt = _data.NhapDcts.Where(p => p.MaDV == madv).ToList();
                    if (kt.Count > 0)
                    {
                        MessageBox.Show("thuốc đã được sử dụng, bạn không thể sửa");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void txtTenDV_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //FormNhap.frm_danhmucthuocbv frm = new FormNhap.frm_danhmucthuocbv();
            //frm.ShowDialog();
        }

        private void btnUpdateCV5084_Click(object sender, EventArgs e)
        {
            //FormNhap.frm_CNDichVu_5084 frm = new FormNhap.frm_CNDichVu_5084(1);
            //frm.ShowDialog();
        }

        private void btnKhoaPhong_Click(object sender, EventArgs e)
        {
            //FormDanhMuc.usDichVu._updateMaKPsd(1);
        }
        public void _setValue(string tendv, string maqd, int sott, string tenhc, string sodk, string nuocsx, string duongdung, int trongdm, string hamluong, string baoche, string qcpc, string tchuan, string tuoitho, string nhasx, string nguongoc)
        {
            txtTenDV.Text = tendv;
            txtTenHC.Text = tenhc;
            txtMaQD.Text = maqd;
            txtSoTTqd.Text = sott.ToString();
            txtSoDK.Text = sodk;
            txtNuocSX.Text = nuocsx;
            txtDuongDung.Text = duongdung;
            cboTrongDM.SelectedIndex = trongdm;
            txtHamLuong.Text = hamluong;
            txtDangBC.Text = baoche;
            txtQCPC.Text = qcpc;
            txtTieuChuan.Text = tchuan;
            txtTuoiTho.Text = tuoitho;
            cbo_NhaSX.Text = nhasx;
            cboNguonGocnb.Text = nguongoc;
        }

        private void btn5084_Click(object sender, EventArgs e)
        {
            //FormDanhMuc.frm_DM5084 frm = new frm_DM5084();
            //frm.Getdata = new frm_DM5084._setValue(_setValue);
            //frm.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frm_Excell_CV908 frm = new frm_Excell_CV908();
            //frm.ShowDialog();
        }

        private void lup_MaDuongD_EditValueChanged(object sender, EventArgs e)
        {
            if (TTLuu == 1 || TTLuu == 2)
            {
                if (!string.IsNullOrEmpty(lup_MaDuongD.Text))
                {
                    txtDuongDung.Text = _lddung.Where(p => p.MaDuongDung == lup_MaDuongD.Text).Select(p => p.DuongDung1).ToList().Count > 0 ? _lddung.Where(p => p.MaDuongDung == lup_MaDuongD.Text).Select(p => p.DuongDung1).ToList().First() : "";
                }
            }
        }
        void timkiem()
        {
            try
            {

                string _timkiem = "";
                if (!string.IsNullOrEmpty(txtTimKiem.Text) && txtTimKiem.Text != "Tìm Mã|Tên dược|Số đăng ký")
                    _timkiem = txtTimKiem.Text;
                _data = new Hospital();
                _ldichvu.Clear();
                _ldichvu = _data.DichVus.Where(p => p.PLoai == 1).ToList();
                grcDichVu.DataSource = _ldichvu.Where(p => p.TenDV.ToLower().Contains(_timkiem.ToLower()) || p.SoDK == _timkiem || p.MaTam == _timkiem).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void btnUpdateDichVuEx_Click(object sender, EventArgs e)
        {
            //FormNhap.frm_Update_DichVuEx dvEx = new FormNhap.frm_Update_DichVuEx();
            //dvEx.ShowDialog();
        }

        private void btnDongiaDV_Click(object sender, EventArgs e)
        {
            //frm_DonGiaDV frm = new frm_DonGiaDV();
            //frm.ShowDialog();
        }



    }
}
