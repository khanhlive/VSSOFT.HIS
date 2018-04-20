namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DmTinh")]
    public partial class DmTinh
    {
        [Key]
        [StringLength(2)]
        public string MaTinh { get; set; }

        [StringLength(100)]
        public string TenTinh { get; set; }

        public int? Status { get; set; }
    }
}
