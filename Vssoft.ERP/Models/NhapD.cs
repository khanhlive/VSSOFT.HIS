namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapD")]
    public partial class NhapD
    {
        [Key]
        public int IDNhap { get; set; }

        public DateTime? NgayNhap { get; set; }

        [StringLength(50)]
        public string SoCT { get; set; }

        public int? MaKP { get; set; }

        [StringLength(50)]
        public string TenNguoiCC { get; set; }
        public string SoPhieu { get; set; }

        [StringLength(10)]
        public string MaCC { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public int? Status { get; set; }

        public int? PLoai { get; set; }

        public int? MaKPnx { get; set; }

        public int? KieuDon { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(10)]
        public string MaXP { get; set; }

        public int? XuatTD { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public int? SoPL { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public byte IDDTBN { get; set; }

        public int Mien { get; set; }
    }
}
