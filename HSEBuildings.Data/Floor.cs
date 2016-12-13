using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class Floor
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
