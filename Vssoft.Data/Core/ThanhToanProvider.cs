using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vssoft.Data.Extension;
using Vssoft.Data.Extension.Class;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class ThanhToanProvider
    {
        public static int GetPhanTramThanhToan(Hospital data, string muc)
        {
            int PT = 0;
            var q = data.MucTTs.Where(p => p.MaMuc == muc).ToList();
            if (q.Count > 0)
            {
                PT = int.Parse(q.First().PTTT.ToString());
            }
            return PT;
        }
        public static bool isThanhToan(Hospital data, int mabnhan)
        {
            var q = data.VienPhis.Where(p => p.MaBNhan == mabnhan).ToList();
            if (q.Count > 0)
                return true;
            return false;
        }

        public static bool ThanhToan_VTYT_TT04(int iddonct, double dongia)
        {
            Hospital _data = new Hospital();
            var vpctord = _data.VienPhicts.Where(p => p.idVPhict == iddonct).FirstOrDefault();
            if (vpctord == null)
                return false;
            VienPhict vpct = new VienPhict();

            vpct.NgayChiPhi = vpctord.NgayChiPhi;
            vpct.TyLeTT = 100;
            vpct.MaKP = vpctord.MaKP;
            vpct.MaDV = vpctord.MaDV;
            vpct.DonGia = dongia;
            vpct.ThanhTien = vpctord.SoLuong * dongia;
            vpct.SoLuong = vpctord.SoLuong;
            vpct.SoLuongD = 0;
            vpct.TienChenh = 0;
            vpct.TienChenhBN = 0;
            vpct.DonVi = vpctord.DonVi;
            vpct.idVPhi = vpctord.idVPhi;
            vpct.ThanhToan = vpctord.ThanhToan;
            vpct.Mien = vpctord.Mien;
            vpct.XHH = vpctord.XHH;
            vpct.TienBN = vpctord.SoLuong * dongia;
            vpct.TienBH = 0;
            vpct.TrongBH = 0;
            vpct.TyLeBHTT = 0;
            vpct.TyLeTT = 0;
            _data.VienPhicts.Add(vpct);
            _data.SaveChanges();
            return true;
        }


        public static bool SetThanhToan(Hospital _dataContext, int _mabn, DateTime dtNgayTT, int _makptt)
        {
            //try
            //{
            int _HTTT = -1;
            string _muc = "";
            double _tienBH = 0;
            int _pttt = 0;
            int _tuyen = 1;
            int idvp = 0;
            string _DTuong = "";
            int _HangBV = 3;
            bool ttoan = true;
            bool _ktraBNDieuTri = true;
            List<RaVien> ravien = new List<RaVien>();
            var bn = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).ToList();
            ravien = _dataContext.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
            var kttt = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).ToList();
            var kt = (from ds in _dataContext.DThuocs.Where(p => p.MaBNhan == _mabn).OrderBy(p => p.IDDon) select ds).ToList();

            #region TH bệnh nhân vào viện nhưng không có phát sinh chi phí trong khoa
            _ktraBNDieuTri = BenhNhanProvider.KiemtraBenhnhanNoiNgoaitru(_mabn);
            if (!_ktraBNDieuTri)
            {
                DialogResult _result = DialogResult.No;
                _result = MessageBox.Show("Bệnh nhân " + bn.First().TenBNhan + " đã vào viện nhưng chưa có phát sinh chi phí trong khoa, bạn muốn cập nhật lại bệnh nhân thành khám bệnh ngoại trú ?", "Cập nhật bệnh nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_result == DialogResult.Yes)
                {
                    #region cập nhật lại thành bệnh nhân ngoại trú
                    var qkb = (from kb in _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn)
                               join kp in _dataContext.KPhongs.Where(p => p.PLoai == KhoaPhongPL.PhongKham) on kb.MaKP equals kp.MaKP
                               select kb).OrderByDescending(p => p.IDKB).FirstOrDefault();
                    foreach (var a in bn)
                    {
                        a.NoiTru = 0;
                        if (qkb != null)
                            a.MaKP = qkb.MaKP;
                    }
                    // xóa vào viện
                    var qvv = _dataContext.VaoViens.Where(p => p.MaBNhan == _mabn).ToList();
                    foreach (var a in qvv)
                    {
                        _dataContext.VaoViens.Remove(a);
                    }
                    // xóa BNKB

                    var qkbNT = (from kb in _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn)
                                 join kp in _dataContext.KPhongs.Where(p => p.PLoai == KhoaPhongPL.LamSang) on kb.MaKP equals kp.MaKP
                                 select kb).ToList();
                    foreach (var a in qkbNT)
                    {
                        _dataContext.BNKBs.Remove(a);
                    }

                    _dataContext.SaveChanges();

                    // cập nhật lại mã kp điều trị trong bảng BNKB
                    var qBNKBConLai = (from kb in _dataContext.BNKBs.Where(p => p.MaBNhan == _mabn)
                                       join kp in _dataContext.KPhongs on kb.MaKP equals kp.MaKP
                                       select kb).ToList();
                    foreach (var a in qBNKBConLai)
                    {
                        a.MaKPdt = a.MaKP;
                        if (a.PhuongAn == 1)
                            a.PhuongAn = 0;
                    }

                    _dataContext.SaveChanges();


                    //? new Hospital ?
                    #endregion
                }
                else
                    return false;
            }
            #endregion



            if (CommonHelper.isKhoaDuLieu(_dataContext, dtNgayTT, "KhoaVP"))
            {
                return false;
            }
            if (KhamBenhProvider.KiemTraCongKham_NgayGiuong(_dataContext, _mabn) == true)
            {
                return false;
            }
            if (_mabn <= 0)
            {
                return false;
            }
            int _tyle = 0;
            string tencd = "";
            tencd = KhamBenhProvider.KiemTraDichVuChiDinh(_dataContext, _mabn);
            if (!string.IsNullOrEmpty(tencd))
            {
                bool _TToan_chuaTHien = true; // trạng thái thực hiện cận lâm sàng
                if (Common.MaBV == "30002" || Common.MaBV == "01071")
                {
                    _TToan_chuaTHien = false;
                }
                if (_TToan_chuaTHien)
                {
                    DialogResult _result = MessageBox.Show("Bệnh nhân có các chỉ định CLS chưa được thực hiện:\n " + tencd + "Bạn vẫn muốn thanh toán?", "Hỏi thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_result == DialogResult.No)
                        return false;
                }
                else
                {
                    MessageBox.Show("Bệnh nhân có các chỉ định CLS chưa được thực hiện:\n " + tencd + "Bạn không thể thanh toán?", "Hỏi thanh toán");
                    return false;
                }
            }
            if (ttoan)
            {
                if (BenhNhanProvider.KiemTraBenhNhanKhamBenhTrongNgay(_dataContext, _mabn, dtNgayTT))
                {
                    DialogResult _result = MessageBox.Show("Bệnh nhân đã thanh toán trong ngày: \n " + dtNgayTT.Date + "Bạn vẫn muốn thanh toán?", "Hỏi thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_result == DialogResult.No)
                        ttoan = false;
                }
                else if (Common.MaBV == "27183" && !BenhNhanProvider.isDone(_dataContext, _mabn))
                {
                    DialogResult _result = MessageBox.Show("Bệnh nhân chưa kết thúc khám, Bạn không thể thanh toán", "Thông báo");

                    ttoan = false;
                }
            }


            if (kt.Count == 0)
            {
                MessageBox.Show("Bệnh nhân chưa phát sinh chi phí");
                ttoan = false;
            }
            else if (FormatHelper.BeginDate(dtNgayTT) < FormatHelper.BeginDate(kt.First().NgayKe.Value))
            {
                MessageBox.Show("Ngày thanh toán không được < ngày kê đơn");
                ttoan = false;
            }

            if (bn.Count > 0)
                _DTuong = bn.First().DTuong;
            if (string.IsNullOrEmpty(ICDProvider.getMaICDarr(_dataContext, _mabn, Common.GetICD)[0]) && _DTuong == "BHYT")
            {
                if (Common.MaBV == "30012" || Common.MaBV == "01830")
                {
                    MessageBox.Show("Bệnh nhân chưa có mã ICD tại phòng khám có MaKP là:" + ICDProvider.getMaICDarr(_dataContext, _mabn, Common.GetICD)[2] + " bạn không thể thanh toán");
                    ttoan = false;
                }
                else
                {
                    DialogResult _result = MessageBox.Show("Bệnh nhân chưa có mã ICD tại phòng khám có MaKP là:" + ICDProvider.getMaICDarr(_dataContext, _mabn, Common.GetICD)[2] + "\n Bạn vẫn muốn thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_result == DialogResult.No)
                        ttoan = false;
                }

            }
            if (!ttoan)
                return false;
            if (Common.MaBV == "30002")
            {
                string dsdon = "";  //FormNhap.frm_Ravien.CheckDonChuaLinh(_mabn);
                if (!string.IsNullOrEmpty(dsdon))
                {
                    DialogResult _result = MessageBox.Show("Bệnh nhân có các đơn thuốc chưa lĩnh :\n " + dsdon + "Bạn vẫn muốn Thanh toán cho bệnh nhân?", "Hỏi ra viện", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_result == DialogResult.No)
                        return false;
                }
            }
            int _dtkham = -1;


            int ktntru = -1;
            if (bn.Count > 0)
            {
                ktntru = bn.First().NoiTru.Value;
                _dtkham = bn.First().IDDTBN;
                var dt = _dataContext.DTBNs.Where(p => p.IDDTBN == _dtkham).Select(p => p.HTTT).ToList();
                if (dt.Count > 0)
                {
                    _HTTT = dt.First();
                }
            }

            if (ktntru > 0)
            {

                if (ravien.Count <= 0)
                {
                    MessageBox.Show("Bệnh nhân chưa làm thủ tục ra viện, Bạn không thể thanh toán");
                    return false;
                }
                else
                {
                    if (Common.MaBV == "30005")
                    {
                        double songaygiuong = 4111111;// FormNhap.frm_Ravien._getSoNgayGiuong(_dataContext, _mabn);
                        int songaydt = ravien.First().SoNgaydt.Value;
                        int chenh = Convert.ToInt32(songaygiuong) - songaydt;
                        if (chenh != 0)
                        {
                            if (MessageBox.Show("Số ngày giường: " + songaygiuong + "không khớp số ngày điều trị: " + songaydt + "\n Bạn vẫn muốn thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return false;
                        }
                    }

                }
            }
            else
            {
                if (dtNgayTT > DateTime.Now)
                {
                    MessageBox.Show("Ngày giờ thanh toán phải{0} <= ngày giờ hiện tại");
                    return false;
                }
                if (ravien.Count <= 0)
                {
                    if (bn.First().DTNT)
                    {
                        MessageBox.Show("Bệnh nhân chưa làm thủ tục ra viện, Bạn không thể thanh toán");
                        return false;
                    }
                    else
                    {
                        if (RaVienProvider.LuuVaXoaRaVienCu(_dataContext, _mabn, dtNgayTT.AddMinutes(-1), "Luu", 2) == false)
                            return false;
                    }
                }
            }
            if (ravien.Count > 0 && ravien.First().NgayRa != null && dtNgayTT != null)
            {
                if ((dtNgayTT < ravien.First().NgayRa.Value))
                {
                    MessageBox.Show("ngày giờ thanh toán không hợp lệ! \n ngày TT: " + dtNgayTT.ToLongDateString() + "ngày ra viện " + ravien.First().NgayRa.Value.ToLongDateString());
                    return false;
                }
            }
            #region update MKP

            if (ravien.Count > 0)
            {
                var qvphi = (from vp in _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn)
                             join vpct in _dataContext.VienPhicts.Where(p => p.MaKP == null || p.MaKP <= 0) on vp.idVPhi equals vpct.idVPhi
                             select vpct).ToList();
                foreach (var item in qvphi)
                {

                    VienPhict vpct = _dataContext.VienPhicts.Single(p => p.idVPhict == item.idVPhict);
                    vpct.MaKP = ravien.First().MaKP;
                }
            }
            #endregion
            if (ttoan)
            {
                _dataContext = new Hospital();

                ravien = _dataContext.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
                string _dtuong = "";
                int _vanchuyen = -1;//9
                double _tienvc = 0;
                // bxung mới
                decimal _luongCS = 0;
                string _khuvuc = "";
                int noitru = 0;
                string _sothe = "";
                if (bn.Count > 0)
                {

                    // update trongDM =2 | trongDM =1 =>0 đối với bệnh nhân dịch vụ
                    // áp dụng BV Thanh Hà
                    if (Common.MaBV == "30009")
                        DonThuocProvider.CapNhatTrongBHForBenhNhan(_dataContext, _mabn);
                    //
                    if (bn.First().SThe != null)
                        _sothe = bn.First().SThe;
                    if (bn.First().LuongCS != null)
                        _luongCS = bn.First().LuongCS.Value;
                    if (bn.First().KhuVuc != null)
                    {
                        if (bn.First().KhuVuc.ToString().Contains("K"))
                            _khuvuc = bn.First().KhuVuc;

                    }
                    if (bn.First().MucHuong != null && bn.First().MucHuong.Value > 0)
                    {
                        _muc = bn.First().MucHuong.ToString();
                        //MessageBox.Show(_muc.ToString());
                        _pttt = ThanhToanProvider.GetPhanTramThanhToan(_dataContext, _muc);
                    }
                    if (bn.First().Tuyen != null)
                        _tuyen = bn.First().Tuyen.Value;
                    noitru = bn.First().NoiTru.Value;
                }
                //

                if (!string.IsNullOrEmpty(_sothe) && _sothe.Length > 2)
                    _dtuong = _sothe.Substring(2, 1);// 9
                var ktvc = _dataContext.MucTTs.Where(p => p.MaMuc.Contains(_dtuong)).Select(p => p.VanChuyen).ToList();
                if (ktvc.Count > 0)
                    if (ktvc.First() != null && ktvc.First().ToString() != "")
                        _vanchuyen = ktvc.First().Value;


                _HangBV = BenhvienProvider.GetHangBenhVien(Common.MaBV);
                switch (_HangBV)
                {
                    case 1:
                        if (noitru == 0)
                            _tyle = 0;
                        else
                            _tyle = 40;
                        break;
                    case 2:
                        if (Common.MaBV == "01830")// dinhpv yêu cầu
                            _tyle = 70;
                        else
                        {
                            if (noitru == 0)
                                _tyle = 0;
                            else
                                _tyle = 60;
                        }
                        break;
                    case 3:

                        _tyle = 70;
                        break;
                    case 4:
                        _tyle = 100;
                        _pttt = 100;
                        break;
                }

                if (kttt.Count <= 0)
                {
                    //bool vtyt = false;
                    int _maCK = 0;
                    var dsnhomdv = (from dv in _dataContext.DichVus
                                    join tnhom in _dataContext.TieuNhomDVs on dv.IdTieuNhom equals tnhom.IdTieuNhom
                                    join nhom in _dataContext.NhomDVs on tnhom.IDNhom equals nhom.IDNhom
                                    select new { dv.GiaBHGioiHanTT, dv.MaDV, nhom.IDNhom, nhom.TenNhomCT, dv.PLoai, dv.Loai, dv.Status, dv.DonGia, dv.DonVi, dv.TrongDM }).ToList();

                    var ck = (from nhom in dsnhomdv.Where(p => p.TenNhomCT.Contains("Khám bệnh")).Where(p => p.PLoai == 2 && p.Loai == _dtkham).Where(p => p.Status == 1)
                              select new { nhom.DonGia, nhom.MaDV, nhom.DonVi, nhom.TrongDM }).OrderByDescending(p => p.DonGia).ToList();
                    if (ck.Count > 0)
                        _maCK = ck.First().MaDV;

                    if (kt.Count > 0)
                    {
                        bool thanhtoan = true;


                        if (thanhtoan && ktntru > 0)
                        {

                            if (ravien.Count > 0 && FormatHelper.BeginDate(dtNgayTT) < FormatHelper.BeginDate(ravien.First().NgayRa.Value))
                            {
                                MessageBox.Show("Ngày thanh toán không được < ngày ra viện");
                                thanhtoan = false;
                            }
                        }
                        bool _tachCP_Thu = false;
                        if (Common.MaBV == "30007" || Common.MaBV == "30010")
                            _tachCP_Thu = true;
                        if (thanhtoan)
                        {
                            bool _tachKP = false;
                            if (Common.MaBV == "30007")
                                _tachKP = true;
                            int _makpsd = 0;
                            if (ravien.Count > 0)
                                _makpsd = ravien.First().MaKP == null ? 0 : ravien.First().MaKP.Value;
                            if (_makpsd == 0)
                            {
                                MessageBox.Show("không tồn tại khoa phòng trong ra viện");
                                return false;

                            }
                            var mavanchuyen = (from dv in dsnhomdv.Where(p => p.TenNhomCT.Contains("Vận chuyển"))
                                               select dv.MaDV).ToList();
                            if (ktntru > 0)
                            {
                                #region nội trú
                                var tong = (from kd in _dataContext.DThuocs
                                            join kdct in _dataContext.DThuoccts.OrderBy(p => p.IDDonct) on kd.IDDon equals kdct.IDDon
                                            join dv in _dataContext.DichVus on kdct.MaDV equals dv.MaDV
                                            where (kd.MaBNhan == _mabn)
                                            group new { kdct, dv, kd } by new { KieuDon = kd.KieuDon == 6 ? kd.KieuDon : 1, kdct.NgayNhap, dv.TenDV, kdct.TyLeTT, kdct.LoaiDV, kdct.Mien, IDCD = _tachCP_Thu ? (kdct.ThanhToan == 1 ? kdct.IDCD : 0) : 0, MaKP = _tachKP ? (kdct.MaKPtk == null ? kdct.MaKP : kdct.MaKPtk) : _makpsd, kdct.MaDV, kdct.DonGia, kdct.DonVi, kdct.ThanhToan, kdct.TrongBH, kdct.XHH } into kq
                                            select new { kq.Key.KieuDon, kq.Key.NgayNhap, kq.Key.TenDV, kq.Key.TyLeTT, kq.Key.Mien, kq.Key.ThanhToan, kq.Key.IDCD, kq.Key.XHH, kq.Key.MaKP, kq.Key.LoaiDV, madv = kq.Key.MaDV, dongia = kq.Key.DonGia, donvi = kq.Key.DonVi, trongBH = kq.Key.TrongBH, soluong = kq.Sum(p => p.kdct.SoLuong), thanhtien = kq.Sum(p => p.kdct.ThanhTien) }).OrderBy(p => p.donvi).ToList();

                                var vienphi = (from kd in tong
                                               group kd by new { kd.KieuDon, kd.NgayNhap.Value.Date, kd.TenDV, kd.TyLeTT, kd.Mien, kd.IDCD, kd.MaKP, kd.madv, kd.dongia, kd.donvi, kd.ThanhToan, kd.trongBH, kd.XHH, kd.LoaiDV } into kq
                                               select new { kq.Key.KieuDon, NgayNhap = kq.Select(p => p.NgayNhap).Min(), kq.Key.TenDV, kq.Key.TyLeTT, kq.Key.Mien, kq.Key.ThanhToan, kq.Key.IDCD, kq.Key.XHH, kq.Key.LoaiDV, kq.Key.MaKP, madv = kq.Key.madv, dongia = kq.Key.dongia, donvi = kq.Key.donvi, trongBH = kq.Key.trongBH, soluong = kq.Sum(p => p.soluong), thanhtien = kq.Sum(p => p.thanhtien) }).OrderBy(p => p.donvi).ToList();

                                string chiphiKP = "";
                                foreach (var item in vienphi)
                                {
                                    //MessageBox.Show(Math.Round(89999.7, 0).ToString() + " _   " +  Math.Round(44999.85 * 2 * 100 * 0.01, 0) );
                                    double a = Math.Round(Math.Round(item.thanhtien, 2), 0);
                                    double ttien = (double)item.soluong * (double)item.dongia * (100 - item.Mien) * (double)item.TyLeTT * 0.0001;
                                    double b = Math.Round(Math.Round(ttien, 2), 0);

                                    if (a != b)
                                    {
                                        MessageBox.Show(item.TenDV + " Thành tiền không bằng số lượng * đơn giá * tỷ lệ TT - miễn");
                                        // _LuuXoaRaVien(_dataContext, _mabn, dtNgayTT.AddMinutes(-1), "Xoa", 2);
                                        return false;
                                    }
                                    if (item.MaKP == null || item.MaKP == 0)
                                    {
                                        chiphiKP += item.madv + ";";
                                    }
                                }
                                if (!string.IsNullOrEmpty(chiphiKP))
                                {
                                    MessageBox.Show("Các chi phí: " + chiphiKP + " chưa thuộc khoa| phòng điều trị nào!");
                                    return false;
                                }
                                foreach (var a in vienphi)
                                {
                                    // kiểm tra vận chuyển
                                    var ktmadv = (from dv in mavanchuyen.Where(p => p == a.madv)
                                                  select dv).ToList();
                                    if (ktmadv.Count > 0)
                                    {
                                        _tienvc = a.thanhtien;
                                        break;
                                    }
                                    //
                                }
                                //

                                VienPhi vp = new VienPhi();
                                vp.NgayNhap = DateTime.Now;
                                vp.MaBNhan = kt.First().MaBNhan;
                                vp.NgayTT = dtNgayTT;
                                vp.NgayRa = ravien.First().NgayRa;
                                // ngoai h
                                bool _ngoaih = false;
                                _ngoaih = FormatHelper.isNgoaiGioHanhChinh(dtNgayTT);
                                vp.NgoaiGio = 0;
                                if (_ngoaih == true)
                                {
                                    if (MessageBox.Show("BN TT ngoài giờ hành chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        vp.NgoaiGio = 1;
                                }
                                //
                                //if (lupNguoiTT.EditValue != null && lupNguoiTT.EditValue.ToString() != "")
                                //    vp.MaCB = lupNguoiTT.EditValue.ToString();
                                //else
                                vp.MaCB = Common.MaCB;
                                if (_makptt != null)
                                    vp.MaKP = _makptt;
                                else
                                    vp.MaKP = Common.MaKP;
                                vp.Duyet = 0;
                                _dataContext.VienPhis.Add(vp);
                                if (_dataContext.SaveChanges() >= 1)
                                {
                                    BenhNhanProvider.SetStatus(_mabn, 3);
                                    var q = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).OrderByDescending(p => p.idVPhi).ToList();
                                    if (q.Count > 0)
                                    {
                                        idvp = q.First().idVPhi;
                                    }
                                    else
                                    {
                                        idvp = 0;
                                    }
                                    Hospital _data = new Hospital();

                                    double _tongtien = Math.Round(vienphi.Where(p => p.trongBH == 1).Sum(p => p.thanhtien), 2, MidpointRounding.AwayFromZero);//ktra
                                    if (idvp > 0)
                                    {

                                        foreach (var a in vienphi)
                                        {
                                            double tt = 0;
                                            if (a.soluong != 0)
                                            {
                                                VienPhict vpct = new VienPhict();
                                                if (_tachCP_Thu)
                                                {
                                                    if (a.madv == _maCK)
                                                    {
                                                        vpct.IDTamUng = a.IDCD;
                                                    }
                                                    else
                                                    {
                                                        var soph = _data.ChiDinhs.Where(p => p.IDCD == a.IDCD).Select(p => p.SoPhieu).ToList();
                                                        if (soph.Count > 0 && soph.First() != null)
                                                        {
                                                            vpct.IDTamUng = soph.First();
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                                //if(a.MaKP==null || a.MaKP<=0)
                                                //    // laays maKP ra vien
                                                //    else
                                                vpct.NgayChiPhi = a.NgayNhap == null ? dtNgayTT : a.NgayNhap.Value;
                                                if (a.TyLeTT == 0)
                                                    vpct.TyLeTT = 100;
                                                else
                                                    vpct.TyLeTT = a.TyLeTT;
                                                vpct.MaKP = a.MaKP;
                                                vpct.MaDV = a.madv;
                                                double giaVTYTTT = 0;
                                                double dongia = a.dongia;
                                                var kiemtraVTYT = dsnhomdv.Where(p => p.IDNhom == 10 || p.IDNhom == 11).Where(p => p.MaDV == a.madv && p.GiaBHGioiHanTT > 0).Select(p => p.GiaBHGioiHanTT).FirstOrDefault();
                                                if (kiemtraVTYT != null && kiemtraVTYT > 0)
                                                {
                                                    if (dongia > kiemtraVTYT)
                                                    {
                                                        giaVTYTTT = dongia - kiemtraVTYT;
                                                        dongia = kiemtraVTYT;
                                                    }
                                                }
                                                vpct.DonGia = dongia;
                                                tt = Math.Round((a.soluong * dongia) * (a.TyLeTT / 100), Common.LamTronSo);
                                                vpct.ThanhTien = tt;
                                                vpct.SoLuong = a.soluong;
                                                vpct.DonVi = a.donvi;
                                                vpct.SoLuongD = 0;
                                                vpct.TienChenh = 0;
                                                vpct.TienChenhBN = 0;
                                                vpct.ThanhToan = a.ThanhToan;
                                                vpct.idVPhi = idvp;
                                                vpct.Mien = a.Mien;
                                                vpct.XHH = a.XHH;
                                                vpct.LoaiDV = a.LoaiDV;


                                                // KT tiền vận chuyển
                                                var ktmadv = (from dv in mavanchuyen.Where(p => p == a.madv)
                                                              select dv).ToList();
                                                if (_HTTT == 1)//if (_DTuong == "BHYT")
                                                {
                                                    if (_tuyen == 1)//bệnh nhân đúng tuyến
                                                    {
                                                        if (a.trongBH == 1)
                                                        {//dịch vụ trong danh mục BHYT
                                                            if (ktmadv.Count > 0)
                                                            {

                                                                if (_vanchuyen == 1)
                                                                {
                                                                    vpct.TienBH = tt;
                                                                    vpct.TienBN = 0;
                                                                    vpct.TrongBH = 1;
                                                                    vpct.TyLeBHTT = 100;
                                                                }
                                                                else
                                                                {
                                                                    vpct.TienBN = tt;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TrongBH = 0;
                                                                    vpct.TyLeBHTT = 0;
                                                                }
                                                            }

                                                            //k thúc
                                                            else
                                                            {
                                                                if ((_tongtien - _tienvc) >= Common.GHanTT100 && _luongCS != 1)
                                                                {
                                                                    _tienBH = Math.Round(tt * _pttt / 100, Common.LamTronSo);
                                                                    vpct.TienBH = _tienBH;
                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                    vpct.TyLeBHTT = _pttt;
                                                                }
                                                                else
                                                                {
                                                                    vpct.TienBH = tt;
                                                                    vpct.TienBN = 0;
                                                                    vpct.TyLeBHTT = 100;
                                                                }
                                                                vpct.TrongBH = 1;
                                                            }


                                                        }
                                                        else
                                                        {
                                                            if (a.trongBH == 0)
                                                            {
                                                                vpct.TrongBH = 0;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                vpct.TyLeBHTT = 0;
                                                            }
                                                            else if (a.trongBH == 2)
                                                            {
                                                                vpct.TrongBH = 2;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = 0;
                                                                vpct.TyLeBHTT = 100;
                                                            }
                                                            else
                                                            {
                                                                vpct.TrongBH = 3;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = tt;
                                                                vpct.TyLeBHTT = 0;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (_tuyen == 2) //BN trái tuyến
                                                        {
                                                            if (a.trongBH == 1)
                                                            {//dịch vụ trong danh mục BHYT

                                                                if (ktmadv.Count > 0)
                                                                {

                                                                    if (_vanchuyen == 1)
                                                                    {
                                                                        vpct.TienBH = tt;
                                                                        vpct.TrongBH = 1;
                                                                        vpct.TyLeBHTT = 100;
                                                                    }
                                                                    else
                                                                    {
                                                                        vpct.TienBN = tt;
                                                                        vpct.TrongBH = 0;
                                                                        vpct.TyLeBHTT = 0;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    // mới
                                                                    if (!string.IsNullOrEmpty(_khuvuc)) // BN có khu vực ưu tiên tính theo đúng tuyến
                                                                    {
                                                                        if (_tyle > 0)
                                                                        {
                                                                            _tienBH = Math.Round(tt * _pttt / 100, Common.LamTronSo);
                                                                            vpct.TienBH = _tienBH;
                                                                            vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                            vpct.TyLeBHTT = _pttt;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                            vpct.TyLeBHTT = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //if ((_tongtien - _tienvc) < Common.GHanTT100 && Common.MaBV != "24009")// BN có tiền nhỏ hơn giới hạn thanh toán thì tính % trái tuyến theo hạng BV không nhân tỷ lệ
                                                                        //{
                                                                        //    _tienBH = Math.Round(tt * _tyle / 100, Common.LamTronSo);
                                                                        //    vpct.TyLeBHTT = _tyle;
                                                                        //    vpct.TienBH = _tienBH;
                                                                        //    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                        //}
                                                                        //else
                                                                        //{

                                                                        vpct.TyLeBHTT = (_tyle * _pttt) / 100;
                                                                        _tienBH = Math.Round(tt * _tyle / 100 * _pttt / 100, Common.LamTronSo);
                                                                        vpct.TienBH = _tienBH;
                                                                        vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                        //}

                                                                    }
                                                                    //
                                                                    if (_tyle > 0)
                                                                        vpct.TrongBH = 1;
                                                                    else
                                                                        vpct.TrongBH = 0;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                if (a.trongBH == 0)
                                                                {
                                                                    vpct.TrongBH = 0;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                    vpct.TyLeBHTT = 0;
                                                                }
                                                                else if (a.trongBH == 2)
                                                                {
                                                                    vpct.TrongBH = 2;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = 0;
                                                                    vpct.TyLeBHTT = 0;
                                                                }
                                                                else
                                                                {
                                                                    vpct.TrongBH = 3;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = tt;
                                                                    vpct.TyLeBHTT = 0;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (_HTTT == 2)//else
                                                {
                                                    if (a.trongBH == 2)
                                                    {
                                                        vpct.TrongBH = 2;
                                                        vpct.TienBH = 0;
                                                        vpct.TienBN = 0;
                                                        vpct.TyLeBHTT = 0;
                                                    }
                                                    else if (a.trongBH == 3)
                                                    {
                                                        vpct.TrongBH = 3;
                                                        vpct.TienBH = 0;
                                                        vpct.TienBN = tt;
                                                        vpct.TyLeBHTT = 0;
                                                    }
                                                    else
                                                    {
                                                        vpct.TyLeBHTT = 0;
                                                        vpct.TrongBH = 0;
                                                        vpct.TienBH = 0;
                                                        vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                    }
                                                }
                                                else if (_HTTT == 0)
                                                {
                                                    switch (a.trongBH)
                                                    {
                                                        case 1:
                                                            vpct.TrongBH = a.trongBH;
                                                            vpct.TienBH = tt;
                                                            vpct.TienBN = 0;
                                                            vpct.TyLeBHTT = 100;
                                                            break;
                                                        case 2:
                                                            vpct.TrongBH = a.trongBH;
                                                            vpct.TienBH = 0;
                                                            vpct.TienBN = 0;
                                                            vpct.TyLeBHTT = 0;
                                                            break;
                                                        case 0:
                                                            vpct.TrongBH = a.trongBH;
                                                            vpct.TienBH = 0;
                                                            vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                            vpct.TyLeBHTT = 0;
                                                            break;
                                                        case 3:
                                                            vpct.TrongBH = a.trongBH;
                                                            vpct.TienBH = 0;
                                                            vpct.TienBN = tt;
                                                            vpct.TyLeBHTT = 0;
                                                            break;
                                                    }
                                                }
                                                _data.VienPhicts.Add(vpct);
                                                _data.SaveChanges();
                                                if (giaVTYTTT > 0)
                                                    ThanhToan_VTYT_TT04(vpct.idVPhict, giaVTYTTT);
                                            }
                                        }

                                    }//kt
                                    else
                                    {
                                        MessageBox.Show("không có mã bệnh nhân trong bảng viện phí");
                                    }
                                    BenhNhanProvider.SetStatus(_mabn, 3);
                                }
                                #endregion
                                else
                                {
                                    #region ngoại trú

                                    var ktdt = _dataContext.DThuocs.Where(p => p.PLDV == 1).Where(p => p.MaBNhan == _mabn).ToList();
                                    if (ktdt.Count >= 2)
                                    {
                                        var tong1 = (from kd in _dataContext.DThuocs
                                                     join kdct in _dataContext.DThuoccts.OrderBy(p => p.IDDonct) on kd.IDDon equals kdct.IDDon
                                                     join dv in _dataContext.DichVus on kdct.MaDV equals dv.MaDV
                                                     where (kd.MaBNhan == _mabn)
                                                     select new { kdct.NgayNhap, kdct.LoaiDV, dv.TenDV, kdct.TyLeTT, kdct.Mien, kdct.ThanhToan, IDCD = _tachCP_Thu ? kdct.IDCD : 0, MaKP = _tachKP ? kdct.MaKP : _makpsd, kdct.MaDV, kdct.DonGia, kdct.DonVi, kdct.TrongBH, kdct.XHH, kdct.SoLuong, kdct.ThanhTien }
                                                      ).ToList();

                                        var vienphi1 = (from a in tong1
                                                        group a by new { a.LoaiDV, a.NgayNhap.Value.Date, a.TenDV, a.TyLeTT, a.Mien, a.ThanhToan, IDCD = a.IDCD, MaKP = a.MaKP, a.MaDV, a.DonGia, a.DonVi, a.TrongBH, a.XHH } into kq
                                                        select new { kq.Key.LoaiDV, NgayNhap = kq.Select(p => p.NgayNhap).Min(), kq.Key.TenDV, kq.Key.TyLeTT, kq.Key.Mien, kq.Key.ThanhToan, kq.Key.IDCD, kq.Key.MaKP, madv = kq.Key.MaDV, dongia = kq.Key.DonGia, donvi = kq.Key.DonVi, kq.Key.XHH, trongBH = kq.Key.TrongBH, soluong = kq.Sum(p => p.SoLuong), thanhtien = kq.Sum(p => p.ThanhTien) }).ToList();


                                        // kiểm tra vận chuyển
                                        foreach (var a in vienphi)
                                        {
                                            if (Math.Round(Math.Round(a.thanhtien, 2), 0) != Math.Round(Math.Round(a.soluong * a.dongia * a.TyLeTT * (100 - a.Mien) * 0.0001, 2), 0))
                                            {
                                                MessageBox.Show(a.TenDV + " Thành tiền không bằng số lượng * đơn giá * tỷ lệ tt  trừ miễn ");
                                                BenhNhan qbn = _dataContext.BenhNhans.Single(p => p.MaBNhan == _mabn);
                                                if (qbn.DTNT == false && qbn.NoiTru == 0)
                                                    RaVienProvider.LuuVaXoaRaVienCu(_dataContext, _mabn, dtNgayTT, "Luu", 2);
                                                return false;
                                            }
                                            var ktmadv = (from dv in mavanchuyen.Where(p => p == a.madv)
                                                          select dv).ToList();
                                            if (ktmadv.Count > 0)
                                            {
                                                _tienvc = a.thanhtien;
                                                break;
                                            }
                                        }
                                        //

                                        //kthuc luuw ra viên
                                        VienPhi vp1 = new VienPhi();
                                        vp1.MaBNhan = kt.First().MaBNhan;
                                        vp1.NgayTT = dtNgayTT;
                                        vp1.NgayRa = ravien.First().NgayRa;
                                        bool _ngoaih1 = false;
                                        _ngoaih1 = FormatHelper.isNgoaiGioHanhChinh(dtNgayTT);
                                        vp1.NgoaiGio = 0;
                                        if (_ngoaih1 == true)
                                        {
                                            if (MessageBox.Show("BN TT ngoài giờ hành chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                vp1.NgoaiGio = 1;
                                        }
                                        vp1.MaCB = Common.MaCB;
                                        vp1.MaKP = Common.MaKP;
                                        _dataContext.VienPhis.Add(vp1);
                                        if (_dataContext.SaveChanges() == 1)
                                        {
                                            BenhNhanProvider.SetStatus(_mabn, 3);
                                            var q = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).OrderByDescending(p => p.idVPhi).ToList();
                                            if (q.Count > 0)
                                            {
                                                idvp = q.First().idVPhi;
                                            }
                                            else
                                            {
                                                idvp = 0;
                                            }
                                            Hospital _data = new Hospital();
                                            double tt = 0;
                                            double _tongtien = Math.Round(vienphi.Where(p => p.trongBH == 1).Sum(p => p.thanhtien), 2, MidpointRounding.AwayFromZero);//ktra
                                            if (idvp > 0)
                                            {
                                                foreach (var a in vienphi)
                                                {
                                                    if (a.soluong != 0)
                                                    {
                                                        VienPhict vpct = new VienPhict();
                                                        if (_tachCP_Thu)
                                                        {
                                                            if (a.madv == _maCK)
                                                            {
                                                                vpct.IDTamUng = a.IDCD;
                                                            }
                                                            else
                                                            {
                                                                var soph = _data.ChiDinhs.Where(p => p.IDCD == a.IDCD).Select(p => p.SoPhieu).ToList();
                                                                if (soph.Count > 0 && soph.First() != null)
                                                                {
                                                                    vpct.IDTamUng = soph.First();
                                                                }
                                                                else
                                                                {

                                                                }
                                                            }
                                                        }
                                                        vpct.NgayChiPhi = a.NgayNhap == null ? dtNgayTT : a.NgayNhap.Value;
                                                        if (a.TyLeTT == 0)
                                                            vpct.TyLeTT = 100;
                                                        else
                                                            vpct.TyLeTT = a.TyLeTT;
                                                        vpct.Mien = a.Mien;
                                                        vpct.MaKP = a.MaKP;
                                                        vpct.MaDV = a.madv;
                                                        double giaVTYTTT = 0;
                                                        double dongia = a.dongia;
                                                        var kiemtraVTYT = dsnhomdv.Where(p => p.IDNhom == 10 || p.IDNhom == 11).Where(p => p.MaDV == a.madv && p.GiaBHGioiHanTT > 0).Select(p => p.GiaBHGioiHanTT).FirstOrDefault();
                                                        if (kiemtraVTYT != null && kiemtraVTYT > 0)
                                                        {
                                                            if (dongia > kiemtraVTYT)
                                                            {
                                                                giaVTYTTT = dongia - kiemtraVTYT;
                                                                dongia = kiemtraVTYT;
                                                            }
                                                        }
                                                        vpct.DonGia = dongia;
                                                        tt = Math.Round((a.soluong * dongia) * (a.TyLeTT / 100), Common.LamTronSo);
                                                        vpct.ThanhTien = tt;
                                                        vpct.SoLuong = a.soluong;
                                                        vpct.SoLuongD = 0;
                                                        vpct.TienChenh = 0;
                                                        vpct.TienChenhBN = 0;
                                                        vpct.DonVi = a.donvi;
                                                        vpct.idVPhi = idvp;
                                                        vpct.ThanhToan = a.ThanhToan;
                                                        vpct.Mien = a.Mien;
                                                        vpct.XHH = a.XHH;
                                                        vpct.LoaiDV = a.LoaiDV;

                                                        if (_HTTT == 1)//  if (_DTuong == "BHYT")
                                                        {
                                                            var ktmadv = (from dv in mavanchuyen.Where(p => p == a.madv)
                                                                          select dv).ToList();
                                                            if (_tuyen == 1)//bệnh nhân đúng tuyến
                                                            {
                                                                if (a.trongBH == 1)
                                                                {//dịch vụ trong danh mục BHYT
                                                                    if (ktmadv.Count > 0)
                                                                    {
                                                                        if (_vanchuyen == 1)
                                                                        {
                                                                            vpct.TienBH = tt;
                                                                            vpct.TienBN = 0;
                                                                            vpct.TrongBH = 1;
                                                                            vpct.TyLeBHTT = 100;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TienBN = tt;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TrongBH = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if ((_tongtien - _tienvc) >= Common.GHanTT100 && _luongCS != 1)
                                                                        {
                                                                            _tienBH = Math.Round(tt * _pttt / 100, Common.LamTronSo);
                                                                            vpct.TienBH = _tienBH;
                                                                            vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                            vpct.TyLeBHTT = _pttt;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TienBN = 0;
                                                                            vpct.TienBH = tt;
                                                                            vpct.TyLeBHTT = 100;
                                                                        }
                                                                        vpct.TrongBH = 1;
                                                                    }


                                                                }
                                                                else
                                                                {
                                                                    if (a.trongBH == 0)
                                                                    {
                                                                        vpct.TrongBH = 0;
                                                                        vpct.TienBH = 0;
                                                                        vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                        vpct.TyLeBHTT = 0;
                                                                    }
                                                                    else if (a.trongBH == 2)
                                                                    {
                                                                        vpct.TrongBH = 2;
                                                                        vpct.TienBH = 0;
                                                                        vpct.TienBN = 0;
                                                                        vpct.TyLeBHTT = 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        vpct.TrongBH = 3;
                                                                        vpct.TienBH = 0;
                                                                        vpct.TienBN = tt;
                                                                        vpct.TyLeBHTT = 0;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (_tuyen == 2) //BN trái tuyến
                                                                {
                                                                    if (a.trongBH == 1)
                                                                    {//dịch vụ trong danh mục BHYT
                                                                        if (ktmadv.Count > 0)
                                                                        {
                                                                            if (_vanchuyen == 1)
                                                                            {
                                                                                vpct.TienBH = tt;
                                                                                vpct.TrongBH = 1;
                                                                                vpct.TyLeBHTT = 100;
                                                                            }
                                                                            else
                                                                            {
                                                                                vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                                vpct.TrongBH = 0;
                                                                                vpct.TyLeBHTT = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            // mới
                                                                            if (!string.IsNullOrEmpty(_khuvuc)) // BN có khu vực ưu tiên tính theo đúng tuyến
                                                                            {
                                                                                if (_tyle > 0)
                                                                                {
                                                                                    vpct.TyLeBHTT = _pttt;
                                                                                    _tienBH = Math.Round(tt * _pttt / 100, Common.LamTronSo);
                                                                                    vpct.TienBH = _tienBH;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                                }
                                                                                else
                                                                                {
                                                                                    vpct.TyLeBHTT = 0;
                                                                                    vpct.TienBH = 0;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if ((_tongtien - _tienvc) < Common.GHanTT100)// BN có tiền nhỏ hơn giới hạn thanh toán thì tính % trái tuyến theo hạng BV không nhân tỷ lệ
                                                                                {
                                                                                    vpct.TyLeBHTT = _tyle;
                                                                                    _tienBH = Math.Round(tt * _tyle / 100, Common.LamTronSo);
                                                                                    vpct.TienBH = _tienBH;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;

                                                                                }
                                                                                else
                                                                                {
                                                                                    vpct.TyLeBHTT = (_tyle * _pttt) / 100;
                                                                                    _tienBH = Math.Round(tt * _tyle / 100 * _pttt / 100, Common.LamTronSo);
                                                                                    vpct.TienBH = _tienBH;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;

                                                                                }

                                                                            }
                                                                            //
                                                                            if (_tyle > 0)
                                                                                vpct.TrongBH = 1;

                                                                            else
                                                                                vpct.TrongBH = 0;
                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        if (a.trongBH == 0)
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TrongBH = 0;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                        }
                                                                        else if (a.trongBH == 2)
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TrongBH = 2;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TrongBH = 3;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = tt;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (_HTTT == 2)//else
                                                        {
                                                            if (a.trongBH == 2)
                                                            {
                                                                vpct.TyLeBHTT = 0;
                                                                vpct.TrongBH = 2;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = 0;
                                                            }
                                                            else if (a.trongBH == 3)
                                                            {
                                                                vpct.TyLeBHTT = 0;
                                                                vpct.TrongBH = 3;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = tt;
                                                            }
                                                            else
                                                            {
                                                                vpct.TyLeBHTT = 0;
                                                                vpct.TrongBH = 0;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                            }
                                                        }
                                                        else if (_HTTT == 0)
                                                        {
                                                            switch (a.trongBH)
                                                            {
                                                                case 1:
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = tt;
                                                                    vpct.TienBN = 0;
                                                                    vpct.TyLeBHTT = 100;
                                                                    break;
                                                                case 2:
                                                                    vpct.TyLeBHTT = 0;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = 0;
                                                                    break;
                                                                case 0:
                                                                    vpct.TyLeBHTT = 0;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                    break;
                                                                case 3:
                                                                    vpct.TyLeBHTT = 0;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = tt;
                                                                    break;
                                                            }
                                                        }
                                                        _data.VienPhicts.Add(vpct);
                                                        _data.SaveChanges();
                                                        if (giaVTYTTT > 0)
                                                            ThanhToan_VTYT_TT04(vpct.idVPhict, giaVTYTTT);
                                                    }
                                                }

                                            }
                                            //kt
                                            else
                                            {
                                                MessageBox.Show("không có mã bệnh nhân trong bảng viện phí");
                                            }
                                            BenhNhanProvider.SetStatus(_mabn, 3);
                                        }

                                        // tạo sao lưu\
                                        //DungChung.Ham.updateChiPhiDV(_dataContext, idvp);

                                        // btnXem_Click(sender, e);
                                    }
                                    else
                                    {
                                        var vienphi2 = (from kd in _dataContext.DThuocs.Where(p => p.KieuDon != -2)
                                                        join kdct in _dataContext.DThuoccts.OrderBy(p => p.IDDonct) on kd.IDDon equals kdct.IDDon
                                                        join dv in _dataContext.DichVus on kdct.MaDV equals dv.MaDV
                                                        where (kd.MaBNhan == _mabn)
                                                        //where(kd.KieuDon==1 || kd.KieuDon==0) //kieemrtra lai kieu don
                                                        group new { kdct, dv } by new { kdct.LoaiDV, kdct.NgayNhap, dv.TenDV, kdct.TyLeTT, kdct.Mien, kdct.XHH, kdct.ThanhToan, ck = (_maCK == dv.MaDV ? kdct.MaKP : _makpsd), IDCD = _tachCP_Thu ? kdct.IDCD : 0, MaKP = _tachKP ? kdct.MaKP : _makpsd, kdct.MaDV, kdct.DonGia, kdct.DonVi, kdct.TrongBH } into kq
                                                        select new { kq.Key.NgayNhap, kq.Key.LoaiDV, kq.Key.TenDV, kq.Key.TyLeTT, kq.Key.XHH, kq.Key.ThanhToan, kq.Key.Mien, idct = kq.Select(p => p.kdct.IDDonct).Min(), kq.Key.IDCD, kq.Key.MaKP, madv = kq.Key.MaDV, dongia = kq.Key.DonGia, donvi = kq.Key.DonVi, trongBH = kq.Key.TrongBH, soluong = kq.Sum(p => p.kdct.SoLuong), thanhtien = kq.Sum(p => p.kdct.ThanhTien) }).OrderBy(p => p.idct).ToList();

                                        // kiểm tra vận chuyển
                                        foreach (var a in vienphi)
                                        {
                                            if (Math.Round(Math.Round(a.thanhtien, 2), 0) != Math.Round(Math.Round(a.soluong * a.dongia * (100 - a.Mien) * a.TyLeTT * 0.0001, 2), 0))
                                            {
                                                MessageBox.Show(a.TenDV + " Thành tiền không bằng số lượng * đơn giá * tỷ lệ TT trừ miễn");
                                                BenhNhan qbn = _dataContext.BenhNhans.Single(p => p.MaBNhan == _mabn);
                                                if (qbn.DTNT == false && qbn.NoiTru == 0)
                                                    RaVienProvider.LuuVaXoaRaVienCu(_dataContext, _mabn, dtNgayTT, "Xoa", 2);
                                                return false;
                                            }
                                            var ktmadv = (from dv in mavanchuyen.Where(p => p == a.madv)
                                                          select dv).ToList();
                                            if (ktmadv.Count > 0)
                                            {
                                                _tienvc = a.thanhtien;
                                                break;
                                            }
                                        }
                                        //
                                        VienPhi vp2 = new VienPhi();
                                        vp2.MaBNhan = kt.First().MaBNhan;
                                        vp2.NgayTT = dtNgayTT;
                                        vp2.NgayRa = ravien.First().NgayRa;
                                        //if (lupNguoiTT.EditValue != null && lupNguoiTT.EditValue.ToString() != "")
                                        //    vp.MaCB = lupNguoiTT.EditValue.ToString();
                                        //else
                                        bool _ngoaih2 = false;
                                        _ngoaih2 = FormatHelper.isNgoaiGioHanhChinh(dtNgayTT);
                                        vp2.NgoaiGio = 0;
                                        if (_ngoaih2 == true)
                                        {
                                            if (MessageBox.Show("BN TT ngoài giờ hành chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                vp2.NgoaiGio = 1;

                                        }
                                        vp2.MaCB = Common.MaCB;
                                        //if (lupBPKe.EditValue != null && lupBPKe.EditValue.ToString() != "")
                                        //    vp.MaKP = lupBPKe.EditValue.ToString();
                                        //else
                                        vp2.MaKP = Common.MaKP;
                                        _dataContext.VienPhis.Add(vp2);
                                        if (_dataContext.SaveChanges() == 1)
                                        {
                                            BenhNhanProvider.SetStatus(_mabn, 3);
                                            var q = _dataContext.VienPhis.Where(p => p.MaBNhan == _mabn).OrderByDescending(p => p.idVPhi).ToList();
                                            if (q.Count > 0)
                                            {
                                                idvp = q.First().idVPhi;
                                            }
                                            else
                                            {
                                                idvp = 3;
                                            }
                                            Hospital _data = new Hospital();
                                            double tt = 0;
                                            double _tongtien = 0;
                                            if (vienphi.Where(p => p.trongBH == 1).ToList().Count > 0)
                                                _tongtien = Math.Round(vienphi.Where(p => p.trongBH == 1).Sum(p => p.thanhtien), 2, MidpointRounding.AwayFromZero);//ktra
                                            if (idvp > 0)
                                            {

                                                foreach (var a in vienphi)
                                                {
                                                    if (a.soluong != 0)
                                                    {
                                                        VienPhict vpct = new VienPhict();
                                                        if (_tachCP_Thu)
                                                        {
                                                            if (a.madv == _maCK)
                                                            {
                                                                vpct.IDTamUng = a.IDCD;
                                                            }
                                                            else
                                                            {
                                                                var soph = _data.ChiDinhs.Where(p => p.IDCD == a.IDCD).Select(p => p.SoPhieu).ToList();
                                                                if (soph.Count > 0 && soph.First() != null)
                                                                {
                                                                    vpct.IDTamUng = soph.First();
                                                                }
                                                                else
                                                                {

                                                                }
                                                            }
                                                        }
                                                        vpct.NgayChiPhi = a.NgayNhap == null ? dtNgayTT : a.NgayNhap.Value;
                                                        if (a.TyLeTT == 0)
                                                            vpct.TyLeTT = 100;
                                                        else
                                                            vpct.TyLeTT = a.TyLeTT;
                                                        vpct.MaKP = a.MaKP;
                                                        vpct.MaDV = a.madv;
                                                        double giaVTYTTT = 0;
                                                        double dongia = a.dongia;
                                                        var kiemtraVTYT = dsnhomdv.Where(p => p.IDNhom == 10 || p.IDNhom == 11).Where(p => p.MaDV == a.madv && p.GiaBHGioiHanTT > 0).Select(p => p.GiaBHGioiHanTT).FirstOrDefault();
                                                        if (kiemtraVTYT != null && kiemtraVTYT > 0)
                                                        {
                                                            if (dongia > kiemtraVTYT)
                                                            {
                                                                giaVTYTTT = dongia - kiemtraVTYT;
                                                                dongia = kiemtraVTYT;

                                                            }
                                                        }
                                                        vpct.DonGia = dongia;
                                                        tt = Math.Round((a.soluong * dongia) * (a.TyLeTT / 100), Common.LamTronSo);
                                                        vpct.ThanhTien = tt;
                                                        vpct.SoLuong = a.soluong;
                                                        vpct.SoLuongD = 0;
                                                        vpct.TienChenh = 0;
                                                        vpct.TienChenhBN = 0;
                                                        vpct.DonVi = a.donvi;
                                                        vpct.idVPhi = idvp;
                                                        vpct.ThanhToan = a.ThanhToan;
                                                        vpct.Mien = a.Mien;
                                                        vpct.XHH = a.XHH;
                                                        vpct.LoaiDV = a.LoaiDV;

                                                        if (_HTTT == 1) //if (_DTuong == "BHYT")
                                                        {
                                                            var ktmadv = (from dv in mavanchuyen.Where(p => p == a.madv)
                                                                          select dv).ToList();
                                                            if (_tuyen == 1)//bệnh nhân đúng tuyến
                                                            {
                                                                if (a.trongBH == 1)
                                                                {//dịch vụ trong danh mục BHYT
                                                                    if (ktmadv.Count > 0)
                                                                    {
                                                                        if (_vanchuyen == 1)
                                                                        {
                                                                            vpct.TienBH = tt;
                                                                            vpct.TrongBH = 1;
                                                                            vpct.TienBN = 0;
                                                                            vpct.TyLeBHTT = 100;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = tt;
                                                                            vpct.TrongBH = 0;
                                                                            vpct.TyLeBHTT = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if ((_tongtien - _tienvc) >= Common.GHanTT100 && _luongCS != 1)
                                                                        {
                                                                            vpct.TyLeBHTT = _pttt;
                                                                            _tienBH = Math.Round(tt * _pttt / 100, Common.LamTronSo);
                                                                            vpct.TienBH = _tienBH;
                                                                            vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TyLeBHTT = 100;
                                                                            vpct.TienBN = 0;
                                                                            vpct.TienBH = tt;
                                                                        }
                                                                        vpct.TrongBH = 1;
                                                                    }


                                                                }
                                                                else
                                                                {
                                                                    if (a.trongBH == 0)
                                                                    {
                                                                        vpct.TyLeBHTT = 0;
                                                                        vpct.TrongBH = 0;
                                                                        vpct.TienBH = 0;
                                                                        vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                    }
                                                                    else if (a.trongBH == 2)
                                                                    {
                                                                        vpct.TyLeBHTT = 0;
                                                                        vpct.TrongBH = 2;
                                                                        vpct.TienBH = 0;
                                                                        vpct.TienBN = 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        vpct.TyLeBHTT = 0;
                                                                        vpct.TrongBH = 3;
                                                                        vpct.TienBH = 0;
                                                                        vpct.TienBN = tt;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (_tuyen == 2) //BN trái tuyến
                                                                {
                                                                    if (a.trongBH == 1)
                                                                    {//dịch vụ trong danh mục BHYT
                                                                        if (ktmadv.Count > 0)
                                                                        {
                                                                            if (_vanchuyen == 1)
                                                                            {
                                                                                vpct.TyLeBHTT = 100;
                                                                                vpct.TienBH = tt;
                                                                                vpct.TrongBH = 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                vpct.TyLeBHTT = 0;
                                                                                vpct.TienBN = tt;
                                                                                vpct.TrongBH = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            // mới
                                                                            if (!string.IsNullOrEmpty(_khuvuc)) // BN có khu vực ưu tiên tính theo đúng tuyến
                                                                            {
                                                                                if (_tyle > 0)
                                                                                {
                                                                                    vpct.TyLeBHTT = _pttt;
                                                                                    _tienBH = Math.Round(tt * _pttt / 100, Common.LamTronSo);
                                                                                    vpct.TienBH = _tienBH;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                                }
                                                                                else
                                                                                {
                                                                                    vpct.TyLeBHTT = 0;
                                                                                    vpct.TienBH = 0;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if ((_tongtien - _tienvc) < Common.GHanTT100)// BN có tiền nhỏ hơn giới hạn thanh toán thì tính % trái tuyến theo hạng BV không nhân tỷ lệ
                                                                                {
                                                                                    vpct.TyLeBHTT = _tyle;
                                                                                    _tienBH = Math.Round(tt * _tyle / 100, Common.LamTronSo);
                                                                                    vpct.TienBH = _tienBH;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;

                                                                                }
                                                                                else
                                                                                {
                                                                                    vpct.TyLeBHTT = (_tyle * _pttt) / 100;
                                                                                    _tienBH = Math.Round(tt * _tyle / 100 * _pttt / 100, Common.LamTronSo);
                                                                                    vpct.TienBH = _tienBH;
                                                                                    vpct.TienBN = Math.Round((tt - _tienBH), Common.LamTronSo) * (100 - a.Mien) / 100;

                                                                                }

                                                                            }
                                                                            if (_tyle > 0)
                                                                                vpct.TrongBH = 1;
                                                                            else
                                                                                vpct.TrongBH = 0;
                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        if (a.trongBH == 0)
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TrongBH = 0;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                        }
                                                                        else if (a.trongBH == 2)
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TrongBH = 2;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            vpct.TyLeBHTT = 0;
                                                                            vpct.TrongBH = 3;
                                                                            vpct.TienBH = 0;
                                                                            vpct.TienBN = tt;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (_HTTT == 2)//else
                                                        {
                                                            if (a.trongBH == 2)
                                                            {
                                                                vpct.TrongBH = 2;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = 0;
                                                                vpct.TyLeBHTT = 100;
                                                            }
                                                            else if (a.trongBH == 3)
                                                            {
                                                                vpct.TyLeBHTT = 0;
                                                                vpct.TrongBH = 3;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = tt;
                                                            }
                                                            else
                                                            {
                                                                vpct.TyLeBHTT = 0;
                                                                vpct.TrongBH = 0;
                                                                vpct.TienBH = 0;
                                                                vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                            }
                                                        }
                                                        else if (_HTTT == 0)
                                                        {
                                                            switch (a.trongBH)
                                                            {
                                                                case 1:
                                                                    vpct.TyLeBHTT = 100;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = tt;
                                                                    vpct.TienBN = 0;
                                                                    break;
                                                                case 2:
                                                                    vpct.TyLeBHTT = 0;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = 0;
                                                                    break;
                                                                case 0:
                                                                    vpct.TyLeBHTT = 0;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = tt * (100 - a.Mien) / 100;
                                                                    break;
                                                                case 3:
                                                                    vpct.TyLeBHTT = 0;
                                                                    vpct.TrongBH = a.trongBH;
                                                                    vpct.TienBH = 0;
                                                                    vpct.TienBN = tt;
                                                                    break;
                                                            }
                                                        }
                                                        _data.VienPhicts.Add(vpct);
                                                        _data.SaveChanges();
                                                        if (giaVTYTTT > 0)
                                                            ThanhToan_VTYT_TT04(vpct.idVPhict, giaVTYTTT);
                                                    }
                                                }

                                            }//kt
                                            else
                                            {
                                                MessageBox.Show("không có mã bệnh nhân trong bảng viện phí");
                                            }
                                        }
                                        // tạo sao lưu\
                                        //DungChung.Ham.updateChiPhiDV(_dataContext, idvp);

                                        //btnXem_Click(sender, e);
                                        //if (Common.MaBV == "30007")
                                        //    btnDuyet_Click(sender, e);
                                    }
                                    #endregion
                                }

                            }

                            #region in số TT bệnh nhân thanh toán 27001
                            //if (Common.MaBV == "27001")
                            //{
                            //    var qbn = _dataContext.BenhNhans.Where(p => p.MaBNhan == _mabn).FirstOrDefault();
                            //    if (qbn != null && qbn.NoiTru == 0)
                            //    {
                            //        var qSoDKExit = _dataContext.SoDKKBs.Where(p => p.MaBNhan == _mabn && p.Status == 3).ToList();
                            //        if (qSoDKExit.Count == 0)
                            //        {
                            //            DateTime NgayTT = dtNgayTT.Date;
                            //            var qsodk = _dataContext.SoDKKBs.Where(p => p.NgayDK == NgayTT && p.Status == 3).OrderByDescending(p => p.SoDK).ToList();
                            //            int sodk = 1;
                            //            if (qsodk.Count > 0)
                            //            {
                            //                sodk = qsodk.First().SoDK + 1;
                            //            }
                            //            SoDKKB dkMoi = new SoDKKB();
                            //            dkMoi.SoDK = sodk;
                            //            dkMoi.Status = 3;
                            //            dkMoi.NgayDK = NgayTT;
                            //            dkMoi.MaBNhan = _mabn;
                            //            dkMoi.GioDK = dtNgayTT.TimeOfDay;
                            //            _dataContext.SoDKKBs.AddObject(dkMoi);
                            //            _dataContext.SaveChanges();
                            //        }
                            //    }
                            //}
                            #endregion
                            return true;
                            //TimKiem();
                        } // két thúc kiểm tra bn có chi phí hay ko

                        else
                        {
                            MessageBox.Show("Bệnh nhân này không có dịch vụ để thanh toán!");
                        }
                    }
                    else
                    {
                        string _tenbn = "";
                        MessageBox.Show("bệnh nhân " + _tenbn + " đã thanh toán");
                    }
                    return true;
                }
                else
                {
                    return false;
                }

                //}// kết thúc kiểm tra ma bn
                //catch (Exception)
                //{

                //    return false;
                //}
            }

            return true;

        }

        public static double GetMucThanhToan(List<MucTT> _qmuc, int hangBV, string mathe, int tuyen, int noingoaitru, DateTime ngayTT)
        {
            Hospital data = new Hospital();
            double _muctt = 0;
            string mamuc = "";

            if (mathe.Length > 2 && ngayTT != null)
            {
                mamuc = mathe.Substring(2, 1);
                var qmuc = _qmuc.Where(p => p.MaMuc == mamuc).ToList();
                if (qmuc.Count > 0 && qmuc.First().PTTT != null)
                {

                    // var q = data.MucTTs.(p => p.MaMuc == mamuc).PTTT;
                    if (tuyen == 1) // đúng tuyến
                    {
                        _muctt = Convert.ToDouble(qmuc.First().PTTT.ToString());
                    }
                    else // trái tuyến
                    {
                        double tylevuottuyen = 0;

                        if (noingoaitru == 0)
                        {
                            if (ngayTT >= new DateTime(2015, 1, 1) && ngayTT < new DateTime(2016, 1, 1))
                                switch (hangBV)
                                {
                                    case 3:
                                        tylevuottuyen = 0.7;
                                        break;
                                }
                            else if (ngayTT >= new DateTime(2016, 1, 1))
                            {
                                if (hangBV == 4 || hangBV == 3)
                                    tylevuottuyen = 1;
                            }
                        }
                        else if (noingoaitru == 1) // nội trú
                        {
                            if (ngayTT >= new DateTime(2015, 1, 1) && ngayTT < new DateTime(2016, 1, 1))
                                switch (hangBV)
                                {
                                    case 3:
                                        tylevuottuyen = 0.7;
                                        break;
                                    case 2:
                                        tylevuottuyen = 0.6;
                                        break;
                                    case 1:
                                        tylevuottuyen = 0.4;
                                        break;
                                }
                            else if (ngayTT >= new DateTime(2016, 1, 1) && ngayTT < new DateTime(2021, 1, 1))
                                switch (hangBV)
                                {
                                    case 4:
                                        tylevuottuyen = 1;
                                        break;
                                    case 3:
                                        tylevuottuyen = 1;
                                        break;
                                    case 2:
                                        tylevuottuyen = 0.6;
                                        break;
                                    case 1:
                                        tylevuottuyen = 0.4;
                                        break;
                                }
                            else if (ngayTT >= new DateTime(2021, 1, 1))
                            {
                                switch (hangBV)
                                {
                                    case 4:
                                        tylevuottuyen = 1;
                                        break;
                                    case 3:
                                        tylevuottuyen = 1;
                                        break;
                                    case 2:
                                        tylevuottuyen = 1;
                                        break;
                                    case 1:
                                        tylevuottuyen = 0.4;
                                        break;
                                }
                            }
                        }
                        _muctt = Convert.ToDouble(qmuc.First().PTTT) * tylevuottuyen;
                    }
                }
            }
            return _muctt;
        }

        public static double GetSoTienCanThu(int _MaBn)
        {
            Hospital _data = new Hospital();
            double KetQua = 0;
            int PTMucH = 0;
            int _tyle = 0;
            int _HangBV = 0;
            int noitru = 0, _tuyen = 0, _VC = 0;
            string DTuong = "", KhuVuc = "", _dt = "", _SoThe = "";


            var TTBN = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _MaBn)
                        select new
                        {
                            bn.MucHuong,
                            bn.Tuyen,
                            bn.DTuong,
                            bn.KhuVuc,
                            bn.NoiTru,
                            bn.SThe
                        }).FirstOrDefault();
            if (TTBN != null)
            {
                noitru = TTBN.NoiTru.Value;
                if (TTBN.MucHuong != null && TTBN.MucHuong > 0)
                {
                    string _a = TTBN.MucHuong.ToString();
                    PTMucH = ThanhToanProvider.GetPhanTramThanhToan(_data, _a);
                }
                if (TTBN.Tuyen != null)
                    _tuyen = TTBN.Tuyen.Value;
                if (TTBN.KhuVuc != null)
                    if (TTBN.KhuVuc.ToString().Contains("K"))
                        KhuVuc = TTBN.KhuVuc;
                if (TTBN.DTuong != "KSK" && TTBN.DTuong.Trim() != "")
                    DTuong = TTBN.DTuong;
                if (TTBN.SThe != null)
                    _SoThe = TTBN.SThe;
            }
            if (!string.IsNullOrEmpty(_SoThe) && _SoThe.Length > 2)
                _dt = _SoThe.Substring(2, 1);
            var KTVanC = _data.MucTTs.Where(p => p.MaMuc.Contains(_dt)).Select(p => p.VanChuyen).ToList();
            if (KTVanC.Count > 0)
                _VC = KTVanC.First().Value;
            _HangBV = BenhvienProvider.GetHangBenhVien(Common.MaBV);

            switch (_HangBV)
            {
                case 1:
                    if (noitru == 0)
                        _tyle = 0;
                    else
                        _tyle = 40;
                    break;
                case 2:
                    if (Common.MaBV == "01830")
                        _tyle = 70;
                    else
                    {
                        if (noitru == 0)
                            _tyle = 0;
                        else
                            _tyle = 60;
                    }
                    break;
                case 3:

                    _tyle = 70;
                    break;
                case 4:
                    _tyle = 100;
                    PTMucH = 100;
                    break;
            }
            var _ldtct = (from dt in _data.DThuocs.Where(p => p.MaBNhan == _MaBn)
                          join dtct in _data.DThuoccts.Where(p => p.ThanhToan != 1).OrderBy(p => p.IDDonct).Where(p => p.TrongBH != 2) on dt.IDDon equals dtct.IDDon
                          group dtct by new { dtct.MaDV, dtct.TrongBH } into kq
                          select new
                          {
                              kq.Key.MaDV,
                              kq.Key.TrongBH,
                              ThanhTien = kq.Sum(p => p.ThanhTien)
                          }).ToList();
            var _ldvVC = (from dv in _data.DichVus
                          join tn in _data.TieuNhomDVs on dv.IdTieuNhom equals tn.IdTieuNhom
                          join n in _data.NhomDVs.Where(p => p.TenNhomCT.Contains("Vận chuyển")) on tn.IDNhom equals n.IDNhom
                          select new { dv.MaDV }).ToList();
            if (DTuong == "Dịch Vụ")
            {
                if (_ldtct.Count() > 0)
                    KetQua = _ldtct.Sum(p => p.ThanhTien);
            }
            else
            {
                foreach (var item in _ldtct)
                {
                    if (_tuyen == 1) //đúng tuyến
                    {
                        var _ktvc = _ldvVC.Where(p => p.MaDV == item.MaDV).ToList(); //kiểm tra tiền vận chuyển
                        if (_ktvc.Count() > 0)
                        {
                            if (_VC == 1)
                                KetQua += item.ThanhTien;
                        }
                        else
                        {
                            if (item.TrongBH == 0)
                            {
                                KetQua += item.ThanhTien;
                            }
                            else
                            {
                                KetQua += (item.ThanhTien * (100 - PTMucH)) / 100;
                            }
                        }
                    }
                    else //trái tuyến
                    {
                        var _ktvc = _ldvVC.Where(p => p.MaDV == item.MaDV).ToList(); //kiểm tra tiền vận chuyển
                        if (_ktvc.Count() > 0)
                        {
                            KetQua += item.ThanhTien; //bệnh nhân trái tuyến chi trả 100% tiền VC
                        }
                        else
                        {
                            if (item.TrongBH == 0)
                            {
                                KetQua += item.ThanhTien;
                            }
                            else
                            {
                                KetQua += item.ThanhTien - ((item.ThanhTien * PTMucH * _tyle) / (100 * 100));
                            }
                        }
                    }
                }
            }
            return KetQua;
        }

        public static double GetTongTienTamUng(Hospital _data, int _MaBN)
        {
            double KQ = 0;
            var TU = (from tu in _data.TamUngs.Where(p => p.MaBNhan == _MaBN).Where(p => p.PhanLoai == 0)
                      group tu by new { tu.MaBNhan } into kq
                      select new { Tong = kq.Sum(p => p.SoTien) }).FirstOrDefault();
            if (TU != null)
            {
                KQ = TU.Tong.Value;
            }
            return KQ;
        }

        public static double GetSoTienBNTraThem(Hospital _data, int _MaBN)
        {
            double KQ = 0;
            double TienTU = 0, TienBN = 0;
            TienTU = GetTongTienTamUng(_data, _MaBN);
            TienBN = GetSoTienCanThu(_MaBN);
            KQ = TienBN - TienTU;
            return KQ;
        }
    }
}
