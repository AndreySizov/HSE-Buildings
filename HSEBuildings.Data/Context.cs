using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class Context :DbContext
    {
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Flor> Flor { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Side> Side { get; set; }
        public DbSet<SideFlor> SideFlor { get; set; }
        public DbSet<PhotoSet> PhotoSet { get; set; }

        public Context() : base("localsql")
        {

        }
    }
}
