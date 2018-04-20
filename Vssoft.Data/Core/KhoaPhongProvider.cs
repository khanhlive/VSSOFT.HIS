using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Core
{
    public class KhoaPhongProvider
    {
        public static List<LKhoaPhong> Empty
        {
            get
            {
                List<LKhoaPhong> _lkp = new List<LKhoaPhong>();
                LKhoaPhong _l = new LKhoaPhong();
                _l.TenKP = " None";
                _l.MaKP = 0;
                _l.PLoai = "";
                _lkp.Add(_l);

                return _lkp;
            }
        }
        public static List<LKhoaPhong> All
        {
            get
            {
                List<LKhoaPhong> _lkp = new List<LKhoaPhong>();
                LKhoaPhong _l = new LKhoaPhong();
                _l.TenKP = " Tất cả";
                _l.MaKP = 0;
                _l.PLoai = "";
                _lkp.Add(_l);

                return _lkp;
            }
        }

    }
    public class LKhoaPhong
    {
        public string tenkp;
        public int makp;
        public string ploai;
        public string TenKP
        {
            set { tenkp = value; }
            get { return tenkp; }
        }
        public int MaKP
        {
            set { makp = value; }
            get { return makp; }
        }
        public string PLoai
        {
            set { ploai = value; }
            get { return ploai; }
        }
    }
}
