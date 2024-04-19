namespace 旅遊景點.Components
{
    partial class JourneyMenu
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
        public void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.JourneryNameTab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 127);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // JourneryNameTab
            // 
            this.JourneryNameTab.AutoSize = true;
            this.JourneryNameTab.Location = new System.Drawing.Point(66, 149);
            this.JourneryNameTab.Name = "JourneryNameTab";
            this.JourneryNameTab.Size = new System.Drawing.Size(9, 12);
            this.JourneryNameTab.TabIndex = 1;
            this.JourneryNameTab.Text = "-";
            // 
            // JourneyManu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.JourneryNameTab);
            this.Controls.Add(this.pictureBox1);
            this.Name = "JourneyManu";
            this.Size = new System.Drawing.Size(147, 171);
            this.Click += new System.EventHandler(this.Show_JourneyForm);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label JourneryNameTab;
    }
}
