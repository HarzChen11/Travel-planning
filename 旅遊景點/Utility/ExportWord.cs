using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using MapFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 旅遊景點.Extension;
using Font = Aspose.Words.Font;

namespace 旅遊景點.Utility
{
    internal class ExportWord
    {
        public string licenseFile = ConfigurationManager.AppSettings["license"];
        public ExportWord()
        {
            //new Aspose.Words.License().SetLicense(new MemoryStream(Convert.FromBase64String("PExpY2Vuc2U+CiAgPERhdGE+CiAgICA8TGljZW5zZWRUbz5TdXpob3UgQXVuYm94IFNvZnR3YXJlIENvLiwgTHRkLjwvTGljZW5zZWRUbz4KICAgIDxFbWFpbFRvPnNhbGVzQGF1bnRlYy5jb208L0VtYWlsVG8+CiAgICA8TGljZW5zZVR5cGU+RGV2ZWxvcGVyIE9FTTwvTGljZW5zZVR5cGU+CiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1pdGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+CiAgICA8T3JkZXJJRD4yMDA2MDIwMTI2MzM8L09yZGVySUQ+CiAgICA8VXNlcklEPjEzNDk3NjAwNjwvVXNlcklEPgogICAgPE9FTT5UaGlzIGlzIGEgcmVkaXN0cmlidXRhYmxlIGxpY2Vuc2U8L09FTT4KICAgIDxQcm9kdWN0cz4KICAgICAgPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0PgogICAgPC9Qcm9kdWN0cz4KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl0aW9uVHlwZT4KICAgIDxTZXJpYWxOdW1iZXI+OTM2ZTVmZDEtODY2Mi00YWJmLTk1YmQtYzhkYzBmNTNhZmE2PC9TZXJpYWxOdW1iZXI+CiAgICA8U3Vic2NyaXB0aW9uRXhwaXJ5PjIwMjEwODI3PC9TdWJzY3JpcHRpb25FeHBpcnk+CiAgICA8TGljZW5zZVZlcnNpb24+My4wPC9MaWNlbnNlVmVyc2lvbj4KICAgIDxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHBzOi8vcHVyY2hhc2UuYXNwb3NlLmNvbS9wb2xpY2llcy91c2UtbGljZW5zZTwvTGljZW5zZUluc3RydWN0aW9ucz4KICA8L0RhdGE+CiAgPFNpZ25hdHVyZT5wSkpjQndRdnYxV1NxZ1kyOHFJYUFKSysvTFFVWWRrQ2x5THE2RUNLU0xDQ3dMNkEwMkJFTnh5L3JzQ1V3UExXbjV2bTl0TDRQRXE1aFAzY2s0WnhEejFiK1JIWTBuQkh1SEhBY01TL1BSeEJES0NGbWg1QVFZRTlrT0FxSzM5NVBSWmJRSGowOUNGTElVUzBMdnRmVkp5cUhjblJvU3dPQnVqT1oyeDc4WFE9PC9TaWduYXR1cmU+CjwvTGljZW5zZT4=")));

            if (File.Exists(licenseFile))
            {
                Aspose.Words.License license = new Aspose.Words.License();
                license.SetLicense(licenseFile);
            }
            else
            {
                throw new Exception("Aspose授權設定失敗停止動作");
            }
        }

        string nowdt = DateTime.Now.ToString("yyyyMMdd");
        public void getWord(string fileName, string[] keys, object[] values)
        {
            Aspose.Words.Document doc = new Aspose.Words.Document(ConfigurationManager.AppSettings["template"] + fileName + ".docx");
            doc.MailMerge.Execute(
             keys, values
             );

            doc.Save(ConfigurationManager.AppSettings["newDocument"] + fileName + nowdt + ".docx");
        }

        public void getWord<T>(string fileName, List<T> list, string TbName)
        {
            //Document document = new Document(ConfigurationManager.AppSettings["template"] + fileName + ".docx");

            //var table = ToDataTable<T>(list);

            //table.TableName = TbName;
            //document.MailMerge.ExecuteWithRegions(table);

            //document.Save(ConfigurationManager.AppSettings["newDocument"] + fileName + nowdt + ".docx");
        }


        public void ToDataTable<T>(string fileName, List<T> list)
        {

            Document document = CreateTitle(fileName, list[0]);

            string path = ConfigurationManager.AppSettings["filePath"] + $"travel\\{fileName}\\";

            CreateTable(document, list, path + $@"\{fileName}.jpg");

            Save(document, path + fileName + "－" + nowdt);
        }

        public Document CreateTitle<T>(string fileName, T infos)
        {
            Document document = new Document();

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Font font = document.CreateBuilder().Font;
            font.Bold = true;
            font.Color = System.Drawing.Color.Blue;
            font.Name = "Arial";
            font.Size = 24;
            font.Spacing = 3;

            string Position = "";
            document.Write("行程名稱：" + fileName, font, Position);


            for (int i = 8; i < 11; i++)
            {
                var att1 = props[i].GetCustomAttribute(typeof(DisplayNameAttribute), true);
                document.Write($"{(att1 as DisplayNameAttribute).DisplayName}：{props[i].GetValue(infos)}", font);
            }
            DocumentBuilder builder = document.CreateBuilder();



            return document;
        }

        public void CreateTable<T>(Document document, List<T> list, string imagePath)
        {
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            DocumentBuilder tableBuilder = document.CreateBuilder();

            //分頁
            tableBuilder.InsertBreak(BreakType.PageBreak);

            // 顯示第幾天行程
            var infos = list[0];
            Font font = document.CreateBuilder().Font;
            font.Bold = true;
            font.Color = System.Drawing.Color.Red;
            font.Name = "Arial";
            font.Size = 20;
            font.Spacing = 3;
            for (int i = 0; i < 1; i++)
            {
                var att1 = props[0].GetCustomAttribute(typeof(DisplayNameAttribute), true);
                document.Write($"第{props[i].GetValue(infos)}天", font);
            }

            Font font1 = tableBuilder.Font;
            font1.Bold = true;
            font1.Color = System.Drawing.Color.Black;
            font1.Name = "Arial";
            font1.Size = 12;
            font1.Spacing = 2;

            Table table = tableBuilder.StartTable();
            foreach (T item in list)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    var checkIgnore = props[i].CustomAttributes.Where(x => x.AttributeType.Name.Contains("Ignore")).FirstOrDefault();
                    if (checkIgnore == null)
                    {
                        var type = props[i].GetCustomAttribute(typeof(DisplayNameAttribute), true);
                        string att = (type as DisplayNameAttribute).DisplayName.ToString();
                        CreatCell(tableBuilder, 63, att, item);

                        string value = props[i].GetValue(item).ToString();
                        CreatCell(tableBuilder, 185, value, item);
                        tableBuilder.EndRow();
                    }
                }
            }
            table.AutoFit(AutoFitBehavior.FixedColumnWidths);
            tableBuilder.EndTable();

            tableBuilder.InsertImage(imagePath,
                RelativeHorizontalPosition.Margin,
                250,
                RelativeVerticalPosition.Margin,
                80,
                270,
                360,
                WrapType.Square);

            //tableBuilder.InsertBreak(BreakType.PageBreak);
        }

        public void Save(Document document, string path)
        {
            Console.WriteLine(path + ".docx");
            document.Save(path + ".docx");
            document.Save(path + ".pdf");
        }

        private static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        private static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }


        private void CreatCell(DocumentBuilder builder, int Width, string text, object item)
        {
            builder.InsertCell();
            builder.CellFormat.Width = Width;
            builder.RowFormat.Height = 40;

            builder.Write(text);
        }
    }
}