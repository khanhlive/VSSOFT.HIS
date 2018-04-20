namespace Vssoft.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ICD10_2465
    {
        [StringLength(1000)]
        public string STTChuong { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(1000)]
        public string MaChuong { get; set; }

        [StringLength(1000)]
        public string TenChuongE { get; set; }

        [StringLength(1000)]
        public string TenChuong { get; set; }

        [StringLength(1000)]
        public string MaNhom { get; set; }

        [StringLength(1000)]
        public string TenNhomE { get; set; }

        [StringLength(1000)]
        public string TenNhom { get; set; }

        [StringLength(1000)]
        public string MaNhomPhu1 { get; set; }

        [StringLength(1000)]
        public string TenNhomPhu1E { get; set; }

        [StringLength(1000)]
        public string TenNhomPhu1 { get; set; }

        [StringLength(1000)]
        public string MaNhomPhu2 { get; set; }

        [StringLength(1000)]
        public string TenNhomPhu2E { get; set; }

        [StringLength(1000)]
        public string TenNhomPhu2 { get; set; }

        [StringLength(1000)]
        public string MaLoai { get; set; }

        [StringLength(1000)]
        public string TenLoaiE { get; set; }

        [StringLength(1000)]
        public string TenLoai { get; set; }

        [StringLength(1000)]
        public string MaBenh { get; set; }

        [StringLength(1000)]
        public string TenBenhE { get; set; }

        [StringLength(1000)]
        public string TenBenh { get; set; }

        [StringLength(1000)]
        public string TenBenhBX { get; set; }

        [StringLength(1000)]
        public string MaNhomBCBYT { get; set; }

        [StringLength(1000)]
        public string MaCt { get; set; }

        [StringLength(1000)]
        public string MaTH { get; set; }
    }
}
