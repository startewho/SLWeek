using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using SLWeek.Models;
using SLWeek.Utils;

namespace SLWeek.ViewModels
{

    [DataContract]
    public class ChannelPage_Model : ViewModelBase<ChannelPage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property。
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性


        protected override Task OnBindedViewLoad(IView view)
        {
         
            ObservableChannels = new ObservableCollection<Channel>();
                      
            foreach (var channeltype in AppSettings.Instance.SelectChannelTypes)
            {
                ObservableChannels.Add(new Channel(channeltype.Name, AppStrings.PageSize, false));
            }

            //SelectPivotItemIndex = 0;
            SelectedChannel = ObservableChannels[0];
            SelectedChannel.IsSelected = true;

            return base.OnBindedViewLoad(view);
        }

        //protected override Task OnBindedViewUnload(IView view)
        //{
        //    foreach (var channel in ObservableChannels)
        //    {
        //        channel.IsSelected = false;
        //    }

        //    return base.OnBindedViewUnload(view);
        //}

        /// <summary>
        /// 选中的PivotItem进行显示,其它的PivotItem折叠
        /// </summary>
        public int SelectPivotItemIndex
        {
            get { return _SelectPivotItemIndexLocator(this).Value; }
            set
            {
                _SelectPivotItemIndexLocator(this).SetValueAndTryNotify(value);

                for (var i = 0; i < ObservableChannels.Count; i++)
                {
                    if (i != value)
                    {
                     ObservableChannels[i].IsSelected = false;
                    }
                    else
                    {
                      ObservableChannels[value].IsSelected = true;
                    }
                }
       
            }
        }
        #region Property int SelectPivotItemIndex Setup        
        protected Property<int> _SelectPivotItemIndex = new Property<int> { LocatorFunc = _SelectPivotItemIndexLocator };
        static Func<BindableBase, ValueContainer<int>> _SelectPivotItemIndexLocator = RegisterContainerLocator("SelectPivotItemIndex", model => model.Initialize("SelectPivotItemIndex", ref model._SelectPivotItemIndex, ref _SelectPivotItemIndexLocator, _SelectPivotItemIndexDefaultValueFactory));
        static Func<int> _SelectPivotItemIndexDefaultValueFactory = () => default(int);
        #endregion

        /// <summary>
        /// 选中的Channel显示,其他折叠已节省内存
        /// </summary>
        public Channel SelectedChannel
        {
            get { return _SelectedChannelLocator(this).Value; }
            set
            {
                if (value!=null)
                {
                  
                    foreach (Channel channel in ObservableChannels.Where(t => t != value))
                    {
                        channel.IsSelected = false;
                    }
                    value.IsSelected = true;
                }
                _SelectedChannelLocator(this).SetValueAndTryNotify(value);
                
            }
        }
        #region Property Channel SelectedChannel Setup        
        protected Property<Channel> _SelectedChannel = new Property<Channel> { LocatorFunc = _SelectedChannelLocator };
        static Func<BindableBase, ValueContainer<Channel>> _SelectedChannelLocator = RegisterContainerLocator("SelectedChannel", model => model.Initialize("SelectedChannel", ref model._SelectedChannel, ref _SelectedChannelLocator, _SelectedChannelDefaultValueFactory));
        static Func<Channel> _SelectedChannelDefaultValueFactory = () => default(Channel);
        #endregion


        public ObservableCollection<Channel> ObservableChannels
        {
            get { return _ObservableChannelsLocator(this).Value; }
            set { _ObservableChannelsLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<Channel> ObservableChannels Setup        
        protected Property<ObservableCollection<Channel>> _ObservableChannels = new Property<ObservableCollection<Channel>> { LocatorFunc = _ObservableChannelsLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<Channel>>> _ObservableChannelsLocator = RegisterContainerLocator("ObservableChannels", model => model.Initialize("ObservableChannels", ref model._ObservableChannels, ref _ObservableChannelsLocator, _ObservableChannelsDefaultValueFactory));
        static Func<ObservableCollection<Channel>> _ObservableChannelsDefaultValueFactory = () => default(ObservableCollection<Channel>);
        #endregion


    }

}

