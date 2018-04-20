namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapDct")]
    public partial class NhapDct
    {
        [Key]
        public int IDNhapct { get; set; }

        public int? IDNhap { get; set; }

        public int? MaDV { get; set; }

        [StringLength(20)]
        public string SoLo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanDung { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        public double DonGiaCT { get; set; }

        public double DonGia { get; set; }

        public int VAT { get; set; }

        public double SoLuongN { get; set; }

        public double ThanhTienN { get; set; }

        public double SoLuongX { get; set; }

        public double ThanhTienX { get; set; }

        public double SoLuongKK { get; set; }

        public double ThanhTienKK { get; set; }

        public double SoLuongSD { get; set; }

        public double ThanhTienSD { get; set; }

        [StringLength(10)]
        public string MaCC { get; set; }

        [StringLength(30)]
        public string SoDangKy { get; set; }

        public double DonGiaDY { get; set; }

        public double SoLuongDY { get; set; }

        public double ThanhTienDY { get; set; }

        public int? MaBNhan { get; set; }

        public byte IDDTBN { get; set; }
    }
}
