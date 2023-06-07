namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public int id { get; set; }

        [StringLength(200)]
        public string newsTitle { get; set; }

        public string detail { get; set; }

        public string description { get; set; }

        [StringLength(500)]
        public string image { get; set; }

        public bool? isActive { get; set; }

        public int? createById { get; set; }

        public DateTime? dateCreate { get; set; }

        public virtual accountAD accountAD { get; set; }
    }
}
