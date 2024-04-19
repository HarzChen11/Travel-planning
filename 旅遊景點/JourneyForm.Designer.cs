namespace 旅遊景點
{
    partial class JourneyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.journeyNameLab = new System.Windows.Forms.Label();
            this.journeyDayCountLab = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.autoCompleteTextBox1 = new 旅遊景點.Components.AutoCompleteTextBox();
            this.tabpage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.PlaceNameTab = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabpage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "行程名稱：";
            // 
            // journeyNameLab
            // 
            this.journeyNameLab.AutoSize = true;
            this.journeyNameLab.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.journeyNameLab.Location = new System.Drawing.Point(102, 26);
            this.journeyNameLab.Name = "journeyNameLab";
            this.journeyNameLab.Size = new System.Drawing.Size(15, 19);
            this.journeyNameLab.TabIndex = 1;
            this.journeyNameLab.Text = "-";
            // 
            // journeyDayCountLab
            // 
            this.journeyDayCountLab.AutoSize = true;
            this.journeyDayCountLab.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.journeyDayCountLab.Location = new System.Drawing.Point(233, 26);
            this.journeyDayCountLab.Name = "journeyDayCountLab";
            this.journeyDayCountLab.Size = new System.Drawing.Size(15, 19);
            this.journeyDayCountLab.TabIndex = 3;
            this.journeyDayCountLab.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(173, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "天數：";
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(440, 77);
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
            this.gMapControl1.Size = new System.Drawing.Size(539, 547);
            this.gMapControl1.TabIndex = 6;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabpage2);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(992, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(306, 547);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.autoCompleteTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(298, 517);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "編輯行程";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "地點：";
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(100, 32);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(147, 25);
            this.autoCompleteTextBox1.TabIndex = 0;
            this.autoCompleteTextBox1.Values = null;
            // 
            // tabpage2
            // 
            this.tabpage2.Controls.Add(this.listBox1);
            this.tabpage2.Location = new System.Drawing.Point(4, 26);
            this.tabpage2.Name = "tabpage2";
            this.tabpage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage2.Size = new System.Drawing.Size(298, 517);
            this.tabpage2.TabIndex = 1;
            this.tabpage2.Text = "我的最愛";
            this.tabpage2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(7, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(285, 514);
            this.listBox1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Location = new System.Drawing.Point(14, 77);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(408, 547);
            this.tabControl2.TabIndex = 8;
            // 
            // PlaceNameTab
            // 
            this.PlaceNameTab.AutoSize = true;
            this.PlaceNameTab.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.PlaceNameTab.Location = new System.Drawing.Point(487, 25);
            this.PlaceNameTab.Name = "PlaceNameTab";
            this.PlaceNameTab.Size = new System.Drawing.Size(16, 19);
            this.PlaceNameTab.TabIndex = 9;
            this.PlaceNameTab.Text = "-";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(991, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "存檔";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveClick);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(880, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 37);
            this.button3.TabIndex = 11;
            this.button3.Text = "路線規劃";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Router_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(397, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "當前編輯：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(1096, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "單日匯出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(1201, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 37);
            this.button4.TabIndex = 14;
            this.button4.Text = "匯出整份";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SaveAll_Click);
            // 
            // JourneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 672);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PlaceNameTab);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.journeyDayCountLab);
            this.Controls.Add(this.journeyNameLab);
            this.Controls.Add(this.label1);
            this.Name = "JourneyForm";
            this.Text = "JourneyForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabpage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label journeyNameLab;
        private System.Windows.Forms.Label journeyDayCountLab;
        private System.Windows.Forms.Label label5;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private Components.AutoCompleteTextBox autoCompleteTextBox1;
        private System.Windows.Forms.Label PlaceNameTab;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}