using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMSidekick.ViewModels;
using System.Runtime.Serialization;

namespace SLWeek.Models
{
    public class PostModel:BindableBase<PostModel>
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


        public string Icon
        {
            get { return _IconLocator(this).Value; }
            set { _IconLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Icon Setup        
        protected Property<string> _Icon = new Property<string> { LocatorFunc = _IconLocator };
        static Func<BindableBase, ValueContainer<string>> _IconLocator = RegisterContainerLocator<string>("Icon", model => model.Initialize("Icon", ref model._Icon, ref _IconLocator, _IconDefaultValueFactory));
        static Func<string> _IconDefaultValueFactory = () => default(string);
        #endregion



        public Uri PostUri
        {
            get { return _PostUriLocator(this).Value; }
            set { _PostUriLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property Uri PostUri Setup        
        protected Property<Uri> _PostUri = new Property<Uri> { LocatorFunc = _PostUriLocator };
        static Func<BindableBase, ValueContainer<Uri>> _PostUriLocator = RegisterContainerLocator<Uri>("PostUri", model => model.Initialize("PostUri", ref model._PostUri, ref _PostUriLocator, _PostUriDefaultValueFactory));
        static Func<Uri> _PostUriDefaultValueFactory = () => default(Uri);
        #endregion


    }
}
