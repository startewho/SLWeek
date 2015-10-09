using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SLWeek.Models;
using SLWeek.Utils;

namespace SLWeek.Source
{
    public class TopPostSource : IIncrementalSource<PostDetail>
    {
       
        public async Task<IEnumerable<PostDetail>> GetPagedItems(string query,int pageIndex, int pageSize)
        {

            //if (pageIndex < 1)
            //    throw new ArgumentOutOfRangeException("pageIndex");
            //if (pageSize < 1)
            //    throw new ArgumentOutOfRangeException("pageSize");

            var querylist = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("height", query),
                new KeyValuePair<string, string>("uid", "13916551"),
                new KeyValuePair<string, string>("platform", "a"),
                new KeyValuePair<string, string>("mobile", "Emnu")

            };
            var jsontext = await HttpHelper.GetTextByPost(AppStrings.TopPostListUri, query,querylist);

            if (jsontext!=null)
            {
                JObject postlist = JObject.Parse(jsontext);
                var list = postlist.SelectToken("list").Select(item => new PostDetail
                {
                    Title = (string) item["title"],
                    Des = (string) item["des"],
                    Creattime = ((string)item["creation_time"]).ToDateTime(),
                    Icon = AppStrings.HostUri + (string) item["icon"],
                    Id = Convert.ToInt32((string) item["id"]),
                    PostUrl = string.Format(AppStrings.PostUri, Convert.ToInt32((string)item["id"]), AppSettings.Instance.IsEnableImageMode ? "show" : "hide")
                    });
                return list;
            }


            return null;
            
        }
    }


}
