namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KQMau")]
    public partial class KQMau
    {
        public int? MaDV { get; set; }

        [Key]
        [StringLength(10)]
        public string MaKQ { get; set; }

        public string TenKQ { get; set; }

        [StringLength(250)]
        public string TenRG { get; set; }

        public string KetLuan { get; set; }

        [StringLength(250)]
        public string LoiDan { get; set; }
    }
}
