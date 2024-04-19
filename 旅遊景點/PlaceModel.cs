using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點
{
    public class PlaceModel
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Id { get; set; }

        public PlaceModel(string Name,string Address, double Lat,double Lng,string Id)
        {
            this.Name = Name;
            this.Address = Address;
            this.Lat = Lat;
            this.Lng = Lng;
            this.Id = Id;
        }
    }
}
