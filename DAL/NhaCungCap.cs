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
    using System.Linq;
    using DTO;

    public partial class NhaCungCap
    {
        private static NhaCungCap instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            this.PhieuNhaps = new HashSet<PhieuNhap>();
            this.PhieuDatHangs = new HashSet<PhieuDatHang>();
        }

        public static NhaCungCap Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCap();
                return instance;
            }
        }

        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatHang> PhieuDatHangs { get; set; }

        public void DeleteNCC(DTO_NhaCungCap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                NhaCungCap ncc = (from item in db.NhaCungCaps
                                  where item.MaNhaCungCap == obj.MaNhaCungCap
                                  select item).SingleOrDefault();
                db.NhaCungCaps.Remove(ncc);
                db.SaveChanges();
            }
        }

        public void InsertNCC(DTO_NhaCungCap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                this.MaNhaCungCap = obj.MaNhaCungCap;
                this.TenNhaCungCap = obj.TenNhaCungCap;
                this.Email = obj.Email;
                this.DiaChi = obj.DiaChi;
                this.SoDienThoai = obj.SoDienThoai;

                db.NhaCungCaps.Add(this);
                db.SaveChanges();
            }
        }

        public void UpdateNCC(DTO_NhaCungCap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                this.MaNhaCungCap = obj.MaNhaCungCap;
                this.TenNhaCungCap = obj.TenNhaCungCap;
                this.Email = obj.Email;
                this.DiaChi = obj.DiaChi;
                this.SoDienThoai = obj.SoDienThoai;

                db.NhaCungCaps.Attach(this);
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<DTO_NhaCungCap> showNCC()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.NhaCungCaps
                              select new DTO_NhaCungCap
                              {
                                  MaNhaCungCap = item.MaNhaCungCap,
                                  TenNhaCungCap = item.TenNhaCungCap,
                                  SoDienThoai = item.SoDienThoai,
                                  DiaChi = item.DiaChi,
                                  Email = item.Email
                              }).ToList<DTO_NhaCungCap>();
                return result;
            }
        }


        public List<DTO_NhaCungCap> searchNCC(string str)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.NhaCungCaps
                              where item.MaNhaCungCap.Contains(str.ToUpper())
                              || item.TenNhaCungCap.Contains(str)
                              || item.DiaChi.Contains(str)
                              || item.SoDienThoai.Contains(str)
                              || item.Email.Contains(str)
                              select new DTO_NhaCungCap
                              {
                                  MaNhaCungCap = item.MaNhaCungCap,
                                  TenNhaCungCap = item.TenNhaCungCap,
                                  SoDienThoai = item.SoDienThoai,
                                  DiaChi = item.DiaChi,
                                  Email = item.Email
                              }).ToList<DTO_NhaCungCap>();
                return result;
            }
        }
    }
}
