namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanToc")]
    public partial class DanToc
    {
        [Key]
        [StringLength(10)]
        public string MaDT { get; set; }

        [StringLength(50)]
        public string TenDT { get; set; }

        public string MoTa { get; set; }

        public int Status { get; set; }
    }
}
