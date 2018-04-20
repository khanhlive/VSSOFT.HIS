namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MucTT")]
    public partial class MucTT
    {
        [Key]
        [StringLength(10)]
        public string MaMuc { get; set; }

        [StringLength(50)]
        public string DienGiai { get; set; }

        public int? PTTT { get; set; }

        public int? VanChuyen { get; set; }

        public int Status { get; set; }
    }
}
