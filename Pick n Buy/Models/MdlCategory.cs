using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Pick_n_Buy.Models
{
    public class MdlCategory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Thumbnail { get; set; }


    }
}