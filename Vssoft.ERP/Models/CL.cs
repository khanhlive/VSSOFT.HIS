namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLS")]
    public partial class CL
    {
        [Key]
        public int IdCLS { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(20)]
        public string MaCB { get; set; }

        public int? MaKP { get; set; }

        public int? MaKPth { get; set; }

        public DateTime? NgayThang { get; set; }

        [StringLength(20)]
        public string MaCBth { get; set; }

        public DateTime? NgayTH { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(20)]
        public string BarCode { get; set; }

        [StringLength(250)]
        public string DSCBTH { get; set; }

        public byte Status { get; set; }

        public int? STT { get; set; }

        [StringLength(100)]
        public string BenhPham { get; set; }

        [StringLength(50)]
        public string TrangThaiBP { get; set; }

        public DateTime? ThoiGianLayMau { get; set; }

        public DateTime? ThoiGianNhanMau { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public DateTime? NgayKQ { get; set; }

        public bool CapCuu { get; set; }

        public int? IDBB { get; set; }
    }
}
