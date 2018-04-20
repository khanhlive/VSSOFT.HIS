namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaUT")]
    public partial class GiaUT
    {
        public int? MaDV { get; set; }

        public double? DonGia { get; set; }

        public int? Status { get; set; }

        public int? MaKP { get; set; }

        [Key]
        public int IdGiaUT { get; set; }
        public string SoLo { get; set; }
    }
}
