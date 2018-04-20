namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SDTS")]
    public partial class SDT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDSD { get; set; }

        public DateTime? Ngay { get; set; }

        public int? MaKP { get; set; }

        [StringLength(10)]
        public string MaCB { get; set; }

        public string NoiDung { get; set; }

        [StringLength(10)]
        public string PLoai { get; set; }
    }
}
