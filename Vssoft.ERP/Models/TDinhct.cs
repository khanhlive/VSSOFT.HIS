namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TDinhct")]
    public partial class TDinhct
    {
        public int? MaBNhan { get; set; }

        public int? MaDV { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        public double? DonGia { get; set; }

        public double? SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        public double? TienBN { get; set; }

        public double? TienBH { get; set; }

        public double? TienTC { get; set; }

        public int? Duyet { get; set; }

        public int ID { get; set; }
    }
}
