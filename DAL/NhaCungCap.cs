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

    public partial class NhaCungCap
    {
        private static NhaCungCap instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            this.PhieuNhaps = new HashSet<PhieuNhap>();
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

        public void DeleteNCC(NhaCungCap obj)
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

        public NhaCungCap InsertNCC(NhaCungCap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                db.NhaCungCaps.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void UpdateNCC(NhaCungCap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                db.NhaCungCaps.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<NhaCungCap> showNCC()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                return db.NhaCungCaps.ToList();
            }
        }

        public String autoID()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var maxID = db.Database
                    .SqlQuery<String>("select MaNhaCungCap from dbo.NhaCungCap where MaNhaCungCap = (Select Max(MaNhaCungCap) from dbo.NhaCungCap)")
                    .FirstOrDefault();
                
                return maxID.ToString();
            }
        }
    }
}
