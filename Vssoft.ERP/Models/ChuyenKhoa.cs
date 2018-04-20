namespace Vssoft.ERP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChuyenKhoa")]
    public partial class ChuyenKhoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCK { get; set; }
        [StringLength(100)]
        public string TenCK { get; set; }
        [StringLength(250)]
        public string TenChiTiet { get; set; }
        public string MaQuyetDinh { get; set; }
        public int Status { get; set; }
    }
}
