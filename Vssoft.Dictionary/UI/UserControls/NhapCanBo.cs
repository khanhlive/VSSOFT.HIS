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
    public partial class NhapCanBo : DevExpress.XtraEditors.XtraUserControl
    {
        Hospital dataContext = new Hospital();
        public NhapCanBo()
        {
            InitializeComponent();
        
        }
        private int TTLuu=0;
        private void EnableControl(bool T) {
            txtCapBac.Properties.ReadOnly = !T;
            chkKhoa.Properties.ReadOnly = !T;
            txtChucVu.Properties.ReadOnly = !T;
            txtDiaChi.Properties.ReadOnly = !T;
            txtMaCB.Properties.ReadOnly = !T;
            txtSoDT.Properties.ReadOnly = !T;
            txtTenCB.Properties.ReadOnly = !T;
            txtCCHN.Properties.ReadOnly = !T;
            dtNamSinh.Properties.ReadOnly = !T;
            lupDToc.Properties.ReadOnly = !T;
            lupMaKP.Properties.ReadOnly = !T;
            btnLuuKb.Enabled = T;
            btnMoiKb.Enabled = !T;
            btnSuaKb.Enabled = !T;
            btnXoaKb.Enabled = !T;
            grcCanBo.Enabled = !T;
        }
        private void resetcontrol() {
            txtCapBac.Text = "";
            txtChucVu.Text = "";
            txtDiaChi.Text = "";
            txtMaCB.Text = "";
            txtSoDT.Text = "";
            txtTenCB.Text="";
            txtCCHN.Text = "";
            lupMaKP.EditValue = 0;
            chkKhoa.Checked = false;
        }
        private void grvCanBo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
        }
        #region checkSave
        private  bool checkSave() { 
        if(string.IsNullOrEmpty(txtMaCB.Text)){
        MessageBox.Show("Bạn chưa nhập mã cán bộ");
            txtMaCB.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtTenCB.Text)) {
            MessageBox.Show("Bạn chưa nhập tên cán bộ");
            txtTenCB.Focus();
            return false;
        }
        if (dtNamSinh.EditValue == null) {
            MessageBox.Show("Bạn chưa chọn năm sinh");
            dtNamSinh.Focus();
            return false;
        }
        if (radNamNu.SelectedIndex != 0 || radNamNu.SelectedIndex != 1) {
            MessageBox.Show("Bạn chưa chọn giới tính");
            radNamNu.Focus();
            return false;
        }
        if (lupDToc.EditValue == null)
        {
            MessageBox.Show("Bạn chưa chọn dân tộc");
            lupDToc.Focus();
            return false;
        }
        if (lupMaKP.EditValue == null) {
            MessageBox.Show("Bạn chưa chọn mã khoa phòng");
            lupMaKP.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtChucVu.Text)) {
            MessageBox.Show("Bạn chưa chọn chức vụ");
            txtChucVu.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCapBac.Text)) {
            MessageBox.Show("Bạn chưa chọn cấp bậc");
            txtCapBac.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtSoDT.Text)) {
            MessageBox.Show("Bạn chưa nhập số điện thoại");
            txtSoDT.Focus();
        }
            return true;
        }
        #endregion
        private void grvCanBo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvCanBo.GetFocusedRowCellValue(colMaCB) != null && grvCanBo.GetFocusedRowCellValue(colMaCB).ToString() != "")
            {
                txtMaCB.Text = grvCanBo.GetFocusedRowCellValue(colMaCB).ToString();
                if (grvCanBo.GetFocusedRowCellValue(colTenCB) != null && grvCanBo.GetFocusedRowCellValue(colTenCB).ToString() != "")
                {
                    txtTenCB.Text = grvCanBo.GetFocusedRowCellValue(colTenCB).ToString();
                }
                else {
                    txtTenCB.Text = "";
                }
                if (grvCanBo.GetFocusedRowCellValue(colMaKP) != null )
                {
                    lupMaKP.EditValue= Convert.ToInt32( grvCanBo.GetFocusedRowCellValue(colMaKP));
                }
                else
                {
                    lupMaKP.EditValue = 0;
                }
                if (grvCanBo.GetFocusedRowCellValue(colChucVu) != null && grvCanBo.GetFocusedRowCellValue(colChucVu).ToString() != "")
                {
                    txtChucVu.Text = grvCanBo.GetFocusedRowCellValue(colChucVu).ToString();
                }
                else
                {
                    txtChucVu.Text = "";
                }
                if (grvCanBo.GetFocusedRowCellValue(colCapBac) != null && grvCanBo.GetFocusedRowCellValue(colCapBac).ToString() != "")
                {
                    txtCapBac.Text = grvCanBo.GetFocusedRowCellValue(colCapBac).ToString();
                }
                else
                {
                    txtCapBac.Text = "";
                }
                if (grvCanBo.GetFocusedRowCellValue(colDiaChi) != null && grvCanBo.GetFocusedRowCellValue(colDiaChi).ToString() != "")
                {
                    txtDiaChi.Text = grvCanBo.GetFocusedRowCellValue(colDiaChi).ToString();
                }
                else
                {
                    txtDiaChi.Text = "";
                }
                if (grvCanBo.GetFocusedRowCellValue(colSoDT) != null && grvCanBo.GetFocusedRowCellValue(colSoDT).ToString() != "")
                {
                    txtSoDT.Text = grvCanBo.GetFocusedRowCellValue(colSoDT).ToString();
                }
                else
                {
                    txtSoDT.Text = "";
                }
                if (grvCanBo.GetFocusedRowCellValue(colKhoa) != null && grvCanBo.GetFocusedRowCellValue(colKhoa).ToString() != "")
                {
                    if (grvCanBo.GetFocusedRowCellValue(colKhoa).ToString() == "1")
                        chkKhoa.Checked = true;
                    else
                        chkKhoa.Checked = false;
                }
                else
                {
                    chkKhoa.Checked = false;
                }
                if (grvCanBo.GetFocusedRowCellValue(colCCHN) != null && grvCanBo.GetFocusedRowCellValue(colCCHN).ToString() != "")
                {
                    txtCCHN.Text = grvCanBo.GetFocusedRowCellValue(colCCHN).ToString();
                }
                else
                {
                    txtCCHN.Text = "";
                }
            }
            else {
                txtMaCB.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private bool KTLuu() {
            if(string.IsNullOrEmpty(txtMaCB.Text)){
                MessageBox.Show("Chưa có mã cán bộ");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenCB.Text)) {
                MessageBox.Show("Chưa nhập tên cán bộ!");
                txtTenCB.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(lupMaKP.Text))
            {
                MessageBox.Show("Chưa chọn khoa phòng!");
                lupMaKP.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtChucVu.Text))
            {
                MessageBox.Show("Chưa nhập chức vụ!");
                txtChucVu.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(txtCapBac.Text))
            //{
            //    MessageBox.Show("Chưa nhập cấp bậc!");
            //    txtCapBac.Focus();
            //    return false;
            //}
            return true;
        }
        private void btnLuuKb_Click(object sender, EventArgs e)
        {
            CanBo canbo = new CanBo();

            if (KTLuu())
            {

                switch (TTLuu)
                {
                    case 1:
                        string macb=txtMaCB.Text;
                        var ma=dataContext.CanBoes.Where(p => p.MaCB== (macb)).ToList();
                        if (ma.Count > 0) {
                            MessageBox.Show("Mã cán bộ đã có, vui lòng nhập mã khác");
                        }
                        else
                        {
                            if (chkKhoa.Checked)
                                canbo.Khoa = 1;
                            else
                                canbo.Khoa = 0;
                            canbo.MaCB = txtMaCB.Text;
                            canbo.TenCB = txtTenCB.Text;
                            canbo.MaCCHN = txtCCHN.Text;
                            canbo.MaKP = lupMaKP.EditValue == null ? 0 : Convert.ToInt32(lupMaKP.EditValue);
                            canbo.ChucVu = txtChucVu.Text;
                            canbo.CapBac = txtCapBac.Text;
                            canbo.SoDT = txtSoDT.Text;
                            if (lupDToc.EditValue != null && lupDToc.EditValue.ToString()!="")
                            canbo.MaDT = lupDToc.EditValue.ToString();
                            canbo.DiaChi = txtDiaChi.Text;
                            if (radNamNu.SelectedIndex == 0)
                            {
                                canbo.GioiTinh = 1;
                            }
                            else {
                                canbo.GioiTinh = 0;
                            }
                            dataContext.CanBoes.Add(canbo);
                            if (dataContext.SaveChanges() == 1)
                            {
                                MessageBox.Show("Thêm mới thành công");
                                NhapCanBo_Load(sender, e);
                            }
                        }
                        break;
                    case 2:
                        
                        if (!string.IsNullOrEmpty(txtMaCB.Text))
                        {
                            string id = txtMaCB.Text;
                            CanBo canbosua = dataContext.CanBoes.Single(p => p.MaCB== (id));
                            if (chkKhoa.Checked)
                                canbosua.Khoa = 1;
                            else
                                canbosua.Khoa = 0;
                            canbosua.MaCCHN = txtCCHN.Text;
                            canbosua.TenCB = txtTenCB.Text;
                            canbosua.MaKP = lupMaKP.EditValue == null ? 0 : Convert.ToInt32(lupMaKP.EditValue);
                            canbosua.ChucVu = txtChucVu.Text.Trim();
                            canbosua.CapBac = txtCapBac.Text.Trim();
                            canbosua.SoDT = txtSoDT.Text.Trim();
                            canbosua.DiaChi = txtDiaChi.Text.Trim();
                            if (radNamNu.SelectedIndex == 0)
                            {
                                canbosua.GioiTinh = 1;
                            }
                            else
                            {
                                canbosua.GioiTinh = 0;
                            }
                            if (dataContext.SaveChanges() == 1)
                            {
                                MessageBox.Show("Sửa thành công");
                                NhapCanBo_Load(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show("bạn chưa chọn hoặc không có cán bộ để sửa");
                        }
                        break;
                }

            }
        }
        List<CanBo> _lcanbo = new List<CanBo>();
        private void NhapCanBo_Load(object sender, EventArgs e)
        {
            EnableControl(false);
            lupMaKP.Properties.DataSource = dataContext.KPhongs;
            lupMaKPds.DataSource = dataContext.KPhongs;
            _lcanbo=dataContext.CanBoes.ToList();;
            grcCanBo.DataSource = _lcanbo;
            var datoc = dataContext.DanTocs.ToList();
            lupDToc.Properties.DataSource = datoc.ToList();
            //txt_MaCanBo.DataBindings.Clear();
            //txt_MaCanBo.DataBindings.Add("Text", dataContext.CanBoes, "TenCB");
            var dt = dataContext.KPhongs.Where(p => p.MaKP== (Vssoft.Data.Common.MaKP)).ToList();
            if (dt.Count > 0 && dt.First().PLoai == "Admin")
            {
                panelControl4.Enabled = true;
            }
            else
                panelControl4.Enabled = false;

        }

        private void btnMoiKb_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            resetcontrol();
            txtTenCB.Focus();
            TTLuu = 1;
            
        }

        private void btnSuaKb_Click(object sender, EventArgs e)
        {
            EnableControl(true);
                TTLuu=2;
                txtTenCB.Focus();
                txtMaCB.Enabled = false;
          
        }

        private void txtMaCB_TextChanged(object sender, EventArgs e)
        {

        }
        string _timkiem = "";
        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
                _timkiem = txtTimKiem.Text.ToLower().Trim();
            else
                _timkiem = "";
            grcCanBo.DataSource = _lcanbo.Where(p => p.TenCB.ToLower().Contains(_timkiem)).ToList();
        }

        private void grcCanBo_DataSourceChanged(object sender, EventArgs e)
        {
            grvCanBo_FocusedRowChanged(null, null);
        }

        private void grvCanBo_DataSourceChanged(object sender, EventArgs e)
        {
            grvCanBo_FocusedRowChanged(null, null);
        }

        private void btnXoaKb_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaCB.Text))
            {
                var ktdtct = dataContext.DThuoccts.Where(p => p.MaCB == txtMaCB.Text).ToList();
                if (ktdtct.Count > 0)
                {
                    MessageBox.Show(txtTenCB.Text+ " đã được sử dụng, bạn không thể xóa");
                    return;

                }
                var ktdt = dataContext.DThuocs.Where(p => p.MaCB == txtMaCB.Text).ToList();
                if (ktdt.Count > 0)
                {
                    MessageBox.Show(txtTenCB.Text + " đã được sử dụng, bạn không thể xóa");
                    return;

                }
                var ktnd = dataContext.NhapDs.Where(p => p.MaCB == txtMaCB.Text).ToList();
                if (ktnd.Count > 0)
                {
                    MessageBox.Show(txtTenCB.Text + " đã được sử dụng, bạn không thể xóa");
                    return;

                }
                try { 
               var _lcb = dataContext.CanBoes.Single(p => p.MaCB == txtMaCB.Text);
               dataContext.CanBoes.Remove(_lcb);
               dataContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: "+ex.Message);

                }
            }
        }

       
        

    }
}
