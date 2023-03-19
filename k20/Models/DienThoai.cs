namespace k20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dienthoai")]
    public partial class dienthoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dienthoai()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        public int MAdienthoai { get; set; }

        [Required]
        [StringLength(200)]
        public string TENdienthoai { get; set; }

        public decimal GIABAN { get; set; }

        [Required]
        public string MOTA { get; set; }

        [Required]
        [StringLength(200)]
        public string ANHBIA { get; set; }

        public DateTime? NGAYCAPNHAT { get; set; }

        public int SOLUONGTON { get; set; }

        public int? manhasanxuat { get; set; }

        public double? SALE { get; set; }

        public int? TRONGLUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual nhasanxuat nhasanxuat { get; set; }
    }
}
