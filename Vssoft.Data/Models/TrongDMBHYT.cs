using System.Collections.Generic;

namespace Vssoft.Data.Models
{
    public class TrongDMBHYT
    {
        string ten;
        int _value;
        public string Ten_TrongBH
        {
            set { ten = value; }
            get { return ten; }
        }
        public int TrongBH
        {
            set { _value = value; }
            get { return _value; }
        }
        public static List<TrongDMBHYT> GetList
        {
            get
            {
                List<TrongDMBHYT> _lTrongDMBH = new List<TrongDMBHYT>();
                _lTrongDMBH.Add(new TrongDMBHYT { TrongBH = 0, Ten_TrongBH = "Ngoài DMBH" });
                _lTrongDMBH.Add(new TrongDMBHYT { TrongBH = 1, Ten_TrongBH = "Trong DMBH" });
                _lTrongDMBH.Add(new TrongDMBHYT { TrongBH = 2, Ten_TrongBH = "Không TT" });
                _lTrongDMBH.Add(new TrongDMBHYT { TrongBH = 3, Ten_TrongBH = "Phụ thu" });
                return _lTrongDMBH;
            }
        }
    }
}
