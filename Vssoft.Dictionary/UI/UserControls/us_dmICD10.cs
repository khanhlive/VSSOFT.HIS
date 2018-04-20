using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.IO;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.UserControls
{
    public partial class us_dmICD10 : DevExpress.XtraEditors.XtraUserControl
    {
        public us_dmICD10()
        {
            InitializeComponent();
        }
        int TTLuu = 0;
        //int TTXoa = 0;
        string _MaICD = "";
        private void enableControl(bool T)
        {
            txtMaICD.Enabled = T;
            txtTenICD.Enabled = T;
            txtTenCB.Enabled = T;
            cboStatus.Enabled = T;
            btnLuuKb.Enabled = T;
            btnMoiKb.Enabled = !T;
            btnSuaKb.Enabled = !T;
            btnXoaKb.Enabled = !T;
            grcICD.Enabled = !T;
        }
        private void resetControl()
        {
            txtMaICD.Text = "";
            txtTenICD.Text = "";
            txtTenCB.Text = "";
            cboStatus.Text = "";
        }
        #region KTLuu
        private bool KTLuu()
        {
            if (string.IsNullOrEmpty(txtMaICD.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã ICD");
                txtMaICD.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenICD.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên ICD");
                txtTenICD.Focus();
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
        List<ICD10> _lICD = new List<ICD10>();

        private void us_dmICD10_Load(object sender, EventArgs e)
        {
            //var icd = (from icd10 in dataContext.ICD10 select new {icd10.MaICD, icd10.TenICD, icd10.TenCB }).ToList();
            _lICD = dataContext.ICD10.OrderBy(p => p.MaICD).ToList();
                grcICD.DataSource = _lICD;
                enableControl(false);
          
        }

       
        private void grvICD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvICD.GetFocusedRowCellValue(colMaICD) != null && grvICD.GetFocusedRowCellValue(colMaICD).ToString() != "")
            {
                txtMaICD.Text = grvICD.GetFocusedRowCellValue(colMaICD).ToString();
                if (grvICD.GetFocusedRowCellValue(colTenICD) != null && grvICD.GetFocusedRowCellValue(colTenICD).ToString() != "")
                {
                    txtTenICD.Text = grvICD.GetFocusedRowCellValue(colTenICD).ToString();
                }
                else
                {
                    txtTenICD.Text = "";
                }
                 if (grvICD.GetFocusedRowCellValue(colMSCB) != null && grvICD.GetFocusedRowCellValue(colMSCB).ToString() != "")
                {
                    txtMSCB.Text = grvICD.GetFocusedRowCellValue(colMSCB).ToString();
                }
                else
                {
                    txtMSCB.Text = "";
                }
                if (grvICD.GetFocusedRowCellValue(colTenCB) != null && grvICD.GetFocusedRowCellValue(colTenCB).ToString() != "")
                {
                    txtTenCB.Text = grvICD.GetFocusedRowCellValue(colTenCB).ToString();
                }
                else
                {
                    txtTenCB.Text = "";
                }
                if (grvICD.GetFocusedRowCellValue(colStatus) != null && grvICD.GetFocusedRowCellValue(colStatus).ToString() != "")
                {
                    int a = int.Parse(grvICD.GetFocusedRowCellValue(colStatus).ToString());
                    switch (a)
                    {
                        case 1:
                            cboStatus.SelectedIndex = 0;
                            break;
                        case 0:
                            cboStatus.SelectedIndex = 1;
                            break;
                    }
                }
                else
                {
                    cboStatus.Text = "";
                }
            }
            else
            {
                txtMaICD.Text = "";
            }
        }

           

        private void btnLuuKb_Click_1(object sender, EventArgs e)
        {
            if (KTLuu())
            {
                switch (TTLuu)
                {
                    case 1:
                        _MaICD = txtMaICD.Text.Trim();
                        var ma = dataContext.ICD10.Where(p => p.MaICD== (_MaICD)).ToList();
                        if (ma.Count > 0)
                        {
                            MessageBox.Show("Mã ICD đã có, vui lòng nhập mã khác");
                        }
                        else
                        {
                            ICD10 icd = new ICD10();
                            icd.MaICD = txtMaICD.Text;
                            icd.TenICD = txtTenICD.Text;
                            icd.MSCB = txtMSCB.Text;
                            icd.TenCB = txtTenCB.Text;
                            if (cboStatus.SelectedIndex == 0)
                                icd.Status = 1;
                            else
                            {
                                if (cboStatus.SelectedIndex == 1)
                                {
                                    icd.Status = 0;
                                }
                            }
                            //bp.Status = cboStatus.Text.ToString();
                            dataContext.ICD10.Add(icd);
                            dataContext.SaveChanges();
                            enableControl(false);
                            MessageBox.Show("Lưu thành công!");
                        }
                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(txtMaICD.Text))
                        {
                            string maICD = txtMaICD.Text;
                            ICD10 icdsua = dataContext.ICD10.Single(p => p.MaICD== (maICD));
                            icdsua.TenICD = txtTenICD.Text;
                            icdsua.MSCB = txtMSCB.Text;
                            icdsua.TenCB = txtTenCB.Text;
                            if (cboStatus.SelectedIndex == 0)
                                icdsua.Status = 1;
                            else
                            {
                                if (cboStatus.SelectedIndex == 1)
                                {
                                    icdsua.Status = 0;
                                }
                            }
                            dataContext.SaveChanges();
                            MessageBox.Show("Lưu thành công!");
                            enableControl(false);
                        }
                        break;
                }
                _lICD = dataContext.ICD10.OrderBy(p => p.MaICD).ToList();
                grcICD.DataSource = _lICD.ToList();
                //var icd = (from icd10 in dataContext.ICD10 select new { icd10.MaICD, icd10.TenICD, icd10.TenCB }).ToList();
                //grcICD.DataSource = icd;
            }
        }

        private void btnMoiKb_Click_1(object sender, EventArgs e)
        {
            enableControl(true);
            resetControl();
            TTLuu = 1;
            cboStatus.SelectedIndex = 0;
            txtMaICD.Focus();
        }

        private void btnSuaKb_Click_1(object sender, EventArgs e)
        {
            enableControl(true);
            txtMaICD.Enabled = false;
            TTLuu = 2;
            txtTenICD.Focus();
        }

        private void btnXoaKb_Click_1(object sender, EventArgs e)
        {
            _MaICD = txtMaICD.Text;
            var ma = dataContext.BNKBs.Where(p => p.MaICD== (_MaICD)).ToList();
            if (ma.Count > 0)
            {
                MessageBox.Show("Mã ICD đã được sử dụng, Bạn không thể xóa.");
            }
            else
            {
                DataRow dr = grvICD.GetFocusedDataRow();
                DialogResult dia = MessageBox.Show("Bạn có chắc chắn muốn xóa ICD đã chọn?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dia == DialogResult.Yes)
                {
                    var xoa = dataContext.ICD10.Single(p => p.MaICD== (_MaICD));
                    dataContext.ICD10.Remove(xoa);
                    dataContext.SaveChanges();
                    btnXoaKb.Enabled = true;

                }
                _lICD = dataContext.ICD10.OrderBy(p => p.MaICD).ToList();
                grcICD.DataSource = _lICD.ToList();
                //var icd = (from icd10 in dataContext.ICD10 select new { icd10.MaICD, icd10.TenICD, icd10.TenCB }).ToList();
                //grcICD.DataSource = icd;
            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            string tk = "";
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                tk = txtTimKiem.Text;
            }
            grcICD.DataSource = _lICD.Where(p => p.MaICD.Contains(tk) || p.TenICD.Contains(tk));
           
        }

        private void btnDM_Click(object sender, EventArgs e)
        {
            //FormNhap.frm_CapNhatDanhMucICD frm = new FormNhap.frm_CapNhatDanhMucICD();
            //frm.ShowDialog();
        }
    }
}
