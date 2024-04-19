using GoogleMapAPI.Place.BasePlace;
using GoogleMapAPI.Place.Photo;
using GoogleMapAPI.Place.PlaceDetail;
using MapFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊景點
{
    public partial class SliderBox : UserControl
    {

        public SliderBox()
        {
            InitializeComponent();
        }
        private List<Bitmap> _data = new List<Bitmap>();
        public List<Byte[]> Data
        {

            set
            {
                // 圖片編號先歸零
                reset();
                this._data.Clear();
                // value 是從外部傳進來的 List<Byte[]> list
                value.ForEach(x => this._data.Add(ByteToImage(x)));
                if (this._data.FirstOrDefault() != null)
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = this._data.First();
                CheckNumber();
            }
        }

        public Bitmap ByteToImage(byte[] b)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = b;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        int number = 0;
        private void nextClick(object sender, EventArgs e)
        {
            if (number < _data.Count)
            {
                number++;
                //button1.Enabled = true;
            }
            CheckNumber();
            //else
            //{
            //    button2.Enabled = false;

            //}


            pictureBox1.Image = _data[number];
        }



        private void precedClick(object sender, EventArgs e)
        {
            if (number > 0)
            {
                number--;
                //button2.Enabled = true;
            }
            CheckNumber();
            //else
            //{
            //    button1.Enabled = false;
            //}
            pictureBox1.Image = _data[number];
        }

        public void CheckNumber()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            if (number == 0)
            {
                button1.Enabled = false;
            }
            else if (number == _data.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        public void reset()
        {
            number = 0;
        }
    }
}
