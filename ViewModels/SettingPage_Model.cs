using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using SLWeek.Models;
using SLWeek.Utils;
namespace SLWeek.ViewModels
{

    [DataContract]
    public class SettingPage_Model : ViewModelBase<SettingPage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property。
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性

        public SettingPage_Model()
        {
            Title = "设置";
            IsImageMode = CommonAppSettings.Instance.IsEnableImageMode;
            ListPostTypes = CommonAppSettings.Instance.SelectChannelTypes;
            PropScribe();
        }
        public String Title
        {
            get { return _TitleLocator(this).Value; }
            set { _TitleLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property String Title Setup
        protected Property<String> _Title = new Property<String> { LocatorFunc = _TitleLocator };
        static Func<BindableBase, ValueContainer<String>> _TitleLocator = RegisterContainerLocator<String>("Title", model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));
        static Func<BindableBase, String> _TitleDefaultValueFactory = m => m.GetType().Name;
        #endregion

        private void PropScribe()
        {
            GetValueContainer<bool>(vm =>vm.IsImageMode).GetEventObservable().Subscribe(e =>
            {
                var isimagemode = e.EventArgs.NewValue;
                CommonAppSettings.Instance.IsEnableImageMode = isimagemode;
            }).DisposeWith(this);

            GetValueContainer<List<PostType>>(vm => vm.ListPostTypes).GetEventObservable().Subscribe(e =>
            {
                var changeValue =e.EventArgs.NewValue;
                CommonAppSettings.Instance.SelectChannelTypes = changeValue;
            }).DisposeWith(this);
        }


        protected override Task OnBindedViewUnload(MVVMSidekick.Views.IView view)
        {

        CommonAppSettings.Instance.SelectChannelTypes = ListPostTypes;
            return base.OnBindedViewUnload(view);
        }

        public List<PostType> ListPostTypes
        {
            get { return _ListPostTypesLocator(this).Value; }
            set { _ListPostTypesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property List<PostType> ListPostTypes Setup        
        protected Property<List<PostType>> _ListPostTypes = new Property<List<PostType>> { LocatorFunc = _ListPostTypesLocator };
        static Func<BindableBase, ValueContainer<List<PostType>>> _ListPostTypesLocator = RegisterContainerLocator<List<PostType>>("ListPostTypes", model => model.Initialize("ListPostTypes", ref model._ListPostTypes, ref _ListPostTypesLocator, _ListPostTypesDefaultValueFactory));
        static Func<List<PostType>> _ListPostTypesDefaultValueFactory = () => default(List<PostType>);
        #endregion

        

        public bool IsImageMode
        {
            get { return _IsImageModeLocator(this).Value; }
            set
            {
                _IsImageModeLocator(this).SetValueAndTryNotify(value);
            
            }
        }
        #region Property bool IsImageMode Setup        
        protected Property<bool> _IsImageMode = new Property<bool> { LocatorFunc = _IsImageModeLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsImageModeLocator = RegisterContainerLocator<bool>("IsImageMode", model => model.Initialize("IsImageMode", ref model._IsImageMode, ref _IsImageModeLocator, _IsImageModeDefaultValueFactory));
        static Func<bool> _IsImageModeDefaultValueFactory = () => default(bool);
        #endregion


    }

}

