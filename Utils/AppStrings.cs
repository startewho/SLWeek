using System.Collections.Generic;

namespace SLWeek.Utils
{
     public static  class AppStrings
    {

        public static readonly string BookmarkDbName = "BookmarkDb.db";
        public static readonly string TagDbName = "TagDb.db";
        public static readonly string UidName = "13916551";
        public static readonly string MobileName = "Emnu";
        public static readonly string HostUri = "http://lifeweeker3.cms.palmtrends.com";
        public static readonly string PostListUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=list";
        public static readonly string TopPostListUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=top";
        public static readonly string AuthorListUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=zl";
        public static readonly string AuthorPostListUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=list";
        public static readonly string PostUri = "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=article&id={0}&fontsize=m&mode=day&uid=13916551&platform=a&pid=10022&mobile=MEmu&picMode={1}";
        public static readonly string UerAgent = "Mozilla/5.0 (Linux; U; Android 4.2.2; en-cn; MEmu Build/JDQ39E) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30";
        public static readonly List<string> PostType = new List<string> { "shehui", "wenhua", "guoji", "shishang" };
        public static int PageSize=20;
        public  static Dictionary<string, string> PostTypeDic = new Dictionary<string, string>
                    {
                        {"shehui", "社会"},
                        {"wenhua", "文化"},
                        {"guoji", "国际"},
                        {"shishang", "时尚"},
                        {"renwu", "人物"},
                        {"jieqi", "节气"},
                        {"lishi", "历史"},
                        {"jingji", "经济"},
                        {"keji", "科技"},
                        {"shoucang", "收藏"},
                        {"zhuanfang", "专访"},
                        {"dushu", "读书"},
                        {"lvyou", "旅游"},
                        {"yuanzhuo", "圆桌"} 
                    };

                    }
}
