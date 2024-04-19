namespace 旅遊景點
{
    partial class MenuControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MapSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.行程總覽 = new System.Windows.Forms.ToolStripMenuItem();
            this.我的最愛 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapSearch,
            this.LocationSearch,
            this.行程總覽,
            this.我的最愛});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(437, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MapSearch
            // 
            this.MapSearch.Name = "MapSearch";
            this.MapSearch.Size = new System.Drawing.Size(107, 24);
            this.MapSearch.Text = "MapSearch";
            this.MapSearch.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // LocationSearch
            // 
            this.LocationSearch.Name = "LocationSearch";
            this.LocationSearch.Size = new System.Drawing.Size(117, 24);
            this.LocationSearch.Text = "地點條件搜尋";
            this.LocationSearch.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 行程總覽
            // 
            this.行程總覽.Name = "行程總覽";
            this.行程總覽.Size = new System.Drawing.Size(85, 24);
            this.行程總覽.Text = "行程總覽";
            this.行程總覽.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 我的最愛
            // 
            this.我的最愛.Name = "我的最愛";
            this.我的最愛.Size = new System.Drawing.Size(85, 24);
            this.我的最愛.Text = "我的最愛";
            this.我的最愛.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(437, 34);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MapSearch;
        private System.Windows.Forms.ToolStripMenuItem LocationSearch;
        private System.Windows.Forms.ToolStripMenuItem 行程總覽;
        private System.Windows.Forms.ToolStripMenuItem 我的最愛;
    }
}
