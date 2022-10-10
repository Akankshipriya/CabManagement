using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public int Distance { get;set; }
        public Cars Car { get; set; }
    }
}
