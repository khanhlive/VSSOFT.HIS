namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TamUngct")]
    public partial class TamUngct
    {
        [Key]
        public int IDTamUngct { get; set; }

        public int IDTamUng { get; set; }

        public int MaDV { get; set; }

        public double SoLuong { get; set; }

        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public double SoTien { get; set; }

        public int? IDCD { get; set; }

        public int TrongBH { get; set; }

        public int Mien { get; set; }

        public double TienBN { get; set; }
        public int Status { get; set; }
    }
}
