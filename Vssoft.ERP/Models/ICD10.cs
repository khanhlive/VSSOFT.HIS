namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ICD10
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDICD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaICD { get; set; }

        [StringLength(250)]
        public string TenICD { get; set; }

        public int? Status { get; set; }

        [StringLength(10)]
        public string MSCB { get; set; }

        [StringLength(250)]
        public string TenCB { get; set; }

        [StringLength(500)]
        public string TenWHOe { get; set; }

        [StringLength(500)]
        public string TenWHO { get; set; }

        public int? IDCB { get; set; }

        public int? ID_MBICD { get; set; }

        [StringLength(250)]
        public string TenICD_YHCT { get; set; }

        [StringLength(20)]
        public string MaICD10 { get; set; }
    }
}
