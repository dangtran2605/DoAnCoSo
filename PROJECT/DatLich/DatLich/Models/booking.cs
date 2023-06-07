namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("booking")]
    public partial class booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public booking()
        {
            detailBookings = new HashSet<detailBooking>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string fullName { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        public DateTime? dateCheckIn { get; set; }

        public int? people { get; set; }

        public bool? isConfirm { get; set; }

        public bool? isDisable { get; set; }

        public bool? isDone { get; set; }

        public int? idStaff { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailBooking> detailBookings { get; set; }
    }
}
