using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class CanLamSangProvider
    {
        public static string KiemTraCLS(Hospital _data, int maBN, string strTimkiem, int ploaiTKiem, double kq, List<string> TenRG)
        {
            string ktra = "center";
            List<DichVuct> _lDVct = new List<DichVuct>();
            if (ploaiTKiem == 0)
            {
                int stt = 0;
                int.TryParse(strTimkiem, out stt);
                var q1 = (from tenrg in TenRG
                          join tndv in _data.TieuNhomDVs on tenrg equals tndv.TenRG
                          join dv in _data.DichVus on tndv.IdTieuNhom equals dv.IdTieuNhom
                          join dvct in _data.DichVucts.Where(p => p.STT == stt) on dv.MaDV equals dvct.MaDV
                          select dvct).ToList();
                _lDVct.AddRange(q1);
            }
            if (ploaiTKiem == 1)
            {
                var q1 = (from tenrg in TenRG
                          join tndv in _data.TieuNhomDVs on tenrg equals tndv.TenRG
                          join dv in _data.DichVus on tndv.IdTieuNhom equals dv.IdTieuNhom
                          join dvct in _data.DichVucts.Where(p => p.MaDVct == strTimkiem) on dv.MaDV equals dvct.MaDV
                          select dvct).ToList();
                _lDVct.AddRange(q1);
            }
            var q = _data.BenhNhans.Where(p => p.MaBNhan == maBN).Select(p => p.GTinh);
            if (q.Count() > 0 && q.First() != null)
            {
                int GTinh = 0;
                GTinh = q.First().Value;
                if (q.First() != null && GTinh == 0)//Nếu là nữ
                {
                    if (_lDVct.Count() > 0)
                    {
                        String TSBTnu = _lDVct.First().TSBTnu;
                        if (TSBTnu != null && TSBTnu != "") // Nếu có TSBTnu
                        {
                            String TSnuTu = _lDVct.First().TSnuTu;
                            String TSnuDen = _lDVct.First().TSnuDen;
                            if (!String.IsNullOrEmpty(TSnuTu) && !String.IsNullOrEmpty(TSnuDen))
                            {
                                double nuTu = 0;
                                double nuDen = 0;
                                if (!double.TryParse(TSnuTu, out nuTu) || !double.TryParse(TSnuDen, out nuDen))
                                {
                                    return "center";
                                }

                                if (double.TryParse(TSnuTu, out nuTu) && double.TryParse(TSnuDen, out nuDen) && kq >= nuTu && kq <= nuDen)
                                {
                                    ktra = "center";
                                }
                                else if (double.TryParse(TSnuTu, out nuTu) && kq < nuTu)
                                {
                                    ktra = "left";
                                }
                                else if (double.TryParse(TSnuDen, out nuDen) && kq > nuDen)
                                {
                                    ktra = "right";
                                }
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(TSnuTu))
                                {
                                    double nuTu = 0;
                                    if (double.TryParse(TSnuTu, out nuTu))
                                    {
                                        if (TSBTnu.Contains(">"))
                                        {
                                            if (kq > nuTu)
                                            {
                                                ktra = "center";
                                            }
                                            else
                                                ktra = "left";
                                        }
                                        else
                                        {
                                            if (kq >= nuTu)
                                            {
                                                ktra = "center";
                                            }
                                            else
                                                ktra = "left";
                                        }
                                    }
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(TSnuDen))
                                    {
                                        double nuDen = 0;
                                        if (double.TryParse(TSnuDen, out nuDen))
                                        {
                                            if (TSBTnu.Contains("<"))
                                            {
                                                if (kq < nuDen)
                                                {
                                                    ktra = "center";
                                                }
                                                else
                                                    ktra = "right";
                                            }
                                            else
                                            {
                                                if (kq <= nuDen)
                                                {
                                                    ktra = "center";
                                                }
                                                else
                                                    ktra = "right";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else // Nếu không có TSBTnu
                        {
                            GTinh = 1;
                        }
                    }
                }
                if (q.First() != null && GTinh == 1)// Nếu là nam
                {
                    if (_lDVct.Count() > 0)
                    {
                        String TSBTn = "";
                        if (_lDVct.First().TSBTn != null)
                        {
                            TSBTn = _lDVct.First().TSBTn;
                        }
                        String TSnTu = _lDVct.First().TSnTu;
                        String TSnDen = _lDVct.First().TSnDen;
                        if (!String.IsNullOrEmpty(TSnTu) && !String.IsNullOrEmpty(TSnDen))
                        {
                            double nTu = 0;
                            double nDen = 0;
                            if (!double.TryParse(TSnTu, out nTu) || !double.TryParse(TSnDen, out nDen))
                            {
                                return "center";
                            }
                            if (double.TryParse(TSnTu, out nTu) && double.TryParse(TSnDen, out nDen) && kq >= nTu && kq <= nDen)
                            {
                                ktra = "center";
                            }
                            else if (double.TryParse(TSnTu, out nTu) && kq < nTu)
                            {
                                ktra = "left";
                            }
                            else if (double.TryParse(TSnDen, out nDen) && kq > nDen)
                            {
                                ktra = "right";
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(TSnTu))
                            {
                                double nTu = 0;
                                if (double.TryParse(TSnTu, out nTu))
                                {
                                    if (TSBTn.Contains(">"))
                                    {
                                        if (kq > nTu || nTu == 0)
                                        {
                                            ktra = "center";
                                        }
                                        else
                                            ktra = "left";
                                    }
                                    else
                                    {
                                        if (kq >= nTu || nTu == 0)
                                        {
                                            ktra = "center";
                                        }
                                        else if (kq < nTu)
                                        {
                                            ktra = "left";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(TSnDen))
                                {
                                    double nDen = 0;
                                    if (double.TryParse(TSnDen, out nDen))
                                    {
                                        if (TSBTn.Contains("<"))
                                        {
                                            if (kq < nDen || nDen == 0)
                                            {
                                                ktra = "center";
                                            }
                                            else
                                                ktra = "right";
                                        }
                                        else
                                        {
                                            if (kq <= nDen || nDen == 0)
                                            {
                                                ktra = "center";
                                            }
                                            else
                                                ktra = "right";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ktra;
        }

        public static string KiemTraThoiGianCDCLS(Hospital _data, int _MaBN)
        {
            string _lTenDV = "";
            DateTime _NgayHienTai = System.DateTime.Now, _NgayCD = System.DateTime.Now;
            var _lDichVu = (from dv in _data.DichVus.Where(p => p.PLoai == 2)
                            join tn in _data.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
                            select new { dv.MaDV, tn.TenTN, dv.TenDV, tn.TenRG }).ToList();
            var _lChiDinh = (from cls in _data.CLS.Where(p => p.MaBNhan == _MaBN)
                             join cd in _data.ChiDinhs.Where(p => p.Status == 0) on cls.IdCLS equals cd.IdCLS
                             select new { cd.IDCD, cls.NgayThang, cd.MaDV }).ToList();
            var _lKetQua = (from a in _lChiDinh
                            join b in _lDichVu on a.MaDV equals b.MaDV
                            select new { a.MaDV, a.NgayThang, a.IDCD, b.TenDV, b.TenRG, b.TenTN }).ToList();
            foreach (var item in _lKetQua)
            {
                if (item.NgayThang != null)
                {
                    _NgayCD = Convert.ToDateTime(item.NgayThang);
                    TimeSpan Test = _NgayHienTai - _NgayCD;
                    if (Test.Days >= 1)
                    {
                        _lTenDV += item.TenDV + ":\n";
                    }
                    else
                    {
                        if (Test.Hours >= 4)
                        {
                            _lTenDV += item.TenDV + ":\n";
                        }
                    }
                }
            }
            return _lTenDV;
        }
    }
}
