namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XuatD")]
    public partial class XuatD
    {
        [Key]
        public int IDXuat { get; set; }

        public DateTime? NgayXuat { get; set; }

        [StringLength(50)]
        public string SoCT { get; set; }

        [StringLength(50)]
        public string MaBNhan { get; set; }

        public int? MaKP { get; set; }

        [StringLength(50)]
        public string MaCB { get; set; }

        public string LyDo { get; set; }

        [StringLength(50)]
        public string PhanLoai { get; set; }

        public string GhiChu { get; set; }

        public int? Status { get; set; }
    }
}
