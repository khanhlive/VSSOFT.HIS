namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BNKB")]
    public partial class BNKB
    {
        [Key]
        public int IDKB { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(250)]
        public string ChanDoan { get; set; }

        [StringLength(10)]
        public string MaICD { get; set; }

        public int? MaKP { get; set; }

        public DateTime? NgayKham { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public int? PhuongAn { get; set; }

        public int? MaKPdt { get; set; }

        [StringLength(100)]
        public string BenhKhac { get; set; }

        [StringLength(15)]
        public string Buong { get; set; }

        [StringLength(10)]
        public string Giuong { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string ChuyenKhoa { get; set; }

        [StringLength(10)]
        public string MaICD2 { get; set; }

        public DateTime? NgayHen { get; set; }

        public DateTime? NgayNghi { get; set; }

        public int MaCK { get; set; }
    }
}
