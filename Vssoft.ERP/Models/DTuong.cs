namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DTuong")]
    public partial class DTuong
    {
        [Key]
        [StringLength(2)]
        public string MaDTuong { get; set; }

        [StringLength(250)]
        public string TenDTuong { get; set; }

        [StringLength(10)]
        public string Nhom { get; set; }

        public int? VanChuyen { get; set; }

        public int? Status { get; set; }

        public int? MaMuc { get; set; }

        public int? MucCu { get; set; }
    }
}
