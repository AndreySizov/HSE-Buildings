using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class Side
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public int CampusId { get; set; }
    }
}
