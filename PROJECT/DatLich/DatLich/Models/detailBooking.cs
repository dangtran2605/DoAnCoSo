namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detailBooking")]
    public partial class detailBooking
    {
        public int id { get; set; }

        public int? idBooking { get; set; }

        public int? idService { get; set; }

        public virtual booking booking { get; set; }

        public virtual service service { get; set; }
    }
}
