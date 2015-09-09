using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLWeek.Utils
{
     public static  class Strings
    {
        public static readonly string HostUri = "http://lifeweeker3.cms.palmtrends.com";
        public static readonly string PostListUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=list";
        public static readonly string AuthorListUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=zl&";
        public static readonly string UerAgent = "Mozilla/5.0 (Linux; U; Android 4.2.2; en-cn; MEmu Build/JDQ39E) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30";
        public static readonly List<string> PostType = new List<string>() { "shehui", "wenhua", "guoji", "shishang" };
        public static double Offset;

         public static string HrefAddHost(string originaltext)
         {
            
            originaltext= originaltext.Replace("src=\"/upload", "src=\"" + HostUri+"/upload");
            originaltext = originaltext.Replace("href=\"/upload", "href=\"" + HostUri+ "/upload");
            return originaltext;
         }
    }
}
