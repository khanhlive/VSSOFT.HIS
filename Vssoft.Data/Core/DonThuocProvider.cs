using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class DonThuocProvider
    {
        public static void CapNhatTrongBHForBenhNhan(Hospital _data, int _mabn)
        {
            string _doiTuongBH_DV = "";
            var bn = _data.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
            if (bn.Count > 0)
            {
                _doiTuongBH_DV = bn.First().DTuong;
            }
            if (_doiTuongBH_DV == "Dịch vụ")
            {
                var update = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _mabn)
                              join dtct in _data.DThuoccts on dt.IDDon equals dtct.IDDon
                              select dtct).ToList();
                if (update.Count > 0)
                {
                    foreach (var a in update)
                    {
                        a.TrongBH = 0;

                    }

                    _data.SaveChanges();
                }
            }
        }

        //public static void InDon(int _IDDon, int _IDBN, int maKP)
        //{

        //    int _int_maBN = 0;
        //    string _maCQCQ = "";
        //    Form frm = new Form();
        //    Hospital _data = new Hospital();
        //    var qMaChuQuan = _data.BenhViens.Where(p => p.MaBV == Common.MaBV).FirstOrDefault();
        //    if (qMaChuQuan != null)
        //        _maCQCQ = qMaChuQuan.MaChuQuan;
        //    DThuoc dthuoc = _data.DThuocs.Where(p => p.IDDon == _IDDon).FirstOrDefault();
        //    if (maKP == 0 && dthuoc != null)
        //        maKP = dthuoc.MaKP ?? 0;
        //    KPhong kph = _data.KPhongs.Where(p => p.MaKP == maKP).FirstOrDefault();
        //    if (dthuoc != null)
        //        _int_maBN = dthuoc.MaBNhan ?? 0;
        //    var ktkd = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _int_maBN).Where(p => (Common.MaBV == "27001") ? true : p.IDDon == _IDDon).Where(p => p.PLDV == 1)
        //                join dtct in _data.DThuoccts.Where(p => Common.MaBV == "27001" ? p.MaKP == maKP : true).Where(p => (Common.MaBV == "27023" || Common.MaBV == "27022" || Common.MaBV == "12122") ? true : p.TrongBH != 2) on dt.IDDon equals dtct.IDDon
        //                join cb in _data.CanBoes on dt.MaCB equals cb.MaCB
        //                join kp in _data.KPhongs on dt.MaKP equals kp.MaKP
        //                select new { dt.GhiChu, dt.IDDon, cb.CapBac, dt.KieuDon, dt.LoaiDuoc, dt.MaBNhan, dt.NgayKe, dt.PLDV, cb.TenCB, kp.TenKP }).ToList();

        //    if (ktkd.Count > 0)// kiểm tra có đơn thuốc hay chưa
        //    {
        //        // int _int_maBN = ktkd.First().MaBNhan ?? 0;
        //        string matinh = Common.MaBV.Substring(0, 2);
        //        switch (matinh)
        //        {
        //            #region case 99
        //            case "99": //bỏ (chưa dùng)
        //                BaoCao.rep_PhieuKCBNgoaiT rep = new BaoCao.rep_PhieuKCBNgoaiT();
        //                rep._idDon.Value = ktkd.First().IDDon;
        //                var tt = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _int_maBN)
        //                          join kb in _data.BNKBs on bn.MaBNhan equals kb.MaBNhan
        //                          select new { bn.GTinh, bn.TenBNhan, bn.NamSinh, bn.HanBHDen, bn.HanBHTu, bn.NgaySinh, bn.ThangSinh, bn.NNhap, kb.MaICD, kb.ChanDoan, kb.BenhKhac, kb.IDKB, bn.SThe, bn.DChi }).OrderByDescending(p => p.IDKB).ToList();
        //                if (tt.Count > 0)
        //                {
        //                    rep._TenBNhan.Value = tt.First().TenBNhan;
        //                    rep.Tuoi.Value = BenhNhanProvider.TuoitheoThang(_data, _int_maBN, Common.formatAge);
        //                    switch (tt.First().GTinh)
        //                    {
        //                        case 1:
        //                            rep.GTinh.Value = "Nam";
        //                            break;
        //                        case 0:
        //                            rep.GTinh.Value = "Nữ";
        //                            break;
        //                    }
        //                    if (tt.First().HanBHDen != null && tt.First().HanBHDen.Value.Day > 0)
        //                        rep.HanDen.Value = tt.First().HanBHDen.ToString().Substring(0, 10);
        //                    if (tt.First().HanBHTu != null && tt.First().HanBHTu.Value.Day > 0)
        //                        rep.HanTu.Value = tt.First().HanBHTu.ToString().Substring(0, 10);
        //                    rep.ICD.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[0];
        //                    rep.SThe.Value = tt.First().SThe;
        //                    rep.ChanDoan.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[1];
        //                    rep.TenCB.Value = ktkd.First().TenCB;
        //                    rep.TenKP.Value = ktkd.First().TenKP;
        //                    rep.DiaChi.Value = tt.First().DChi;
        //                    rep._MaBNhan.Value = _int_maBN.ToString();
        //                    if (ktkd.First().NgayKe.Value.Day > 0)
        //                    {
        //                        rep.Ngaykham.Value = ktkd.First().NgayKe.ToString().Substring(0, 10);
        //                        rep.ngayke.Value = FormatHelper.NgaySangChu(ktkd.First().NgayKe.Value);
        //                    }
        //                    // lấy mã KCB ban đầu
        //                    var madkkcb = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _int_maBN)
        //                                   join bv in _data.BenhViens on bn.MaCS equals bv.MaBV
        //                                   select new { bv.TenBV }).ToList();
        //                    if (madkkcb.Count > 0)
        //                        rep.dkkcbbd.Value = madkkcb.First().TenBV;
        //                }
        //                //int id = ktkd.First().IDDon;
        //                var q = (from dv in _data.DichVus
        //                         join dtct in _data.DThuoccts.Where(p => p.TrongBH != 2) on dv.MaDV equals dtct.MaDV
        //                         join dt in _data.DThuocs.Where(p => p.MaBNhan == _int_maBN) on dtct.IDDon equals dt.IDDon
        //                         join nhomdv in _data.NhomDVs on dv.IDNhom equals nhomdv.IDNhom
        //                         //where (dtct.IDDon == id)
        //                         group new { dv, dtct, nhomdv } by new { nhomdv.TenNhom, nhomdv.STT, dv.TenDV, dv.MaDV, dv.DonVi, dtct.DonGia } into kq
        //                         select new { kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.MaDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.dtct.SoLuong), ThanhTien = kq.Sum(p => p.dtct.ThanhTien) }).OrderBy(p => p.STT).OrderBy(p => p.TenDV).ToList();
        //                //HuongDan = dtct.DuongD + dtct.SoLan + dtct.MoiLan + dtct.DviUong 
        //                //var q = (from dv in _data.DichVus
        //                //         join dtct in _data.DThuoccts on dv.MaDV equals dtct.MaDV
        //                //         where (dtct.IDDon == id)
        //                //         group new { dv, dtct } by new { dv.TenDV, dv.MaDV, dtct.DonVi } into kq
        //                //         select new { kq.Key.TenDV, kq.Key.MaDV, kq.Key.DonVi, SoLuong = kq.Sum(p => p.dtct.SoLuong) }).ToList();
        //                if (q.Count > 0)
        //                    rep.DataSource = q.ToList();
        //                //rep.ShowPreviewDialog();
        //                //rep.DataMember = "Table";
        //                rep.BindData();
        //                rep.CreateDocument();
        //                frm.prcIN.PrintingSystem = rep.PrintingSystem;

        //                frm.ShowDialog();
        //                break;
        //            #endregion
                    
        //            #region default
        //            default:
        //                if (DateTime.Now.Date >= Convert.ToDateTime("01/05/2016") && Common.MaBV != "26007")
        //                {
        //                    #region 30340
        //                    if (Common.MaBV == "30340")
        //                    {
        //                        for (int i = 1; i < 3; i++)
        //                        {
        //                            BaoCao.repDonThuoc_TT05_A4 repd = new BaoCao.repDonThuoc_TT05_A4();
        //                            repd._idDon.Value = ktkd.First().IDDon;
        //                            var ttd = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _int_maBN)
        //                                       join kb in _data.BNKBs on bn.MaBNhan equals kb.MaBNhan
        //                                       select new { bn.GTinh, bn.TenBNhan, bn.NamSinh, bn.NgaySinh, bn.ThangSinh, bn.NNhap, kb.MaICD, kb.ChanDoan, kb.BenhKhac, kb.IDKB, bn.SThe, bn.DChi, kb.GhiChu }).OrderByDescending(p => p.IDKB).ToList();
        //                            if (ttd.Count > 0)
        //                            {
        //                                repd._TenBNhan.Value = ttd.First().TenBNhan;

        //                                repd.Tuoi.Value = BenhNhanProvider.TuoitheoThang(_data, _int_maBN, Common.formatAge);
        //                                repd.lblTuoi.Text = "Tuổi:";


        //                                //Lời dặn, họ tên người thân
        //                                string _ghichu = ttd.First().GhiChu ?? "";
        //                                string[] ar = _ghichu.Split(';');
        //                                if (ar.Length > 0)
        //                                    repd.paraHoTenNguoiThan.Value = ar[0];
        //                                if (ar.Length > 1)
        //                                    repd.paraLoDanBS.Value = ar[1];

        //                                // KT
        //                                switch (ttd.First().GTinh)
        //                                {
        //                                    case 1:
        //                                        repd.GTinh.Value = "Nam";
        //                                        repd.Nu.Value = "/";
        //                                        break;
        //                                    case 0:
        //                                        repd.GTinh.Value = "Nữ";
        //                                        repd.Nam.Value = "/";
        //                                        break;
        //                                }
        //                                repd.ICD.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[0];
        //                                repd.SThe.Value = ttd.First().SThe;
        //                                repd.ChanDoan.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[1];
        //                                repd.TenCB.Value = ktkd.First().CapBac + ": " + ktkd.First().TenCB;

        //                                repd.TenKP.Value = ktkd.First().TenKP;
        //                                repd.DiaChi.Value = ttd.First().DChi;
        //                                repd._MaBNhan.Value = _int_maBN.ToString();
        //                                if (ktkd.First().NgayKe.Value.Day > 0)
        //                                    repd.ngayke.Value = FormatHelper.NgaySangChu(ktkd.First().NgayKe.Value);
        //                                var qd1 = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _int_maBN).Where(p => Common.MaBV == "27001" ? true : dthuoc.IDDon == _IDDon).Where(p => p.PLDV == 1)
        //                                           join dtct in _data.DThuoccts.Where(p => Common.MaBV == "27001" ? p.MaKP == maKP : true).Where(p => Common.MaBV == "27023" ? true : p.TrongBH != 2) on dt.IDDon equals dtct.IDDon
        //                                           join dv in _data.DichVus on dtct.MaDV equals dv.MaDV
        //                                           join tn in _data.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
        //                                           where tn.TenRG != "Thuốc gây nghiện" && tn.TenRG != "Thuốc hướng tâm thần"
        //                                           select new { TenDV = Common.MaBV == "30012" ? (dv.TenHC + " (" + dv.TenDV + ")") : ((Common.MaBV == "30007") ? (dv.TenHC + ": " + dv.HamLuong + " (" + dv.TenDV + ") ") : dv.TenDV), dv.TenHC, dv.HamLuong, dv.MaDV, dv.DonVi, dtct.SoLuong, dtct.IDDonct, dtct.GhiChu, HuongDan = "", DuongD = dtct.DuongD ?? "", SoLan = dtct.SoLan ?? "", MoiLan = dtct.MoiLan ?? "", Luong = dtct.Luong ?? "", DviUong = dtct.DviUong ?? "", dtct.TrongBH }).OrderBy(p => p.IDDonct).ToList();

        //                                var qd2 = (from dv in qd1
        //                                           select new { TenDV = Common.MaBV == "08602" ? dv.TenHC + "(" + dv.TenDV + ")" + " " + dv.HamLuong : dv.TenDV, dv.HamLuong, dv.MaDV, dv.DonVi, dv.SoLuong, dv.IDDonct, dv.TrongBH, HuongDan = dv.DuongD + dv.SoLan + dv.MoiLan + dv.Luong + dv.DviUong + dv.GhiChu }).OrderBy(p => p.IDDonct).ToList();
        //                                repd.ThuKho.Value = Common.ThuKho;
        //                                if (qd2.Where(p => p.TrongBH == 1).Count() > 0 && i == 1)
        //                                {
        //                                    repd.DataSource = qd2.Where(p => p.TrongBH == 1).ToList();
        //                                    repd.celTrongNgoaiDM.Text = "(Thuốc trong danh mục BHYT)";
        //                                    repd.BindData();
        //                                    repd.CreateDocument();
        //                                    frm.prcIN.PrintingSystem = repd.PrintingSystem;
        //                                    frm.ShowDialog();
        //                                }
        //                                else if (i == 2 && qd2.Where(p => p.TrongBH == 0).Count() > 0)
        //                                {
        //                                    repd.DataSource = qd2.Where(p => p.TrongBH == 0).ToList();
        //                                    repd.celTrongNgoaiDM.Text = "(Thuốc ngoài danh mục BHYT)";
        //                                    repd.BindData();
        //                                    repd.CreateDocument();
        //                                    frm.prcIN.PrintingSystem = repd.PrintingSystem;
        //                                    frm.ShowDialog();
        //                                }
        //                            }
        //                        }
        //                    }
        //                    #endregion
        //                    #region default
        //                    else
        //                    {
        //                        if (DateTime.Now < Convert.ToDateTime("30/01/2017"))
        //                        {
        //                            var qdtct = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _int_maBN).Where(p => p.PLDV == 1)
        //                                         join dtct in _data.DThuoccts on dt.IDDon equals dtct.IDDon
        //                                         select dtct).ToList();
        //                            foreach (var t in qdtct)
        //                            {
        //                                t.ThanhTien = t.SoLuong * t.DonGia * t.TyLeTT / 100;
        //                                _data.SaveChanges();
        //                            }
        //                        }


        //                        #region bv khác
        //                        BaoCao.repDonThuoc_TT05 repd = new BaoCao.repDonThuoc_TT05();

        //                        repd._idDon.Value = ktkd.First().IDDon;
        //                        var ttd = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _int_maBN)
        //                                   join kb in _data.BNKBs on bn.MaBNhan equals kb.MaBNhan
        //                                   select new { bn.GTinh, bn.TenBNhan, bn.NamSinh, bn.NgaySinh, bn.ThangSinh, bn.NNhap, kb.MaICD, kb.ChanDoan, kb.BenhKhac, kb.IDKB, bn.SThe, bn.DChi, kb.GhiChu }).OrderByDescending(p => p.IDKB).ToList();
        //                        if (ttd.Count > 0)
        //                        {
        //                            repd._TenBNhan.Value = ttd.First().TenBNhan;
        //                            if (Common.MaBV == "27001")
        //                            {
        //                                repd.Tuoi.Value = ttd.First().NamSinh;
        //                                repd.lblTuoi.Text = "N.Sinh:";
        //                            }
        //                            else
        //                            {
        //                                repd.Tuoi.Value = BenhNhanProvider.TuoitheoThang(_data, _int_maBN, Common.formatAge);
        //                                repd.lblTuoi.Text = "Tuổi:";
        //                            }

        //                            //Lời dặn, họ tên người thân
        //                            string _ghichu = ttd.First().GhiChu ?? "";
        //                            string[] ar = _ghichu.Split(';');
        //                            if (ar.Length > 0)
        //                                repd.paraHoTenNguoiThan.Value = ar[0];
        //                            if (ar.Length > 1)
        //                                repd.paraLoDanBS.Value = ar[1];

        //                            // KT
        //                            switch (ttd.First().GTinh)
        //                            {
        //                                case 1:
        //                                    repd.GTinh.Value = "Nam";
        //                                    repd.Nu.Value = "/";
        //                                    break;
        //                                case 0:
        //                                    repd.GTinh.Value = "Nữ";
        //                                    repd.Nam.Value = "/";
        //                                    break;
        //                            }
        //                            repd.ICD.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[0];
        //                            repd.SThe.Value = ttd.First().SThe;
        //                            repd.ChanDoan.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[1];
        //                            repd.TenCB.Value = ktkd.First().CapBac + ": " + ktkd.First().TenCB;
        //                            if (Common.MaBV == "27001" && kph != null)
        //                                repd.TenKP.Value = kph.TenKP;
        //                            else
        //                                repd.TenKP.Value = ktkd.First().TenKP;
        //                            repd.DiaChi.Value = ttd.First().DChi;
        //                            repd._MaBNhan.Value = _int_maBN.ToString();
        //                            if (ktkd.First().NgayKe.Value.Day > 0)
        //                                repd.ngayke.Value = FormatHelper.NgaySangChu(ktkd.First().NgayKe.Value);

        //                        }

        //                        var qd1 = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _int_maBN).Where(p => Common.MaBV == "27001" ? true : p.IDDon == _IDDon).Where(p => p.PLDV == 1)
        //                                   join dtct in _data.DThuoccts.Where(p => Common.MaBV == "27001" ? p.MaKP == maKP : true).Where(p => (Common.MaBV == "27023" || Common.MaBV == "27022" || Common.MaBV == "12122") ? true : p.TrongBH != 2) on dt.IDDon equals dtct.IDDon
        //                                   join dv in _data.DichVus on dtct.MaDV equals dv.MaDV
        //                                   join tn in _data.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
        //                                   where tn.TenRG != "Thuốc gây nghiện" && tn.TenRG != "Thuốc hướng tâm thần"
        //                                   select new { TenTNRG = tn.TenRG, dv.TenRG, TenDV = Common.MaBV == "30012" ? (dv.TenHC + " (" + dv.TenDV + ")") : ((Common.MaBV == "30007") ? (dv.TenHC + ": " + dv.HamLuong + " (" + dv.TenDV + ") ") : ((Common.MaBV == "27183" || Common.MaBV == "27001") ? (dv.TenDV + "( " + dv.HamLuong + ")") : dv.TenDV)), dv.TenHC, dv.HamLuong, dv.MaDV, dv.DonVi, dtct.SoLuong, dtct.IDDonct, dtct.GhiChu, HuongDan = "", DuongD = dtct.DuongD ?? "", SoLan = dtct.SoLan ?? "", MoiLan = dtct.MoiLan ?? "", Luong = dtct.Luong ?? "", DviUong = dtct.DviUong ?? "" }).OrderBy(p => p.IDDonct).ToList();
        //                        //var qd1 = (from tn in _data.TieuNhomDVs
        //                        //           join dv in _data.DichVus on tn.IdTieuNhom equals dv.IdTieuNhom
        //                        //           join dtct in _data.DThuoccts.Where(p => Common.MaBV == "27023" ? true : p.TrongBH != 2) on dv.MaDV equals dtct.MaDV
        //                        //           where (dtct.IDDon == _IDDon)
        //                        //            && tn.TenRG != "Thuốc gây nghiện" && tn.TenRG != "Thuốc hướng tâm thần"
        //                        //           select new { TenDV = Common.MaBV == "30012" ? (dv.TenHC + " (" + dv.TenDV + ")") : ((Common.MaBV == "30007") ? (dv.TenHC + ": " + dv.HamLuong + " (" + dv.TenDV + ") ") : dv.TenDV), dv.TenHC, dv.HamLuong, dv.MaDV, dv.DonVi, dtct.SoLuong, dtct.IDDonct, dtct.GhiChu, HuongDan = "", DuongD = dtct.DuongD ?? "", SoLan = dtct.SoLan ?? "", MoiLan = dtct.MoiLan ?? "", Luong = dtct.Luong ?? "", DviUong = dtct.DviUong ?? "" }).OrderBy(p => p.IDDonct).ToList();
        //                        var qd2 = (from dv in qd1
        //                                   select new { TenDV = (Common.MaBV == "27023" || Common.MaBV == "08602" || (Common.MaBV == "12001" && dv.TenTNRG != Common.st_TieuNhomRG_ChuyenKhoa.ThuocThuong_CPYHCT)) ? (dv.TenHC + "(" + dv.TenDV + ")" + " " + dv.HamLuong) : ((Common.MaBV == "04011" || Common.MaBV == "24009" || _maCQCQ == "24009") ? dv.TenRG : dv.TenDV), dv.HamLuong, dv.MaDV, dv.DonVi, dv.SoLuong, dv.IDDonct, HuongDan = dv.DuongD + dv.SoLan + dv.MoiLan + dv.Luong + dv.DviUong + dv.GhiChu }).OrderBy(p => p.IDDonct).ToList();
        //                        repd.DataSource = qd2.ToList();
        //                        repd.ThuKho.Value = Common.ThuKho;
        //                        repd.BindData();
        //                        repd.CreateDocument();
        //                        frm.prcIN.PrintingSystem = repd.PrintingSystem;
        //                        frm.ShowDialog();
        //                        #endregion


        //                    }
        //                    #endregion
        //                }
        //                else
        //                {

        //                    BaoCao.repDonThuoc repd = new BaoCao.repDonThuoc();
        //                    repd._idDon.Value = ktkd.First().IDDon;
        //                    int _idDon = ktkd.First().IDDon;
        //                    var ttd = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _int_maBN)
        //                               join kb in _data.BNKBs on bn.MaBNhan equals kb.MaBNhan
        //                               select new { bn.GTinh, bn.TenBNhan, bn.NamSinh, bn.NgaySinh, bn.ThangSinh, bn.NNhap, kb.MaICD, kb.ChanDoan, kb.BenhKhac, kb.IDKB, bn.SThe, bn.DChi }).OrderByDescending(p => p.IDKB).ToList();
        //                    if (ttd.Count > 0)
        //                    {
        //                        repd._TenBNhan.Value = ttd.First().TenBNhan;
        //                        repd.Tuoi.Value = BenhNhanProvider.TuoitheoThang(_data, _int_maBN, Common.formatAge);
        //                        // KT
        //                        switch (ttd.First().GTinh)
        //                        {
        //                            case 1:
        //                                repd.GTinh.Value = "Nam";
        //                                break;
        //                            case 0:
        //                                repd.GTinh.Value = "Nữ";
        //                                break;
        //                        }

        //                        repd.ICD.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[0];
        //                        repd.SThe.Value = ttd.First().SThe;
        //                        repd.ChanDoan.Value = ICDProvider.getMaICDarr(_data, _int_maBN, Common.GetICD)[1];

        //                        repd.TenCB.Value = ktkd.First().CapBac + ": " + ktkd.First().TenCB;
        //                        repd.TenKP.Value = ktkd.First().TenKP;
        //                        repd.DiaChi.Value = ttd.First().DChi;
        //                        repd._MaBNhan.Value = _int_maBN.ToString();
        //                        if (ktkd.First().NgayKe.Value.Day > 0)
        //                            repd.ngayke.Value = FormatHelper.NgaySangChu(ktkd.First().NgayKe.Value);
        //                    }
        //                    var qd1 = (from tn in _data.TieuNhomDVs
        //                               join dv in _data.DichVus on tn.IdTieuNhom equals dv.IdTieuNhom
        //                               join dtct in _data.DThuoccts.Where(p => p.TrongBH != 2) on dv.MaDV equals dtct.MaDV
        //                               where (dtct.IDDon == _IDDon)

        //                               select new { dtct.TrongBH, TenDV = Common.MaBV == "27023" ? (dv.TenHC + " (" + dv.TenDV + ")") : dv.TenDV, dv.MaDV, dv.DonVi, dtct.SoLuong, dtct.IDDonct, HuongDan = dtct.DuongD + dtct.SoLan + dtct.MoiLan + dtct.Luong + dtct.DviUong }).OrderBy(p => p.IDDonct).ToList();

        //                    if (Common.MaBV == "24009")
        //                        repd.CongKhoan.Value = "Cộng: " + qd1.Count + " khoản";
        //                    else
        //                        repd.CongKhoan.Value = "Cộng: ............... khoản";
        //                    if (qd1.Count > 0)
        //                        repd.DataSource = qd1.Where(p => Common.MaBV == "30340" ? p.TrongBH == 1 : true).ToList();

        //                    //rep.ShowPreviewDialog();
        //                    //rep.DataMember = "Table";
        //                    repd.ThuKho.Value = Common.ThuKho;
        //                    repd.BindData();
        //                    repd.CreateDocument();
        //                    frm.prcIN.PrintingSystem = repd.PrintingSystem;

        //                    frm.ShowDialog();
        //                    if (Common.MaBV == "12122")
        //                    {
        //                        List<DThuocct> _ldthuocct = _data.DThuoccts.Where(p => p.IDDon == _idDon).Where(p => p.Status != -1).ToList();
        //                        foreach (DThuocct dtct in _ldthuocct)
        //                        {
        //                            dtct.SoPL = -1;

        //                        }
        //                        _data.SaveChanges();
        //                    }
        //                }
        //                break;
        //                #endregion
        //        }//ket thuc switch

        //    }
        //    else // trường hợp không có đơn nhưng vẫn in don có công khám
        //    {
        //        #region 30002
        //        if (Common.MaBV == "30002")
        //        {
        //            BaoCao.rep_PhieuKCBNgoaiT rep = new BaoCao.rep_PhieuKCBNgoaiT();


        //            //rep._idDon.Value = ktkd.First().IDDon;


        //            var tt = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _IDBN)
        //                      join kb in _data.BNKBs on bn.MaBNhan equals kb.MaBNhan
        //                      select new { bn.GTinh, bn.TenBNhan, bn.NamSinh, bn.HanBHDen, bn.HanBHTu, bn.NgaySinh, bn.ThangSinh, bn.NNhap, kb.MaICD, kb.ChanDoan, kb.BenhKhac, kb.IDKB, bn.SThe, bn.DChi }).OrderByDescending(p => p.IDKB).ToList();
        //            if (tt.Count > 0)
        //            {
        //                rep._TenBNhan.Value = tt.First().TenBNhan;
        //                rep.Tuoi.Value = BenhNhanProvider.TuoitheoThang(_data, _IDBN, Common.formatAge);
        //                switch (tt.First().GTinh)
        //                {
        //                    case 1:
        //                        rep.GTinh.Value = "Nam";
        //                        break;
        //                    case 0:
        //                        rep.GTinh.Value = "Nữ";
        //                        break;
        //                }
        //                if (tt.First().HanBHDen != null && tt.First().HanBHDen.Value.Day > 0)
        //                    rep.HanDen.Value = tt.First().HanBHDen.ToString().Substring(0, 10);
        //                if (tt.First().HanBHTu != null && tt.First().HanBHTu.Value.Day > 0)
        //                    rep.HanTu.Value = tt.First().HanBHTu.ToString().Substring(0, 10);
        //                rep.ICD.Value = ICDProvider.getMaICDarr(_data, _IDBN, Common.GetICD)[0];
        //                rep.SThe.Value = tt.First().SThe;
        //                rep.ChanDoan.Value = ICDProvider.getMaICDarr(_data, _IDBN, Common.GetICD)[1];
        //                // lấy khoa phòng
        //                var laykp = (from bnkb in _data.BNKBs.Where(p => p.MaBNhan == _IDBN)
        //                             join kp in _data.KPhongs on bnkb.MaKP equals kp.MaKP
        //                             join cb in _data.CanBoes on bnkb.MaCB equals cb.MaCB
        //                             select new { kp.TenKP, cb.TenCB, bnkb.IDKB, bnkb.NgayKham }).OrderBy(p => p.IDKB).ToList();
        //                if (laykp.Count > 0)
        //                {
        //                    rep.TenCB.Value = laykp.First().TenCB;//
        //                    rep.TenKP.Value = laykp.First().TenKP;//
        //                    rep.Ngaykham.Value = laykp.First().NgayKham.ToString().Substring(0, 10);
        //                    rep.ngayke.Value = FormatHelper.NgaySangChu(laykp.First().NgayKham.Value);
        //                }
        //                rep.DiaChi.Value = tt.First().DChi;
        //                rep._MaBNhan.Value = _IDBN.ToString();

        //                // lấy mã KCB ban đầu
        //                var madkkcb = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _IDBN)
        //                               join bv in _data.BenhViens on bn.MaCS equals bv.MaBV
        //                               select new { bv.TenBV }).ToList();
        //                if (madkkcb.Count > 0)
        //                    rep.dkkcbbd.Value = madkkcb.First().TenBV;
        //            }
        //            var q = (from dv in _data.DichVus
        //                     join dtct in _data.DThuoccts on dv.MaDV equals dtct.MaDV
        //                     join dt in _data.DThuocs.Where(p => p.MaBNhan == _IDBN) on dtct.IDDon equals dt.IDDon
        //                     join nhomdv in _data.NhomDVs on dv.IDNhom equals nhomdv.IDNhom
        //                     //where (dtct.IDDon == id)
        //                     group new { dv, dtct, nhomdv } by new { nhomdv.TenNhom, nhomdv.STT, dv.TenDV, dv.MaDV, dv.DonVi, dtct.DonGia } into kq
        //                     select new { kq.Key.TenNhom, kq.Key.STT, kq.Key.TenDV, kq.Key.MaDV, kq.Key.DonVi, kq.Key.DonGia, SoLuong = kq.Sum(p => p.dtct.SoLuong), ThanhTien = kq.Sum(p => p.dtct.ThanhTien) }).OrderBy(p => p.STT).OrderBy(p => p.TenDV).ToList();
                    
        //            if (q.Count > 0)
        //                rep.DataSource = q.ToList();
        //            rep.BindData();
        //            rep.CreateDocument();
        //            frm.prcIN.PrintingSystem = rep.PrintingSystem;

        //            frm.ShowDialog();
        //        }
        //        #endregion
        //        else
        //        {

        //            #region bv khác

        //            BaoCao.repDonThuoc_TT05 repd = new BaoCao.repDonThuoc_TT05();
        //            var ttd = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _IDBN)
        //                       join kb in _data.BNKBs on bn.MaBNhan equals kb.MaBNhan
        //                       select new { bn.GTinh, bn.TenBNhan, bn.NamSinh, bn.NgaySinh, bn.ThangSinh, bn.NNhap, kb.MaICD, kb.ChanDoan, kb.BenhKhac, kb.IDKB, bn.SThe, bn.DChi, kb.GhiChu }).OrderByDescending(p => p.IDKB).ToList();
        //            if (ttd.Count > 0)
        //            {
        //                repd._TenBNhan.Value = ttd.First().TenBNhan;
        //                if (Common.MaBV == "27001")
        //                {
        //                    repd.Tuoi.Value = ttd.First().NamSinh;
        //                    repd.lblTuoi.Text = "N.Sinh:";
        //                }
        //                else
        //                {
        //                    repd.Tuoi.Value = BenhNhanProvider.TuoitheoThang(_data, _IDBN, Common.formatAge);
        //                    repd.lblTuoi.Text = "Tuổi:";
        //                }
        //                //Lời dặn, họ tên người thân

        //                string _ghichu = ttd.First().GhiChu ?? "";
        //                string[] ar = _ghichu.Split(';');
        //                if (ar.Length > 0)
        //                    repd.paraHoTenNguoiThan.Value = ar[0];
        //                if (ar.Length > 1)
        //                    repd.paraLoDanBS.Value = ar[1];

        //                // KT
        //                switch (ttd.First().GTinh)
        //                {
        //                    case 1:
        //                        repd.GTinh.Value = "Nam";
        //                        repd.Nu.Value = "/";
        //                        break;
        //                    case 0:
        //                        repd.GTinh.Value = "Nữ";
        //                        repd.Nam.Value = "/";
        //                        break;
        //                }
        //                repd.ICD.Value = ICDProvider.getMaICDarr(_data, _IDBN, Common.GetICD)[0];
        //                repd.SThe.Value = ttd.First().SThe;
        //                repd.ChanDoan.Value = ICDProvider.getMaICDarr(_data, _IDBN, Common.GetICD)[1];


        //                repd.DiaChi.Value = ttd.First().DChi;
        //                repd._MaBNhan.Value = _IDBN.ToString();

        //            }
        //            int iddon = 0;

        //            var qd1 = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _IDBN)
        //                       join dtct in _data.DThuoccts.Where(p => Common.MaBV == "27001" ? p.MaKP == maKP : true).Where(p => (Common.MaBV == "27023" || Common.MaBV == "27022" || Common.MaBV == "12122") ? true : p.TrongBH != 2) on dt.IDDon equals dtct.IDDon
        //                       join dv in _data.DichVus on dtct.MaDV equals dv.MaDV
        //                       join nhom in _data.NhomDVs.Where(p => p.TenNhomCT.Contains("Khám bệnh")) on dv.IDNhom equals nhom.IDNhom
        //                       //             select new { dv.TenDV, dtct.SoLuong, dtct.DonGia, dtct.DonVi, dtct.ThanhTien }).ToList();
        //                       select new { dt.IDDon, TenDV = (Common.MaBV == "27023" || Common.MaBV == "30012") ? dv.TenHC + " (" + dv.TenDV + ")" : (Common.MaBV == "27001" ? (dv.TenDV + " (" + dv.HamLuong + ")") : dv.TenDV), dv.MaDV, dv.DonVi, dtct.SoLuong, dtct.IDDonct, HuongDan = dtct.DuongD + dtct.SoLan + dtct.MoiLan + dtct.Luong + dtct.DviUong }).OrderBy(p => p.IDDonct).ToList();
        //            if (qd1.Count > 0)
        //                iddon = qd1.First().IDDon;
        //            repd._idDon.Value = iddon;
        //            var ktkd2 = (from dt in _data.DThuocs.Where(p => p.IDDon == iddon)
        //                         join cb in _data.CanBoes on dt.MaCB equals cb.MaCB
        //                         join kp in _data.KPhongs on dt.MaKP equals kp.MaKP
        //                         select new { dt.GhiChu, dt.IDDon, cb.CapBac, dt.KieuDon, dt.LoaiDuoc, dt.MaBNhan, dt.NgayKe, dt.PLDV, cb.TenCB, kp.TenKP }).ToList();
        //            if (ktkd2.Count > 0)
        //            {
        //                if (Common.MaBV == "24009")
        //                    repd.TenCB.Value = ktkd2.First().CapBac + ": " + ktkd2.First().TenCB;
        //                if (Common.MaBV == "27001" && kph != null)
        //                    repd.TenKP.Value = kph.TenKP;
        //                else
        //                    repd.TenKP.Value = ktkd2.First().TenKP;
        //                if (ktkd2.First().NgayKe.Value.Day > 0)
        //                    repd.ngayke.Value = FormatHelper.NgaySangChu(ktkd2.First().NgayKe.Value);
        //            }
        //            repd.DataSource = qd1.ToList();
        //            repd.ThuKho.Value = Common.ThuKho;
        //            repd.BindData();
        //            repd.CreateDocument();
        //            frm.prcIN.PrintingSystem = repd.PrintingSystem;
        //            frm.ShowDialog();
        //            #endregion


        //        }
        //        //}

        //    }
        //}//

        public static void InDon(int _IDDon, int _IDBN, int maKP)
        {

        }

        public static void InDonThuocTDuong(int mabn, int iddon) { }
        //{
        //    Hospital data = new Hospital();
        //    BaoCao.rep_DThuoc_12001 rep = new BaoCao.rep_DThuoc_12001();
        //    var qbn = (from bn in data.BenhNhans.Where(p => p.MaBNhan == mabn)
        //               join bnkb in data.BNKBs on bn.MaBNhan equals bnkb.MaBNhan
        //               select new
        //               {
        //                   bn.MaBNhan,
        //                   bn.TenBNhan,
        //                   bn.Tuoi,
        //                   GTinh = bn.GTinh == 1 ? "Nam" : "Nữ",
        //                   bn.DChi,
        //                   bn.DTuong,
        //                   bn.SThe,
        //                   bn.HanBHTu,
        //                   bn.HanBHDen,
        //                   bnkb.ChanDoan,
        //                   bnkb.BenhKhac
        //               }).ToList();
        //    if (qbn.Count > 0)
        //    {
        //        rep.lblMaBN.Text = qbn.FirstOrDefault().MaBNhan.ToString();
        //        rep.lblTenBN.Text = qbn.FirstOrDefault().TenBNhan.ToUpper();
        //        rep.lblTuoi.Text = DungChung.Ham.TuoitheoThang(data, mabn, "60-00");//DungChung.Bien.formatAge);
        //        rep.lblGTinh.Text = qbn.FirstOrDefault().GTinh;
        //        rep.lblDChi.Text = qbn.FirstOrDefault().DChi;
        //        rep.lblDTuong.Text = qbn.FirstOrDefault().DTuong;
        //        if (qbn.FirstOrDefault().DTuong.Equals("BHYT"))
        //        {
        //            rep.lblSThe.Text = qbn.FirstOrDefault().SThe;
        //            rep.lblGiaTriTu.Text = String.Format("{0:dd/MM/yyyy}", qbn.FirstOrDefault().HanBHTu);
        //            rep.lblGiaTriDen.Text = String.Format("{0:dd/MM/yyyy}", qbn.FirstOrDefault().HanBHDen);
        //        }
        //        int _IDBN = Convert.ToInt32(qbn.FirstOrDefault().MaBNhan.ToString());
        //        rep.lblMaBenhICD.Text = DungChung.Ham.getMaICDarr(data, _IDBN, DungChung.Bien.GetICD)[0];
        //        rep.lblChanDoan.Text = DungChung.Ham.getMaICDarr(data, _IDBN, DungChung.Bien.GetICD)[1];
        //        rep.celTenBN.Text = qbn.FirstOrDefault().TenBNhan;
        //    }
        //    var qdthuoc = (from dt in data.DThuocs.Where(p => p.MaBNhan == mabn)
        //                   join cb in data.CanBoes on dt.MaCB equals cb.MaCB
        //                   join dtct in data.DThuoccts.Where(p => p.IDDon == iddon) on dt.IDDon equals dtct.IDDon
        //                   join dv in data.DichVus on dtct.MaDV equals dv.MaDV
        //                   select new
        //                   {
        //                       TenThuoc = dv.TenHC + "," + dv.TenDV + ";" + dv.HamLuong,
        //                       dtct.SoLuong,
        //                       dv.DonVi,
        //                       CachDung = dtct.DuongD + " " + dtct.SoLan + " " + dtct.MoiLan + " " + dtct.Luong + " " + dtct.DviUong,
        //                       cb.TenCB,
        //                       dt.NgayKe
        //                   }).ToList();

        //    if (qdthuoc.Count > 0)
        //    {
        //        rep.celBS.Text = qdthuoc.FirstOrDefault().TenCB;
        //        rep.lblCong.Text = qdthuoc.Count().ToString();
        //        DateTime ngayke = Convert.ToDateTime(qdthuoc.First().NgayKe);
        //        rep.celNgay.Text = "Ngày " + ngayke.Day + " tháng " + ngayke.Month + " năm " + ngayke.Year;
        //        frmIn frm = new frmIn();
        //        rep.DataSource = qdthuoc.ToList();
        //        rep.BindingData();
        //        rep.CreateDocument();
        //        frm.prcIN.PrintingSystem = rep.PrintingSystem;
        //        frm.ShowDialog();
        //    }
        //}


        public static bool ThemPhuThu(Hospital _data, int _IDDThuoct, double _GiaPhuThu)
        {
            var _ldtct = _data.DThuoccts.Where(p => p.IDDonct == _IDDThuoct).FirstOrDefault();
            if (_ldtct == null)
                return false;
            DThuocct a = new DThuocct();
            a.IDDon = _ldtct.IDDon;
            a.MaDV = _ldtct.MaDV;
            a.DonVi = _ldtct.DonVi;
            a.SoLuong = _ldtct.SoLuong;
            a.DonGia = _GiaPhuThu;
            a.ThanhTien = _ldtct.SoLuong * _GiaPhuThu;
            a.TienBN = _ldtct.SoLuong * _GiaPhuThu;
            a.TrongBH = 3;
            a.NgayNhap = _ldtct.NgayNhap;
            a.IDCD = _ldtct.IDCD;
            a.MaCB = _ldtct.MaCB;
            a.MaKP = _ldtct.MaKP;
            a.IDKB = _ldtct.IDKB;
            a.Loai = _ldtct.Loai;
            a.ThanhToan = _ldtct.ThanhToan;
            a.MaKPtk = _ldtct.MaKPtk;
            a.TyLeTT = 100;
            a.LoaiDV = _ldtct.LoaiDV;
            a.Status = _ldtct.Status;
            _data.DThuoccts.Add(a);
            _data.SaveChanges();
            return true;
        }
    }
}
