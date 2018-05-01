namespace Vssoft.Data.ERP.Dictionary
{
    using System;
    
    public partial class DIC_NHOMDICHVU
    {
        public DIC_NHOMDICHVU()
        {
        }
        public int MaNhom { get; set; }
        public string TenNhom { get; set; }
        public string TenNhomChiTiet { get; set; }
        public Nullable<int> BHYT { get; set; }
        public Nullable<int> STT { get; set; }
        public int Status { get; set; }
    }
}
