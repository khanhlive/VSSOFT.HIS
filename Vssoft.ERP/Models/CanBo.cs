namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanBo")]
    public partial class CanBo
    {
        [Key]
        [StringLength(10)]
        public string MaCB { get; set; }

        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string TenCB { get; set; }
        public string MaCCHN { get; set; }

        public int? MaKP { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string CapBac { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SoDT { get; set; }

        public int? GioiTinh { get; set; }

        [StringLength(50)]
        public string BangCap { get; set; }

        [StringLength(10)]
        public string MaDT { get; set; }

        public int? Khoa { get; set; }
        public bool KhoaChungTu { get; set; }

        [StringLength(500)]
        public string FileAnh { get; set; }
        public string TenKP { get; set; }
        public string TenDT { get; set; }
    }
}
