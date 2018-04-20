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
    public class CongKhamProvider
    {
        public static bool KiemtraThietlapCongkham(int? loai, bool boolTheoChuyenKhoa, string MaQD, int MaCK)
        {
            if (boolTheoChuyenKhoa)
            {
                #region Công khám được set theo chuyên khoa
                var a = Common._lChuyenKhoa.Where(p => p.MaCK == MaCK).Select(p => p.MaCK_QD).FirstOrDefault();
                string mack_qd = a.ToString("D2");
                string maCongKham = mack_qd + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];
                if (maCongKham == MaQD)
                    return true;
                else
                    return false;


                #endregion
            }
            else
            {
                #region Công khám không được set theo chuyên khoa (được set theo khoa phòng)

                string maCongKham = (loai == null ? "" : loai.ToString()) + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];
                if (maCongKham == MaQD)
                    return true;
                else
                    return false;
                #endregion
            }
        }

        public static int GetCongKham_ChuyenKhoa(int _maBN, int idkb, DateTime thoigiantaoCK)
        {
            int maDV = 0;
            int _idDTBN = -1;
            string _makpsd = ";";
            int _makp = 0;
            bool ngoaigio = false;
            Hospital DaTaContext = new Hospital();
            #region kiểm tra lần đến khám
            var qbenhnhan = DaTaContext.BenhNhans.Single(p => p.MaBNhan == _maBN);
            DateTime tungaykham = FormatHelper.BeginDate(qbenhnhan.NNhap.Value);
            DateTime denngaykham = FormatHelper.EndDate(qbenhnhan.NNhap.Value);
            var bndakham = DaTaContext.BenhNhans.Where(p => qbenhnhan.IDPerson > 0 && p.IDPerson == qbenhnhan.IDPerson && p.NNhap >= tungaykham && p.NNhap <= denngaykham).ToList();

            #endregion
            var bnhan = DaTaContext.BenhNhans.Where(p => p.MaBNhan == _maBN).FirstOrDefault();
            int _mack = -1;
            int dtbn = -1;
            if (bnhan != null)
            {
                _idDTBN = bnhan.IDDTBN;
                if (_makp == 0)
                    _makp = bnhan.MaKP ?? 0;
                _makpsd = ";" + bnhan.MaKP + ";";
                var qchuyenkhoa = (from kp in DaTaContext.KPhongs.Where(p => p.MaKP == _makp) select kp).FirstOrDefault();
                if (qchuyenkhoa != null)
                    _mack = qchuyenkhoa.MaCK;//?? 0;

                dtbn = DaTaContext.DTBNs.Where(p => p.IDDTBN == _idDTBN).Select(p => p.HTTT).FirstOrDefault();
            }

            var bnkbT = DaTaContext.BNKBs.Where(p => p.MaBNhan == _maBN).ToList();
            var bnkb = bnkbT.Where(p => p.IDKB == idkb).ToList();
            if (bnkb.Count > 0)
            {
                _mack = bnkb.First().MaCK;
                _makpsd = ";" + bnkb.First().MaKP + ";";
                _makp = bnkb.First().MaKP == null ? 0 : bnkb.First().MaKP.Value;

            }

            if (Common.MaBV == "01071")
            {
                if (CommonHelper.isWeekend(thoigiantaoCK) || FormatHelper.isNgoaiGioHanhChinh(thoigiantaoCK))
                    ngoaigio = true;
            }
            string mackham_ck = ChuyenKhoaProvider.GetMaCongKham_ChuyenKhoa(_mack);
            var ckham2 = (from nhom in DaTaContext.NhomDVs.Where(p => p.TenNhomCT.Contains("Khám bệnh"))
                          join dvu in DaTaContext.DichVus.Where(p => p.PLoai == 2 && p.Status == 1 && p.Loai == _idDTBN) on nhom.IDNhom equals dvu.IDNhom
                          select new { dvu.MaKPsd, dvu.DonGia, dvu.DonGia2, dvu.DonGiaDV2, dvu.DonGiaBHYT, dvu.MaDV, dvu.DonVi, dvu.TrongDM, dvu.MaQD }).OrderByDescending(p => p.DonGia).ToList();

            #region xác định có khai báo công khám theo chuyên khoa
            List<string> lck = new List<string>();
            for (int i = 1; i < 18; i++)
            {
                lck.Add(i.ToString("D2") + ".1895");
                lck.Add(i.ToString("D2") + ".1896");
                lck.Add(i.ToString("D2") + ".1897");
                lck.Add(i.ToString("D2") + ".1898");
                lck.Add(i.ToString("D2") + ".1899");

            }
            var qCheckChuyenKhoa = ckham2.Where(p => lck.Contains(p.MaQD)).ToList();
            bool boolTheoChuyenKhoa = false;
            if (qCheckChuyenKhoa.Count > 0)
                boolTheoChuyenKhoa = true;
            #endregion
            var ckham = (from dv in ckham2
                         where (dv.MaKPsd != null && dv.MaKPsd.Contains(_makpsd))
                         select new { dv.DonGia, dv.DonGiaBHYT, dv.DonGia2, dv.DonGiaDV2, dv.MaDV, dv.DonVi, dv.TrongDM, dv.MaQD }).OrderByDescending(p => p.DonGia).ToList();
            if (bnhan != null)
            {
                if (Common.MaBV == "01071")
                {

                    if (bnhan != null && dtbn != 1)
                    {
                        if (bnhan.CapCuu == 1)// nếu bệnh nhân cấp cứu (bệnh nhân dịch vụ lấy công khám theo chuyên khoa cấp cứu)
                            mackham_ck = ChuyenKhoaProvider.GetMaCongKham_ChuyenKhoa(47);
                        else if (ngoaigio) // nếu là bệnh nhân ngoài giờ (đang áp dụng cho bv 01071 )
                        {
                            mackham_ck = _idDTBN + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)] + ".NG";
                        }

                    }
                }
                if (dtbn != 1 && !boolTheoChuyenKhoa && !ngoaigio && (bnhan.CapCuu != 1 || Common.MaBV == "01017"))
                    mackham_ck = _idDTBN.ToString() + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];

                //bn dịch vụ đã thiết lập công khám theo chuyên khoa khám thì lấy theo mã đó, còn nếu không lấy theo mã dv chung
                if (dtbn != 1 && ckham.Where(p => p.MaQD == mackham_ck).Count() == 0)
                    mackham_ck = _idDTBN.ToString() + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];

            }

            var qkq = ckham.Where(p => p.MaQD == mackham_ck).FirstOrDefault();
            if (qkq != null)
                maDV = qkq.MaDV;
            return maDV;
        }

        public static bool Update_Delete_CongKham(int _maBN, int idkb, bool update, DateTime ngaychidinh)
        {
            int _idDTBN = -1;
            int _madvCK = -1;
            int maxid = -1;
            double _tyleTT = 1, _Dongia = 0;
            string BNBHYT = "";
            string _makpsd = ";";
            int _makp = 0;
            bool ngoaigio = false;

            bool landenkham = false; //kiểm tra bệnh nhân đến khám lần thứ mấy trong ngày : false: lần đầu tiên; true: các lần sau
            Hospital DaTaContext = new Hospital();
            #region kiểm tra lần đến khám
            var qbenhnhan = DaTaContext.BenhNhans.Single(p => p.MaBNhan == _maBN);
            DateTime tungaykham = FormatHelper.BeginDate(qbenhnhan.NNhap.Value);
            DateTime denngaykham = FormatHelper.EndDate(qbenhnhan.NNhap.Value);
            var bndakham = DaTaContext.BenhNhans.Where(p => qbenhnhan.IDPerson > 0 && p.IDPerson == qbenhnhan.IDPerson && p.NNhap >= tungaykham && p.NNhap <= denngaykham).ToList();
            if (bndakham.Count > 1)
                landenkham = true;
            else
                landenkham = false;
            #endregion
            var bnhan = DaTaContext.BenhNhans.Where(p => p.MaBNhan == _maBN).FirstOrDefault();
            int _mack = -1;
            int dtbn = -1;
            if (bnhan != null)
            {
                _idDTBN = bnhan.IDDTBN;
                if (_makp == 0)
                    _makp = bnhan.MaKP ?? 0;
                _makpsd = ";" + bnhan.MaKP + ";";
                var qchuyenkhoa = (from kp in DaTaContext.KPhongs.Where(p => p.MaKP == _makp) select kp).FirstOrDefault();
                if (qchuyenkhoa != null)
                    _mack = qchuyenkhoa.MaCK;//?? 0;

                dtbn = DaTaContext.DTBNs.Where(p => p.IDDTBN == _idDTBN).Select(p => p.HTTT).FirstOrDefault();
            }

            var bnkbT = DaTaContext.BNKBs.Where(p => p.MaBNhan == _maBN).ToList();
            var bnkb = bnkbT.Where(p => p.IDKB == idkb).ToList();
            if (bnkb.Count > 0)
            {
                _mack = bnkb.First().MaCK;
                _makpsd = ";" + bnkb.First().MaKP + ";";
                _makp = bnkb.First().MaKP == null ? 0 : bnkb.First().MaKP.Value;
                if (Common.MaBV == "01071")
                {
                    if (CommonHelper.isWeekend(bnkb.First().NgayKham.Value) || FormatHelper.isNgoaiGioHanhChinh(bnkb.First().NgayKham.Value))
                        ngoaigio = true;
                }
            }
            else if (bnhan != null)
            {
                if (Common.MaBV == "01071")
                {
                    if (CommonHelper.isWeekend(bnhan.NNhap.Value) || FormatHelper.isNgoaiGioHanhChinh(bnhan.NNhap.Value))
                        ngoaigio = true;
                }
            }


            string mackham_ck = ChuyenKhoaProvider.GetMaCongKham_ChuyenKhoa(_mack);




            var ckham2 = (from nhom in DaTaContext.NhomDVs.Where(p => p.TenNhomCT.Contains("Khám bệnh"))
                          join dvu in DaTaContext.DichVus.Where(p => p.PLoai == 2 && p.Status == 1 && p.Loai == _idDTBN) on nhom.IDNhom equals dvu.IDNhom
                          select new { dvu.MaKPsd, dvu.DonGia, dvu.DonGia2, dvu.DonGiaDV2, dvu.DonGiaBHYT, dvu.MaDV, dvu.DonVi, dvu.TrongDM, dvu.MaQD }).OrderByDescending(p => p.DonGia).ToList();

            #region xác định có khai báo công khám theo chuyên khoa
            List<string> lck = new List<string>();
            for (int i = 1; i < 18; i++)
            {
                lck.Add(i.ToString("D2") + ".1895");
                lck.Add(i.ToString("D2") + ".1896");
                lck.Add(i.ToString("D2") + ".1897");
                lck.Add(i.ToString("D2") + ".1898");
                lck.Add(i.ToString("D2") + ".1899");

            }
            var qCheckChuyenKhoa = ckham2.Where(p => lck.Contains(p.MaQD)).ToList();
            bool boolTheoChuyenKhoa = false;
            if (qCheckChuyenKhoa.Count > 0)
                boolTheoChuyenKhoa = true;
            #endregion
            var ckham = (from dv in ckham2
                         where (dv.MaKPsd != null && dv.MaKPsd.Contains(_makpsd))
                         select new { dv.DonGia, dv.DonGiaBHYT, dv.DonGia2, dv.DonGiaDV2, dv.MaDV, dv.DonVi, dv.TrongDM, dv.MaQD }).OrderByDescending(p => p.DonGia).ToList();
            if (bnhan != null)
            {

                BNBHYT = bnhan.DTuong;
                if (Common.MaBV == "01071")
                {

                    if (bnhan != null && dtbn != 1)
                    {
                        if (bnhan.CapCuu == 1)// nếu bệnh nhân cấp cứu (bệnh nhân dịch vụ lấy công khám theo chuyên khoa cấp cứu)
                            mackham_ck = ChuyenKhoaProvider.GetMaCongKham_ChuyenKhoa(47);
                        else if (ngoaigio) // nếu là bệnh nhân ngoài giờ (đang áp dụng cho bv 01071 )
                        {
                            mackham_ck = _idDTBN + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)] + ".NG";
                        }
                    }
                }
                if (dtbn != 1 && !boolTheoChuyenKhoa && !ngoaigio && (bnhan.CapCuu != 1 || Common.MaBV == "01017"))
                    mackham_ck = _idDTBN.ToString() + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];

                //bn dịch vụ đã thiết lập công khám theo chuyên khoa khám thì lấy theo mã đó, còn nếu không lấy theo mã dv chung
                if (dtbn != 1 && ckham.Where(p => p.MaQD == mackham_ck).Count() == 0)
                    mackham_ck = _idDTBN.ToString() + "." + Common.mack_theoHangBV[BenhvienProvider.GetHangBVCK(Common.MaBV)];

            }

            List<int> _lmack = new List<int>();
            foreach (var i in ckham)
            {
                _lmack.Add(i.MaDV);
            }
            bool kttontaick = false;
            bool giacu = PriceProvider.GetGiaCu(_maBN, -1, ngaychidinh);
            if (landenkham)
            {
                _tyleTT = 0.3;
            }

            #region tính công khám bệnh nhân
            foreach (var item in ckham)
            {
                if (item.MaQD == mackham_ck)
                {
                    kttontaick = true;
                    _madvCK = item.MaDV;

                    //   _Dongia = item.TrongDM == 1 ? (giacu ? item.DonGia : item.DonGiaBHYT) : (giacu ? item.DonGia : item.DonGiaDV2);


                    _Dongia = (lck.Contains(item.MaQD) && bnhan.DTuong == "BHYT") ? (giacu ? item.DonGia : item.DonGiaBHYT) : (giacu ? item.DonGia2.Value : item.DonGiaDV2);

                    var kt = DaTaContext.DThuocs.Where(p => p.PLDV == 2).Where(p => p.MaBNhan == _maBN).ToList();
                    var ktck2 = (from dt in DaTaContext.DThuocs.Where(p => p.MaBNhan == _maBN)
                                 join dtct1 in DaTaContext.DThuoccts on dt.IDDon equals dtct1.IDDon
                                 select dtct1).ToList();

                    var ktck = (from dt in ktck2
                                join b in _lmack on dt.MaDV equals b
                                select dt).ToList();
                    if (update) // thêm công khám
                    {
                        // kiểm tra công khám có chuyên khoa rồi thì không thêm
                        var ktckhoa = bnkbT.Where(p => p.MaCK == _mack).ToList();
                        if (ktckhoa.Count > 1)
                            continue;
                        //
                        // kiểm tra kp lâm sàng không thêm công khám
                        var ktpl = DaTaContext.KPhongs.Where(p => p.PLoai == "Lâm sàng" && p.MaKP == _makp).ToList();
                        if (ktpl.Count > 0)
                            continue;

                        // kiểm tra tiền công khám đã thu trực tiếp
                        var kttu = (from tu in DaTaContext.TamUngs
                                    join tuuct in DaTaContext.TamUngcts on tu.IDTamUng equals tuuct.IDTamUng
                                    where tu.MaBNhan == _maBN && tuuct.MaDV == _madvCK
                                    select tu).ToList();
                        if (kt.Count <= 0)
                        {
                            DThuoc dthuoccd = new DThuoc();
                            if (bnkb.Count > 0 && bnkb.First().NgayKham != null)
                                dthuoccd.NgayKe = bnkb.First().NgayKham;
                            else
                                dthuoccd.NgayKe = bnhan.NNhap;
                            dthuoccd.MaBNhan = _maBN;
                            dthuoccd.KieuDon = -1;
                            dthuoccd.PLDV = 2;
                            if (bnkb.Count > 0 && bnkb.First().MaCB != null)
                                dthuoccd.MaCB = bnkb.First().MaCB;
                            if (bnkb.Count > 0 && bnkb.First().MaKP != null)
                                dthuoccd.MaKP = bnkb.First().MaKP;
                            else
                                dthuoccd.MaKP = _makp;

                            DaTaContext.DThuocs.Add(dthuoccd);
                            if (DaTaContext.SaveChanges() == 1)
                            {
                                maxid = DaTaContext.DThuocs.Where(p => p.MaBNhan == _maBN).ToList().Max(p => p.IDDon);
                            }
                        }
                        else
                        {

                            if (ktck.Count <= 0)
                                maxid = kt.First().IDDon;
                            else
                            {
                                maxid = kt.First().IDDon;
                                if (ktck.Count < 4)
                                    _tyleTT = 0.3;
                                else
                                    if (ktck.Count == 4)
                                    _tyleTT = 0.1;
                                else
                                    _tyleTT = 0;
                            }
                        }
                        if (_tyleTT > 0 && (_tyleTT == 1 || (_tyleTT < 1 && BNBHYT == "BHYT")))
                        {
                            DThuocct dtct = new DThuocct();
                            dtct.MaKP = _makp;
                            dtct.IDDon = maxid;
                            dtct.IDKB = idkb;
                            dtct.MaDV = item.MaDV;
                            dtct.SoLuong = 1;
                            if (bnkb.Count > 0 && bnkb.First().NgayKham != null)
                                dtct.NgayNhap = bnkb.First().NgayKham;
                            else
                                dtct.NgayNhap = bnhan.NNhap;
                            dtct.DonVi = item.DonVi;
                            dtct.DonGia = _Dongia;
                            dtct.ThanhTien = _Dongia * _tyleTT;
                            dtct.TrongBH = (lck.Contains(item.MaQD) && dtbn == 1) ? 1 : 0; //item.TrongDM == null ? 0 : item.TrongDM.Value;
                            if (kttu.Count > 0)
                                dtct.ThanhToan = 1;
                            dtct.TyLeTT = _tyleTT * 100;
                            DaTaContext.DThuoccts.Add(dtct);
                            DaTaContext.SaveChanges();
                            return true;
                        }
                    }
                    else
                    { // xóa công khám
                        if (ktck.Count > 0)
                        {
                            List<DThuocct> _lxoa = (from dt in DaTaContext.DThuocs.Where(p => p.MaBNhan == _maBN)
                                                    join dtct1 in DaTaContext.DThuoccts.Where(p => p.MaDV == _madvCK && p.IDKB == idkb) on dt.IDDon equals dtct1.IDDon
                                                    select dtct1).ToList();
                            foreach (var a in _lxoa)
                            {
                                DaTaContext.DThuoccts.Remove(a);
                                DaTaContext.SaveChanges();
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            if (kttontaick == false)
            {
                if (ckham2.Where(p => p.MaQD == mackham_ck).ToList().Count > 0)
                    MessageBox.Show("Công khám trong danh mục có mã QĐ: " + mackham_ck + " chưa được chọn sử dụng cho phòng khám của bạn");
                else
                    MessageBox.Show("Bạn chưa thiết lập dịch vụ tiền công khám trong danh mục có mã QĐ: " + mackham_ck);
            }
            return false;
        }
    }
}
