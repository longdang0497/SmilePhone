//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmilePhone.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            this.PhieuChis = new HashSet<PhieuChi>();
        }
    
        public string MaPhieuNhap { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNhaCungCap { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
    
        public virtual ChiTietPhieuNhap ChiTietPhieuNhap { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
    }
}