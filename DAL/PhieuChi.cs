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
    
    public partial class PhieuChi
    {
        public string MaPhieuChi { get; set; }
        public Nullable<System.DateTime> NgayChi { get; set; }
        public string MaNhanVien { get; set; }
        public string MaPhieuNhap { get; set; }
        public Nullable<decimal> TongTienChi { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
        public virtual PhieuNhap PhieuNhap { get; set; }
    }
}
