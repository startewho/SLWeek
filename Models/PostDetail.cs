﻿using System;
using MVVMSidekick.ViewModels;
using SLWeek.Utils;
namespace SLWeek.Models
{
    public   class PostDetail:BindableBase<PostDetail>
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

        public int Id { get; set; }

        public string Creattime { get; set; }

        public string Des { get; set; }


        public string Title
        {
            get { return _TitleLocator(this).Value; }
            set { _TitleLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Title Setup        
        protected Property<string> _Title = new Property<string> { LocatorFunc = _TitleLocator };
        static Func<BindableBase, ValueContainer<string>> _TitleLocator = RegisterContainerLocator<string>("Title", model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));
        static Func<string> _TitleDefaultValueFactory = () => default(string);
        #endregion



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
