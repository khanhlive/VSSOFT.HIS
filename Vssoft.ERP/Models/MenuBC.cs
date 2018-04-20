namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuBC")]
    public partial class MenuBC
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(500)]
        public string TenBC { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }

        [StringLength(50)]
        public string Nhom { get; set; }

        public bool? Status { get; set; }
    }
}
