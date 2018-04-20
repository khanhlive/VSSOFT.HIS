namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CBICD")]
    public partial class CBICD
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCB { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MSCB { get; set; }

        [StringLength(250)]
        public string NHOMCB { get; set; }

        [StringLength(250)]
        public string TENCB { get; set; }

        public int? STATUS { get; set; }
    }
}
