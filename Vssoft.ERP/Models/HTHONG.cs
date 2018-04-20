namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HTHONG")]
    public partial class HTHONG
    {
        [Key]
        [StringLength(10)]
        public string MaCB { get; set; }

        public int? PPXuat { get; set; }

        [StringLength(50)]
        public string KeToanTruong { get; set; }

        [StringLength(50)]
        public string GiamDoc { get; set; }
        public string MauIn { get; set; }

        [StringLength(50)]
        public string TruongKhoaDuoc { get; set; }

        [StringLength(50)]
        public string TruongKhoaLS { get; set; }

        [StringLength(50)]
        public string KeToanVP { get; set; }

        [StringLength(50)]
        public string ThuKho { get; set; }

        public int? GHanTT100 { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string TenCQCQ { get; set; }

        [StringLength(250)]
        public string NguoiLapBieu { get; set; }

        [StringLength(50)]
        public string GiamDinhBH { get; set; }

        [StringLength(50)]
        public string MaNganSach { get; set; }

        [StringLength(100)]
        public string FormatString { get; set; }

        [StringLength(50)]
        public string KieuDoc { get; set; }

        public int? MaKho { get; set; }

        [StringLength(20)]
        public string GioTu { get; set; }

        [StringLength(20)]
        public string GioDen { get; set; }

        [StringLength(250)]
        public string TenCQBH { get; set; }

        [StringLength(250)]
        public string TenCQCQBH { get; set; }

        public int? InPhoi { get; set; }

        [StringLength(250)]
        public string DuongDan { get; set; }

        [StringLength(50)]
        public string KeToanVPdv { get; set; }

        [StringLength(50)]
        public string DiaDanh { get; set; }

        [StringLength(250)]
        public string TenCQrg { get; set; }

        [StringLength(250)]
        public string NangCap { get; set; }

        public int? LamTron { get; set; }

        [StringLength(50)]
        public string GiamDinhBH2 { get; set; }

        public int? FormatDate { get; set; }

        public int? GetICD { get; set; }

        [StringLength(10)]
        public string FormatAge { get; set; }

        [StringLength(50)]
        public string KeToanVPnt { get; set; }

        [Required]
        [StringLength(50)]
        public string MaBV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaMoi { get; set; }

        public int HDSDThuoc { get; set; }
    }
}
