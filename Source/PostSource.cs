using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLWeek.Models;
using SLWeek.Utils;
using Newtonsoft.Json.Linq;

namespace SLWeek.Source
{
    public class PostSource : IIncrementalSource<PostDetail>
    {


     
        public async Task<IEnumerable<PostDetail>> GetPagedItems(string query,int pageIndex, int pageSize)
        {
            //if (pageIndex < 1)
            //    throw new ArgumentOutOfRangeException("pageIndex");
            //if (pageSize < 1)
            //    throw new ArgumentOutOfRangeException("pageSize");

            var jsontext = await HttpHelper.GetTextByPost(Strings.PostListUri, query,
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("sa", query),
                    new KeyValuePair<string, string>("offset", (pageIndex*pageSize).ToString()),
                    new KeyValuePair<string, string>("count", pageSize.ToString()),
                    new KeyValuePair<string, string>("uid", "13916551"),
                    new KeyValuePair<string, string>("platform", "a"),
                    new KeyValuePair<string, string>("mobile", "Emnu"),

                });

            if (jsontext!=null)
            {
                JObject postlist = JObject.Parse(jsontext);
                var list = postlist.SelectToken("list").Select(item => new PostDetail()
                {
                    Title = (string) item["title"],
                    Des = (string) item["des"],
                    Creattime = (string) item["adddate"],
                    Icon = new Uri(Strings.HostUri + (string) item["icon"]),
                    Id = Convert.ToInt32((string) item["id"]),
                    PostUrl =
                        string.Format(
                            "http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=article&id={0}&fontsize=m&mode=day&uid=13916551&platform=a&pid=10022&mobile=MEmu&picMode=show",
                            Convert.ToInt32((string) item["id"])),
                });
                return list;
            }


            return null;
            
        }
    }


}
