using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLWeek.Utils
{
   public static class StringExtesion
    {
       public static DateTime ToDateTime(this string str)
       {
            var dtStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var lTime = long.Parse(str + "0000000");
            var toNow = new TimeSpan(lTime);
            var dtResult = dtStart.Add(toNow);
           return dtResult;
       }
    }
}
