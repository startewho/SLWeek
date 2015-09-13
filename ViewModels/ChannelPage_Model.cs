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
using SLWeek.Source;
using SLWeek.Models;
using SLWeek.Utils;
namespace SLWeek.ViewModels
{

    [DataContract]
    public class ChannelPage_Model : ViewModelBase<ChannelPage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property。
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性
        public ChannelPage_Model()
        {

            Init();
        }


        ///// <summary>
        ///// This will be
        private void Init()
        {
            ListChannels = new List<Channel>
            {
                new Channel("shehui", 20),
                new Channel("wenhua", 20)
            };
        }


        public List<Channel> ListChannels
        {
            get { return _ListChannelsLocator(this).Value; }
            set { _ListChannelsLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property List<Channel> ListChannels Setup        
        protected Property<List<Channel>> _ListChannels = new Property<List<Channel>> { LocatorFunc = _ListChannelsLocator };
        static Func<BindableBase, ValueContainer<List<Channel>>> _ListChannelsLocator = RegisterContainerLocator<List<Channel>>("ListChannels", model => model.Initialize("ListChannels", ref model._ListChannels, ref _ListChannelsLocator, _ListChannelsDefaultValueFactory));
        static Func<List<Channel>> _ListChannelsDefaultValueFactory = () => default(List<Channel>);
        #endregion




    }

}

