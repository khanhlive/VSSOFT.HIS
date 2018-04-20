namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCC")]
    public partial class NhaCC
    {
        [Key]
        [StringLength(10)]
        public string MaCC { get; set; }

        [StringLength(250)]
        public string TenCC { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string NguoiCC { get; set; }

        public int? Status { get; set; }
    }
}
