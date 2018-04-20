using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class DichVuProvider
    {
        #region hàm lấy  đơn vị
        public static string GetDonViTinh(Hospital data, int madv)
        {
            string donvi = "";
            var q = data.DichVus.Where(p => p.MaDV == madv).ToList();
            if (q.Count > 0 && q.First().DonVi != null)
            {
                donvi = q.First().DonVi.Trim();
            }
            return donvi;
        }
        #endregion

        public static bool KiemTraDichVuTrongBHYT(Hospital data, int madv)
        {
            var q = data.DichVus.Where(p => p.MaDV == madv).ToList();
            if (q.Count > 0)
            {
                if (q.First().TrongDM == 1)
                    return true;
            }
            return false;
        }

        public static bool CapNhatChiPhiDichVu(Hospital data, int _idvp)
        {
            try
            {
                var kttontai = data.ChiPhiDVs.Where(p => p.idVPhi == _idvp && p.Status == true).ToList();
                if (kttontai.Count > 0)
                {
                    return false;
                }
                else
                {
                    var q = (from bn in data.BenhNhans
                             join vp in data.VienPhis.Where(p => p.idVPhi == _idvp) on bn.MaBNhan equals vp.MaBNhan
                             join vpct in data.VienPhicts on vp.idVPhi equals vpct.idVPhi
                             join dv in data.DichVus on vpct.MaDV equals dv.MaDV
                             join nhomdv in data.NhomDVs on dv.IDNhom equals nhomdv.IDNhom
                             join rv in data.RaViens on bn.MaBNhan equals rv.MaBNhan
                             select new
                             {
                                 bn.MaBNhan,
                                 bn.TenBNhan,
                                 bn.NamSinh,
                                 bn.GTinh,
                                 bn.SThe,
                                 bn.Tuyen,
                                 bn.DChi,
                                 bn.DTuong,
                                 bn.CapCuu,
                                 bn.MaCS,
                                 bn.NoiTinh,
                                 bn.HanBHTu,
                                 bn.HanBHDen,
                                 bn.TuyenDuoi,
                                 bn.NoiTru,
                                 bn.DTNT,
                                 rv.NgayVao,
                                 rv.NgayRa,
                                 rv.SoNgaydt,
                                 rv.MaICD,
                                 rv.MaKP,
                                 bn.MaDTuong,
                                 vp.NgayTT,
                                 vpct.TrongBH,
                                 dv.MaDV,
                                 dv.TenDV,
                                 vpct.ThanhTien,
                                 dv.BHTT,
                                 vpct.DonGia,
                                 vpct.SoLuong,
                                 vpct.TienBN,
                                 vpct.TienBH,
                                 vp.idVPhi
                             }).ToList();
                    var q2 = (from q1 in q
                              join dv in data.DichVus on q1.MaDV equals dv.MaDV
                              join ndv in data.NhomDVs on dv.IDNhom equals ndv.IDNhom
                              select new ChiPhiDV
                              {
                                  MaBNhan = q1.MaBNhan,
                                  TenBNhan = q1.TenBNhan,
                                  NamSinh = q1.NamSinh,
                                  GTinh = q1.GTinh,
                                  SThe = q1.SThe,
                                  Tuyen = q1.Tuyen,
                                  DChi = q1.DChi,
                                  DTuong = q1.DTuong,
                                  CapCuu = q1.CapCuu,
                                  MaCS = q1.MaCS,
                                  NoiTinh = q1.NoiTinh,
                                  HanBHTu = q1.HanBHTu,
                                  HanBHDen = q1.HanBHDen,
                                  TuyenDuoi = q1.TuyenDuoi,
                                  NgayVao = q1.NgayVao,
                                  NgayRa = q1.NgayRa,
                                  SoNgaydt = q1.SoNgaydt,
                                  MaICD = q1.MaICD,
                                  MaKP = q1.MaKP,
                                  MaDTuong = q1.MaDTuong,
                                  NgayTT = q1.NgayTT,
                                  NoiTru = q1.NoiTru,
                                  DTNT = q1.DTNT,
                                  TrongBH = q1.TrongBH,
                                  MaDV = q1.MaDV,
                                  idVPhi = q1.idVPhi,
                                  DonGia = q1.DonGia,
                                  SoLuong = q1.SoLuong,
                                  ThanhTien = q1.ThanhTien,
                                  //Thuoc = kq.Select(p=>p.vpct)
                                  Thuoc = ndv.TenNhomCT == "Thuốc trong danh mục BHYT" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  CDHA = ndv.TenNhomCT == "Chẩn đoán hình ảnh" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  CongKham = ndv.TenNhomCT == "Khám bệnh" ? q1.ThanhTien : 0,
                                  XetNghiem = ndv.TenNhomCT == "Xét nghiệm" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  Mau = ndv.TenNhomCT == "Máu và chế phẩm của máu" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  TTPT = ndv.TenNhomCT == "Thủ thuật, phẫu thuật" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  VTYTTH = ndv.TenNhomCT == "Vật tư y tế trong danh mục BHYT" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  VTYT_tl = ndv.TenNhomCT == "VTYT thanh toán theo tỷ lệ" && q1.BHTT != 100 ? q1.ThanhTien : 0,
                                  DVKT_tl = ndv.TenNhomCT == "DVKT thanh toán theo tỷ lệ" && q1.BHTT != 100 ? q1.ThanhTien : 0,
                                  Thuoc_tl = ndv.TenNhomCT == "Thuốc trong danh mục BHYT" && q1.BHTT != 100 ? q1.ThanhTien : 0,
                                  CPVanChuyen = ndv.TenNhomCT == "Vận chuyển" && q1.BHTT == 100 ? q1.ThanhTien : 0,
                                  TienBN = q1.TienBN,
                                  TienBH = q1.TienBH,
                                  TienNgayGiuong = ndv.TenNhomCT == "Giường điều trị nội trú" ? q1.ThanhTien : 0,
                              }).ToList();
                    List<DTuong> _lDTuong = new List<DTuong>();
                    _lDTuong = data.DTuongs.ToList();

                    foreach (var item in q2)
                    {
                        if (_lDTuong.Where(p => p.MaDTuong == item.MaDTuong).ToList().Count > 0)
                        {
                            item.Nhom = _lDTuong.Where(p => p.MaDTuong == item.MaDTuong).First().Nhom;
                        }
                        item.Status = true;
                        item.MaCB = Common.MaCB;
                        item.NgayUpdate = System.DateTime.Now;
                        data.ChiPhiDVs.Add(item);
                        //data.SaveChanges();
                    }
                    if (q2.Count > 0)
                    {
                        data.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static void XoaChiPhiDichvu(Hospital data, int idVPhi)
        {
            try
            {
                var q = data.ChiPhiDVs.Where(p => p.idVPhi == idVPhi && p.Status == true).ToList();
                foreach (var item in q)
                {
                    item.Status = false;
                    item.MaCB = Common.MaCB;
                    item.NgayUpdate = System.DateTime.Now;
                }
                data.SaveChanges();
            }
            catch (Exception)
            {

            }

        }

        public static double BHTT(int madv)
        {
            double a = 1;
            Hospital _data = new Hospital();
            var dv = _data.DichVus.Where(p => p.MaDV == madv).Select(p => p.BHTT).FirstOrDefault();
            //if (dv.Value != null)
            //    a = dv.Value / 100;
            return a;
        }

        public static List<Gia_SoLo_HanSuDung> _getDSGia(Hospital data, int maDV, int makho) // 
        {
            List<Gia_SoLo_HanSuDung> dsach = new List<Gia_SoLo_HanSuDung>();
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
                        {
                            Gia_SoLo_HanSuDung moi = new Gia_SoLo_HanSuDung();
                            moi.Gia = q.First().DonGia;
                            dsach.Add(moi);
                        }

                    }
                    break;
                case 1: // nhập trước xuất trước
                    //  string _macc = "";
                    bool _dongy = false;
                    if (q.Count > 0 && q.First().DongY != null && q.First().DongY == 1)
                        _dongy = true;
                    double _soluongDYHH = 0, _soLuongDYHH_KD = 0;
                    var kttutruc = data.KPhongs.Where(p => p.MaKP == makho).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
                    #region tủ trực
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
                                Gia_SoLo_HanSuDung moi = new Gia_SoLo_HanSuDung();
                                if (slkd.Count > 0)
                                {
                                    _slkd = slkd.First().soluong;
                                }
                                if (i.soluong > 0)
                                {
                                    moi.SoLuong = i.soluong - _slkd;
                                    moi.Gia = i.DonGia;

                                }
                                dsach.Add(moi);

                            }

                            if (dsach.Sum(p => p.SoLuong) > 0)
                                Common.SoLuongTon = dsach.Sum(p => p.SoLuong);
                            else
                                Common.SoLuongTon = 0;

                        }
                        else
                            Common.SoLuongTon = 0;

                    }
                    #endregion
                    else
                    {
                        var kt = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.MaKP == makho).ToList();
                        Common.SoLuongTon = 0;
                        Gia_SoLo_HanSuDung moi = new Gia_SoLo_HanSuDung();
                        #region có giá ưu tiên
                        if (kt.Count > 0)
                        {
                            //gia = kt.First().DonGia.Value;
                            // _macc = kt.First().m // thêm mã cc vào giá ưu tiên


                            moi.Gia = kt.First().DonGia.Value;

                            // so lương ĐY hao hụt
                            if (_dongy)
                            {
                                var qkp = data.KPhongs.Where(p => p.MaKP == makho && (p.PPHHDY == 1 || p.PPHHDY == 2)).ToList();
                                if (qkp.Count == 0)
                                {
                                    var dongySL = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho).Where(p => p.PLoai == 2)
                                                   join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.SoLuongDY != null && p.DonGia == moi.Gia) on nhap.IDNhap equals nhapct.IDNhap
                                                   group new { nhapct } by new { nhapct.MaDV } into kq
                                                   select new { soluong = kq.Sum(p => p.nhapct.SoLuongDY) }).ToList();
                                    if (dongySL.Count > 0)
                                        _soluongDYHH = dongySL.First().soluong;
                                }
                            }
                            //
                            var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == moi.Gia).Where(p => p.Status == null || p.Status == 0)
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
                            if (_gia.Where(p => p.DonGia == moi.Gia).ToList().Count > 0 && _gia.Where(p => p.DonGia == moi.Gia).First().soluong > 0)
                            {
                                moi.SoLuong = _gia.Where(p => p.DonGia == moi.Gia).First().soluong - _slkd - _soluongDYHH - _soLuongDYHH_KD;
                            }
                            // soluong = soluong - DungChung.Ham._getSL_DongY(data, maDV, soluong);
                            if (moi.SoLuong > 0)
                            {
                                Common.SoLuongTon = moi.SoLuong;
                            }
                            else
                            {
                                moi.SoLuong = 0;
                                if (_gia.Count > 0)
                                {
                                    Double[] dsgia = new Double[_gia.Count];
                                    foreach (var i in _gia)
                                    {
                                        // tạo một biến soluongkd = i.soluong- soluongkd
                                        var slkd1 = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.Status == null || p.Status == 0)
                                                     join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                                     group sl by sl.DonGia into kq
                                                     select new { kq.Key, soluong = kq.Sum(p => p.SoLuong), }).ToList();
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
                                            var qkp = data.KPhongs.Where(p => p.MaKP == makho && (p.PPHHDY == 1 || p.PPHHDY == 2)).ToList();
                                            if (qkp.Count == 0)
                                            {
                                                var dongySL = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho).Where(p => p.PLoai == 2)
                                                               join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.SoLuongDY != null && p.DonGia == i.DonGia) on nhap.IDNhap equals nhapct.IDNhap
                                                               group new { nhapct } by new { nhapct.MaDV } into kq
                                                               select new { soluong = kq.Sum(p => p.nhapct.SoLuongDY) }).ToList();
                                                if (dongySL.Count > 0)
                                                    _soluongDYHH = dongySL.First().soluong;
                                                _soLuongDYHH_KD = NhapDuocProvider.GetSoLuongDongY(data, maDV, _slkd1, makho);
                                            }
                                        }
                                        //


                                        //
                                        if (i.soluong > 0)
                                        {
                                            moi.SoLuong = i.soluong - _slkd1 - _soluongDYHH - _soLuongDYHH_KD;
                                            // soluong = soluong - DungChung.Ham._getSL_DongY(data, maDV, soluong);
                                            moi.Gia = i.DonGia;
                                        }
                                        //if (moi.SoLuong > 0)
                                        //{
                                        //    Common.SoLuongTon = moi.SoLuong;
                                        //    break;
                                        //}
                                        //else
                                        //{
                                        //    Common.SoLuongTon = 0;
                                        //}
                                    }
                                }
                            }
                            dsach.Add(moi);
                        }
                        #endregion
                        #region không có giá UT

                        if (_gia.Count > 0)
                        {
                            Double[] dsgia = new Double[_gia.Count];
                            Common.SoLuongTon = 0;
                            foreach (var i in _gia)
                            {
                                // tạo một biến soluongkd = i.soluong- soluongkd
                                Gia_SoLo_HanSuDung moi2 = new Gia_SoLo_HanSuDung();
                                var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.Status == null || p.Status == 0)
                                            join kd in data.DThuocs.Where(p => p.MaKXuat == makho).Where(p => p.Status == 0).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon
                                            group sl by sl.DonGia into kq
                                            select new { DonGia = kq.Key, soluong = kq.Sum(p => p.SoLuong) }).Where(p => p.DonGia == i.DonGia).ToList();
                                double _slkd = 0;
                                if (slkd.Count() > 0)
                                {
                                    _slkd = slkd.First().soluong;
                                }
                                // dông y

                                _soLuongDYHH_KD = 0;
                                _soluongDYHH = 0;
                                // so lương ĐY hao hụt
                                if (_dongy)
                                {
                                    var qkp = data.KPhongs.Where(p => p.MaKP == makho && (p.PPHHDY == 1 || p.PPHHDY == 2)).ToList();
                                    if (qkp.Count == 0)
                                    {

                                        var dongySL = (from nhap in data.NhapDs.OrderByDescending(p => p.NgayNhap).Where(p => p.MaKP == makho).Where(p => p.PLoai == 2)
                                                       join nhapct in data.NhapDcts.Where(p => p.MaDV == maDV && p.SoLuongDY != null && p.DonGia == i.DonGia) on nhap.IDNhap equals nhapct.IDNhap
                                                       group new { nhapct } by new { nhapct.MaDV } into kq
                                                       select new { soluong = kq.Sum(p => p.nhapct.SoLuongDY) }).ToList();
                                        if (dongySL.Count > 0)
                                            _soluongDYHH = dongySL.First().soluong;
                                        _soLuongDYHH_KD = NhapDuocProvider.GetSoLuongDongY(data, maDV, _slkd, makho);
                                    }
                                }
                                //

                                if (i.soluong > 0)
                                {
                                    moi2.SoLuong = i.soluong - _slkd - _soluongDYHH - _soLuongDYHH_KD;
                                    //   soluong = soluong - DungChung.Ham._getSL_DongY(data, maDV, soluong);
                                    moi2.Gia = i.DonGia;
                                }
                                if (moi == null)
                                    dsach.Add(moi2);
                                else
                                {
                                    if (i.DonGia != moi.Gia)
                                        dsach.Add(moi2);
                                }
                            }

                        }
                        #endregion
                        if (dsach.Sum(p => p.SoLuong) > 0)
                            Common.SoLuongTon = dsach.Sum(p => p.SoLuong);
                    }
                    break;

                case 2:
                    #region// xuất theo hạn sử dụng - chua hoan thien
                    var kt2 = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.Status == 1).ToList();
                    Gia_SoLo_HanSuDung giamoi = new Gia_SoLo_HanSuDung();
                    if (kt2.Count > 0)
                    {
                        giamoi.Gia = kt2.First().DonGia.Value;
                    }
                    else
                    {
                        if (_gia.Count > 0)
                            giamoi.Gia = _gia.First().DonGia;
                    }
                    dsach.Add(giamoi);

                    break;
                #endregion
                case 3:
                    // Thuóc đông y không có số lô nên khi tinh theo số lô không trừ đi số lượng hư hao
                    var _gia3 = (from nhap in abc
                                 where (nhap.SoLo != null && nhap.SoLo != "")
                                 group new { nhap } by new { nhap.MaDV, nhap.DonGia, nhap.SoLo } into kq
                                 select new { kq.Key.DonGia, kq.Key.SoLo, soluong = (kq.Sum(p => p.nhap.SoLuongN) - kq.Sum(p => p.nhap.SoLuongX)), ngay = kq.Min(p => p.nhap.NgayNhap) }).OrderBy(p => p.ngay).ToList();
                    string _solo = null;
                    var kttutruc3 = data.KPhongs.Where(p => p.MaKP == makho).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
                    #region tủ trực
                    if (kttutruc3.Count > 0)// kiểm tra tủ trực
                    {
                        Common.SoLuongTon = 0;
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
                                var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == i.DonGia).Where(p => p.SoLo == (_solo)).Where(p => p.Status != 2).Where(p => p.Status == null || p.Status == 0)
                                            join kd in data.DThuocs.Where(p => p.MaKXuat == makho) on sl.IDDon equals kd.IDDon
                                            group sl by new { sl.DonGia, sl.SoLo } into kq
                                            select new { kq.Key.DonGia, kq.Key.SoLo, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                                double _slkd = 0;
                                if (slkd.Count > 0)
                                {
                                    _slkd = slkd.First().soluong;

                                }
                                Gia_SoLo_HanSuDung moi = new Gia_SoLo_HanSuDung();
                                if (i.soluong > 0)
                                {
                                    moi.SoLuong = i.soluong - _slkd;
                                    moi.Gia = i.DonGia;
                                    moi.SoLo = i.SoLo;
                                }
                                dsach.Add(moi);
                            }
                            if (dsach.Sum(p => p.SoLuong) > 0)
                                Common.SoLuongTon = dsach.Sum(p => p.SoLuong);
                        }


                    }
                    #endregion
                    #region không phải tủ trực
                    else
                    {
                        var kt = data.GiaUTs.Where(p => p.MaDV == maDV).Where(p => p.MaKP == makho).ToList();
                        Common.SoLuongTon = 0;
                        #region giá UT
                        if (kt.Count > 0)
                        {
                            //gia = kt.First().DonGia.Value;
                            // _macc = kt.First().m // thêm mã cc vào giá ưu tiên
                            Gia_SoLo_HanSuDung moi2 = new Gia_SoLo_HanSuDung();
                            moi2.Gia = kt.First().DonGia.Value;
                            moi2.SoLo = kt.First().SoLo;
                            var slkd = (from sl in data.DThuoccts.Where(p => p.MaDV == maDV).Where(p => p.DonGia == moi2.Gia && p.SoLo == moi2.SoLo).Where(p => p.Status == 0)
                                        join kd in data.DThuocs.Where(p => p.MaKXuat == makho) on sl.IDDon equals kd.IDDon
                                        group sl by new { sl.DonGia, sl.SoLo } into kq
                                        select new { kq.Key, kq.Key.SoLo, soluong = kq.Sum(p => p.SoLuong) }).ToList();
                            double _slkd = 0;
                            if (slkd.Count > 0)
                            {
                                _slkd = slkd.First().soluong;
                            }
                            if (_gia3.Where(p => p.DonGia == moi2.Gia && p.SoLo == moi2.SoLo).ToList().Count > 0 && _gia3.Where(p => p.DonGia == moi2.Gia && p.SoLo == moi2.SoLo).First().soluong > 0)
                            {
                                moi2.SoLuong = _gia3.Where(p => p.DonGia == moi2.Gia && p.SoLo == moi2.SoLo).First().soluong - _slkd;
                            }
                            if (moi2.SoLuong <= 0)
                            {
                                moi2.SoLuong = 0;
                                if (_gia.Count > 0)
                                {
                                    Double[] dsgia = new Double[_gia.Count];
                                    foreach (var i in _gia3.Where(p => p.SoLo != moi2.SoLo))
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
                                            moi2.SoLuong = i.soluong - _slkd1;
                                            moi2.Gia = i.DonGia;
                                            moi2.SoLo = i.SoLo;

                                        }


                                    }
                                }
                            }
                            dsach.Add(moi2);
                            Common.SoLuongTon = moi2.SoLuong;
                        }
                        #endregion
                        #region không có giá UT
                        else
                        {
                            Common.SoLuongTon = 0;
                            if (_gia.Count > 0)
                            {
                                Double[] dsgia = new Double[_gia.Count];
                                foreach (var i in _gia3)
                                {
                                    // tạo một biến soluongkd = i.soluong- soluongkd
                                    Gia_SoLo_HanSuDung moi3 = new Gia_SoLo_HanSuDung();
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
                                        moi3.SoLuong = i.soluong - _slkd;
                                        moi3.Gia = i.DonGia;
                                        moi3.SoLo = i.SoLo;
                                    }
                                    dsach.Add(moi3);
                                }
                                if (dsach.Sum(p => p.SoLuong) > 0)
                                    Common.SoLuongTon = dsach.Sum(p => p.SoLuong);
                            }

                        }
                    }
                    #endregion
                    #endregion
                    break;
            }
            return dsach.Where(p => p.Gia != 0 && p.SoLuong != 0).ToList();
        }

        public static double GetGiaSudung(Hospital data, int madv, double dongiaSD, int trongBH, int nhapxuat, int maKP, DateTime ngayke)
        {
            #region MyRegion


            //double rs = 0;
            //DateTime ngayht = FormatHelper.EndDate(ngayke);
            //if (nhapxuat == 1)
            //{

            //    rs = dongiaSD;
            //    var qdongia = data.DonGiaDVs.Where(p => p.NgayHieuLuc == null ? (true) : (p.NgayHieuLuc.Value <= ngayht)).Where(p => p.MaDV == madv && p.Status == true).Where(p => (trongBH == 1 && p.DonGiaX_BH == dongiaSD) || (trongBH == 0 && p.DonGiaX_DV == dongiaSD)).OrderByDescending(p => p.NgayHieuLuc).Select(p => p.DonGiaN).FirstOrDefault();
            //    if (qdongia != null)
            //    {
            //        rs = qdongia;
            //    }

            //}
            //else // lấy giá xuất
            //{
            //    var qdongia = data.DonGiaDVs.Where(p => p.NgayHieuLuc == null ? (true) : (p.NgayHieuLuc.Value <= ngayht)).Where(p => p.MaDV == madv && p.Status == true).OrderByDescending(p => p.NgayHieuLuc).Select(p => new { DonGiaX = trongBH == 1 ? p.DonGiaX_BH : p.DonGiaX_DV, p.DonGiaN }).FirstOrDefault();
            //    if (qdongia != null)
            //    {
            //        rs = qdongia.DonGiaX;



            //        var kttutruc = data.KPhongs.Where(p => p.MaKP == maKP).Where(p => p.PLoai.Contains("Tủ trực")).ToList();
            //        #region tủ trực
            //        if (kttutruc.Count > 0)// kiểm tra tủ trực
            //        {
            //            var qnd = (from nhap in data.NhapDs.Where(p => p.MaKP == maKP).OrderByDescending(p => p.NgayNhap)
            //                       join nhapct in data.NhapDcts.Where(p => p.MaDV == madv && p.DonGia == qdongia.DonGiaN) on nhap.IDNhap equals nhapct.IDNhap
            //                       group new { nhapct, nhap } by new { nhapct.MaDV, nhapct.DonGia } into kq
            //                       select new { kq.Key.DonGia, SoLuong = kq.Sum(p => p.nhapct.SoLuongX) }).ToList();
            //            var slkd0 = (from sl in data.DThuoccts.Where(p => p.MaDV == madv)//.Where(p => p.DonGia == qdongia.DonGiaN)
            //                             .Where(p => p.Status == null || p.Status == 0 || p.Status == 1)
            //                         join kd in data.DThuocs.Where(p => p.MaKXuat == maKP || p.MaKP == maKP).Where(p => p.Status != 2) on sl.IDDon equals kd.IDDon

            //                         select new
            //                         {
            //                             kd.NgayKe,
            //                             sl.MaDV,
            //                             sl.DonGia,
            //                             sl.TrongBH,
            //                             SLKD = (sl.MaKXuat == maKP && (sl.SoLuong > 0 || (sl.SoLuong < 0 && kd.KieuDon == 2))) ? sl.SoLuong : 0,
            //                             SLTra = (kd.MaKP == maKP && sl.Status == 0 && kd.KieuDon == 4) ? sl.SoLuong : 0// Đơn treo lĩnh HC VTYT (chỉ đơn trả dược mới trừ, đơn lĩnh thì không tính thêm : Ví dụ: tủ trực còn 50 viên, kê đơn trả cho kho tổng 30 viên (nhưng chưa lĩnh) cũng chỉ kê đơn cho bệnh nhân hoặc trả dược trong vòng 20 viên còn lại; Trường hợp kê đơn lĩnh thêm 40 viên, không được tính=> chỉ được tính khi nào đã lĩnh dược về khoa
            //                         }).ToList();

            //            var slkd1 = (from kd in slkd0
            //                         select new
            //                         {
            //                             kd.MaDV,
            //                             kd.SLKD,
            //                             kd.SLTra,
            //                             DonGia = _getGiaSD(data, kd.MaDV ?? 0, kd.DonGia, kd.TrongBH, 1, maKP, kd.NgayKe.Value)
            //                         }).Where(p => p.DonGia == qdongia.DonGiaN).ToList();
            //            var slkd = (from sl in slkd1
            //                        group new { sl } by sl.DonGia into kq
            //                        select new
            //                        {
            //                            kq.Key,
            //                            soluong = kq.Sum(p => p.sl.SLKD) - kq.Sum(p => p.sl.SLTra)
            //                        }).ToList();
            //            double _slkd = 0;

            //            if (slkd.Count > 0)
            //            {
            //                _slkd = slkd.First().soluong;
            //                double soluongDY = DungChung.Ham._getSL_DongY(data, madv, _slkd, maKP);
            //                _slkd = _slkd + soluongDY;
            //            }
            //            if (qnd.Count > 0)
            //                DungChung.Bien.SoLuongTon = qnd.First().SoLuong - _slkd;
            //            else
            //                DungChung.Bien.SoLuongTon = 0;
            //            if (DungChung.Bien.SoLuongTon <= 0)
            //                DungChung.Bien.SoLuongTon = 0;
            //        }
            //        #endregion
            //        else
            //        {
            //            var qnd = (from nhap in data.NhapDs.Where(p => p.MaKP == maKP).OrderByDescending(p => p.NgayNhap)
            //                       join nhapct in data.NhapDcts.Where(p => p.MaDV == madv && p.DonGia == qdongia.DonGiaN) on nhap.IDNhap equals nhapct.IDNhap
            //                       group new { nhapct, nhap } by new { nhapct.MaDV, nhapct.DonGia } into kq
            //                       select new { kq.Key.DonGia, SoLuong = (kq.Sum(p => p.nhapct.SoLuongN) - kq.Sum(p => p.nhapct.SoLuongX)) }).ToList();
            //            var slkd0 = (from sl in data.DThuoccts.Where(p => p.MaDV == madv)//.Where(p => p.DonGia == qdongia.DonGiaN)
            //                             .Where(p => p.Status == null || p.Status == 0)
            //                         join kd in data.DThuocs.Where(p => p.MaKXuat == maKP).Where(p => p.Status == 0).Where(p => p.KieuDon != 2) on sl.IDDon equals kd.IDDon

            //                         select new { sl.TrongBH, sl.MaDV, sl.DonGia, sl.SoLuong, kd.NgayKe }).ToList();
            //            var slkd1 = (from sl in slkd0
            //                         select new
            //                         {
            //                             sl.TrongBH,
            //                             sl.MaDV,
            //                             sl.SoLuong,
            //                             DonGia = _getGiaSD(data, sl.MaDV ?? 0, sl.DonGia, sl.TrongBH, 1, maKP, sl.NgayKe.Value)
            //                         }).Where(p => p.DonGia == qdongia.DonGiaN).ToList();

            //            var slkd = (from sl in slkd1
            //                        group sl by sl.DonGia into kq
            //                        select new { kq.Key, soluong = kq.Sum(p => p.SoLuong) }).ToList();
            //            double _slkd = 0;
            //            if (slkd.Count > 0)
            //            {
            //                _slkd = slkd.First().soluong;
            //                double soluongDY = DungChung.Ham._getSL_DongY(data, madv, _slkd, maKP);
            //                _slkd = _slkd + soluongDY;
            //            }
            //            if (qnd.Count > 0)
            //                DungChung.Bien.SoLuongTon = qnd.First().SoLuong - _slkd;
            //            else
            //                DungChung.Bien.SoLuongTon = 0;
            //            if (DungChung.Bien.SoLuongTon <= 0)
            //                DungChung.Bien.SoLuongTon = 0;
            //        }
            //    }
            //}
            //return rs;
            #endregion

            return 696969;
        }

    }

}
