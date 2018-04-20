using System;
using System.Linq;
using System.Windows.Forms;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class KhamBenhProvider
    {
        public static string KiemTraDichVuChiDinh(Hospital _data, int mabn)
        {
            string tendv = "";
            var a = (from cls in _data.CLS.Where(p => p.MaBNhan == mabn)
                     join cd in _data.ChiDinhs.Where(p => p.Status == null || p.Status == 0) on cls.IdCLS equals cd.IdCLS
                     join dv in _data.DichVus on cd.MaDV equals dv.MaDV
                     select dv.TenDV).ToList();
            int j = 1;
            foreach (var i in a)
            {
                tendv += j + ": " + i + "\n ";
                j++;
            }
            return tendv;
        }

        public static bool KiemTraCongKham_NgayGiuong(Hospital _dataContext, int mabn)
        {
            var bnhan = _dataContext.BenhNhans.Where(p => p.MaBNhan == mabn).ToList();
            int noitru = -1;
            string doituong = "", _tenbn = "";
            if (bnhan.Count > 0 && bnhan.First().NoiTru != null)
            {
                noitru = bnhan.First().NoiTru.Value;
                doituong = bnhan.First().DTuong;
                _tenbn = bnhan.First().TenBNhan;
            }
            int _congkham = 0;
            int _ngaygiuong = 0;
            var kt = (from dt in _dataContext.DThuocs.Where(p => p.MaBNhan == mabn)
                      join dtct in _dataContext.DThuoccts on dt.IDDon equals dtct.IDDon
                      join dvu in _dataContext.DichVus.Where(p => p.PLoai == 2).Where(p => p.Status == 1) on dtct.MaDV equals dvu.MaDV
                      join tn in _dataContext.TieuNhomDVs on dvu.IdTieuNhom equals tn.IdTieuNhom
                      join nhom in _dataContext.NhomDVs on tn.IDNhom equals nhom.IDNhom
                      select new { dtct.IDDonct, nhom.TenNhomCT }).ToList();
            _congkham = kt.Where(p => p.TenNhomCT.Contains("Khám bệnh")).ToList().Count;
            _ngaygiuong = kt.Where(p => p.TenNhomCT.Contains("Giường điều trị nội trú")).ToList().Count;
            if (doituong == "BHYT")
            {
                if (noitru == 1)
                {

                    if (_ngaygiuong <= 0)
                    {
                        DialogResult _result = MessageBox.Show("Bệnh nhân: " + _tenbn + " chưa có tiền ngày giường, \n Bạn vẫn muốn thanh toán?", "Hỏi thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (_result == DialogResult.Yes)
                            return false;
                        else
                            return true;
                    }
                }
                else
                {
                    if (_ngaygiuong > 0)
                    {
                        MessageBox.Show("Bệnh nhân  ngoại trú không có tiền ngày giường,\n Bạn không thể thanh toán!");
                        return true;
                    }
                    else
                    {
                        if (_congkham <= 0)
                        {
                            var rv = _dataContext.RaViens.Where(p => p.MaBNhan == mabn).Select(p => p.MaICD).ToList();
                            if (rv.Count > 0 && rv.First() != null && rv.First().ToString().ToUpper() == "N18")
                                return false;
                            MessageBox.Show("Bệnh nhân không có tiền công khám, Bạn không thể thanh toán!");
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (doituong == "Dịch vụ")
                {
                    if (noitru == 1)
                    {
                        if (_ngaygiuong <= 0)
                        {
                            DialogResult _result = MessageBox.Show("Bệnh nhân: " + _tenbn + " chưa có tiền ngày giường, \n Bạn vẫn muốn thanh toán?", "Hỏi thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (_result == DialogResult.Yes)
                                return false;
                            else
                                return true;
                        }
                    }
                    else
                    {
                        if (_congkham <= 0)
                        {

                            System.Windows.Forms.DialogResult _result = MessageBox.Show("Bệnh nhân: " + _tenbn + " chưa có tiền công khám, \n Bạn vẫn muốn thanh toán?", "Hỏi thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (_result == DialogResult.Yes)
                                return false;
                            else
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public static string[] GetDanhSachBNKB(Hospital _Data, int mabn, int makp)
        {
            string[] arrTT = new string[5] { "", "", "", "", "" };
            var kbcd = (from bnkb in _Data.BNKBs.Where(p => p.MaBNhan == mabn).Where(p => p.MaKP == makp) select new { bnkb.MaICD, bnkb.ChanDoan, bnkb.MaKP, bnkb.Buong, bnkb.Giuong, bnkb.BenhKhac, bnkb.IDKB }).OrderByDescending(p => p.IDKB).ToList();
            if (kbcd.Count > 0)
            {
                arrTT[0] = kbcd.First().MaICD;
                arrTT[1] = ICDProvider.GetICDstr(kbcd.First().ChanDoan + ";" + kbcd.First().BenhKhac);
                arrTT[2] = kbcd.First().Buong == null ? "" : kbcd.First().Buong;
                arrTT[3] = kbcd.First().Giuong == null ? "" : kbcd.First().Giuong;
            }
            var qkp = (from kp in _Data.KPhongs
                       where (kp.MaKP == (makp))
                       select new { kp.TenKP }).ToList();
            if (qkp.Count > 0)
            {
                arrTT[4] = qkp.First().TenKP;
            }
            return arrTT;
        }

        public static string KiemtraSoLanKham(int mabnhan)
        {
            Hospital data = new Hospital();
            BenhNhan bnhan = data.BenhNhans.Where(p => p.MaBNhan == mabnhan).FirstOrDefault();
            if (bnhan != null && !String.IsNullOrEmpty(bnhan.SThe))// là bệnh nhân bảo hiểm
            {
                DateTime ngaynhap = bnhan.NNhap.Value.Date;
                var qlbn = (from bn in data.BenhNhans.Where(p => p.SThe == bnhan.SThe).Where(p => p.MaBNhan != bnhan.MaBNhan)
                            join rv in data.RaViens on bn.MaBNhan equals rv.MaBNhan
                            select new { bn.MaBNhan, rv.NgayRa }).ToList();
                VaoVien vvien = data.VaoViens.Where(p => p.MaBNhan == mabnhan).FirstOrDefault();
                if (vvien != null && vvien.NgayVao != null)
                {
                    foreach (var a in qlbn)
                    {
                        if (a.NgayRa.Value.Date == vvien.NgayVao.Value.Date)
                            return "Bệnh nhân đã ra viện trong ngày";
                    }
                }

                foreach (var a in qlbn)
                {
                    if (a.NgayRa.Value.Date == ngaynhap)
                        return "Bệnh nhân đã ra viện trong ngày";
                }
                foreach (var a in qlbn)
                {
                    if ((ngaynhap - a.NgayRa.Value.Date.AddMonths(1)).Days <= 0)
                        return "Bệnh nhân đã khám trong tháng";
                }
            }
            return "";
        }
    }
}
