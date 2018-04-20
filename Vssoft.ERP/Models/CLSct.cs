namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLSct")]
    public partial class CLSct
    {
        public int Id { get; set; }

        public int? IdCLS { get; set; }

        [StringLength(10)]
        public string MaDVct { get; set; }

        [StringLength(250)]
        public string ChiDinh { get; set; }

        public int? Status { get; set; }

        [StringLength(20)]
        public string MaCB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaythang { get; set; }

        public int? IDCD { get; set; }

        public int? STTHT { get; set; }

        public string KetQua { get; set; }

        public double? SoPhieu { get; set; }

        [StringLength(50)]
        public string KetquaXN { get; set; }

        [StringLength(250)]
        public string DuongDan { get; set; }

        [StringLength(500)]
        public string DuongDan2 { get; set; }
    }
}
