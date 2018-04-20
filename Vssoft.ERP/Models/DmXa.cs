namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DmXa")]
    public partial class DmXa
    {
        [Key]
        [StringLength(2)]
        public string MaXa { get; set; }

        [StringLength(2)]
        public string MaTinh { get; set; }

        [StringLength(2)]
        public string MaHuyen { get; set; }

        [StringLength(100)]
        public string TenXa { get; set; }
    }
}
