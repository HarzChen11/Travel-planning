using GMap.NET;
using GMap.NET.MapProviders;
using MapFunction;
using MapProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點.Utility;
using GoogleMapAPI.Place.PlaceDetail;
using GoogleMapAPI.Place.BasePlace;
using GoogleMapAPI.Place.Photo;
using System.IO;

namespace 旅遊景點
{
    public partial class 我的最愛 : Form
    {
        List<LocationData> datasource = new List<LocationData>();
        public 我的最愛()
        {
            InitializeComponent();
            CSVHelper helper = new CSVHelper();
            datasource = helper.ReadCSVModel<LocationData>("我的最愛.csv");
            datasource.ForEach(x => listBox1.Items.Add(x.Place));
            gMapControl1.SetMarkers(datasource);

            listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;

            flowLayoutPanel1.AutoScroll = true;
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

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            String place = (String)listBox1.SelectedItem;
            LocationData data = datasource.Where(x => x.Place.Equals(place)).First();
            gMapControl1.Position = new GMap.NET.PointLatLng(data.lat, data.lng);
            PlaceDetailRequest PlaceDetail = new PlaceDetailRequest();
            //Console.WriteLine(PlaceDetail.place_id);
            PlaceDetail.language = "zh-TW";
            var PlaceDetailResponse = new PlaceService().GetResponse<PlaceDetailResponse>(PlaceDetail);

            // 此時這邊拉回的 list 資料是 "2進位" 資料，需將資料傳進 sliderBox1，再透過解碼變成圖片格式
            List<Byte[]> list = new List<Byte[]>();
            foreach (var item in PlaceDetailResponse.result.photos)
            {
                PlacePhotoRequest photo = new PlacePhotoRequest();
                photo.photo_reference =item.photo_reference;
                Byte[] b = new PlaceService().GetImage(photo);
                list.Add(b);
            }

            sliderBox1.Data=list;

            foreach (var item in PlaceDetailResponse.result.reviews)
            {
                TextMessage message = new TextMessage(item);
                flowLayoutPanel1.Controls.Add(message);
            }
            
            
        }

      
    }
}
