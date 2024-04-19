using MapFunction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊景點.Utility
{
    internal class CSVHelper
    {

        public List<T> ReadCSVModel<T>(DateTime StartTime, DateTime EndTime) where T : new()
        {
            string dirPath = ($@"C:\Users\user\Desktop\C#\ConsoleApp1\WindowsFormsApp1.記帳\記帳本檔案\");

            List<DateTime> dayList = new List<DateTime>();
            TimeSpan timeSpan = EndTime.Subtract(StartTime);
            for (int i = 0; i <= timeSpan.Days; i++)
            {
                DateTime dateTime = StartTime.AddDays(i);
                dayList.Add(dateTime);
            }

            List<T> list = new List<T>();

            foreach (var dayTime in dayList)
            {
                list.AddRange(STReader<T>(Path.Combine(dirPath, dayTime.ToString("yyyy-MM-dd"), "景點.csv")));
            }

            return list;
        }

        string destination = ConfigurationManager.AppSettings["filePath"];

        public List<T> ReadCSVModel<T>(String path) where T : new()
        {
            string finalPath = destination + path;
            Console.WriteLine(finalPath);

            List<T> list = new List<T>();
            //if (!destination.Contains(".csv"))
            //{
            //    destination = Path.Combine(destination, "我的最愛.csv");
            //}
            if (!File.Exists(finalPath))
            {
                throw new Exception("檔案不存在");
            }

            list = STReader<T>(finalPath);
            #region
            //StreamReader streamReader = new StreamReader(path);

            //while (!streamReader.EndOfStream)
            //{
            //    String[] datas = streamReader.ReadLine().Split(',');
            //    T t = new T();
            //    var porp = t.GetType().GetProperties();
            //    for (int i = 0; i < datas.Length; i++)
            //    {
            //        porp[i].SetValue(t, datas[i]);
            //    }
            //    list.Add(t);
            //}
            //streamReader.Close();
            #endregion
            return list;
        }

        private List<T> STReader<T>(string finalPath) where T : new()
        {
            List<T> list = new List<T>();
            if (!File.Exists(finalPath))
            {
                return list;
            }
            StreamReader streamReader = new StreamReader(finalPath);

            while (!streamReader.EndOfStream)
            {
                String[] datas = streamReader.ReadLine().Split(',');
                T t = new T();
                var porp = t.GetType().GetProperties();
                for (int i = 0; i < datas.Length; i++)
                {
                    porp[i].SetValue(t, Convert.ChangeType(datas[i], porp[i].PropertyType));
                }
                list.Add(t);
            }
            streamReader.Close();
            return list;
        }

        public void WriteCSV(string path, object data)
        {
            string finalPath = destination + path; // favorite: favorite.csv / travel: travel/<travelName>/20221118.csv

            var line = finalPath.Split('\\').ToList();
            string last = line.Last();
            line.Remove(last);
            string temp = "";
            foreach (string word in line)
            {
                temp += word + '\\';
            }


            if (File.Exists(temp))
            {
                throw new Exception("該路徑非csv檔案格式");
            }

            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            Console.WriteLine(temp + last);

            if (check(data))
            {
                StreamWriter streamWriter = new StreamWriter(temp + last, true);

                var props = data.GetType().GetProperties();
                String text = "";
                foreach (var prop in props)
                {
                    text += $"{prop.GetValue(data)},";
                }
                text = text.TrimEnd(',');

                streamWriter.WriteLine(text);
                streamWriter.Flush();
                streamWriter.Close();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void WriteCSV(String path, List<LocationData> Schedule)
        {
            string finalPath = ConfigurationManager.AppSettings["filePath"] + path; // favorite: favorite.csv / travel: travel/<travelName>/20221118.csv

            var line = finalPath.Split('\\').ToList();
            string last = line.Last();
            line.Remove(last);
            string temp = "";
            foreach (string word in line)
            {
                temp += word + '\\';
            }

            if (File.Exists(temp))
            {
                throw new Exception("該路徑非csv檔案格式");
            }

            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }

            StreamWriter streamWriter = new StreamWriter(temp + last, true);

            foreach (var item in Schedule)
            {
                var props = item.GetType().GetProperties();
                String text = "";
                foreach (var prop in props)
                {
                    text += $"{prop.GetValue(item)},";
                }
                text = text.TrimEnd(',');
                streamWriter.WriteLine(text);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }

        public bool check(object data)
        {
            LocationData locationData = (LocationData)data;
            var list = ReadCSVModel<LocationData>("我的最愛.csv");
            int number=list.Where(x => x.PlaceID == locationData.PlaceID).Count();
            if(number == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
