using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class RaVienProvider
    {
        public static bool isRaVien(Hospital _data, int _mabn)
        {

            var kt = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _mabn).Where(p => p.NoiTru == 1)
                      join rav in _data.RaViens.Where(p => p.MaBNhan == _mabn) on bn.MaBNhan equals rav.MaBNhan
                      select rav).ToList();
            if (kt.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("Bệnh nhân đã làm thủ tục ra|chuyển viện, bạn không thể thêm mới hay sửa");
                return true;
            }
            else
                return false;
        }
        public static bool isNgoaiTruRaVien(Hospital _data, int _mabn)
        {
            var kt = (from bn in _data.BenhNhans.Where(p => p.MaBNhan == _mabn).Where(p => p.NoiTru == 0) join rav in _data.RaViens.Where(p => p.Status == 2) on bn.MaBNhan equals rav.MaBNhan select rav).ToList();
            if (kt.Count > 0)
            {
                // System.Windows.Forms.MessageBox.Show("Bệnh nhân đã làm thủ tục ra|chuyển viện, bạn không thể thêm mới hay sửa");
                return true;
            }
            else
                return false;
        }

        public static string iss(Hospital _data, string _sthe, int ttluu)
        {
            if (ttluu == 2)
            {
                return "";
            }
            DateTime ngayss = DateTime.Now.AddMonths(-2);
            var kt = (from bn in _data.BenhNhans.Where(p => p.NNhap > ngayss).Where(p => p.SThe.ToLower() == (_sthe.ToLower()))
                      join rav in _data.RaViens on bn.MaBNhan equals rav.MaBNhan into kq
                      from kq2 in kq.DefaultIfEmpty()
                      where kq2 == null
                      select bn).OrderByDescending(p => p.NNhap).ToList();
            if (kt.Count > 0)
            {
                int makp = kt.First().MaKP.Value;
                var kp = _data.KPhongs.Where(p => p.MaKP == makp).ToList();
                if (kp.Count > 0)
                    return kp.First().TenKP;
                return "";
            }
            else
                return "";
        }

        public static string isRaVien(Hospital _data, string _sthe, int ttluu)
        {
            if (ttluu == 2)
            {
                return "";
            }
            DateTime ngayss = DateTime.Now.AddMonths(-2);
            var kt = (from bn in _data.BenhNhans.Where(p => p.NNhap > ngayss).Where(p => p.SThe.ToLower() == (_sthe.ToLower()))
                      join rav in _data.RaViens on bn.MaBNhan equals rav.MaBNhan into kq
                      from kq2 in kq.DefaultIfEmpty()
                      where kq2 == null
                      select bn).OrderByDescending(p => p.NNhap).ToList();
            if (kt.Count > 0)
            {
                int makp = kt.First().MaKP.Value;
                var kp = _data.KPhongs.Where(p => p.MaKP == makp).ToList();
                if (kp.Count > 0)
                    return kp.First().TenKP;
                return "";
            }
            else
                return "";
        }

        public static bool LuuVaXoaRaVienCu(Hospital _data, int _mabn, DateTime dtNgayTT, string Luu_Xoa, int RaChuyenVien)
        {
            try
            {
                var ktrvien = _data.RaViens.Where(p => p.MaBNhan == _mabn).ToList();
                if (Luu_Xoa == "Luu")
                {
                    var bnkb = _data.BNKBs.Where(p => p.MaBNhan == _mabn).OrderByDescending(p => p.IDKB).ToList();
                    if (ktrvien.Count <= 0)
                    {
                        if (bnkb.Count > 0)
                        {
                            string[] maicd = new string[6] { "", "", "", "", "", "0" };
                            maicd = ICDProvider.getMaICDarr(_data, _mabn, Common.GetICD);
                            DateTime _ngayvao = dtNgayTT;
                            if (bnkb.Last().NgayKham != null)
                                _ngayvao = bnkb.Last().NgayKham.Value;
                            else
                                _ngayvao = dtNgayTT.AddMinutes(-1);
                            TimeSpan ts = dtNgayTT - _ngayvao;
                            if (ts.TotalMinutes < 1)
                            {
                                //MessageBox.Show("Ngày giờ ra viện: " + dtNgayTT.Tostring() + " phải > ngày giờ vào viện: " + _ngayvao.Tostring());
                                return false;
                            }
                            RaVien _ravien = new RaVien();
                            _ravien.MaKP = string.IsNullOrEmpty(maicd[2]) ? 0 : Convert.ToInt32(maicd[2]);
                            _ravien.MaICD = maicd[0];
                            _ravien.ChanDoan = maicd[1];
                            _ravien.MaCK = Convert.ToInt16(maicd[5]);
                            if (bnkb.First().PhuongAn != null && bnkb.First().PhuongAn == 2)
                                _ravien.Status = 1;
                            else
                                _ravien.Status = 2;
                            // kiểm tra lại số ngày điều trị
                            int songaydt = 11;// FormNhap.frm_Ravien.getDaysOfStay(_mabn, _ngayvao, dtNgayTT);
                            // doi voi benh nhan ngoai tru, dt ngoai tru = ngay ra - ngay vao, quynv yeu cau
                            if (songaydt > 1)
                                songaydt = songaydt - 1;
                            _ravien.SoNgaydt = 1;
                            _ravien.NgayRa = dtNgayTT;
                            _ravien.MaBNhan = _mabn;
                            _ravien.NgayVao = _ngayvao;
                            _data.RaViens.Add(_ravien);
                            _data.SaveChanges();
                            try
                            {
                                BenhNhanProvider.SetStatus(_mabn, 2);

                            }
                            catch { }
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                if (Luu_Xoa == "Xoa")
                {
                    try
                    {
                        var xoa = _data.RaViens.Single(p => p.MaBNhan == _mabn);
                        _data.RaViens.Remove(xoa);
                        _data.SaveChanges();
                        var qcls = _data.CLS.Where(p => p.MaBNhan == _mabn).ToList();
                        if (qcls.Count == 0)
                            BenhNhanProvider.SetStatus(_mabn, 1);// bệnh nhân đã khám
                        else
                            BenhNhanProvider.SetStatus(_mabn, 5);// bệnh nhân đã có kqCLS
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                //MessageBox.Show("Lỗi tạo ra viện: " + ex.Message);
                return false;
            }
        }
    }
}
