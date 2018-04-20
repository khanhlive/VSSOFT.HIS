using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.Models;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class BangKeReportProvider
    {
        //public static void BKeBNDichVu_01071(int _mabn)
        //{

        //    Hospital _dataContext = new Hospital();
        //    List<BangKeReportModel> _lbangke = new List<BangKeReportModel>();
        //    Form frm = new Form();
        //    int _HTTT = -1;
        //    string _muc = "", _tenbn = "", _DTuong = "";
        //    double _tienTThu = 0;

        //    int _hangbv = 1;

        //    var tt = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).ToList();
        //    if (tt.Count > 0)
        //    {

        //        if (_mabn > 0)
        //        {
        //            int _noitru = 0;

        //            var par = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
        //            var _ngaykham = _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDKB).ToList();
        //            var Rvien = _dataContext.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
        //            var vvien = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
        //            var tung = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //            if (tung.Where(p => p.PhanLoai == 0).ToList().Count > 0)
        //                _tienTThu = tung.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value;
        //            int idVP = 0;
        //            if (tt.Count > 0)
        //                idVP = tt.First().idVPhi;

        //            var vpcttong = _dataContext.VienPhicts.Where(p => p.idVPhi == idVP).ToList();
        //            var qvpct = (from vpct in vpcttong
        //                         group vpct by new { vpct.ThanhToan, vpct.DonVi, vpct.DonGia, vpct.Duyet, vpct.IDTamUng, vpct.idVPhi, vpct.MaDV, vpct.MaKP, vpct.Mien, vpct.TrongBH, vpct.TyLeBHTT, vpct.TyLeTT, vpct.XHH }
        //                             into kq
        //                         select new
        //                         {

        //                             DonGia = kq.Key.DonGia,
        //                             DonVi = kq.Key.DonVi,
        //                             Duyet = kq.Key.Duyet,
        //                             IDTamUng = kq.Key.IDTamUng,
        //                             idVPhi = kq.Key.idVPhi,
        //                             idVPhict = kq.FirstOrDefault().idVPhict,
        //                             MaDV = kq.Key.MaDV,
        //                             MaKP = kq.Key.MaKP,
        //                             Mien = kq.Key.Mien,
        //                             SoLuong = kq.Sum(p => p.SoLuong),
        //                             ThanhTien = kq.Sum(p => p.ThanhTien),
        //                             ThanhToan = kq.Key.ThanhToan,
        //                             TienBH = kq.Sum(p => p.TienBH),
        //                             TienBN = kq.Sum(p => p.TienBN),
        //                             TrongBH = kq.Key.TrongBH,
        //                             TyLeBHTT = kq.Key.TyLeBHTT,
        //                             TyLeTT = kq.Key.TyLeTT,
        //                             XHH = kq.Key.XHH,
        //                         }
        //                                      ).ToList();
        //            List<VienPhict> _lvpct = new List<VienPhict>();
        //            foreach (var a in qvpct)
        //            {
        //                VienPhict vpct = new VienPhict();
        //                vpct.DonGia = a.DonGia;
        //                vpct.DonVi = a.DonVi;
        //                vpct.Duyet = a.Duyet;
        //                vpct.IDTamUng = a.IDTamUng;
        //                vpct.idVPhi = a.idVPhi;
        //                vpct.idVPhict = a.idVPhict;
        //                vpct.MaDV = a.MaDV;
        //                vpct.MaKP = a.MaKP;
        //                vpct.Mien = a.Mien;
        //                vpct.SoLuong = a.SoLuong;
        //                vpct.ThanhTien = a.ThanhTien;
        //                vpct.ThanhToan = a.ThanhToan;
        //                vpct.TienBH = a.TienBH;
        //                vpct.TienBN = a.TienBN;
        //                vpct.TrongBH = a.TrongBH;
        //                vpct.TyLeBHTT = a.TyLeBHTT;
        //                vpct.TyLeTT = a.TyLeTT;
        //                vpct.XHH = a.XHH;
        //                _lvpct.Add(vpct);
        //            }
        //            var dichvu = (from dv in _dataContext.DichVus
        //                          join tn in _dataContext.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
        //                          join nhomdv in _dataContext.NhomDVs on tn.IDNhom equals nhomdv.IDNhom
        //                          select new { dv.SoTT, dv.TrongDM, dv.MaDV, dv.TenHC, dv.HamLuong, dv.MaQD, dv.SoQD, TenNhom = nhomdv.TenNhom, nhomdv.TenNhomCT, nhomdv.STT, dv.TenDV, dv.DonVi, dv.PLoai }).ToList();
        //            // thêm tenCK vào dich vụ công khám, tạm bổ ngày 26/07
        //            string[] _chuyenkhoa = new string[20];
        //            for (int i = 0; i < 20; i++)
        //            {
        //                _chuyenkhoa[i] = "";
        //            }
        //            int j = 0;

        //            foreach (var item in _ngaykham)
        //            {
        //                var ck = Common._lChuyenKhoa.Where(p => p.MaCK == item.MaCK).ToList();
        //                if (ck.Count > 0)
        //                {
        //                    _chuyenkhoa[j] = ck.First().ChuyenKhoa ?? "";
        //                    j++;
        //                }
        //            }
        //            int _iddtbn = -1; string _loaiDT = "";
        //            if (par.Count > 0)
        //            {
        //                _iddtbn = par.First().IDDTBN;

        //                _DTuong = par.First().DTuong;
        //                if (par.First().MucHuong != null && par.First().MucHuong.ToString() != "")
        //                    _muc = par.First().MucHuong.ToString();
        //                _noitru = par.First().NoiTru.Value;
        //                _tenbn = par.First().TenBNhan;
        //            }
        //            var dtbn = _dataContext.DTBNs.Where(p => p.IDDTBN == _iddtbn).ToList();
        //            if (dtbn.Count > 0)
        //            {
        //                _HTTT = dtbn.First().HTTT;
        //                _loaiDT = dtbn.First().DTBN1;
        //            }
        //            string maCQCQ = "";
        //            if (Common.MaTinh == "12")
        //            {
        //                var qcqcq = _dataContext.BenhViens.Where(p => p.MaBV == Common.MaBV).FirstOrDefault();
        //                if (qcqcq != null)
        //                    maCQCQ = qcqcq.MaChuQuan;
        //            }

        //            if (_hangbv == 4 && ((Common.MaTinh != "12" && Common.MaBV != "30280" && Common.MaBV != "30340" && Common.MaBV != "27001" && Common.MaBV != "04247" && Common.MaBV != "27183") || maCQCQ == "12001"))
        //                _noitru = 2;

        //            for (int m = 0; m < 2; m++)//0: Chi phí không phải xã hội hóa; 1: chi phí xã hội hóa
        //            {
        //                _lbangke.Clear();
        //                if (m == 1)
        //                {
        //                    var qxhh = (from vpct in _lvpct.Where(p => p.XHH > 0) select vpct).ToList();
        //                    if (qxhh.Count == 0)
        //                        break;
        //                }

        //                #region mau cu
        //                repBangKe01bv_A4_01071 rep = new repBangKe01bv_A4_01071();
        //                rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                rep.tenBN.Value = _tenbn;
        //                rep.TenBN2.Value = _tenbn;
        //                rep.MaBNhan.Value = _mabn;
        //                if (par.Count > 0)
        //                {
        //                    rep.KhuVuc.Value = par.First().KhuVuc;
        //                    rep.DiaChi.Value = par.First().DChi;
        //                    int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                    if (gioiTinh == 1)
        //                    {
        //                        rep.Nam.Value = "X";
        //                    }
        //                    else if (gioiTinh == 0)
        //                    {
        //                        rep.Nu.Value = "X";
        //                    }
        //                    if (_ngaykham.Count > 0)
        //                    {
        //                        DateTime _dt2 = System.DateTime.Now;
        //                        if (_ngaykham.First().NgayKham != null)
        //                        {
        //                            _dt2 = _ngaykham.First().NgayKham.Value;
        //                            rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                        }
        //                    }

        //                    if (Rvien.Count > 0)
        //                    {
        //                        DateTime _dt2 = System.DateTime.Now;

        //                        if (tt.First().NgayTT != null)
        //                        {
        //                            _dt2 = tt.First().NgayTT.Value;
        //                            rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                        }

        //                    }
        //                    _DTuong = (par.First().DTuong).ToString();
        //                    int dungtuyen = 0, capcuu = 0;

        //                    if (m == 0)
        //                        rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                    else
        //                        rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                    rep.koBH.Value = "X";
        //                    capcuu = int.Parse(par.First().CapCuu.ToString());
        //                    if (capcuu == 1)
        //                    {
        //                        rep.CapCuu.Value = "X";
        //                    }
        //                    rep.HanBHTu.Value = "";


        //                    if (tt.Count > 0)
        //                    {
        //                        StringDatetimeType _fmat = Common.FormatDate;
        //                        rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                    }

        //                    if (Rvien.Count > 0)
        //                    {
        //                        int _makp = 0;
        //                        if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                            _makp = Rvien.First().MaKP.Value;
        //                        var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                        if (kphong.Count > 0)
        //                            rep.KhoaPhong.Value = kphong.First().TenKP;
        //                        rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                        rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                        if (Rvien.First().SoNgaydt != null)
        //                            rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                        string _mabvchuyenden = "";
        //                        if (!string.IsNullOrEmpty(par.First().MaBV))
        //                            _mabvchuyenden = par.First().MaBV;
        //                        if (Rvien.First().MaBVC != null)
        //                            _mabvchuyenden = Rvien.First().MaBVC;
        //                        if (!string.IsNullOrEmpty(_mabvchuyenden))
        //                        {
        //                            var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                            if (bv.Count > 0)
        //                                rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                        }

        //                    }
        //                    if (par.First().SoKB != null)
        //                        rep.SoKB.Value = par.First().SoKB;
        //                    string _ngaysinh = "";
        //                    if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                        _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                    if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                        _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                    if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                        _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                    rep.NSinh.Value = _ngaysinh;
        //                    //bệnh nhân BHYT
        //                    var bk01 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                group new { vpct, dv } by new
        //                                {
        //                                    vp1.MaKP,
        //                                    TenNhom = vpct.TrongBH == 1 ? dv.TenNhom : dv.TenNhom.Replace("trong danh mục BHYT", ""),
        //                                    dv.STT,
        //                                    TenDV = dv.TenDV,
        //                                    vpct.DonVi,
        //                                    vpct.DonGia,//, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH 
        //                                    dv.PLoai
        //                                } into kq
        //                                select new { kq.Key.MaKP, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBN = kq.Sum(p => p.vpct.TienBN), TienBH = kq.Sum(p => p.vpct.TienBH), kq.Key.PLoai }).Where(p => p.SoLuong != 0).ToList();
        //                    var bk02 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                where (vpct.ThanhToan == 0)
        //                                group new { vpct, dv } by new
        //                                {
        //                                    vp1.MaKP,
        //                                    TenNhom = vpct.TrongBH == 1 ? dv.TenNhom : dv.TenNhom.Replace("trong danh mục BHYT", ""),
        //                                    dv.STT,
        //                                    TenDV = dv.TenDV,
        //                                    vpct.DonVi,
        //                                    vpct.DonGia,//, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH 
        //                                    dv.PLoai
        //                                } into kq
        //                                select new { kq.Key.MaKP, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBN = kq.Sum(p => p.vpct.TienBN), TienBH = kq.Sum(p => p.vpct.TienBH), kq.Key.PLoai }).Where(p => p.SoLuong != 0).ToList();

        //                    double tongchiphi = bk01.Sum(p => p.ThanhTien);

        //                    if (tongchiphi > 0)
        //                    {
        //                        rep.txtTT.Text = "Chi phí phải trả: " + Math.Round(tongchiphi, 0).ToString("###,###") + " đ";
        //                        rep.txtbangChu.Text = "Số tiền ghi bằng chữ: " + FormatHelper.DocTienBangChu(Math.Round(tongchiphi, 0), " đồng.");
        //                    }
        //                    else
        //                    {
        //                        rep.txtTT.Text = "Chi phí phải trả: 0 đ";
        //                        rep.txtbangChu.Text = "Số tiền ghi bằng chữ: Không đồng !";
        //                    }

        //                    var _tamung = (from a in _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn) select new { a.SoTien, a.PhanLoai, a.TienChenh }).ToList();
        //                    double tamung = _tamung.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien ?? 0);
        //                    if (tamung > 0)
        //                    {
        //                        rep.txtTienTamUng.Text = "- Đã nộp tiền đặt cọc: " + Math.Round(tamung, 0).ToString("###,###") + " đ";
        //                    }
        //                    else rep.txtTienTamUng.Text = "- Đã nộp tiền đặt cọc: 0 đ";
        //                    double datt = _tamung.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien ?? 0);
        //                    if (datt > 0)
        //                        rep.txtThuThang.Text = "- Đã thanh toán: " + Math.Round(datt, 0).ToString("###,###") + " đ";
        //                    else
        //                        rep.txtThuThang.Text = "- Đã thanh toán: 0 đ";
        //                    if (tamung + datt - tongchiphi > 0)
        //                    {
        //                        rep.txtNhanLai.Text = "- Bệnh nhân nhận lại: " + Math.Round((tamung + datt - tongchiphi), 0).ToString("###,###") + " đ";
                                
        //                    }
        //                    else
        //                    {
        //                        rep.txtNhanLai.Text = "- Phải thu thêm của bệnh nhân: " + Math.Round((tongchiphi - tamung - datt), 0).ToString("###,###") + " đ";//"- Bệnh nhân nhận lại: 0 đ";
                                
        //                    }

        //                    if (bk01.Count > 0)
        //                    {
        //                        rep.DataSource = bk01.ToList();
        //                        rep.BindingData();
        //                        rep.CreateDocument();
        //                        //rep.DataMember = "Table";
        //                        ////frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                        frm.ShowDialog();
        //                    }
        //                    #endregion
        //                }
        //            }
        //        }
        //    }
        //}

        //public static void BangkeTTBNDV_20001(int _mabn)
        //{

        //    Hospital _dataContext = new Hospital();
        //    List<BangKeReportModel> _lbangke = new List<BangKeReportModel>();
        //    Form frm = new Form();
        //    int _HTTT = -1;
        //    string _muc = "", _tenbn = "", _DTuong = "";
        //    double _tienTThu = 0;

        //    int _hangbv = 1;

        //    var tt = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).ToList();
        //    if (tt.Count > 0)
        //    {

        //        if (_mabn > 0)
        //        {
        //            int _noitru = 0;

        //            var par = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
        //            var _ngaykham = _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDKB).ToList();
        //            var Rvien = _dataContext.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
        //            var vvien = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
        //            var tung = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //            if (tung.Where(p => p.PhanLoai == 0).ToList().Count > 0)
        //                _tienTThu = tung.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value;
        //            int idVP = 0;
        //            if (tt.Count > 0)
        //                idVP = tt.First().idVPhi;

        //            var vpcttong = _dataContext.VienPhicts.Where(p => p.idVPhi == idVP).ToList();
        //            var qvpct = (from vpct in vpcttong
        //                         group vpct by new { vpct.ThanhToan, vpct.DonVi, vpct.DonGia, vpct.Duyet, vpct.IDTamUng, vpct.idVPhi, vpct.MaDV, vpct.MaKP, vpct.Mien, vpct.TrongBH, vpct.TyLeBHTT, vpct.TyLeTT, vpct.XHH }
        //                             into kq
        //                         select new
        //                         {

        //                             DonGia = kq.Key.DonGia,
        //                             DonVi = kq.Key.DonVi,
        //                             Duyet = kq.Key.Duyet,
        //                             IDTamUng = kq.Key.IDTamUng,
        //                             idVPhi = kq.Key.idVPhi,
        //                             idVPhict = kq.FirstOrDefault().idVPhict,
        //                             MaDV = kq.Key.MaDV,
        //                             MaKP = kq.Key.MaKP,
        //                             Mien = kq.Key.Mien,
        //                             SoLuong = kq.Sum(p => p.SoLuong),
        //                             ThanhTien = kq.Sum(p => p.ThanhTien),
        //                             ThanhToan = kq.Key.ThanhToan,
        //                             TienBH = kq.Sum(p => p.TienBH),
        //                             TienBN = kq.Sum(p => p.TienBN),
        //                             TrongBH = kq.Key.TrongBH,
        //                             TyLeBHTT = kq.Key.TyLeBHTT,
        //                             TyLeTT = kq.Key.TyLeTT,
        //                             XHH = kq.Key.XHH,
        //                         }
        //                                      ).ToList();
        //            List<VienPhict> _lvpct = new List<VienPhict>();
        //            foreach (var a in qvpct)
        //            {
        //                VienPhict vpct = new VienPhict();
        //                vpct.DonGia = a.DonGia;
        //                vpct.DonVi = a.DonVi;
        //                vpct.Duyet = a.Duyet;
        //                vpct.IDTamUng = a.IDTamUng;
        //                vpct.idVPhi = a.idVPhi;
        //                vpct.idVPhict = a.idVPhict;
        //                vpct.MaDV = a.MaDV;
        //                vpct.MaKP = a.MaKP;
        //                vpct.Mien = a.Mien;
        //                vpct.SoLuong = a.SoLuong;
        //                vpct.ThanhTien = a.ThanhTien;
        //                vpct.ThanhToan = a.ThanhToan;
        //                vpct.TienBH = a.TienBH;
        //                vpct.TienBN = a.TienBN;
        //                vpct.TrongBH = a.TrongBH;
        //                vpct.TyLeBHTT = a.TyLeBHTT;
        //                vpct.TyLeTT = a.TyLeTT;
        //                vpct.XHH = a.XHH;
        //                _lvpct.Add(vpct);
        //            }
        //            var dichvu = (from dv in _dataContext.DichVus
        //                          join tn in _dataContext.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
        //                          join nhomdv in _dataContext.NhomDVs on tn.IDNhom equals nhomdv.IDNhom
        //                          select new { dv.SoTT, dv.TrongDM, dv.MaDV, dv.TenHC, dv.HamLuong, dv.MaQD, dv.SoQD, nhomdv.TenNhom, nhomdv.TenNhomCT, nhomdv.STT, dv.TenDV, dv.DonVi, dv.PLoai }).ToList();
        //            // thêm tenCK vào dich vụ công khám, tạm bổ ngày 26/07
        //            string[] _chuyenkhoa = new string[20];
        //            for (int i = 0; i < 20; i++)
        //            {
        //                _chuyenkhoa[i] = "";
        //            }
        //            int j = 0;

        //            foreach (var item in _ngaykham)
        //            {
        //                //if (item.ChuyenKhoa != null)
        //                //{
        //                //    _chuyenkhoa[j] = item.ChuyenKhoa;                              
        //                //    j++;
        //                //}

        //                var ck = Common._lChuyenKhoa.Where(p => p.MaCK == item.MaCK).ToList();
        //                if (ck.Count > 0)
        //                {
        //                    _chuyenkhoa[j] = ck.First().ChuyenKhoa ?? "";
        //                    j++;
        //                }
        //            }
        //            int _iddtbn = -1; string _loaiDT = "";
        //            if (par.Count > 0)
        //            {
        //                _iddtbn = par.First().IDDTBN;

        //                _DTuong = par.First().DTuong;
        //                if (par.First().MucHuong != null && par.First().MucHuong.ToString() != "")
        //                    _muc = par.First().MucHuong.ToString();
        //                _noitru = par.First().NoiTru.Value;
        //                _tenbn = par.First().TenBNhan;
        //            }
        //            var dtbn = _dataContext.DTBNs.Where(p => p.IDDTBN == _iddtbn).ToList();
        //            if (dtbn.Count > 0)
        //            {
        //                _HTTT = dtbn.First().HTTT;
        //                _loaiDT = dtbn.First().DTBN1;
        //            }
        //            string maCQCQ = "";
        //            if (Common.MaTinh == "12")
        //            {
        //                var qcqcq = _dataContext.BenhViens.Where(p => p.MaBV == Common.MaBV).FirstOrDefault();
        //                if (qcqcq != null)
        //                    maCQCQ = qcqcq.MaChuQuan;
        //            }

        //            if (_hangbv == 4 && ((Common.MaTinh != "12" && Common.MaBV != "30280" && Common.MaBV != "30340" && Common.MaBV != "27001" && Common.MaBV != "04247" && Common.MaBV != "27183") || maCQCQ == "12001"))
        //                _noitru = 2;

        //            for (int m = 0; m < 2; m++)//0: Chi phí không phải xã hội hóa; 1: chi phí xã hội hóa
        //            {
        //                _lbangke.Clear();
        //                if (m == 1)
        //                {
        //                    var qxhh = (from vpct in _lvpct.Where(p => p.XHH > 0) select vpct).ToList();
        //                    if (qxhh.Count == 0)
        //                        break;
        //                }

        //                #region mau cu
        //                BaoCao.repBangKe01bv_A4_20001 rep = new BaoCao.repBangKe01bv_A4_20001();
        //                rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                rep.TenBN2.Value = _tenbn;
        //                rep.MaBNhan.Value = _mabn;
        //                if (par.Count > 0)
        //                {
        //                    rep.KhuVuc.Value = par.First().KhuVuc;
        //                    rep.DiaChi.Value = par.First().DChi;
        //                    int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                    if (gioiTinh == 1)
        //                    {
        //                        rep.Nam.Value = "X";
        //                    }
        //                    else if (gioiTinh == 0)
        //                    {
        //                        rep.Nu.Value = "X";
        //                    }
        //                    if (_ngaykham.Count > 0)
        //                    {
        //                        DateTime _dt2 = System.DateTime.Now;
        //                        if (_ngaykham.First().NgayKham != null)
        //                        {
        //                            _dt2 = _ngaykham.First().NgayKham.Value;
        //                            rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                        }
        //                    }

        //                    if (Rvien.Count > 0)
        //                    {
        //                        DateTime _dt2 = System.DateTime.Now;
        //                        //if (Common.MaBV == "30003")
        //                        //{
        //                        if (tt.First().NgayTT != null)
        //                        {
        //                            _dt2 = tt.First().NgayTT.Value;
        //                            rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                        }
        //                        //}
        //                        //else
        //                        //{
        //                        //    if (Rvien.First().NgayRa != null)
        //                        //    {
        //                        //        _dt2 = Rvien.First().NgayRa.Value;
        //                        //        rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                        //    }
        //                        //}
        //                    }
        //                    _DTuong = (par.First().DTuong).ToString();
        //                    int dungtuyen = 0, capcuu = 0;
        //                    if (_HTTT == 1) //   if (_DTuong.Contains("BHYT"))
        //                    {
        //                        rep.SoThe.Value = par.First().SThe;
        //                        rep.coBH.Value = "X";
        //                        //if(par.First().SThe!=null && par.First().SThe.ToString()!="" && par.First().SThe.Length>10)
        //                        // _muc = par.First().SThe.Substring(2, 1);

        //                        rep.HanBHTu.Value = par.First().HanBHTu;
        //                        rep.HanBHDen.Value = par.First().HanBHDen;
        //                        string macs = "";
        //                        if (par.First().MaCS != null)
        //                        {
        //                            macs = par.First().MaCS;
        //                            rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                        }
        //                        var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                        if (csdkbd.Count > 0)
        //                        {
        //                            rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                        }


        //                        if (par.First().Tuyen != null)
        //                        {
        //                            dungtuyen = int.Parse(par.First().Tuyen.ToString());
        //                        }

        //                        capcuu = int.Parse(par.First().CapCuu.ToString());
        //                        if (capcuu == 1)
        //                        {
        //                            rep.CapCuu.Value = "X";
        //                            rep.DungTuyen.Value = "";
        //                            rep.TraiTuyen.Value = "";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (m == 0)
        //                            rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                        else
        //                            rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                        rep.koBH.Value = "X";
        //                        capcuu = int.Parse(par.First().CapCuu.ToString());
        //                        if (capcuu == 1)
        //                        {
        //                            rep.CapCuu.Value = "X";
        //                        }
        //                        rep.HanBHTu.Value = "";
        //                    }

        //                    if (tt.Count > 0)
        //                    {
        //                        StringDatetimeType _fmat = Common.FormatDate;
        //                        if (Common.MaBV == "30002")
        //                            _fmat = StringDatetimeType.FullDate;
        //                        if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                            rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                        else if (Common.MaBV == "27001")
        //                            rep.NgayGD.Value = " Ngày ... tháng... năm......";
        //                        else
        //                            rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                        rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                    }

        //                    if (Rvien.Count > 0)
        //                    {
        //                        int _makp = 0;
        //                        if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                            _makp = Rvien.First().MaKP.Value;
        //                        var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                        if (kphong.Count > 0)
        //                            rep.KhoaPhong.Value = kphong.First().TenKP;
        //                        rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                        rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                        if (Rvien.First().SoNgaydt != null)
        //                            rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                        string _mabvchuyenden = "";
        //                        if (!string.IsNullOrEmpty(par.First().MaBV))
        //                            _mabvchuyenden = par.First().MaBV;
        //                        if (Rvien.First().MaBVC != null)
        //                            _mabvchuyenden = Rvien.First().MaBVC;
        //                        if (!string.IsNullOrEmpty(_mabvchuyenden))
        //                        {
        //                            var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                            if (bv.Count > 0)
        //                                rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                        }

        //                    }
        //                    if (par.First().SoKB != null)
        //                        rep.SoKB.Value = par.First().SoKB;
        //                    //if (vvien.First().SoVV != null)
        //                    //    rep.SoKB.Value = vvien.First().SoVV;
        //                    string _ngaysinh = "";
        //                    if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                        _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                    if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                        _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                    if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                        _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                    rep.NSinh.Value = _ngaysinh;
        //                    //bệnh nhân BHYT
        //                    var bk01 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                group new { vpct, dv } by new
        //                                {
        //                                    vp1.MaKP,
        //                                    dv.TenNhom,
        //                                    dv.STT,
        //                                    TenDV = dv.TenDV,
        //                                    vpct.DonVi,
        //                                    vpct.DonGia,//, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH 
        //                                    dv.PLoai
        //                                } into kq
        //                                select new { kq.Key.MaKP, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBN = kq.Sum(p => p.vpct.TienBN), TienBH = kq.Sum(p => p.vpct.TienBH), kq.Key.PLoai }).Where(p => p.SoLuong != 0).ToList();
        //                    var bk02 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                where (vpct.ThanhToan == 0)
        //                                group new { vpct, dv } by new
        //                                {
        //                                    vp1.MaKP,
        //                                    dv.TenNhom,
        //                                    dv.STT,
        //                                    TenDV = dv.TenDV,
        //                                    vpct.DonVi,
        //                                    vpct.DonGia,//, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH 
        //                                    dv.PLoai
        //                                } into kq
        //                                select new { kq.Key.MaKP, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBN = kq.Sum(p => p.vpct.TienBN), TienBH = kq.Sum(p => p.vpct.TienBH), kq.Key.PLoai }).Where(p => p.SoLuong != 0).ToList();
        //                    double tongthuoc = bk01.Where(p => p.PLoai == 1).Sum(p => p.ThanhTien);
        //                    double tongdv = bk01.Where(p => p.PLoai == 2).Sum(p => p.ThanhTien);
        //                    double tongchiphi = bk01.Sum(p => p.ThanhTien);
        //                    if (tongthuoc > 0)
        //                        rep.TongThuoc.Value = tongthuoc;
        //                    else rep.TongThuoc.Value = "0";
        //                    if (tongdv > 0)
        //                        rep.ChiPhiKhac.Value = tongdv;
        //                    else rep.ChiPhiKhac.Value = "0";
        //                    if (tongchiphi > 0)
        //                        rep.TongChiPhi.Value = tongchiphi;
        //                    else rep.TongChiPhi.Value = "0";

        //                    var _tamung = (from a in _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn) select new { a.SoTien, a.PhanLoai, a.TienChenh }).ToList();
        //                    double tamung = _tamung.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien ?? 0);
        //                    if (tamung > 0)
        //                    {
        //                        double hoanung = tamung - bk02.Sum(p => p.ThanhTien);
        //                        rep.HoanUng.Value = hoanung;
        //                        rep.TamUng.Value = tamung;
        //                    }
        //                    else rep.TamUng.Value = "0";
        //                    double datt = _tamung.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien ?? 0);
        //                    double chuathanhtoan = bk02.Sum(p => p.ThanhTien);
        //                    if (chuathanhtoan > 0)
        //                        rep.ChuaThanhToan.Value = chuathanhtoan;
        //                    else rep.ChuaThanhToan.Value = "0";
        //                    if (datt > 0)
        //                        rep.DaThanhToan.Value = datt;
        //                    else rep.DaThanhToan.Value = "0";

        //                    if (tamung - chuathanhtoan > 0)
        //                    {
        //                        rep.BVHoanTra.Value = "Bệnh viện hoàn trả:";
        //                        rep.BVHT.Value = tamung - chuathanhtoan;
        //                    }
        //                    else
        //                    {
        //                        rep.BVHoanTra.Value = "Bệnh nhân thanh toán:";
        //                        if (chuathanhtoan - tamung > 0)
        //                            rep.BVHT.Value = chuathanhtoan - tamung;
        //                        else rep.BVHT.Value = "0";
        //                    }
        //                    rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                    rep.TienBN.Value = bk01.Sum(p => p.TienBN);
        //                    var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                    rep.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                    if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                        rep.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                    else
        //                        rep.ThuTT.Value = 0;
        //                    if (bk01.Count > 0)
        //                    {
        //                        rep.DataSource = bk01.ToList();
        //                        rep.BindingData();
        //                        rep.CreateDocument();
        //                        //rep.DataMember = "Table";
        //                        ////frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                        frm.ShowDialog();
        //                    }
        //                    #endregion
        //                }
        //            }
        //        }
        //    }
        //}

        //public static void In_BangKe01_02(Hospital _dataContext, int _mabn, int _maubk, int kieu)
        //{
        //    //try
        //    //{
        //    _dataContext = new Hospital();
        //    List<BangKeReportModel> _lbangke = new List<BangKeReportModel>();
        //    Form frm = new Form();
        //    int _HTTT = -1;
        //    string _muc = "", _tenbn = "", _DTuong = "";
        //    double _tienTThu = 0;
        //    int _maubk01 = 0, _maubk02 = 0;
        //    // hiển thị biểu mẫu bảng kê 01BV
        //    int _hangbv = BenhvienProvider.GetHangBenhVien(Common.MaBV);
        //    string _CQCQ = "";
        //    string _MaBV = Common.MaBV;
        //    var CQCQ = _dataContext.BenhViens.Where(p => p.MaBV == _MaBV).Select(p => p.MaChuQuan).FirstOrDefault();
        //    if (CQCQ != null)
        //        _CQCQ = CQCQ;

        //    var tt = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).ToList();
        //    if (tt.Count > 0)
        //    {
        //        //if ((Common.MaBV == "27001" || Common.MaBV == "27022" || Common.MaBV == "30010" || Common.MaBV == "30340" || Common.MaBV == "30012" || Common.MaBV == "12128" || Common.MaBV == "12122" || Common.MaBV == "01830" || Common.MaBV == "30005" || Common.MaBV == "12038" || Common.MaBV == "08104" || Common.MaBV == "02005" || Common.MaBV == "19048" || Common.MaBV == "24009" || Common.MaBV == "26007" || Common.MaBV == "06007" || Common.MaBV == "30004" || Common.MaBV == "33080" || Common.MaBV == "33050" || Common.MaBV == "30003" || Common.MaBV == "12001" || Common.MaBV == "08204" || Common.MaBV == "08602" || Common.MaBV == "30281" || _maubk == 4) && _maubk != 5) // bảng kê a4
        //        //    _khoA4 = true;
        //        //else
        //        //    _khoA4 = false;
        //        if (kieu == 0)
        //        {
        //            var qthong = _dataContext.HTHONGs.Where(p => p.MaBV == Common.MaBV).Where(p => p.MauIn != null).Select(p => p.MauIn).FirstOrDefault();
        //            if (qthong != null)
        //            {
        //                string[] mauin = qthong.Split(';');
        //                if (mauin[0] != null && mauin[0] != "")
        //                    _maubk01 = Convert.ToInt32(mauin[0].Trim());
        //                if (mauin[1] != null && mauin[1] != "")
        //                    _maubk02 = Convert.ToInt32(mauin[1].Trim());
        //            }
        //        }
        //        else
        //        {
        //            switch (_maubk)
        //            {
        //                case 4:
        //                    _maubk01 = 1;
        //                    _maubk02 = 1;

        //                    break;
        //                case 5:
        //                    _maubk01 = 0;
        //                    _maubk02 = 0;

        //                    break;
        //                case 41:

        //                    _maubk01 = 2;
        //                    _maubk02 = 2;
        //                    break;
        //            }
        //        }
        //        // hiển thị biểu mẫu bảng kê 01BV
        //        if (_mabn > 0)
        //        {
        //            int _noitru = 0;

        //            var par = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
        //            var _ngaykham = _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDKB).ToList();
        //            var Rvien = _dataContext.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
        //            var vvien = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
        //            var tung = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //            if (tung.Where(p => p.PhanLoai == 0).ToList().Count > 0)
        //                _tienTThu = tung.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value;
        //            int idVP = 0;
        //            if (tt.Count > 0)
        //                idVP = tt.First().idVPhi;

        //            var vpcttong = _dataContext.VienPhicts.Where(p => p.idVPhi == idVP).ToList();
        //            var qvpct = (from vpct in vpcttong
        //                         group vpct by new { vpct.ThanhToan, vpct.DonVi, vpct.DonGia, vpct.Duyet, vpct.IDTamUng, vpct.idVPhi, vpct.MaDV, vpct.MaKP, vpct.Mien, vpct.TrongBH, vpct.TyLeBHTT, vpct.TyLeTT, vpct.XHH }
        //                             into kq
        //                         select new
        //                         {

        //                             DonGia = kq.Key.DonGia,
        //                             DonVi = kq.Key.DonVi,
        //                             Duyet = kq.Key.Duyet,
        //                             IDTamUng = kq.Key.IDTamUng,
        //                             idVPhi = kq.Key.idVPhi,
        //                             idVPhict = kq.FirstOrDefault().idVPhict,
        //                             MaDV = kq.Key.MaDV,
        //                             MaKP = kq.Key.MaKP,
        //                             Mien = kq.Key.Mien,
        //                             SoLuong = kq.Sum(p => p.SoLuong),
        //                             ThanhTien = kq.Sum(p => p.ThanhTien),
        //                             ThanhToan = kq.Key.ThanhToan,
        //                             TienBH = kq.Sum(p => p.TienBH),
        //                             TienBN = kq.Sum(p => p.TienBN),
        //                             TrongBH = kq.Key.TrongBH,
        //                             TyLeBHTT = kq.Key.TyLeBHTT,
        //                             TyLeTT = kq.Key.TyLeTT,
        //                             XHH = kq.Key.XHH,
        //                         }
        //                                      ).ToList();
        //            List<VienPhict> _lvpct = new List<VienPhict>();
        //            foreach (var a in qvpct)
        //            {
        //                VienPhict vpct = new VienPhict();
        //                vpct.DonGia = a.DonGia;
        //                vpct.DonVi = a.DonVi;
        //                vpct.Duyet = a.Duyet;
        //                vpct.IDTamUng = a.IDTamUng;
        //                vpct.idVPhi = a.idVPhi;
        //                vpct.idVPhict = a.idVPhict;
        //                vpct.MaDV = a.MaDV;
        //                vpct.MaKP = a.MaKP;
        //                vpct.Mien = a.Mien;
        //                vpct.SoLuong = a.SoLuong;
        //                vpct.ThanhTien = a.ThanhTien;
        //                vpct.ThanhToan = a.ThanhToan;
        //                vpct.TienBH = a.TienBH;
        //                vpct.TienBN = a.TienBN;
        //                vpct.TrongBH = a.TrongBH;
        //                vpct.TyLeBHTT = a.TyLeBHTT;
        //                vpct.TyLeTT = a.TyLeTT;
        //                vpct.XHH = a.XHH;
        //                _lvpct.Add(vpct);
        //            }
        //            var dichvu = (from dv in _dataContext.DichVus
        //                          join tn in _dataContext.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
        //                          join nhomdv in _dataContext.NhomDVs on tn.IDNhom equals nhomdv.IDNhom
        //                          select new { dv.SoTT, dv.TrongDM, dv.MaDV, dv.TenHC, dv.HamLuong, dv.MaQD, dv.SoQD, nhomdv.TenNhom, nhomdv.TenNhomCT, nhomdv.STT, dv.TenDV, dv.DonVi, dv.TenRG }).ToList();
        //            // thêm tenCK vào dich vụ công khám, tạm bổ ngày 26/07
        //            string[] _chuyenkhoa = new string[20];
        //            for (int i = 0; i < 20; i++)
        //            {
        //                _chuyenkhoa[i] = "";
        //            }
        //            int j = 0;

        //            foreach (var item in _ngaykham)
        //            {
        //                //if (item.ChuyenKhoa != null)
        //                //{
        //                //    _chuyenkhoa[j] = item.ChuyenKhoa;                              
        //                //    j++;
        //                //}

        //                var ck = Common._lChuyenKhoa.Where(p => p.MaCK == item.MaCK).ToList();
        //                if (ck.Count > 0)
        //                {
        //                    _chuyenkhoa[j] = ck.First().ChuyenKhoa ?? "";
        //                    j++;
        //                }
        //            }
        //            int _iddtbn = -1; string _loaiDT = "";
        //            if (par.Count > 0)
        //            {
        //                _iddtbn = par.First().IDDTBN;

        //                _DTuong = par.First().DTuong;
        //                if (par.First().MucHuong != null && par.First().MucHuong.ToString() != "")
        //                    _muc = par.First().MucHuong.ToString();
        //                _noitru = par.First().NoiTru.Value;
        //                _tenbn = par.First().TenBNhan;
        //            }
        //            var dtbn = _dataContext.DTBNs.Where(p => p.IDDTBN == _iddtbn).ToList();
        //            if (dtbn.Count > 0)
        //            {
        //                _HTTT = dtbn.First().HTTT;
        //                _loaiDT = dtbn.First().DTBN1; //dtbn.First().MoTa;
        //            }
        //            string maCQCQ = "";
        //            if (Common.MaTinh == "12")
        //            {
        //                var qcqcq = _dataContext.BenhViens.Where(p => p.MaBV == Common.MaBV).FirstOrDefault();
        //                if (qcqcq != null)
        //                    maCQCQ = qcqcq.MaChuQuan;
        //            }

        //            if (_hangbv == 4 && ((Common.MaTinh != "12" && Common.MaBV != "30280" && Common.MaBV != "30340" && Common.MaBV != "27001" && Common.MaBV != "04247" && Common.MaBV != "27183") || maCQCQ == "12001"))
        //                _noitru = 2;

        //            for (int m = 0; m < 2; m++)//0: Chi phí không phải xã hội hóa; 1: chi phí xã hội hóa
        //            {
        //                _lbangke.Clear();
        //                if (m == 1)
        //                {
        //                    var qxhh = (from vpct in _lvpct.Where(p => p.XHH > 0) select vpct).ToList();
        //                    if (qxhh.Count == 0)
        //                        break;
        //                }
        //                switch (_noitru)
        //                {
        //                    #region
        //                    case 0:
        //                        #region Bảng kê ngoại trú
        //                        #region lấy số thứ tự thanh toán 27001

        //                        string sodk = "";
        //                        if (Common.MaBV == "27001")
        //                        {
        //                            var qsodk = _dataContext.SoDKKBs.Where(p => p.MaBNhan == _mabn && p.Status == 3).FirstOrDefault();
        //                            if (qsodk != null)
        //                            {
        //                                sodk = qsodk.SoDK.ToString();
        //                            }
        //                        }
        //                        #endregion
        //                        if (_maubk01 == 1 || _maubk01 == 2)
        //                        {
        //                            if (vvien.Count > 0)
        //                            {
        //                                if (_maubk01 == 2)
        //                                {
        //                                    #region mau moi
        //                                    BaoCao.repBangKe01bv_A4_26007 rep = new BaoCao.repBangKe01bv_A4_26007();
        //                                    if (sodk != "")
        //                                    {
        //                                        rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                                        rep.STTThanhToan.Value = sodk;
        //                                    }
        //                                    rep.txtGiamDinhBH.Text = Common.MaBV == "30340" ? Common.GiamDinhBH : "";
        //                                    rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                                    rep.MaBNhan.Value = _mabn;
        //                                    if (par.Count > 0)
        //                                    {
        //                                        rep.KhuVuc.Value = par.First().KhuVuc;
        //                                        rep.DiaChi.Value = par.First().DChi;
        //                                        int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                                        if (gioiTinh == 1)
        //                                        {
        //                                            rep.Nam.Value = "X";
        //                                        }
        //                                        else if (gioiTinh == 0)
        //                                        {
        //                                            rep.Nu.Value = "X";
        //                                        }
        //                                        if (_ngaykham.Count > 0)
        //                                        {
        //                                            DateTime _dt2 = System.DateTime.Now;
        //                                            if (_ngaykham.First().NgayKham != null)
        //                                            {
        //                                                _dt2 = _ngaykham.First().NgayKham.Value;
        //                                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                            }
        //                                        }

        //                                        if (Rvien.Count > 0)
        //                                        {
        //                                            DateTime _dt2 = System.DateTime.Now;
        //                                            if (Common.MaBV == "30003")
        //                                            {
        //                                                if (tt.First().NgayTT != null)
        //                                                {
        //                                                    _dt2 = tt.First().NgayTT.Value;
        //                                                    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                if (Rvien.First().NgayRa != null)
        //                                                {
        //                                                    _dt2 = Rvien.First().NgayRa.Value;
        //                                                    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                            }
        //                                        }
        //                                        _DTuong = (par.First().DTuong).ToString();
        //                                        int dungtuyen = 0, capcuu = 0;
        //                                        if (_HTTT == 1) //   if (_DTuong.Contains("BHYT"))
        //                                        {
        //                                            rep.SoThe.Value = par.First().SThe;
        //                                            rep.coBH.Value = "X";
        //                                            //if(par.First().SThe!=null && par.First().SThe.ToString()!="" && par.First().SThe.Length>10)
        //                                            // _muc = par.First().SThe.Substring(2, 1);

        //                                            rep.HanBHTu.Value = par.First().HanBHTu;
        //                                            rep.HanBHDen.Value = par.First().HanBHDen;
        //                                            string macs = "";
        //                                            if (par.First().MaCS != null)
        //                                            {
        //                                                macs = par.First().MaCS;
        //                                                rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                            }
        //                                            var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                            if (csdkbd.Count > 0)
        //                                            {
        //                                                rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                            }


        //                                            if (par.First().Tuyen != null)
        //                                            {
        //                                                dungtuyen = int.Parse(par.First().Tuyen.ToString());
        //                                            }

        //                                            capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                            if (capcuu == 1)
        //                                            {
        //                                                rep.CapCuu.Value = "X";
        //                                                rep.DungTuyen.Value = "";
        //                                                rep.TraiTuyen.Value = "";
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            if (m == 1)
        //                                                rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                            else
        //                                                rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                            rep.koBH.Value = "X";
        //                                            capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                            if (capcuu == 1)
        //                                            {
        //                                                rep.CapCuu.Value = "X";
        //                                            }
        //                                            rep.HanBHTu.Value = "";
        //                                        }

        //                                        if (tt.Count > 0)
        //                                        {
        //                                            StringDatetimeType _fmat = Common.FormatDate;
        //                                            if (Common.MaBV == "30002")
        //                                                _fmat = StringDatetimeType.FullDate;
        //                                            if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                                rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                            else if (Common.MaBV == "27001")
        //                                                rep.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                            else
        //                                                rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                            rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                        }

        //                                        if (Rvien.Count > 0)
        //                                        {
        //                                            int _makp = 0;
        //                                            if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                                _makp = Rvien.First().MaKP.Value;
        //                                            var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                            if (kphong.Count > 0)
        //                                                rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                            rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                            rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                            if (Rvien.First().SoNgaydt != null)
        //                                                rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                            string _mabvchuyenden = "";
        //                                            if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                                _mabvchuyenden = par.First().MaBV;
        //                                            if (Rvien.First().MaBVC != null)
        //                                                _mabvchuyenden = Rvien.First().MaBVC;
        //                                            var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                            if (bv.Count > 0)
        //                                            {
        //                                                rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                                            }
        //                                        }


        //                                        if (par.First().SoKB != null)
        //                                            rep.SoKB.Value = par.First().SoKB;
        //                                        //if (vvien.First().SoVV != null)
        //                                        //    rep.SoKB.Value = vvien.First().SoVV;
        //                                        string _ngaysinh = "";
        //                                        if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                            _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                                        if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                            _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                                        if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                            _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                                        rep.NSinh.Value = _ngaysinh;
        //                                        //bệnh nhân BHYT
        //                                        if (_HTTT == 1)// if (_DTuong == "BHYT")
        //                                        {
        //                                            int i = 0;

        //                                            var bk01 = (from vp1 in tt
        //                                                        join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                        join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                        select new { vp1.MaKP, dv.TenHC, dv.TenRG, dv.HamLuong, dv.MaQD, dv.SoQD, dv.TenNhom, dv.TenNhomCT, dv.STT, MaKPct = vpct.MaKP, vpct.idVPhict, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).OrderBy(p => p.idVPhict).ToList();

        //                                            foreach (var item in bk01)
        //                                            {
        //                                                string tendv = item.TenDV;
        //                                                if (Common.MaBV == "30012")
        //                                                { tendv = (item.TenHC != null && item.TenHC != "") ? (item.TenHC + " (" + item.TenDV + ")") : item.TenDV; }  // tendv + "; " + (item.TenHC ?? "") + "; " + (item.HamLuong ?? "");}
        //                                                else if (Common.MaBV == "27183" || Common.MaBV == "12001")
        //                                                    tendv = item.TenDV + " " + item.HamLuong;
        //                                                else if (Common.MaBV == "12001" || _CQCQ == "12001")
        //                                                    tendv = (item.TenRG != null && item.TenRG.Trim() == "") ? item.TenRG : item.TenDV;
        //                                                // thêm tên chuyên khoa vào dịch vụ công khám, tạm bỏ 26/07
        //                                                //if (item.TenNhomCT == "Khám bệnh")
        //                                                //{
        //                                                //    tendv = tendv + " - " + _chuyenkhoa[i];
        //                                                //    i++;
        //                                                //}
        //                                                _lbangke.Add(new BangKeReportModel { TrongBH = item.TrongBH, DonGia = item.DonGia, DonVi = item.DonVi, IdVPhict = item.idVPhict, MaKP = item.MaKP ?? 0, MaKPct = item.MaKPct ?? 0, SoLuong = item.SoLuong, STT = item.STT ?? 0, TenDV = tendv, TenNhom = item.TenNhom, TienBH = item.TienBH, TienBN = item.TienBN, ThanhTien = item.ThanhTien, MaQD = item.MaQD, SoQD = item.SoQD });
        //                                            }
        //                                            double _tongtien = bk01.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien);
        //                                            if (dungtuyen == 1)
        //                                            {
        //                                                if (capcuu != 1)
        //                                                    rep.DungTuyen.Value = "X";
        //                                                if (m == 0)
        //                                                    rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                else
        //                                                    rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";

        //                                            }
        //                                            else if (dungtuyen == 2)
        //                                            {
        //                                                if (capcuu != 1)
        //                                                    rep.TraiTuyen.Value = "X";

        //                                                string kvuc = "";
        //                                                if (par.First().KhuVuc != null)
        //                                                    kvuc = par.First().KhuVuc;
        //                                                string muchuong = "";
        //                                                switch (_hangbv)
        //                                                {
        //                                                    case 1:

        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                        break;
        //                                                    case 2:
        //                                                        if (Common.MaBV == "01830")
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                        else
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                        break;
        //                                                    case 3:
        //                                                        if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                        {

        //                                                            if (kvuc.ToLower().Contains("k"))
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                            else
        //                                                                muchuong = "Mức hưởng: " + "70" + "%";
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            if (kvuc.ToLower().Contains("k"))
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                            else
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                        }
        //                                                        break;
        //                                                    case 4:
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                        break;

        //                                                }
        //                                                if (m == 0)
        //                                                    rep.mucHuong.Value = muchuong;
        //                                                else
        //                                                    rep.mucHuong.Value = muchuong + " (XHH)";

        //                                            }
        //                                            // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                            double sotien = 0;
        //                                            sotien = bk01.Sum(p => p.TienBN);
        //                                            rep.TienBN.Value = sotien;
        //                                            rep.TienBH.Value = bk01.Sum(p => p.TienBH);
        //                                            rep.Tongtien.Value = _tongtien;
        //                                            double tienCL = 0;
        //                                            tienCL = sotien - _tienTThu;
        //                                            if (Common.MaBV != "01071")
        //                                            {
        //                                                if (tienCL > 0)
        //                                                {
        //                                                    MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (tienCL < 0)
        //                                                    {
        //                                                        tienCL *= -1;
        //                                                        MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                                    }
        //                                                }
        //                                            }
        //                                            if (bk01.Count > 0)
        //                                            {
        //                                                rep.DataSource = _lbangke.ToList();
        //                                                rep.BindingData();
        //                                                rep.CreateDocument();
        //                                                //rep.DataMember = "Table";
        //                                                //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                frm.ShowDialog();
        //                                            }
        //                                        }// ket thuc BN BHYT
        //                                        else
        //                                        {
        //                                            var bk01 =
        //                                                 (from vp1 in tt
        //                                                  join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                  join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                  where vpct.ThanhToan == 0
        //                                                  select new { vp1.MaKP, dv.MaQD, dv.TenHC, dv.HamLuong, dv.SoQD, TenNhom = vpct.TrongBH == 1 ? dv.TenNhom : dv.TenNhom.Replace("trong danh mục BHYT", ""), dv.STT, TenDV = (Common.MaBV == "27183") ? (dv.TenDV + " " + dv.HamLuong) : ((Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : dv.TenDV) : dv.TenDV), vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).ToList();

        //                                            rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                                            rep.TienBN.Value = bk01.Sum(p => p.TienBN);
        //                                            var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                            rep.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                            if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                                rep.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                            else
        //                                                rep.ThuTT.Value = 0;
        //                                            if (bk01.Count > 0)
        //                                            {
        //                                                rep.DataSource = bk01.ToList();
        //                                                rep.BindingData();
        //                                                rep.CreateDocument();
        //                                                //rep.DataMember = "Table";
        //                                                //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                frm.ShowDialog();
        //                                            }
        //                                        }

        //                                        // kết thúc

        //                                    }

        //                                    #endregion
        //                                }

        //                                else
        //                                {
        //                                    if (Common.MaBV == "20001" && _DTuong == "Dịch vụ")
        //                                    {
        //                                        BangkeTTBNDV_20001(_mabn);
        //                                    }
        //                                    else if (Common.MaBV == "01071" && _DTuong == "Dịch vụ")
        //                                    {
        //                                        BKeBNDichVu_01071(_mabn);

        //                                        //InBangKePhongKham_01071(_mabn);
        //                                    }
        //                                    else
        //                                    {
        //                                        #region mau cu
        //                                        BaoCao.repBangKe01bv_A4 rep = new BaoCao.repBangKe01bv_A4();
        //                                        if (sodk != "")
        //                                        {
        //                                            rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                                            rep.STTThanhToan.Value = sodk;
        //                                        }
        //                                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                                        rep.TenBN2.Value = _tenbn;
        //                                        rep.MaBNhan.Value = _mabn;
        //                                        rep.txtGiamDinhBH.Text = Common.MaBV == "30340" ? Common.GiamDinhBH : "";
        //                                        rep.GDBH.Value = Common.MaBV == "30340" ? Common.GiamDinhBH : "";
        //                                        if (par.Count > 0)
        //                                        {
        //                                            rep.KhuVuc.Value = par.First().KhuVuc;
        //                                            rep.DiaChi.Value = par.First().DChi;
        //                                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                                            if (gioiTinh == 1)
        //                                            {
        //                                                rep.Nam.Value = "X";
        //                                            }
        //                                            else if (gioiTinh == 0)
        //                                            {
        //                                                rep.Nu.Value = "X";
        //                                            }
        //                                            if (_ngaykham.Count > 0)
        //                                            {
        //                                                DateTime _dt2 = System.DateTime.Now;
        //                                                if (_ngaykham.First().NgayKham != null)
        //                                                {
        //                                                    _dt2 = _ngaykham.First().NgayKham.Value;
        //                                                    rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                            }
        //                                            if (Rvien.Count > 0)
        //                                            {
        //                                                DateTime _dt2 = System.DateTime.Now;
        //                                                if (par.First().DTNT == true)
        //                                                {
        //                                                    if (Rvien.First().NgayRa != null)
        //                                                        _dt2 = Rvien.First().NgayRa.Value;
        //                                                    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (tt.First().NgayTT != null)
        //                                                    {
        //                                                        _dt2 = tt.First().NgayTT.Value;
        //                                                        rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                    }
        //                                                }
        //                                            }
        //                                            //if (Rvien.Count > 0)
        //                                            //{
        //                                            //    DateTime _dt2 = System.DateTime.Now;
        //                                            //    //if (Common.MaBV == "30003")
        //                                            //    //{
        //                                            //    if (tt.First().NgayTT != null)
        //                                            //    {
        //                                            //        _dt2 = tt.First().NgayTT.Value;
        //                                            //        rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                            //    }
        //                                            //    //}
        //                                            //    //else
        //                                            //    //{
        //                                            //    //    if (Rvien.First().NgayRa != null)
        //                                            //    //    {
        //                                            //    //        _dt2 = Rvien.First().NgayRa.Value;
        //                                            //    //        rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                            //    //    }
        //                                            //    //}
        //                                            //}
        //                                            _DTuong = (par.First().DTuong).ToString();
        //                                            int dungtuyen = 0, capcuu = 0;
        //                                            if (_HTTT == 1) //   if (_DTuong.Contains("BHYT"))
        //                                            {
        //                                                rep.SoThe.Value = par.First().SThe;
        //                                                rep.coBH.Value = "X";
        //                                                //if(par.First().SThe!=null && par.First().SThe.ToString()!="" && par.First().SThe.Length>10)
        //                                                // _muc = par.First().SThe.Substring(2, 1);

        //                                                rep.HanBHTu.Value = par.First().HanBHTu;
        //                                                rep.HanBHDen.Value = par.First().HanBHDen;
        //                                                string macs = "";
        //                                                if (par.First().MaCS != null)
        //                                                {
        //                                                    macs = par.First().MaCS;
        //                                                    rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                                }
        //                                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                                if (csdkbd.Count > 0)
        //                                                {
        //                                                    rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                                }


        //                                                if (par.First().Tuyen != null)
        //                                                {
        //                                                    dungtuyen = int.Parse(par.First().Tuyen.ToString());
        //                                                }

        //                                                capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                                if (capcuu == 1)
        //                                                {
        //                                                    rep.CapCuu.Value = "X";
        //                                                    rep.DungTuyen.Value = "";
        //                                                    rep.TraiTuyen.Value = "";
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                if (m == 0)
        //                                                    rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                                else
        //                                                    rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                                rep.koBH.Value = "X";
        //                                                capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                                if (capcuu == 1)
        //                                                {
        //                                                    rep.CapCuu.Value = "X";
        //                                                }
        //                                                rep.HanBHTu.Value = "";
        //                                            }

        //                                            if (tt.Count > 0)
        //                                            {
        //                                                StringDatetimeType _fmat = Common.FormatDate;
        //                                                if (Common.MaBV == "30002")
        //                                                    _fmat = StringDatetimeType.FullDate;
        //                                                if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                                    rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                                else if (Common.MaBV == "27001")
        //                                                    rep.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                                else
        //                                                    rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                            }

        //                                            if (Rvien.Count > 0)
        //                                            {
        //                                                int _makp = 0;
        //                                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                                    _makp = Rvien.First().MaKP.Value;
        //                                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                                if (kphong.Count > 0)
        //                                                    rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                                if (Rvien.First().SoNgaydt != null)
        //                                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                                string _mabvchuyenden = "";
        //                                                if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                                    _mabvchuyenden = par.First().MaBV;
        //                                                if (Rvien.First().MaBVC != null)
        //                                                    _mabvchuyenden = Rvien.First().MaBVC;
        //                                                if (!string.IsNullOrEmpty(_mabvchuyenden))
        //                                                {
        //                                                    var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                                    if (bv.Count > 0)
        //                                                    {
        //                                                        rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                                                        if (Common.MaBV == "12122")
        //                                                            rep.celLblNoiChuyenDen.Text = "Nơi chuyển đi";
        //                                                    }
        //                                                }

        //                                            }
        //                                            if (par.First().SoKB != null)
        //                                                rep.SoKB.Value = par.First().SoKB;
        //                                            //if (vvien.First().SoVV != null)
        //                                            //    rep.SoKB.Value = vvien.First().SoVV;
        //                                            string _ngaysinh = "";
        //                                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                                            rep.NSinh.Value = _ngaysinh;
        //                                            //bệnh nhân BHYT
        //                                            if (_HTTT == 1)// if (_DTuong == "BHYT")
        //                                            {
        //                                                int i = 0;

        //                                                var bk01 =
        //                                                       (from vp1 in tt
        //                                                        join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                        join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                        group new { vp1, vpct, dv } by new { vp1.MaKP, dv.TenNhom, dv.TenRG, dv.TenHC, dv.HamLuong, dv.TenNhomCT, dv.STT, MaKPct = vpct.MaKP, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.TrongBH, dv.TrongDM } into kq
        //                                                        select new { kq.Key.MaKP, kq.Key.TenNhom, kq.Key.TenRG, kq.Key.TenHC, kq.Key.HamLuong, kq.Key.TenNhomCT, kq.Key.STT, MaKPct = kq.Key.MaKP, idVPhict = kq.Max(p => p.vpct.idVPhict), kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN), kq.Key.TrongBH, kq.Key.TrongDM }).OrderBy(p => p.idVPhict).ToList();
        //                                                foreach (var item in bk01)
        //                                                {
        //                                                    string tendv = item.TenDV;
        //                                                    if (Common.MaBV == "30012")
        //                                                    { tendv = (item.TenHC != null && item.TenHC != "") ? (item.TenHC + " (" + item.TenDV + ")") : item.TenDV; }
        //                                                    else if (Common.MaBV == "27183")
        //                                                        tendv = item.TenDV + " " + item.HamLuong;
        //                                                    else if (Common.MaBV == "12001" || _CQCQ == "12001")
        //                                                        tendv = (item.TenRG != null && item.TenRG.Trim() != "") ? item.TenRG : item.TenDV;
        //                                                    // thêm tên chuyên khoa vào dịch vụ công khám, tạm bỏ 26/07
        //                                                    //if (item.TenNhomCT == "Khám bệnh")
        //                                                    //{
        //                                                    //    tendv = tendv + " - " + _chuyenkhoa[i];
        //                                                    //    i++;
        //                                                    //}
        //                                                    _lbangke.Add(new BangKeReportModel { TrongBH = item.TrongBH, DonGia = item.DonGia, DonVi = item.DonVi, IdVPhict = item.idVPhict, MaKP = item.MaKP ?? 0, MaKPct = item.MaKPct ?? 0, SoLuong = item.SoLuong, STT = item.STT ?? 0, TenDV = tendv, TenNhom = item.TenNhom, TienBH = item.TienBH, TienBN = item.TienBN, ThanhTien = item.ThanhTien });
        //                                                }
        //                                                double _tongtien = bk01.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien);
        //                                                if (dungtuyen == 1)
        //                                                {
        //                                                    if (capcuu != 1)
        //                                                        rep.DungTuyen.Value = "X";
        //                                                    if (m == 0)
        //                                                        rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    else
        //                                                        rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";

        //                                                }
        //                                                else if (dungtuyen == 2)
        //                                                {
        //                                                    if (capcuu != 1)
        //                                                        rep.TraiTuyen.Value = "X";

        //                                                    string kvuc = "";
        //                                                    if (par.First().KhuVuc != null)
        //                                                        kvuc = par.First().KhuVuc;
        //                                                    string muchuong = "";
        //                                                    switch (_hangbv)
        //                                                    {
        //                                                        case 1:
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                            break;
        //                                                        case 2:
        //                                                            if (Common.MaBV == "01830")
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                            else
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                            break;
        //                                                        case 3:
        //                                                            if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                            {

        //                                                                if (kvuc.ToLower().Contains("k"))
        //                                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                                else
        //                                                                    muchuong = "Mức hưởng: " + "70" + "%";
        //                                                            }
        //                                                            else
        //                                                            {
        //                                                                if (kvuc.ToLower().Contains("k"))
        //                                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                                else
        //                                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                            }
        //                                                            break;
        //                                                        case 4:
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                            break;

        //                                                    }
        //                                                    if (m == 0)
        //                                                        rep.mucHuong.Value = muchuong;
        //                                                    else

        //                                                        rep.mucHuong.Value = muchuong + " (XHH)";
        //                                                }
        //                                                // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                                double sotien = 0;
        //                                                sotien = bk01.Sum(p => p.TienBN);
        //                                                rep.TienBN.Value = sotien;
        //                                                rep.TienBH.Value = bk01.Sum(p => p.TienBH);
        //                                                rep.Tongtien.Value = _tongtien;
        //                                                double tienCL = 0;
        //                                                tienCL = sotien - _tienTThu;
        //                                                if (Common.MaBV != "01071")
        //                                                {
        //                                                    if (tienCL > 0)
        //                                                    {
        //                                                        MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (tienCL < 0)
        //                                                        {
        //                                                            tienCL *= -1;
        //                                                            MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                                        }
        //                                                    }
        //                                                }
        //                                                if (bk01.Count > 0)
        //                                                {
        //                                                    rep.DataSource = _lbangke.ToList();
        //                                                    rep.BindingData();
        //                                                    rep.CreateDocument();
        //                                                    //rep.DataMember = "Table";
        //                                                    //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                    frm.ShowDialog();
        //                                                }
        //                                            }// ket thuc BN BHYT
        //                                            else
        //                                            {
        //                                                var bk01 = (from vp1 in tt
        //                                                            join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                            join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                            where vpct.ThanhToan == 0
        //                                                            group new { vpct, dv } by new
        //                                                            {
        //                                                                vp1.MaKP,
        //                                                                dv.TenNhom,
        //                                                                dv.STT,
        //                                                                TenDV = (Common.MaBV == "27183") ? (dv.TenDV + " " + dv.HamLuong) : ((Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : dv.TenDV) : dv.TenDV),
        //                                                                vpct.DonVi,
        //                                                                vpct.DonGia//, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH 
        //                                                            } into kq
        //                                                            select new { kq.Key.MaKP, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBN = kq.Sum(p => p.vpct.TienBN), TienBH = kq.Sum(p => p.vpct.TienBH) }).Where(p => p.SoLuong != 0).ToList();

        //                                                rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                                                rep.TienBN.Value = bk01.Sum(p => p.TienBN);
        //                                                var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                                rep.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                                if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                                    rep.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                                else
        //                                                    rep.ThuTT.Value = 0;
        //                                                if (bk01.Count > 0)
        //                                                {
        //                                                    rep.DataSource = bk01.ToList();
        //                                                    rep.BindingData();
        //                                                    rep.CreateDocument();
        //                                                    //rep.DataMember = "Table";
        //                                                    //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                    frm.ShowDialog();
        //                                                }
        //                                            }

        //                                            // kết thúc

        //                                        }

        //                                        #endregion
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (_maubk01 == 2)
        //                                {
        //                                    #region bv 26007
        //                                    BaoCao.repBangKe01bv_A4_26007 rep = new BaoCao.repBangKe01bv_A4_26007();
        //                                    if (sodk != "")
        //                                    {
        //                                        rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                                        rep.STTThanhToan.Value = sodk;
        //                                    }
        //                                    rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                                    rep.MaBNhan.Value = _mabn;
        //                                    if (par.Count > 0)
        //                                    {
        //                                        rep.KhuVuc.Value = par.First().KhuVuc;
        //                                        rep.DiaChi.Value = par.First().DChi;
        //                                        int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                                        if (gioiTinh == 1)
        //                                        {
        //                                            rep.Nam.Value = "X";
        //                                        }
        //                                        else if (gioiTinh == 0)
        //                                        {
        //                                            rep.Nu.Value = "X";
        //                                        }
        //                                        if (_ngaykham.Count > 0)
        //                                        {
        //                                            DateTime _dt2 = System.DateTime.Now;
        //                                            if (_ngaykham.First().NgayKham != null)
        //                                            {
        //                                                _dt2 = _ngaykham.First().NgayKham.Value;
        //                                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                            }
        //                                        }

        //                                        if (Rvien.Count > 0)
        //                                        {
        //                                            DateTime _dt2 = System.DateTime.Now;
        //                                            if (Common.MaBV == "30003")
        //                                            {
        //                                                if (tt.First().NgayTT != null)
        //                                                {
        //                                                    _dt2 = tt.First().NgayTT.Value;
        //                                                    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                if (Rvien.First().NgayRa != null)
        //                                                    _dt2 = Rvien.First().NgayRa.Value;
        //                                                rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                            }
        //                                        }
        //                                        _DTuong = (par.First().DTuong).ToString();
        //                                        int dungtuyen = 0, capcuu = 0;

        //                                        if (_HTTT == 1)  //    if (_DTuong.Contains("BHYT"))
        //                                        {
        //                                            rep.SoThe.Value = par.First().SThe;
        //                                            rep.coBH.Value = "X";
        //                                            //if(par.First().SThe!=null && par.First().SThe.ToString()!="" && par.First().SThe.Length>10)
        //                                            // _muc = par.First().SThe.Substring(2, 1);

        //                                            rep.HanBHTu.Value = par.First().HanBHTu;
        //                                            rep.HanBHDen.Value = par.First().HanBHDen;
        //                                            string macs = "";
        //                                            if (par.First().MaCS != null)
        //                                            {
        //                                                macs = par.First().MaCS;
        //                                                rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                            }
        //                                            var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                            if (csdkbd.Count > 0)
        //                                            {
        //                                                rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                            }


        //                                            if (par.First().Tuyen != null)
        //                                            {
        //                                                dungtuyen = int.Parse(par.First().Tuyen.ToString());
        //                                            }

        //                                            capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                            if (capcuu == 1)
        //                                            {
        //                                                rep.CapCuu.Value = "X";
        //                                                rep.DungTuyen.Value = "";
        //                                                rep.TraiTuyen.Value = "";
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            if (m == 0)
        //                                                rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                            else
        //                                                rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                            rep.koBH.Value = "X";
        //                                            capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                            if (capcuu == 1)
        //                                            {
        //                                                rep.CapCuu.Value = "X";
        //                                            }
        //                                            rep.HanBHTu.Value = "";
        //                                        }
        //                                        if (tt.Count > 0)
        //                                        {
        //                                            StringDatetimeType _fmat = Common.FormatDate;
        //                                            if (Common.MaBV == "30002")
        //                                                _fmat = StringDatetimeType.FullDate;
        //                                            if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                                rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                            else if (Common.MaBV == "27001")
        //                                                rep.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                            else
        //                                                rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                            rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                        }

        //                                        if (Rvien.Count > 0)
        //                                        {
        //                                            int _makp = 0;
        //                                            if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                                _makp = Rvien.First().MaKP.Value;
        //                                            var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                            if (kphong.Count > 0)
        //                                                rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                            rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                            rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                            if (Rvien.First().SoNgaydt != null)
        //                                                rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                            string _mabvchuyenden = "";
        //                                            if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                                _mabvchuyenden = par.First().MaBV;
        //                                            if (!string.IsNullOrEmpty(Rvien.First().MaBVC))
        //                                            {

        //                                                _mabvchuyenden = Rvien.First().MaBVC;
        //                                                var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                                if (bv.Count > 0)
        //                                                    rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                                            }

        //                                        }
        //                                        if (par.First().SoKB != null)
        //                                            rep.SoKB.Value = par.First().SoKB;
        //                                        string _ngaysinh = "";
        //                                        if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                            _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                                        if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                            _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                                        if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                            _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                                        rep.NSinh.Value = _ngaysinh;
        //                                        #region bệnh nhân BHYT
        //                                        if (_HTTT == 1)//   if (_DTuong == "BHYT")
        //                                        {
        //                                            int i = 0;
        //                                            var bk01 = (from vp1 in tt
        //                                                        join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                        join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                        group new { vp1, dv, vpct } by new { vp1.MaKP, dv.MaQD, dv.TenHC, dv.HamLuong, dv.SoQD, dv.TenNhomCT, dv.TenNhom, MaKPct = vpct.MaKP, dv.STT, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.TrongBH, dv.TrongDM } into kq
        //                                                        select new { kq.Key.MaKP, kq.Key.MaQD, kq.Key.TenHC, kq.Key.HamLuong, kq.Key.SoQD, kq.Key.TenNhomCT, TenNhom = kq.Key.TrongBH == 1 ? kq.Key.TenNhom : kq.Key.TenNhom.Replace("trong danh mục BHYT", ""), kq.Key.MaKPct, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN), kq.Key.TrongBH, kq.Key.TrongDM, idVPhict = kq.Max(p => p.vpct.idVPhict) }).OrderBy(p => p.idVPhict).Where(p => p.SoLuong != 0).ToList();

        //                                            foreach (var item in bk01)
        //                                            {
        //                                                string tendv = item.TenDV;
        //                                                if (Common.MaBV == "30012")
        //                                                { tendv = (item.TenHC != null && item.TenHC != "") ? (item.TenHC + " (" + item.TenDV + ")") : item.TenDV; }
        //                                                else if (Common.MaBV == "27183" || Common.MaBV == "12001")
        //                                                    tendv = item.TenDV + " " + item.HamLuong;
        //                                                // thêm tên chuyên khoa vào dịch vụ công khám, tạm bỏ 26/07
        //                                                //if (item.TenNhomCT == "Khám bệnh")
        //                                                //{
        //                                                //    tendv = tendv + " - " + _chuyenkhoa[i];
        //                                                //    i++;
        //                                                //}
        //                                                _lbangke.Add(new BangKeReportModel
        //                                                {
        //                                                    TrongBH = item.TrongBH,
        //                                                    DonGia = item.DonGia,
        //                                                    DonVi = item.DonVi,
        //                                                    IdVPhict = item.idVPhict,
        //                                                    MaKP = item.MaKP ?? 0,
        //                                                    MaKPct = item.MaKPct ?? 0,
        //                                                    SoLuong = item.SoLuong,
        //                                                    STT = item.STT ?? 0,
        //                                                    TenDV = tendv,
        //                                                    TenNhom = item.TenNhom,
        //                                                    TienBH = item.TienBH,
        //                                                    TienBN = item.TienBN,
        //                                                    ThanhTien = item.ThanhTien,
        //                                                    SoQD = item.SoQD,
        //                                                    MaQD = item.MaQD
        //                                                });
        //                                            }
        //                                            double _tongtien = bk01.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien);
        //                                            if (dungtuyen == 1)
        //                                            {
        //                                                if (capcuu != 1)
        //                                                    rep.DungTuyen.Value = "X";
        //                                                if (m == 0)
        //                                                    rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                else

        //                                                    rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";
        //                                            }
        //                                            else if (dungtuyen == 2)
        //                                            {
        //                                                if (capcuu != 1)
        //                                                    rep.TraiTuyen.Value = "X";

        //                                                string kvuc = "";
        //                                                if (par.First().KhuVuc != null)
        //                                                    kvuc = par.First().KhuVuc;
        //                                                string muchuong = "";
        //                                                switch (_hangbv)
        //                                                {
        //                                                    case 1:
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                        break;
        //                                                    case 2:
        //                                                        if (Common.MaBV == "01830")
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                        else
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                        break;
        //                                                    case 3:
        //                                                        if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                        {

        //                                                            if (kvuc.ToLower().Contains("k"))
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                            else
        //                                                                muchuong = "Mức hưởng: " + "70" + "%";
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            if (kvuc.ToLower().Contains("k"))
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                            else
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";

        //                                                        }
        //                                                        break;
        //                                                    case 4:
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                        break;

        //                                                }
        //                                                if (m == 0)
        //                                                    rep.mucHuong.Value = muchuong;
        //                                                else
        //                                                    rep.mucHuong.Value = muchuong + " (XHH)";

        //                                            }
        //                                            // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                            double sotien = 0;
        //                                            sotien = bk01.Sum(p => p.TienBN);
        //                                            rep.TienBN.Value = sotien;
        //                                            rep.TienBH.Value = bk01.Sum(p => p.TienBH);
        //                                            rep.Tongtien.Value = _tongtien;
        //                                            double tienCL = 0;
        //                                            tienCL = sotien - _tienTThu;
        //                                            if (Common.MaBV != "01071")
        //                                            {
        //                                                if (tienCL > 0)
        //                                                {
        //                                                    MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (tienCL < 0)
        //                                                    {
        //                                                        tienCL *= -1;
        //                                                        MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                                    }
        //                                                }
        //                                            }
        //                                            if (bk01.Count > 0)
        //                                            {
        //                                                rep.DataSource = _lbangke.ToList();
        //                                                rep.BindingData();
        //                                                rep.CreateDocument();
        //                                                //rep.DataMember = "Table";
        //                                                //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                frm.ShowDialog();
        //                                            }
        //                                        }
        //                                        #endregion// ket thuc BN BHYT
        //                                        #region bn ko bảo hiểm
        //                                        else
        //                                        {
        //                                            var bk01 = (from vp1 in tt
        //                                                        join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                        join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                        where vpct.ThanhToan == 0
        //                                                        group new { vp1, dv, vpct } by new { vp1.MaKP, dv.MaQD, dv.TenHC, dv.HamLuong, dv.SoQD, dv.TenNhom, vpct.TrongBH, dv.STT, TenDV = Common.MaBV == "12001" ? (dv.TenDV + " " + dv.HamLuong) : dv.TenDV, vpct.DonVi, vpct.DonGia } into kq
        //                                                        select new { kq.Key.MaKP, kq.Key.MaQD, kq.Key.TenHC, kq.Key.HamLuong, kq.Key.SoQD, TenNhom = kq.Key.TrongBH == 1 ? kq.Key.TenNhom : kq.Key.TenNhom.Replace("trong danh mục BHYT", ""), kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN), kq.Key.TrongBH }).Where(p => p.SoLuong != 0).ToList();
        //                                            //select new { vp1.MaKP, dv.MaQD, dv.TenHC, dv.HamLuong, dv.SoQD, dv.TenNhom, vpct.TrongBH, dv.STT, TenDV = Common.MaBV == "12001" ? (dv.TenDV + " " + dv.HamLuong) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).ToList();
        //                                            if (bk01.Count > 0)
        //                                            {
        //                                                rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                                                rep.TienBN.Value = bk01.Sum(p => p.TienBN);
        //                                                var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                                rep.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                                if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                                    rep.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                                else
        //                                                    rep.ThuTT.Value = 0;
        //                                                rep.DataSource = bk01.ToList();
        //                                                rep.BindingData();
        //                                                rep.CreateDocument();
        //                                                //rep.DataMember = "Table";
        //                                                //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                frm.ShowDialog();
        //                                            }
        //                                        }

        //                                        #endregion kết thúc

        //                                    }

        //                                    #endregion
        //                                }

        //                                else
        //                                {
        //                                    if (Common.MaBV == "20001" && _DTuong == "Dịch vụ")
        //                                    {
        //                                        BangkeTTBNDV_20001(_mabn);
        //                                    }
        //                                    //else if (Common.MaBV == "01071" && _DTuong == "Dịch vụ")
        //                                    //{
        //                                    //    //InBangKePhongKham_01071(_mabn);
        //                                    //    BKeBNDichVu_01071(_mabn);
        //                                    //}
        //                                    else
        //                                    {
        //                                        #region bv chung
        //                                        BaoCao.repBangKe01bv_A4 rep = new BaoCao.repBangKe01bv_A4();
        //                                        if (sodk != "")
        //                                        {

        //                                            rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                                            rep.STTThanhToan.Value = sodk;
        //                                        }
        //                                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                                        rep.TenBN2.Value = _tenbn;
        //                                        rep.txtGiamDinhBH.Text = (Common.MaBV == "30340" || Common.MaBV == "30005") ? Common.GiamDinhBH : "";
        //                                        rep.GDBH.Value = (Common.MaBV == "30340" || Common.MaBV == "30005") ? Common.GiamDinhBH : "";
        //                                        rep.MaBNhan.Value = _mabn;
        //                                        if (par.Count > 0)
        //                                        {
        //                                            rep.KhuVuc.Value = par.First().KhuVuc;
        //                                            rep.DiaChi.Value = par.First().DChi;
        //                                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                                            if (gioiTinh == 1)
        //                                            {
        //                                                rep.Nam.Value = "X";
        //                                            }
        //                                            else if (gioiTinh == 0)
        //                                            {
        //                                                rep.Nu.Value = "X";
        //                                            }
        //                                            if (_ngaykham.Count > 0)
        //                                            {
        //                                                DateTime _dt2 = System.DateTime.Now;
        //                                                if (_ngaykham.First().NgayKham != null)
        //                                                {
        //                                                    _dt2 = _ngaykham.First().NgayKham.Value;
        //                                                    rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                            }

        //                                            if (Rvien.Count > 0)
        //                                            {
        //                                                DateTime _dt2 = System.DateTime.Now;
        //                                                //if (Common.MaBV == "30003")
        //                                                //{
        //                                                //if (tt.First().NgayTT != null)
        //                                                //{
        //                                                //    _dt2 = tt.First().NgayTT.Value;
        //                                                //    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                //}
        //                                                //}
        //                                                //else
        //                                                //{
        //                                                //    if (Rvien.First().NgayRa != null)
        //                                                //        _dt2 = Rvien.First().NgayRa.Value;
        //                                                //    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                //}
        //                                                if (par.First().DTNT == true)
        //                                                {
        //                                                    if (Rvien.First().NgayRa != null)
        //                                                        _dt2 = Rvien.First().NgayRa.Value;
        //                                                    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (tt.First().NgayTT != null)
        //                                                    {
        //                                                        _dt2 = tt.First().NgayTT.Value;
        //                                                        rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                                    }
        //                                                }
        //                                            }
        //                                            _DTuong = (par.First().DTuong).ToString();
        //                                            int dungtuyen = 0, capcuu = 0;
        //                                            #region bn BHYT
        //                                            if (_HTTT == 1)  //    if (_DTuong.Contains("BHYT"))
        //                                            {
        //                                                rep.SoThe.Value = par.First().SThe;
        //                                                rep.coBH.Value = "X";
        //                                                //if(par.First().SThe!=null && par.First().SThe.ToString()!="" && par.First().SThe.Length>10)
        //                                                // _muc = par.First().SThe.Substring(2, 1);

        //                                                rep.HanBHTu.Value = par.First().HanBHTu;
        //                                                rep.HanBHDen.Value = par.First().HanBHDen;
        //                                                string macs = "";
        //                                                if (par.First().MaCS != null)
        //                                                {
        //                                                    macs = par.First().MaCS;
        //                                                    rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                                }
        //                                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                                if (csdkbd.Count > 0)
        //                                                {
        //                                                    rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                                }


        //                                                if (par.First().Tuyen != null)
        //                                                {
        //                                                    dungtuyen = int.Parse(par.First().Tuyen.ToString());
        //                                                }

        //                                                capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                                if (capcuu == 1)
        //                                                {
        //                                                    rep.CapCuu.Value = "X";
        //                                                    rep.DungTuyen.Value = "";
        //                                                    rep.TraiTuyen.Value = "";
        //                                                }
        //                                            }
        //                                            #endregion
        //                                            #region bn ko có bh
        //                                            else
        //                                            {
        //                                                if (m == 0)
        //                                                    rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                                else
        //                                                    rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                                rep.koBH.Value = "X";
        //                                                capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                                if (capcuu == 1)
        //                                                {
        //                                                    rep.CapCuu.Value = "X";
        //                                                }
        //                                                rep.HanBHTu.Value = "";
        //                                            }
        //                                            if (tt.Count > 0)
        //                                            {
        //                                                StringDatetimeType _fmat = Common.FormatDate;
        //                                                if (Common.MaBV == "30002")
        //                                                    _fmat = StringDatetimeType.FullDate;
        //                                                if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                                    rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                                else if (Common.MaBV == "27001")
        //                                                    rep.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                                else
        //                                                    rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                            }

        //                                            if (Rvien.Count > 0)
        //                                            {
        //                                                int _makp = 0;
        //                                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                                    _makp = Rvien.First().MaKP.Value;
        //                                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                                if (kphong.Count > 0)
        //                                                    rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                                if (Rvien.First().SoNgaydt != null)
        //                                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                                string _mabvchuyenden = "";
        //                                                if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                                    _mabvchuyenden = par.First().MaBV;
        //                                                if (!string.IsNullOrEmpty(Rvien.First().MaBVC))
        //                                                {

        //                                                    _mabvchuyenden = Rvien.First().MaBVC;
        //                                                    var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                                    if (bv.Count > 0)
        //                                                    {
        //                                                        rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                                                        if (Common.MaBV == "12122")
        //                                                            rep.celLblNoiChuyenDen.Text = "Nơi chuyển đi";
        //                                                    }

        //                                                }

        //                                            }
        //                                            #endregion
        //                                            if (par.First().SoKB != null)
        //                                                rep.SoKB.Value = par.First().SoKB;
        //                                            string _ngaysinh = "";
        //                                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                                            rep.NSinh.Value = _ngaysinh;
        //                                            #region bệnh nhân BHYT
        //                                            if (_HTTT == 1)//   if (_DTuong == "BHYT")
        //                                            {
        //                                                int i = 0;
        //                                                var bk01 = (from vp1 in tt
        //                                                            join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                            join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                            group new { vp1, dv, vpct } by new { vp1.MaKP, dv.TenRG, dv.TenNhomCT, dv.HamLuong, dv.TenHC, dv.TenNhom, MaKPct = vpct.MaKP, dv.STT, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.TrongBH, dv.TrongDM } into kq
        //                                                            select new { kq.Key.MaKP, kq.Key.TenHC, kq.Key.TenRG, kq.Key.HamLuong, kq.Key.TenNhomCT, TenNhom = kq.Key.TrongBH == 1 ? kq.Key.TenNhom : kq.Key.TenNhom.Replace("trong danh mục BHYT", ""), kq.Key.MaKPct, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN), kq.Key.TrongBH, kq.Key.TrongDM, idVPhict = kq.Max(p => p.vpct.idVPhict) }).OrderBy(p => p.idVPhict).Where(p => p.SoLuong != 0).ToList();
        //                                                // select new { vp1.MaKP, dv.TenNhomCT, dv.HamLuong, dv.TenHC, dv.TenNhom, MaKPct = vpct.MaKP, dv.STT, vpct.idVPhict, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).OrderBy(p => p.idVPhict).ToList();


        //                                                foreach (var item in bk01)
        //                                                {
        //                                                    string tendv = item.TenDV;
        //                                                    if (Common.MaBV == "30012")
        //                                                    { tendv = (item.TenHC != null && item.TenHC != "") ? (item.TenHC + " (" + item.TenDV + ")") : item.TenDV; }
        //                                                    else if (Common.MaBV == "27183")
        //                                                        tendv = item.TenDV + " " + item.HamLuong;
        //                                                    else if (Common.MaBV == "12001" || _CQCQ == "12001")
        //                                                        tendv = (item.TenRG != null && item.TenRG.Trim() != "") ? item.TenRG : item.TenDV;
        //                                                    // thêm tên chuyên khoa vào dịch vụ công khám, tạm bỏ 26/07
        //                                                    //if (item.TenNhomCT == "Khám bệnh")
        //                                                    //{
        //                                                    //    tendv = tendv + " - " + _chuyenkhoa[i];
        //                                                    //    i++;
        //                                                    //}
        //                                                    _lbangke.Add(new BangKeReportModel { TrongBH = item.TrongBH, DonGia = item.DonGia, DonVi = item.DonVi, IdVPhict = item.idVPhict, MaKP = item.MaKP ?? 0, MaKPct = item.MaKPct ?? 0, SoLuong = item.SoLuong, STT = item.STT ?? 0, TenDV = tendv, TenNhom = item.TenNhom, TienBH = item.TienBH, TienBN = item.TienBN, ThanhTien = item.ThanhTien });
        //                                                }
        //                                                double _tongtien = bk01.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien);
        //                                                if (dungtuyen == 1)
        //                                                {
        //                                                    if (capcuu != 1)
        //                                                        rep.DungTuyen.Value = "X";
        //                                                    if (m == 0)
        //                                                        rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    else

        //                                                        rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";
        //                                                }
        //                                                else if (dungtuyen == 2)
        //                                                {
        //                                                    if (capcuu != 1)
        //                                                        rep.TraiTuyen.Value = "X";

        //                                                    string kvuc = "";
        //                                                    if (par.First().KhuVuc != null)
        //                                                        kvuc = par.First().KhuVuc;
        //                                                    string muchuong = "";
        //                                                    switch (_hangbv)
        //                                                    {
        //                                                        case 1:
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                            break;
        //                                                        case 2:
        //                                                            if (Common.MaBV == "01830")
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                            else
        //                                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                            break;
        //                                                        case 3:
        //                                                            if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                            {

        //                                                                if (kvuc.ToLower().Contains("k"))
        //                                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                                else
        //                                                                    muchuong = "Mức hưởng: " + "70" + "%";
        //                                                            }
        //                                                            else
        //                                                            {
        //                                                                if (kvuc.ToLower().Contains("k"))
        //                                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                                else
        //                                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";

        //                                                            }
        //                                                            break;
        //                                                        case 4:
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                            break;

        //                                                    }
        //                                                    if (m == 0)
        //                                                        rep.mucHuong.Value = muchuong;
        //                                                    else
        //                                                        rep.mucHuong.Value = muchuong + " (XHH)";

        //                                                }
        //                                                // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                                double sotien = 0;
        //                                                sotien = bk01.Sum(p => p.TienBN);
        //                                                rep.TienBN.Value = sotien;
        //                                                rep.TienBH.Value = bk01.Sum(p => p.TienBH);
        //                                                rep.Tongtien.Value = _tongtien;
        //                                                double tienCL = 0;
        //                                                tienCL = sotien - _tienTThu;
        //                                                if (Common.MaBV != "01071")
        //                                                {
        //                                                    if (tienCL > 0)
        //                                                    {
        //                                                        MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (tienCL < 0)
        //                                                        {
        //                                                            tienCL *= -1;
        //                                                            MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                                        }
        //                                                    }
        //                                                }
        //                                                if (bk01.Count > 0)
        //                                                {
        //                                                    rep.DataSource = _lbangke.ToList();
        //                                                    rep.BindingData();
        //                                                    rep.CreateDocument();
        //                                                    //rep.DataMember = "Table";
        //                                                    //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                    frm.ShowDialog();
        //                                                }
        //                                            }
        //                                            #endregion// ket thuc BN BHYT
        //                                            #region bn ko có BH
        //                                            else
        //                                            {
        //                                                var bk01 = (from vp1 in tt
        //                                                            join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                            join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                            where vpct.ThanhToan == 0
        //                                                            group new { vp1, dv, vpct } by new { vp1.MaKP, dv.HamLuong, dv.TenHC, dv.TenNhom, vpct.TrongBH, dv.STT, TenDV = (Common.MaBV == "27183") ? (dv.TenDV + " " + dv.HamLuong) : ((Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : dv.TenDV) : dv.TenDV), vpct.DonVi, vpct.DonGia } into kq
        //                                                            select new { kq.Key.MaKP, kq.Key.TenHC, kq.Key.HamLuong, TenNhom = kq.Key.TrongBH == 1 ? kq.Key.TenNhom : kq.Key.TenNhom.Replace("trong danh mục BHYT", ""), kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN), kq.Key.TrongBH }).Where(p => p.SoLuong != 0).ToList();
        //                                                // select new { vp1.MaKP, dv.HamLuong, dv.TenHC, dv.TenNhom, vpct.TrongBH, dv.STT, TenDV = (Common.MaBV == "27183" || Common.MaBV == "12001") ? (dv.TenDV + " " + dv.HamLuong) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).ToList();

        //                                                rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                                                rep.TienBN.Value = bk01.Sum(p => p.TienBN);
        //                                                var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                                rep.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                                if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                                    rep.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                                else
        //                                                    rep.ThuTT.Value = 0;
        //                                                if (bk01.Count > 0)
        //                                                {
        //                                                    rep.DataSource = bk01.ToList();
        //                                                    rep.BindingData();
        //                                                    rep.CreateDocument();
        //                                                    //rep.DataMember = "Table";
        //                                                    //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                                    frm.ShowDialog();
        //                                                }
        //                                            }

        //                                            #endregion// kết thúc

        //                                        }

        //                                        #endregion
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        #region bảng kê a5
        //                        else
        //                        {

        //                            BaoCao.repBangKe01bv rep = new BaoCao.repBangKe01bv();
        //                            if (sodk != "")
        //                            {
        //                                rep.STTThanhToan_lbl.Value = "Số TT: ";
        //                                rep.STTThanhToan.Value = sodk;
        //                            }
        //                            rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                            rep.MaBNhan.Value = _mabn;
        //                            if (par.Count > 0)
        //                            {
        //                                rep.KhuVuc.Value = par.First().KhuVuc;
        //                                rep.DiaChi.Value = par.First().DChi;
        //                                int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                                if (gioiTinh == 1)
        //                                {
        //                                    rep.Nam.Value = "X";
        //                                }
        //                                else if (gioiTinh == 0)
        //                                {
        //                                    rep.Nu.Value = "X";
        //                                }


        //                                if (_ngaykham.Count > 0)
        //                                {
        //                                    DateTime _dt2 = System.DateTime.Now;
        //                                    if (_ngaykham.First().NgayKham != null)
        //                                    {
        //                                        _dt2 = _ngaykham.First().NgayKham.Value;
        //                                        rep.NgayKham.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                    }
        //                                }

        //                                if (Rvien.Count > 0)
        //                                {
        //                                    DateTime _dt2 = System.DateTime.Now;
        //                                    //if (Common.MaBV == "30003")
        //                                    //{
        //                                    if (tt.First().NgayTT != null)
        //                                        _dt2 = tt.First().NgayTT.Value;
        //                                    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                    //}
        //                                    //else
        //                                    //{
        //                                    //    if (Rvien.First().NgayRa != null)
        //                                    //        _dt2 = Rvien.First().NgayRa.Value;
        //                                    //    rep.NgayKT.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                    //}
        //                                }
        //                                int dungtuyen = 0, capcuu = 0;
        //                                _DTuong = (par.First().DTuong).ToString();
        //                                if (_HTTT == 1)//   if (_DTuong.Contains("BHYT"))
        //                                {
        //                                    rep.SoThe.Value = par.First().SThe;
        //                                    rep.coBH.Value = "X";
        //                                    //if (par.First().SThe != null && par.First().SThe.ToString() != "" && par.First().SThe.Length > 10)
        //                                    //    _muc = par.First().SThe.Substring(2, 1);

        //                                    rep.HanBHTu.Value = par.First().HanBHTu;
        //                                    rep.HanBHDen.Value = par.First().HanBHDen;
        //                                    string macs = "";
        //                                    if (par.First().MaCS != null)
        //                                    {
        //                                        macs = par.First().MaCS;
        //                                        rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                    }
        //                                    var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                    if (csdkbd.Count > 0)
        //                                    {
        //                                        rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                    }

        //                                    if (par.First().Tuyen != null)
        //                                    {
        //                                        dungtuyen = int.Parse(par.First().Tuyen.ToString());
        //                                    }

        //                                    capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                    if (capcuu == 1)
        //                                    {
        //                                        rep.CapCuu.Value = "X";
        //                                        rep.DungTuyen.Value = "";
        //                                        rep.TraiTuyen.Value = "";
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                    else
        //                                        rep.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                    rep.koBH.Value = "X";
        //                                    capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                    if (capcuu == 1)
        //                                    {
        //                                        rep.CapCuu.Value = "X";
        //                                    }
        //                                    rep.HanBHTu.Value = "";
        //                                    rep.koBH.Value = "X";
        //                                }

        //                                if (Rvien.Count > 0)
        //                                {
        //                                    int _makp = 0;
        //                                    if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                        _makp = Rvien.First().MaKP.Value;
        //                                    var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                    if (kphong.Count > 0)
        //                                        rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                    rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                    rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                    if (Rvien.First().SoNgaydt != null)
        //                                        rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                    string _mabvchuyenden = "";
        //                                    if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                        _mabvchuyenden = par.First().MaBV;
        //                                    if (!string.IsNullOrEmpty(Rvien.First().MaBVC))
        //                                    {
        //                                        _mabvchuyenden = Rvien.First().MaBVC;
        //                                        var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                        if (bv.Count > 0)
        //                                        {
        //                                            rep.NoiChuyenDen.Value = bv.First().TenBV;
        //                                            if (Common.MaBV == "12122")
        //                                                rep.celLblNoiChuyenDen.Text = "Nơi chuyển đi";
        //                                        }

        //                                    }

        //                                }
        //                                string _ngaysinh = "";
        //                                if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                    _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                                if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                    _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                                if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                    _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                                rep.NSinh.Value = _ngaysinh;
        //                                var ngaytt = tt.FirstOrDefault().NgayTT;
        //                                if (ngaytt != null)
        //                                {
        //                                    StringDatetimeType _fmat = Common.FormatDate;
        //                                    if (Common.MaBV == "30002")
        //                                        _fmat = StringDatetimeType.FullDate;
        //                                    if (Common.MaBV == "27001")
        //                                        rep.NgayGD.Value = "Ngày ... tháng .... năm ......";
        //                                    else if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                        rep.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                    else
        //                                        rep.NgayGD.Value = FormatHelper.NgaySangChu(ngaytt.Value, _fmat);
        //                                    rep.NgayTT.Value = FormatHelper.NgaySangChu(ngaytt.Value, _fmat);
        //                                }
        //                                if (par.First().SoKB != null)
        //                                    rep.SoKB.Value = par.First().SoKB;
        //                                //bệnh nhân BHYT
        //                                if (_HTTT == 1) //    if (_DTuong == "BHYT")
        //                                {
        //                                    var bk01 = (from vp1 in tt
        //                                                join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                group new { vp1, dv, vpct } by new { dv.TenNhom, dv.HamLuong, dv.TenRG, dv.TenHC, dv.TenNhomCT, dv.STT, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.TrongBH, dv.TrongDM } into kq
        //                                                select new { kq.Key.TenHC, kq.Key.HamLuong, kq.Key.TenRG, kq.Key.TenNhomCT, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN), kq.Key.TrongBH, kq.Key.TrongDM, idVPhict = kq.Max(p => p.vpct.idVPhict) }).OrderBy(p => p.idVPhict).Where(p => p.SoLuong != 0).ToList();
        //                                    //select new { dv.TenNhom, dv.HamLuong, dv.TenHC, dv.TenNhomCT, vpct.idVPhict, dv.STT, dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).OrderBy(p => p.idVPhict).ToList();
        //                                    int i = 0;
        //                                    _lbangke.Clear();
        //                                    foreach (var item in bk01)
        //                                    {
        //                                        string tendv = item.TenDV;
        //                                        if (Common.MaBV == "30012")
        //                                        { tendv = (item.TenHC != null && item.TenHC != "") ? (item.TenHC + " (" + item.TenDV + ")") : item.TenDV; }
        //                                        else if (Common.MaBV == "27183")
        //                                            tendv = item.TenDV + " " + item.HamLuong;
        //                                        else if (_CQCQ == "12001" || Common.MaBV == "12001")
        //                                            tendv = (item.TenRG != null && item.TenRG.Trim() != "") ? item.TenRG : item.TenDV;
        //                                        // thêm tên chuyên khoa vào dịch vụ công khám, tạm bỏ 26/07
        //                                        //if (item.TenNhomCT == "Khám bệnh")
        //                                        //{
        //                                        //    tendv = tendv + " - " + _chuyenkhoa[i];
        //                                        //    i++;
        //                                        //}
        //                                        _lbangke.Add(new BangKeReportModel { TrongBH = item.TrongBH, DonGia = item.DonGia, DonVi = item.DonVi, IdVPhict = item.idVPhict, SoLuong = item.SoLuong, STT = item.STT ?? 0, TenDV = tendv, TenNhom = item.TenNhom, TienBH = item.TienBH, TienBN = item.TienBN, ThanhTien = item.ThanhTien });
        //                                    }
        //                                    double _tongtien = bk01.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien);
        //                                    if (dungtuyen == 1)
        //                                    {
        //                                        if (capcuu != 1)
        //                                            rep.DungTuyen.Value = "X";
        //                                        if (m == 0)
        //                                            rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                        else

        //                                            rep.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";
        //                                    }
        //                                    else if (dungtuyen == 2)
        //                                    {
        //                                        if (capcuu != 1)
        //                                            rep.TraiTuyen.Value = "X";

        //                                        string kvuc = "";
        //                                        if (par.First().KhuVuc != null)
        //                                            kvuc = par.First().KhuVuc;
        //                                        string muchuong = "";
        //                                        switch (_hangbv)
        //                                        {
        //                                            case 1:
        //                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                break;
        //                                            case 2:
        //                                                if (Common.MaBV == "01830")
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                else
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                break;
        //                                            case 3:
        //                                                if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                {

        //                                                    if (kvuc.ToLower().Contains("k"))
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    else
        //                                                        muchuong = "Mức hưởng: " + "70" + "%";
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (kvuc.ToLower().Contains("k"))
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    else
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                }
        //                                                break;
        //                                            case 4:
        //                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                break;

        //                                        }
        //                                        if (m == 0)
        //                                            rep.mucHuong.Value = muchuong;
        //                                        else
        //                                            rep.mucHuong.Value = muchuong + " (XHH)";
        //                                    }
        //                                    // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                    double sotien = 0;
        //                                    sotien = bk01.Sum(p => p.TienBN);
        //                                    rep.TienBN.Value = sotien;
        //                                    rep.TienBH.Value = bk01.Sum(p => p.TienBH);
        //                                    rep.Tongtien.Value = _tongtien;
        //                                    double tienCL = 0;
        //                                    tienCL = sotien - _tienTThu;
        //                                    if (Common.MaBV != "01071")
        //                                    {
        //                                        if (tienCL > 0)
        //                                        {
        //                                            MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                        }
        //                                        else
        //                                        {
        //                                            if (tienCL < 0)
        //                                            {
        //                                                tienCL *= -1;
        //                                                MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                            }
        //                                        }
        //                                    }
        //                                    if (bk01.Count > 0)
        //                                    {
        //                                        rep.DataSource = _lbangke.ToList();
        //                                        rep.BindingData();
        //                                        rep.CreateDocument();
        //                                        //  rep.DataMember = "Table";
        //                                        //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                        frm.ShowDialog();
        //                                    }
        //                                }// ket thuc BN BHYT
        //                                else
        //                                {
        //                                    var bk01 = (from vp1 in tt
        //                                                join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                where vpct.ThanhToan == 0
        //                                                group new { vp1, dv, vpct } by new { dv.TenNhom, dv.TenHC, dv.HamLuong, dv.STT, TenDV = (Common.MaBV == "27183") ? (dv.TenDV + " " + dv.HamLuong) : ((_CQCQ == "12001" || Common.MaBV == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : dv.TenDV) : dv.TenDV), vpct.DonVi, vpct.DonGia } into kq
        //                                                select new { kq.Key.TenHC, kq.Key.HamLuong, kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.vpct.SoLuong), ThanhTien = kq.Sum(p => p.vpct.ThanhTien), TienBH = kq.Sum(p => p.vpct.TienBH), TienBN = kq.Sum(p => p.vpct.TienBN) }).Where(p => p.SoLuong != 0).ToList();
        //                                    if (bk01.Count > 0)
        //                                    {
        //                                        // select new { dv.TenNhom, dv.TenHC, dv.HamLuong, dv.STT, TenDV = (Common.MaBV == "27183" || Common.MaBV == "12001") ? (dv.TenDV + " " + dv.HamLuong) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).ToList();
        //                                        rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                                        rep.TienBN.Value = bk01.Sum(p => p.TienBN);
        //                                        var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                        rep.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                        if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                            rep.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                        else
        //                                            rep.ThuTT.Value = 0;
        //                                        rep.DataSource = bk01.ToList();
        //                                        rep.BindingData();
        //                                        rep.CreateDocument();
        //                                        //rep.DataMember = "Table";
        //                                        //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                        frm.ShowDialog();
        //                                    }
        //                                }

        //                                // kết thúc

        //                            }
        //                        }
        //                        #endregion bảng kê a5 kết thúc
        //                        break;
        //                    #endregion
        //                    #endregion
        //                    #region bảng kê nội trú
        //                    case 1:

        //                        if (_maubk02 == 2)
        //                        {
        //                            #region bv 26027
        //                            List<int> lMaThuocHoiChan = new List<int>();// danh sách mã thuốc hội chẩn
        //                            var kp02 = (from bns in _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDKB) join kps in _dataContext.KPhongs on bns.MaKP equals kps.MaKP select kps.TenKP).ToList();


        //                            //lấy ra danh sách thuốc hội chẩn
        //                            if (Common.MaBV == "26007")
        //                            {
        //                                var qhoichan = _dataContext.BBHCs.Where(p => p.MaBNhan == _mabn).ToList();

        //                                foreach (var a in qhoichan)
        //                                {
        //                                    DateTime ngayHC = a.NgayHC.Value.Date;
        //                                    var qdt = (from dt in _dataContext.DThuocs.Where(p => p.MaBNhan == _mabn && p.MaKP == a.MaKP)
        //                                               join dtct in _dataContext.DThuoccts on dt.IDDon equals dtct.IDDon
        //                                               join dv in _dataContext.DichVus.Where(p => p.PLoai == 1) on dtct.MaDV equals dv.MaDV
        //                                               select new { NgayKe = dt.NgayKe, dv.MaDV }).ToList();
        //                                    foreach (var b in qdt)
        //                                    {
        //                                        if (b.NgayKe != null && b.NgayKe.Value.Date == ngayHC)
        //                                            lMaThuocHoiChan.Add(b.MaDV);
        //                                    }
        //                                }
        //                            }


        //                            BaoCao.repBangKe02bv_26007 rep02 = new BaoCao.repBangKe02bv_26007(lMaThuocHoiChan);

        //                            //kiểm tra bệnh nhân hội chẩn
        //                            if (Common.MaBV == "26007")
        //                            {

        //                                var qhoichan = _dataContext.BBHCs.Where(p => p.MaBNhan == _mabn).ToList();

        //                                if (qhoichan.Count > 0)
        //                                {
        //                                    rep02.HoiChan.Value = "x";
        //                                }
        //                                else
        //                                    rep02.HoiChan.Value = "";
        //                            }


        //                            rep02.tenBN.Value = _tenbn;
        //                            rep02.MaBNhan.Value = _mabn;

        //                            if (kp02.Count > 0)
        //                            {
        //                                rep02.KhoaPhong.Value = kp02.Last();
        //                            }
        //                            var par02 = (from bn in _dataContext.BenhNhans
        //                                         where bn.MaBNhan == _mabn
        //                                         select bn).ToList();
        //                            if (par02.Count > 0)
        //                            {
        //                                rep02.KhuVuc.Value = par02.First().KhuVuc;
        //                                rep02.DiaChi.Value = par02.First().DChi;
        //                                int gioiTinh = int.Parse(par02.First().GTinh.ToString());
        //                                if (gioiTinh == 1)
        //                                {
        //                                    rep02.Nam.Value = "X";
        //                                }
        //                                else if (gioiTinh == 0)
        //                                {
        //                                    rep02.Nu.Value = "X";
        //                                }
        //                                _DTuong = (par02.First().DTuong).ToString();
        //                                if (Rvien.Count > 0)
        //                                {
        //                                    int _makp = 0;
        //                                    if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                        _makp = Rvien.First().MaKP.Value;
        //                                    var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                    if (kphong.Count > 0)
        //                                        rep02.KhoaPhong.Value = kphong.First().TenKP;
        //                                    DateTime _dt2 = System.DateTime.Now;
        //                                    if (Rvien.First().NgayRa != null)
        //                                    {
        //                                        _dt2 = Rvien.First().NgayRa.Value;
        //                                        rep02.NgayRa.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);//
        //                                    }
        //                                    if (Rvien.First().SoNgaydt != null)
        //                                        rep02.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                    string _mabvchuyenden = "";
        //                                    if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                        _mabvchuyenden = par.First().MaBV;
        //                                    if (!string.IsNullOrEmpty(Rvien.First().MaBVC))
        //                                        _mabvchuyenden = Rvien.First().MaBVC;
        //                                    DateTime _dt3 = System.DateTime.Now;
        //                                    if (Rvien.First().NgayVao != null)
        //                                        _dt3 = Rvien.First().NgayVao.Value;
        //                                    rep02.NgayVao.Value = FormatHelper.NgaySangChu(_dt3, Common.FormatDate);
        //                                    var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                    if (bv.Count > 0)
        //                                        rep02.NoiChuyenDen.Value = bv.First().TenBV;
        //                                }
        //                                var vaovien = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
        //                                if (vaovien.Count > 0)
        //                                {
        //                                    DateTime _dt2 = System.DateTime.Now;
        //                                    if (vaovien.First().NgayVao != null)
        //                                        _dt2 = vaovien.First().NgayVao.Value;
        //                                    rep02.NgayVao.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                    if (vaovien.First().SoBA != null)
        //                                        rep02.SoBA.Value = vaovien.First().SoBA;
        //                                }
        //                                int dungtuyen = 0, capcuu = 0;
        //                                if (_HTTT == 1)//  if (_DTuong.Contains("BHYT"))
        //                                {
        //                                    rep02.SoThe.Value = par02.First().SThe;
        //                                    rep02.coBH.Value = "X";
        //                                    //if (par02.First().SThe != null && par02.First().SThe.ToString() != "" && par02.First().SThe.Length > 10)
        //                                    //    _muc = par02.First().SThe.Substring(2, 1);
        //                                    rep02.HanBHTu.Value = par02.First().HanBHTu;
        //                                    rep02.HanBHDen.Value = par02.First().HanBHDen;
        //                                    string macs = "";
        //                                    if (par02.First().MaCS != null)
        //                                    {
        //                                        macs = par02.First().MaCS;
        //                                        rep02.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                    }
        //                                    var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                    if (csdkbd.Count > 0)
        //                                    {
        //                                        rep02.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                    }

        //                                    //var ravien = _dataContext.RaViens.Where(p => p.MaBNhan==_mabn).ToList();
        //                                    //if (ravien.Count > 0)
        //                                    //{
        //                                    //    rep02.NgayRa.Value = ravien.First().NgayRa;//
        //                                    //    rep02.TongNgay.Value = ravien.First().SoNgaydt;
        //                                    //}



        //                                    capcuu = int.Parse(par02.First().CapCuu.ToString());
        //                                    if (capcuu == 1)
        //                                    {
        //                                        rep02.CapCuu.Value = "X";
        //                                        rep02.DungTuyen.Value = "";
        //                                        rep02.TraiTuyen.Value = "";
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (m == 0)
        //                                        rep02.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                    else
        //                                        rep02.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                    rep02.koBH.Value = "X";
        //                                    capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                    if (capcuu == 1)
        //                                    {
        //                                        rep02.CapCuu.Value = "X";
        //                                    }
        //                                    rep02.HanBHTu.Value = "";
        //                                }
        //                                rep02.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                rep02.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                string _ngaysinh = "";
        //                                if (par02.First().NgaySinh != null && par02.First().NgaySinh.ToString() != "")
        //                                    _ngaysinh = par02.First().NgaySinh.ToString() + "/";
        //                                if (par02.First().ThangSinh != null && par02.First().ThangSinh.ToString() != "")
        //                                    _ngaysinh = _ngaysinh + par02.First().ThangSinh.ToString() + "/";
        //                                if (par02.First().NamSinh != null && par02.First().NamSinh.ToString() != "")
        //                                    _ngaysinh = _ngaysinh + par02.First().NamSinh.ToString();
        //                                rep02.NSinh.Value = _ngaysinh;
        //                                if (tt.Count > 0 && tt.First().NgayTT != null)
        //                                {
        //                                    StringDatetimeType _fmat = Common.FormatDate;
        //                                    if (Common.MaBV == "30002")
        //                                        _fmat = StringDatetimeType.FullDate;
        //                                    rep02.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                    if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                        rep02.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                    else if (Common.MaBV == "27001")
        //                                        rep02.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                    else
        //                                        rep02.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                                }
        //                                #region bệnh nhân BHYT
        //                                if (_HTTT == 1)//   if (_DTuong == "BHYT")
        //                                {
        //                                    var bk02 = (from vp1 in tt
        //                                                join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                select new { dv.MaDV, TenNhom = vpct.TrongBH == 1 ? dv.TenNhom : dv.TenNhom.Replace("trong danh mục BHYT", ""), dv.HamLuong, dv.TenHC, dv.STT, dv.SoTT, dv.SoQD, dv.MaQD, TenDV = Common.MaBV == "12001" ? (dv.TenDV + " " + dv.HamLuong) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.SoTT).ToList();
        //                                    double _tongtien = Math.Round(bk02.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien), 3);
        //                                    if (par02.First().Tuyen != null)
        //                                    {
        //                                        dungtuyen = int.Parse(par02.First().Tuyen.ToString());
        //                                    }
        //                                    if (dungtuyen == 1)
        //                                    {
        //                                        if (capcuu != 1)
        //                                            rep02.DungTuyen.Value = "X";
        //                                        if (m == 0)
        //                                            rep02.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                        else
        //                                            rep02.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";

        //                                    }
        //                                    else if (dungtuyen == 2)
        //                                    {
        //                                        if (capcuu != 1)
        //                                            rep02.TraiTuyen.Value = "X";

        //                                        string kvuc = "";
        //                                        if (par.First().KhuVuc != null)
        //                                            kvuc = par.First().KhuVuc;
        //                                        string muchuong = "";
        //                                        switch (_hangbv)
        //                                        {
        //                                            case 1:
        //                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                break;
        //                                            case 2:
        //                                                if (Common.MaBV == "01830")
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                else
        //                                                    if (kvuc.ToLower().Contains("k"))
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                else
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                break;
        //                                            case 3:
        //                                                if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                {

        //                                                    if (kvuc.ToLower().Contains("k"))
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    else
        //                                                        muchuong = "Mức hưởng: " + "70" + "%";
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (kvuc.ToLower().Contains("k"))
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    else
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                }
        //                                                break;
        //                                            case 4:
        //                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                break;

        //                                        }
        //                                        if (m == 0)
        //                                            rep02.mucHuong.Value = muchuong;
        //                                        else
        //                                            rep02.mucHuong.Value = muchuong + " (XHH)";
        //                                    }
        //                                    // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                    double sotien = 0;
        //                                    sotien = bk02.Sum(p => p.TienBN);
        //                                    rep02.TienBN.Value = sotien;
        //                                    rep02.TienBH.Value = bk02.Sum(p => p.TienBH);
        //                                    rep02.Tongtien.Value = _tongtien;
        //                                    double tienCL = 0;
        //                                    tienCL = sotien - _tienTThu;
        //                                    if (Common.MaBV != "01071")
        //                                    {
        //                                        if (tienCL > 0)
        //                                        {
        //                                            MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                        }
        //                                        else
        //                                        {
        //                                            if (tienCL < 0)
        //                                            {
        //                                                tienCL *= -1;
        //                                                MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                            }
        //                                        }
        //                                    }
        //                                    if (bk02.Count > 0)
        //                                    {
        //                                        rep02.DataSource = bk02.ToList();
        //                                        rep02.BindingData();
        //                                        rep02.CreateDocument();
        //                                        // rep02.DataMember = "Table";
        //                                        frm.prcIN.PrintingSystem = rep02.PrintingSystem;
        //                                        frm.ShowDialog();
        //                                    }
        //                                }
        //                                #endregion// ket thuc BN BHYT
        //                                #region bn ko có bh
        //                                else
        //                                {
        //                                    var bk02 = (from vp1 in tt
        //                                                join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                where vpct.ThanhToan == 0
        //                                                select new { TenNhom = vpct.TrongBH == 1 ? dv.TenNhom : dv.TenNhom.Replace("trong danh mục BHYT", ""), dv.HamLuong, dv.TenHC, dv.STT, TenDV = Common.MaBV == "12001" ? (dv.TenDV + " " + dv.HamLuong) : dv.TenDV, dv.MaQD, dv.SoQD, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).Where(p => p.SoLuong != 0).ToList();
        //                                    rep02.Tongtien.Value = bk02.Sum(p => p.ThanhTien);
        //                                    rep02.TienBN.Value = bk02.Sum(p => p.TienBN);
        //                                    var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                    rep02.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                    if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                        rep02.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                    else
        //                                        rep02.ThuTT.Value = 0;
        //                                    rep02.DataSource = bk02.ToList();
        //                                    rep02.BindingData();
        //                                    rep02.CreateDocument();
        //                                    //rep02.DataMember = "Table";
        //                                    frm.prcIN.PrintingSystem = rep02.PrintingSystem;
        //                                    frm.ShowDialog();
        //                                }

        //                                #endregion// kết thúc

        //                            }
        //                            #endregion
        //                        }
        //                        else
        //                        {
        //                            if (Common.MaBV == "01071" && _DTuong == "Dịch vụ")
        //                            {
        //                                BKeBNDichVu_01071(_mabn);
        //                                //InBangKePhongKham_01071(_mabn);
        //                            }
        //                            else
        //                            {
        //                                #region bv chung
        //                                var kp02 = (from bns in _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDKB) join kps in _dataContext.KPhongs on bns.MaKP equals kps.MaKP select kps.TenKP).ToList();

        //                                List<int> lMaThuocHoiChan = new List<int>();// danh sách mã thuốc hội chẩn



        //                                //lấy ra danh sách thuốc hội chẩn
        //                                if (Common.MaBV == "26007")
        //                                {
        //                                    var qhoichan = _dataContext.BBHCs.Where(p => p.MaBNhan == _mabn).ToList();

        //                                    foreach (var a in qhoichan)
        //                                    {
        //                                        DateTime ngayHC = a.NgayHC.Value.Date;
        //                                        var qdt = (from dt in _dataContext.DThuocs.Where(p => p.MaBNhan == _mabn && p.MaKP == a.MaKP)
        //                                                   join dtct in _dataContext.DThuoccts on dt.IDDon equals dtct.IDDon
        //                                                   join dv in _dataContext.DichVus.Where(p => p.PLoai == 1) on dtct.MaDV equals dv.MaDV
        //                                                   select new { NgayKe = dt.NgayKe, dv.MaDV }).ToList();
        //                                        foreach (var b in qdt)
        //                                        {
        //                                            if (b.NgayKe != null && b.NgayKe.Value.Date == ngayHC)
        //                                                lMaThuocHoiChan.Add(b.MaDV);
        //                                        }
        //                                    }
        //                                }


        //                                BaoCao.repBangKe02bv rep02 = new BaoCao.repBangKe02bv(lMaThuocHoiChan);

        //                                //kiểm tra bệnh nhân hội chẩn
        //                                if (Common.MaBV == "26007")
        //                                {
        //                                    var qhoichan = _dataContext.BBHCs.Where(p => p.MaBNhan == _mabn).ToList();

        //                                    if (qhoichan.Count > 0)
        //                                    {
        //                                        rep02.HoiChan.Value = "x";
        //                                    }
        //                                    else
        //                                        rep02.HoiChan.Value = "";
        //                                }

        //                                //  BaoCao.repBangKe02bv rep02 = new BaoCao.repBangKe02bv();

        //                                rep02.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                                rep02.TenBN2.Value = _tenbn;
        //                                rep02.MaBNhan.Value = _mabn;


        //                                if (kp02.Count > 0)
        //                                {
        //                                    rep02.KhoaPhong.Value = kp02.Last();
        //                                }
        //                                var par02 = (from bn in _dataContext.BenhNhans
        //                                             where bn.MaBNhan == _mabn
        //                                             select bn).ToList();
        //                                if (par02.Count > 0)
        //                                {
        //                                    rep02.KhuVuc.Value = par02.First().KhuVuc;
        //                                    rep02.DiaChi.Value = par02.First().DChi;
        //                                    int gioiTinh = int.Parse(par02.First().GTinh.ToString());
        //                                    if (gioiTinh == 1)
        //                                    {
        //                                        rep02.Nam.Value = "X";
        //                                    }
        //                                    else if (gioiTinh == 0)
        //                                    {
        //                                        rep02.Nu.Value = "X";
        //                                    }
        //                                    _DTuong = (par02.First().DTuong).ToString();
        //                                    if (Rvien.Count > 0)
        //                                    {
        //                                        int _makp = 0;
        //                                        if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                            _makp = Rvien.First().MaKP.Value;
        //                                        var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                        if (kphong.Count > 0)
        //                                            rep02.KhoaPhong.Value = kphong.First().TenKP;
        //                                        DateTime _dt2 = System.DateTime.Now;
        //                                        if (Rvien.First().NgayRa != null)
        //                                        {
        //                                            _dt2 = Rvien.First().NgayRa.Value;
        //                                            rep02.NgayRa.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);//
        //                                        }
        //                                        if (Rvien.First().SoNgaydt != null)
        //                                            rep02.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                        string _mabvchuyenden = "";
        //                                        if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                            _mabvchuyenden = par.First().MaBV;
        //                                        if (!string.IsNullOrEmpty(Rvien.First().MaBVC))
        //                                            _mabvchuyenden = Rvien.First().MaBVC;
        //                                        DateTime _dt3 = System.DateTime.Now;
        //                                        if (Rvien.First().NgayVao != null)
        //                                            _dt3 = Rvien.First().NgayVao.Value;
        //                                        rep02.NgayVao.Value = FormatHelper.NgaySangChu(_dt3, Common.FormatDate);
        //                                        var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                        if (bv.Count > 0)
        //                                            rep02.NoiChuyenDen.Value = bv.First().TenBV;
        //                                    }
        //                                    var vaovien = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
        //                                    if (vaovien.Count > 0)
        //                                    {
        //                                        DateTime _dt2 = System.DateTime.Now;
        //                                        if (vaovien.First().NgayVao != null)
        //                                            _dt2 = vaovien.First().NgayVao.Value;
        //                                        rep02.NgayVao.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                        if (vaovien.First().SoBA != null)
        //                                            rep02.SoBA.Value = vaovien.First().SoBA;
        //                                    }
        //                                    int dungtuyen = 0, capcuu = 0;
        //                                    if (_HTTT == 1)//  if (_DTuong.Contains("BHYT"))
        //                                    {
        //                                        rep02.SoThe.Value = par02.First().SThe;
        //                                        rep02.coBH.Value = "X";
        //                                        //if (par02.First().SThe != null && par02.First().SThe.ToString() != "" && par02.First().SThe.Length > 10)
        //                                        //    _muc = par02.First().SThe.Substring(2, 1);
        //                                        rep02.HanBHTu.Value = par02.First().HanBHTu;
        //                                        rep02.HanBHDen.Value = par02.First().HanBHDen;
        //                                        string macs = "";
        //                                        if (par02.First().MaCS != null)
        //                                        {
        //                                            macs = par02.First().MaCS;
        //                                            rep02.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                        }
        //                                        var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                        if (csdkbd.Count > 0)
        //                                        {
        //                                            rep02.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                        }

        //                                        //var ravien = _dataContext.RaViens.Where(p => p.MaBNhan==_mabn).ToList();
        //                                        //if (ravien.Count > 0)
        //                                        //{
        //                                        //    rep02.NgayRa.Value = ravien.First().NgayRa;//
        //                                        //    rep02.TongNgay.Value = ravien.First().SoNgaydt;
        //                                        //}



        //                                        capcuu = int.Parse(par02.First().CapCuu.ToString());
        //                                        if (capcuu == 1)
        //                                        {
        //                                            rep02.CapCuu.Value = "X";
        //                                            rep02.DungTuyen.Value = "";
        //                                            rep02.TraiTuyen.Value = "";
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        if (m == 0)
        //                                            rep02.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                        else
        //                                            rep02.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                        rep02.koBH.Value = "X";
        //                                        capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                        if (capcuu == 1)
        //                                        {
        //                                            rep02.CapCuu.Value = "X";
        //                                        }
        //                                        rep02.HanBHTu.Value = "";
        //                                    }
        //                                    rep02.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                    rep02.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                    string _ngaysinh = "";
        //                                    if (par02.First().NgaySinh != null && par02.First().NgaySinh.ToString() != "")
        //                                        _ngaysinh = par02.First().NgaySinh.ToString() + "/";
        //                                    if (par02.First().ThangSinh != null && par02.First().ThangSinh.ToString() != "")
        //                                        _ngaysinh = _ngaysinh + par02.First().ThangSinh.ToString() + "/";
        //                                    if (par02.First().NamSinh != null && par02.First().NamSinh.ToString() != "")
        //                                        _ngaysinh = _ngaysinh + par02.First().NamSinh.ToString();
        //                                    rep02.NSinh.Value = _ngaysinh;
        //                                    var ngaytt = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).Select(p => p.NgayTT).ToList();
        //                                    if (ngaytt.Count > 0)
        //                                    {
        //                                        StringDatetimeType _fmat = Common.FormatDate;
        //                                        if (Common.MaBV == "30002")
        //                                            _fmat = StringDatetimeType.FullDate;
        //                                        rep02.NgayTT.Value = FormatHelper.NgaySangChu(ngaytt.First().Value, _fmat);
        //                                        if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                            rep02.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                        else if (Common.MaBV == "27001")
        //                                            rep02.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                        else
        //                                            rep02.NgayGD.Value = FormatHelper.NgaySangChu(ngaytt.First().Value, _fmat);
        //                                    }
        //                                    //bệnh nhân BHYT
        //                                    if (_HTTT == 1)//   if (_DTuong == "BHYT")
        //                                    {
        //                                        var bk02 = (from vp1 in tt
        //                                                    join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                    join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                    select new { dv.MaDV, dv.TenNhom, dv.HamLuong, dv.TenHC, dv.STT, dv.SoTT, vp1.LyDo, dv.SoQD, dv.MaQD, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.SoTT).ToList();

        //                                        #region tính tổng số thang thuốc đông y
        //                                        if (Common.MaBV == "27021" || Common.MaBV == "27022" || Common.MaBV == "27023")
        //                                        {
        //                                            //var qdt = (from dt in _dataContext.DThuocs.Where(p => p.MaBNhan == _mabn && p.PLDV == 1)
        //                                            //           join dtct in _dataContext.DThuoccts.Where(p => p.TrongBH == 1) on dt.IDDon equals dtct.IDDon
        //                                            //           join dv in _dataContext.DichVus.Where(p=>p.TenDV == "Sắc thuốc thang") on dtct.MaDV equals dv.MaDV
        //                                            //           group new{ dt, dtct} by new { dv.TenDV } into kq
        //                                            //           select new { kq.Key.TenDV, SoLuong = kq.Sum(p=>p.dtct.SoLuong) }).ToList();
        //                                            var qdt = (from bk in bk02.Where(p => p.TenDV == "Sắc thuốc thang")
        //                                                       group bk by new { TenDV = bk.TenDV } into kq
        //                                                       select new { kq.Key.TenDV, SoLuong = kq.Sum(p => p.SoLuong) }).ToList();

        //                                            if (qdt.Count > 0)
        //                                            {
        //                                                rep02.lblSoThang.Text = "Tổng số thang: " + qdt.First().SoLuong.ToString();

        //                                            }
        //                                        }
        //                                        #endregion
        //                                        double _tongtien = Math.Round(bk02.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien), 3);
        //                                        if (par02.First().Tuyen != null)
        //                                        {
        //                                            dungtuyen = int.Parse(par02.First().Tuyen.ToString());
        //                                        }
        //                                        if (dungtuyen == 1)
        //                                        {
        //                                            if (capcuu != 1)
        //                                                rep02.DungTuyen.Value = "X";
        //                                            if (m == 0)
        //                                                rep02.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                            else
        //                                                rep02.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";

        //                                        }
        //                                        else if (dungtuyen == 2)
        //                                        {
        //                                            if (capcuu != 1)
        //                                                rep02.TraiTuyen.Value = "X";

        //                                            string kvuc = "";
        //                                            if (par.First().KhuVuc != null)
        //                                                kvuc = par.First().KhuVuc;
        //                                            string muchuong = "";
        //                                            switch (_hangbv)
        //                                            {
        //                                                case 1:
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                                    break;
        //                                                case 2:
        //                                                    if (Common.MaBV == "01830")
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                    else
        //                                                        muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                                    break;
        //                                                case 3:
        //                                                    if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                                    {

        //                                                        if (kvuc.ToLower().Contains("k"))
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                        else
        //                                                            muchuong = "Mức hưởng: " + "70" + "%";
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (kvuc.ToLower().Contains("k"))
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                        else
        //                                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                                    }
        //                                                    break;
        //                                                case 4:
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                    break;

        //                                            }
        //                                            if (m == 0)
        //                                                rep02.mucHuong.Value = muchuong;
        //                                            else
        //                                                rep02.mucHuong.Value = muchuong + " (XHH)";
        //                                        }
        //                                        // hiện thị thông báo số tiền thu thêm hoặc trả lại
        //                                        double sotien = 0;
        //                                        sotien = bk02.Sum(p => p.TienBN);
        //                                        rep02.TienBN.Value = sotien;
        //                                        rep02.TienBH.Value = bk02.Sum(p => p.TienBH);
        //                                        rep02.Tongtien.Value = _tongtien;
        //                                        double tienCL = 0;
        //                                        tienCL = sotien - _tienTThu;
        //                                        if (Common.MaBV != "01071")
        //                                        {
        //                                            if (tienCL > 0)
        //                                            {
        //                                                MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                            }
        //                                            else
        //                                            {
        //                                                if (tienCL < 0)
        //                                                {
        //                                                    tienCL *= -1;
        //                                                    MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                                }
        //                                            }
        //                                        }
        //                                        if (bk02.Count > 0)
        //                                        {
        //                                            rep02.DataSource = bk02.ToList();
        //                                            rep02.BindingData();
        //                                            rep02.CreateDocument();
        //                                            // rep02.DataMember = "Table";
        //                                            frm.prcIN.PrintingSystem = rep02.PrintingSystem;
        //                                            frm.ShowDialog();
        //                                        }
        //                                    }// ket thuc BN BHYT
        //                                    else
        //                                    {
        //                                        var bk02 = (from vp1 in tt
        //                                                    join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                                    join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                                    where vpct.ThanhToan == 0
        //                                                    select new { dv.MaDV, dv.TenNhom, dv.TenHC, dv.HamLuong, dv.STT, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, dv.MaQD, dv.SoQD, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).Where(p => p.SoLuong != 0).ToList();
        //                                        rep02.Tongtien.Value = bk02.Sum(p => p.ThanhTien);
        //                                        rep02.TienBN.Value = bk02.Sum(p => p.TienBN);
        //                                        var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                        rep02.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                        if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                            rep02.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                        else
        //                                            rep02.ThuTT.Value = 0;
        //                                        #region tính tổng số thang thuốc đông y
        //                                        if (Common.MaBV == "27021" || Common.MaBV == "27022" || Common.MaBV == "27023")
        //                                        {
        //                                            var qdt = (from bk in bk02.Where(p => p.TenDV == "Sắc thuốc thang")
        //                                                       group bk by new { TenDV = bk.TenDV } into kq
        //                                                       select new { kq.Key.TenDV, SoLuong = kq.Sum(p => p.SoLuong) }).ToList();

        //                                            if (qdt.Count > 0)
        //                                            {
        //                                                rep02.lblSoThang.Text = "Tổng số thang: " + qdt.First().SoLuong.ToString();

        //                                            }
        //                                        }
        //                                        #endregion
        //                                        if (bk02.Count > 0)
        //                                        {
        //                                            rep02.DataSource = bk02.ToList();
        //                                            rep02.BindingData();
        //                                            rep02.CreateDocument();
        //                                            //rep02.DataMember = "Table";
        //                                            frm.prcIN.PrintingSystem = rep02.PrintingSystem;
        //                                            frm.ShowDialog();
        //                                        }
        //                                    }

        //                                    // kết thúc

        //                                }
        //                                #endregion
        //                            }
        //                        }
        //                        break;
        //                    case 2:
        //                        #region case 2
        //                        var kp03 = (from bns in _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDKB) join kps in _dataContext.KPhongs on bns.MaKP equals kps.MaKP select kps.TenKP).ToList();

        //                        BaoCao.repBangKe03bv rep03 = new BaoCao.repBangKe03bv();
        //                        rep03.tenBN.Value = _tenbn;
        //                        rep03.MaBNhan.Value = _mabn;

        //                        if (kp03.Count > 0)
        //                        {
        //                            rep03.KhoaPhong.Value = kp03.Last();
        //                        }
        //                        var par03 = (from bn in _dataContext.BenhNhans
        //                                     where bn.MaBNhan == _mabn
        //                                     select bn).ToList();
        //                        if (par03.Count > 0)
        //                        {
        //                            rep03.KhuVuc.Value = par03.First().KhuVuc;
        //                            rep03.DiaChi.Value = par03.First().DChi;
        //                            int gioiTinh = int.Parse(par03.First().GTinh.ToString());
        //                            if (gioiTinh == 1)
        //                            {
        //                                rep03.Nam.Value = "X";
        //                            }
        //                            else if (gioiTinh == 0)
        //                            {
        //                                rep03.Nu.Value = "X";
        //                            }
        //                            _DTuong = (par03.First().DTuong).ToString();
        //                            //var ravien = _dataContext.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
        //                            if (Rvien.Count > 0)
        //                            {
        //                                //rep03.MaICD.Value = Rvien.First().MaICD;
        //                                int _makp = 0;
        //                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                    _makp = Rvien.First().MaKP.Value;
        //                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                if (kphong.Count > 0)
        //                                    rep03.KhoaPhong.Value = kphong.First().TenKP;
        //                                DateTime _dt2 = System.DateTime.Now;
        //                                if (Rvien.First().NgayRa != null)
        //                                {
        //                                    _dt2 = Rvien.First().NgayRa.Value;
        //                                    rep03.NgayRa.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);//
        //                                }
        //                                if (Rvien.First().SoNgaydt != null)
        //                                    rep03.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                                string _mabvchuyenden = "";
        //                                if (!string.IsNullOrEmpty(par.First().MaBV))
        //                                    _mabvchuyenden = par.First().MaBV;
        //                                if (!string.IsNullOrEmpty(Rvien.First().MaBVC))
        //                                    _mabvchuyenden = Rvien.First().MaBVC;
        //                                DateTime _dt3 = System.DateTime.Now;
        //                                if (Rvien.First().NgayVao != null)
        //                                    _dt3 = Rvien.First().NgayVao.Value;
        //                                rep03.NgayVao.Value = FormatHelper.NgaySangChu(_dt3, Common.FormatDate);
        //                                var bv = _dataContext.BenhViens.Where(p => p.MaBV == (_mabvchuyenden)).ToList();
        //                                if (bv.Count > 0)
        //                                    rep03.NoiChuyenDen.Value = bv.First().TenBV;
        //                            }
        //                            var vaovien = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
        //                            if (vaovien.Count > 0)
        //                            {
        //                                DateTime _dt2 = System.DateTime.Now;
        //                                if (vaovien.First().NgayVao != null)
        //                                    _dt2 = vaovien.First().NgayVao.Value;
        //                                rep03.NgayVao.Value = FormatHelper.NgaySangChu(_dt2, Common.FormatDate);
        //                                if (vaovien.First().SoBA != null)
        //                                    rep03.SoBA.Value = vaovien.First().SoBA;
        //                            }
        //                            int dungtuyen = 0, capcuu = 0;
        //                            if (_HTTT == 1)//  if (_DTuong.Contains("BHYT"))
        //                            {
        //                                rep03.SoThe.Value = par03.First().SThe;
        //                                rep03.coBH.Value = "X";
        //                                //if (par03.First().SThe != null && par03.First().SThe.ToString() != "" && par03.First().SThe.Length > 10)
        //                                //    _muc = par03.First().SThe.Substring(2, 1);
        //                                rep03.HanBHTu.Value = par03.First().HanBHTu;
        //                                rep03.HanBHDen.Value = par03.First().HanBHDen;
        //                                string macs = "";
        //                                if (par03.First().MaCS != null)
        //                                {
        //                                    macs = par03.First().MaCS;
        //                                    rep03.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                }
        //                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                if (csdkbd.Count > 0)
        //                                {
        //                                    rep03.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                }

        //                                //var ravien = _dataContext.RaViens.Where(p => p.MaBNhan==_mabn).ToList();
        //                                //if (ravien.Count > 0)
        //                                //{
        //                                //    rep03.NgayRa.Value = ravien.First().NgayRa;//
        //                                //    rep03.TongNgay.Value = ravien.First().SoNgaydt;
        //                                //}



        //                                capcuu = int.Parse(par03.First().CapCuu.ToString());
        //                                if (capcuu == 1)
        //                                {
        //                                    rep03.CapCuu.Value = "X";
        //                                    rep03.DungTuyen.Value = "";
        //                                    rep03.TraiTuyen.Value = "";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (m == 0)
        //                                    rep03.mucHuong.Value = "Dành cho đối tượng " + _loaiDT;
        //                                else
        //                                    rep03.mucHuong.Value = "Dành cho đối tượng " + _loaiDT + " (XHH)";
        //                                rep03.koBH.Value = "X";
        //                                capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                if (capcuu == 1)
        //                                {
        //                                    rep03.CapCuu.Value = "X";
        //                                }
        //                                rep03.HanBHTu.Value = "";
        //                            }
        //                            rep03.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                            rep03.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                            string _ngaysinh = "";
        //                            if (par03.First().NgaySinh != null && par03.First().NgaySinh.ToString() != "")
        //                                _ngaysinh = par03.First().NgaySinh.ToString() + "/";
        //                            if (par03.First().ThangSinh != null && par03.First().ThangSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par03.First().ThangSinh.ToString() + "/";
        //                            if (par03.First().NamSinh != null && par03.First().NamSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par03.First().NamSinh.ToString();
        //                            rep03.NSinh.Value = _ngaysinh;
        //                            var ngaytt = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).Select(p => p.NgayTT).ToList();
        //                            if (ngaytt.Count > 0)
        //                            {
        //                                StringDatetimeType _fmat = Common.FormatDate;
        //                                if (Common.MaBV == "30002")
        //                                    _fmat = StringDatetimeType.FullDate;
        //                                rep03.NgayTT.Value = FormatHelper.NgaySangChu(ngaytt.First().Value, _fmat);
        //                                if (Common.MaBV == "08204" || Common.MaBV == "19048" || Common.MaBV == "27023")
        //                                    rep03.NgayGD.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, 0);
        //                                else if (Common.MaBV == "27001")
        //                                    rep03.NgayGD.Value = " Ngày ... tháng... năm......";
        //                                else
        //                                    rep03.NgayGD.Value = FormatHelper.NgaySangChu(ngaytt.First().Value, _fmat);
        //                            }
        //                            //bệnh nhân BHYT
        //                            if (_HTTT == 1)//   if (_DTuong == "BHYT")
        //                            {
        //                                var bk02 = (from vp1 in tt
        //                                            join vpct in _lvpct.Where(p => p.TrongBH == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                            join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                            select new { dv.TenNhom, dv.STT, dv.SoTT, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.SoTT).ToList();
        //                                double _tongtien = Math.Round(bk02.Where(p => p.TrongBH == 1).Sum(p => p.ThanhTien), 3);
        //                                if (par03.First().Tuyen != null)
        //                                {
        //                                    dungtuyen = int.Parse(par03.First().Tuyen.ToString());
        //                                }
        //                                if (dungtuyen == 1)
        //                                {
        //                                    if (capcuu != 1)
        //                                        rep03.DungTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep03.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                    else
        //                                        rep03.mucHuong.Value = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "% (XHH)";

        //                                }
        //                                else if (dungtuyen == 2)
        //                                {
        //                                    if (capcuu != 1)
        //                                        rep03.TraiTuyen.Value = "X";
        //                                    string kvuc = "";
        //                                    if (par.First().KhuVuc != null)
        //                                        kvuc = par.First().KhuVuc;
        //                                    string muchuong = "";
        //                                    switch (_hangbv)
        //                                    {
        //                                        case 1:
        //                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.4 + "%";
        //                                            break;
        //                                        case 2:
        //                                            if (Common.MaBV == "01830")
        //                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                            else
        //                                                muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.6 + "%";
        //                                            break;
        //                                        case 3:
        //                                            if (Common.MaBV == "08204" || _tongtien < Common.GHanTT100)
        //                                            {

        //                                                if (kvuc.ToLower().Contains("k"))
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                else
        //                                                    muchuong = "Mức hưởng: " + "70" + "%";
        //                                            }
        //                                            else
        //                                            {
        //                                                if (kvuc.ToLower().Contains("k"))
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                                else
        //                                                    muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) * 0.7 + "%";
        //                                            }
        //                                            break;
        //                                        case 4:
        //                                            muchuong = "Mức hưởng: " + ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc) + "%";
        //                                            break;

        //                                    }
        //                                    if (m == 0)
        //                                        rep03.mucHuong.Value = muchuong;
        //                                    else
        //                                        rep03.mucHuong.Value = muchuong + "( XHH)";

        //                                }
        //                                // hiện thị thông báo số tiền thu thêm hoặc trả lại

        //                                double sotien = 0;
        //                                sotien = bk02.Sum(p => p.TienBN);
        //                                rep03.TienBN.Value = sotien;
        //                                rep03.TienBH.Value = bk02.Sum(p => p.TienBH);
        //                                rep03.Tongtien.Value = _tongtien;
        //                                double tienCL = 0;
        //                                tienCL = sotien - _tienTThu;
        //                                if (Common.MaBV != "01071")
        //                                {
        //                                    if (tienCL > 0)
        //                                    {
        //                                        MessageBox.Show("Số tiền bệnh nhân phải nộp thêm: " + tienCL.ToString("##,###"));
        //                                    }
        //                                    else
        //                                    {
        //                                        if (tienCL < 0)
        //                                        {
        //                                            tienCL *= -1;
        //                                            MessageBox.Show(string.Format("Số tiền trả lại cho bệnh nhân: " + tienCL.ToString("##,###")));
        //                                        }
        //                                    }
        //                                }
        //                                rep03.DataSource = bk02.ToList();
        //                                rep03.BindingData();
        //                                rep03.CreateDocument();
        //                                // rep03.DataMember = "Table";
        //                                //frm.prcIN.PrintingSystem = rep03.PrintingSystem;
        //                                frm.ShowDialog();
        //                            }// ket thuc BN BHYT
        //                            else
        //                            {
        //                                var bk02 = (from vp1 in tt
        //                                            join vpct in _lvpct.Where(p => p.TrongBH == 1 || p.TrongBH == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                            join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                            where vpct.ThanhToan == 0
        //                                            select new { dv.TenNhom, dv.STT, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, TienBN = vpct.TienBN, vpct.TienBH }).Where(p => p.SoLuong != 0).ToList();
        //                                rep03.Tongtien.Value = bk02.Sum(p => p.ThanhTien);
        //                                rep03.TienBN.Value = bk02.Sum(p => p.TienBN);
        //                                var tamthu = _dataContext.TamUngs.Where(p => p.MaBNhan == _mabn).ToList();
        //                                rep03.TamThu.Value = tamthu.Where(p => p.PhanLoai == 0).Sum(p => p.SoTien).Value - tamthu.Where(p => p.PhanLoai == 4).Sum(p => p.SoTien).Value;

        //                                if (tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien) != null)
        //                                    rep03.ThuTT.Value = tamthu.Where(p => p.PhanLoai == 3).Sum(p => p.SoTien).Value;
        //                                else
        //                                    rep03.ThuTT.Value = 0;
        //                                if (bk02.Count > 0)
        //                                {
        //                                    rep03.DataSource = bk02.ToList();
        //                                    rep03.BindingData();
        //                                    rep03.CreateDocument();
        //                                    //rep03.DataMember = "Table";
        //                                    //frm.prcIN.PrintingSystem = rep03.PrintingSystem;
        //                                    frm.ShowDialog();
        //                                }
        //                            }

        //                            // kết thúc

        //                        }
        //                        break;
        //                        #endregion
        //                        #endregion
        //                }
        //                #region in mẫu bảng kê cho BN BHYT có chi phí ngoài danh mục BHYT
        //                // in mẫu bảng kê cho BN BHYT có chi phí ngoài danh mục BHYT
        //                if (_lvpct.Where(p => p.ThanhToan == 2).ToList().Count > 0)
        //                {
        //                    var bk00 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => p.TrongBH == 0 && p.ThanhToan == 2).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                select new { vp1.MaKP, dv.TenNhom, dv.STT, vpct.idVPhict, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    var bk01 = (from a in bk00
        //                                select new { a.MaKP, TenNhom = (Common.MaBV != "01071") ? a.TenNhom : (a.TenNhom.Replace("trong danh mục BHYT", "")), a.STT, a.idVPhict, a.TenDV, a.DonVi, a.DonGia, a.SoLuong, a.ThanhTien, a.TienBH, a.TienBN, a.TrongBH, a.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    if (bk01.Count > 0)
        //                    {

        //                        BaoCao.repBangKeCPNgoaiBH_A4 rep = new BaoCao.repBangKeCPNgoaiBH_A4();
        //                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                        rep.MaBNhan.Value = _mabn;
        //                        rep.TieuDe.Value = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH";

        //                        //if (kp.Count > 0)
        //                        //{
        //                        //    rep.KhoaPhong.Value = kp.First().TenKP;
        //                        //}

        //                        if (par.Count > 0)
        //                        {
        //                            rep.DiaChi.Value = par.First().DChi;
        //                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                            if (gioiTinh == 1)
        //                            {
        //                                rep.Nam.Value = "X";
        //                            }
        //                            else if (gioiTinh == 0)
        //                            {
        //                                rep.Nu.Value = "X";
        //                            }
        //                            try
        //                            {
        //                                var mk = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).Max(p => p.SoKB);
        //                                if (mk > 0)
        //                                {
        //                                    rep.SoKB.Value = mk;

        //                                }
        //                            }
        //                            catch (Exception)
        //                            {
        //                                rep.SoKB.Value = "";
        //                            }
        //                            if (_ngaykham.Count > 0 && _ngaykham.First().NgayKham != null)
        //                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_ngaykham.First().NgayKham.Value, 3);

        //                            if (Rvien.Count > 0)
        //                                rep.NgayKT.Value = Rvien.First().NgayRa;
        //                            _DTuong = (par.First().DTuong).ToString();
        //                            if (_DTuong.Contains("BHYT"))
        //                            {
        //                                rep.SoThe.Value = par.First().SThe;
        //                                rep.coBH.Value = "X";
        //                                rep.HanBHTu.Value = par.First().HanBHTu;
        //                                rep.HanBHDen.Value = par.First().HanBHDen;
        //                                string macs = "";
        //                                if (par.First().MaCS != null)
        //                                {
        //                                    macs = par.First().MaCS;
        //                                    rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                }
        //                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                if (csdkbd.Count > 0)
        //                                {
        //                                    rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                }


        //                                int dungtuyen = 0;
        //                                if (par.First().Tuyen != null)
        //                                {
        //                                    dungtuyen = int.Parse(par.First().Tuyen.ToString());

        //                                }
        //                                if (dungtuyen == 1)
        //                                {
        //                                    rep.DungTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT";
        //                                    else
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT (XHH)";

        //                                }
        //                                else if (dungtuyen == 2)
        //                                {

        //                                    rep.TraiTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT";
        //                                    else
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT (XHH)";
        //                                }
        //                                int capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                if (capcuu == 1)
        //                                {
        //                                    rep.CapCuu.Value = "X";
        //                                    rep.TraiTuyen.Value = "";
        //                                    rep.DungTuyen.Value = "";
        //                                }
        //                            }
        //                            if (tt.Count > 0)
        //                            {
        //                                StringDatetimeType _fmat = Common.FormatDate;
        //                                if (Common.MaBV == "30002")
        //                                    _fmat = StringDatetimeType.FullDate;
        //                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                            }

        //                            if (Rvien.Count > 0)
        //                            {
        //                                int _makp = 0;
        //                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                    _makp = Rvien.First().MaKP.Value;
        //                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                if (kphong.Count > 0)
        //                                    rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                if (Rvien.First().SoNgaydt != null)
        //                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                            }
        //                            string _ngaysinh = "";
        //                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                            rep.NSinh.Value = _ngaysinh;

        //                            rep.Tongtien.Value = bk01.Where(p => p.TrongBH == 0).Sum(p => p.ThanhTien);
        //                            rep.DataSource = bk01.ToList();
        //                            rep.BindingData();
        //                            rep.CreateDocument();
        //                            // rep.DataMember = "Table";
        //                            //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                            frm.ShowDialog();

        //                        }
        //                    }
        //                }
        //                if (_lvpct.Where(p => p.ThanhToan == 1).ToList().Count > 0)
        //                {
        //                    var bk00 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => p.ThanhToan == 1).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                select new { vp1.MaKP, dv.TenNhom, dv.STT, vpct.idVPhict, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    var bk01 = (from a in bk00
        //                                select new
        //                                {
        //                                    a.MaKP,
        //                                    TenNhom = (Common.MaBV != "01071") ? a.TenNhom : (a.TenNhom.Replace("trong danh mục BHYT", "")),
        //                                    a.STT,
        //                                    a.idVPhict,
        //                                    a.TenDV,
        //                                    a.DonVi,
        //                                    a.DonGia,
        //                                    a.SoLuong,
        //                                    a.ThanhTien,
        //                                    a.TienBH,
        //                                    a.TienBN,
        //                                    a.TrongBH,
        //                                    a.TrongDM
        //                                }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    if (bk01.Count > 0)
        //                    {

        //                        BaoCao.repBangKeCPNgoaiBH_A4 rep = new BaoCao.repBangKeCPNgoaiBH_A4();
        //                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                        rep.MaBNhan.Value = _mabn;
        //                        rep.TieuDe.Value = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH";

        //                        //if (kp.Count > 0)
        //                        //{
        //                        //    rep.KhoaPhong.Value = kp.First().TenKP;
        //                        //}

        //                        if (par.Count > 0)
        //                        {
        //                            rep.DiaChi.Value = par.First().DChi;
        //                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                            if (gioiTinh == 1)
        //                            {
        //                                rep.Nam.Value = "X";
        //                            }
        //                            else if (gioiTinh == 0)
        //                            {
        //                                rep.Nu.Value = "X";
        //                            }
        //                            try
        //                            {
        //                                var mk = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).Max(p => p.SoKB);
        //                                if (mk > 0)
        //                                {
        //                                    rep.SoKB.Value = mk;

        //                                }
        //                            }
        //                            catch (Exception)
        //                            {
        //                                rep.SoKB.Value = "";
        //                            }
        //                            if (_ngaykham.Count > 0 && _ngaykham.First().NgayKham != null)
        //                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_ngaykham.First().NgayKham.Value, 3);

        //                            if (Rvien.Count > 0)
        //                                rep.NgayKT.Value = Rvien.First().NgayRa;
        //                            _DTuong = (par.First().DTuong).ToString();
        //                            if (_DTuong.Contains("BHYT"))
        //                            {
        //                                rep.SoThe.Value = par.First().SThe;
        //                                rep.coBH.Value = "X";
        //                                rep.HanBHTu.Value = par.First().HanBHTu;
        //                                rep.HanBHDen.Value = par.First().HanBHDen;
        //                                string macs = "";
        //                                if (par.First().MaCS != null)
        //                                {
        //                                    macs = par.First().MaCS;
        //                                    rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                }
        //                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                if (csdkbd.Count > 0)
        //                                {
        //                                    rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                }


        //                                int dungtuyen = 0;
        //                                if (par.First().Tuyen != null)
        //                                {
        //                                    dungtuyen = int.Parse(par.First().Tuyen.ToString());

        //                                }

        //                                // rep.mucHuong.Value = "CÁC DỊCH VỤ ĐÃ THU TRỰC TIẾP";
        //                                int capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                if (capcuu == 1)
        //                                {
        //                                    rep.CapCuu.Value = "X";
        //                                    rep.TraiTuyen.Value = "";
        //                                    rep.DungTuyen.Value = "";
        //                                }
        //                            }
        //                            rep.mucHuong.Value = "CÁC DỊCH VỤ ĐÃ THU TRỰC TIẾP";
        //                            if (tt.Count > 0)
        //                            {
        //                                StringDatetimeType _fmat = Common.FormatDate;
        //                                if (Common.MaBV == "30002")
        //                                    _fmat = StringDatetimeType.FullDate;
        //                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                            }

        //                            if (Rvien.Count > 0)
        //                            {
        //                                int _makp = 0;
        //                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                    _makp = Rvien.First().MaKP.Value;
        //                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                if (kphong.Count > 0)
        //                                    rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                if (Rvien.First().SoNgaydt != null)
        //                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                            }
        //                            string _ngaysinh = "";
        //                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                            rep.NSinh.Value = _ngaysinh;

        //                            rep.Tongtien.Value = bk01.Sum(p => p.ThanhTien);
        //                            rep.DataSource = bk01.ToList();
        //                            rep.BindingData();
        //                            rep.CreateDocument();
        //                            // rep.DataMember = "Table";
        //                            //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                            frm.ShowDialog();

        //                        }
        //                    }
        //                }
        //                if (_HTTT == 1)//  if (_DTuong == "BHYT")
        //                {
        //                    #region _DTuong == "BHYT"
        //                    //var kp = (from bns in _dataContext.BNKBs.Where(p=>p.MaBNhan== (txtMaBNhan.Text)) join kps in _dataContext.KPhongs on bns.MaKP equals kps.MaKP select new { kps.TenKP,bns.IDKB }).OrderByDescending(p=>p.IDKB).ToList();
        //                    var bk00 = (from vp1 in tt
        //                                join vpct in _lvpct.Where(p => (p.TrongBH == 0 || p.TrongBH == 3) && p.ThanhToan == 0).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                select new { vp1.MaKP, dv.TenNhom, dv.STT, vpct.idVPhict, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    var bk01 = (from a in bk00
        //                                select new
        //                                {
        //                                    a.MaKP,
        //                                    TenNhom = (Common.MaBV != "01071") ? a.TenNhom : (a.TenNhom.Replace("trong danh mục BHYT", "")),
        //                                    a.STT,
        //                                    a.idVPhict,
        //                                    a.TenDV,
        //                                    a.DonVi,
        //                                    a.DonGia,
        //                                    a.SoLuong,
        //                                    a.ThanhTien,
        //                                    a.TienBH,
        //                                    a.TienBN,
        //                                    a.TrongBH,
        //                                    a.TrongDM
        //                                }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();



        //                    if (bk01.Count > 0)
        //                    {

        //                        BaoCao.repBangKeCPNgoaiBH_A4 rep = new BaoCao.repBangKeCPNgoaiBH_A4();
        //                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                        rep.MaBNhan.Value = _mabn;
        //                        rep.TieuDe.Value = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH";

        //                        //if (kp.Count > 0)
        //                        //{
        //                        //    rep.KhoaPhong.Value = kp.First().TenKP;
        //                        //}

        //                        if (par.Count > 0)
        //                        {
        //                            rep.DiaChi.Value = par.First().DChi;
        //                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                            if (gioiTinh == 1)
        //                            {
        //                                rep.Nam.Value = "X";
        //                            }
        //                            else if (gioiTinh == 0)
        //                            {
        //                                rep.Nu.Value = "X";
        //                            }
        //                            try
        //                            {
        //                                var mk = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).Max(p => p.SoKB);
        //                                if (mk > 0)
        //                                {
        //                                    rep.SoKB.Value = mk;

        //                                }
        //                            }
        //                            catch (Exception)
        //                            {
        //                                rep.SoKB.Value = "";
        //                            }
        //                            if (_ngaykham.Count > 0 && _ngaykham.First().NgayKham != null)
        //                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_ngaykham.First().NgayKham.Value, 3);

        //                            if (Rvien.Count > 0)
        //                                rep.NgayKT.Value = Rvien.First().NgayRa;
        //                            _DTuong = (par.First().DTuong).ToString();
        //                            if (_DTuong.Contains("BHYT"))
        //                            {
        //                                rep.SoThe.Value = par.First().SThe;
        //                                rep.coBH.Value = "X";
        //                                rep.HanBHTu.Value = par.First().HanBHTu;
        //                                rep.HanBHDen.Value = par.First().HanBHDen;
        //                                string macs = "";
        //                                if (par.First().MaCS != null)
        //                                {
        //                                    macs = par.First().MaCS;
        //                                    rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                }
        //                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                if (csdkbd.Count > 0)
        //                                {
        //                                    rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                }


        //                                int dungtuyen = 0;
        //                                if (par.First().Tuyen != null)
        //                                {
        //                                    dungtuyen = int.Parse(par.First().Tuyen.ToString());

        //                                }
        //                                if (dungtuyen == 1)
        //                                {
        //                                    rep.DungTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT";
        //                                    else
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT (XHH)";

        //                                }
        //                                else if (dungtuyen == 2)
        //                                {

        //                                    rep.TraiTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT";
        //                                    else
        //                                        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT (XHH)";
        //                                }
        //                                int capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                if (capcuu == 1)
        //                                {
        //                                    rep.CapCuu.Value = "X";
        //                                    rep.TraiTuyen.Value = "";
        //                                    rep.DungTuyen.Value = "";
        //                                }
        //                            }
        //                            if (tt.Count > 0)
        //                            {
        //                                StringDatetimeType _fmat = Common.FormatDate;
        //                                if (Common.MaBV == "30002")
        //                                    _fmat = StringDatetimeType.FullDate;
        //                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                            }

        //                            if (Rvien.Count > 0)
        //                            {
        //                                int _makp = 0;
        //                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                    _makp = Rvien.First().MaKP.Value;
        //                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                if (kphong.Count > 0)
        //                                    rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                if (Rvien.First().SoNgaydt != null)
        //                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                            }
        //                            string _ngaysinh = "";
        //                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                            rep.NSinh.Value = _ngaysinh;

        //                            rep.Tongtien.Value = bk01.Where(p => p.TrongBH == 0).Sum(p => p.ThanhTien);
        //                            rep.DataSource = bk01.ToList();
        //                            rep.BindingData();
        //                            rep.CreateDocument();
        //                            // rep.DataMember = "Table";
        //                            //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                            frm.ShowDialog();

        //                        }
        //                    }
        //                    #region Bỏ in bảng kê phụ thu, in chung với bk ngoài danh mục
        //                    //var bk01_03 = (from vp1 in tt
        //                    //               join vpct in _lvpct.Where(p => p.TrongBH == 3) on vp1.idVPhi equals vpct.idVPhi
        //                    //               join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                    //               select new { vp1.MaKP, dv.TenNhom, dv.STT, vpct.idVPhict, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    //if(bk01_03.Count>0)
        //                    //{
        //                    //    BaoCao.repBangKeCPNgoaiBH_A4 rep = new BaoCao.repBangKeCPNgoaiBH_A4();
        //                    //    rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                    //    rep.MaBNhan.Value = _mabn;
        //                    //    rep.TieuDe.Value = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH";

        //                    //    //if (kp.Count > 0)
        //                    //    //{
        //                    //    //    rep.KhoaPhong.Value = kp.First().TenKP;
        //                    //    //}

        //                    //    if (par.Count > 0)
        //                    //    {
        //                    //        rep.DiaChi.Value = par.First().DChi;
        //                    //        int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                    //        if (gioiTinh == 1)
        //                    //        {
        //                    //            rep.Nam.Value = "X";
        //                    //        }
        //                    //        else if (gioiTinh == 0)
        //                    //        {
        //                    //            rep.Nu.Value = "X";
        //                    //        }
        //                    //        try
        //                    //        {
        //                    //            var mk = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).Max(p => p.SoKB);
        //                    //            if (mk > 0)
        //                    //            {
        //                    //                rep.SoKB.Value = mk;

        //                    //            }
        //                    //        }
        //                    //        catch (Exception)
        //                    //        {
        //                    //            rep.SoKB.Value = "";
        //                    //        }
        //                    //        if (_ngaykham.Count > 0 && _ngaykham.First().NgayKham != null)
        //                    //            rep.NgayKham.Value = FormatHelper.NgaySangChu(_ngaykham.First().NgayKham.Value, 3);

        //                    //        if (Rvien.Count > 0)
        //                    //            rep.NgayKT.Value = Rvien.First().NgayRa;
        //                    //        _DTuong = (par.First().DTuong).ToString();
        //                    //        if (_DTuong.Contains("BHYT"))
        //                    //        {
        //                    //            rep.SoThe.Value = par.First().SThe;
        //                    //            rep.coBH.Value = "X";
        //                    //            rep.HanBHTu.Value = par.First().HanBHTu;
        //                    //            rep.HanBHDen.Value = par.First().HanBHDen;
        //                    //            string macs = "";
        //                    //            if (par.First().MaCS != null)
        //                    //            {
        //                    //                macs = par.First().MaCS;
        //                    //                rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                    //            }
        //                    //            var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                    //            if (csdkbd.Count > 0)
        //                    //            {
        //                    //                rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                    //            }


        //                    //            int dungtuyen = 0;
        //                    //            if (par.First().Tuyen != null)
        //                    //            {
        //                    //                dungtuyen = int.Parse(par.First().Tuyen.ToString());

        //                    //            }
        //                    //            rep.mucHuong.Value = "Chi phí phụ thu";
        //                    //            //if (dungtuyen == 1)
        //                    //            //{
        //                    //            //    rep.DungTuyen.Value = "X";
        //                    //            //    if (m == 0)
        //                    //            //        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT";
        //                    //            //    else
        //                    //            //        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT (XHH)";

        //                    //            //}
        //                    //            //else if (dungtuyen == 2)
        //                    //            //{

        //                    //            //    rep.TraiTuyen.Value = "X";
        //                    //            //    if (m == 0)
        //                    //            //        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT";
        //                    //            //    else
        //                    //            //        rep.mucHuong.Value = "NGOÀI DANH MỤC BHYT (XHH)";
        //                    //            //}
        //                    //            int capcuu = int.Parse(par.First().CapCuu.ToString());
        //                    //            if (capcuu == 1)
        //                    //            {
        //                    //                rep.CapCuu.Value = "X";
        //                    //                rep.TraiTuyen.Value = "";
        //                    //                rep.DungTuyen.Value = "";
        //                    //            }
        //                    //        }
        //                    //        if (tt.Count > 0)
        //                    //        {
        //                    //            StringDatetimeType _fmat = Common.FormatDate;
        //                    //            if (Common.MaBV == "30002")
        //                    //                _fmat = StringDatetimeType.FullDate;
        //                    //            rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                    //        }

        //                    //        if (Rvien.Count > 0)
        //                    //        {
        //                    //            int _makp = 0;
        //                    //            if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                    //                _makp = Rvien.First().MaKP.Value;
        //                    //            var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                    //            if (kphong.Count > 0)
        //                    //                rep.KhoaPhong.Value = kphong.First().TenKP;
        //                    //            rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                    //            rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                    //            if (Rvien.First().SoNgaydt != null)
        //                    //                rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                    //        }
        //                    //        string _ngaysinh = "";
        //                    //        if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                    //            _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                    //        if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                    //            _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                    //        if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                    //            _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                    //        rep.NSinh.Value = _ngaysinh;

        //                    //        rep.Tongtien.Value = bk01_03.Sum(p => p.ThanhTien);
        //                    //        rep.DataSource = bk01_03.ToList();
        //                    //        rep.BindingData();
        //                    //        rep.CreateDocument();
        //                    //        // rep.DataMember = "Table";
        //                    //        //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                    //        frm.ShowDialog();

        //                    //    }
        //                    //}
        //                    #endregion
        //                    var bk00_02 = (from vp1 in tt
        //                                   join vpct in _lvpct.Where(p => p.TrongBH == 2).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                   join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                   select new { vp1.MaKP, dv.TenNhom, dv.STT, vpct.idVPhict, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    var bk01_02 = (from a in bk00_02
        //                                   select new
        //                                   {
        //                                       a.MaKP,
        //                                       TenNhom = (Common.MaBV != "01071") ? a.TenNhom : (a.TenNhom.Replace("trong danh mục BHYT", "")),
        //                                       a.STT,
        //                                       a.idVPhict,
        //                                       a.TenDV,
        //                                       a.DonVi,
        //                                       a.DonGia,
        //                                       a.SoLuong,
        //                                       a.ThanhTien,
        //                                       a.TienBH,
        //                                       a.TienBN,
        //                                       a.TrongBH,
        //                                       a.TrongDM
        //                                   }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();

        //                    if (bk01_02.Count > 0)
        //                    {

        //                        BaoCao.repBangKeCPNgoaiBH_A4 rep = new BaoCao.repBangKeCPNgoaiBH_A4();
        //                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                        rep.MaBNhan.Value = _mabn;
        //                        rep.TieuDe.Value = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH";

        //                        //if (kp.Count > 0)
        //                        //{
        //                        //    rep.KhoaPhong.Value = kp.First().TenKP;
        //                        //}

        //                        if (par.Count > 0)
        //                        {
        //                            rep.DiaChi.Value = par.First().DChi;
        //                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                            if (gioiTinh == 1)
        //                            {
        //                                rep.Nam.Value = "X";
        //                            }
        //                            else if (gioiTinh == 0)
        //                            {
        //                                rep.Nu.Value = "X";
        //                            }
        //                            if (par.First().SoKB != null)
        //                                rep.SoKB.Value = par.First().SoKB;
        //                            if (_ngaykham.Count > 0 && _ngaykham.First().NgayKham != null)
        //                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_ngaykham.First().NgayKham.Value, 3);

        //                            if (Rvien.Count > 0)
        //                                rep.NgayKT.Value = Rvien.First().NgayRa;
        //                            _DTuong = (par.First().DTuong).ToString();
        //                            if (_DTuong.Contains("BHYT"))
        //                            {
        //                                rep.SoThe.Value = par.First().SThe;
        //                                rep.coBH.Value = "X";
        //                                //  string muc = txtSoThe.Text.Substring(2, 1);

        //                                rep.HanBHTu.Value = par.First().HanBHTu;
        //                                rep.HanBHDen.Value = par.First().HanBHDen;
        //                                string macs = "";
        //                                if (par.First().MaCS != null)
        //                                {
        //                                    macs = par.First().MaCS;
        //                                    rep.MaCS.Value = macs.Substring(0, 2) + "-" + macs.Substring(2, 3);
        //                                }
        //                                var csdkbd = _dataContext.BenhViens.Where(p => p.MaBV == macs).ToList();
        //                                if (csdkbd.Count > 0)
        //                                {
        //                                    rep.CSDKKCB.Value = csdkbd.First().TenBV;
        //                                }


        //                                int dungtuyen = 0;
        //                                if (par.First().Tuyen != null)
        //                                {
        //                                    dungtuyen = int.Parse(par.First().Tuyen.ToString());

        //                                }
        //                                if (dungtuyen == 1)
        //                                {
        //                                    rep.DungTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "Không phải thanh toán".ToUpper();
        //                                    else
        //                                        rep.mucHuong.Value = "Không phải thanh toán (xhh)".ToUpper();

        //                                }
        //                                else if (dungtuyen == 2)
        //                                {
        //                                    rep.TraiTuyen.Value = "X";
        //                                    if (m == 0)
        //                                        rep.mucHuong.Value = "Không phải thanh toán".ToUpper();
        //                                    else
        //                                        rep.mucHuong.Value = "Không phải thanh toán (xhh)".ToUpper();
        //                                }
        //                                int capcuu = int.Parse(par.First().CapCuu.ToString());
        //                                if (capcuu == 1)
        //                                {
        //                                    rep.CapCuu.Value = "X";
        //                                    rep.TraiTuyen.Value = "";
        //                                    rep.DungTuyen.Value = "";
        //                                }
        //                            }
        //                            if (tt.Count > 0)
        //                            {
        //                                StringDatetimeType _fmat = Common.FormatDate;
        //                                if (Common.MaBV == "30002")
        //                                    _fmat = StringDatetimeType.FullDate;
        //                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                            }

        //                            if (Rvien.Count > 0)
        //                            {
        //                                int _makp = 0;
        //                                if (Rvien.Count > 0 && Rvien.First().MaKP != null)
        //                                    _makp = Rvien.First().MaKP.Value;
        //                                var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                                if (kphong.Count > 0)
        //                                    rep.KhoaPhong.Value = kphong.First().TenKP;
        //                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                if (Rvien.First().SoNgaydt != null)
        //                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                            }
        //                            string _ngaysinh = "";
        //                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                            rep.NSinh.Value = _ngaysinh;

        //                            rep.Tongtien.Value = bk01_02.Sum(p => p.ThanhTien);
        //                            if (bk01_02.Count > 0)
        //                            {
        //                                rep.DataSource = bk01_02.ToList();
        //                                rep.BindingData();
        //                                rep.CreateDocument();
        //                                // rep.DataMember = "Table";
        //                                //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                frm.ShowDialog();
        //                            }
        //                        }
        //                    }



        //                    #endregion
        //                }
        //                else
        //                {
        //                    #region _HTTT != 1
        //                    var bk00_02 = (from vp1 in tt
        //                                   join vpct in _lvpct.Where(p => p.TrongBH == 2).Where(p => m == 0 ? (p.XHH == 0) : (p.XHH > 0)) on vp1.idVPhi equals vpct.idVPhi
        //                                   join dv in dichvu on vpct.MaDV equals dv.MaDV
        //                                   select new { vp1.MaKP, dv.TenNhom, dv.STT, vpct.idVPhict, TenDV = (Common.MaBV == "12001" || _CQCQ == "12001") ? ((dv.TenRG != null && dv.TenRG.Trim() != "") ? dv.TenRG : (dv.TenDV + " " + dv.HamLuong)) : dv.TenDV, vpct.DonVi, vpct.DonGia, vpct.SoLuong, vpct.ThanhTien, vpct.TienBH, vpct.TienBN, vpct.TrongBH, dv.TrongDM }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    var bk01_02 = (from a in bk00_02
        //                                   select new
        //                                   {
        //                                       a.MaKP,
        //                                       TenNhom = (Common.MaBV != "01071") ? a.TenNhom : (a.TenNhom.Replace("trong danh mục BHYT", "")),
        //                                       a.STT,
        //                                       a.idVPhict,
        //                                       a.TenDV,
        //                                       a.DonVi,
        //                                       a.DonGia,
        //                                       a.SoLuong,
        //                                       a.ThanhTien,
        //                                       a.TienBH,
        //                                       a.TienBN,
        //                                       a.TrongBH,
        //                                       a.TrongDM
        //                                   }).Where(p => p.SoLuong != 0).OrderBy(p => p.idVPhict).ToList();
        //                    if (bk01_02.Count > 0)
        //                    {

        //                        BaoCao.repBangKeCPNgoaiBH_A4 rep = new BaoCao.repBangKeCPNgoaiBH_A4();
        //                        rep.tenBN.Value = Common.MaBV == "20001" ? _tenbn.ToUpper() : _tenbn;
        //                        rep.MaBNhan.Value = _mabn;
        //                        rep.TieuDe.Value = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH";


        //                        if (m == 0)
        //                            rep.mucHuong.Value = "Không phải thanh toán".ToUpper();
        //                        else
        //                            rep.mucHuong.Value = "Không phải thanh toán (xhh)".ToUpper();
        //                        //if (kp.Count > 0)
        //                        //{
        //                        //    rep.KhoaPhong.Value = kp.First().TenKP;
        //                        //}

        //                        if (par.Count > 0)
        //                        {
        //                            rep.DiaChi.Value = par.First().DChi;
        //                            int gioiTinh = int.Parse(par.First().GTinh.ToString());
        //                            if (gioiTinh == 1)
        //                            {
        //                                rep.Nam.Value = "X";
        //                            }
        //                            else if (gioiTinh == 0)
        //                            {
        //                                rep.Nu.Value = "X";
        //                            }
        //                            if (par.First().SoKB != null)
        //                                rep.SoKB.Value = par.First().SoKB;
        //                            if (_ngaykham.Count > 0 && _ngaykham.First().NgayKham != null)
        //                                rep.NgayKham.Value = FormatHelper.NgaySangChu(_ngaykham.First().NgayKham.Value, Common.FormatDate);

        //                            if (Rvien.Count > 0)
        //                                rep.NgayKT.Value = Rvien.First().NgayRa;
        //                            _DTuong = (par.First().DTuong).ToString();

        //                            if (tt.Count > 0)
        //                            {
        //                                StringDatetimeType _fmat = Common.FormatDate;
        //                                if (Common.MaBV == "30002")
        //                                    _fmat = StringDatetimeType.FullDate;
        //                                rep.NgayTT.Value = FormatHelper.NgaySangChu(tt.First().NgayTT.Value, _fmat);
        //                            }

        //                            if (Rvien.Count > 0)
        //                            {
        //                                rep.ChanDoan.Value = ICDProvider.GetICDstr(Rvien.First().ChanDoan);
        //                                rep.MaICD.Value = ICDProvider.GetICDstr(Rvien.First().MaICD);
        //                                if (Rvien.First().SoNgaydt != null)
        //                                    rep.TongNgay.Value = Rvien.First().SoNgaydt.ToString() + " ngày";
        //                            }
        //                            string _ngaysinh = "";
        //                            if (par.First().NgaySinh != null && par.First().NgaySinh.ToString() != "")
        //                                _ngaysinh = par.First().NgaySinh.ToString() + "/";
        //                            if (par.First().ThangSinh != null && par.First().ThangSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().ThangSinh.ToString() + "/";
        //                            if (par.First().NamSinh != null && par.First().NamSinh.ToString() != "")
        //                                _ngaysinh = _ngaysinh + par.First().NamSinh.ToString();
        //                            rep.NSinh.Value = _ngaysinh;
        //                            int _makp = 0;
        //                            if (bk01_02.Count > 0 && bk01_02.First().MaKP != null)
        //                                _makp = bk01_02.First().MaKP.Value;
        //                            var kphong = _dataContext.KPhongs.Where(p => p.MaKP == (_makp)).ToList();
        //                            if (kphong.Count > 0)
        //                                rep.KhoaPhong.Value = kphong.First().TenKP;
        //                            rep.Tongtien.Value = bk01_02.Sum(p => p.ThanhTien);
        //                            if (bk01_02.Count > 0)
        //                            {
        //                                rep.DataSource = bk01_02.ToList();
        //                                rep.BindingData();
        //                                rep.CreateDocument();
        //                                // rep.DataMember = "Table";
        //                                //frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //                                frm.ShowDialog();
        //                            }
        //                        }
        //                    }
        //                    #endregion
        //                }
        //                #endregion
        //                //
        //            }
        //        }
        //        //ket thuc bang ke 02
        //    }//123
        //    else
        //    {
        //        MessageBox.Show("Bệnh nhân chưa được thanh toán!");
        //    }
        //    //ket thuc bang ke 01
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show("Lỗi xem bảng kê " + ex.Message);
        //    //}
        //}

        public static void Demo1(int _mabn)
        {

        }
        public static void Demo2(int _mabn)
        {

        }
        public static void Demo1(Hospital _dataContext, int _mabn, int _maubk, int kieu)
        {

        }
    }
}
