//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vssoft.ERP.ERP
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIC_NHOMDICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIC_NHOMDICHVU()
        {
            this.DIC_TIEUNHOMDICHVU = new HashSet<DIC_TIEUNHOMDICHVU>();
        }
    
        public int MaNhom { get; set; }
        public string TenNhom { get; set; }
        public int Status { get; set; }
        public Nullable<int> STT { get; set; }
        public string TenNhomChiTiet { get; set; }
        public Nullable<int> BHYT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIC_TIEUNHOMDICHVU> DIC_TIEUNHOMDICHVU { get; set; }
    }
}
