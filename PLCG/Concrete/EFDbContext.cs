using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PLCG.Models;

namespace PLCG.Concrete
{
    public class EFDbContext : DbContext
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
    }
}