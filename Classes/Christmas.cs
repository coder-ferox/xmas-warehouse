using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Christmas
    {
        static double perc = 0.274;
        static DateTime christmas = new DateTime(DateTime.Now.Year, 12, 25);
        static DateTime dy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        static int daysLeft = 25 - (int)DateTime.Now.Day;

        public static double getPercGreen()
        {
            return (double)dy.DayOfYear * perc;
        }

        public static double getPercGreenRounded()
        {
            return Math.Round(getPercGreen(), 0);
        }
        
        public static double getPercRed()
        {
            return 100.0 - getPercGreenRounded();
        }
        
        public static int getDaysLeft()
        {
            return daysLeft;
        }


    }
}
