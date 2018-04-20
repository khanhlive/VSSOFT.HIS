namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VienPhict")]
    public partial class VienPhict
    {
        [Key]
        public int idVPhict { get; set; }

        public int? idVPhi { get; set; }

        public int? MaDV { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        public double DonGia { get; set; }
        public int LoaiDV { get; set; }

        public double SoLuong { get; set; }

        public double ThanhTien { get; set; }

        public double TienBN { get; set; }

        public double TienBH { get; set; }

        public double TienChenh { get; set; }

        public int TrongBH { get; set; }

        public int? Duyet { get; set; }

        public double SoLuongD { get; set; }

        public double TienChenhBN { get; set; }

        public int? PhanLoai1 { get; set; }

        public int? MaKP { get; set; }

        public int? IDTamUng { get; set; }

        public int ThanhToan { get; set; }

        public int Mien { get; set; }

        public double TyLeBHTT { get; set; }
        public DateTime? NgayChiPhi { get; set; }
        public double TyLeTT { get; set; }
        public int XHH { get; set; }
    }
}
