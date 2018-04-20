namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [Key]
        public int MaDonVi { get; set; }

        [StringLength(250)]
        public string TenDonVi { get; set; }

        [StringLength(300)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Nuoc { get; set; }
    }
}
