namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoBienLai")]
    public partial class SoBienLai
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Quyen { get; set; }

        public int SoTu { get; set; }

        public int SoDen { get; set; }

        public int SoHT { get; set; }

        public int Status { get; set; }

        [StringLength(50)]
        public string MaCB { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PLoai { get; set; }
    }
}
