using MapFunction;
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
using 旅遊景點.Components;
using 旅遊景點.Models;

namespace 旅遊景點
{
    public partial class 行程總覽 : Form
    {
        string image;
        string projectDirectory;
        public 行程總覽()
        {
            InitializeComponent();

            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            Creat_journeyManu();

            pictureBox1.Image = Image.FromFile(projectDirectory + "\\image.jpeg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Creat_journeyManu()
        {
            string[] PlaceName = Directory.GetDirectories(projectDirectory+"\\旅遊景點\\Datas\\travel");
            foreach (var item in PlaceName)
            {
                JourneyMenu journeyManu = new JourneyMenu();
                string FileName = item.Split('\\')[9];
                journeyManu.JourneryNameTab.Text = FileName;
                journeyManu.pictureBox1.Image = Image.FromFile(item + '\\' + FileName + ".jpeg");
                flowLayoutPanel1.Controls.Add(journeyManu);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = (@"C:\Users\user\Downloads");
            openFileDialog.Filter = "圖片檔|*.png;.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox pictureBox = (PictureBox)sender;
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                image = openFileDialog.FileName;
            }
        }

        Form JourneyForm;
        private void NewJourney(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int dayConunt = Convert.ToInt32(textBox2.Text);
            string date = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string day = textBox2.Text;

            string end = dateTimePicker1.Value.AddDays(dayConunt - 1).ToString("yyyy/MM/dd");

            JourneyModel model = new JourneyModel(name, dayConunt, image, date, end, day);
            JourneyForm = new JourneyForm(model);
            JourneyForm.FormClosed += JourneyForm_FormClosed;
            JourneyForm.Show();
            if (JourneyForm.DialogResult.ToString() == "Close")
            {
                JourneyForm_FormClosed();
            }
        }

        private void JourneyForm_FormClosed(object sender = null, FormClosedEventArgs e = null)
        {
            foreach (var item in this.flowLayoutPanel1.Controls)
            {
                if (item is JourneyMenu)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
            }
            Creat_journeyManu();
        }
    }
}
