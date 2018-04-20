namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoTT")]
    public partial class SoTT
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime NgayDK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKP { get; set; }

        [Key]
        [Column("SoTT", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoTT1 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBNhan { get; set; }
    }
}
