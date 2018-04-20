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
    public partial class CLS : DevExpress.XtraEditors.XtraUserControl
    {
        public CLS()
        {
            InitializeComponent();
        }

        Hospital _data = new Hospital();
        private void btnOK_Click(object sender, EventArgs e)
        {
            var q = _data.BenhNhans.ToList();
            grcCLS.DataSource = q.ToList();
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
