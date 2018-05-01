namespace Vssoft.Data.ERP.Dictionary
{
    public partial class DIC_BENHVIEN
    {
        public int ID { get; set; }
        public string MaBenhVien { get; set; }
        
        public string MaChuQuan { get; set; }
        public string TenBenhVien { get; set; }
        public string TuyenBenhVien { get; set; }
        public int HangBenhVien { get; set; }
        
        public string MaHuyen { get; set; }
        public string TenHuyen { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string DiaChi { get; set; }
        public bool Connect { get; set; }
        public int Status { get; set; }
    }
}
