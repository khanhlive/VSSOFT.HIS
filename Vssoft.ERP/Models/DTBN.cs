namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DTBN")]
    public partial class DTBN
    {
        [Key]
        public byte IDDTBN { get; set; }

        [Column("DTBN")]
        [StringLength(50)]
        public string DTBN1 { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        public int? Status { get; set; }

        public byte HTTT { get; set; }
    }
}
