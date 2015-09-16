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
            InitModel();
            PropScribe();
        }

        private void InitModel()
        {
            Title = "设置";
            IsImageMode = AppSettings.Instance.IsEnableImageMode;
            ListPostTypes = AppSettings.Instance.SelectChannelTypes;
        }

        private void PropScribe()
        {
            GetValueContainer<bool>(vm => vm.IsImageMode).GetEventObservable().Subscribe(e =>
            {
                var isimagemode = e.EventArgs.NewValue;
                AppSettings.Instance.IsEnableImageMode = isimagemode;
            }).DisposeWith(this);


            //CheckBox点击之后,马上更改设置,以实现实时更新
            MVVMSidekick.EventRouting.EventRouter.Instance.GetEventChannel<Object>()
                .Where(x => x.EventName == "NotyCheckedByEventRouter")
                .Subscribe(
                    async e =>
                    {
                        await MVVMSidekick.Utilities.TaskExHelper.Yield();
                        var item = e.EventData as PostType;
                        if (item != null)
                        {
                            AppSettings.Instance.SelectChannelTypes = ListPostTypes;
                            //StageManager.DefaultStage.Frame.Navigate(typeof(PostDetailPage),item);
                        }

                    }
                ).DisposeWith(this);


        }

        public String Title
        {
            get { return _TitleLocator(this).Value; }
            set { _TitleLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property String Title Setup

        protected Property<String> _Title = new Property<String> {LocatorFunc = _TitleLocator};

        private static Func<BindableBase, ValueContainer<String>> _TitleLocator =
            RegisterContainerLocator<String>("Title",
                model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));

        private static Func<BindableBase, String> _TitleDefaultValueFactory = m => m.GetType().Name;

        #endregion

    

        public List<PostType> ListPostTypes
        {
            get { return _ListPostTypesLocator(this).Value; }
            set { _ListPostTypesLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property List<PostType> ListPostTypes Setup        

        protected Property<List<PostType>> _ListPostTypes = new Property<List<PostType>>
        {
            LocatorFunc = _ListPostTypesLocator
        };

        private static Func<BindableBase, ValueContainer<List<PostType>>> _ListPostTypesLocator =
            RegisterContainerLocator<List<PostType>>("ListPostTypes",
                model =>
                    model.Initialize("ListPostTypes", ref model._ListPostTypes, ref _ListPostTypesLocator,
                        _ListPostTypesDefaultValueFactory));

        private static Func<List<PostType>> _ListPostTypesDefaultValueFactory = () => default(List<PostType>);

        #endregion




        public bool IsImageMode
        {
            get { return _IsImageModeLocator(this).Value; }
            set { _IsImageModeLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property bool IsImageMode Setup        

        protected Property<bool> _IsImageMode = new Property<bool> {LocatorFunc = _IsImageModeLocator};

        private static Func<BindableBase, ValueContainer<bool>> _IsImageModeLocator =
            RegisterContainerLocator<bool>("IsImageMode",
                model =>
                    model.Initialize("IsImageMode", ref model._IsImageMode, ref _IsImageModeLocator,
                        _IsImageModeDefaultValueFactory));

        private static Func<bool> _IsImageModeDefaultValueFactory = () => default(bool);

        #endregion
    }
}

