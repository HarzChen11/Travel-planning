using GMap.NET.WindowsForms;
using GoogleMapAPI.Place.BasePlace;
using GoogleMapAPI.Place.PlaceDetail;
using GoogleMapAPI.Place.TextSearch;
using GoogleMapAPI.Request.GeoCoding;
using MapFunction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace 旅遊景點.Components
{
    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private List<String> _values;
        private String _formerValue = String.Empty;

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout(); 
            this._listBox.ItemHeight = 12;
            this._listBox.Location = new System.Drawing.Point(0, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(100, 88);
            this._listBox.TabIndex = 0;
            this._listBox.BringToFront();
            this._listBox.DoubleClick += new System.EventHandler(this._listBox_DoubleClick);
            this.ResumeLayout(false);

        }

        private void _listBox_DoubleClick(object sender, EventArgs e)
        { 
            if (_listBox.SelectedItem != null)
            {
                this.Text = _listBox.SelectedItem.ToString();
                _listBox.Visible = false;

                TextSearchRequest searchRequest = new TextSearchRequest();
                searchRequest.query = this.Text;
                searchRequest.language = "zh-TW";
                var TextSearchResponse = new PlaceService().GetResponse<TextSearchResponse>(searchRequest);
                LocationData data = new LocationData(
                    TextSearchResponse.results[0].name,
                    TextSearchResponse.results[0].formatted_address,
                    TextSearchResponse.results[0].place_id,
                    TextSearchResponse.results[0].geometry.location.lat,
                    TextSearchResponse.results[0].geometry.location.lng
                    );

                //GeocodingRequest GeocodeRequest = new GeocodingRequest();
                //GeocodeRequest.address = this.Text;
                //var GeocodeResponse = new GeocodingService().GetResponse(GeocodeRequest);
                //LocationData data = new LocationData(
                //    GeocodeResponse.results[0].address_components[0].long_name,
                //    GeocodeResponse.results[0].place_id,
                //    GeocodeResponse.results[0].geometry.location.lat,
                //    GeocodeResponse.results[0].geometry.location.lng
                //    );

                ShowMap(this, data);

            }
        }

        public event EventHandler<LocationData> ShowMap;

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Parent.Controls.Add(_listBox);
                _listBox.Left = Left;
                _listBox.Top = Top + Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            // 如果 e 判斷不等於鍵盤的 "上下鍵" ，就更新 ListBox。
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                UpdateListBox();
            }
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            InsertWord((String)_listBox.SelectedItem);
                            ResetListBox();
                            _formerValue = Text;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;

                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;

                        break;
                    }
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        public void UpdateListBox()
        {
            // 原先寫法如果 151 行不註解，鍵盤點選任何 "非英數" 的按鍵，就不會更新 ListBox 的選項的顯示，此時可以往下點選建議選項
            // (是透過 text.Text 是 String 屬性，賦予給 _formerValue 後，判斷兩者會是相同屬性，則不更新)

            // 後來因為我們的需求是要動態更新 ListBox 的選項 ，若保留 151 行，則無法執行後面即時更新 ListBox 的提示選項的程式
            //if (Text == _formerValue) return; 
            _formerValue = Text;
            String word = GetWord();

            if (_values != null && word.Length > 0)
            {
                List<String> matches = _values.Where(x => x.Contains(word)).ToList();
                if (matches.Count > 0)
                {
                    ShowListBox();
                    _listBox.Items.Clear();
                    matches.ForEach(x => _listBox.Items.Add(x));
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            _listBox.Height += _listBox.GetItemHeight(i);
                            _listBox.Width = Width;
                        }
                    }
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        private String GetWord()
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);
            posEnd = (posEnd == -1) ? text.Length : posEnd;

            int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

            return text.Substring(posStart, length);
        }

        private void InsertWord(String newTag)
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);

            String firstPart = text.Substring(0, posStart) + newTag;
            String updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


            Text = updatedText;
            SelectionStart = firstPart.Length;
        }

        public List<String> Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                this.UpdateListBox();
            }
        }

        public List<String> SelectedValues
        {
            get
            {
                String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<String>(result);
            }
        }
    }

}