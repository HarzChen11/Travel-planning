using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MapFunction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProject
{
    public static class Extension
    {
        static GMapOverlay markers = new GMapOverlay("makers");
        public static void SetMarkers(this GMapControl control, double lat, double lng, ToolTip toolTip = null)
        {
            control.Position = new GMap.NET.PointLatLng(lat, lng);
            GMapMarker maker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);

            if (toolTip != null)
            {
                maker.ToolTipText = toolTip.Text;
                maker.ToolTip.Fill = new SolidBrush(toolTip.Backgroud);
                maker.ToolTip.Foreground = toolTip.FontColor;
                maker.ToolTip.TextPadding = toolTip.Size;
            }
            markers.Markers.Add(maker);
            control.Overlays.Add(markers);


        }

        public static void removeOverlays(this GMapControl control)
        {
            foreach(var overlay in control.Overlays)
            {
                overlay.Routes.Clear();
                overlay.Markers.Clear();
            }
            control.Overlays.Clear();

        }

        public static int MarkerCounts(this GMapControl control)
        {
            return markers.Markers.Count;
        }

        public static void SetMarkers(this GMapControl control, List<LocationData> list)
        {

            list.ForEach(x =>
            {

                GMapMarker maker = new GMarkerGoogle(new PointLatLng(x.lat, x.lng), GMarkerGoogleType.red_dot);
                ToolTip toolTip = new MapProject.ToolTip(x.Place);
                maker.ToolTipText = toolTip.Text;
                maker.ToolTip.Fill = new SolidBrush(toolTip.Backgroud);
                maker.ToolTip.Foreground = toolTip.FontColor;
                maker.ToolTip.TextPadding = toolTip.Size;
                markers.Markers.Add(maker);

            });
           // control.Position = new GMap.NET.PointLatLng(list[0].lat, list[0].lng);

            control.Overlays.Add(markers);



        }
    }
}
