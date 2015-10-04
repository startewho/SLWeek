using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using Windows.UI;
using Windows.UI.Xaml;
using MVVMSidekick.EventRouting;
using MVVMSidekick.Reactive;
using MVVMSidekick.Utilities;
using MVVMSidekick.ViewModels;
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
            IsLightTheme = ElementTheme.Light == AppSettings.Instance.CurrentTheme;
            IsAccentTitleBar = AppSettings.Instance.IsAccentColorTitleBar;
            SelectedPostTypes = AppSettings.Instance.SelectChannelTypes;
            AccentColors = AppSettings.Instance.AccentColors;
            AccentColor = AppSettings.Instance.AccentColor;

            ListPostTypes = new List<PostType>
        {
            new PostType {Name = "shehui", CNName = "社会", IsSelected = false},
            new PostType {Name = "wenhua", CNName = "文化", IsSelected = false},
            new PostType {Name = "keji", CNName = "科技", IsSelected = false},
            new PostType {Name = "guoji", CNName = "国际", IsSelected = false},
            new PostType {Name = "shishang", CNName = "时尚", IsSelected = false},
            new PostType {Name = "renwu", CNName = "人物", IsSelected = false},
            new PostType {Name = "jingji", CNName = "经济", IsSelected = false},
            new PostType {Name = "shoucang", CNName = "收藏", IsSelected = false},
            new PostType {Name = "zhuanfang", CNName = "专访", IsSelected = false},
            new PostType {Name = "lvyou", CNName = "旅游", IsSelected = false},
            new PostType {Name = "yuanzhuo", CNName = "圆桌", IsSelected = false}
        };
            foreach (var listPostType in ListPostTypes)
            {
                foreach (var selectedPostType in SelectedPostTypes)
                {
                    if (listPostType.Name==selectedPostType.Name)
                    {
                        listPostType.IsSelected = selectedPostType.IsSelected;
                    }
                }
            }
        
         
        }

        private void PropScribe()
        {
            GetValueContainer(vm => vm.IsImageMode).GetNewValueObservable().Subscribe(e =>
            {
                var isimagemode = e.EventArgs;
                AppSettings.Instance.IsEnableImageMode = isimagemode;
            }).DisposeWith(this);

            GetValueContainer(vm => vm.IsLightTheme).GetNewValueObservable().Subscribe( async e => 
            {
                var islighttheme = e.EventArgs;
                AppSettings.Instance.CurrentTheme = islighttheme ? ElementTheme.Light : ElementTheme.Dark;
                App.SetShellDecoration(false);
                //StageManager.DefaultStage.Frame.RequestedTheme = AppSettings.Instance.CurrentTheme;
                await TaskExHelper.Yield();
                // await StageManager.DefaultStage.Show(new SettingPage_Model());
                // ((Page) this.StageManager.CurrentBindingView).RequestedTheme = AppSettings.Instance.CurrentTheme;

            }).DisposeWith(this);

            GetValueContainer(vm => vm.AccentColor).GetNewValueObservable().Subscribe( e =>
            {
                var accentcolor = e.EventArgs;
                AppSettings.Instance.AccentColor = accentcolor;
                App.SetShellDecoration(true);
                
                //  await StageManager.DefaultStage.Show(new SettingPage_Model());
            }).DisposeWith(this);



            //CheckBox点击之后,马上更改设置,以实现实时更新
            EventRouter.Instance.GetEventChannel<Object>()
                .Where(x => x.EventName == "NotyCheckedByEventRouter")
                .Subscribe(
                    async e =>
                    {
                        var item = e.EventData as PostType;
                        if (item!=null)
                        {
                            var query = ListPostTypes.Where(listPosttype => listPosttype.IsSelected);
                            AppSettings.Instance.SelectChannelTypes = query.ToList();
                        }

                        await TaskExHelper.Yield();
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
            RegisterContainerLocator("Title",
                model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));

        private static Func<BindableBase, String> _TitleDefaultValueFactory = m => m.GetType().Name;

        #endregion




        public List<Color> AccentColors
        {
            get { return _AccentColorsLocator(this).Value; }
            set
            {
                _AccentColorsLocator(this).SetValueAndTryNotify(value);
              
            }
        }
        #region Property List<Color> AccentColors Setup        
        protected Property<List<Color>> _AccentColors = new Property<List<Color>> { LocatorFunc = _AccentColorsLocator };
        static Func<BindableBase, ValueContainer<List<Color>>> _AccentColorsLocator = RegisterContainerLocator<List<Color>>("AccentColors", model => model.Initialize("AccentColors", ref model._AccentColors, ref _AccentColorsLocator, _AccentColorsDefaultValueFactory));
        static Func<List<Color>> _AccentColorsDefaultValueFactory = () => default(List<Color>);
        #endregion


        public Color AccentColor
        {
            get { return _AccentColorLocator(this).Value; }
            set
            {
                _AccentColorLocator(this).SetValueAndTryNotify(value);
              
            }
        }
        #region Property Color AccentColor Setup        
        protected Property<Color> _AccentColor = new Property<Color> { LocatorFunc = _AccentColorLocator };
        static Func<BindableBase, ValueContainer<Color>> _AccentColorLocator = RegisterContainerLocator<Color>("AccentColor", model => model.Initialize("AccentColor", ref model._AccentColor, ref _AccentColorLocator, _AccentColorDefaultValueFactory));
        static Func<Color> _AccentColorDefaultValueFactory = () => default(Color);
        #endregion
       

        public List<PostType> SelectedPostTypes
        {
            get { return _SelectedPostTypesLocator(this).Value; }
            set { _SelectedPostTypesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property List<PostType> SelectedPostTypes Setup        
        protected Property<List<PostType>> _SelectedPostTypes = new Property<List<PostType>> { LocatorFunc = _SelectedPostTypesLocator };
        static Func<BindableBase, ValueContainer<List<PostType>>> _SelectedPostTypesLocator = RegisterContainerLocator("SelectedPostTypes", model => model.Initialize("SelectedPostTypes", ref model._SelectedPostTypes, ref _SelectedPostTypesLocator, _SelectedPostTypesDefaultValueFactory));
        static Func<List<PostType>> _SelectedPostTypesDefaultValueFactory = () => default(List<PostType>);
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
            RegisterContainerLocator("ListPostTypes",
                model =>
                    model.Initialize("ListPostTypes", ref model._ListPostTypes, ref _ListPostTypesLocator,
                        _ListPostTypesDefaultValueFactory));

        private static Func<List<PostType>> _ListPostTypesDefaultValueFactory = () => default(List<PostType>);

        #endregion



        /// <summary>
        /// 是否采用Ligth主题
        /// </summary>
        public bool IsLightTheme
        {
            get { return _IsLightThemeLocator(this).Value; }
            set { _IsLightThemeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsLightTheme Setup        
        protected Property<bool> _IsLightTheme = new Property<bool> { LocatorFunc = _IsLightThemeLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsLightThemeLocator = RegisterContainerLocator("IsLightTheme", model => model.Initialize("IsLightTheme", ref model._IsLightTheme, ref _IsLightThemeLocator, _IsLightThemeDefaultValueFactory));
        static Func<bool> _IsLightThemeDefaultValueFactory = () => default(bool);
        #endregion


        public bool IsAccentTitleBar
        {
            get { return _IsAccentTitleBarLocator(this).Value; }
            set { _IsAccentTitleBarLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsAccentTitleBar Setup        
        protected Property<bool> _IsAccentTitleBar = new Property<bool> { LocatorFunc = _IsAccentTitleBarLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsAccentTitleBarLocator = RegisterContainerLocator<bool>("IsAccentTitleBar", model => model.Initialize("IsAccentTitleBar", ref model._IsAccentTitleBar, ref _IsAccentTitleBarLocator, _IsAccentTitleBarDefaultValueFactory));
        static Func<bool> _IsAccentTitleBarDefaultValueFactory = () => default(bool);
        #endregion



        public bool IsImageMode
        {
            get { return _IsImageModeLocator(this).Value; }
            set { _IsImageModeLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property bool IsImageMode Setup        

        protected Property<bool> _IsImageMode = new Property<bool> {LocatorFunc = _IsImageModeLocator};

        private static Func<BindableBase, ValueContainer<bool>> _IsImageModeLocator =
            RegisterContainerLocator("IsImageMode",
                model =>
                    model.Initialize("IsImageMode", ref model._IsImageMode, ref _IsImageModeLocator,
                        _IsImageModeDefaultValueFactory));

        private static Func<bool> _IsImageModeDefaultValueFactory = () => default(bool);

        #endregion
    }
}

