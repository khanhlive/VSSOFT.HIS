namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TamUng")]
    public partial class TamUng
    {
        [Key]
        public int IDTamUng { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(250)]
        public string LyDo { get; set; }

        public double? SoTien { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public DateTime? NgayThu { get; set; }

        public int? SoTo { get; set; }

        public int? KetLuan { get; set; }

        public int? PhanLoai { get; set; }

        public int? MaKP { get; set; }

        public int? NgoaiGio { get; set; }

        [StringLength(10)]
        public string QuyenHD { get; set; }

        [StringLength(15)]
        public string SoHD { get; set; }

        public double TienChenh { get; set; }

        public bool? Status { get; set; }
    }
}
