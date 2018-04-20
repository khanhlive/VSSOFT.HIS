namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [Key]
        public int ID_CV { get; set; }

        [StringLength(50)]
        public string Ten_CV { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        public byte? Status { get; set; }
    }
}
