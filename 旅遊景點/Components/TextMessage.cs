using GoogleMapAPI;
using GoogleMapAPI.Place.BasePlace;
using GoogleMapAPI.Place.Photo;
using GoogleMapAPI.Place.PlaceDetail;
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
    public partial class TextMessage : UserControl
    {
        public TextMessage(PlaceDetailResponse.Review review)
        {
            InitializeComponent();
            label4.Text = review.author_name;

            string photo = review.profile_photo_url;
            Byte[] b = HttpRequest.GetRequest(photo);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = ByteToImage(b);
            label5.Text = review.rating.ToString();
            label6.Text = review.relative_time_description;
            textBox1.Text = review.text;
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
    }
}
