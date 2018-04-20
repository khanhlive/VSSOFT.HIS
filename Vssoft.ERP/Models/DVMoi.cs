namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DVMoi")]
    public partial class DVMoi
    {
        [StringLength(350)]
        public string TenDV { get; set; }

        public double DonGia { get; set; }

        [StringLength(150)]
        public string MaQD { get; set; }

        public int? Statut { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDV { get; set; }

        [StringLength(100)]
        public string SoQD { get; set; }
    }
}
