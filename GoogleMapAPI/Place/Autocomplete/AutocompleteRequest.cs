using Google.Maps;
using Google.Maps.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.Autocomplete
{
    public class AutocompleteRequest : BasePlace.PlaceRequest
    {
        public string input { get; set; }


        public int offset { get; set; }


        public LatLng location { get; set; }


        public int? radius { get; set; }

        public string language { get; set; }


        public PlaceType[] types { get; set; }


        public string components { get; set; }


        public string sessionToken { get; set; }

        public override string URL => base.URL + "autocomplete/" + this.ToUri().ToString();
    }
}
