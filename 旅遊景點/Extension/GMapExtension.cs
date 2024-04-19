using GMap.NET;
using GMap.NET.WindowsForms;
using MapFunction;
using MapProject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 旅遊景點.Service;

namespace 旅遊景點.Extension
{
    public static class GMapExtension
    {
        
        public static void AddRoutes(this GMapControl gMap,List<PointLatLng> routes)
        {
            gMap.AddOverlays(Factory.GetOverlay(MapEnum.Route, routes));
            gMap.AddOverlays(Factory.GetOverlay(MapEnum.Maker, routes.First().Lat, routes.First().Lng));
            gMap.AddOverlays(Factory.GetOverlay(MapEnum.Maker, routes.Last().Lat, routes.Last().Lng));
        }

        public static void AddOverlays(this GMapControl gMap, GMapOverlay overlay)
        {
            gMap.Overlays.Add(overlay);
            double zoom = gMap.Zoom;
            gMap.Zoom = gMap.MinZoom;
            gMap.Zoom = zoom;
        }

        /// <summary>
        /// 地圖快照
        /// </summary>
        /// <returns>回傳照片儲存路徑</returns>
        public static string TakePhoto(this GMapControl gMap,string journeyName,string imgName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            gMap.Zoom = 14;
            Thread.Sleep(1000);
            Image b = gMap.ToImage();

            string path = projectDirectory + $"\\旅遊景點\\Datas\\travel\\{journeyName}\\";

            b.Save(path +imgName+".jpeg", ImageFormat.Jpeg);
            path += imgName + ".jpeg";
            return path;
        }
    }
}
