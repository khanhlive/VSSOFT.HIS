using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Models
{
    
    #region class Báo cáo
    public class CLS_Report
    {
        private string tenbc;
        private int id;
        private string ploai;
        private string mabv;
        private string kieu, nhom;
        private bool _public;
        private bool _Public
        {
            set { _public = value; }
            get { return _public; }
        }
        public string Nhom
        {
            set { nhom = value; }
            get { return nhom; }
        }
        public string Kieu
        {
            set { kieu = value; }
            get { return kieu; }
        }
        public string MaBV
        {
            set { mabv = value; }
            get { return mabv; }
        }
        public string TenBC
        {
            set { tenbc = value; }
            get { return tenbc; }
        }
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        public string Loai
        {
            set { ploai = value; }
            get { return ploai; }
        }

    }
    #endregion
}
