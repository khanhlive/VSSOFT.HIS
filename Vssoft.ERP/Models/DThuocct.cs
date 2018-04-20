namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DThuocct")]
    public partial class DThuocct
    {
        [Key]
        public int IDDonct { get; set; }

        public int? IDDon { get; set; }
        public int MaKPtk { get; set; }
        public int XHH { get; set; }

        public int? MaDV { get; set; }
        public double TyLeTT { get; set; }
        public int LoaiDV { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        public double DonGia { get; set; }

        [StringLength(20)]
        public string SoLo { get; set; }

        public double SoLuong { get; set; }

        public double ThanhTien { get; set; }

        public double TienBN { get; set; }

        public double TienBH { get; set; }

        public double TienChenh { get; set; }

        public int TrongBH { get; set; }

        public DateTime? NgayNhap { get; set; }

        [StringLength(50)]
        public string DuongD { get; set; }

        [StringLength(50)]
        public string MoiLan { get; set; }

        [StringLength(50)]
        public string DviUong { get; set; }

        [StringLength(5)]
        public string SoLan { get; set; }

        [StringLength(5)]
        public string Luong { get; set; }

        [StringLength(10)]
        public string MaCC { get; set; }

        public int? SoPL { get; set; }

        public int? Status { get; set; }

        public int? IDCD { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        [StringLength(250)]
        public string DSCBTH { get; set; }

        public int? MaKP { get; set; }

        public int IDKB { get; set; }

        public byte Loai { get; set; }

        public int ThanhToan { get; set; }

        public int Mien { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
        public int MaKXuat { get; set; }
    }
}
