using Google.Maps;
using GoogleMapAPI.Request.GeoCoding;
using System.Collections.Generic;
using BaseRequest = GoogleMapAPI.Request.GeoCoding.BaseRequest;

namespace GoogleMapAPI.Directions
{
    public class DirectionsRequest : BaseRequest
    {
        public DirectionsRequest(Location origin, Location destination, TravelModelEnum travelModel, bool alternatives = true)
        {
            //, bool avoidFerries, bool avoidHighways, bool avoidTolls
            this.origin = origin;
            this.destination = destination;
            this.travelModel = travelModel;
            this.alternatives = alternatives;
            //this.avoidFerries = avoidFerries;
            //this.avoidHighways = avoidHighways;
            //this.avoidTolls = avoidTolls;
        }

        public DirectionsRequest(List<Location> list, TravelModelEnum travelModel, bool alternatives = true)
        {
            //, bool avoidFerries, bool avoidHighways, bool avoidTolls
            this.list = list;
            this.travelModel = travelModel;
            this.alternatives = alternatives;
            //this.avoidFerries = avoidFerries;
            //this.avoidHighways = avoidHighways;
            //this.avoidTolls = avoidTolls;
        }

        public DirectionsRequest(Location origin, Location destination, List<string> WayPointList, TravelModelEnum travelModel, bool alternatives = true)
        {
            this.origin = origin;
            this.destination = destination;
            this.wayPointList = WayPointList;
            this.travelModel = travelModel;
            this.alternatives = alternatives;
        }
        public string waypoints { get; set; }
        private List<string> wayPointList
        {
            set
            {
                this.waypoints = "optimize:true|";
                foreach (var item in value)
                {
                    this.waypoints += item + "|";
                }
                this.waypoints = this.waypoints.TrimEnd('|');
            }
        }

        public List<Location> list
        {
            get;
            set;
        }

        public Location origin
        {
            get;
            set;
        }

        public Location destination
        {
            get;
            set;
        }



        public string language
        {
            get;
            set;
        }

        public TravelModelEnum travelModel
        {
            get;
            set;
        }

        public bool alternatives
        {
            get;
            set;
        }

        public bool avoidFerries
        {
            get;
            set;
        }

        public bool avoidHighways
        {
            get;
            set;
        }

        public bool avoidTolls
        {
            get;
            set;
        }

        public override string URL => "https://maps.googleapis.com/maps/api/directions/" + this.ToUri().ToString();
    }
}
