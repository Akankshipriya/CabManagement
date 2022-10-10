using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Models
{
    public class AssignModel
    {
        public IEnumerable<Cars> car { get; set; }
        public IEnumerable<driver> driver { get; set; }
        public IEnumerable<Route> route { get; set; }
    }
}
