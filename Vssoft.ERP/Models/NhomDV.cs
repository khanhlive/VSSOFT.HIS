namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomDV")]
    public partial class NhomDV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDNhom { get; set; }

        [StringLength(250)]
        public string TenNhom { get; set; }

        public int? Status { get; set; }

        public int? STT { get; set; }

        [StringLength(250)]
        public string TenNhomCT { get; set; }

        public int? BHYT { get; set; }
    }
}
