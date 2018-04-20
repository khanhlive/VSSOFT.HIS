
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using Vssoft.Data;
using Vssoft.Data.Core;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Security
{
    public partial class Function
    {
        #region getHanDung
        public static DateTime? getHanDung(int madv, string solo) 
            => NhapDuocProvider.GetHanDung(madv, solo);
        #endregion

        #region hàm set khoa phòng hiện tại và nội-ngoại trú cho bệnh nhân

        public static bool _setMaKP_BenhNhan(Hospital _data, int _mabn, int _makp, int _noitru) 
            => BenhNhanProvider.SetMaKPToBenhNhan(_data, _mabn, _makp, _noitru);

        #endregion

        #region hàm set trạng thái(Status) trong bảng "Bệnh nhân"

        public static void _setStatus(int mabenhnhan, int status)
            => BenhNhanProvider.SetStatus(mabenhnhan, status);
        #endregion

        #region set SoKB

        public static bool setSoKB(int mabn) =>
            BenhNhanProvider.SetSoKB(mabn);

        #endregion

        #region hàm set trạng thái(Status) trong bảng "Bệnh nhân"
        /// <summary>
        /// set trạng thái đã khám bệnh hay chưa
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="status"></param>
        /// <param name="makp"></param>
        public static void _setStatus(int ms, int status, int makp) 
            => BenhNhanProvider.SetStatus(ms, status, makp);
        #endregion

        #region hàm lấy  đơn vị
        public static string _getDonVi(Hospital data, int madv) 
            => DichVuProvider.GetDonViTinh(data, madv);

        public static List<LKhoaPhong> None => KhoaPhongProvider.Empty;

        public static List<LKhoaPhong> TatCa => KhoaPhongProvider.All;

        public static bool GiaCu(int mabn, int TrongDM, DateTime ngaychidinh) 
            => PriceProvider.GetGiaCu(mabn, TrongDM, ngaychidinh);

        public static double _getGiaDM(Hospital data, int maDV, int trongDM, int mabn, DateTime ngaychidinh) 
            => PriceProvider.GetGiaDM(data, maDV, trongDM, mabn, ngaychidinh);
        #endregion

        #region KiemTra soLo đã sử dụng
        public static bool checkSoLo(int makho, int madv, string solo, double dongia) 
            => NhapDuocProvider.KiemTraSoLoDaSuDung(makho, madv, solo, dongia);
        #endregion

        #region kiểm tra số lượng tồn
        
        public static double _checkTon(Hospital data, int maDV, int makho, double gia, double soluongke, string solo) 
            => NhapDuocProvider.KiemTraSoLuongThuocTonKho(data, maDV, makho, gia, soluongke, solo);
        #endregion

        #region kiểm tra số lượng tồn khi lưu kê đơn
        
        public static double _checkTon_KD(Hospital data, int maDV, int makho, double gia, double soluongke, string solo)
            =>NhapDuocProvider.KiemTraSoLuongThuocTonKho_KeDon(data, maDV, makho, gia, soluongke, solo);
        #endregion


        #region lay giá và tính tồn dược theo kho

        public static Gia_SoLo_HanSuDung _getGia(Hospital data, int maDV, int makho)
            => PriceProvider.GetGia_SoLo_HSD(data, maDV, makho);
        #endregion

        #region lay giá và tính tồn dược theo kho theo mã cung cấp
        public static double _getGia(Hospital data, int maDV, int makho, string macc)
            => PriceProvider.GetGiaTheoNhaCungCap(data, maDV, makho, macc);
        #endregion
        #region lấy số lô

        #endregion
        #region hàm lấy max
        public static int _maxID()
        {
            int max = 0;
            return max;
        }
        #endregion
        #region hàm tính tổng tiền
        public static double _SumTT(double a, double b)
        {
            return a * b;
        }
        #endregion

        #region hàm lấy phần trăm BNBH thanh toán
        public static int _PtramTT(Hospital data, string muc)
            => ThanhToanProvider.GetPhanTramThanhToan(data, muc);
        #endregion

        #region hàm kiểm tra dịch vụ có trong danh mục BHYT hay không
        public static bool _KTDMBHYT(Hospital data, int madv)
            => DichVuProvider.KiemTraDichVuTrongBHYT(data, madv);
        #endregion

        #region Hàm đọc số thành chữ

        // Hàm đọc số thành chữ
        public static string DocTienBangChu(double SoTien, string strTail)
            => FormatHelper.DocTienBangChu(SoTien, strTail);

        #endregion

        #region ham viet hoa chu cai dau
        public static string ToFirstUpper(string s)
            => FormatHelper.ToFirstUpper(s);
        #endregion

        #region lấy số tuần trong năm
        public static int GetWeekOrderInYear(DateTime time)
            => FormatHelper.GetWeekOrderInYear(time);
        #endregion

        #region Kiểm tra thẻ theo ngày
        public static string KTTheBHYT(Hospital DataContext, string sthe, DateTime ngay)
            => BHYTProvider.KTTheBHYT(DataContext, sthe, ngay);
        #endregion

        #region Kiểm tra thẻ nhập trong tuần
        public static string KTTheBHYT(Hospital DataContext, string sthe, DateTime ngay, int tuan)
            => BHYTProvider.KTTheBHYT(DataContext, sthe, ngay, tuan);
        #endregion

        #region NgayTu
        public static DateTime NgayTu(DateTime ngaydmy)
            => FormatHelper.BeginDate(ngaydmy);
        #endregion

        #region NgayDen
        public static DateTime NgayDen(DateTime ngaydmy)
            => FormatHelper.EndDate(ngaydmy);
        #endregion

        public static string GetICDstr(string maBenh)
            => ICDProvider.GetICDstr(maBenh);
        public static string NgaySangChu(DateTime ngay)
            => FormatHelper.NgaySangChu(ngay);
        #region Ngày sang chữ
        public static string NgaySangChu(DateTime ngay, StringDatetimeType type) 
            => FormatHelper.NgaySangChu(ngay, type);
        #endregion
        #region hàm lấy right
        // hàm lấy right
        public static string Right(string s, int len)
        {
            if (s.Length <= len) return s;
            else
            {
                return s.Substring(s.Length - len, len);
            }
        }
        #endregion

        #region kiểm tra thanh toán hay chưa
        public static bool KTraTT(Hospital data, int mabnhan)
            => ThanhToanProvider.isThanhToan(data, mabnhan);
        #endregion
        #region kiểm tra khám bệnh hay chưa
        public static bool KTraKB(Hospital data, int mabn)
            => BenhNhanProvider.isKhamBenh(data, mabn);
        #endregion

        public static DateTime ConvertNgay(string ngay)
            => FormatHelper.StringToDatetime(ngay);

        #region Ktra ngày nhập không được nhỏ hơn ngày nhập bệnh nhân
        public static bool CheckNgay(Hospital data, int mabn, DateTime ngay)
            => BenhNhanProvider.KiemTraNgayNhap(data, mabn, ngay);
        #endregion
        #region Kiểm tra đã có số phiếu lĩnh chưa
        public static bool _checkSoPL(Hospital data, int IDdon)
            => PhieuLinhProvider.isHasSoPhieuLinh(data, IDdon);
        #endregion
        #region KT giờ HC
        public static bool CheckNGioHC(DateTime dt)
            => FormatHelper.isNgoaiGioHanhChinh(dt);
        #endregion
        #region
        
        #endregion
        #region lấy số pm
        public static string Read(string KeyName, int i)
        {
            // Opening the registry key
            try
            {
                RegistryKey rk = Registry.LocalMachine;
                // Open a subKey as read-only
                string subKey = "SOFTWARE\\Cuong";
                RegistryKey sk1 = rk.OpenSubKey(subKey);

                if (sk1 == null)
                {
                    return "";
                }
                else
                {
                    try
                    {
                        // If the RegistryKey exists I get its value
                        // or null is returned.
                        return (string)sk1.GetValue(KeyName.ToString());
                    }
                    catch (Exception)
                    {
                        // AAAAAAAAAAARGH, an error!
                        System.Windows.Forms.MessageBox.Show("Liên hệ 0466.72.36.36");
                        return "";
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi đọc số PM ");
                return "";
            }
        }
        #endregion
        #region lay ngay update
        #endregion

        #region cắt chuỗi
        public static string CatChuoi(string chuoi, char kytu)
            => FormatHelper.StringSplit(chuoi, kytu);
        #endregion
        #region kiểm tra ngày khóa dữ liệu
        public static bool _checkNgayKhoa(Hospital data, DateTime dt, string ploaict)
            => CommonHelper.isKhoaDuLieu(data, dt, ploaict);
        #endregion

        #region ktra ra vien

        public static bool KT_RaVien(Hospital _data, int _mabn)
            => RaVienProvider.isRaVien(_data, _mabn);
        #endregion

        #region ktra ra vien ngoại trú
        /// <summary>
        /// ra viện : true, chưa ra: false
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_mabn"></param>
        /// <returns></returns>
        public static bool KT_RaVien_ngt(Hospital _data, int _mabn)
            => RaVienProvider.isNgoaiTruRaVien(_data, _mabn);
        #endregion

        #region ktra ra vien
        public static string KT_RaVien(Hospital _data, string _sthe, int ttluu)
            => RaVienProvider.isRaVien(_data, _sthe, ttluu);
        #endregion

        #region Kiểm tra chỉ định đã được thực hiện hay chưa
        public static string KTChiDinh(Hospital _data, int mabn)
            => KhamBenhProvider.KiemTraDichVuChiDinh(_data, mabn);
        #endregion

        #region tính tuổi ra tháng tuổi
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="mabn"></param>
        /// <param name="gioihan">thang-ngay</param>
        /// <returns></returns>
        /// 
        public static string TuoitheoThang(Hospital _data, int mabn, string gioihan)
            => BenhNhanProvider.TuoitheoThang(_data, mabn, gioihan);
        #endregion

        #region tính tuổi ra tháng tuổi
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="mabn"></param>
        /// <param name="gioihan">thang-ngay</param>
        /// <returns></returns>
        public static string TuoitheoThang(DateTime _ngaynhap, string _ngayS, string _thangS, string _namS, int _tuoi, string gioihan)
            => BenhNhanProvider.TuoitheoThang(_ngaynhap, _ngayS, _thangS, _namS, _tuoi, gioihan);
        #endregion

        #region Lấy mã ICD
        /// <summary>
        /// 0. lấy Mã ICD và chẩn đoán cuối cùng 
        /// 1. Lấy Mã ICD và chẩn đoán đầu tiên
        /// 2. Lấy tất cả các chẩn đoán, Mã ICD cuối cùng làm chính
        /// 3. Lấy tất cả các chuẩn đoán, Mã ICD đầu tiên làm chính
        /// \n returns: string[]{"Mã ICD","Chẩn đoán","Mã KP","Ngày khám"};
        /// </summary>
        /// <param name="data"> da ta contect</param>
        /// <param name="mabn">Mã bệnh nhân</param>
        /// <param name="kieu">Cách thức lấy mã ICD, được thiết lập trên hệ thống</param>
        /// <returns>
        /// 1 là sdfg dsg 
        /// </returns>
        public static string[] getMaICDarr(Hospital _data, int _mabn, int _kieu)
            => ICDProvider.getMaICDarr(_data, _mabn, _kieu);
        #endregion

        #region arrICD
        /// <summary>
        /// return array 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string[] getICD(string arr)
            => ICDProvider.SplitICD(arr);
        #endregion
        


    }
}
