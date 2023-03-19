namespace k20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        public int MADONHANG { get; set; }

        public bool? DATHANHTOAN { get; set; }

        [StringLength(100)]
        public string TINHTRANGGIAOHANG { get; set; }

        public DateTime? NGAYDAT { get; set; }

        public DateTime? NGAYGIAO { get; set; }

        public int? MAKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
