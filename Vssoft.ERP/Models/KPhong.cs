namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KPhong")]
    public partial class KPhong
    {
        [StringLength(50)]
        public string TenKP { get; set; }

        [StringLength(50)]
        public string PLoai { get; set; }

        [StringLength(250)]
        public string DChi { get; set; }

        public int? Status { get; set; }

        public int? NhomKP { get; set; }

        public int? TrongBV { get; set; }

        [StringLength(50)]
        public string ChuyenKhoa { get; set; }

        public int? PPXuat { get; set; }

        public int? QuanLy { get; set; }

        [StringLength(500)]
        public string BuongGiuong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaQD { get; set; }

        [StringLength(10)]
        public string MaKPBackUp { get; set; }

        [Key]
        public int MaKP { get; set; }

        public int MaCK { get; set; }

        public bool TuTruc { get; set; }

        public byte PPHHDY { get; set; }

        [Required]
        [StringLength(250)]
        public string MaBVsd { get; set; }
    }
}
