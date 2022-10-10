using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Models
{
    public class CabManagementDBContext: DbContext
    {
        public CabManagementDBContext(DbContextOptions<CabManagementDBContext> options) : base(options)
        {

        }
        public DbSet<TravelManager> TravelManagers { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<driver> Drivers { get; set; }

    }
}
