using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class BHYTProvider
    {
        #region Kiểm tra thẻ theo ngày
        public static string KTTheBHYT(Hospital DataContext, string sthe, DateTime ngay)
        {
            try
            {
                if (!string.IsNullOrEmpty(sthe))
                {
                    var kt = DataContext.BenhNhans.Where(p => p.NNhap.Value.Day == (ngay.Day)).Where(p => p.NNhap.Value.Month == (ngay.Month)).Where(p => p.NNhap.Value.Year == (ngay.Year)).Where(p => p.SThe == (sthe)).ToList();
                    if (kt.Count > 0)
                    {
                        int makp = kt.First().MaKP.Value;
                        var tenkp = DataContext.KPhongs.Where(p => p.MaKP == makp).Select(p => p.TenKP).DefaultIfEmpty();
                        return tenkp.First();
                    }
                    else
                        return "";
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";

            }
        }
        #endregion
        #region Kiểm tra thẻ nhập trong tuần
        public static string KTTheBHYT(Hospital DataContext, string sthe, DateTime ngay, int tuan)
        {
            try
            {
                if (!string.IsNullOrEmpty(sthe))
                {
                    {
                        if (!string.IsNullOrEmpty(sthe))
                        {
                            var kt2 = DataContext.BenhNhans.Where(p => p.SThe == (sthe)).OrderBy(p => p.NNhap).ToList();

                            if (kt2.Count > 0)
                            {
                                foreach (var a in kt2)
                                {
                                    if (FormatHelper.GetWeekOrderInYear(ngay) == FormatHelper.GetWeekOrderInYear(a.NNhap.Value))
                                    {

                                        int makp = kt2.First().MaKP.Value;
                                        var tenkp = DataContext.KPhongs.Where(p => p.MaKP == makp).Select(p => p.TenKP).DefaultIfEmpty();
                                        return tenkp.First();

                                    }
                                    // kiểm tra ra viện
                                    var rv = DataContext.RaViens.Where(p => p.MaBNhan == a.MaBNhan).OrderBy(p => p.NgayRa).FirstOrDefault();
                                    if (rv != null && rv.NgayRa != null)
                                    {
                                        if (FormatHelper.GetWeekOrderInYear(ngay) == FormatHelper.GetWeekOrderInYear(rv.NgayRa.Value))
                                        {

                                            int makp = rv.MaKP.Value;
                                            var tenkp = DataContext.KPhongs.Where(p => p.MaKP == makp).Select(p => p.TenKP).DefaultIfEmpty();
                                            return tenkp.First();

                                        }
                                    }
                                }
                            }
                            return "";
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";

            }
        }
        #endregion
    }
}
