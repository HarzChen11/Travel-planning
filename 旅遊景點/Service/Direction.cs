using GMap.NET;
using GoogleMapAPI.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點.Service
{
    internal class Direction
    {
        private DirectionsResponse _response;
        public String RoutesInfo
        {
            get
            {
                List<string> list = new List<string>();
                string result = "";
                this._response.routes[0].legs[0].steps.ToList().ForEach(step => result += step.html_instructions);
                return result;
            }
        }

        //public List<LocationData> DirectionData
        //{
        //    get
        //    {
        //        LocationData data = new LocationData(_response.routes[0].legs[0].start_address, _response.routes[0].legs[0].start_location.lat, _response.routes[0].legs[0].start_location.lng);
        //        LocationData data2 = new LocationData(_response.routes[0].legs[0].end_address, _response.routes[0].legs[0].end_location.lat, _response.routes[0].legs[0].end_location.lng);
        //        List<LocationData> list = new List<LocationData>();
        //        list.Add(data);
        //        list.Add(data2);
        //        return list;
        //    }
        //}

        public IEnumerable<PointLatLng> PolyLine
        {
            get
            {
                string line = this._response.routes[0].overview_polyline.points;
                return Decode(line);
              }
        }

        public DirectionsResponse getPlaceDirection(String placeA, String placeB)
        {
            DirectionsRequest direction = new DirectionsRequest(placeA, placeB, TravelModelEnum.DRIVING);
            direction.language = "zh-TW";
            this._response = new DirectionService().GetResponse(direction);

            return this._response;
        }



        public IEnumerable<PointLatLng> Decode(string polylineString)
        {
            if (string.IsNullOrEmpty(polylineString))
                throw new ArgumentNullException(nameof(polylineString));

            var polylineChars = polylineString.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polylineChars.Length)
            {
                // Next lat
                var sum = 0;
                var shifter = 0;
                int nextFiveBits;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // Next lng
                sum = 0;
                shifter = 0;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && nextFiveBits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                yield return new PointLatLng(Convert.ToDouble(currentLat) / 1E5, Convert.ToDouble(currentLng) / 1E5);

            }
        }

    }
}
