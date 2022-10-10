using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Models
{
    public class driver
    {
        [Key]
        public int driverId { get; set; }
        public string driverName { get; set; }
        public string driverGender { get; set; }
        public int driverAge { get; set; }
        
    }
}
