using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProject
{
    public abstract class MapHelper
    {
        //List<PointLatLng> list = new List<PointLatLng>();
        public abstract GMapOverlay SetOverLay(double lat, double lng, ToolTip toolTip = null);

        public abstract GMapOverlay SetOverLay(List<PointLatLng> list, ToolTip toolTip = null);
        public abstract GMapOverlay SetOverLay(IEnumerable<PointLatLng> list);
        public abstract GMapOverlay SetOverLay(List<PointLatLng> list);

    }
}
