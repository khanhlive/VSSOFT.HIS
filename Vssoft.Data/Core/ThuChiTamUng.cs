using System.Linq;
using System.Windows.Forms;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class ThuChiTamUngProvider
    {
        public static bool KiemTraTamThu(Hospital _data, int _mabn, int _IDCLS)
        {
            var bn = _data.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
            int _noitru = -1;
            string _doituong = "";

            if (bn.Count > 0)
            {
                _noitru = bn.First().NoiTru.Value;
                _doituong = bn.First().DTuong;
            }
            if (_noitru == 0)
            {
                var kt = _data.ChiDinhs.Where(p => p.IdCLS == _IDCLS).ToList();
                if (kt.Count > 0)
                {
                    if (Common.TamThuCLS == 1)
                    {
                        foreach (var a in kt)
                        {
                            if ((a.Status == 0 || a.Status == null) && (a.SoPhieu == null || a.SoPhieu <= 0))
                            {
                                MessageBox.Show("Bệnh nhân chưa nộp tiền dịch vụ. Bạn không thể thực hiện!");
                                return false;
                            }
                        }

                    }
                    if (Common.TamThuCLS == 2)
                    {
                        foreach (var a in kt)
                        {
                            if ((a.Status == 0 || a.Status == null) && (a.SoPhieu == null || a.SoPhieu <= 0) && _doituong != "BHYT")
                            {
                                MessageBox.Show("Bệnh nhân chưa nộp tiền dịch vụ. Bạn không thể thực hiện!");
                                return false;
                            }
                        }
                    }
                    if (Common.TamThuCLS == 3)
                    {
                        foreach (var a in kt)
                        {
                            if ((a.Status == 0 || a.Status == null) && (a.SoPhieu == null || a.SoPhieu <= 0) && a.TrongBH == 0)
                            {
                                MessageBox.Show("Bệnh nhân chưa nộp tiền dịch vụ. Bạn không thể thực hiện!");
                                return false;
                            }
                        }

                    }
                }
            }
            else
            {
                return true;
            }
            return true;
        }

        public static bool KiemTraTamThu_IDCD(Hospital _data, int _mabn, int _IDCD)
        {
            var bn = _data.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
            int _noitru = -1;
            string _doituong = "";

            if (bn.Count > 0)
            {
                _noitru = bn.First().NoiTru.Value;
                _doituong = bn.First().DTuong;
            }
            if (_noitru == 0)
            {
                var kt = (from cd in _data.ChiDinhs.Where(p => p.IDCD == _IDCD)
                          select new { cd.Status, cd.SoPhieu, cd.TrongBH }).FirstOrDefault();
                if (kt != null)
                {
                    if (Common.TamThuCLS == 1)
                    {
                        if ((kt.Status == 0 || kt.Status == null) && (kt.SoPhieu == null || kt.SoPhieu <= 0))
                        {
                            MessageBox.Show("Bệnh nhân chưa nộp tiền dịch vụ. Bạn không thể thực hiện!");
                            return false;
                        }


                    }
                    if (Common.TamThuCLS == 2)
                    {

                        if ((kt.Status == 0 || kt.Status == null) && (kt.SoPhieu == null || kt.SoPhieu <= 0) && _doituong != "BHYT")
                        {
                            MessageBox.Show("Bệnh nhân chưa nộp tiền dịch vụ. Bạn không thể thực hiện!");
                            return false;
                        }

                    }
                    if (Common.TamThuCLS == 3)
                    {

                        if ((kt.Status == 0 || kt.Status == null) && (kt.SoPhieu == null || kt.SoPhieu <= 0) && kt.TrongBH == 0)
                        {
                            MessageBox.Show("Bệnh nhân chưa nộp tiền dịch vụ. Bạn không thể thực hiện!");
                            return false;
                        }


                    }
                }
            }
            else
            {
                return true;
            }
            return true;
        }

        public static bool KiemtraThucHienDVDaTamThu(Hospital _data, int _MaBN, int _IDTamUngct)
        {
            bool KetQua = true;
            int _IDTamUng = 0, _MaDV = 0;
            var IDTamUng = (from tuct in _data.TamUngcts.Where(p => p.IDTamUngct == _IDTamUngct)
                            select new { tuct.IDTamUng, tuct.MaDV }).FirstOrDefault();
            if (IDTamUng != null)
            {
                _IDTamUng = IDTamUng.IDTamUng;
                _MaDV = IDTamUng.MaDV;
                var _lCD = (from cls in _data.CLS.Where(p => p.MaBNhan == _MaBN)
                            join cd in _data.ChiDinhs.Where(p => p.MaDV == _MaDV).Where(p => p.SoPhieu == _IDTamUng) on cls.IdCLS equals cd.IdCLS
                            select new { cd.Status, cd.IDCD }).ToList();
                if (_lCD.Count() > 0)
                {
                    if (_lCD.First().Status == 1)
                    {
                        KetQua = false;
                    }
                    else
                        KetQua = true;
                }
            }
            return KetQua;
        }

        public static void XoaTamUngct(Hospital _data, int _MaBn, int _IDTamUngct)
        {
            int _IDTamUng = 0, _MaDV = 0, idDon = 0;
            bool KtraNoiTru = false;
            var _lCongKham = (from nhom in _data.NhomDVs.Where(p => p.IDNhom == 13)
                              join tn in _data.TieuNhomDVs on nhom.IDNhom equals tn.IDNhom
                              join dv in _data.DichVus on tn.IdTieuNhom equals dv.IdTieuNhom
                              select new { dv.MaDV }).Distinct().ToList();
            var _Bn = _data.BenhNhans.Where(p => p.MaBNhan == _MaBn).ToList();
            if (_Bn.Count > 0)
                KtraNoiTru = true;
            var _lTUct = _data.TamUngcts.Where(p => p.IDTamUngct == _IDTamUngct).FirstOrDefault();
            if (_lTUct != null)
            {
                _IDTamUng = _lTUct.IDTamUng;
                _MaDV = _lTUct.MaDV;
                _lTUct.Status = 1;
                _data.SaveChanges();

                var _lTU = _data.TamUngs.Where(p => p.IDTamUng == _IDTamUng).FirstOrDefault();
                if (_lTU != null)
                {
                    _lTU.SoTien = _lTU.SoTien - _lTUct.ThanhTien;
                    _lTU.TienChenh = _lTU.TienChenh - _lTUct.ThanhTien;
                    _data.SaveChanges();
                }
                var _CheckCK = _lCongKham.Where(p => p.MaDV == _MaDV).ToList();
                if (_CheckCK.Count > 0)
                {
                    var dthuoct = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _MaBn)
                                   join dtct in _data.DThuoccts.Where(p => p.MaDV == _MaDV).Where(p => p.ThanhToan == 1) on dt.IDDon equals dtct.IDDon
                                   select dtct).ToList();
                    foreach (var a in dthuoct)
                    {
                        if (!KtraNoiTru)
                        {
                            idDon = a.IDDon ?? 0;
                            _data.DThuoccts.Remove(a);
                            _data.SaveChanges();
                            if (_data.DThuoccts.Where(p => p.IDDon == idDon).Count() == 0)
                            {
                                var qdthuoc = _data.DThuocs.Where(p => p.IDDon == idDon).FirstOrDefault();
                                if (qdthuoc != null)
                                {
                                    _data.DThuocs.Remove(qdthuoc);
                                    _data.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            a.ThanhToan = 0;
                            a.IDCD = 0;
                            _data.SaveChanges();
                        }

                    }
                }
                else
                {
                    var _lChiDinh = _data.ChiDinhs.Where(p => p.MaDV == _MaDV).Where(p => p.SoPhieu == _IDTamUng).FirstOrDefault();
                    if (_lChiDinh != null)
                    {
                        _lChiDinh.SoPhieu = null;
                        _data.SaveChanges();
                    }
                }
            }
        }
    }
}
