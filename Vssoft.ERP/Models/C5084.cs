namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("5084")]
    public partial class C5084
    {
        [Key]
        public int idDichVu { get; set; }

        public int? Bang { get; set; }

        [StringLength(350)]
        public string TenDV { get; set; }

        [StringLength(300)]
        public string HamLuong { get; set; }

        public int? IDHC { get; set; }

        [StringLength(200)]
        public string BaoChe { get; set; }

        [StringLength(500)]
        public string DongGoi { get; set; }

        [StringLength(100)]
        public string TieuChuan { get; set; }

        [StringLength(50)]
        public string TuoiTho { get; set; }

        [StringLength(100)]
        public string SoDangKy { get; set; }

        [StringLength(100)]
        public string MaDV { get; set; }

        public int? MaCtySX { get; set; }

        public int? MaCtyDk { get; set; }

        [StringLength(10)]
        public string NguonGoc { get; set; }

        public int? STT_ThongTu { get; set; }

        [StringLength(20)]
        public string MaNhom { get; set; }

        [StringLength(20)]
        public string MaDuongDung { get; set; }

        public int? STTNhom { get; set; }

        [StringLength(20)]
        public string MaKhoa { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string TheTichThuc { get; set; }

        [StringLength(500)]
        public string HoatChat { get; set; }

        [StringLength(500)]
        public string congtysx { get; set; }

        [StringLength(50)]
        public string Nuoc { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(500)]
        public string congtydangky { get; set; }

        [StringLength(50)]
        public string Nuocdk { get; set; }

        [StringLength(500)]
        public string DiaChiDK { get; set; }

        [StringLength(500)]
        public string Nhom { get; set; }

        public byte TrongDM { get; set; }
    }
}
