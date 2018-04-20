namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVuEx")]
    public partial class DichVuEx
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDV { get; set; }

        [Required]
        [StringLength(50)]
        public string MaATC { get; set; }

        public int? HinhThucMua { get; set; }
        public string MaHC { get; set; }
    }
}
