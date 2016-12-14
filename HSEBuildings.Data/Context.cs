using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    class Context :DbContext
    {
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Photo> Photo { get; set; }

        public Context() : base("localsql")
        {

        }
    }
}
