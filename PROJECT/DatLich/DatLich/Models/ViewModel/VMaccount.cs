using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatLich.Models.ViewModel
{
    public class VMaccount
    {
        public int id { get; set; }
        [StringLength(200)]
        public string userName { get; set; }

        [StringLength(200)]
        public string passWord { get; set; }
        [StringLength(200)]
        public string confirmPassword { get; set; }
        public int? idStaff { get; set; }
    }
}