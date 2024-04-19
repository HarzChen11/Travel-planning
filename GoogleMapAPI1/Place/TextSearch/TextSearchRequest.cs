using GoogleMapAPI.Place.BasePlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.TextSearch
{
    public class TextSearchRequest : PlaceRequest
    {

        public string query
        {
            get;
            set;
        }

        public string language
        {
            get;
            set;
        }

        public string pageToken
        {
            get;
            set;
        }

        public override string URL => base.URL + "textsearch/" + this.ToUri().ToString();
    }
}
