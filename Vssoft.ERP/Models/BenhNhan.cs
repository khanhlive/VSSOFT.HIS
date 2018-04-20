namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        public int? Tuoi { get; set; }

        public int? GTinh { get; set; }

        [StringLength(250)]
        public string DChi { get; set; }

        [StringLength(10)]
        public string DTuong { get; set; }

        public DateTime? NNhap { get; set; }

        [StringLength(20)]
        public string SThe { get; set; }

        [StringLength(10)]
        public string MaCS { get; set; }

        public int? NoiTru { get; set; }

        [StringLength(250)]
        public string TChung { get; set; }

        public int? MaKP { get; set; }

        public int? Tuyen { get; set; }

        [StringLength(250)]
        public string CDNoiGT { get; set; }

        public int? CapCuu { get; set; }

        public int? NoiTinh { get; set; }

        public int? SoTT { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanBHTu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanBHDen { get; set; }

        [StringLength(2)]
        public string NgaySinh { get; set; }

        [StringLength(2)]
        public string ThangSinh { get; set; }

        [StringLength(4)]
        public string NamSinh { get; set; }

        [StringLength(10)]
        public string MaBV { get; set; }

        [StringLength(50)]
        public string ChuyenKhoa { get; set; }

        [StringLength(250)]
        public string TenBNhan { get; set; }

        public int? NgoaiGio { get; set; }

        public int? TuyenDuoi { get; set; }

        public int? SoKB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MucHuong { get; set; }

        [StringLength(2)]
        public string KhuVuc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LuongCS { get; set; }

        public bool? UuTien { get; set; }

        public bool DTNT { get; set; }

        [StringLength(2)]
        public string MaDTuong { get; set; }

        public int? IDPerson { get; set; }

        public bool NoThe { get; set; }

        public byte IDDTBN { get; set; }

        [StringLength(50)]
        public string Ma_lk { get; set; }

        [Key]
        public int MaBNhan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKCB { get; set; }

        public bool Export { get; set; }

        public int? Normal { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }
    }
}
