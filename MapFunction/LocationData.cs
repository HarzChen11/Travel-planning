using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFunction
{
    public class LocationData
    {
        [Ignore]
        [DisplayName("第幾天")]
        public string DayNumber { get; set; } = "0";
        [DisplayName("地點")]
        public String Place { get; set; }
        [DisplayName("地址")]
        public String Address { get; set; }
        [DisplayName("PlaceID")]
        [Ignore]
        public String PlaceID { get; set; }
        [DisplayName("緯度")]
        [Ignore]
        public double lat { get; set; }
        [DisplayName("經度")]
        [Ignore]
        public double lng { get; set; }
        [DisplayName("出發時間")]
        public string DepartureTime { get; set; }
        [DisplayName("抵達時間")]
        public string ArrivelTime { get; set; }

        [DisplayName("出發日期")]
        [Ignore]
        public string start { get; set; } = "";
        [DisplayName("回程日期")]
        [Ignore]
        public string end { get; set; } = "";
        [DisplayName("遊玩天數")]
        [Ignore]
        public string Day { get; set; }

        public LocationData(string Place, string Address, string PlaceID, double lat, double lng)
        {
            this.Place = Place;
            this.Address = Address;
            this.PlaceID = PlaceID;
            this.lat = lat;
            this.lng = lng;
        }

        public LocationData(string Place, string PlaceID, double lat, double lng)
        {
            this.Place = Place;
            this.PlaceID = PlaceID;
            this.lat = lat;
            this.lng = lng;
        }

        public LocationData(string Place, double lat, double lng)
        {
            this.Place = Place;
            this.lat = lat;
            this.lng = lng;

        }

        public LocationData(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }
        public LocationData()
        {

        }
    }
}
