using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SideFlor SideFlor { get; set; }
        public int SideFlorId { get; set; }
        
    }
}
