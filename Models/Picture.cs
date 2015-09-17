using System;
using MVVMSidekick.ViewModels;

namespace SLWeek.Models
{
        public  class Picture:BindableBase<Picture>
    {


        public string PictureUrl
        {
            get { return _PictureUrlLocator(this).Value; }
            set { _PictureUrlLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PictureUrl Setup        
        protected Property<string> _PictureUrl = new Property<string> { LocatorFunc = _PictureUrlLocator };
        static Func<BindableBase, ValueContainer<string>> _PictureUrlLocator = RegisterContainerLocator<string>("PictureUrl", model => model.Initialize("PictureUrl", ref model._PictureUrl, ref _PictureUrlLocator, _PictureUrlDefaultValueFactory));
        static Func<string> _PictureUrlDefaultValueFactory = () => default(string);
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


        public int Index
        {
            get { return _IndexLocator(this).Value; }
            set { _IndexLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int Index Setup        
        protected Property<int> _Index = new Property<int> { LocatorFunc = _IndexLocator };
        static Func<BindableBase, ValueContainer<int>> _IndexLocator = RegisterContainerLocator<int>("Index", model => model.Initialize("Index", ref model._Index, ref _IndexLocator, _IndexDefaultValueFactory));
        static Func<int> _IndexDefaultValueFactory = () => default(int);
        #endregion

    }
}
