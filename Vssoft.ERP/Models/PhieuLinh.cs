namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuLinh")]
    public partial class PhieuLinh
    {
        [Key]
        public int IdPL { get; set; }

        public int? IdXD { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLinh { get; set; }

        public int? MaKP { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }
    }
}
