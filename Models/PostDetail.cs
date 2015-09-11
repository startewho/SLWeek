using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMSidekick.ViewModels;
namespace SLWeek.Models
{
    public   class PostDetail:BindableBase<PostDetail>
    {
        public int Id
        {
            get { return _IdLocator(this).Value; }
            set { _IdLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int Id Setup        
        protected Property<int> _Id = new Property<int> { LocatorFunc = _IdLocator };
        static Func<BindableBase, ValueContainer<int>> _IdLocator = RegisterContainerLocator<int>("Id", model => model.Initialize("Id", ref model._Id, ref _IdLocator, _IdDefaultValueFactory));
        static Func<int> _IdDefaultValueFactory = () => default(int);
        #endregion

        public string Creattime
        {
            get { return _CreattimeLocator(this).Value; }
            set { _CreattimeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Creattime Setup        
        protected Property<string> _Creattime = new Property<string> { LocatorFunc = _CreattimeLocator };
        static Func<BindableBase, ValueContainer<string>> _CreattimeLocator = RegisterContainerLocator<string>("Creattime", model => model.Initialize("Creattime", ref model._Creattime, ref _CreattimeLocator, _CreattimeDefaultValueFactory));
        static Func<string> _CreattimeDefaultValueFactory = () => default(string);
        #endregion


        public string Des
        {
            get { return _DesLocator(this).Value; }
            set { _DesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Des Setup        
        protected Property<string> _Des = new Property<string> { LocatorFunc = _DesLocator };
        static Func<BindableBase, ValueContainer<string>> _DesLocator = RegisterContainerLocator<string>("Des", model => model.Initialize("Des", ref model._Des, ref _DesLocator, _DesDefaultValueFactory));
        static Func<string> _DesDefaultValueFactory = () => default(string);
        #endregion


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

        public string HtmlText
        {
            get { return _HtmlTextLocator(this).Value; }
            set { _HtmlTextLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string HtmlText Setup        
        protected Property<string> _HtmlText = new Property<string> { LocatorFunc = _HtmlTextLocator };
        static Func<BindableBase, ValueContainer<string>> _HtmlTextLocator = RegisterContainerLocator<string>("HtmlText", model => model.Initialize("HtmlText", ref model._HtmlText, ref _HtmlTextLocator, _HtmlTextDefaultValueFactory));
        static Func<string> _HtmlTextDefaultValueFactory = () => default(string);
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
