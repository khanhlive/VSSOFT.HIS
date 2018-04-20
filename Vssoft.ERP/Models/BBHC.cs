namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BBHC")]
    public partial class BBHC
    {
        [Key]
        public int IDBB { get; set; }

        public DateTime? NgayHC { get; set; }

        public int? MaKP { get; set; }

        public DateTime? NgayDTTu { get; set; }

        public DateTime? NgayDTDen { get; set; }

        [StringLength(10)]
        public string Buong { get; set; }

        [StringLength(10)]
        public string Giuong { get; set; }

        [StringLength(1000)]
        public string QTDBDT { get; set; }

        [StringLength(500)]
        public string KetLuan { get; set; }

        [StringLength(500)]
        public string HuongDT { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        [StringLength(10)]
        public string MaCBtk { get; set; }

        [StringLength(500)]
        public string ThanhVien { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(250)]
        public string ChanDoan { get; set; }
    }
}
