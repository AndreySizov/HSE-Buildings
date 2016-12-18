using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class PhotoSet
    {
        public int Id { get; set; }
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public int PhotoSetNum { get; set; }
    }
}
