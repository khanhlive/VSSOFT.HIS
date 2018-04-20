namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanUngT")]
    public partial class PhanUngT
    {
        public int MaBNhan { get; set; }

        public DateTime TimeStart { get; set; }

        public int MaDV { get; set; }

        [StringLength(500)]
        public string PPThu { get; set; }

        [StringLength(50)]
        public string MaCB { get; set; }

        public DateTime? TimeClose { get; set; }

        public int MaKP { get; set; }

        [Key]
        public int ID_PUT { get; set; }
    }
}
