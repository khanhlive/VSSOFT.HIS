namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(50)]
        public string TenDN { get; set; }

        [StringLength(50)]
        public string TenGoi { get; set; }

        [StringLength(50)]
        public string MatK { get; set; }

        public int? CapDo { get; set; }

        public string TraLoi { get; set; }

        public string CauHoi { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        [StringLength(50)]
        public string MaCB { get; set; }

        [StringLength(50)]
        public string MaDVsd { get; set; }
    }
}
