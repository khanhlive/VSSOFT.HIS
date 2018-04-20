namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiSan")]
    public partial class TaiSan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTS { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public int? MaKP { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public int? MaDV { get; set; }
    }
}
