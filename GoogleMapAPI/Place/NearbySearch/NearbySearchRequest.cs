using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.NearbySearch
{
    public class NearbySearchRequest : BasePlace.PlaceRequest
    {


        public string type { get; set; }
        public int radius { get; set; }
        public string location { get; set; }
        public override string URL => base.URL + "nearbysearch/" + this.ToUri().ToString();
    }
}
