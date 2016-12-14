using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBuildings.Data
{
    class Repository
    {
        private class DataSet
        {
            public List<Campus> Campuses { get; set; }
            public List<Floor> Floors { get; set; }
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

        public IEnumerable<Floor> Floors
        {
            get
            {
                return _dataset.Floors;
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
            //Here will be JsonConveration file
            //_dataset = JsonConvert.DeserializeObject<>(File.ReadAllText("AllYearsStats.Json"));
        }
    }
}

