using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data;
using Vssoft.Data.Core;
using Vssoft.Data.Extension;
using Vssoft.Data.Models;
using Vssoft.ERP.Models;

namespace Vssoft.Security
{
    public partial class Function
    {
        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_macb">mã cán bộ trong dữ liệu</param>
        /// <param name="_macbxoa">mã cán bộ muốn thực hiện sửa-xóa</param>
        /// <returns></returns>
        public static bool _KiemTraCBSuaXoa(Hospital _data, string _macb, string _macbxoa)
            => PermissionProvider.isSuaXoa(_data, _macb, _macbxoa);
        #endregion
        #region convert font Unicode
        public static int Font = 0;
        public static string convertTCVN(string str)
            => FormatHelper.ConvertTCVN(str);
        public static string convertUnicode(string str)
            => FormatHelper.ConvertUnicode(str);
        /// <summary>
        /// convert sang TCVN3 = TCVN3,convert sang Unicode = Unicode
        /// </summary>
        /// <param name="str"></param>
        /// <param name="TCVN3Unicode">convert sang TCVN3 = TCVN3,convert sang Unicode = Unicode</param>
        /// <returns></returns>
        public static string convertFont(string str, string TCVN3Unicode)
            => FormatHelper.ConvertFont(str, TCVN3Unicode);
        public static string convertFont(bool convert, string str, string TCVN3Unicode)
            => FormatHelper.ConvertFont(convert, str, TCVN3Unicode);
        #endregion
        #region kiểm tra kq cls
        /// <summary>
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="maBN"></param>
        /// <param name="strTimkiem"></param>
        /// <param name="ploaiTKiem">0: STT, 1: MaDVct</param>
        /// <param name="TenRG"> mảng chứa các tên TNRG</param>
        /// <param name="kq"></param>
        /// <param name="TenRG"></param>
        /// <returns></returns>
        public static string kiemtraKQ(Hospital _data, int maBN, string strTimkiem, int ploaiTKiem, double kq, List<string> TenRG)
            => CanLamSangProvider.KiemTraCLS(_data, maBN, strTimkiem, ploaiTKiem, kq, TenRG);

        #endregion

        #region lấy trị số bình thường
        //string TenTNRG;
        /// <summary>
        /// trả về 1 mảng. 0:TenDVct, 1:DonVi, 2:TSBT,3:TSBTn,4:TSBTnu
        /// </summary>
        /// <param name="DataContect"></param>
        /// <param name="madvct"></param>
        /// <param name="ploaiTKiem">0: STT, 1: MaDVct</param>
        /// <param name="TenTNRG"> mảng chứa các tên TNRG</param>
        /// <returns>
        /// 
        /// </returns>
        public static string[] layTSBT(Hospital DataContect, string strTimkiem, List<string> TenTNRG, int ploaiTKiem)
            => TriSoTrungBinhProvider.GetTriSoBinhThuong(DataContect, strTimkiem, TenTNRG, ploaiTKiem);


        #endregion
        #region Lưu-Xóa ra viện bn ngoại trú
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_mabn"></param>
        /// <param name="Luu_Xoa"> Lưu : Luu, Xóa: Xoa</param>
        /// <param name="RaChuyenVien"> set status để biết bệnh nhân ra hay chuyển viện</param>
        public static bool _LuuXoaRaVien(Hospital _data, int _mabn, DateTime dtNgayTT, string Luu_Xoa, int RaChuyenVien)
            => RaVienProvider.LuuVaXoaRaVienCu(_data, _mabn, dtNgayTT, Luu_Xoa, RaChuyenVien);
        #endregion
        #region liệt kê danh sách thuốc tồn theo kho

        public static List<ThuocTon> KiemTraTonDuoc(Hospital _dataContext, int _makp)
            => NhapDuocProvider.KiemTraTonDuoc(_dataContext, _makp);
        #endregion
        #region KTCongKham_ngaygiuong
        public static bool KTCongKham_ngaygiuong(Hospital _dataContext, int mabn)
            => KhamBenhProvider.KiemTraCongKham_NgayGiuong(_dataContext, mabn);
        #endregion
        #region updateChiPhiDV
        public static bool updateChiPhiDV(Hospital data, int _idvp)
            => DichVuProvider.CapNhatChiPhiDichVu(data, _idvp);
        #endregion
        #region xoaChiPhiDV
        public static void xoaChiPhiDV(Hospital data, int idVPhi)
            => DichVuProvider.XoaChiPhiDichvu(data, idVPhi);
        #endregion

        #region TrongDMBHYT

        public static List<TrongDMBHYT> _SetValue_TrongDMBH
            => TrongDMBHYT.GetList;
        #endregion
        #region Tính hao hụt số lượng đông y
        public static double _getSL_DongY(Hospital _data, int _madv, double _soluong, int makho)
            => NhapDuocProvider.GetSoLuongDongY(_data, _madv, _soluong, makho);
        #endregion
        #region
        /// <summary>
        /// True: đã thanh toán trong ngày
        /// False: chưa thanh toán trong ngày
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_sthe"></param>
        /// <returns></returns>
        public static bool _KTBN_TT_TrongNgay(Hospital _data, int _mabn, DateTime _dt)
            => BenhNhanProvider.KiemTraBenhNhanKhamBenhTrongNgay(_data, _mabn, _dt);
        #endregion
        #region lấy thông tin bệnh nhân khám bệnh
        /// <summary>
        ///  arrTT[0] = MaICD;
        ///        arrTT[1] = ChanDoan
        ///       arrTT[2] = Buong;
        ///        arrTT[3] =Giuong;
        /// </summary>
        /// <param name="_Data"></param>
        /// <param name="mabn"></param>
        /// <param name="makp"></param>
        /// <returns></returns>
        public static string[] laythongtinBNKB(Hospital _Data, int mabn, int makp)
            => KhamBenhProvider.GetDanhSachBNKB(_Data, mabn, makp);
        #endregion
        #region _update Trong DM =0 với BN dịch vụ
        public static void _updateTrongDM_Dtct(Hospital _data, int _mabn)
            => DonThuocProvider.CapNhatTrongBHForBenhNhan(_data, _mabn);
        #endregion
        #region _kiểm tra tạm thu cận lâm sàng
        /// <summary>
        /// true: đã tạm thu
        /// false: chưa tạm thu
        /// </summary>
        /// <param name="IDCD"></param>
        /// <returns></returns>
        public static bool _checkTamThu(Hospital _data, int _mabn, int _IDCLS)
            => ThuChiTamUngProvider.KiemTraTamThu(_data, _mabn, _IDCLS);
        #endregion

        #region Check tam thu theo IDCD
        public static bool _checkTamThu_IDCD(Hospital _data, int _mabn, int _IDCD)
            => ThuChiTamUngProvider.KiemTraTamThu(_data, _mabn, _IDCD);
        #endregion
        #region _getTenCB
        public static string _getTenCB(Hospital _data, string _macb)
            => CanBoProvider.GetName(_data, _macb);
        #endregion

        #region Phân quyền
        /// <summary>
        /// 0:mới 
        /// 1:sửa
        /// 2:XóagetIDForm
        /// 3:Xem
        /// </summary>
        /// <param name="idForm"></param>       
        /// <param name="machucnang"> Thêm = 1; sửa =2; xóa =3; xem =4</param>
        /// <returns></returns>
        public static bool[] checkQuyen(string tenform_Bc)
            => PermissionProvider.CheckQuyenHan(tenform_Bc);

        public static bool[] checkQuyenFalse(string tenform_Bc)
            => PermissionProvider.CheckQuyenFalse(tenform_Bc);

        #endregion
        public static int hangBV(string mabv)
            => BenhvienProvider.GetHangBenhVien(mabv);
        #region hang bv de tinh tien cong kham
        public static int hangBVCK(string mabv)
            => BenhvienProvider.GetHangBVCK(mabv);
        #endregion
        #region thanh toán
        // 01/06/2017 thanh toán VTYT theo TT04/2017/BYT tạm thời tách 2 dịch vụ đối với các vtyt có chi phí > quy định trong phụ lục 1 kèm thông tu
        public static bool ThanhToan_VTYT_TT04(int iddonct, double dongia)
            => ThanhToanProvider.ThanhToan_VTYT_TT04(iddonct, dongia);
        /// <summary>
        /// dùng để kiểm tra bệnh nhân đã cho vào viện nhưng nếu chưa phát sinh chi phí nào trong khoa (ht áp dụng cho 27021 và 01830)
        /// trả về true: nếu là bn bình thường; trả về false nếu là bệnh nhân vào viện nhưng chưa điều trị trong khoa
        /// </summary>
        /// <returns></returns>
        public static bool ktBNNoiNgoaiTru(int mabn)
            => BenhNhanProvider.KiemtraBenhnhanNoiNgoaitru(mabn);
        //
        public static bool ThanhToan(Hospital _dataContext, int _mabn, DateTime dtNgayTT, int _makptt)
            => ThanhToanProvider.SetThanhToan(_dataContext, _mabn, dtNgayTT, _makptt);
        
        private static void XoaRaVien(int _mabn)
        {
            Hospital data = new Hospital();
            RaVien qravien = data.RaViens.Where(parameters => parameters.MaBNhan == _mabn).FirstOrDefault();
            if (qravien != null)
            {
                data.RaViens.Remove(qravien);
                data.SaveChanges();
            }
        }

        #endregion

        public static void BKeBNDichVu_01071(int _mabn)
            => BangKeReportProvider.Demo1(_mabn);//BangKeReportProvider.BKeBNDichVu_01071(_mabn);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dataContext"></param>
        /// <param name="_mabn"></param>
        /// <param name="_maubk"> A4:4, A5:5, A4_new: 41</param>
        /// /// <param name="kieu"> 0: tự động, 1: theo mẫu</param>
        public static void BangkeTTBNDV_20001(int _mabn)
            => BangKeReportProvider.Demo2(_mabn);// BangKeReportProvider.BangkeTTBNDV_20001(_mabn);
        public static void In_BangKe01_02(Hospital _dataContext, int _mabn, int _maubk, int kieu)
            => BangKeReportProvider.Demo1(_dataContext, _mabn,_maubk, kieu);


        #region tinhmuc thanh toan
        /// <summary>
        /// Trả về giá trị mức hưởng  bảo hiểm y tế thanh toán
        /// </summary>
        /// <param name="muc">Lấy giá trị trong bảng MucTT (PTTT) tương ứng với mã Mức (Mã mức là ký tự thứ 3 trên thẻ BHYT </param>
        /// <param name="hangBV">trong bảng Bệnh viện. Khi nhập trên form sẽ nhập là hạng A, B,C,D tương ứng với hạng 1,2,3,4</param>
        /// <param name="tuyen">đúng tuyến hay trái tuyến (1: Đúng tuyến; 2: Trái tuyến</param>
        ///  /// <param name="noingoaitru">nội ngoại trú : 0: ngoại trú; 1= Nội trú</param>
        /// <returns></returns>
        public static double _getmuc(List<MucTT> _qmuc, int hangBV, string mathe, int tuyen, int noingoaitru, DateTime ngayTT)
            => ThanhToanProvider.GetMucThanhToan(_qmuc, hangBV, mathe, tuyen, noingoaitru, ngayTT);
        #endregion

        #region Indon
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_IDDon"></param>
        /// <param name="_IDBN"></param>
        /// <param name="maKP"></param>
        /// <param name="nhomduoc">"Thuốc thường", Hóa chất", "Vật tư y tế", "Thuốc gây nghiện", "Thuốc hướng tâm thần", "Thuốc trẻ em", "Thuốc đông y"</param>
        public static void InDon(int _IDDon, int _IDBN, int maKP)
            => DonThuocProvider.InDon(_IDDon, _IDBN, maKP);
        public static void InDonThuocTDuong(int mabn, int iddon)
            => DonThuocProvider.InDonThuocTDuong(mabn, iddon);
        #endregion


        #region kiểm tra đối tượng BHYT
        public static void _set_dtBHYT()
            => CommonHelper.SetDoiTuongBHYT();
        #endregion

        #region thêm tiền phụ thu vào DThuocct
        public static bool _InsertPhuThu(Hospital _data, int _IDDThuoct, double _GiaPhuThu)

            => DonThuocProvider.ThemPhuThu(_data, _IDDThuoct, _GiaPhuThu);

        #endregion
        #region Update_Delete_CongKham
        public static string maCKham_CKhoa(int mack)
            => ChuyenKhoaProvider.GetMaCongKham_ChuyenKhoa(mack);
        /// <summary>
        /// Kiểm tra xem công khám có được thiết lập đúng hay ko
        /// </summary>
        /// <param name="loai">Trường loại trong bảng dịch vụ: ID đối tượng bệnh nhân</param>
        /// <param name="boolTheoChuyenKhoa">true: Công khám được set theo chuyên khoa ; false: Công khám không set theo chuyên khoa mà do bệnh viện tự thiết lập theo từng khoa phòng</param>

        /// <param name="MaQD">Mã QD trong danh mục dịch vụ</param>
        /// <param name="MaCK">Mã chuyên khoa</param>      
        /// <returns></returns>
        public static bool checkCongKham(int? loai, bool boolTheoChuyenKhoa, string MaQD, int MaCK)
            => CongKhamProvider.KiemtraThietlapCongkham(loai, boolTheoChuyenKhoa, MaQD, MaCK);

        public static bool CheckCuoiTuan(DateTime dt)
            => CommonHelper.isWeekend(dt);
        /// <summary>
        /// Lấy mã công khám tự động được thiết lập
        /// </summary>
        /// <param name="_maBN"></param>
        /// <param name="idkb">id khám bệnh</param>
        /// <param name="thoigiantaoCK">Thời gian tạo công khám</param>
        /// <returns></returns>
        public static int GetMackham_ck(int _maBN, int idkb, DateTime thoigiantaoCK)
            => CongKhamProvider.GetCongKham_ChuyenKhoa(_maBN, idkb, thoigiantaoCK);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_maBN"></param>
        /// <param name="idkb"></param>
        /// <param name="update">1: update, 0:delete</param>
        /// <returns></returns>
        public static bool Update_Delete_CongKham(int _maBN, int idkb, bool update, DateTime ngaychidinh)
            => CongKhamProvider.Update_Delete_CongKham(_maBN, idkb, update, ngaychidinh);
        #endregion
        #region Nâng cấp giao diện
        public static bool updateGiaoDien()
        {
            string _duongdan = System.IO.Directory.GetCurrentDirectory();
            return true;
        }
        #endregion
        #region đóng ứng dụng
        public static void _closeApp(string namefile)
        {
            try
            {
                foreach (System.Diagnostics.Process item in System.Diagnostics.Process.GetProcessesByName(namefile))//nameProcess
                {
                    try
                    {
                        item.Kill();
                        item.WaitForExit();
                    }
                    catch (Win32Exception ex) { }
                    catch (InvalidOperationException ex1) { }
                }
            }
            catch
            {

            }
        }
        #endregion
        #region mở ứng dụng
        public static void _openApp(string filepath, string filename)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo("C:\\Program Files\\");
                FileInfo[] fi = di.GetFiles(filename, SearchOption.AllDirectories);
                if (fi.Count() <= 0)
                {
                    di = new DirectoryInfo("C:\\Program Files (x86)\\");
                    fi = di.GetFiles(filename, SearchOption.AllDirectories);
                }
                string path = "";

                foreach (FileInfo file in fi)
                {
                    path = file.DirectoryName + "\\" + filename;

                }
                if (!string.IsNullOrEmpty(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                return;
            }
            catch (Exception)
            {
                // MessageBox.Show("lỗi");
            }

        }
        #endregion
        #region get % BHYT thanh toán
        public static double BHTT(int madv)
            => DichVuProvider.BHTT(madv);
        #endregion
        /// <summary>
        /// Trả về thông báo bệnh nhân đã khám trong ngày hoặc trong tháng
        /// </summary>
        /// <param name="mabnhan">Mã bệnh nhân</param> 
        /// 

        public static List<Gia_SoLo_HanSuDung> _getDSGia(Hospital data, int maDV, int makho)
            => DichVuProvider._getDSGia(data, maDV, makho);
        private string checkSoLanKham(int mabnhan)
            => KhamBenhProvider.KiemtraSoLanKham(mabnhan);
        /// <summary>
        /// trả về chuổi đã bỏ đi các dấu ";" thừa; VD: 25; abc;;56 => 25; abc;56
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        public static string FreshString(string chuoi)
            => FormatHelper.FreshString(chuoi);

        /// <summary>
        /// Lay gia mac dinh trong bang DonGiaDV
        /// </summary>
        /// <param name="DaTaContext"></param>
        /// <param name="madv"></param>
        /// <param name="nhapxuat"> 1: nhaapj; 2 xuaats</param>
        /// <returns></returns>
        public static double _getGiaSD(Hospital data, int madv, double dongiaSD, int trongBH, int nhapxuat, int maKP, DateTime ngayke)
            => DichVuProvider.GetGiaSudung(data, madv, dongiaSD, trongBH, nhapxuat, maKP, ngayke);


        //internal static List<DonGiaDV> _getGiaSD(Hospital data, int madv)
        //{
        //    try
        //    {
        //        double rs = 0;
        //        var qdongia = data.DonGiaDVs.Where(p => p.MaDV == madv && p.Status == true).ToList();
        //        return qdongia;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.InnerException.ToString());
        //        return new List<DonGiaDV>();

        //    }

        //}

        #region lấy số PL
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ploai"></param>
        /// <param name="maKP"></param>
        /// <param name="noiNgoaiTru"></param>
        /// <returns></returns>
        public static int GetSoPL(int ploai, int maKP, int noiNgoaiTru)
            => PhieuLinhProvider.GetSoPL(ploai, maKP, noiNgoaiTru);
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="maKP"></param>
        /// <param name="_soPL"></param>
        /// <param name="ploai"></param>
        /// <param name="noiNgoaiTru">-1: Không setl 0: set theo ngoại trú: 1: set theo nội trú</param>
        /// <returns></returns>
        public static bool SetSoPL(int maKP, int _soPL, int ploai, int noiNgoaiTru)
            => PhieuLinhProvider.SetSoPL(maKP, _soPL, ploai, noiNgoaiTru);

        // khi xóa
        public static bool SetStatusSoPL(int maKP, int _soPL, int ploai, int noiNgoaiTru)
            => PhieuLinhProvider.SetStatusSoPL(maKP, _soPL, ploai, noiNgoaiTru);
        public static bool checkSoPL(int maKP, int _soPL, int ploai, int noiNgoaiTru)
            => PhieuLinhProvider.CheckSoPL(maKP, _soPL, ploai, noiNgoaiTru);


        /// <summary>
        /// Lấy giá nhập cho bệnh viện 30340 khi biết giá xuất, trong BH
        /// </summary>
        /// <param name="maDV"></param>
        /// <param name="DonGiaX">đơn giá xuất</param>
        /// <returns></returns>
        public static double getGiaNhapByGiaXuat(int? maDV, double DonGiaX, int trongBH)
            => PriceProvider.GetGiaNhapByGiaXuat(maDV, DonGiaX, trongBH);

        //số phiếu theo y/c 27183
        public static string _idphieutheokp(int _Ploai, int _MaKP)
            => NhapDuocProvider.GetIdPhieuTeoKhoaphong(_Ploai, _MaKP);

        /// <summary>
        /// insert vào bảng HSHuy khi hủy các số vào viện, ssos bệnh án,, số PL...
        /// </summary>
        /// <param name="makpvv"></param>
        /// <param name="so"></param>
        /// <param name="ploai">1: số PL; 2: số vào viện; 3: số khám bệnh; 4: số bệnh án; 5: số chuyển viện; 6: Số TT trong ngày (270001); 7: số lưu trữ (số hồ sơ); 8: Mã y tế; 9: Số ra viện</param>
        /// <param name="noingoaitru">-1:  ko set; 0: ngoại trú trú; 1: nội trú</param>
        public static void UpdateHSHuy(int mabn, int makpvv, string so, int ploai, int noingoaitru)
        {
            //Hospital data = new Hospital(DungChung.Bien.StrCon);
            //HSHuy moi = new HSHuy();
            //moi.MaBN = mabn;
            //moi.MaKP = makpvv;
            //moi.NgayHuy = DateTime.Now;
            //moi.MaCB = DungChung.Bien.MaCB;
            //moi.PLoai = ploai;
            //moi.SoHuy = so;
            //moi.NoiTru = noingoaitru;
            //data.HSHuys.AddObject(moi);
            //data.SaveChanges();
        }
        #region Tong tien bn phair tra
        public static double SoTienCanThu(int _MaBn)
            => ThanhToanProvider.GetSoTienCanThu(_MaBn);
        #endregion
        public static double TienBNTraThem(Hospital _data, int _MaBN)
            => ThanhToanProvider.GetSoTienBNTraThem(_data, _MaBN);
        public static double TongTienTU(Hospital _data, int _MaBN)
            => ThanhToanProvider.GetTongTienTamUng(_data, _MaBN);
        public static bool _CheckThucHienDVDaTamThu(Hospital _data, int _MaBN, int _IDTamUngct)
            => ThuChiTamUngProvider.KiemtraThucHienDVDaTamThu(_data, _MaBN, _IDTamUngct);
        public static string _KiemTraThoiGianCDCLS(Hospital _data, int _MaBN)
            => CanLamSangProvider.KiemTraThoiGianCDCLS(_data, _MaBN);
        public static void XoaTamUngct(Hospital _data, int _MaBn, int _IDTamUngct)
            => ThuChiTamUngProvider.XoaTamUngct(_data, _MaBn, _IDTamUngct);

    }
}
