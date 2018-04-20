using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.UserControls
{
    public partial class us_DmBenhVien : DevExpress.XtraEditors.XtraUserControl
    {
        public us_DmBenhVien()
        {
            InitializeComponent();
        }
        int TTLuu = 0;
        //int TTXoa = 0;
        string Mabv = "";
        private void enableControl(bool T)
        {
            txtMaBV.Properties.ReadOnly = !T;
            txtTenBV.Properties.ReadOnly = !T;
            txtDiaChi.Properties.ReadOnly = !T;
            txtMaTinh.Properties.ReadOnly = !T;
            txtMaHuyen.Properties.ReadOnly = !T;
            txtMaChuQuan.Properties.ReadOnly = !T;
            cmbTuyenBV.Properties.ReadOnly = !T;
            txtHangBV.Properties.ReadOnly = !T;
            cboStatus.Properties.ReadOnly = !T;
            chkConnect.Properties.ReadOnly = !T;
            btnLuuBV.Enabled = T;
            btnMoiBV.Enabled = !T;
            btnSuaBV.Enabled = !T;
            grcBenhVien.Enabled = !T;
        }
        private void resetControl()
        {
            txtMaBV.Text = "";
            txtTenBV.Text = "";
            txtDiaChi.Text = "";
            txtMaTinh.Text = "";
            txtMaHuyen.Text = "";
            txtMaChuQuan.Text = "";
            txtHangBV.Text = "";
            cmbTuyenBV.Text = "";
            cboStatus.Text = "";
            chkConnect.Checked = false;
        }
        #region
        private bool KTLuu()
        {
            if (string.IsNullOrEmpty(txtMaBV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã bệnh viện");
                txtMaBV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenBV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên bệnh viện");
                txtTenBV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ bệnh viện");
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaTinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã tỉnh của bệnh viện");
                txtMaTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaHuyen.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã huyện của bệnh viện");
                txtMaHuyen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaChuQuan.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã chủ quản bệnh viện");
                txtMaChuQuan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmbTuyenBV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tuyến bệnh viện");
                cmbTuyenBV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboStatus.Text))
            {
                MessageBox.Show("Bạn chưa chọn trạng thái");
                cboStatus.Focus();
                return false;
            }
            return true;
        }

        #endregion
        Hospital dataContext = new Hospital();
        List<BenhVien> _lBVien = new List<BenhVien>();

        private void btnMoiKb_Click(object sender, EventArgs e)
        {
            enableControl(true);
            resetControl();
            TTLuu = 1;
            cboStatus.SelectedIndex = 0;
            txtMaBV.Focus();
        }

        private void btnSuaKb_Click(object sender, EventArgs e)
        {
            enableControl(true);
            txtMaBV.Properties.ReadOnly = true;
            TTLuu = 2;
            txtTenBV.Focus();
        }

    
        private void btnLuuKb_Click(object sender, EventArgs e)
        {
            if (KTLuu())
            {
                switch (TTLuu)
                {
                    case 1:
                        Mabv = txtMaBV.Text.Trim();
                        var ma = dataContext.BenhViens.Where(p => p.MaBV== (Mabv)).ToList();
                        if (ma.Count > 0)
                        {
                            MessageBox.Show("Mã bệnh viện đã có, vui lòng nhập mã khác");
                        }
                        else
                        {
                            BenhVien bv = new BenhVien();
                            bv.MaBV = txtMaBV.Text;
                            bv.TenBV = txtTenBV.Text;
                            bv.DiaChi = txtDiaChi.Text;
                            bv.MaTinh = txtMaTinh.Text;
                            bv.MaHuyen = txtMaHuyen.Text;
                            bv.MaChuQuan = txtMaChuQuan.Text;
                            if (!string.IsNullOrEmpty(txtHangBV.Text))
                                bv.HangBV = Convert.ToInt32(txtHangBV.Text);
                            else
                                bv.HangBV = -1;
                            bv.TuyenBV = cmbTuyenBV.Text;
                            bv.status = cboStatus.SelectedIndex;
                            bv.Connect = chkConnect.Checked;
                            dataContext.BenhViens.Add(bv);
                            dataContext.SaveChanges();
                            enableControl(false);
                            MessageBox.Show("Lưu thành công!");
                         }
                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(txtMaBV.Text))
                        {
                            string mabv = txtMaBV.Text;
                            BenhVien bvsua = dataContext.BenhViens.Single(p => p.MaBV== (mabv));
                            bvsua.TenBV = txtTenBV.Text;
                            bvsua.DiaChi = txtDiaChi.Text;
                            bvsua.MaTinh = txtMaTinh.Text;
                            bvsua.MaHuyen = txtMaHuyen.Text;
                            bvsua.MaChuQuan = txtMaChuQuan.Text;
                            if (!string.IsNullOrEmpty(txtHangBV.Text))
                            bvsua.HangBV = Convert.ToInt32(txtHangBV.Text);
                            else
                                bvsua.HangBV = -1;
                            bvsua.TuyenBV = cmbTuyenBV.Text;
                            bvsua.status = cboStatus.SelectedIndex;
                            bvsua.Connect = chkConnect.Checked;
                            dataContext.SaveChanges();
                            MessageBox.Show("Lưu thành công!");
                            enableControl(false);
                         }
                        break;
                }
                _lBVien = dataContext.BenhViens.OrderBy(p => p.TenBV).ToList();
                grcBenhVien.DataSource = _lBVien.ToList();
            }
        }

        private void us_DmBenhVien_Load(object sender, EventArgs e)
        {
            _lBVien = dataContext.BenhViens.OrderBy(p => p.MaTinh).OrderBy(p=>p.MaHuyen).ToList();
            grcBenhVien.DataSource = _lBVien;
            enableControl(false);

        }

        private void grvBenhVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvBenhVien.GetFocusedRowCellValue(colMaBV) != null && grvBenhVien.GetFocusedRowCellValue(colMaBV).ToString() != "")
            {
                txtMaBV.Text = grvBenhVien.GetFocusedRowCellValue(colMaBV).ToString();
                var benhvien = _lBVien.Where(p => p.MaBV == txtMaBV.Text).FirstOrDefault();
                if (benhvien != null)
                {
                    txtTenBV.Text = benhvien.TenBV;
                    txtDiaChi.Text = benhvien.DiaChi;
                    txtMaTinh.Text = benhvien.MaTinh;
                    txtMaHuyen.Text = benhvien.MaHuyen;
                    txtMaChuQuan.Text = benhvien.MaChuQuan;
                    txtHangBV.Text = benhvien.HangBV == null ? "" : benhvien.HangBV.ToString();
                    cmbTuyenBV.Text = benhvien.TuyenBV;
                    cboStatus.SelectedIndex = benhvien.status ?? -1;
                   
                    chkConnect.Checked = benhvien.Connect;
                }
                else
                {
                    txtTenBV.Text = "";
                    txtDiaChi.Text = "";
                    txtMaTinh.Text = "";
                    txtMaChuQuan.Text = "";
                    txtMaHuyen.Text = "";
                    txtHangBV.Text = "";
                    cmbTuyenBV.Text = "";
                    cboStatus.SelectedIndex = -1;
                }
            }
            else
            {
                txtTenBV.Text = "";
                txtDiaChi.Text = "";
                txtMaTinh.Text = "";
                txtMaChuQuan.Text = "";
                txtMaHuyen.Text = "";
                txtHangBV.Text = "";
                cmbTuyenBV.Text = "";
                txtMaBV.Text = "";
                cboStatus.SelectedIndex = -1;
            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            string tk = "";
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                tk = txtTimKiem.Text;
            }
            var bv=(from ds in dataContext.BenhViens
                   where (ds.MaBV.Contains(tk)|| ds.TenBV.ToLower().Contains(tk)) select ds).OrderBy(p => p.MaTinh).OrderBy(p=>p.MaHuyen).ToList();
            grcBenhVien.DataSource = bv;
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            us_DmBenhVien_Load(sender, e);
        }

        private void grvBenhVien_DataSourceChanged(object sender, EventArgs e)
        {
            grvBenhVien_FocusedRowChanged(null, null);
        }
    }
}
