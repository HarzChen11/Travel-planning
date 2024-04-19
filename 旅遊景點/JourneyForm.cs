using Aspose.Words;
using GMap.NET;
using GMap.NET.MapProviders;
using GoogleMapAPI.Directions;
using GoogleMapAPI.Utility;
using MapFunction;
using MapProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using 旅遊景點.Components;
using 旅遊景點.Extension;
using 旅遊景點.Models;
using 旅遊景點.Service;
using 旅遊景點.Utility;
using DirectionService = GoogleMapAPI.Directions.DirectionService;
using Font = System.Drawing.Font;

namespace 旅遊景點
{
    public partial class JourneyForm : Form
    {
        string PlaceName;
        Place place = new Place();
        Schedule schedule;
        List<Schedule> schedulesList = new List<Schedule>();
        List<LocationData> LocationDataList = new List<LocationData>();
        JourneyModel journey;
        bool isEdit = false;
        Dictionary<int, List<Schedule>> dictionary = new Dictionary<int, List<Schedule>>();
        List<LocationData> datasource = new List<LocationData>();
        string projectDirectory;

        public JourneyForm(JourneyModel Journey)
        {
            InitializeComponent();

            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            this.journey = Journey;

            journeyNameLab.Text = journey.journeyName;
            journeyDayCountLab.Text = journey.day.ToString();

            int days = Convert.ToInt32(journey.day);
            initTabPages(days);
            autoCompleteTextBox1.KeyUp += AutoCompleteTextBox1_KeyUp;
            autoCompleteTextBox1.ShowMap += AutoCompleteTextBox1_ShowMap;
        }

        /// <summary>
        /// 行程總覽編輯行程介面
        /// </summary>
        /// <param name="JourneyName">行程行稱</param>
        /// <param name="travels"></param>
        public JourneyForm(string JourneyName, string Image, List<Travel> travels)
        {
            InitializeComponent();

            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine(projectDirectory);

            isEdit = true;
            this.journeyNameLab.Text = JourneyName;
            this.journeyDayCountLab.Text = travels[0].travels[0].Day;
            initTabPages(travels);
            string start = travels.First().travels[0].start;
            string end = travels.Last().travels.Last().end;
            journey = new JourneyModel(JourneyName, travels.Count, Image, start, end, journeyDayCountLab.Text);
            autoCompleteTextBox1.KeyUp += AutoCompleteTextBox1_KeyUp;
            autoCompleteTextBox1.ShowMap += AutoCompleteTextBox1_ShowMap;
            // 標記所有景點位置
            this.gMapControl1.SetMarkers(travels[0].travels);
            // 劃出景點路線
            Router_Click();

            this.gMapControl1.Zoom = 14;
        }

        /// <summary>
        /// 拉出行程總覽中已儲存的行程記錄
        /// </summary>
        private void initTabPages(List<Travel> travelList)
        {
            for (int i = 0; i < travelList.Count(); i++)
            {
                TabPage tabPage = new TabPage();
                tabPage.Name = "tabPage" + i;
                tabPage.Text = "第" + (i + 1) + "天";
                tabPage.Width = 530;
                tabPage.Font = new Font("微軟正黑體", 10, FontStyle.Bold);

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Width = 490;
                panel.Height = 495;
                panel.AutoScroll = true;

                tabPage.Controls.Add(panel);
                tabControl2.Controls.Add(tabPage);

                Button button = new Button();
                tabPage.Controls.Add(button);
                button.Location = new Point(360, 440);
                button.Text = "+";
                button.Font = new Font("微軟正黑體", 13, FontStyle.Bold);
                button.Size = new Size(35, 35);
                button.BringToFront();
                button.Click += AddSchedule;
                button.Tag = panel;

                CSVHelper helper = new CSVHelper();
                datasource = helper.ReadCSVModel<LocationData>("我的最愛.csv");
                datasource.ForEach(x => listBox1.Items.Add(x.Place));

                listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
                List<Schedule> schedules = new List<Schedule>();
                for (int j = 0; j < travelList[i].travels.Count(); j++)
                {
                    Schedule schedule = new Schedule();
                    schedule.Click += Schedule_Click;
                    schedule.BorderStyle = BorderStyle.FixedSingle;
                    var travel = travelList[i].travels[j];
                    schedule.dateTimePicker1.Value = DateTime.Parse(travel.ArrivelTime);
                    schedule.dateTimePicker2.Value = DateTime.Parse(travel.DepartureTime);
                    schedule.label3.Text = travel.Place;
                    schedule.LocationData = travel;
                    panel.Controls.Add(schedule);
                    schedules.Add(schedule);
                }
                dictionary.Add(i + 1, schedules);
            }


        }

        /// <summary>
        /// 初始化行程天數
        /// </summary>
        /// <param name="days">產生旅遊天數</param>
        private void initTabPages(int days)
        {
            for (int i = 1; i <= days; i++)
            {
                TabPage tabPage = new TabPage();
                tabPage.Name = "tabPage" + i;
                tabPage.Text = "第" + i + "天";
                tabPage.Width = 530;
                tabPage.Font = new Font("微軟正黑體", 10, FontStyle.Bold);

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Width = 490;
                panel.Height = 495;
                panel.AutoScroll = true;

                tabPage.Controls.Add(panel);
                tabControl2.Controls.Add(tabPage);

                Button button = new Button();
                tabPage.Controls.Add(button);
                button.Location = new Point(360, 440);
                button.Text = "+";
                button.Font = new Font("微軟正黑體", 13, FontStyle.Bold);
                button.Size = new Size(35, 35);
                button.BringToFront();
                button.Click += AddSchedule;
                button.Tag = panel;

                dictionary.Add(i, new List<Schedule>());

                CSVHelper helper = new CSVHelper();
                datasource = helper.ReadCSVModel<LocationData>("我的最愛.csv");
                datasource.ForEach(x => listBox1.Items.Add(x.Place));

                listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
            }
        }

        /// <summary>
        /// 選擇景點並透過地圖顯示景點所在位置
        /// </summary>
        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            String place = (String)listBox1.SelectedItem;
            LocationData data = datasource.Where(x => x.Place.Equals(place)).First();
            gMapControl1.Position = new GMap.NET.PointLatLng(data.lat, data.lng);
            this.gMapControl1.SetMarkers(data.lat, data.lng, new MapProject.ToolTip(data.Place));
        }

        /// <summary>
        /// 增加該天數下的每一個行程
        /// </summary>
        private void AddSchedule(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            FlowLayoutPanel panel = (FlowLayoutPanel)button.Tag;

            Schedule schedule = new Schedule();
            schedule.Click += Schedule_Click;
            schedule.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(schedule);
            dictionary[tabControl2.SelectedIndex + 1].Add(schedule);
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            //Button Del_Button = (Button)sender;
            //Schedule schedule=(Schedule)Del_Button.Tag;
            Console.WriteLine("1");
        }

        /// <summary>
        /// 顯示當前要編輯的行程
        /// </summary>
        private void Schedule_Click(object sender, EventArgs e)
        {
            PlaceName = tabControl2.TabPages[tabControl2.SelectedIndex].ToString();
            PlaceName = PlaceName.Split(':')[1].ToString();
            schedule = (Schedule)sender;
            PlaceNameTab.Text = PlaceName + schedule.label3.Text;
        }

        /// <summary>
        /// 設定地圖初始化資料
        /// </summary>
        private void gMapControl1_Load(object sender, EventArgs e)
        {
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance; //設定地圖來源
            GMaps.Instance.Mode = AccessMode.ServerAndCache; //GMap工作模式
            this.gMapControl1.ShowCenter = false; //隱藏中間的十字架
            this.gMapControl1.MaxZoom = 20; //最大縮放
            this.gMapControl1.MinZoom = 10; //最小縮放
            this.gMapControl1.Zoom = 16;
        }

        /// <summary>
        /// 根據下拉式選單選擇地點後，更新地圖顯示位置
        /// </summary>
        /// <param name="e">地點的詳細資訊</param>
        private void AutoCompleteTextBox1_ShowMap(object sender, LocationData e)
        {
            if (schedule == null)
            {
                MessageBox.Show("請先選擇要編輯的行程");
                return;
            }

            schedule.setLocationData(e, journey.date, journey.end, journey.day);
            this.gMapControl1.Position = new GMap.NET.PointLatLng(e.lat, e.lng);
            this.gMapControl1.SetMarkers(e.lat, e.lng, new MapProject.ToolTip(e.Place));
            PlaceNameTab.Text = PlaceName + schedule.label3.Text;
            this.place.getDetail(e.PlaceID);
            //Console.WriteLine("markerCounts: " + this.gMapControl1.MarkerCounts());
        }

        /// <summary>
        /// 下拉式選單選擇景點
        /// </summary>
        private void AutoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            AutoCompleteTextBox textbox = (AutoCompleteTextBox)sender;

            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                this.place.getAutoCompletePlaces(textbox.Text, predictions =>
                {
                    textbox.Values = predictions.Select(x => x.structured_formatting.main_text).ToList();
                });

            }
        }

        /// <summary>
        /// 規劃路線
        /// </summary>
        private void Router_Click(object sender = null, EventArgs e = null)
        {
            this.gMapControl1.removeOverlays();
            //Console.WriteLine("marker count: " + this.gMapControl1.ShowMarkerCounts());
            List<string> list = new List<string>();
            List<PointLatLng> points = new List<PointLatLng>();
            foreach (var item in tabControl2.TabPages[tabControl2.SelectedIndex].Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)item;
                    foreach (Schedule schedule in panel.Controls)
                    {
                        if (schedule.LocationData.PlaceID != null)
                        {
                            LocationDataList.Add(schedule.LocationData);
                            list.Add("place_id:" + schedule.LocationData.PlaceID);
                            points.Add(new PointLatLng(schedule.LocationData.lat, schedule.LocationData.lng));
                            this.gMapControl1.SetMarkers(schedule.LocationData.lat, schedule.LocationData.lng, new MapProject.ToolTip(schedule.LocationData.Place));


                        }
                    }
                }
            }

            routerPlaning(LocationDataList);
            #region
            // 1 , 2 ,3 ,4 , 5
            //List<string> waypoint = list.Skip(1).Take(list.Count - 1).ToList();
            //DirectionsRequest directionsRequest = new DirectionsRequest(list.First(), list.Last(), waypoint, TravelModelEnum.DRIVING);
            //var directionResponse = new DirectionService().GetResponse(directionsRequest);

            //List<Location> locations = PolylineHelper.Decode(directionResponse.routes[0].overview_polyline.points).ToList();

            //this.gMapControl1.AddOverlays(Factory.GetOverlay(MapEnum.Route, locations.Select(x => new PointLatLng
            //{
            //    Lat = x.lat,
            //    Lng = x.lng
            //})));
            #endregion
        }

        /// <summary>
        /// 畫出每一天行程路線
        /// </summary>
        public void routerPlaning(List<LocationData> list)
        {
            this.gMapControl1.removeOverlays();
            List<Location> locations = new List<Location>();
            // 1 , 2 ,3 ,4 , 5
            List<string> waypoint = list.Select(x => "place_id:" + x.PlaceID).Skip(1).Take(list.Count - 1).ToList();
            DirectionsRequest directionsRequest = new DirectionsRequest("place_id:" + list.First().PlaceID, "place_id:" + list.Last().PlaceID, waypoint, TravelModelEnum.DRIVING);
            var directionResponse = new DirectionService().GetResponse(directionsRequest);

            if (list.Count > 1)
            {
                locations = PolylineHelper.Decode(directionResponse.routes[0].overview_polyline.points).ToList();
            }

            this.gMapControl1.AddOverlays(Factory.GetOverlay(MapEnum.Route, locations.Select(x => new PointLatLng
            {
                Lat = x.lat,
                Lng = x.lng
            })));

            // 標記所有景點位置
            this.gMapControl1.SetMarkers(LocationDataList);
            // 停在最後一個行程的視角
            gMapControl1.Position = new GMap.NET.PointLatLng(list[0].lat, list[0].lng);
        }

        /// <summary>
        /// 存檔
        /// </summary>
        private void SaveClick(object sender, EventArgs e)
        {
            schedulesList = getData();
            foreach (Schedule schedule in schedulesList)
            {
                CSVHelper helper = new CSVHelper();
                DateTime date = schedule.dateTimePicker1.Value;
                schedule.LocationData.start = schedule.dateTimePicker1.Value.ToString("hh:MM");
                schedule.LocationData.end = schedule.dateTimePicker2.Value.ToString("hh:MM");

                int day = schedule.Day - 1;
                //Console.WriteLine(date.AddDays(day).ToString("yyyy-MM-dd") + schedule.LocationData.Place);
                helper.WriteCSV($@"travel\{journey.journeyName}\{date.AddDays(day).ToString("yyyy-MM-dd")}.csv", schedule.LocationData);
            }
            //Console.WriteLine("第" + schedule.Day + "天" + schedule.dateTimePicker1.Value.ToString("HH:mm") + schedule.dateTimePicker2.Value.ToString("HH:mm") + JsonConvert.SerializeObject(schedule.LocationData));
        }

        /// <summary>
        /// 單日行程匯出
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ExportWord exportWord = new ExportWord();
            List<LocationData> list = getData().Select(x => new LocationData
            {
                lat = x.LocationData.lat,
                lng = x.LocationData.lng,
                PlaceID = x.LocationData.PlaceID,
                DayNumber = x.Day.ToString(),
                Address = x.LocationData.Address,
                Place = x.LocationData.Place,
                Day = x.LocationData.Day,
                DepartureTime = x.dateTimePicker1.Value.ToString("hh:mm"),
                ArrivelTime = x.dateTimePicker2.Value.ToString("hh:mm"),
                start = x.LocationData.start,
                end = x.LocationData.end,
            }).ToList();

            // 執行路線規劃後 存圖
            if (list.Count > 1)
            {
                Router_Click();
            }

            gMapControl1.TakePhoto(journey.journeyName, journey.journeyName);

            exportWord.ToDataTable<LocationData>(journey.journeyName, list);
        }

        /// <summary>
        /// 紀錄TabPages每筆景點資料
        /// </summary>
        /// <returns>回傳所有景點資料</returns>
        public List<Schedule> getData()
        {
            //List<Schedule> schedulesList = new List<Schedule>();
            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                foreach (var item in tabControl2.TabPages[i].Controls)
                {
                    if (item is FlowLayoutPanel)
                    {
                        FlowLayoutPanel panel = (FlowLayoutPanel)item;
                        foreach (Schedule schedule in panel.Controls)
                        {
                            if (schedule.LocationData != null)
                            {
                                schedule.Day = i + 1;
                                schedulesList.Add(schedule);
                            }
                            else
                            {
                                MessageBox.Show("請先選擇景點");
                            }
                        }
                    }
                }
            }
            return schedulesList;
        }

        /// <summary>
        /// 紀錄TabPages每筆景點資料
        /// </summary>
        /// <returns>回傳指定天數的景點資料</returns>
        public List<Schedule> getData(int number)
        {
            //List<Schedule> schedulesList = new List<Schedule>();
            schedulesList.Clear();
            foreach (var item in tabControl2.TabPages[number].Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel panel = (FlowLayoutPanel)item;
                    foreach (Schedule schedule in panel.Controls)
                    {
                        if (schedule.LocationData != null)
                        {
                            schedule.Day = number + 1;
                            schedulesList.Add(schedule);
                        }
                        else
                        {
                            MessageBox.Show("請先選擇景點");
                        }
                    }
                }
            }
            return schedulesList;
        }

        /// <summary>
        /// 匯出整份檔案
        /// </summary>
        private void SaveAll_Click(object sender, EventArgs e)
        {
            string path = projectDirectory + $"\\旅遊景點\\Datas\\travel\\{journey.journeyName}\\";
            Console.WriteLine(path);
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (journey.image == null)
            {
                journey.image = projectDirectory + "\\image.jpeg";
            }
            if (journey.image != $"{path}{journey.journeyName}.jpeg")
                File.Copy(journey.image, $"{path}{journey.journeyName}.jpeg", true);

            ExportWord word = new ExportWord();
            Document document = word.CreateTitle(this.journey.journeyName, new LocationData()
            {
                Day = journey.day,
                start = journey.date,
                end = journey.end
            });
            List<Travel> travels = new List<Travel>();
            for (int i = 0; i < tabControl2.TabPages.Count; i++)
            {
                Travel travel = new Travel();
                travel.travels = getData(i).Select(x => new LocationData
                {
                    lat = x.LocationData.lat,
                    lng = x.LocationData.lng,
                    PlaceID = x.LocationData.PlaceID,
                    DayNumber = x.Day.ToString(),
                    Address = x.LocationData.Address,
                    Place = x.LocationData.Place,
                    Day = x.LocationData.Day,
                    DepartureTime = x.dateTimePicker1.Value.ToString("hh:mm"),
                    ArrivelTime = x.dateTimePicker2.Value.ToString("hh:mm"),
                    start = x.LocationData.start,
                    end = x.LocationData.end,
                }).ToList();

                routerPlaning(travel.travels);
                string imgPath = gMapControl1.TakePhoto(journey.journeyName, "Day_" + (i + 1));
                word.CreateTable(document, travel.travels, imgPath);
                travels.Add(travel);
            }

            word.Save(document, path + journey.journeyName);

            string result = JsonConvert.SerializeObject(travels);
            File.WriteAllText($"{path}{journey.journeyName}.json", result);
            MessageBox.Show("匯出完成，將自動關閉該頁面");
            this.Close();
        }
    }
}
