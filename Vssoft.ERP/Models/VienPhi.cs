namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VienPhi")]
    public partial class VienPhi
    {
        [Key]
        public int idVPhi { get; set; }

        public DateTime? NgayTT { get; set; }

        public int? MaBNhan { get; set; }

        public int? MaKP { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public int? Duyet { get; set; }

        [StringLength(250)]
        public string LyDo { get; set; }

        public int? NgoaiGio { get; set; }

        public int? Status { get; set; }

        public DateTime? NgayDuyet { get; set; }

        public bool Export { get; set; }

        public DateTime? NgayRa { get; set; }

        public bool ExportBHXH { get; set; }

        public bool ExportBYT { get; set; }

        [StringLength(50)]
        public string MaGD_BHXH { get; set; }

        public DateTime? NgayNhap { get; set; }
    }
}
