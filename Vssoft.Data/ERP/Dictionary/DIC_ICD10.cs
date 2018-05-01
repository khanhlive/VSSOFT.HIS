namespace Vssoft.Data.ERP.Dictionary
{
    public partial class DIC_ICD10
    {
        public int ID { get; set; }
        
        public string MaICD { get; set; }
        
        public string TenICD { get; set; }
        
        public string MaChuongBenh { get; set; }
        
        public string TenChuongBenh { get; set; }
        
        public string TenWHOe { get; set; }
        
        public string TenWHO { get; set; }

        public int? IDCB { get; set; }

        public int? ID_MBICD { get; set; }
        
        public string TenICD_YHCT { get; set; }
        
        public string MaICD10 { get; set; }
        public int Status { get; set; }
    }
}
