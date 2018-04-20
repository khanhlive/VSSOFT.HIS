namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaoVien")]
    public partial class VaoVien
    {
        [Key]
        public int idVaoVien { get; set; }

        public DateTime? NgayVao { get; set; }

        [StringLength(250)]
        public string TienSuBT { get; set; }

        [StringLength(250)]
        public string TienSuGD { get; set; }

        public int? MaBNhan { get; set; }

        [StringLength(250)]
        public string KhamTThan { get; set; }

        [StringLength(250)]
        public string KhamBPhan { get; set; }

        [StringLength(250)]
        public string kQLamSang { get; set; }

        [StringLength(250)]
        public string ChanDoan { get; set; }

        [StringLength(250)]
        public string DaXuLy { get; set; }

        [StringLength(50)]
        public string ChuY { get; set; }

        [StringLength(50)]
        public string Mach { get; set; }

        [StringLength(50)]
        public string NhietDo { get; set; }

        [StringLength(10)]
        public string HuyetAp { get; set; }

        [StringLength(50)]
        public string NhipTho { get; set; }

        [StringLength(50)]
        public string CanNang { get; set; }

        [StringLength(10)]
        public string SoBA { get; set; }

        [StringLength(10)]
        public string SoVV { get; set; }

        [StringLength(250)]
        public string LyDo { get; set; }

        public int? MaKP { get; set; }

        [StringLength(250)]
        public string Tai { get; set; }

        [StringLength(250)]
        public string Mui { get; set; }

        [StringLength(250)]
        public string Hong { get; set; }

        [StringLength(50)]
        public string MatP { get; set; }

        [StringLength(50)]
        public string MatT { get; set; }

        [StringLength(50)]
        public string NhanApP { get; set; }

        [StringLength(50)]
        public string NhanApT { get; set; }

        [StringLength(50)]
        public string ChuyenKhoa { get; set; }

        [StringLength(500)]
        public string BenhLy { get; set; }
    }
}
