namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bang20
    {
        [Key]
        public int IdB20 { get; set; }

        [StringLength(10)]
        public string MaCC { get; set; }

        public int? TrongBH { get; set; }

        public int? NoiTru { get; set; }

        public int? SoTT { get; set; }

        public double? DonGia { get; set; }

        [StringLength(10)]
        public string DTuong { get; set; }

        public int? MaKP { get; set; }

        [StringLength(20)]
        public string SoTTqd { get; set; }

        public int IDNhom { get; set; }

        [StringLength(50)]
        public string TenNhom { get; set; }

        [StringLength(100)]
        public string TenTN { get; set; }

        [StringLength(50)]
        public string TenHC { get; set; }

        public int? MaDV { get; set; }

        [StringLength(250)]
        public string TenDV { get; set; }

        [StringLength(250)]
        public string MaQD { get; set; }

        [StringLength(50)]
        public string DuongD { get; set; }

        [StringLength(250)]
        public string HamLuong { get; set; }

        [StringLength(230)]
        public string SoDK { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        public double? SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        public int? PLoai { get; set; }

        [StringLength(50)]
        public string QCPC { get; set; }
    }
}
