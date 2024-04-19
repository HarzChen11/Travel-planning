using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace MapProject
{
    public class RouteHelper : MapHelper
    {
        GMapOverlay lay = new GMapOverlay("lay");

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override GMapOverlay SetOverLay(double lat, double lng, ToolTip toolTip = null)
        {
            throw new NotImplementedException();
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override GMapOverlay SetOverLay(List<PointLatLng> list, ToolTip toolTip = null)
        {
            throw new NotImplementedException();
        }

        public override GMapOverlay SetOverLay(IEnumerable<PointLatLng> list)
        {
            //创建一条route
            GMapRoute route1 = new GMapRoute("route1");
            //设置route的颜色和粗细
            route1.Stroke = new Pen(Color.Red, 2);
            //向route中添加点
            var temp = list.ToList();
            route1.Points.AddRange(temp);

            //将route添加到图层
            lay.Routes.Add(route1);
            
            return lay;
        }

        public override GMapOverlay SetOverLay(List<PointLatLng> list)
        {
            throw new NotImplementedException();
        }

        //public GMapOverlay setRouteMaker(List<PointLatLng> list)
        //{
        //    //创建一条route
        //    GMapRoute route1 = new GMapRoute("route1");
        //    //设置route的颜色和粗细
        //    route1.Stroke = new Pen(Color.Red, 2);
        //    //向route中添加点
        //    route1.Points.AddRange(list);

        //    //将route添加到图层
        //    lay.Routes.Add(route1);


        //    return lay;
        //}

    }
}
