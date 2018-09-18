using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFReportLib.Mock
{
    public static class RandomGenerator
    {
        private static Random rnd;
        public static int GetRandom(int min, int max)
        {
            if (rnd == null)
            {
                rnd = new Random();
            }

            return rnd.Next(min, max);
        }

        public static DateTime GetRandomDate(DateTime start, DateTime end)
        {
            if (rnd == null)
                rnd = new Random();

            DateTime dt = start.Add(new TimeSpan(rnd.Next(1, 31), rnd.Next(1, 24), rnd.Next(1, 60), 0, 0));

            return dt;
        }
    }
}
