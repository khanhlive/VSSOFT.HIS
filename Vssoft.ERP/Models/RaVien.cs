namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RaVien")]
    public partial class RaVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRaVien { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBNhan { get; set; }

        public DateTime? NgayRa { get; set; }

        public int? SoRaVien { get; set; }

        public int? SoChuyenVien { get; set; }

        [StringLength(1000)]
        public string TinhTrangC { get; set; }

        [StringLength(1000)]
        public string LyDoC { get; set; }

        [StringLength(50)]
        public string HinhThucC { get; set; }

        public int? SoNgaydt { get; set; }

        public int? Status { get; set; }

        public int? SoGT { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        [StringLength(250)]
        public string PPDTr { get; set; }

        [StringLength(250)]
        public string LoiDan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanC { get; set; }

        public int? MaKP { get; set; }

        [StringLength(10)]
        public string MaBVC { get; set; }

        public string KetQua { get; set; }

        [StringLength(20)]
        public string MaICD { get; set; }

        [StringLength(1000)]
        public string ChanDoan { get; set; }

        public int? MaCK { get; set; }

        public int? PhanLoai1 { get; set; }

        [StringLength(1000)]
        public string ThuocSD { get; set; }

        [StringLength(20)]
        public string DonVi { get; set; }

        [StringLength(250)]
        public string TSBTnu { get; set; }

        public DateTime? NgayVao { get; set; }

        [StringLength(20)]
        public string SoLT { get; set; }

        [StringLength(20)]
        public string MaYTe { get; set; }

        [StringLength(10)]
        public string DTuongManTinh { get; set; }
    }
}
