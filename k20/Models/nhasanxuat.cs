namespace k20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhasanxuat")]
    public partial class nhasanxuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhasanxuat()
        {
            dienthoais = new HashSet<dienthoai>();
        }

        [Key]
        public int manhasanxuat { get; set; }

        [Required]
        [StringLength(200)]
        public string tennhasanxuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dienthoai> dienthoais { get; set; }
    }
}
