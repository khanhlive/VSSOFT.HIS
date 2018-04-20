namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TieuNhomDV")]
    public partial class TieuNhomDV
    {
        [Key]
        public int IdTieuNhom { get; set; }

        [StringLength(100)]
        public string TenTN { get; set; }

        public int? IDNhom { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string TenRG { get; set; }

        public byte? STT { get; set; }
    }
}
