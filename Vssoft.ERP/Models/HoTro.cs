namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoTro")]
    public partial class HoTro
    {
        [StringLength(100)]
        public string TenNV { get; set; }

        [Key]
        public int IDNV { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string PhongBan { get; set; }

        [StringLength(12)]
        public string SoDT1 { get; set; }

        [StringLength(12)]
        public string SoDT2 { get; set; }

        public int? SoTT { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string BietDanh { get; set; }
    }
}
