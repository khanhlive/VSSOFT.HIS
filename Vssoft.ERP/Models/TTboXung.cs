namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTboXung")]
    public partial class TTboXung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBNhan { get; set; }

        [StringLength(50)]
        public string NgheNghiep { get; set; }

        [StringLength(250)]
        public string NThan { get; set; }

        [StringLength(250)]
        public string NoiLV { get; set; }

        [StringLength(20)]
        public string SoKSinh { get; set; }

        [StringLength(2)]
        public string MaTinh { get; set; }

        [StringLength(2)]
        public string MaHuyen { get; set; }

        [StringLength(2)]
        public string MaXa { get; set; }

        [StringLength(10)]
        public string MaDT { get; set; }

        [StringLength(50)]
        public string NgoaiKieu { get; set; }

        [StringLength(15)]
        public string DThoai { get; set; }

        [StringLength(15)]
        public string DThoaiNT { get; set; }

        [StringLength(15)]
        public string CMT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapCMT { get; set; }

        [StringLength(10)]
        public string MaNN { get; set; }

        [StringLength(50)]
        public string ThonPho { get; set; }

        public int? ID_CB { get; set; }

        public int? ID_CV { get; set; }

        public int? ThangTheoDoi { get; set; }

        public int? TienSuDTri { get; set; }

        public int? TinhTrangH { get; set; }

        public int? ChanDoanLao { get; set; }

        public int? So_eTBM { get; set; }

        public int? DTuongLao { get; set; }

        [StringLength(50)]
        public string DTuongLaoKhac { get; set; }

        [StringLength(500)]
        public string FileAnh { get; set; }
    }
}
