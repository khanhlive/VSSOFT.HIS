using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vssoft.ERP.Models;

namespace Vssoft.Dictionary.UI.UserControls
{
    public partial class dmDoiTuongcs : DevExpress.XtraEditors.XtraUserControl
    {
        public dmDoiTuongcs()
        {
            InitializeComponent();
        }

        List<DTuong> l_Dt = new List<DTuong>();
        Hospital _data = new Hospital();
        private void dmDoiTuongcs_Load(object sender, EventArgs e)
        {
             _data = new Hospital();
            l_Dt = _data.DTuongs.OrderBy(p => p.MaDTuong).ToList();
            gridControl1.DataSource = l_Dt;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn lưu thay đổi?", "Hỏi lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { 
            _data.SaveChanges();
            MessageBox.Show("Lưu thành công");
            }
            else
            {
                dmDoiTuongcs_Load(sender, e);
            }
        }
    }
}
