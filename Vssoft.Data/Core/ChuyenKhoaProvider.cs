using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Core
{
    public class ChuyenKhoaProvider
    {
        public static string GetMaCongKham_ChuyenKhoa(int mack)
        {
            try
            {
                var a = Common._lChuyenKhoa.Where(p => p.MaCK == mack).Select(p => p.MaCK_QD).FirstOrDefault();
                string mack_qd = a.ToString("D2");
                return mack_qd + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];
            }
            catch
            {
                return "";
            }
        }
    }
}
