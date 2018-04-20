namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenDN { get; set; }

        [Column("_New")]
        public bool C_New { get; set; }

        [Column("_Edit")]
        public bool C_Edit { get; set; }

        [Column("_Delete")]
        public bool C_Delete { get; set; }

        [Column("_View")]
        public bool C_View { get; set; }

        [Column("_Print")]
        public bool C_Print { get; set; }
    }
}
