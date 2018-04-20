using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Extension.Class;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class BenhNhanProvider
    {
        #region hàm set khoa phòng hiện tại và nội-ngoại trú cho bệnh nhân

        public static bool SetMaKPToBenhNhan(Hospital _data, int _mabn, int _makp, int _noitru)
        {
            try
            {
                var sua = _data.BenhNhans.Single(p => p.MaBNhan == _mabn);
                if (_makp > 0)
                {
                    sua.MaKP = _makp;
                    //test

                    //
                }
                if (_noitru == 0 || _noitru == 1)
                    sua.NoiTru = _noitru;
                else
                    sua.NoiTru = sua.NoiTru;
                if (_noitru == 0)
                {
                    var vaovien = _data.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
                    if (vaovien.Count > 0)
                        sua.DTNT = true;
                    else
                        sua.DTNT = false;
                }
                else
                {
                    sua.DTNT = false;
                }
                _data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region hàm set trạng thái(Status) trong bảng "Bệnh nhân"
        public static void SetStatus(int mabenhnhan, int status)
        {
            Hospital DaTaContext = new Hospital();
            int _sokb = 0;
            try
            {
                int? max = DaTaContext.BenhNhans.Max(p => p.SoKB);
                _sokb = max ?? 0;
                _sokb++;
            }
            catch (Exception)
            {
                _sokb = 1;
            }
            if (status == 0)
                _sokb = 0;
            // kiểm tra ngoại trú mới thêm số kb;

            var ktnt = DaTaContext.BenhNhans.Where(p => p.MaBNhan == (mabenhnhan)).ToList();
            if (ktnt.Count > 0)
            {
                if (ktnt.First().NoiTru == 1)
                    _sokb = 0;
                else
                    if (ktnt.First().SoKB != null && ktnt.First().SoKB > 0)
                    _sokb = ktnt.First().SoKB.Value;
            }
            foreach (BenhNhan item in ktnt)
            {
                item.Status = status;
                if (status == 3 && item.SoKB == 0)
                    item.SoKB = _sokb;
                DaTaContext.SaveChanges();
            }
        }
        #endregion

        #region set SoKB

        public static bool SetSoKB(int mabn)
        {
            Hospital DaTaContext = new Hospital();
            int _sokb = 0;
            try
            {
                int? max = DaTaContext.BenhNhans.Where(p => p.NNhap != null && p.NNhap.Value.Year == DateTime.Now.Year).Max(p => p.SoKB);
                _sokb = max ?? 0;
                _sokb++;
                BenhNhan bn = DaTaContext.BenhNhans.Single(p => p.MaBNhan == mabn);
                bn.SoKB = _sokb;
                DaTaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region hàm set trạng thái(Status) trong bảng "Bệnh nhân"
        /// <summary>
        /// set trạng thái đã khám bệnh hay chưa
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="status"></param>
        /// <param name="makp"></param>
        public static void SetStatus(int ms, int status, int makp)
        {
            Hospital DaTaContext = new Hospital();
            int _sokb = 0;
            try
            {
                //var maxSD = DaTaContext.BenhNhans.Select(p => p.SoKB).ToList().OrderByDescending(p => p.Value).ToList();
                //if (maxSD.Count > 0)
                //    _sokb = maxSD.First().Value + 1;
                var maxSD = DaTaContext.BenhNhans.Max(p => p.SoKB);
                if (maxSD != null)
                    _sokb = maxSD.Value + 1;
                else
                    _sokb = 1;
            }
            catch (Exception)
            {
                _sokb = 1;
            }
            if (status == 0)
                _sokb = 0;
            // kiểm tra ngoại trú mới thêm số kb;
            //  int ktsokb = 0;
            var ktnt = DaTaContext.BenhNhans.Where(p => p.MaBNhan == ms).ToList();
            if (ktnt.Count > 0)
            {
                if (ktnt.First().NoiTru == 1)
                    _sokb = 0;
                else
                    if (ktnt.First().SoKB != null)
                    _sokb = ktnt.First().SoKB.Value;
            }
            var checkpph = DaTaContext.BNKBs.Where(p => p.MaKP == makp).Where(p => p.MaBNhan == ms).Where(p => p.PhuongAn == 4).ToList();//ktra nếu phương án=4(khám phối hợp) thì makp trong bang bn ko đổi đức
            if (checkpph.Count == 0)
            {
                foreach (var bnstatus in ktnt)
                {
                    if (makp > 0)
                    {
                        bnstatus.MaKP = makp;
                        // test

                        //
                    }
                    bnstatus.Status = status;
                }
            }
            //if (ktsokb == 0)
            //    bnstatus.SoKB = _sokb;
            DaTaContext.SaveChanges();
        }
        #endregion

        public static bool isKhamBenh(Hospital data, int mabn)
        {
            var q = data.BNKBs.Where(p => p.MaBNhan == mabn).ToList();
            if (q.Count > 0)
                return true;
            return false;
        }

        #region Ktra ngày nhập không được nhỏ hơn ngày nhập bệnh nhân
        public static bool KiemTraNgayNhap(Hospital data, int mabn, DateTime ngay)
        {
            var bn = data.BenhNhans.Where(p => p.MaBNhan == mabn).Select(p => p.NNhap).ToList();
            if (bn.Count > 0)
            {
                if ((ngay - bn.First().Value).Days < 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        public static string TuoitheoThang(Hospital _data, int mabn, string gioihan)
        {
            string tuoi = "";
            try
            {
                string[] _gioihan;
                _gioihan = gioihan.Split('-');
                int gioihanthang = 0, gioihanngay = 0;
                if (_gioihan.Length > 1)
                {
                    int.TryParse(_gioihan[0], out gioihanthang);
                    int.TryParse(_gioihan[1], out gioihanngay);
                }
                var bn = _data.BenhNhans.Where(p => p.MaBNhan == mabn).ToList();
                if (bn.Count > 0)
                {
                    int _tuoi = bn.First().Tuoi.Value;
                    tuoi = _tuoi.ToString();
                    int _ngays = 1;
                    int _thangs = 1;
                    int _nams = 1900;
                    if (bn.First().NgaySinh != null)
                        _ngays = Convert.ToInt32(bn.First().NgaySinh);
                    if (bn.First().ThangSinh != null)
                        _thangs = Convert.ToInt32(bn.First().ThangSinh);
                    if (bn.First().NamSinh != null)
                        _nams = Convert.ToInt32(bn.First().NamSinh);
                    int nam = bn.First().NNhap.Value.Year - _nams;
                    int thangtuoi = 0, ngaytuoi = 0;
                    if (_ngays == 0)
                        _ngays = 1;
                    if (_thangs == 0)
                        _thangs = 1;
                    string a = _ngays + "/" + _thangs + "/" + _nams;
                    DateTime _ngaysinh = Convert.ToDateTime(a);
                    if (nam <= 0)
                    {
                        thangtuoi = (bn.First().NNhap.Value.Month - _thangs);
                    }
                    else
                    {
                        thangtuoi = (bn.First().NNhap.Value.Month - _thangs) + 12 * nam;
                    }
                    ngaytuoi = (bn.First().NNhap.Value - _ngaysinh).Days;
                    if (thangtuoi <= gioihanthang)
                    {

                        if (ngaytuoi <= gioihanngay)
                        {
                            tuoi = ngaytuoi.ToString() + " ngày";
                        }
                        else
                        {
                            tuoi = thangtuoi.ToString() + " tháng";
                        }
                    }
                    else
                    {
                        tuoi = _tuoi.ToString();
                    }
                    return tuoi;
                }
                return tuoi;
            }
            catch (Exception ex)
            {
                return tuoi;
            }
        }

        public static string TuoitheoThang(DateTime _ngaynhap, string _ngayS, string _thangS, string _namS, int _tuoi, string gioihan)
        {
            string tuoi = "";
            try
            {
                string[] _gioihan;
                _gioihan = gioihan.Split('-');
                int gioihanthang = 0, gioihanngay = 0;
                if (_gioihan.Length > 1)
                {
                    int.TryParse(_gioihan[0], out gioihanthang);
                    int.TryParse(_gioihan[1], out gioihanngay);
                }

                tuoi = _tuoi.ToString();
                int _ngays = 1;
                int _thangs = 1;
                int _nams = 1900;
                if (!string.IsNullOrEmpty(_ngayS))
                    _ngays = Convert.ToInt32(_ngayS);
                if (!string.IsNullOrEmpty(_thangS))
                    _thangs = Convert.ToInt32(_thangS);
                if (!string.IsNullOrEmpty(_namS))
                    _nams = Convert.ToInt32(_namS);
                int nam = _ngaynhap.Year - _nams;
                int thangtuoi = 0, ngaytuoi = 0;
                if (_ngays == 0)
                    _ngays = 1;
                if (_thangs == 0)
                    _thangs = 1;
                string a = _ngays + "/" + _thangs + "/" + _nams;
                DateTime _ngaysinh = Convert.ToDateTime(a);
                if (nam <= 0)
                {
                    thangtuoi = (_ngaynhap.Month - _thangs) + 1;
                }
                else
                {
                    thangtuoi = (_ngaynhap.Month - _thangs) + 1 + 12 * nam;
                }
                ngaytuoi = (_ngaynhap - _ngaysinh).Days;
                if (thangtuoi <= gioihanthang)
                {

                    if (ngaytuoi <= gioihanngay)
                    {
                        tuoi = ngaytuoi.ToString() + "ng";
                    }
                    else
                    {
                        tuoi = thangtuoi.ToString() + "th";
                    }
                }
                else
                {
                    tuoi = _tuoi.ToString();
                }
                return tuoi;

            }
            catch (Exception)
            {
                return tuoi;
            }
        }

        public static bool KiemTraBenhNhanKhamBenhTrongNgay(Hospital _data, int _mabn, DateTime _dt)
        {
            var bn = _data.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
            string _sothe = "";
            if (bn.Count > 0 && bn.First().SThe != null && bn.First().DTuong == "BHYT")
                _sothe = bn.First().SThe;
            if (_sothe.Length == 15)
            {
                int _day = 0, _Month = 0, _year = 0;
                _day = _dt.Day;
                _Month = _dt.Month;
                _year = _dt.Year;
                var kt = (from bnhan in _data.BenhNhans.Where(p => p.SThe == _sothe)
                          join vp in _data.VienPhis.Where(p => p.NgayTT.Value.Day == _day && p.NgayTT.Value.Month == _Month && p.NgayTT.Value.Year == _year) on bnhan.MaBNhan equals vp.MaBNhan
                          select vp.MaBNhan).ToList();
                if (kt.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool KiemtraBenhnhanNoiNgoaitru(int mabn)
        {
            bool kt = true;
            if (Common.MaBV == "27021" || Common.MaBV == "01830")
            {
                Hospital data = new Hospital();
                var qbn = data.BenhNhans.Where(p => p.MaBNhan == mabn).FirstOrDefault();
                if (qbn == null || (qbn.NoiTru == 0 && qbn.DTNT == false))
                    return true;
                else
                {
                    var qcls = (from cls in data.CLS.Where(p => p.MaBNhan == mabn)
                                join kp in data.KPhongs.Where(p => p.PLoai == KhoaPhongPL.LamSang) on cls.MaKP equals kp.MaKP
                                select cls).ToList();
                    if (qcls.Count > 0)
                        return true;

                    var qdv = (from dt in data.DThuocs.Where(p => p.MaBNhan == mabn)
                               join dtct in data.DThuoccts on dt.IDDon equals dtct.IDDon
                               join kp in data.KPhongs.Where(p => p.PLoai == KhoaPhongPL.LamSang) on dtct.MaKP equals kp.MaKP
                               join dv in data.DichVus on dtct.MaDV equals dv.MaDV
                               select new { dv.PLoai, dtct.Status, dtct.SoLuong, dv.MaDV, dt.KieuDon }).ToList();
                    if (qdv.Count == 0)
                        return false;
                    if (qdv.Where(p => p.PLoai == 2).Count() > 0)
                        return true;
                    else
                    {
                        var qdaxuat = (from dv in qdv.Where(p => p.Status == 1) group dv by new { dv.MaDV } into kq select new { kq.Key.MaDV, SoLuong = kq.Sum(p => p.SoLuong) }).Where(p => p.SoLuong != 0).ToList();
                        if (qdaxuat.Count > 0)
                            return true;
                        var qChuaXuat = (from dv in qdv.Where(p => p.Status == 0) group dv by new { dv.MaDV, KieuDon = dv.KieuDon == 2 ? 1 : 0 } into kq select new { kq.Key.MaDV, kq.Key.KieuDon, SoLuong = kq.Sum(p => p.SoLuong) }).Where(p => p.SoLuong != 0).ToList();
                        if (qChuaXuat.Count > 0)
                            return true;
                        return false;

                    }
                }
            }


            return kt;
        }

        public static bool isDone(Hospital _dataContext, int _mabn)
        {
            var qrv = (from rv in _dataContext.RaViens.Where(p => p.MaBNhan == _mabn) select rv).ToList();
            if (qrv.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
