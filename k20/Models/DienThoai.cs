namespace k20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DienThoai")]
    public partial class DienThoai
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string HangSanXuat { get; set; }

        public int? NamSanXuat { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gia { get; set; }

        [StringLength(50)]
        public string Hinh { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public int? MaKH { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
