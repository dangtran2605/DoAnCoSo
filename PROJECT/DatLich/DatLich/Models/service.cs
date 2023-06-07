namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("service")]
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            detailBookings = new HashSet<detailBooking>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string serviceName { get; set; }

        public double? price { get; set; }

        public double? priceSale { get; set; }

        public int? idCategory { get; set; }

        public bool? isActive { get; set; }

        public int? idSale { get; set; }

        public string detail { get; set; }

        [StringLength(500)]
        public string image { get; set; }

        public virtual categoryService categoryService { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailBooking> detailBookings { get; set; }

        public virtual sale sale { get; set; }
    }
}
