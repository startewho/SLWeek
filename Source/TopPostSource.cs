﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLWeek.Models;
using SLWeek.ViewModels;
using SLWeek.Utils;
using Newtonsoft.Json.Linq;

namespace SLWeek.Source
{
    public class TopPostSource : IIncrementalSource<PostDetail>
    {
        private List<PostDetail> posts;

        public TopPostSource()
        {
            posts = new List<PostDetail>();

            for (int i = 0; i < 1024; i++)
            {
                var p = new PostDetail() { Title = "PostModel " + i ,Icon=new Uri("http://baidu.com/logo.jpg")};
                posts.Add(p);
            }
        }

        public async Task<IEnumerable<PostDetail>> GetPagedItems(string query,int pageIndex, int pageSize)
        {
            //if (pageIndex < 1)
            //    throw new ArgumentOutOfRangeException("pageIndex");
            //if (pageSize < 1)
            //    throw new ArgumentOutOfRangeException("pageSize");

            var jsontext = await HttpHelper.GetTextByPost(Strings.TopPostListUri, query,
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("height", query),
                    new KeyValuePair<string, string>("uid", "13916551"),
                    new KeyValuePair<string, string>("platform", "a"),
                    new KeyValuePair<string, string>("mobile", "Emnu"),

                });

            if (jsontext!=null)
            {
                JObject postlist = JObject.Parse(jsontext);
                var list = from item in postlist.SelectToken("list")
                           select
                      new PostDetail()
                      {
                          Title = (string)item["title"],
                          Des = (string)item["des"],
                          Creattime = (string)item["adddate"],
                          HtmlText ="",
                          Icon = new Uri(Strings.HostUri + (string)item["icon"]),
                          Id = Convert.ToInt32((string)item["id"]),
                          PostUrl = string.Format("http://lifeweeker3.cms.palmtrends.com/api_v2.php?action=article&id={0}&fontsize=m&mode=day&uid=13916551&platform=a&pid=10022&mobile=MEmu&picMode=show", Convert.ToInt32((string)item["id"]))
                      };
                return list;
            }


            return posts;
            
        }
    }


}