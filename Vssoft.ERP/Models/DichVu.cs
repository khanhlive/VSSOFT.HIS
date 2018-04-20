namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [StringLength(350)]
        public string TenDV { get; set; }

        public int? IDNhom { get; set; }

        [StringLength(500)]
        public string HamLuong { get; set; }
        public string DSDTBN { get; set; }

        [StringLength(100)]
        public string DonVi { get; set; }
        public int? LThuoc { get; set; }
        
        public string NhomThau { get; set; }
        public double GiaPhuThu { get; set; }

        public int? LThau { get; set; }

        public double DonGiaDV2 { get; set; }

        public double DonGia { get; set; }
        public double GiaBHGioiHanTT { get; set; }

        public int? TrongDM { get; set; }

        public int? Status { get; set; }

        public int? Loai { get; set; }

        public int? BHTT { get; set; }

        public int? DVKTC { get; set; }

        public int? PLoai { get; set; }

        public string TenHC { get; set; }

        [StringLength(500)]
        public string NuocSX { get; set; }

        [StringLength(50)]
        public string DuongD { get; set; }

        public int? IdTieuNhom { get; set; }

        [StringLength(300)]
        public string SoDK { get; set; }

        [StringLength(200)]
        public string DangBC { get; set; }

        [StringLength(500)]
        public string NhaSX { get; set; }

        [StringLength(50)]
        public string QCPC { get; set; }

        public int? BHYT { get; set; }

        [StringLength(100)]
        public string MaQD { get; set; }

        [StringLength(300)]
        public string TenRG { get; set; }

        [StringLength(2)]
        public string TinhTNhap { get; set; }

        [StringLength(4)]
        public string NguonGoc { get; set; }

        [StringLength(2)]
        public string YCSD { get; set; }

        public double? TyLeSP { get; set; }

        public double? TyLeBQ { get; set; }

        [StringLength(250)]
        public string BPDung { get; set; }

        public int? DongY { get; set; }

        [StringLength(50)]
        public string PhuongPhap { get; set; }

        [StringLength(10)]
        public string MaCC { get; set; }

        public int? SoTT { get; set; }

        public double? DonGia2 { get; set; }

        [StringLength(20)]
        public string SoTTqd { get; set; }

        public int? SLMin { get; set; }

        [StringLength(100)]
        public string DonViN { get; set; }

        public int TyLeSD { get; set; }

        [StringLength(20)]
        public string MaTam { get; set; }

        [StringLength(100)]
        public string TieuChuan { get; set; }

        [StringLength(50)]
        public string TuoiTho { get; set; }

        [StringLength(20)]
        public string MaNhom { get; set; }

        [StringLength(20)]
        public string MaDuongDung { get; set; }

        public double? SLuong { get; set; }

        [StringLength(20)]
        public string SoQD { get; set; }

        public DateTime? NgayQD { get; set; }

        public int? MaCTySX { get; set; }

        public int? MaCTyDK { get; set; }

        [StringLength(10)]
        public string MaDVBackUp { get; set; }

        [Key]
        public int MaDV { get; set; }

        [StringLength(300)]
        public string MaKPsd { get; set; }

        public int? DinhMuc { get; set; }

        [StringLength(30)]
        public string MaATC { get; set; }

        public double? DongiaT7 { get; set; }

        [StringLength(20)]
        public string MaHC { get; set; }

        public double DonGiaBHYT { get; set; }

        [Required]
        [StringLength(250)]
        public string DSDonGia { get; set; }
    }
}
