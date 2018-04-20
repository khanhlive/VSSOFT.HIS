namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DThuoc")]
    public partial class DThuoc
    {
        [Key]
        public int IDDon { get; set; }

        public int? MaKP { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public int? Status { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public int? MaKXuat { get; set; }

        public int? PLDV { get; set; }

        public DateTime? NgayKe { get; set; }

        public int? KieuDon { get; set; }

        public int? LoaiDuoc { get; set; }

        public int? SoPL { get; set; }
    }
}
