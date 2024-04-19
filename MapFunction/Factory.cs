using GMap.NET;
using GMap.NET.WindowsForms;
using MapFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProject
{
    public class Factory
    {
        //public static MapHelper GetOverlay(string ClassName)
        //{
        //    MapHelper helper = null;
        //    switch (ClassName)
        //    {
        //        case "1":
        //            setMap = new MakerHelper();
        //            break;
        //        case "2":
        //            setMap = new RouteMaker();
        //            break;
        //    }
        //    return setMap;
        //}

        public static GMapOverlay GetOverlay(MapEnum map, double lat, double lng)
        {
            return GetMapHelper(map).SetOverLay(lat, lng);
        }

        public static GMapOverlay GetOverlay(MapEnum map, IEnumerable<PointLatLng> list)
        {
            return GetMapHelper(map).SetOverLay(list);
        }

   
        private static MapHelper GetMapHelper(MapEnum map)
        {
            MapHelper helper = null;
            switch (map)
            {
                case MapEnum.Maker:
                    helper = new MakerHelper();
                    break;
                case MapEnum.Route:
                    helper = new RouteHelper();
                    break;
            }
            return helper;
        }
    }
}

