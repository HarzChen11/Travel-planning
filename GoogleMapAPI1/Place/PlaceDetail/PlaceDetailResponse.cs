using Google.Maps.Places;
using Google.Maps.Places.Details;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Details.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.PlaceDetail
{
    public class PlaceDetailResponse : BasePlace.PlaceResponse
    {

        [JsonProperty("result")]
        public PlaceDetailsResult Result
        {
            get;
            set;
        }

        public class PlaceDetailsResult
        {
            [JsonProperty("address_components")]
            public AddressComponent[] AddressComponents
            {
                get;
                set;
            }

            [JsonProperty("formatted_address")]
            public string FormattedAddress
            {
                get;
                set;
            }

            [JsonProperty("formatted_phone_number")]
            public string FormattedPhoneNumber
            {
                get;
                set;
            }

            [JsonProperty("geometry")]
            public Geometry Geometry
            {
                get;
                set;
            }

            [JsonProperty("icon")]
            public string icon
            {
                get;
                set;
            }

            [JsonProperty("international_phone_number")]
            public string InternationalPhoneNumber
            {
                get;
                set;
            }

            [JsonProperty("name")]
            public string Name
            {
                get;
                set;
            }

            [JsonProperty("opening_hours")]
            public Google.Maps.Places.Details.OpeningHours OpeningHours
            {
                get;
                set;
            }

            [JsonProperty("permanently_closed")]
            public bool PermanentlyClosed
            {
                get;
                set;
            }

            [JsonProperty("photos")]
            public Google.Maps.Places.Details.Photo[] Photos
            {
                get;
                set;
            }

            [JsonProperty("place_id")]
            public string PlaceID
            {
                get;
                set;
            }

            [JsonProperty("scope")]
            public GoogleApi.Entities.Places.Common.Enums.Scope Scope
            {
                get;
                set;
            }

            [JsonProperty("alt_ids")]
            public AltID[] AltIDs
            {
                get;
                set;
            }

            [JsonProperty("price_level")]
            public Google.Maps.Places.Details.PriceLevel PriceLevel
            {
                get;
                set;
            }

            [JsonProperty("rating")]
            public float Rating
            {
                get;
                set;
            }

            [JsonProperty("reviews")]
            public Google.Maps.Places.Details.Review[] Reviews
            {
                get;
                set;
            }

            [JsonProperty("types")]
            public PlaceType[] Types
            {
                get;
                set;
            }

            [JsonProperty("url")]
            public string URL
            {
                get;
                set;
            }

            [JsonProperty("utc_offset")]
            public int UtcOffset
            {
                get;
                set;
            }

            [JsonProperty("vicinity")]
            public string Vicinity
            {
                get;
                set;
            }

            [JsonProperty("website")]
            public string Website
            {
                get;
                set;
            }
        }
    }
}
