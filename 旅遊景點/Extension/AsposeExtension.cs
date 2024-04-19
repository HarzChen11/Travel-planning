using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點.Extension
{
    static class AsposeExtension
    {
        public static DocumentBuilder builder = null;
        public static DocumentBuilder CreateBuilder(this Document document)
        {
            if(builder== null)
                 builder = new DocumentBuilder(document);
            return builder;
        }

        public static void DeleteBuilder(this Document document)
        {
            builder = null;
        }
        public static void Write(this Document document,string text,Aspose.Words.Font fontStyle = null, string Position = null)
        {
            if (builder == null)
            {
                builder = new DocumentBuilder(document);
            }              
            if (fontStyle == null)
            {
                setDefaultFont();
            }
            if (Position != null)
            {
                ParagraphFormat paragraphFormat = builder.ParagraphFormat;
                paragraphFormat.Alignment = ParagraphAlignment.Center;
            }
            builder.Writeln(text);
            
        }

        private static void setDefaultFont()
        {
            Font font = builder.Font;
            font.Bold = false;
            font.Color = System.Drawing.Color.Black;
            font.Name = "Arial";
            font.Size = 12;
            font.Spacing = 1;
        }


    }
}
