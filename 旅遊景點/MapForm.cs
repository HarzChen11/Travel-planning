using GMap.NET;
using GMap.NET.MapProviders;
using MapProject;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using 旅遊景點.Components;
using System.Diagnostics;
using System.Collections.Generic;
using 旅遊景點.Service;
using MapFunction;
using 旅遊景點.Extension;

namespace 旅遊景點
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }


        private void MapForm_Load(object sender, EventArgs e)
        {
            autoCompleteTextBox1.KeyUp += AutoCompleteTextBox1_KeyUp;
            autoCompleteTextBox2.KeyUp += AutoCompleteTextBox1_KeyUp;
            //autoCompleteTextBox1.Values = new List<string> { "one", "two", "three", "tree", "four", "fivee" };
            autoCompleteTextBox1.ShowMap += AutoCompleteTextBox1_ShowMap;
            autoCompleteTextBox2.ShowMap += AutoCompleteTextBox1_ShowMap;

            MenuControl.form = this;
        }



        Place place = new Place();
        private void AutoCompleteTextBox1_ShowMap(object sender, LocationData e)
        {
            this.gMapControl1.Position = new GMap.NET.PointLatLng(e.lat, e.lng);
            this.gMapControl1.SetMarkers(e.lat, e.lng, new MapProject.ToolTip("找到了！"));

            place.getDetail(e.PlaceID);
            webBrowser1.DocumentText = place.PlaceInfo;
        }

        private void AutoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            AutoCompleteTextBox textbox = (AutoCompleteTextBox)sender;
            //Console.WriteLine(textbox.Text);
            // regex 判斷
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                // say => say hello / say hi
                // say he => say hello
                //if (textbox.Text.Contains("h"))
                //{

                // debounce time

                //Console.WriteLine(request.URL);

                place.getAutoCompletePlaces(textbox.Text, predictions =>
                {
                    textbox.Values = predictions.Select(x => x.structured_formatting.main_text).ToList();
                });
                #region
                //foreach (var response in AutocompleteResponse.predictions)
                //{
                //    if (response.structured_formatting.main_text.Contains(textbox.Text))
                //    {
                //        Console.WriteLine(response.structured_formatting.main_text);
                //    }
                //}
                //textbox.Values = new List<string> { "one", "two", "three", "tree", "four", "fivee", "hi", "hello", "say hi", "hight" };}
                #endregion
            }


        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance; //設定地圖來源
            GMaps.Instance.Mode = AccessMode.ServerAndCache; //GMap工作模式
            this.gMapControl1.ShowCenter = false; //隱藏中間的十字架
            this.gMapControl1.MaxZoom = 20; //最大縮放
            this.gMapControl1.MinZoom = 10; //最小縮放
            this.gMapControl1.Zoom = 16;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.gMapControl1.Overlays.Clear();
            if (autoCompleteTextBox1.Text != null && autoCompleteTextBox2.Text != null)
            {
                Direction direction = new Direction();
                direction.getPlaceDirection(autoCompleteTextBox1.Text, autoCompleteTextBox2.Text);
                webBrowser1.DocumentText = direction.RoutesInfo;
                #region
                //richTextBox1.Text = result;
                //webBrowser1.Document.Write("<html><head></head><body>" + result + "</body></html>");
                //list = Response.routes[0].legs[0].steps.Select(x => x.html_instructions).ToList();
                //foreach(var item in list)
                //{
                //    richTextBox1.Text += item;
                //}
                #endregion
                var routes = direction.PolyLine.ToList();
                this.gMapControl1.AddRoutes(routes);

                // 115-117 已改用 Extension 建立路線及標記，並放上圖層
                //this.gMapControl1.AddOverlays(Factory.GetOverlay(MapEnum.Route, routes));
                //this.gMapControl1.AddOverlays(Factory.GetOverlay(MapEnum.Maker, routes.First().Lat, routes.First().Lng));
                //this.gMapControl1.AddOverlays(Factory.GetOverlay(MapEnum.Maker, routes.Last().Lat, routes.Last().Lng));

                // 117、118 已改用 Extension 刷新 zoom ，顯示路線
                //this.gMapControl1.Zoom = -16;
                //this.gMapControl1.Zoom = 16;

                //  View <=  Controller  => Model
                // MVCS => Model
                // Controller 要輕
                // Model 要重
                // Service 商業邏輯的判斷
                // View 要笨

            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

      
    }
}
