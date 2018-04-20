namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiDinh")]
    public partial class ChiDinh
    {
        [Key]
        public int IDCD { get; set; }

        public int? IdCLS { get; set; }

        public int? MaDV { get; set; }

        public int? Status { get; set; }

        [Column("ChiDinh")]
        [StringLength(250)]
        public string ChiDinh1 { get; set; }

        public string KetLuan { get; set; }

        public string LoiDan { get; set; }

        public int? SoPhieu { get; set; }

        public int? TamThu { get; set; }

        public int? TrongBH { get; set; }

        [StringLength(50)]
        public string Mau_Lan_MTruongXN { get; set; }
    }
}
