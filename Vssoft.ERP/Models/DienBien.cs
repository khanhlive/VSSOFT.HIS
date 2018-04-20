namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DienBien")]
    public partial class DienBien
    {
        public DateTime? NgayNhap { get; set; }

        public int? MaBNhan { get; set; }

        [Column("DienBien")]
        public string DienBien1 { get; set; }

        public string YLenh { get; set; }

        public int ID { get; set; }

        public int? IDDon { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        [StringLength(2000)]
        public string ThucHienYL { get; set; }
    }
}
