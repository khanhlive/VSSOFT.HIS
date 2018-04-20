namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhVien")]
    public partial class BenhVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(50)]
        public string MaBV { get; set; }

        [StringLength(50)]
        public string MaTinh { get; set; }

        [StringLength(50)]
        public string MaHuyen { get; set; }

        [StringLength(50)]
        public string MaChuQuan { get; set; }

        [StringLength(150)]
        public string TenBV { get; set; }

        [StringLength(50)]
        public string TuyenBV { get; set; }

        public int? HangBV { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public int? status { get; set; }

        public bool Connect { get; set; }
    }
}
