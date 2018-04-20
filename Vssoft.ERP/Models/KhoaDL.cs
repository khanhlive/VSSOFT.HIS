namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoaDL")]
    public partial class KhoaDL
    {
        [Column(TypeName = "date")]
        public DateTime NgayKhoa { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public int Status { get; set; }

        public int? PhanLoai { get; set; }

        public int? KhoaVP { get; set; }

        public int? KhoaDC { get; set; }

        public int? PhanLoai1 { get; set; }

        public int ID { get; set; }

        public bool? NoiTru { get; set; }

        public bool? NgoaiTru { get; set; }

        [StringLength(10)]
        public string MaKho { get; set; }

        public int? PLoai { get; set; }
    }
}
