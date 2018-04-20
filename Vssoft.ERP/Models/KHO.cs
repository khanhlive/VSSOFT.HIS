namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHO")]
    public partial class KHO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDKHO { get; set; }

        [Key]
        [StringLength(50)]
        public string MSKHO { get; set; }

        public string TKHO { get; set; }

        public string CTIET { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }
    }
}
