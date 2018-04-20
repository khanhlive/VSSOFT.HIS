using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class PriceProvider
    {
        public static bool GetGiaCu(int mabn, int TrongDM, DateTime ngaychidinh)
        {
            Hospital data = new Hospital();
            bool giacu = false;

            var ttbn = data.BenhNhans.Where(p => p.MaBNhan == mabn).ToList();
            if (ttbn.Count > 0)
            {
                string dtuong = ttbn.First().DTuong;
                DateTime ngaythang = FormatHelper.BeginDate(Common.ngayGiaMoiDV);

                if (TrongDM == -1)
                {
                    if (dtuong == "BHYT")
                        ngaythang = FormatHelper.BeginDate(Common.ngayGiaMoi);
                    if (Common.MaBV == "30007" && dtuong == "BHYT")
                    {
                        if (ngaychidinh.Date < ngaythang)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    if (dtuong != "BHYT")// chỉ lấy theo ngày nhập (Hữu Hùng trả lời ngày 31/07/2017)
                    {
                        if (ngaychidinh.Date < ngaythang)
                        {
                            giacu = true;
                        }
                        else
                        {
                            giacu = false;
                        }

                    }
                }
                else
                    if (TrongDM == 1)
                {
                    ngaythang = FormatHelper.BeginDate(Common.ngayGiaMoi);
                    if (Common.MaBV == "30007" && dtuong == "BHYT")
                    {
                        if (ngaychidinh.Date < ngaythang)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                else// chỉ lấy theo ngày nhập (Hữu Hùng trả lời ngày 31/07/2017)
                {
                    if (ngaychidinh.Date < ngaythang)
                    {
                        giacu = true;
                    }
                    else
                    {
                        giacu = false;
                    }

                }
                var vaovien = (from vv in data.VaoViens.Where(p => p.MaBNhan == mabn)
                               select vv.NgayVao).ToList();

                if (ttbn.Count > 0 && vaovien.Count > 0 && vaovien.First() != null && vaovien.First().Value.Date < ngaythang)
                {
                    giacu = true;
                }
                if (vaovien.Count <= 0 && ttbn.Count > 0 && ttbn.First().NoiTru == 0 && ttbn.First().NNhap.Value.Date < ngaythang)
                    giacu = true;
            }
            return giacu;
        }

        public static double GetGiaDM(Hospital data, int maDV, int trongDM, int mabn, DateTime ngaychidinh)
        {
            bool giacu = GetGiaCu(mabn, trongDM, ngaychidinh);
            double gia = 0;
            var q = data.DichVus.Where(p => p.MaDV == maDV).ToList();
            if (q.Count > 0)
            {
                if (trongDM == 1)
                {
                    if (giacu)
                        gia = q.First().DonGia;
                    else
                        gia = q.First().DonGiaBHYT;
                }
                else
                {
                    //if (Common.MaBV == "30009")
                    //{
                    if (giacu)
                        gia = q.First().DonGia2.Value; // giá DV cũ
                    else
                        gia = q.First().DonGia2.Value;//q.First().DonGiaDV2; // giá  DV mới
                    //}
                    //else
                    //{
                    //    gia = q.First().DonGia2;

                    //}

                }
            }
            return gia;
        }

        public static Gia_SoLo_HanSuDung GetGia_SoLo_HSD(Hospital data, int maDV, int makho) // đang sử dụng
        {
            Gia_SoLo_HanSuDung dsach = new Gia_SoLo_HanSuDung();
            Common.SoLuongTon = 0;
            dsach.Gia = 0;
            dsach.SoLo = null;
            dsach.SoLuong = 0;
            dsach.HanDung = null;
            int ppxuat = 0;
            var kp = data.KPhongs.Where(p => p.MaKP == makho).Select(p => p.PPXuat).ToList();
            if (kp.Count > 0 && kp.First() != null)
                ppxuat = kp.First().Value;
            var abc = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho)
                       join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV) on nhap.IDNhap equals nhapct.IDNhap
                       select new { nhap.NgayNhap, nhapct.SoLuongN, nhapct.SoLo, nhapct.HanDung, nhapct.SoLuongX, nhapct.DonGia, nhapct.MaDV, nhap.PLoai }).ToList();
            var _gia2 = (from nhap in abc.OrderByDescending(p => p.NgayNhap)
                         group new { nhap } by new { MaDV = nhap.MaDV, nhap.DonGia } into kq
                         select new { kq.Key.DonGia, soluongN = kq.Where(p => p.nhap.PLoai == 1).Sum(p => p.nhap.SoLuongN), soLuongX = kq.Where(p => p.nhap.PLoai == 2 || p.nhap.PLoai == 3).Sum(p => p.nhap.SoLuongX), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();

            var _gia = (from nhap in _gia2
                        select new { nhap.DonGia, soluong = nhap.soluongN - nhap.soLuongX, ngay = nhap.ngay }).OrderBy(p => p.ngay).ToList();

            var q = data.DichVus.Where(p => p.MaDV == maDV).ToList();
            switch (ppxuat)
            {
                case 0://

                    if (q.Count > 0)
                    {
                        if (q.First().DonGia != null)
                            dsach.Gia = q.First().DonGia;
                        else
                            dsach.Gia = 0;
                    }
                    break;
                case 1: // nhập trước xuất trước
                    //  string _macc = "";
                    bool _dongy = false;
                    if (q.Count > 0 && q.First().DongY != null && q.First().DongY == 1)
                        _dongy = true;
                    double _soluongDYHH = 0, _soLuongDYHH_KD = 0;


                    var kttutruc = data.KPhongs.Where(p => p.MaKP == makho).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
                    if (kttutruc.Count > 0)// kiểm tra tủ trực
                    {
                        var _giatt0 = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKPnx == makho)
                                       join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV) on nhap.IDNhap equals nhapct.IDNhap
                                       select new { nhapct.DonGia, nhapct.SoLuongX, nhap.PLoai, nhap.KieuDon, nhapct.MaDV, nhapct.SoLuongN, nhap.NgayNhap, nhapct.SoLo }).ToList();
                        var _giatt = (from nd in _giatt0
                                      group nd by new { nd.MaDV, nd.DonGia, nd.SoLo } into kq
                                      select new
                                      {
                                          kq.Key.DonGia,
                                          kq.Key.SoLo,
                                          soluong = (kq.Sum(p => p.SoLuongX) - kq.Where(p => p.PLoai == 1 && p.KieuDon == 2).Sum(p => p.SoLuongN)),
                                          ngay = kq.Min(p => p.NgayNhap)
                                      }).OrderBy(p => p.ngay).ToList();

                        if (_giatt.Count > 0)
                        {
                            Double[] dsgia = new Double[_giatt.Count];
                            foreach (var i in _giatt)
                            {
                                var slkd0 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.Status == null || p.Status == 0 || p.Status == 1)
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
                                if (i.soluong > 0)
                                {
                                    dsach.SoLuong = i.soluong - _slkd;
                                    dsach.Gia = i.DonGia;
                                }
                                if (dsach.SoLuong > 0)
                                {
                                    Common.SoLuongTon = dsach.SoLuong;
                                    break;
                                }
                                else
                                {
                                    Common.SoLuongTon = 0;
                                }
                            }
                        }


                    }
                    else
                    {
                        var kt = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.MaKP == makho).ToList();
                        if (kt.Count > 0)
                        {
                            // _macc = kt.First().m // thêm mã cc vào giá ưu tiên
                            dsach.Gia = kt.First().DonGia.Value;
                            // so lương ĐY hao hụt
                            if (_dongy)
                            {
                                var dongySL = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho).Where(p => p.PLoai == 2)
                                               join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.SoLuongDY != null && p.DonGia == dsach.Gia) on nhap.IDNhap equals nhapct.IDNhap
                                               group new { nhapct } by new { nhapct.MaDV } into kq
                                               select new { soluong = kq.Sum(p => p.nhapct.SoLuongDY) }).ToList();
                                if (dongySL.Count > 0)
                                    _soluongDYHH = dongySL.First().soluong;
                            }
                            //
                            var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == dsach.Gia).Where(p => p.Status == null || p.Status == 0)
                                        join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                        group sl by sl.DonGia into kq
                                        select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                            double _slkd = 0;

                            if (slkd.Count > 0)
                            {
                                _slkd = slkd.First().soluong;
                            }
                            //so lượng ĐY HH KD
                            if (_dongy)
                                _soLuongDYHH_KD = NhapDuocProvider.GetSoLuongDongY(data, maDV, _slkd, makho);
                            //
                            if (_gia.Where(p => p.DonGia == dsach.Gia).ToList().Count > 0 && _gia.Where(p => p.DonGia == dsach.Gia).First().soluong > 0)
                            {
                                dsach.SoLuong = _gia.Where(p => p.DonGia == dsach.Gia).First().soluong - _slkd - _soluongDYHH - _soLuongDYHH_KD;
                            }
                            if (dsach.SoLuong > 0)
                            {
                                Common.SoLuongTon = dsach.SoLuong;
                            }
                            else
                            {
                                dsach.SoLuong = 0;
                                if (_gia.Count > 0)
                                {
                                    Double[] dsgia = new Double[_gia.Count];
                                    foreach (var i in _gia)
                                    {
                                        // tạo một biến soluongkd = i.soluong- soluongkd
                                        var slkd1 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.Status == null || p.Status == 0)
                                                     join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                                     group sl by sl.DonGia into kq
                                                     select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                        double _slkd1 = 0;
                                        if (slkd1.Count > 0)
                                        {
                                            _slkd1 = slkd1.First().soluong;
                                        }
                                        // dông y

                                        _soLuongDYHH_KD = 0;
                                        // so lương ĐY hao hụt
                                        if (_dongy)
                                        {
                                            var dongySL = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho).Where(p => p.PLoai == 2)
                                                           join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.SoLuongDY != null && p.DonGia == i.DonGia) on nhap.IDNhap equals nhapct.IDNhap
                                                           group new { nhapct } by new { nhapct.MaDV } into kq
                                                           select new { soluong = kq.Sum(p => p.nhapct.SoLuongDY) }).ToList();
                                            if (dongySL.Count > 0)
                                                _soluongDYHH = dongySL.First().soluong;
                                            _soLuongDYHH_KD = NhapDuocProvider.GetSoLuongDongY(data, maDV, _slkd1, makho);
                                        }
                                        //


                                        //
                                        if (i.soluong > 0)
                                        {
                                            dsach.SoLuong = i.soluong - _slkd1 - _soluongDYHH - _soLuongDYHH_KD;
                                            dsach.Gia = i.DonGia;
                                        }
                                        if (dsach.SoLuong > 0)
                                        {
                                            Common.SoLuongTon = dsach.SoLuong;
                                            break;
                                        }
                                        else
                                        {
                                            Common.SoLuongTon = 0;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (_gia.Count > 0)
                            {
                                Double[] dsgia = new Double[_gia.Count];
                                foreach (var i in _gia)
                                {
                                    // tạo một biến soluongkd = i.soluong- soluongkd
                                    var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.Status == null || p.Status == 0)
                                                join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                                group sl by sl.DonGia into kq
                                                select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                    double _slkd = 0;
                                    if (slkd.Count > 0)
                                    {
                                        _slkd = slkd.First().soluong;
                                    }
                                    // dông y

                                    _soLuongDYHH_KD = 0;
                                    _soluongDYHH = 0;
                                    // so lương ĐY hao hụt
                                    if (_dongy)
                                    {
                                        var dongySL = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho).Where(p => p.PLoai == 2)
                                                       join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.SoLuongDY != null && p.DonGia == i.DonGia) on nhap.IDNhap equals nhapct.IDNhap
                                                       group new { nhapct } by new { nhapct.MaDV } into kq
                                                       select new { soluong = kq.Sum(p => p.nhapct.SoLuongDY) }).ToList();
                                        if (dongySL.Count > 0)
                                            _soluongDYHH = dongySL.First().soluong;
                                        _soLuongDYHH_KD = NhapDuocProvider.GetSoLuongDongY(data, maDV, _slkd, makho);
                                    }
                                    //
                                    if (i.soluong > 0)
                                    {
                                        dsach.SoLuong = i.soluong - _slkd - _soluongDYHH - _soLuongDYHH_KD;
                                        dsach.Gia = i.DonGia;
                                    }
                                    if (dsach.SoLuong > 0)
                                    {
                                        Common.SoLuongTon = dsach.SoLuong;
                                        break;
                                    }
                                    else
                                    {
                                        Common.SoLuongTon = 0;
                                    }
                                }
                            }

                        }
                    }
                    break;
                case 2: // xuất theo hạn sử dụng - chua hoan thien
                    var kt2 = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.Status == 1).ToList();
                    if (kt2.Count > 0)
                    {
                        dsach.Gia = kt2.First().DonGia.Value;
                    }
                    else
                    {
                        if (_gia.Count > 0)
                            dsach.Gia = _gia.First().DonGia;
                    }
                    break;
                case 3:

                    var _gia3 = (from nhap in abc
                                 where (nhap.SoLo != null && nhap.SoLo != "")
                                 group new { nhap } by new { nhap.MaDV, nhap.DonGia, nhap.SoLo } into kq
                                 select new { kq.Key.DonGia, kq.Key.SoLo, soluong = (kq.Sum(p => p.nhap.SoLuongN) - kq.Sum(p => p.nhap.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
                    string _solo = null;
                    var kttutruc3 = data.KPhongs.Where(p => p.MaKP == makho).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
                    if (kttutruc3.Count > 0)// kiểm tra tủ trực
                    {
                        var _giatt = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKPnx == makho)
                                      join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV).Where(p => p.SoLo != null && p.SoLo != "") on nhap.IDNhap equals nhapct.IDNhap
                                      group new { nhapct, nhap } by new { nhapct.MaDV, nhapct.DonGia, nhapct.SoLo } into kq
                                      select new { kq.Key.DonGia, kq.Key.SoLo, soluong = (kq.Sum(p => p.nhapct.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
                        if (_giatt.Count > 0)
                        {
                            Double[] dsgia = new Double[_giatt.Count];
                            foreach (var i in _giatt)
                            {
                                _solo = i.SoLo;
                                // tạo một biến soluongkd = i.soluong- soluongkd
                                var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.SoLo == (_solo)).Where(p => p.Status == null || p.Status == 0 || p.Status == 1)
                                            join kd in data.DThuocs.Where(p => p.MaKXuat == makho) on sl.IDDon equals kd.IDDon
                                            group sl by new { sl.DonGia, sl.SoLo } into kq
                                            select new { kq.Key.DonGia, kq.Key.SoLo, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                double _slkd = 0;
                                if (slkd.Count > 0)
                                {
                                    _slkd = slkd.First().soluong;

                                }
                                if (i.soluong > 0)
                                {
                                    dsach.SoLuong = i.soluong - _slkd;
                                    dsach.Gia = i.DonGia;
                                    dsach.SoLo = i.SoLo;
                                }
                                if (dsach.SoLuong > 0)
                                {
                                    Common.SoLuongTon = dsach.SoLuong;
                                    break;
                                }
                                else
                                {
                                    Common.SoLuongTon = 0;
                                }
                            }
                        }


                    }
                    else
                    {
                        var kt = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.MaKP == makho).ToList();
                        if (kt.Count > 0)
                        {
                            dsach.Gia = kt.First().DonGia.Value;
                            dsach.SoLo = kt.First().SoLo;
                            var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == dsach.Gia && p.SoLo == dsach.SoLo).Where(p => p.Status == 0)
                                        join kd in data.DThuocs.Where(p => p.MaKXuat == makho) on sl.IDDon equals kd.IDDon
                                        group sl by new { sl.DonGia, sl.SoLo } into kq
                                        select new { kq.Key, kq.Key.SoLo, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                            double _slkd = 0;
                            if (slkd.Count > 0)
                            {
                                _slkd = slkd.First().soluong;
                            }
                            if (_gia3.Where(p => p.DonGia == dsach.Gia && p.SoLo == dsach.SoLo).ToList().Count > 0 && _gia3.Where(p => p.DonGia == dsach.Gia && p.SoLo == dsach.SoLo).First().soluong > 0)
                            {
                                dsach.SoLuong = _gia3.Where(p => p.DonGia == dsach.Gia && p.SoLo == dsach.SoLo).First().soluong - _slkd;
                            }
                            if (dsach.SoLuong > 0)
                            {

                                Common.SoLuongTon = dsach.SoLuong;
                            }
                            else
                            {
                                dsach.SoLuong = 0;
                                if (_gia.Count > 0)
                                {
                                    Double[] dsgia = new Double[_gia.Count];
                                    foreach (var i in _gia3.Where(p => p.SoLo != dsach.SoLo))
                                    {
                                        // tạo một biến soluongkd = i.soluong- soluongkd
                                        _solo = i.SoLo;
                                        var slkd1 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.SoLo == (_solo)).Where(p => p.Status == null || p.Status == 0)
                                                     join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                                     group sl by sl.DonGia into kq
                                                     select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                        double _slkd1 = 0;
                                        if (slkd1.Count > 0)
                                        {
                                            _slkd1 = slkd1.First().soluong;
                                        }
                                        if (i.soluong > 0)
                                        {
                                            dsach.SoLuong = i.soluong - _slkd1;
                                            dsach.Gia = i.DonGia;
                                            dsach.SoLo = i.SoLo;

                                        }
                                        if (dsach.SoLuong > 0)
                                        {
                                            Common.SoLuongTon = dsach.SoLuong;

                                            break;
                                        }
                                        else
                                        {
                                            Common.SoLuongTon = 0;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (_gia.Count > 0)
                            {
                                Double[] dsgia = new Double[_gia.Count];
                                foreach (var i in _gia3)
                                {
                                    // tạo một biến soluongkd = i.soluong- soluongkd
                                    _solo = i.SoLo;
                                    var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.SoLo == (_solo)).Where(p => p.Status == null || p.Status == 0)
                                                join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                                group sl by sl.DonGia into kq
                                                select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                    double _slkd = 0;
                                    if (slkd.Count > 0)
                                    {
                                        _slkd = slkd.First().soluong;
                                    }
                                    if (i.soluong > 0)
                                    {
                                        dsach.SoLuong = i.soluong - _slkd;
                                        dsach.Gia = i.DonGia;
                                        dsach.SoLo = i.SoLo;
                                    }
                                    if (dsach.SoLuong > 0)
                                    {
                                        Common.SoLuongTon = dsach.SoLuong;

                                        break;
                                    }
                                    else
                                    {
                                        Common.SoLuongTon = 0;
                                    }
                                }
                            }

                        }
                    }

                    break;
            }
            return dsach;
        }

        public static double GetGiaTheoNhaCungCap(Hospital data, int maDV, int makho, string macc)
        {
            int ppxuat = 0;
            var kp = data.KPhongs.Where(p => p.MaKP == makho).Select(p => p.PPXuat).ToList();
            if (kp.Count > 0 && kp.First() != null)
                ppxuat = kp.First().Value;
            double gia = 0;
            double soluong = 0;
            var _gia = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho)
                        join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV) on nhap.IDNhap equals nhapct.IDNhap
                        group new { nhapct, nhap } by new { nhapct.MaDV, nhapct.DonGia, nhapct.MaCC } into kq
                        select new { kq.Key.DonGia, kq.Key.MaCC, soluong = (kq.Sum(p => p.nhapct.SoLuongN) - kq.Sum(p => p.nhapct.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
            switch (ppxuat)
            {
                case 0://
                    var q = data.DichVus.Where(p => p.MaDV == maDV).ToList();
                    if (q.Count > 0)
                    {
                        gia = q.First().DonGia;
                    }
                    break;
                case 1: // nhập trước xuất trước
                    string _macc = "";
                    var kttutruc = data.KPhongs.Where(p => p.MaKP == makho).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
                    if (kttutruc.Count > 0)// kiểm tra tủ trực
                    {
                        var _giatt = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKPnx == makho)
                                      join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV) on nhap.IDNhap equals nhapct.IDNhap
                                      group new { nhapct, nhap, } by new { nhapct.MaDV, nhapct.DonGia, nhapct.MaCC } into kq
                                      select new { kq.Key.DonGia, kq.Key.MaCC, soluong = (kq.Sum(p => p.nhapct.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
                        if (_giatt.Count > 0)
                        {
                            Double[] dsgia = new Double[_giatt.Count];
                            foreach (var i in _giatt)
                            {
                                _macc = i.MaCC;
                                // tạo một biến soluongkd = i.soluong- soluongkd
                                var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.MaCC == (_macc))
                                            join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status != 2) on sl.IDDon equals kd.IDDon
                                            group sl by sl.DonGia into kq
                                            select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                double _slkd = 0;
                                if (slkd.Count > 0)
                                {
                                    _slkd = slkd.First().soluong;
                                }
                                if (i.soluong > 0)
                                {
                                    soluong = i.soluong - _slkd;
                                    gia = i.DonGia;
                                }
                                if (soluong > 0)
                                {
                                    Common.SoLuongTon = soluong;
                                    Common._maCC = i.MaCC;
                                    break;
                                }
                                else
                                {
                                    Common.SoLuongTon = 0;
                                }
                            }
                        }


                    }
                    else
                    {
                        var kt = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.MaKP == makho).ToList();
                        if (kt.Count > 0)
                        {
                            //gia = kt.First().DonGia.Value;
                            // _macc = kt.First().m // thêm mã cc vào giá ưu tiên
                            gia = kt.First().DonGia.Value;
                            var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia)
                                        join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                        group sl by sl.DonGia into kq
                                        select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                            double _slkd = 0;
                            if (slkd.Count > 0)
                            {
                                _slkd = slkd.First().soluong;
                            }
                            if (_gia.Where(p => p.DonGia == gia).ToList().Count > 0 && _gia.Where(p => p.DonGia == gia).First().soluong > 0)
                            {
                                soluong = _gia.Where(p => p.DonGia == gia).First().soluong - _slkd;
                                if (_gia.Where(p => p.DonGia == gia).First().MaCC != null)
                                    Common._maCC = _gia.Where(p => p.DonGia == gia).First().MaCC;
                            }
                            if (soluong > 0)
                            {
                                Common.SoLuongTon = soluong;
                            }
                            else
                            {
                                soluong = 0;
                                if (_gia.Count > 0)
                                {
                                    Double[] dsgia = new Double[_gia.Count];
                                    foreach (var i in _gia)
                                    {
                                        // tạo một biến soluongkd = i.soluong- soluongkd
                                        _macc = i.MaCC;
                                        var slkd1 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.MaCC == (_macc))
                                                     join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                                     group sl by sl.DonGia into kq
                                                     select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                        double _slkd1 = 0;
                                        if (slkd1.Count > 0)
                                        {
                                            _slkd1 = slkd1.First().soluong;
                                        }
                                        if (i.soluong > 0)
                                        {
                                            soluong = i.soluong - _slkd;
                                            gia = i.DonGia;
                                        }
                                        if (soluong > 0)
                                        {
                                            Common.SoLuongTon = soluong;
                                            Common._maCC = i.MaCC;
                                            break;
                                        }
                                        else
                                        {
                                            Common.SoLuongTon = 0;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (_gia.Count > 0)
                            {
                                Double[] dsgia = new Double[_gia.Count];
                                foreach (var i in _gia)
                                {
                                    // tạo một biến soluongkd = i.soluong- soluongkd
                                    _macc = i.MaCC;
                                    var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.MaCC == (_macc))
                                                join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                                group sl by sl.DonGia into kq
                                                select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                    double _slkd = 0;
                                    if (slkd.Count > 0)
                                    {
                                        _slkd = slkd.First().soluong;
                                    }
                                    if (i.soluong > 0)
                                    {
                                        soluong = i.soluong - _slkd;
                                        gia = i.DonGia;
                                    }
                                    if (soluong > 0)
                                    {
                                        Common.SoLuongTon = soluong;
                                        Common._maCC = i.MaCC;
                                        break;
                                    }
                                    else
                                    {
                                        Common.SoLuongTon = 0;
                                    }
                                }
                            }

                        }
                    }
                    break;
                case 2: // xuất theo hạn sử dụng - chua hoan thien
                    var kt2 = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.Status == 1).ToList();
                    if (kt2.Count > 0)
                    {
                        gia = kt2.First().DonGia.Value;
                    }
                    else
                    {
                        if (_gia.Count > 0)
                            gia = _gia.First().DonGia;
                    }
                    break;
                case 3:
                    if (ppxuat == 3)
                    {
                        var _gia3 = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho)
                                     join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV) on nhap.IDNhap equals nhapct.IDNhap
                                     group new { nhapct, nhap } by new { nhapct.MaDV, nhapct.DonGia, nhapct.SoLo } into kq
                                     select new { kq.Key.DonGia, kq.Key.SoLo, soluong = (kq.Sum(p => p.nhapct.SoLuongN) - kq.Sum(p => p.nhapct.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
                        string _solo = "";
                        var kttutruc3 = data.KPhongs.Where(p => p.MaKP == makho).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
                        if (kttutruc3.Count > 0)// kiểm tra tủ trực
                        {
                            var _giatt = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKPnx == makho)
                                          join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV) on nhap.IDNhap equals nhapct.IDNhap
                                          group new { nhapct, nhap } by new { nhapct.MaDV, nhapct.DonGia, nhapct.SoLo } into kq
                                          select new { kq.Key.DonGia, kq.Key.SoLo, soluong = (kq.Sum(p => p.nhapct.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
                            if (_giatt.Count > 0)
                            {
                                Double[] dsgia = new Double[_giatt.Count];
                                foreach (var i in _giatt)
                                {
                                    _solo = i.SoLo;
                                    // tạo một biến soluongkd = i.soluong- soluongkd
                                    var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.SoLo == (_solo)).Where(p => p.Status != 2)
                                                join kd in data.DThuocs.Where(p => p.MaKXuat == makho) on sl.IDDon equals kd.IDDon
                                                group sl by sl.DonGia into kq
                                                select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                    double _slkd = 0;
                                    if (slkd.Count > 0)
                                    {
                                        _slkd = slkd.First().soluong;
                                    }
                                    if (i.soluong > 0)
                                    {
                                        soluong = i.soluong - _slkd;
                                        gia = i.DonGia;
                                    }
                                    if (soluong > 0)
                                    {
                                        Common.SoLuongTon = soluong;

                                        break;
                                    }
                                    else
                                    {
                                        Common.SoLuongTon = 0;
                                    }
                                }
                            }


                        }
                        else
                        {
                            var kt = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.MaKP == makho).ToList();
                            if (kt.Count > 0)
                            {
                                //gia = kt.First().DonGia.Value;
                                // _macc = kt.First().m // thêm mã cc vào giá ưu tiên
                                gia = kt.First().DonGia.Value;
                                var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == gia)
                                            join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                            group sl by sl.DonGia into kq
                                            select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                double _slkd = 0;
                                if (slkd.Count > 0)
                                {
                                    _slkd = slkd.First().soluong;
                                }
                                if (_gia.Where(p => p.DonGia == gia).ToList().Count > 0 && _gia.Where(p => p.DonGia == gia).First().soluong > 0)
                                {
                                    soluong = _gia.Where(p => p.DonGia == gia).First().soluong - _slkd;
                                    if (_gia.Where(p => p.DonGia == gia).First().MaCC != null)
                                        Common._maCC = _gia.Where(p => p.DonGia == gia).First().MaCC;
                                }
                                if (soluong > 0)
                                {
                                    Common.SoLuongTon = soluong;
                                }
                                else
                                {
                                    soluong = 0;
                                    if (_gia.Count > 0)
                                    {
                                        Double[] dsgia = new Double[_gia.Count];
                                        foreach (var i in _gia3)
                                        {
                                            // tạo một biến soluongkd = i.soluong- soluongkd
                                            _solo = i.SoLo;
                                            var slkd1 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.MaCC == (_solo))
                                                         join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                                         group sl by sl.DonGia into kq
                                                         select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                            double _slkd1 = 0;
                                            if (slkd1.Count > 0)
                                            {
                                                _slkd1 = slkd1.First().soluong;
                                            }
                                            if (i.soluong > 0)
                                            {
                                                soluong = i.soluong - _slkd;
                                                gia = i.DonGia;
                                            }
                                            if (soluong > 0)
                                            {
                                                Common.SoLuongTon = soluong;

                                                break;
                                            }
                                            else
                                            {
                                                Common.SoLuongTon = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {

                                if (_gia.Count > 0)
                                {
                                    Double[] dsgia = new Double[_gia.Count];
                                    foreach (var i in _gia3)
                                    {
                                        // tạo một biến soluongkd = i.soluong- soluongkd
                                        _solo = i.SoLo;
                                        var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.MaCC == (_solo))
                                                    join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0) on sl.IDDon equals kd.IDDon
                                                    group sl by sl.DonGia into kq
                                                    select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                        double _slkd = 0;
                                        if (slkd.Count > 0)
                                        {
                                            _slkd = slkd.First().soluong;
                                        }
                                        if (i.soluong > 0)
                                        {
                                            soluong = i.soluong - _slkd;
                                            gia = i.DonGia;
                                        }
                                        if (soluong > 0)
                                        {
                                            Common.SoLuongTon = soluong;

                                            break;
                                        }
                                        else
                                        {
                                            Common.SoLuongTon = 0;
                                        }
                                    }
                                }

                            }
                        }
                    }
                    break;
            }
            return gia;
        }

        public static double GetGiaNhapByGiaXuat(int? maDV, double DonGiaX, int trongBH)
        {
            //if (maDV == null)
            //    return DonGiaX;
            //else
            //{
            //    Hospital data = new Hospital();
            //    var qdg = data.DonGiaDVs.Where(p => p.MaDV == maDV && (trongBH == 1 ? p.DonGiaX_BH == DonGiaX : p.DonGiaX_DV == DonGiaX)).Where(p => p.Status == true).FirstOrDefault();
            //    if (qdg != null)
            //        return qdg.DonGiaN;
            //    else
            //    {
            //        var qdg1 = data.DonGiaDVs.Where(p => p.MaDV == maDV && (trongBH == 1 ? p.DonGiaX_BH == DonGiaX : p.DonGiaX_DV == DonGiaX)).FirstOrDefault();
            //        if (qdg1 != null)
            //            return qdg1.DonGiaN;
            //        else
            //            return DonGiaX;
            //    }
            //}
            return 696969;
        }
    }

    public class Gia_SoLo_HanSuDung
    {
        public int MaDV { set; get; }
        public double SoLuong { set; get; }
        public double Gia { set; get; }
        public string SoLo { set; get; }
        public DateTime? HanDung { set; get; }
    }
}
