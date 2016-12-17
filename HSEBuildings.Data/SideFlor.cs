using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class SideFlor
    {
        public int Id { get; set; }

        public Flor Flor { get; set; }
        public int FlorId { get; set; }

        public Side Side { get; set; }
        public int SideId { get; set; }

        public int PhotoSetNum { get; set; }
    }
}
