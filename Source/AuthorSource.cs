using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLWeek.Models;
using SLWeek.Utils;
using Newtonsoft.Json.Linq;

namespace SLWeek.Source
{
    public class AuthorSource : IIncrementalSource<Author>
    {


        public async Task<IEnumerable<Author>> GetPagedItems(string query,int pageIndex, int pageSize)
        {
            //if (pageIndex < 1)
            //    throw new ArgumentOutOfRangeException("pageIndex");
            //if (pageSize < 1)
            //    throw new ArgumentOutOfRangeException("pageSize");

            var jsontext = await HttpHelper.GetTextByPost(AppStrings.AuthorListUri, query,
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("offset", (pageIndex*pageSize).ToString()),
                    new KeyValuePair<string, string>("count", pageSize.ToString()),
                    new KeyValuePair<string, string>("uid", "13916551"),
                    new KeyValuePair<string, string>("platform", "a"),
                    new KeyValuePair<string, string>("mobile", "Emnu"),

                });

            if (jsontext!=null)
            {
                JObject postlist = JObject.Parse(jsontext);
                var list = from item in postlist.SelectToken("list")
                           select
                      new Author()
                      {
                          Name = (string)item["author"],
                          Intro = (string)item["intro"],
                          Title = (string)item["title"],
                          Des = (string)item["des"],
                          Icon = AppStrings.HostUri + (string)item["icon"],
                          Id = Convert.ToInt32((string)item["id"]),                      
                      };
                return list;
            }


            return null;
            
        }
    }


}
