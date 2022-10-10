using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        public string CarNumber { get; set; }
        public string CarType { get; set; }
        public string CarDetails { get; set; }
       
        public List<driver> Driver { get; set; }
    }
}
