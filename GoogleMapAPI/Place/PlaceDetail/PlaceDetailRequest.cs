using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.PlaceDetail
{
    public class PlaceDetailRequest : BasePlace.PlaceRequest
    {

        public string place_id
        {
            get;
            set;
        }

        [Obsolete("Use PlaceID")]
        public string reference
        {
            get;
            set;
        }

        public string extensions
        {
            get;
            set;
        }

        public string[] fields
        {
            get;
            set;
        }

        public string sessionToken
        {
            get;
            set;
        }

        public string language
        {
            get;
            set;
        }


        public override string URL => base.URL + "details/" + this.ToUri().ToString();
    }
}
