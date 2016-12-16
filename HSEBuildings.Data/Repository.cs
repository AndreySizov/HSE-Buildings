using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    public class Repository
    {
        private class DataSet
        {
            public List<Campus> Campuses { get; set; }
            public List<Flor> Flors { get; set; }
            public List<Room> Rooms { get; set; }
            public List<Photo> Photos { get; set; }
        }

        DataSet _dataset;

        public IEnumerable<Campus> Campuses
        {
            get
            {
                return _dataset.Campuses;
            }

        }

        public IEnumerable<Flor> Flors
        {
            get
            {
                return _dataset.Flors;
            }

        }

        public IEnumerable<Room> Rooms
        {
            get
            {
                return _dataset.Rooms;
            }

        }

        public IEnumerable<Photo> Photos
        {
            get
            {
                return _dataset.Photos;
            }

        }


        public void GetData()
        {
            
            _dataset = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("../../../HSEBuildings.Data/Buildings.Json"));
        }
    }
}

