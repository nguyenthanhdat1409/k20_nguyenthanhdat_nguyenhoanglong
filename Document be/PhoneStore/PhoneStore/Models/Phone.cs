namespace PhoneStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phone")]
    public partial class Phone
    {
        public int PhoneID { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneName { get; set; }

        public long Price { get; set; }

        public int? ManufacturerID { get; set; }

        [StringLength(200)]
        public string PhoneImg { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
