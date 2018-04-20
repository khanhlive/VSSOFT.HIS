using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class PhieuLinhProvider
    {
        public static bool isHasSoPhieuLinh(Hospital data, int iddon)
        {
            var kt = data.DThuocs.Where(p => p.IDDon == iddon).Select(p => p.SoPL).ToList();
            if (kt.Count > 0)
            {
                if (kt.First() != null && kt.First().ToString() != "")
                {
                    if (kt.First() > 0)
                        return true;
                    else
                        return false;
                }
                else return false;

            }
            return false;
        }

        public static int GetSoPL(int ploai, int maKP, int noiNgoaiTru)
        {
            //Hospital data = new Hospital();
            //int soPL = 1;
            //try
            //{
            //    var sopl = data.SoPLs
            //        // .Where(p => maKP == 0 ? true : p.MaKP == maKP)
            //        .Where(p => maKP == 0 ? true : p.MaKP == maKP)
            //        .Where(p => p.PhanLoai == ploai)
            //        .Where(p => p.NoiTru == noiNgoaiTru)
            //        .Select(p => p.SoPL1).ToList();
            //    if (sopl.Count > 0)
            //    {
            //        soPL += sopl.Max();
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //}
            //return soPL;
            return 1313;
        }

        public static bool SetSoPL(int maKP, int _soPL, int ploai, int noiNgoaiTru)
        {
            //try
            //{
            //    Hospital data = new Hospital(DungChung.Bien.StrCon);
            //    int soht = _soPL - 1;
            //    var qvv = data.SoPLs.Where(p => p.MaKP == maKP && p.PhanLoai == ploai && p.SoPL1 == soht).Where(p => p.NoiTru == noiNgoaiTru).ToList();// thiếu set theo nội ngoại trú

            //    foreach (var a in qvv)
            //    {
            //        data.DeleteObject(a);
            //    }
            //    data.SaveChanges();
            //    SoPL soPLMoi = new SoPL();
            //    soPLMoi.MaKP = maKP;
            //    soPLMoi.SoPL1 = _soPL;
            //    soPLMoi.Status = 1;
            //    soPLMoi.PhanLoai = ploai;
            //    soPLMoi.NoiTru = noiNgoaiTru;
            //    data.SoPLs.AddObject(soPLMoi);
            //    data.SaveChanges();
            //    return true;

            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            return true;
        }

        public static bool SetStatusSoPL(int maKP, int _soPL, int ploai, int noiNgoaiTru)
        {
            //try
            //{
            //    Hospital data = new Hospital(DungChung.Bien.StrCon);
            //    var soPLMoi = data.SoPLs.Where(p => p.MaKP == maKP && p.SoPL1 == _soPL && p.PhanLoai == ploai).Where(p => p.NoiTru == noiNgoaiTru).ToList();
            //    foreach (var item in soPLMoi)
            //    {
            //        item.Status = 0;
            //        data.SaveChanges();
            //    }
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            return true;
        }

        public static bool CheckSoPL(int maKP, int _soPL, int ploai, int noiNgoaiTru)
        {

            //Hospital data = new Hospital(DungChung.Bien.StrCon);
            //var check = data.SoPLs.Where(p => p.MaKP == maKP && p.SoPL1 == _soPL && p.PhanLoai == ploai).Where(p => p.NoiTru == noiNgoaiTru).FirstOrDefault();
            //if (check != null)
            //    return true;
            return false;
        }
    }
}
