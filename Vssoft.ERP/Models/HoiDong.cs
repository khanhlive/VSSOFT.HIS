namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoiDong")]
    public partial class HoiDong
    {
        [Key]
        public int idbb { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string chucvu { get; set; }

        [StringLength(10)]
        public string LoaiBB { get; set; }

        [StringLength(50)]
        public string ThoiGianBD { get; set; }
    }
}
