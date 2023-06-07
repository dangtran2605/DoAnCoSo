namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            accountADs = new HashSet<accountAD>();
            bookings = new HashSet<booking>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string fullName { get; set; }

        public string detail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? born { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        public int? idPosition { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accountAD> accountADs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking> bookings { get; set; }

        public virtual position position { get; set; }
    }
}
