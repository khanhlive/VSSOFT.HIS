namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiPhiDV")]
    public partial class ChiPhiDV
    {
        public int Id { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(50)]
        public string TenBNhan { get; set; }

        public int? GTinh { get; set; }

        [StringLength(250)]
        public string DChi { get; set; }

        [StringLength(10)]
        public string DTuong { get; set; }

        [StringLength(20)]
        public string SThe { get; set; }

        [StringLength(10)]
        public string MaCS { get; set; }

        public int? Tuyen { get; set; }

        public int? NoiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanBHTu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanBHDen { get; set; }

        [StringLength(4)]
        public string NamSinh { get; set; }

        public int? TuyenDuoi { get; set; }

        public DateTime? NgayRa { get; set; }

        [StringLength(10)]
        public string MaICD { get; set; }

        public int? MaKP { get; set; }

        [StringLength(2)]
        public string MaDTuong { get; set; }

        [StringLength(10)]
        public string Nhom { get; set; }

        public DateTime? NgayTT { get; set; }

        public int? NoiTru { get; set; }

        public double? Thuoc { get; set; }

        public double? CDHA { get; set; }

        public double? CongKham { get; set; }

        public double? XetNghiem { get; set; }

        public double? Mau { get; set; }

        public double? TTPT { get; set; }

        public double? VTYTTH { get; set; }

        public double? VTYT_tl { get; set; }

        public double? DVKT_tl { get; set; }

        public double? Thuoc_tl { get; set; }

        public double? CPVanChuyen { get; set; }

        public double? ThanhTien { get; set; }

        public double? TienBN { get; set; }

        public double? TienBH { get; set; }

        public int idVPhi { get; set; }

        public DateTime? NgayVao { get; set; }

        public int? SoNgaydt { get; set; }

        public double? TienNgayGiuong { get; set; }

        public int? CapCuu { get; set; }

        public int? TrongBH { get; set; }

        public int? MaDV { get; set; }

        public double? DonGia { get; set; }

        public double? SoLuong { get; set; }

        public DateTime? NgayUpdate { get; set; }

        public bool? Status { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public bool? DTNT { get; set; }

        [StringLength(2)]
        public string KhuVuc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LuongCS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MucHuong { get; set; }

        [StringLength(250)]
        public string ChanDoan { get; set; }

        [StringLength(10)]
        public string MaBVtd { get; set; }
    }
}
