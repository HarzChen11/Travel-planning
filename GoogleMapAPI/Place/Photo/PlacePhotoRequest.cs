using GoogleMapAPI.Place.BasePlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.Photo
{
    public class PlacePhotoRequest : PlaceRequest
    {
        public string photo_reference { get; set; }
        public override string URL => base.URL + "photo?maxwidth=400&" + this.ToUri(true).ToString();
    }
}
