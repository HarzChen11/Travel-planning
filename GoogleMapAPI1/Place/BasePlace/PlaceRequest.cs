using GoogleMapAPI.Request.GeoCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.BasePlace
{
    public class PlaceRequest : BaseRequest
    {
        public override string URL => "https://maps.googleapis.com/maps/api/place/";
    }
}
