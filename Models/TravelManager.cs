using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Models
{
    public class TravelManager
    {
        [Key]
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string Password { get; set; }
        public List<Route> Routes { get; set; }
        public List<Cars> cars { get; set; }
        public List<driver> drivers { get; set; }
    }
}
