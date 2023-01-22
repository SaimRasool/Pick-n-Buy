using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pick_n_Buy.Models
{
    public class MdlOrder
    {
        [Key]
        public int SID { get; set; }
        public int Quantity { get; set; }
        public string name { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
    }
}