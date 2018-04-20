namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XuatDct")]
    public partial class XuatDct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDXuatct { get; set; }

        public int? IDXuat { get; set; }

        [StringLength(50)]
        public string MaDuoc { get; set; }

        [StringLength(50)]
        public string SoLo { get; set; }

        [StringLength(50)]
        public string SoDangKy { get; set; }

        public DateTime? HanDung { get; set; }

        [StringLength(50)]
        public string DonVi { get; set; }

        public double? DonGia { get; set; }

        public double? SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }
    }
}
