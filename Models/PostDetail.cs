using System;
using MVVMSidekick.ViewModels;
using SLWeek.Utils;
using SQLite.Net.Attributes;
using System.Runtime.Serialization;

namespace SLWeek.Models
{
    [DataContract]
    public   class PostDetail
    {
        public PostDetail()
        {
           
        }
        public PostDetail(int id,string title)
        {
            Id = id;
            PostUrl = string.Format(AppStrings.PostUri, id,AppSettings.Instance.IsEnableImageMode?"show":"hide");
            Title = title;
        }
        [PrimaryKey]
        public int Id { get; set; }

        public string Creattime { get; set; }

        public string Des { get; set; }


        public string Title { get; set; }
       
                       

        public string Icon { get; set; }


        public string PostUrl{get; set;}
        

    }

    
}
