using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點.Models
{
    public class JourneyModel
    {
        public string journeyName { get; set; }
        public int journeyDayCount { get; set; }
        public string image { get; set; }

        public string date { get; set; }
        public string end { get; set; }
        public string day { get; set; }

        public JourneyModel(string JourneyName, int JourneyDayCount, string Image, string Date, string End, string Day)
        {
            this.journeyName = JourneyName;
            this.journeyDayCount = JourneyDayCount;
            this.image = Image;
            this.date = Date;
            this.end = End;
            this.day = Day;
        }
    }
}
