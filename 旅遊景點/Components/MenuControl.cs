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
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        public static Form form = null;

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (form != null)
            {
                form.Hide();
            }


            switch (menuItem.Text)
            {
                case "MapSearch":
                    form = new MapForm();
                    form.Show();
                    break;
                case "地點條件搜尋":
                    form = new 地點條件搜尋();
                    form.Show();
                    break;
                case "行程總覽":
                    form = new 行程總覽();
                    form.Show();
                    break;
                case "我的最愛":
                    form = new 我的最愛();
                    form.Show();
                    break;
            }
        }
    }
}
