using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Models;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class NhapDuocProvider
    {
        public static DateTime? GetHanDung(int madv, string solo)
        {
            Hospital _db = new Hospital();
            var handung = (from nd in _db.NhapDs.Where(p => p.PLoai == 1)
                           join ndct in _db.NhapDcts.Where(p => p.MaDV == madv && p.SoLo == solo && p.HanDung != null) on nd.IDNhap equals ndct.IDNhap
                           select ndct.HanDung).FirstOrDefault();
            if (handung == null)
                return null;
            else
                return handung.Value.Date;
        }

        public static bool KiemTraSoLoDaSuDung(int makho, int madv, string solo, double dongia)
        {
            Hospital data = new Hospital();
            var _gia2 = (from nhap in data.NhapDs.Where(p => p.PLoai == 2).Where(p => p.MaKP == makho)
                         join nhapct in data.NhapDcts.Where(p => p.MaDV == madv).Where(p => p.DonGia == dongia && p.SoLo == solo) on nhap.IDNhap equals nhapct.IDNhap
                         select new { nhapct }).ToList();
            if (_gia2.Count > 0)
            {
                return true;
            }

            else
            {
                var slkd2 = (from sl in data.DThuoccts.Where(p => p.MaDV == madv).Where(p => p.DonGia == dongia && p.SoLo == solo)
                             join kd in data.DThuocs.Where(p => p.Status == 0).Where(p => p.MaKXuat == makho) on sl.IDDon equals kd.IDDon
                             select new { sl.DonGia, sl.SoLuong }).ToList();
                if (slkd2.Count > 0)
                    return true;
                return false;
            }
        }

        public static double KiemTraSoLuongThuocTonKho(Hospital data, int maDV, int makho, double gia, double soluongke, string solo)
        {
            double soluong = -1;
            var ppxuat = data.KPhongs.Where(p => p.MaKP == makho).Select(p => p.PPXuat).FirstOrDefault();
            int pp = ppxuat == null ? -1 : ppxuat.Value;

            var _gia2 = (from nhap in data.NhapDs.Where(p => p.MaKP == makho)
                         join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia && (pp == 3 ? p.SoLo == solo : true)) on nhap.IDNhap equals nhapct.IDNhap
                         select new { nhap.NgayNhap, nhap.PLoai, nhapct }).ToList();
            var _gia = (from nhap in _gia2.OrderByDescending(p => p.NgayNhap)
                        group new { nhap } by new { nhap.nhapct.MaDV, nhap.nhapct.DonGia } into kq
                        select new { kq.Key.DonGia, soluong = (kq.Where(p => p.nhap.PLoai == 1).Sum(p => p.nhap.nhapct.SoLuongN) - kq.Where(p => p.nhap.PLoai == 2 || p.nhap.PLoai == 3).Sum(p => p.nhap.nhapct.SoLuongX)) }).ToList();
            if (_gia.Count > 0)
            {
                soluong = _gia.First().soluong;
                if (soluong < 0)
                {
                    return soluong;
                }
                else
                {
                    var slkd2 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia && (pp == 3 ? p.SoLo == solo : true)).Where(p => p.Status == null || p.Status == 0)
                                 join kd in data.DThuocs.Where(p => p.Status == 0).Where(p => p.MaKXuat == makho).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                 select new { sl.DonGia, sl.SoLuong }).ToList();
                    var slkd = (from sl in slkd2
                                group sl by sl.DonGia into kq
                                select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                    if (slkd.Count > 0)
                    {
                        if (slkd.First().soluong - soluongke > 0)
                            soluong -= soluongke;
                        else
                            soluong -= (slkd.First().soluong);

                        if (soluong <= 0)
                            return soluong;
                    }
                }
            }
            return soluong;
        }

        #region kiểm tra số lượng tồn khi lưu kê đơn
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="maDV"></param>
        /// <param name="makho"></param>
        /// <param name="ppxuat"></param>
        /// <param name="gia">giá thuốc kê</param>
        /// <param name="soluongke"> số lượng thuốc kê</param>
        /// <param name="macc"></param>
        /// <returns></returns>
        public static double KiemTraSoLuongThuocTonKho_KeDon(Hospital data, int maDV, int makho, double gia, double soluongke, string solo)
        {
            double soluong = 0;
            try
            {
                int ppxuat = -1;
                var kp = data.KPhongs.Where(p => p.MaKP == makho).FirstOrDefault();
                if (kp != null && kp.PPXuat != null)
                    ppxuat = kp.PPXuat.Value;
                if (kp.PLoai == "Tủ trực")// kiểm tra tủ trực
                {
                    var _giatt0 = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKPnx == makho)
                                   join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.DonGia == gia && (ppxuat == 3 ? p.SoLo == solo : true)) on nhap.IDNhap equals nhapct.IDNhap
                                   select new { nhapct.DonGia, nhapct.SoLuongX, nhap.PLoai, nhap.KieuDon, nhapct.MaDV, nhapct.SoLuongN, nhap.NgayNhap }).ToList();
                    var _giatt = (from nd in _giatt0
                                  group nd by new { nd.MaDV, nd.DonGia } into kq
                                  select new
                                  {
                                      kq.Key.DonGia,
                                      soluong = (kq.Sum(p => p.SoLuongX) - kq.Where(p => p.PLoai == 1 && p.KieuDon == 2).Sum(p => p.SoLuongN)),
                                      ngay = kq.Min(p => p.NgayNhap)
                                  }).OrderBy(p => p.ngay).FirstOrDefault();

                    if (_giatt != null)
                    {
                        soluong = _giatt.soluong;

                        var slkd0 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia).Where(p => solo == "" ? true : p.SoLo == solo).Where(p => p.Status == null || p.Status == 0 || p.Status == 1)
                                     join kd in data.DThuocs.Where(p => p.MaKXuat == makho || p.MaKP == makho).Where(p => p.Status != 2) on sl.IDDon equals kd.IDDon

                                     select new
                                     {
                                         sl.MaDV,
                                         sl.DonGia,
                                         SLKD = (sl.MaKXuat == makho && (sl.SoLuong > 0 || (sl.SoLuong < 0 && kd.KieuDon == 2))) ? sl.SoLuong : 0,
                                         SLTra = (kd.MaKP == makho && sl.Status == 0 && kd.KieuDon == 4) ? sl.SoLuong : 0// Đơn treo lĩnh HC VTYT (chỉ đơn trả dược mới trừ, đơn lĩnh thì không tính thêm : Ví dụ: tủ trực còn 50 viên, kê đơn trả cho kho tổng 30 viên (nhưng chưa lĩnh) cũng chỉ kê đơn cho bệnh nhân hoặc trả dược trong vòng 20 viên còn lại; Trường hợp kê đơn lĩnh thêm 40 viên, không được tính=> chỉ được tính khi nào đã lĩnh dược về khoa
                                     }).ToList();
                        var slkd = (from sl in slkd0
                                    group new { sl } by sl.DonGia into kq
                                    select new
                                    {
                                        kq.Key,
                                        soluong = kq.Sum(p => p.sl.SLKD) - kq.Sum(p => p.sl.SLTra)
                                    }).ToList();
                        double _slkd = 0;
                        if (slkd.Count > 0)
                        {
                            _slkd = slkd.First().soluong;
                        }

                        else
                        {
                            _slkd = 0;
                        }
                        soluong = soluong - _slkd;

                    }


                }
                else
                {
                    var _gia2 = (from nhap in data.NhapDs.Where(p => p.MaKP == makho)
                                 join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia && (ppxuat == 3 ? p.SoLo == solo : true)) on nhap.IDNhap equals nhapct.IDNhap
                                 select new { nhapct.SoLuongN, nhapct.SoLuongX, nhapct.DonGia, nhapct.MaDV, nhap.NgayNhap }).OrderByDescending(p => p.NgayNhap).ToList();
                    var _gia = (from nhap in _gia2
                                group nhap by new { nhap.MaDV, nhap.DonGia } into kq
                                select new { kq.Key.DonGia, soluong = (kq.Sum(p => p.SoLuongN) - kq.Sum(p => p.SoLuongX)) }).ToList();
                    if (_gia.Count > 0)
                    {
                        soluong = _gia.First().soluong;
                        if (soluong < 0)
                        {
                            return soluong;
                        }
                        else
                        {
                            var slkd2 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia && (ppxuat == 3 ? p.SoLo == solo : true)).Where(p => p.Status == null || p.Status != -1)
                                         join kd in data.DThuocs.Where(p => p.Status == 0).Where(p => p.MaKXuat == makho).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                         select new { sl.SoLuong, sl.MaDV, sl.DonGia, sl.Status }).ToList();


                            var slkd = (from sl in slkd2.Where(p => p.Status == null || p.Status == 0) //.Where(p => p.Status == null || p.Status != -1)
                                        group sl by sl.DonGia into kq
                                        select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                            if (slkd.Count > 0)
                            {
                                if (slkd.First().soluong - soluongke > 0)
                                    soluong -= (slkd.First().soluong - soluongke);
                                else
                                    soluong -= (slkd.First().soluong);

                                if (soluong <= 0)
                                    return soluong;
                            }
                        }
                    }
                }

                return soluong;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        #endregion

        public static double GetSoLuongDongY(Hospital _data, int _madv, double _soluong, int makho)
        {

            double _soluongdy = 0;
            var kp = _data.KPhongs.Where(p => p.MaKP == makho && (p.PPHHDY == 1 || p.PPHHDY == 2)).ToList();
            if (kp.Count > 0)
                return 0;
            var ktdy = _data.DichVus.Where(p => p.MaDV == _madv).Where(p => p.DongY == 1).ToList();
            if (ktdy.Count > 0)
            {
                double _tylePP = 0, _tyleBQ = 0;
                if (ktdy.First().TyLeSP != null)
                    _tylePP = ktdy.First().TyLeSP.Value;
                if (ktdy.First().TyLeBQ != null)
                    _tyleBQ = ktdy.First().TyLeBQ.Value;
                // _soluongdy = (100 * _soluong) / (100 - _tyleBQ - _tylePP) - _soluong;
                _soluongdy = _soluong * (_tyleBQ + _tylePP) / 100;
            }
            else
            {
                _soluongdy = 0;
            }

            return Math.Round(_soluongdy, 3);

        }

        public static List<ThuocTon> KiemTraTonDuoc(Hospital _dataContext, int _makp)
        {
            List<ThuocTon> _lthuocton = new List<ThuocTon>();
            _lthuocton.Clear();
            _dataContext = new Hospital();
            var duoc = (from nd in _dataContext.NhapDs.Where(p => p.MaKP == _makp)
                        join ndct in _dataContext.NhapDcts on nd.IDNhap equals ndct.IDNhap
                        join dv in _dataContext.DichVus on ndct.MaDV equals dv.MaDV
                        select new { nd.MaKP, ndct.MaDV, ndct.DonGia, dv.TenDV, ndct.SoLuongN, ndct.SoLuongX }).ToList();
            var kt = (from nd in duoc
                      group new { nd } by new { nd.MaKP, nd.MaDV, nd.DonGia, nd.TenDV } into kq
                      select new { kq.Key.TenDV, kq.Key.MaKP, kq.Key.MaDV, kq.Key.DonGia, SoLuong = kq.Sum(p => p.nd.SoLuongN) - kq.Sum(p => p.nd.SoLuongX) }).ToList();
            foreach (var a in kt)
            {
                if (a.SoLuong < 0)
                {
                    _lthuocton.Add(new ThuocTon { MaDV = a.MaDV == null ? 0 : a.MaDV.Value, TenDV = a.TenDV, SoLuong = a.SoLuong, DonGia = a.DonGia, MaKho = _makp });

                }
            }
            return _lthuocton;
        }

        public static string GetIdPhieuTeoKhoaphong(int _Ploai, int _MaKP)
        {
            Hospital data = new Hospital();
            string Idmoi = "";
            var tenkp = data.KPhongs.Where(p => p.MaKP == _MaKP).Select(p => p.TenKP).FirstOrDefault();
            string[] q = tenkp.Split(' ');
            int w = q.Length;
            for (int i = 0; i < w; i++)
            {
                if (q[i] != "")
                    Idmoi += q[i].Substring(0, 1);

            }
            List<string> sophieu = data.NhapDs.Where(p => p.MaKP == _MaKP && p.PLoai == _Ploai && p.SoPhieu != null).Select(p => p.SoPhieu).ToList();
            List<int> newsophieu = new List<int>();
            foreach (var item in sophieu)
            {
                string[] arr = item.Split('_');
                if (arr.Length > 1)
                    newsophieu.Add(Convert.ToInt32(arr[1]));
            }
            int spmax = 0;
            if (newsophieu.Count() > 0)
                spmax = newsophieu.Select(p => p).Max();
            if (_Ploai == 1)
            {
                Idmoi += "N_" + (spmax + 1).ToString();
            }
            else
            {
                Idmoi += "X_" + (spmax + 1).ToString();
            }

            return Idmoi.ToUpper();
        }
    }
}
