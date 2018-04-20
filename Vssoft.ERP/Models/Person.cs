namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [Key]
        public int IDPerson { get; set; }

        [Required]
        [StringLength(16)]
        public string SThe { get; set; }

        [StringLength(2)]
        public string MaDTuong { get; set; }

        [Required]
        [StringLength(40)]
        public string TenBNhan { get; set; }

        public int GTinh { get; set; }

        [StringLength(250)]
        public string DChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanBHTu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanBHDen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }

        public int? Status { get; set; }

        [StringLength(10)]
        public string MaCS { get; set; }

        [StringLength(2)]
        public string MaTinh { get; set; }

        [StringLength(2)]
        public string MaHuyen { get; set; }

        [StringLength(2)]
        public string MaXa { get; set; }

        public int? NSinh { get; set; }

        [StringLength(2)]
        public string NgaySinh { get; set; }

        [StringLength(2)]
        public string ThangSinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHM { get; set; }

        [StringLength(2)]
        public string KhuVuc { get; set; }
    }
}
