using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLWeek.Source;
using SLWeek.Models;
using MVVMSidekick.ViewModels;
using SLWeek.Utils;

namespace SLWeek.Models
{
    public class Author:BindableBase<Author>
    {

        public string AddTime
        {
            get { return _AddTimeLocator(this).Value; }
            set { _AddTimeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string AddTime Setup        
        protected Property<string> _AddTime = new Property<string> { LocatorFunc = _AddTimeLocator };
        static Func<BindableBase, ValueContainer<string>> _AddTimeLocator = RegisterContainerLocator<string>("AddTime", model => model.Initialize("AddTime", ref model._AddTime, ref _AddTimeLocator, _AddTimeDefaultValueFactory));
        static Func<string> _AddTimeDefaultValueFactory = () => default(string);
        #endregion

        public string Name
        {
            get { return _NameLocator(this).Value; }
            set { _NameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Name Setup        
        protected Property<string> _Name = new Property<string> { LocatorFunc = _NameLocator };
        static Func<BindableBase, ValueContainer<string>> _NameLocator = RegisterContainerLocator<string>("Name", model => model.Initialize("Name", ref model._Name, ref _NameLocator, _NameDefaultValueFactory));
        static Func<string> _NameDefaultValueFactory = () => default(string);
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

        public string Intro
        {
            get { return _IntroLocator(this).Value; }
            set { _IntroLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Intro Setup        
        protected Property<string> _Intro = new Property<string> { LocatorFunc = _IntroLocator };
        static Func<BindableBase, ValueContainer<string>> _IntroLocator = RegisterContainerLocator<string>("Intro", model => model.Initialize("Intro", ref model._Intro, ref _IntroLocator, _IntroDefaultValueFactory));
        static Func<string> _IntroDefaultValueFactory = () => default(string);
        #endregion

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

    }
}
