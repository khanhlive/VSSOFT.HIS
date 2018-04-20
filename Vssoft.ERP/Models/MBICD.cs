namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MBICD")]
    public partial class MBICD
    {
        [Key]
        public int ID_MBICD { get; set; }

        [StringLength(2000)]
        public string MaICD { get; set; }

        [StringLength(500)]
        public string TenWHO { get; set; }

        [StringLength(500)]
        public string TenWHOe { get; set; }

        public string GHICHU { get; set; }

        public bool? STATUS { get; set; }

        public int? IDCB { get; set; }

        public int? STT { get; set; }

        [StringLength(2000)]
        public string DS_MaICD { get; set; }
    }
}
