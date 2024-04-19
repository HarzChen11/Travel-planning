using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GoogleMapAPI.Place.BasePlace;
using GoogleMapAPI.Place.TextSearch;
using MapFunction;
using MapProject;
using 旅遊景點.Utility;

namespace 旅遊景點
{
    public partial class 地點條件搜尋 : Form
    {
        public 地點條件搜尋()
        {
            InitializeComponent();
            List<comBoxData> type = new List<comBoxData>();
            type.Add(new comBoxData("請選擇", ""));
            type.Add(new comBoxData("學校", "school"));
            type.Add(new comBoxData("機場", "airport"));
            type.Add(new comBoxData("公車站", "bus_station"));
            type.Add(new comBoxData("ATM", "atm"));
            type.Add(new comBoxData("麵包店", "bakery"));
            type.Add(new comBoxData("酒吧", "bar"));
            type.Add(new comBoxData("咖啡店", "cafe"));
            type.Add(new comBoxData("租車行", "car_rental"));
            type.Add(new comBoxData("衣服店", "clothing_store"));
            type.Add(new comBoxData("超市", "shopping_mall"));
            type.Add(new comBoxData("市中心", "city_hall"));
            type.Add(new comBoxData("便利商店", "convenience_store"));
            type.Add(new comBoxData("百貨公司", "department_store"));

            comboBox1.DataSource = type;
            comboBox1.DisplayMember = "key";
            comboBox1.ValueMember = "value";

            listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;

        }
        List<LocationData> datasource = new List<LocationData>();

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            String place = (String)listBox1.SelectedItem;
            LocationData data = datasource.Where(x => x.Place.Equals(place)).First();
            gMapControl1.Position = new GMap.NET.PointLatLng(data.lat, data.lng);

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance; //設定地圖來源
            GMaps.Instance.Mode = AccessMode.ServerAndCache; //GMap工作模式
            this.gMapControl1.ShowCenter = false; //隱藏中間的十字架
            this.gMapControl1.MaxZoom = 20; //最大縮放
            this.gMapControl1.MinZoom = 10; //最小縮放
            this.gMapControl1.Zoom = 17;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            gMapControl1.Overlays.Clear();
            TextSearchRequest searchRequest = new TextSearchRequest();
            searchRequest.radius = int.Parse(textBox1.Text) * 10000;
            searchRequest.type = ((comBoxData)comboBox1.SelectedItem).value;
            searchRequest.language = "zh-TW";
            var PlaceDetailResponse = new PlaceService().GetResponse<TextSearchResponse>(searchRequest);
            datasource = PlaceDetailResponse.results.Select(x => new LocationData()
            {
                lat = x.geometry.location.lat,
                lng = x.geometry.location.lng,
                Place = x.name,
                PlaceID = x.place_id,
                Address = x.formatted_address,


            }).ToList();
            gMapControl1.SetMarkers(datasource);
            datasource.ForEach(x =>
            {
                listBox1.Items.Add(x.Place);
            });

            listBox1.SetSelected(0, true);
        }

        private void addFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                String place = (String)listBox1.SelectedItem;
                LocationData data = datasource.Where(x => x.Place.Equals(place)).First();
                CSVHelper helper = new CSVHelper();
                helper.WriteCSV("我的最愛.csv", data);

            }
            catch (Exception ex)
            {
                MessageBox.Show("該景點已重複加入");
            }
        }
    }
}

