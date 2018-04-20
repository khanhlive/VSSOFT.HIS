namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuLinhct")]
    public partial class PhieuLinhct
    {
        [Key]
        public int idPLct { get; set; }

        public int? IdPL { get; set; }

        public int? IDDon { get; set; }
    }
}
