namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVuct")]
    public partial class DichVuct
    {
        [Key]
        [StringLength(10)]
        public string MaDVct { get; set; }

        public int? MaDV { get; set; }

        [StringLength(250)]
        public string TenDVct { get; set; }

        [StringLength(250)]
        public string TSBT { get; set; }
        public byte STT_R { get; set; }

        public int? STT { get; set; }

        public int? Status { get; set; }

        [StringLength(20)]
        public string DonVi { get; set; }

        [StringLength(250)]
        public string TSBTnu { get; set; }

        [StringLength(10)]
        public string TSnTu { get; set; }

        [StringLength(10)]
        public string TSnDen { get; set; }

        [StringLength(10)]
        public string TSnuTu { get; set; }

        [StringLength(10)]
        public string TSnuDen { get; set; }

        [StringLength(50)]
        public string TenMay { get; set; }

        [StringLength(10)]
        public string TSBTn { get; set; }

        [StringLength(250)]
        public string KetQua { get; set; }

        public byte? STT_F { get; set; }
    }
}
