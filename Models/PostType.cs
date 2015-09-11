using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        static Func<BindableBase, ValueContainer<string>> _NameLocator = RegisterContainerLocator<string>("Name", model => model.Initialize("Name", ref model._Name, ref _NameLocator, _NameDefaultValueFactory));
        static Func<string> _NameDefaultValueFactory = () => default(string);
        #endregion


        public string CNName
        {
            get { return _CNNameLocator(this).Value; }
            set { _CNNameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string CNName Setup        
        protected Property<string> _CNName = new Property<string> { LocatorFunc = _CNNameLocator };
        static Func<BindableBase, ValueContainer<string>> _CNNameLocator = RegisterContainerLocator<string>("CNName", model => model.Initialize("CNName", ref model._CNName, ref _CNNameLocator, _CNNameDefaultValueFactory));
        static Func<string> _CNNameDefaultValueFactory = () => default(string);
        #endregion

    }
}
