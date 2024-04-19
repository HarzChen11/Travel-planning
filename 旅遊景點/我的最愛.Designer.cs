namespace 旅遊景點
{
    partial class 我的最愛
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuControl1 = new 旅遊景點.MenuControl();
            this.sliderBox1 = new 旅遊景點.SliderBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(157, 580);
            this.listBox1.TabIndex = 1;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(175, 46);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(504, 405);
            this.gMapControl1.TabIndex = 2;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(176, 469);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(851, 150);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // menuControl1
            // 
            this.menuControl1.BackColor = System.Drawing.SystemColors.Control;
            this.menuControl1.Location = new System.Drawing.Point(-8, 3);
            this.menuControl1.Margin = new System.Windows.Forms.Padding(4);
            this.menuControl1.Name = "menuControl1";
            this.menuControl1.Size = new System.Drawing.Size(437, 34);
            this.menuControl1.TabIndex = 0;
            // 
            // sliderBox1
            // 
            this.sliderBox1.Location = new System.Drawing.Point(684, 97);
            this.sliderBox1.Margin = new System.Windows.Forms.Padding(2);
            this.sliderBox1.Name = "sliderBox1";
            this.sliderBox1.Size = new System.Drawing.Size(369, 301);
            this.sliderBox1.TabIndex = 7;
            // 
            // 我的最愛
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 631);
            this.Controls.Add(this.sliderBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuControl1);
            this.Name = "我的最愛";
            this.Text = "我的最愛";
            this.ResumeLayout(false);

        }

        #endregion

        private MenuControl menuControl1;
        private System.Windows.Forms.ListBox listBox1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private SliderBox sliderBox1;
    }
}