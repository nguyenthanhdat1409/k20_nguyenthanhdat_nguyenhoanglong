namespace k20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DienThoais = new HashSet<DienThoai>();
        }

        [Key]
        public int IdKH { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DienThoai> DienThoais { get; set; }
    }
}
