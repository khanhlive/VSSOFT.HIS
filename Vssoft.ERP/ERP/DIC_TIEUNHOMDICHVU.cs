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
    
    public partial class DIC_TIEUNHOMDICHVU
    {
        public int MaTieuNhom { get; set; }
        public string TenTieuNhom { get; set; }
        public Nullable<int> MaNhom { get; set; }
        public int Status { get; set; }
        public string TenRutGon { get; set; }
        public Nullable<byte> STT { get; set; }
    
        public virtual DIC_NHOMDICHVU DIC_NHOMDICHVU { get; set; }
    }
}