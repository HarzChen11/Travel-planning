using MapFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊景點
{
    public partial class Schedule : UserControl
    {
        public Schedule()
        {
            InitializeComponent();

        }
      

        public LocationData LocationData { get; set; }
        public void setLocationData(LocationData data, string date, string end, string day)
        {
            this.LocationData = data;
            this.label3.Text = data.Place;
            this.LocationData.start = date;
            this.LocationData.end = end;
            this.LocationData.Day = day;
        }

        public int Day { get; set; }
        private void Schedule_Load(object sender, EventArgs e)
        {

        }
 
    }
}
