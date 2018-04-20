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
    public partial class us_DmKQMau : DevExpress.XtraEditors.XtraUserControl
    {
        public us_DmKQMau()
        {
            InitializeComponent();
        }
        Hospital dataContext = new Hospital();

        int _TTLuu = 0;
        //int TTXoa = 0;
        string _Makqm = "";
        private void enableControl(bool T)
        {
            txtMaKQ.Properties.ReadOnly = !T;
            txtTenKQ.Properties.ReadOnly = !T;
            txtKetLuan.Properties.ReadOnly = !T;
            txtLoiDan.Properties.ReadOnly = !T;
            txtTenRG.Properties.ReadOnly = !T;
            lupMaDV.Properties.ReadOnly = !T;
            btnLuu.Enabled = T;
            btnMoi.Enabled = !T;
            btnSua.Enabled = !T;
            btnXoa.Enabled = !T;
            grcKQMau.Enabled = !T;
        }
        private void resetControl()
        {
            txtMaKQ.Text = "";
            txtTenKQ.Text = "";
            txtKetLuan.Text = "";
            txtLoiDan.Text = "";
            lupMaDV.Text = "";
            txtTenRG.Text = "";
        }
        #region
        private bool KTLuu()
        {
            if (string.IsNullOrEmpty(txtMaKQ.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã kết quả");
                txtMaKQ.Focus();
                return false;
            }
         
            return true;
        }

        #endregion
        List<KQMau> _lkq = new List<KQMau>();
        private void TimKiem()
        {
            string _tenkq = "";
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
                _tenkq = txtTimKiem.Text.Trim();
           _lkq = (from kq in dataContext.KQMaus where (kq.TenKQ.Contains(_tenkq)) select kq).OrderBy(p => p.TenKQ).ToList();
            grcKQMau.DataSource = _lkq.ToList();
        }
        private void us_DmKQMau_Load(object sender, EventArgs e)
        {
            var q = (from dv in dataContext.DichVus.Where(p=>p.PLoai==2) join tnhom in dataContext.TieuNhomDVs on dv.IdTieuNhom equals tnhom.IdTieuNhom select new { dv.MaDV, dv.TenDV,tnhom.TenRG }).OrderBy(p=>p.TenRG).OrderBy(p=>p.TenDV).ToList();
            lupMaDV.Properties.DataSource = q.ToList();
            _lkq = dataContext.KQMaus.OrderBy(p => p.TenKQ).ToList();
            grcKQMau.DataSource = _lkq;
            enableControl(false);
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            enableControl(true);
            resetControl();
            _TTLuu = 1;
            txtMaKQ.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enableControl(true);
            txtMaKQ.Enabled = false;
            _TTLuu = 2;
            txtTenKQ.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _Makqm = txtMaKQ.Text;
            
                DataRow dr = grvKQMau.GetFocusedDataRow();
                DialogResult dia = MessageBox.Show("Bạn có chắc chắn muốn xóa kết quả mẫu đã chọn?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dia == DialogResult.Yes)
                {
                    var xoa = dataContext.KQMaus.Single(p => p.MaKQ== (_Makqm));
                    dataContext.KQMaus.Remove(xoa);
                    dataContext.SaveChanges();
                    //btnXoa.Enabled = true;

                }
                var _lkq = dataContext.KQMaus.OrderBy(p => p.TenKQ).ToList();
                grcKQMau.DataSource = _lkq.ToList();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KTLuu())
            {
                switch (_TTLuu)
                {
                    case 1:
                        _Makqm = txtMaKQ.Text.Trim();
                        var ma = dataContext.KQMaus.Where(p => p.MaKQ== (_Makqm)).ToList();
                        if (ma.Count > 0)
                        {
                            MessageBox.Show("Mã kết quả mẫu đã có, vui lòng nhập mã khác");
                        }
                        else
                        {
                            KQMau kqm = new KQMau();
                            kqm.MaKQ = txtMaKQ.Text;
                            kqm.MaDV = lupMaDV.EditValue == null ? 0 : Convert.ToInt32(lupMaDV.EditValue);
                            kqm.TenKQ = txtTenKQ.Text;
                            kqm.TenRG = txtTenRG.Text;
                            kqm.KetLuan = txtKetLuan.Text;
                            kqm.LoiDan = txtLoiDan.Text;
                            dataContext.KQMaus.Add(kqm);
                            dataContext.SaveChanges();
                            enableControl(false);
                            MessageBox.Show("Lưu thành công!");
                        }
                        break;

                    case 2:
                        if (!string.IsNullOrEmpty(txtMaKQ.Text))
                        {
                            string makq = txtMaKQ.Text;
                            KQMau kqmsua = dataContext.KQMaus.Single(p => p.MaKQ== (makq));
                            kqmsua.MaKQ = txtMaKQ.Text;
                            kqmsua.MaDV = lupMaDV.EditValue == null ? 0 : Convert.ToInt32(lupMaDV.EditValue);
                            kqmsua.TenKQ = txtTenKQ.Text;
                            kqmsua.TenRG = txtTenRG.Text;
                            kqmsua.KetLuan = txtKetLuan.Text;
                            kqmsua.LoiDan = txtLoiDan.Text;
                            dataContext.SaveChanges();
                            MessageBox.Show("Lưu thành công!");
                            enableControl(false);
                        }
                        break;
                }
                var _lkqm = dataContext.KQMaus.OrderBy(p => p.TenKQ).ToList();
                grcKQMau.DataSource = _lkqm.ToList();
            }
        }

        private void grvKQMau_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvKQMau.GetFocusedRowCellValue(colMaKQ) != null && grvKQMau.GetFocusedRowCellValue(colMaKQ).ToString() != "")
            {
                txtMaKQ.Text = grvKQMau.GetFocusedRowCellValue(colMaKQ).ToString();
                if (grvKQMau.GetFocusedRowCellValue(colMaKQ) != null && grvKQMau.GetFocusedRowCellValue(colMaKQ).ToString() != "")
                {
                    txtMaKQ.Text = grvKQMau.GetFocusedRowCellValue(colMaKQ).ToString();
                }
                else
                {
                    txtMaKQ.Text = "";
                }
                if (grvKQMau.GetFocusedRowCellValue(colMaDV) != null && grvKQMau.GetFocusedRowCellValue(colMaDV).ToString() != "")
                {
                    lupMaDV.EditValue =Convert.ToInt32(grvKQMau.GetFocusedRowCellValue(colMaDV));
                }
                else
                {
                    lupMaDV.EditValue =0;
                }
                if (grvKQMau.GetFocusedRowCellValue(colTenKQ) != null && grvKQMau.GetFocusedRowCellValue(colTenKQ).ToString() != "")
                {
                    txtTenKQ.Text = grvKQMau.GetFocusedRowCellValue(colTenKQ).ToString();
                }
                else
                {
                    txtTenKQ.Text = "";
                }

                if (grvKQMau.GetFocusedRowCellValue(colTenRG) != null && grvKQMau.GetFocusedRowCellValue(colTenRG).ToString() != "")
                {
                    txtTenRG.Text = grvKQMau.GetFocusedRowCellValue(colTenRG).ToString();
                }
                else
                {
                    txtTenRG.Text = "";
                }
                if (grvKQMau.GetFocusedRowCellValue(colKetLuan) != null && grvKQMau.GetFocusedRowCellValue(colKetLuan).ToString() != "")
                {
                    txtKetLuan.Text = grvKQMau.GetFocusedRowCellValue(colKetLuan).ToString();
                }
                else
                {
                    txtKetLuan.Text = "";
                }

                if (grvKQMau.GetFocusedRowCellValue(colLoiDan) != null && grvKQMau.GetFocusedRowCellValue(colLoiDan).ToString() != "")
                {
                    txtLoiDan.Text = grvKQMau.GetFocusedRowCellValue(colLoiDan).ToString();
                }
                else
                {
                    txtLoiDan.Text = "";
                }

            }
            else
            {
                txtMaKQ.Text = "";
            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            string tk = "";
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                tk = txtTimKiem.Text;
            }
            grcKQMau.DataSource = _lkq.Where(p => p.TenKQ.Contains(tk));
        }
    }
}
