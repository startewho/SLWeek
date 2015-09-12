using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMSidekick.ViewModels;
using SLWeek.Utils;
namespace SLWeek.Models
{
    public   class PostDetail:BindableBase<PostDetail>
    {
        public PostDetail()
        {
           
        }
        public PostDetail(int id)
        {
            Id = id;
            PostUrl = string.Format(Strings.PostUri, id);
        }

        public int Id { get; set; }

        public string Creattime { get; set; }

        public string Des { get; set; }

        public string Title { get; set; }

        
        public Uri Icon
        {
            get { return _IconLocator(this).Value; }
            set { _IconLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property Uri Icon Setup        
        protected Property<Uri> _Icon = new Property<Uri> { LocatorFunc = _IconLocator };
        static Func<BindableBase, ValueContainer<Uri>> _IconLocator = RegisterContainerLocator<Uri>("Icon", model => model.Initialize("Icon", ref model._Icon, ref _IconLocator, _IconDefaultValueFactory));
        static Func<Uri> _IconDefaultValueFactory = () => default(Uri);
        #endregion

     

        public string PostUrl
        {
            get { return _PostUrlLocator(this).Value; }
            set { _PostUrlLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PostUrl Setup        
        protected Property<string> _PostUrl = new Property<string> { LocatorFunc = _PostUrlLocator };
        static Func<BindableBase, ValueContainer<string>> _PostUrlLocator = RegisterContainerLocator<string>("PostUrl", model => model.Initialize("PostUrl", ref model._PostUrl, ref _PostUrlLocator, _PostUrlDefaultValueFactory));
        static Func<string> _PostUrlDefaultValueFactory = () => default(string);
        #endregion


    }
}
