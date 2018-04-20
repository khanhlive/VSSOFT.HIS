namespace Vssoft.ERP.ERP
{
    using System;

    public partial class DIC_DOITUONG
    {
        public string MaDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public string NhomDoiTuong { get; set; }
        public Nullable<int> VanChuyen { get; set; }
        
        public Nullable<int> MaMuc { get; set; }
        public Nullable<int> MucCu { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
