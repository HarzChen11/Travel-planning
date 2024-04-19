using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace MapProject
{
    internal class MakerHelper : MapHelper
    {
        GMapOverlay markers = new GMapOverlay("makers");

        //public GMapOverlay setMapMarker(double lat,double lng, ToolTip toolTip = null)
        //{

        //    GMapMarker maker = new GMarkerGoogle(new PointLatLng(lat,lng), GMarkerGoogleType.red_dot);

        //    markers.Markers.Add(maker);
        //    if(toolTip !=null)
        //    {
        //        maker.ToolTipText = toolTip.Text;
        //        maker.ToolTip.Fill = new SolidBrush(toolTip.Backgroud);
        //        maker.ToolTip.Foreground = toolTip.FontColor;
        //        maker.ToolTip.TextPadding = toolTip.Size;
        //    }

        //    return markers;
        //}


        GMapMarker maker;
        public override GMapOverlay SetOverLay(List<PointLatLng> list, ToolTip toolTip)
        {
            foreach (var point in list)
            {
                GMapMarker maker = new GMarkerGoogle(new PointLatLng(point.Lat, point.Lng), GMarkerGoogleType.red_dot);

                markers.Markers.Add(maker);
                if (toolTip != null)
                {
                    maker.ToolTipText = toolTip.Text;
                    maker.ToolTip.Fill = new SolidBrush(toolTip.Backgroud);
                    maker.ToolTip.Foreground = toolTip.FontColor;
                    maker.ToolTip.TextPadding = toolTip.Size;
                }
            }

            return markers;
        }

        public override GMapOverlay SetOverLay(double lat, double lng, ToolTip toolTip = null)
        {
            GMapMarker maker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);

            markers.Markers.Add(maker);
            if (toolTip != null)
            {
                maker.ToolTipText = toolTip.Text;
                maker.ToolTip.Fill = new SolidBrush(toolTip.Backgroud);
                maker.ToolTip.Foreground = toolTip.FontColor;
                maker.ToolTip.TextPadding = toolTip.Size;
            }

            return markers;
        }

        public override GMapOverlay SetOverLay(List<PointLatLng> list)
        {
            foreach (var point in list)
            {
                GMapMarker markers = new GMarkerGoogle(new PointLatLng(point.Lat, point.Lng), GMarkerGoogleType.red_dot);
            }


            //markers.Markers.Add(maker);
            //if (toolTip != null)
            //{
            //    maker.ToolTipText = toolTip.Text;
            //    maker.ToolTip.Fill = new SolidBrush(toolTip.Backgroud);
            //    maker.ToolTip.Foreground = toolTip.FontColor;
            //    maker.ToolTip.TextPadding = toolTip.Size;
            //}

            return markers;
        }

        public override GMapOverlay SetOverLay(IEnumerable<PointLatLng> list)
        {
            foreach (var point in list)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(point.Lat, point.Lng), GMarkerGoogleType.red_dot);
                markers.Markers.Add(maker);
            }


            return this.markers;
        }
    }

    public class ToolTip
    {
        public String Text { get; set; }
        public Color Backgroud { get; set; }
        public System.Drawing.Brush FontColor { get; set; }
        public Size Size { get; set; }


        public ToolTip(String Text)
        {
            this.Text = Text;
            this.Backgroud = Color.Aqua;
            this.FontColor = Brushes.Black;
            this.Size = new Size(20, 20);
        }

        public ToolTip(String Text, Size Size)
        {
            this.Text = Text;
            this.Backgroud = Color.Aqua;
            this.FontColor = Brushes.Black;
            this.Size = Size;
        }
        public ToolTip(String Text, int width, int height)
        {
            this.Text = Text;
            this.Backgroud = Color.Aqua;
            this.FontColor = Brushes.Black;
            this.Size = new Size(width, height);
        }

        public ToolTip(String Text, Color Background, Brush FontColor, Size size)
        {
            this.Text = Text;
            this.Backgroud = Background;
            this.FontColor = FontColor;
            this.Size = size;
        }
    }
}
