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
    public partial class usDSKhoaPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public usDSKhoaPhong()
        {
            InitializeComponent();
        }
        Hospital dataContext = new Hospital();
        int TTLuu = 0;
        int Makp = 0;
        private void enableControl(bool T)
        {
            txtDChi.Properties.ReadOnly = !T;
            txtMaKP.Properties.ReadOnly = !T;
            txtTenKP.Properties.ReadOnly = !T;
            cboStatus.Properties.ReadOnly = !T;
            cboPLoai.Properties.ReadOnly = !T;
            lupNhomBP.Properties.ReadOnly = !T;
            cboTrongBV.Properties.ReadOnly = !T;
            cboChuyenKhoa.Properties.ReadOnly = !T;
            txtPPxuatduoc.Properties.ReadOnly = !T;
            memoBuongGiuong.Properties.ReadOnly = !T;
            chk_TuTruc.Properties.ReadOnly = !T;
            cbo_pphhdy.Properties.ReadOnly = !T;
            txtMaQD.Properties.ReadOnly = !T;
            cboQLNT.Properties.ReadOnly = !T;
            lupMaBVSD.Properties.ReadOnly = !T;
            btnLuuKb.Enabled = T;
            btnMoiKb.Enabled = !T;
            btnSuaKb.Enabled = !T;
            btnXoaKb.Enabled = !T;

            grcKhoaPhong.Enabled = !T;
        }
        private void resetControl()
        {
            txtDChi.Text = "";
            txtMaKP.Text = "";
            txtTenKP.Text = "";
            cboStatus.Text = "";
            cboPLoai.Text = "";
            txtMaQD.ResetText();
        }
        private void btnMoiKb_Click(object sender, EventArgs e)
        {
            enableControl(true);
            resetControl();
            TTLuu = 1;
        }
        #region
        private bool KTLuu()
        {
            if (string.IsNullOrEmpty(txtMaKP.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã bộ phận");
                txtMaKP.Focus();
                return false;
            }
            int ot;

            if (!Int32.TryParse(txtMaKP.Text, out ot))
            {
                MessageBox.Show("mã bộ phận không hợp lệ!");
                txtMaKP.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboTrongBV.Text))
            {
                MessageBox.Show("Bạn chưa chọn trong hay ngoài BV");
                cboTrongBV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKP.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên bộ phận");
                txtTenKP.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cboPLoai.Text))
            {
                MessageBox.Show("Bạn chưa chọn phân loại");
                cboPLoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboStatus.Text))
            {
                MessageBox.Show("Bạn chưa chọn trạng thái");
                cboStatus.Focus();
                return false;
            }
            if (cboPLoai.Text == "Khoa dược")
            {
                if (string.IsNullOrEmpty(txtPPxuatduoc.Text))
                {
                    MessageBox.Show("Bạn chưa chọn phương pháp xuất dược");
                    txtPPxuatduoc.Focus();
                    return false;
                }
            }
            if (lupMaBVSD.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn bệnh viện sử dụng!");
                lupMaBVSD.Focus();
                return false;
            }
            return true;
        }
        #endregion
        List<KPhong> _lkhoaphong = new List<KPhong>();
        private void usDSKhoaPhong_Load(object sender, EventArgs e)
        {
            if (Vssoft.Data.Common.MaBV == "01071")
                ckctruccapcuu.Visible = true;
            dataContext = new Hospital();
            lupMaBVSD.Properties.DataSource = dataContext.BenhViens.Where(p => p.Connect).ToList();
            _lkhoaphong = null;
            _lkhoaphong = dataContext.KPhongs.OrderBy(p => p.TenKP).ToList();
            lupNhomBP.Properties.DataSource = _lkhoaphong.Where(p => p.PLoai == ("Lâm sàng") || p.PLoai == ("Phòng khám"));
            lupNhomKPgrv.DataSource = _lkhoaphong;
            grcKhoaPhong.DataSource = null;
            grcKhoaPhong.DataSource = _lkhoaphong.ToList();

            cboChuyenKhoa.Properties.DataSource = Vssoft.Data.Common._lChuyenKhoa.Where(p => p.LoaiCK == 1 || p.LoaiCK == 3).OrderBy(p => p.ChuyenKhoa).ToList();
          
            enableControl(false);
            txtMaKP.Focus();
        }

        private void grvKhoaPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int makp = 0;
            if (grvKhoaPhong.GetFocusedRowCellValue(colMaKP) != null)
            {
                makp = Convert.ToInt32(grvKhoaPhong.GetFocusedRowCellValue(colMaKP));
                txtMaKP.Text = grvKhoaPhong.GetFocusedRowCellValue(colMaKP).ToString();
                if (grvKhoaPhong.GetFocusedRowCellValue(colTenKP) != null && grvKhoaPhong.GetFocusedRowCellValue(colTenKP).ToString() != "")
                {
                    txtTenKP.Text = grvKhoaPhong.GetFocusedRowCellValue(colTenKP).ToString();
                }
                else
                {
                    txtTenKP.Text = "";
                }
                
                if (_lkhoaphong.Where(p => p.MaKP == makp).First().NhomKP != null && _lkhoaphong.Where(p => p.MaKP == makp).First().NhomKP.ToString() != "")
                    lupNhomBP.EditValue = _lkhoaphong.Where(p => p.MaKP == makp).First().NhomKP;
                else
                    lupNhomBP.EditValue = "";
                cboChuyenKhoa.EditValue = _lkhoaphong.Where(p => p.MaKP == makp).First().MaCK;
                if (_lkhoaphong.Where(p => p.MaKP == makp).First().TrongBV != null && _lkhoaphong.Where(p => p.MaKP == makp).First().TrongBV.ToString() != "")
                    cboTrongBV.SelectedIndex = _lkhoaphong.Where(p => p.MaKP == makp).First().TrongBV.Value;
                else
                    cboTrongBV.SelectedIndex = -1;
                cboPLoai.Text = _lkhoaphong.Where(p => p.MaKP == makp).First().PLoai;
                if (_lkhoaphong.Where(p => p.MaKP == makp).First().PPXuat != null && _lkhoaphong.Where(p => p.MaKP == makp).First().PPXuat.ToString() != "")
                {
                    int ppx = _lkhoaphong.Where(p => p.MaKP == makp).First().PPXuat.Value;
                    txtPPxuatduoc.SelectedIndex = ppx;
                }
                else
                    txtPPxuatduoc.SelectedIndex = -1;
               
                txtDChi.Text = _lkhoaphong.Where(p => p.MaKP == makp).First().DChi;
                if (_lkhoaphong.Where(p => p.MaKP == makp).First().PLoai == "Phòng khám" || _lkhoaphong.Where(p => p.MaKP == makp).First().PLoai == "Lâm sàng")
                {
                    if (_lkhoaphong.Where(p => p.MaKP == makp).First().QuanLy == 1)
                        ckctruccapcuu.Checked = true;
                    else
                        ckctruccapcuu.Checked = false;
                }
                else
                    ckctruccapcuu.Checked = false;
                if (_lkhoaphong.Where(p => p.MaKP == makp).First().Status != null)
                {
                    cboStatus.SelectedIndex = _lkhoaphong.Where(p => p.MaKP == makp).First().Status.Value;
                }
                else
                {
                    cboStatus.SelectedIndex = -1;
                }
                if (_lkhoaphong.Where(p => p.MaKP == makp).First().QuanLy != null)
                    cboQLNT.SelectedIndex = _lkhoaphong.Where(p => p.MaKP == makp).First().QuanLy.Value;
                else
                    cboQLNT.SelectedIndex = -1;
                txtMaQD.Text = _lkhoaphong.Where(p => p.MaKP == makp).First().MaQD;
                memoBuongGiuong.Text = _lkhoaphong.Where(p => p.MaKP == makp).First().BuongGiuong;
                cbo_pphhdy.SelectedIndex = _lkhoaphong.Where(p => p.MaKP == makp).First().PPHHDY;
                chk_TuTruc.Checked = _lkhoaphong.Where(p => p.MaKP == makp).First().TuTruc;
                lupMaBVSD.EditValue = _lkhoaphong.Where(p => p.MaKP == makp).First().MaBVsd;
            }
            else
            {
                txtMaKP.Text = "";
            }
        }

        private void btnSuaKb_Click(object sender, EventArgs e)
        {
            enableControl(true);
            txtMaKP.Enabled = false;
            TTLuu = 2;
            txtTenKP.Focus();
        }

        private void btnLuuKb_Click(object sender, EventArgs e)
        {
            if (KTLuu())
            {
                switch (TTLuu)
                {
                    case 1:
                        Makp = Convert.ToInt32(txtMaKP.Text.Trim());
                        var ma = dataContext.KPhongs.Where(p => p.MaKP == Makp).ToList();
                        if (ma.Count > 0)
                        {
                            MessageBox.Show("Mã bộ phận đã có, vui lòng nhập mã khác");
                        }
                        else
                        {
                            KPhong bp = new KPhong();
                            bp.MaKP = Makp;
                            bp.TenKP = txtTenKP.Text;
                            bp.PLoai = cboPLoai.Text;
                            bp.TrongBV = cboTrongBV.SelectedIndex;
                            bp.Status = cboStatus.SelectedIndex;
                            //if (ckctruccapcuu.Checked==true)
                            //    bp.QuanLy = 1;
                            if (lupNhomBP.EditValue != null)
                                bp.NhomKP = Convert.ToInt32(lupNhomBP.EditValue);
                            else
                                bp.NhomKP = 0;
                            bp.DChi = txtDChi.Text;
                            if (!string.IsNullOrEmpty(cboChuyenKhoa.Text))
                            {
                                bp.ChuyenKhoa = cboChuyenKhoa.Text;
                                bp.MaCK = Convert.ToInt32(cboChuyenKhoa.EditValue);
                            }
                            else
                                bp.ChuyenKhoa = "";
                            if (cboPLoai.Text == "Khoa dược" || cboPLoai.Text == "Tủ trực")
                            {
                                bp.PPXuat = txtPPxuatduoc.SelectedIndex;
                                bp.QuanLy = cboQLNT.SelectedIndex;
                            }
                            else if (cboPLoai.Text == "Phòng khám" || cboPLoai.Text == "Lâm sàng")
                            {
                                bp.PPXuat = -1;
                                bp.QuanLy = 1;
                            }
                            else
                            {
                                bp.PPXuat = -1;
                                bp.QuanLy = -1;
                            }
                            if (cboPLoai.Text == "Lâm sàng")
                                bp.PPXuat = txtPPxuatduoc.SelectedIndex;
                            bp.MaQD = txtMaQD.Text.Trim();
                            bp.BuongGiuong = memoBuongGiuong.Text.Trim();
                            bp.PPHHDY = Convert.ToByte(cbo_pphhdy.SelectedIndex);
                            bp.TuTruc = chk_TuTruc.Checked;
                            bp.MaBVsd = lupMaBVSD.EditValue.ToString();
                            dataContext.KPhongs.Add(bp);
                            dataContext.SaveChanges();
                            #region add khoa phòng vào dịch vụ và đơn thuốc
                            var qdv = dataContext.DichVus.Where(p => p.MaKPsd != null).ToList();
                            foreach (var dv in qdv)
                            {
                                dv.MaKPsd = dv.MaKPsd + bp.MaKP + ";";
                            }
                            #endregion
                            dataContext.SaveChanges();
                            enableControl(false);
                            //usDSKhoaPhong_Load(sender, e);
                            TTLuu = 0;
                        }
                        break;



                    case 2:
                        Hospital _data = new Hospital();
                        if (!string.IsNullOrEmpty(txtMaKP.Text))
                        {
                            int makp = Convert.ToInt32(txtMaKP.Text);
                            KPhong bpsua = _data.KPhongs.Single(p => p.MaKP == (makp));
                            bpsua.TenKP = txtTenKP.Text;
                            bpsua.PLoai = cboPLoai.Text;
                            bpsua.TrongBV = cboTrongBV.SelectedIndex;
                            bpsua.Status = cboStatus.SelectedIndex;
                            if (ckctruccapcuu.Checked==true)
                                bpsua.QuanLy = 1;
                            if (lupNhomBP.EditValue != null)
                                bpsua.NhomKP = Convert.ToInt32(lupNhomBP.EditValue);
                            else
                                bpsua.NhomKP = 0;
                            bpsua.DChi = txtDChi.Text.Trim();
                            if (!string.IsNullOrEmpty(cboChuyenKhoa.Text))
                            {
                                bpsua.ChuyenKhoa = cboChuyenKhoa.Text;
                                bpsua.MaCK = Convert.ToInt32(cboChuyenKhoa.EditValue);
                            }
                            else
                                bpsua.ChuyenKhoa = "";
                            if (cboPLoai.Text == "Khoa dược" || cboPLoai.Text == "Tủ trực")
                            {
                                bpsua.PPXuat = txtPPxuatduoc.SelectedIndex;
                                bpsua.QuanLy = cboQLNT.SelectedIndex;
                                bpsua.PPHHDY = Convert.ToByte(cbo_pphhdy.SelectedIndex);
                            }
                            else if (cboPLoai.Text == "Phòng khám" || cboPLoai.Text == "Lâm sàng")
                            {
                                if (ckctruccapcuu.Checked == true)
                                {
                                    bpsua.PPXuat = -1;
                                    bpsua.QuanLy = 1;
                                }
                                else
                                {
                                    bpsua.PPXuat = -1;
                                    bpsua.QuanLy = -1;
                                }
                            }
                            else
                            {
                                bpsua.PPXuat = -1;
                                bpsua.QuanLy = -1;
                            }
                            if (cboPLoai.Text == "Lâm sàng")
                                bpsua.PPXuat = txtPPxuatduoc.SelectedIndex;
                            bpsua.BuongGiuong = memoBuongGiuong.Text.Trim();
                            
                            bpsua.MaQD = txtMaQD.Text.Trim();
                            bpsua.TuTruc = chk_TuTruc.Checked;
                            bpsua.MaBVsd = lupMaBVSD.EditValue.ToString();
                            _data.SaveChanges();
                            enableControl(false);
                            //usDSKhoaPhong_Load(sender, e);
                            TTLuu = 0;
                        }
                        break;
                }
                usDSKhoaPhong_Load(sender, e);

            }
        }
        string _timkiem = "";
        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
                _timkiem = txtTimKiem.Text.ToLower().Trim();
            else
                _timkiem = "";
            grcKhoaPhong.DataSource = _lkhoaphong.Where(p => p.TenKP.ToLower().Contains(_timkiem)).ToList();
        }

        private void btnXoaKb_Click(object sender, EventArgs e)
        {

            int ot;
            int _int_maKP = 0;
            if (Int32.TryParse(txtMaKP.Text, out ot))
                _int_maKP = Convert.ToInt32(txtMaKP.Text);
            if (_int_maKP > 0)
            {
                try
                {
                    DialogResult _result;
                    _result = MessageBox.Show("Bạn muốn xóa khoa|phòng: ", "Xóa khoa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_result == DialogResult.Yes)
                    {
                        var xoa = dataContext.KPhongs.Single(p => p.MaKP == _int_maKP);
                        dataContext.KPhongs.Remove(xoa);
                        dataContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không xóa được!" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có bộ phận để xóa");
            }
        }

        private void lupNhomBP_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (TTLuu == 2 || TTLuu == 1)
            {
                if (lupNhomBP.EditValue != null)
                {
                    if (!string.IsNullOrEmpty(cboPLoai.Text))
                    {
                        if (cboPLoai.Text != "Tủ trực" && cboChuyenKhoa.Text != "Trực cấp cứu")
                        {
                            MessageBox.Show("Những khoa phòng có phân loại là 'Tủ trực' hoặc chuyên khoa 'Trực cấp cứu' mới có nhóm khoa phòng");
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn phân loại");
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(cboPLoai.Text))
                    {
                        if (cboPLoai.Text != "Tủ trực" && cboChuyenKhoa.Text != "Trực cấp cứu")
                        {
                            MessageBox.Show("Những khoa phòng có phân loại là 'Tủ trực' hoặc chuyên khoa 'Trực cấp cứu' mới có nhóm khoa phòng");
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn phân loại");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void cboPLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPPxuatduoc.Properties.Items.Clear();
            bool b = false;
            if (cboPLoai.Text == "Khoa dược" || cboPLoai.Text == "Tủ trực")
            {
                labPPXD.Text = "PP xuất dược:";
                b = true;
                txtPPxuatduoc.Properties.Items.Add("Xuất theo giá trong danh mục");
                txtPPxuatduoc.Properties.Items.Add("Nhập trước xuất trước(có giá ưu tiên)");
                txtPPxuatduoc.Properties.Items.Add("Xuất theo hạn dùng(có giá ưu tiên)");
                txtPPxuatduoc.Properties.Items.Add("Nhập trước xuất trước(theo số lô)");
            }
            chk_TuTruc.Visible = b;
            txtPPxuatduoc.Visible = b;
            labPPXD.Visible = b;
            cboQLNT.Visible = b;
            labQLNT.Visible = b;
            cbo_pphhdy.Visible = b;
            lab_PPDY.Visible = b;
            if (cboPLoai.Text == "Lâm sàng" || cboPLoai.Text == "Phòng khám")
            {
                ckctruccapcuu.Visible = true;
                if (cboPLoai.Text == "Lâm sàng")
                {
                    labPPXD.Visible = true;
                    txtPPxuatduoc.Visible = true;
                    labPPXD.Text = "Số giường KH:";
                    txtPPxuatduoc.Properties.Items.Clear();
                    for (int i = 0; i <= 500; i++)
                    {
                        txtPPxuatduoc.Properties.Items.Add(i);
                    }
                }
            }

        }

        private void cboPLoai_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (TTLuu == 2 || TTLuu == 1)
            {
                lupNhomBP.EditValue = "";
                //lupNhomBP.Text = "";
            }
        }

        private void grvKhoaPhong_DataSourceChanged(object sender, EventArgs e)
        {
            grvKhoaPhong_FocusedRowChanged(null, null);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void memoBuongGiuong_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("cấu trúc nhập buồng giường: \n'tenbuong1{giường1,giường2,...};tenbuong2{giường1,giường2};...'");
        }

        private void memoBuongGiuong_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboPLoai_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPLoai.Text == "Lâm sàng")
            {
                //memoBuongGiuong.Visible = true;
                //labelControl9.Visible = true;
                btnBuongKH.Visible = true;
            }
            else
            {
                //memoBuongGiuong.Visible = false;
                //labelControl9.Visible = false;
                btnBuongKH.Visible = false;
            }
        }

        private void btnChuyenKhoa_Click(object sender, EventArgs e)
        {
            //Frm_Dm_ChuyenKhoa frm = new Frm_Dm_ChuyenKhoa();
            //frm.ShowDialog();
        }

        private void btnBuongKH_Click(object sender, EventArgs e)
        {
            //int makp = 0;
            //if (grvKhoaPhong.GetFocusedRowCellValue(colMaKP) != null)
            //{
            //    makp = Convert.ToInt32(grvKhoaPhong.GetFocusedRowCellValue(colMaKP));
            //    txtMaKP.Text = grvKhoaPhong.GetFocusedRowCellValue(colMaKP).ToString();
            //    QLBV.FormThamSo.frm_NhapBuongGiuongKeKoach frm = new FormThamSo.frm_NhapBuongGiuongKeKoach(makp);
            //    frm.ShowDialog();
            //}
        }
    }
}
