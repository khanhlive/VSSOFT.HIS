namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuTru")]
    public partial class DuTru
    {
        [Key]
        public int IdDuTru { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDT { get; set; }

        public int? MaKP { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public int? Ploai { get; set; }

        public int? status { get; set; }

        [StringLength(150)]
        public string LyDo { get; set; }

        public int? LoaiDuoc { get; set; }
    }
}
