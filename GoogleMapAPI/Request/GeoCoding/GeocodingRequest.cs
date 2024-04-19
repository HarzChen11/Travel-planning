using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Request.GeoCoding
{
    public class GeocodingRequest : BaseRequest
    {
        public string address
        {
            get;
            set;
        }

        public string placeId
        {
            get;
            set;
        }
        public string region
        {
            get;
            set;
        }

        public string language
        {
            get;
            set;
        }


        public override string URL => "https://maps.google.com/maps/api/geocode/" + this.ToUri().ToString();

        //        protected override string URL => "https://maps.google.com/maps/api/geocode/"+this.ToUri().ToString();

        //string calssItem;
        //string classData;

    }
}
