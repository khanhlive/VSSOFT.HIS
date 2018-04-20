namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuongDung")]
    public partial class DuongDung
    {
        public int? STT { get; set; }

        [Key]
        [StringLength(20)]
        public string MaDuongDung { get; set; }

        [Column("DuongDung")]
        [StringLength(200)]
        public string DuongDung1 { get; set; }
    }
}
