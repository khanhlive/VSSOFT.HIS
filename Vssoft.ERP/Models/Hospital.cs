namespace Vssoft.ERP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Hospital : DbContext
    {
        public Hospital()
            : base("name=Hospital")
        {
        }

        public virtual DbSet<C5084> C5084 { get; set; }
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<Bang20> Bang20 { get; set; }
        public virtual DbSet<Bang79a> Bang79a { get; set; }
        public virtual DbSet<BBHC> BBHCs { get; set; }
        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<BenhVien> BenhViens { get; set; }
        public virtual DbSet<BNBHYT> BNBHYTs { get; set; }
        public virtual DbSet<BNKB> BNKBs { get; set; }
        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<CapBac> CapBacs { get; set; }
        public virtual DbSet<CBICD> CBICDs { get; set; }
        public virtual DbSet<ChiDinh> ChiDinhs { get; set; }
        public virtual DbSet<ChiPhiDV> ChiPhiDVs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChuyenKhoa> ChuyenKhoas { get; set; }
        public virtual DbSet<CL> CLS { get; set; }
        public virtual DbSet<CLSct> CLScts { get; set; }
        public virtual DbSet<DanToc> DanTocs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DichVuct> DichVucts { get; set; }
        public virtual DbSet<DichVuEx> DichVuExes { get; set; }
        public virtual DbSet<DienBien> DienBiens { get; set; }
        public virtual DbSet<DmHuyen> DmHuyens { get; set; }
        public virtual DbSet<DmTinh> DmTinhs { get; set; }
        public virtual DbSet<DmXa> DmXas { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<DTBN> DTBNs { get; set; }
        public virtual DbSet<DThuoc> DThuocs { get; set; }
        public virtual DbSet<DThuocct> DThuoccts { get; set; }
        public virtual DbSet<DTuong> DTuongs { get; set; }
        public virtual DbSet<DuongDung> DuongDungs { get; set; }
        public virtual DbSet<DuTru> DuTrus { get; set; }
        public virtual DbSet<DuTruct> DuTructs { get; set; }
        public virtual DbSet<DVMoi> DVMois { get; set; }
        public virtual DbSet<GiaUT> GiaUTs { get; set; }
        public virtual DbSet<HoiDong> HoiDongs { get; set; }
        public virtual DbSet<HoTro> HoTroes { get; set; }
        public virtual DbSet<HTHONG> HTHONGs { get; set; }
        public virtual DbSet<KHO> KHOes { get; set; }
        public virtual DbSet<KhoaDL> KhoaDLs { get; set; }
        public virtual DbSet<KPhong> KPhongs { get; set; }
        public virtual DbSet<KQMau> KQMaus { get; set; }
        public virtual DbSet<MBICD> MBICDs { get; set; }
        public virtual DbSet<MenuBC> MenuBCs { get; set; }
        public virtual DbSet<MucTT> MucTTs { get; set; }
        public virtual DbSet<NhaCC> NhaCCs { get; set; }
        public virtual DbSet<NhapD> NhapDs { get; set; }
        public virtual DbSet<NhapDct> NhapDcts { get; set; }
        public virtual DbSet<NhomDV> NhomDVs { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PhanUngT> PhanUngTs { get; set; }
        public virtual DbSet<PhieuLinh> PhieuLinhs { get; set; }
        public virtual DbSet<PhieuLinhct> PhieuLinhcts { get; set; }
        public virtual DbSet<RaVien> RaViens { get; set; }
        public virtual DbSet<SoBienLai> SoBienLais { get; set; }
        public virtual DbSet<SoTT> SoTTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiSan> TaiSans { get; set; }
        public virtual DbSet<TamUng> TamUngs { get; set; }
        public virtual DbSet<TamUngct> TamUngcts { get; set; }
        public virtual DbSet<TDinh> TDinhs { get; set; }
        public virtual DbSet<TDinhct> TDinhcts { get; set; }
        public virtual DbSet<TieuNhomDV> TieuNhomDVs { get; set; }
        public virtual DbSet<TTboXung> TTboXungs { get; set; }
        public virtual DbSet<VaoVien> VaoViens { get; set; }
        public virtual DbSet<VienPhi> VienPhis { get; set; }
        public virtual DbSet<VienPhict> VienPhicts { get; set; }
        public virtual DbSet<XuatD> XuatDs { get; set; }
        public virtual DbSet<XuatDct> XuatDcts { get; set; }
        public virtual DbSet<ICD10> ICD10 { get; set; }
        public virtual DbSet<ICD10_2465> ICD10_2465 { get; set; }
        public virtual DbSet<ICD11> ICD11 { get; set; }
        public virtual DbSet<SDT> SDTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C5084>()
                .Property(e => e.SoDangKy)
                .IsUnicode(false);

            modelBuilder.Entity<C5084>()
                .Property(e => e.MaDV)
                .IsUnicode(false);

            modelBuilder.Entity<C5084>()
                .Property(e => e.NguonGoc)
                .IsUnicode(false);

            modelBuilder.Entity<C5084>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<C5084>()
                .Property(e => e.MaDuongDung)
                .IsUnicode(false);

            modelBuilder.Entity<C5084>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<C5084>()
                .Property(e => e.TheTichThuc)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MaDVsd)
                .IsUnicode(false);

            modelBuilder.Entity<Bang20>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<Bang20>()
                .Property(e => e.MaQD)
                .IsUnicode(false);

            modelBuilder.Entity<Bang79a>()
                .Property(e => e.SThe)
                .IsUnicode(false);

            modelBuilder.Entity<Bang79a>()
                .Property(e => e.MaCS)
                .IsUnicode(false);

            modelBuilder.Entity<Bang79a>()
                .Property(e => e.NamSinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bang79a>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<Bang79a>()
                .Property(e => e.MaDTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BBHC>()
                .Property(e => e.Buong)
                .IsUnicode(false);

            modelBuilder.Entity<BBHC>()
                .Property(e => e.Giuong)
                .IsUnicode(false);

            modelBuilder.Entity<BBHC>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<BBHC>()
                .Property(e => e.MaCBtk)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.SThe)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaCS)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.NgaySinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.ThangSinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.NamSinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaBV)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MucHuong)
                .HasPrecision(1, 0);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.KhuVuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.LuongCS)
                .HasPrecision(1, 0);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaDTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.Ma_lk)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaKCB)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<BenhVien>()
                .Property(e => e.MaBV)
                .IsUnicode(false);

            modelBuilder.Entity<BenhVien>()
                .Property(e => e.MaTinh)
                .IsUnicode(false);

            modelBuilder.Entity<BenhVien>()
                .Property(e => e.MaHuyen)
                .IsUnicode(false);

            modelBuilder.Entity<BenhVien>()
                .Property(e => e.MaChuQuan)
                .IsUnicode(false);

            modelBuilder.Entity<BNBHYT>()
                .Property(e => e.SThe)
                .IsUnicode(false);

            modelBuilder.Entity<BNBHYT>()
                .Property(e => e.MaCS)
                .IsUnicode(false);

            modelBuilder.Entity<BNKB>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<BNKB>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<BNKB>()
                .Property(e => e.MaICD2)
                .IsUnicode(false);

            modelBuilder.Entity<CanBo>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<CanBo>()
                .Property(e => e.SoDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CanBo>()
                .Property(e => e.MaDT)
                .IsUnicode(false);

            modelBuilder.Entity<CanBo>()
                .Property(e => e.FileAnh)
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.SThe)
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.MaCS)
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.NamSinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.MaDTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.KhuVuc)
                .IsFixedLength();

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.LuongCS)
                .HasPrecision(1, 0);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.MucHuong)
                .HasPrecision(1, 0);

            modelBuilder.Entity<ChiPhiDV>()
                .Property(e => e.MaBVtd)
                .IsUnicode(false);

            modelBuilder.Entity<CL>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<CL>()
                .Property(e => e.MaCBth)
                .IsUnicode(false);

            modelBuilder.Entity<CL>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CL>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<CLSct>()
                .Property(e => e.MaDVct)
                .IsUnicode(false);

            modelBuilder.Entity<CLSct>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<DanToc>()
                .Property(e => e.MaDT)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.TinhTNhap)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.NguonGoc)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.YCSD)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDuongDung)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.SoQD)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDVBackUp)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaKPsd)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaATC)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaHC)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.DSDonGia)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuct>()
                .Property(e => e.MaDVct)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuct>()
                .Property(e => e.TSnTu)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuct>()
                .Property(e => e.TSnDen)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuct>()
                .Property(e => e.TSnuTu)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuct>()
                .Property(e => e.TSnuDen)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuct>()
                .Property(e => e.TSBTn)
                .IsUnicode(false);

            modelBuilder.Entity<DichVuEx>()
                .Property(e => e.MaATC)
                .IsUnicode(false);

            modelBuilder.Entity<DienBien>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<DmHuyen>()
                .Property(e => e.MaHuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DmHuyen>()
                .Property(e => e.MaTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DmTinh>()
                .Property(e => e.MaTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DmXa>()
                .Property(e => e.MaXa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DmXa>()
                .Property(e => e.MaTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DmXa>()
                .Property(e => e.MaHuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DThuoc>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<DThuocct>()
                .Property(e => e.SoLan)
                .IsUnicode(false);

            modelBuilder.Entity<DThuocct>()
                .Property(e => e.Luong)
                .IsUnicode(false);

            modelBuilder.Entity<DThuocct>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<DThuocct>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<DTuong>()
                .Property(e => e.MaDTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DuongDung>()
                .Property(e => e.MaDuongDung)
                .IsUnicode(false);

            modelBuilder.Entity<DuTru>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<DuTruct>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<DVMoi>()
                .Property(e => e.SoQD)
                .IsUnicode(false);

            modelBuilder.Entity<HoiDong>()
                .Property(e => e.LoaiBB)
                .IsUnicode(false);

            modelBuilder.Entity<HoTro>()
                .Property(e => e.SoDT1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoTro>()
                .Property(e => e.SoDT2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.MaNganSach)
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.FormatString)
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.GioTu)
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.GioDen)
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.FormatAge)
                .IsUnicode(false);

            modelBuilder.Entity<HTHONG>()
                .Property(e => e.MaBV)
                .IsUnicode(false);

            modelBuilder.Entity<KHO>()
                .Property(e => e.MSKHO)
                .IsUnicode(false);

            modelBuilder.Entity<KhoaDL>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<KhoaDL>()
                .Property(e => e.MaKho)
                .IsUnicode(false);

            modelBuilder.Entity<KPhong>()
                .Property(e => e.MaQD)
                .IsUnicode(false);

            modelBuilder.Entity<KPhong>()
                .Property(e => e.MaKPBackUp)
                .IsUnicode(false);

            modelBuilder.Entity<KPhong>()
                .Property(e => e.MaBVsd)
                .IsUnicode(false);

            modelBuilder.Entity<KQMau>()
                .Property(e => e.MaKQ)
                .IsUnicode(false);

            modelBuilder.Entity<MBICD>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<MBICD>()
                .Property(e => e.DS_MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<MucTT>()
                .Property(e => e.MaMuc)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCC>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCC>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhapD>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhapD>()
                .Property(e => e.MaXP)
                .IsUnicode(false);

            modelBuilder.Entity<NhapD>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<NhapDct>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.SThe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MaDTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MaCS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MaTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MaHuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.MaXa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.NgaySinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.ThangSinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.KhuVuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhanUngT>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuLinh>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<RaVien>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<RaVien>()
                .Property(e => e.MaBVC)
                .IsUnicode(false);

            modelBuilder.Entity<RaVien>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<RaVien>()
                .Property(e => e.SoLT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RaVien>()
                .Property(e => e.MaYTe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RaVien>()
                .Property(e => e.DTuongManTinh)
                .IsFixedLength();

            modelBuilder.Entity<SoBienLai>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<TamUng>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<TamUng>()
                .Property(e => e.QuyenHD)
                .IsUnicode(false);

            modelBuilder.Entity<TamUng>()
                .Property(e => e.SoHD)
                .IsUnicode(false);

            modelBuilder.Entity<TDinh>()
                .Property(e => e.MaCS)
                .IsUnicode(false);

            modelBuilder.Entity<TDinh>()
                .Property(e => e.SThe)
                .IsUnicode(false);

            modelBuilder.Entity<TDinh>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.SoKSinh)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.MaTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.MaHuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.MaXa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.MaDT)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.DThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.DThoaiNT)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.CMT)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.MaNN)
                .IsUnicode(false);

            modelBuilder.Entity<TTboXung>()
                .Property(e => e.FileAnh)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.Mach)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.NhietDo)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.HuyetAp)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.NhipTho)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.CanNang)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.SoBA)
                .IsUnicode(false);

            modelBuilder.Entity<VaoVien>()
                .Property(e => e.SoVV)
                .IsUnicode(false);

            modelBuilder.Entity<VienPhi>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<VienPhi>()
                .Property(e => e.MaGD_BHXH)
                .IsUnicode(false);

            modelBuilder.Entity<XuatD>()
                .Property(e => e.MaBNhan)
                .IsUnicode(false);

            modelBuilder.Entity<XuatD>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<XuatDct>()
                .Property(e => e.MaDuoc)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10>()
                .Property(e => e.MSCB)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10>()
                .Property(e => e.MaICD10)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.STTChuong)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaChuong)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.TenChuongE)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.TenNhomE)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaNhomPhu1)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.TenNhomPhu1E)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaNhomPhu2)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.TenNhomPhu2E)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.TenLoaiE)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaBenh)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.TenBenhE)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaNhomBCBYT)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaCt)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10_2465>()
                .Property(e => e.MaTH)
                .IsUnicode(false);

            modelBuilder.Entity<ICD11>()
                .Property(e => e.MaICD)
                .IsUnicode(false);

            modelBuilder.Entity<ICD11>()
                .Property(e => e.MSCB)
                .IsUnicode(false);

            modelBuilder.Entity<SDT>()
                .Property(e => e.MaCB)
                .IsUnicode(false);

            modelBuilder.Entity<SDT>()
                .Property(e => e.PLoai)
                .IsUnicode(false);
        }
    }
}
