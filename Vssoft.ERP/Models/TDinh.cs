namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TDinh")]
    public partial class TDinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBNhan { get; set; }

        [StringLength(50)]
        public string TenBNhan { get; set; }

        public int? NoiTinh { get; set; }

        public int? Tuyen { get; set; }

        [StringLength(10)]
        public string MaCS { get; set; }

        public int? Tuoi { get; set; }

        public int? GTinh { get; set; }

        public int? DTuong { get; set; }

        [StringLength(20)]
        public string SThe { get; set; }

        public int? SoNgayDT { get; set; }

        public DateTime? NgayVao { get; set; }

        public DateTime? NgayRa { get; set; }

        public DateTime? NgayKham { get; set; }

        public int? Status { get; set; }

        [StringLength(10)]
        public string MaICD { get; set; }
    }
}
