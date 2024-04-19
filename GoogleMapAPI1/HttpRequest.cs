using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI
{
    public class HttpRequest
        {
            public static T GetRequest<T>(String url)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";

                string result = " ";
                // 取得回應資料

                // 接收響應關聯的流的內部資料
                using (WebResponse response = request.GetResponse())
                {
                    // 將流傳輸到具有所需編碼格式的更高級別的流讀取器
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = sr.ReadToEnd();
                        T model = JsonConvert.DeserializeObject<T>(result);
                        return model;
                    }
                }

            }

            public static T GetRequest<T>(Uri url)
            {
                String requetURL = url.ToString();
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requetURL);
                request.Method = "GET";

                string result = " ";
                // 取得回應資料

                // 接收響應關聯的流的內部資料
                using (WebResponse response = request.GetResponse())
                {
                    // 將流傳輸到具有所需編碼格式的更高級別的流讀取器
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = sr.ReadToEnd();
                        T model = JsonConvert.DeserializeObject<T>(result);
                        return model;
                    }
                }

            }
        }
    }
