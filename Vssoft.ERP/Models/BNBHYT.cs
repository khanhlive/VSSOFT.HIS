namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BNBHYT")]
    public partial class BNBHYT
    {
        [Key]
        public int IDBH { get; set; }

        [Required]
        [StringLength(50)]
        public string SThe { get; set; }

        [StringLength(50)]
        public string MaCS { get; set; }

        [StringLength(250)]
        public string TenBNhan { get; set; }

        [StringLength(50)]
        public string GTinh { get; set; }

        public DateTime? NSinh { get; set; }

        public string DChi { get; set; }

        public DateTime? HanBHTu { get; set; }

        public DateTime? HanBHDen { get; set; }

        public DateTime? NgayCap { get; set; }

        [StringLength(250)]
        public string NoiCap { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }
    }
}
