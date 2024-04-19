using Google.Maps.Places;
using GoogleMapAPI.Request.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.BasePlace
{
    public class PlaceResponse : AServiceResponse
    {
        [JsonProperty("results")]
        public PlacesResult[] Results
        {
            get;
            set;
        }

    }
}
