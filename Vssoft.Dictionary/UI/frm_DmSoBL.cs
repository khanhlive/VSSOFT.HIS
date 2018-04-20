using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vssoft.ERP.Models;

namespace QLBV.FormDanhMuc
{
    public partial class frm_DmSoBL : DevExpress.XtraEditors.XtraForm
    {
        public frm_DmSoBL()
        {
            InitializeComponent();
        }
        List<SoBienLai> _lSoBienLai;
        Hospital _data;
        private void grvDMSoBL_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDMSoBL.GetFocusedRowCellValue(colPLoai) != null)
                cboPLoai.SelectedIndex = Convert.ToInt32(grvDMSoBL.GetFocusedRowCellValue(colPLoai));
            else
                cboPLoai.SelectedIndex = -1;
            if (grvDMSoBL.GetFocusedRowCellValue(colQuyen) != null)
                txtQuyen.Text = grvDMSoBL.GetFocusedRowCellValue(colQuyen).ToString();
            else
                txtQuyen.Text = "";
            if (grvDMSoBL.GetFocusedRowCellValue(colSoTu) != null)
                txtTuSo.Text = grvDMSoBL.GetFocusedRowCellValue(colSoTu).ToString();
            else
                txtTuSo.Text = "";
            if (grvDMSoBL.GetFocusedRowCellValue(colSoDen) != null)
                txtDenSo.Text = grvDMSoBL.GetFocusedRowCellValue(colSoDen).ToString();
            else
                txtDenSo.Text = "";
            if (grvDMSoBL.GetFocusedRowCellValue(colSoHT) != null)
                txtSoHT.Text = grvDMSoBL.GetFocusedRowCellValue(colSoHT).ToString();
            else
                txtSoHT.Text = "";
            if (grvDMSoBL.GetFocusedRowCellValue(colStatus) != null)
                txtStatus.Text = grvDMSoBL.GetFocusedRowCellValue(colStatus).ToString();
            else
                txtStatus.Text = "";
            if (grvDMSoBL.GetFocusedRowCellValue(colMaCB) != null)
                lupMaCB.EditValue = grvDMSoBL.GetFocusedRowCellValue(colMaCB).ToString();
            else
                lupMaCB.EditValue = "";
        }
        void EnableControl(bool b)
        {
            txtDenSo.ReadOnly = b;
            txtQuyen.ReadOnly = b;
            txtSoHT.ReadOnly = b;
            txtStatus.ReadOnly = b;
            txtTuSo.ReadOnly = b;
            cboPLoai.ReadOnly = b;
            lupMaCB.ReadOnly = b;
            btnMoi.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
        }
        private void frm_DmSoBL_Load(object sender, EventArgs e)
        {
            _data = new Hospital();
            _lSoBienLai = _data.SoBienLais.ToList();
            grcDMSoBL.DataSource = _lSoBienLai;
            EnableControl(true);
        }

        private void grvDMSoBL_DataSourceChanged(object sender, EventArgs e)
        {
            grvDMSoBL_FocusedRowChanged(null, null);
        }
        int TTLuu = 0;
        private void btnMoi_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            TTLuu = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            TTLuu = 2;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            _data = new Hospital();
            if (KT())
            {
                if (TTLuu == 1)// thêm mới
                {
                    SoBienLai moi = new SoBienLai();
                    moi.Quyen = txtQuyen.Text;
                    moi.SoDen = Convert.ToInt32(txtDenSo.Text);
                    moi.SoHT = Convert.ToInt32(txtSoHT.Text);
                    moi.SoTu = Convert.ToInt32(txtTuSo.Text);
                    moi.Status = txtStatus.SelectedIndex;
                    moi.PLoai = cboPLoai.SelectedIndex;
                    if (lupMaCB.EditValue != null)
                        moi.MaCB = lupMaCB.EditValue.ToString();
                    _data.SoBienLais.Add(moi);
                    _data.SaveChanges();

                }
                else
                {
                    string quyen = txtQuyen.Text;
                    int ploai = cboPLoai.SelectedIndex;
                    List<SoBienLai> sobl = _data.SoBienLais.Where(p => p.Quyen == quyen && p.PLoai == ploai).ToList();
                    foreach (var item in sobl)
                    {
                        item.SoDen = Convert.ToInt32(txtDenSo.Text);
                        item.SoHT = Convert.ToInt32(txtSoHT.Text);
                        item.SoTu = Convert.ToInt32(txtTuSo.Text);
                        item.Status = txtStatus.SelectedIndex;
                        if (lupMaCB.EditValue != null)
                            item.MaCB = lupMaCB.EditValue.ToString();
                        _data.SaveChanges();
                    }

                }
                EnableControl(true);
                TTLuu = 0;
                frm_DmSoBL_Load(sender, e);
            }
           
        }
        bool KT()
        {
            if (cboPLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn phân loại");
                cboPLoai.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtQuyen.Text))
            {
                MessageBox.Show("Bạn chưa nhập quyển biên lai");
                txtQuyen.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtTuSo.Text))
            {
                MessageBox.Show("Bạn chưa nhập số biên lai bắt đầu ");
                txtTuSo.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtDenSo.Text))
            {
                MessageBox.Show("Bạn chưa nhập số biên lai kết thúc ");
                txtDenSo.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtSoHT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số biên lai hiện tại");
                txtSoHT.Focus();
                return false;

            }
            if (txtStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái");
                txtStatus.Focus();
                return false;

            }
            int soHT = Convert.ToInt32(txtSoHT.Text);
            int soDen = Convert.ToInt32(txtDenSo.Text);
            int SoTu = Convert.ToInt32(txtTuSo.Text);
            if (soHT > soDen || soHT < SoTu)
            {
                MessageBox.Show("Số hiện tại ngoài giới hạn số biên lai");
                return false;
            }
            return true;

        }
        private void txtSoHT_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}