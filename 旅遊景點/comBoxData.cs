using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點
{
    internal class comBoxData
    {
        public string key
        {
            get; 
            set;
        }
        public string value 
        { 
            get;
            set; 
        }

        public comBoxData(string key,string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
