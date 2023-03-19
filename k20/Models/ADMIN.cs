namespace k20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [StringLength(50)]
        public string TAIKHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string MATKHAU { get; set; }

        [StringLength(50)]
        public string HOTEN { get; set; }
    }
}
