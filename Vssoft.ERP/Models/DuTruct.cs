namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuTruct")]
    public partial class DuTruct
    {
        [Key]
        public int IdDuTruct { get; set; }

        public int? IdDuTru { get; set; }

        public int? MaDV { get; set; }

        [StringLength(10)]
        public string SoLo { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        public double? DonGia { get; set; }

        public double? SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        [StringLength(10)]
        public string MaCC { get; set; }
    }
}
