//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietThu
    {
        public string MaChiTietThu { get; set; }
        public string MaBaoCaoThuChi { get; set; }
        public string MaPhieuBanHang { get; set; }
    
        public virtual BaoCaoThuChi BaoCaoThuChi { get; set; }
        public virtual PhieuBanHang PhieuBanHang { get; set; }
    }
}
