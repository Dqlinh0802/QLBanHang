//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADONNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONNHAP()
        {
            this.CT_NHAPHANG = new HashSet<CT_NHAPHANG>();
        }
    
        public int MANHAPHANG { get; set; }
        public Nullable<int> MA_NCC { get; set; }
        public Nullable<int> MA_NV { get; set; }
        public string GHICHUNHAPHANG { get; set; }
        public Nullable<System.DateTime> NGAYNHAPHANG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_NHAPHANG> CT_NHAPHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}