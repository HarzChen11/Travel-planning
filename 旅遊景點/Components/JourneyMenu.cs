using MapFunction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點.Models;

namespace 旅遊景點.Components
{
    public partial class JourneyMenu : UserControl
    {
        string projectDirectory;
        public JourneyMenu()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        }

        //JourneyModel model = new JourneyModel();
        private void Show_JourneyForm(object sender, EventArgs e)
        {
            string JourneyName = this.JourneryNameTab.Text;
            string PlaceName = Path.GetFullPath(projectDirectory + "\\旅遊景點\\Datas\\travel\\" + JourneyName + "\\" + JourneyName + ".json");
            string Image = projectDirectory + "\\旅遊景點\\Datas\\travel\\" + JourneyName + "\\" + JourneyName + ".jpeg";

            StreamReader streamReader = new StreamReader(PlaceName, Encoding.UTF8);
            string str = "";
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                str += line;
            }

            streamReader.Close();

            List<Schedule> schedulesList = new List<Schedule>();
            List<Travel> TravelList = JsonConvert.DeserializeObject<List<Travel>>(str);

            JourneyForm journeyForm = new JourneyForm(JourneyName, Image, TravelList);
            journeyForm.ShowDialog();
            //string id = TravelList[0].travels[0].PlaceID;
            //Console.WriteLine(id);

        }

    }
}
