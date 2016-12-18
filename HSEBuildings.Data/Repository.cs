using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSEBuildings.Data.ResponseTemplates;

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
            public List<Side> Sides { get; set; }
            public List<SideFlor> SideFlors { get; set; }
            public List<PhotoSet> PhotoSets { get; set; }
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

        public IEnumerable<PhotoSet> PhotoSets
        {
            get
            {
                return _dataset.PhotoSets;
            }

        }

        public IEnumerable<Side> Sides
        {
            get
            {
                return _dataset.Sides;
            }

        }

        public IEnumerable<SideFlor> SideFlors
        {
            get
            {
                return _dataset.SideFlors;
            }

        }

        public void GetData()
        {
            
            _dataset = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("HSEBuildings/HSEBuildings.Data/Buildings.Json"));
        }

        public List<Location> getLocation(string name)
        {
            using (var c = new Context())
                return (from item in c.Campus
                       where item.Name == name
                       select new Location { Latitude=item.Latitude, Longitude=item.Longitude }).ToList();
        }

        public List<RoomWay> getPhotoSet(string roomName)
        {
            
            using (var c = new Context())

                return (from item in c.Room
                       join sf in c.SideFlor
                       on item.SideFlorId equals sf.Id
                       join phs in c.PhotoSet
                       on sf.PhotoSetNum equals phs.PhotoSetNum
                       join ph in c.Photo
                       on phs.PhotoId equals ph.Id
                       where item.Name == roomName
                       select new RoomWay { link = ph.Link }).ToList();
        }
        
        public List<Location> getAllCampuses()
        {
            using (var c = new Context())
                return (from item in c.Campus
                        select new Location { Name = item.Name, Latitude = item.Latitude, Longitude = item.Longitude, CampusPhoto = item.CampusPhoto }).ToList();
        }
    }
}

