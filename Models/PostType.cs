using System;
using MVVMSidekick.ViewModels;

namespace SLWeek.Models
{
  
    public class PostType:BindableBase<PostType>
    {


        public string Name
        {
            get { return _NameLocator(this).Value; }
            set { _NameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Name Setup        
        protected Property<string> _Name = new Property<string> { LocatorFunc = _NameLocator };
        static Func<BindableBase, ValueContainer<string>> _NameLocator = RegisterContainerLocator("Name", model => model.Initialize("Name", ref model._Name, ref _NameLocator, _NameDefaultValueFactory));
        static Func<string> _NameDefaultValueFactory = () => default(string);
        #endregion



        public string CNName
        {
            get { return _CNNameLocator(this).Value; }
            set { _CNNameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string CNName Setup        
        protected Property<string> _CNName = new Property<string> { LocatorFunc = _CNNameLocator };
        static Func<BindableBase, ValueContainer<string>> _CNNameLocator = RegisterContainerLocator("CNName", model => model.Initialize("CNName", ref model._CNName, ref _CNNameLocator, _CNNameDefaultValueFactory));
        static Func<string> _CNNameDefaultValueFactory = () => default(string);
        #endregion


        public bool IsSelected
        {
            get { return _IsSelectedLocator(this).Value; }
            set { _IsSelectedLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsSelected Setup        
        protected Property<bool> _IsSelected = new Property<bool> { LocatorFunc = _IsSelectedLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsSelectedLocator = RegisterContainerLocator("IsSelected", model => model.Initialize("IsSelected", ref model._IsSelected, ref _IsSelectedLocator, _IsSelectedDefaultValueFactory));
        static Func<bool> _IsSelectedDefaultValueFactory = () => default(bool);
        #endregion

    }
}
