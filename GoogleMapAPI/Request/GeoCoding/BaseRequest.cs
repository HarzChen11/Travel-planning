using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Request.GeoCoding
{
    public abstract class BaseRequest
    {
        protected String apikey = ConfigurationManager.AppSettings["GoogleMapAPIKey"];
        public abstract string URL { get; }

        //public BaseRequest()
        //{
        //    this.apikey = ConfigurationManager.AppSettings["GoogleMapAPIKey"];
        //}


        public virtual Uri ToUri(bool isPhoto = false)
        {
            //BindingFlags.Public
            var data = this.GetType().GetProperties();
            StringBuilder builder = new StringBuilder();
            foreach (var prop in data)
            {
                if (prop.Name != "URL" && prop.GetValue(this) != null)
                {
                    string classItem = prop.Name;
                    string classData = prop.GetValue(this).ToString();
                    builder.Append(classItem + "=" + classData + "&");
                }
            }

            String str = isPhoto ? "" : "json?";
            str += builder.ToString() + $"key={this.apikey}";
            return new Uri(str, UriKind.Relative);
        }


    }
}
