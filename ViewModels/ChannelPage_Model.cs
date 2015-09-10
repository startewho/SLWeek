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

            if (IsInDesignMode)
            {
                Title = "InDesginMode";
                SoureList=new IncrementalLoadingCollection<PostSource, PostDetail>("",20);
               
                PostKindList=new List<string>() {"shehui","keji","yixue"};
            }

            Init();
        }
        private bool isLoaded;

       
        protected override Task OnBindedViewLoad(MVVMSidekick.Views.IView view)
        {

            if (!isLoaded)
            {
                this.SubscribeCommand();
                this.isLoaded = true;
            }

            return base.OnBindedViewLoad(view);
        }
        private void SubscribeCommand()
        {
            MVVMSidekick.EventRouting.EventRouter.Instance.GetEventChannel<Object>()
                .Where(x => x.EventName == "NavToDetailByEventRouter")
                .Subscribe(
                    async e =>
                    {
                        await MVVMSidekick.Utilities.TaskExHelper.Yield();
                        var item = e.EventData as PostDetail;
                        if (item != null)
                        {
                             await StageManager.DefaultStage.Show(new PostDetailPage_Model(item));
                           //  StageManager.DefaultStage.Frame.Navigate(typeof(PostDetailPage),item);
                        }

                    }
                ).DisposeWith(this);
        }

        ///// <summary>
        ///// This will be
        private void Init()
        {
            SoureList = new IncrementalLoadingCollection<PostSource, PostDetail>("shehui",20);
            PostKindList = new List<string>() { "shehui", "keji", "yixue" };
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




        public List<string> PostKindList
        {
            get { return _PostKindListLocator(this).Value; }
            set { _PostKindListLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property List<string> PostKindList Setup        
        protected Property<List<string>> _PostKindList = new Property<List<string>> { LocatorFunc = _PostKindListLocator };
        static Func<BindableBase, ValueContainer<List<string>>> _PostKindListLocator = RegisterContainerLocator<List<string>>("PostKindList", model => model.Initialize("PostKindList", ref model._PostKindList, ref _PostKindListLocator, _PostKindListDefaultValueFactory));
        static Func<List<string>> _PostKindListDefaultValueFactory = () => default(List<string>);
        #endregion






        public IncrementalLoadingCollection<PostSource, PostDetail> SoureList
        {
            get { return _SoureListLocator(this).Value; }
            set { _SoureListLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property IncrementalLoadingCollection<PostSource,PostDetailPage_Model> SoureList Setup        
        protected Property<IncrementalLoadingCollection<PostSource, PostDetail>> _SoureList = new Property<IncrementalLoadingCollection<PostSource, PostDetail>> { LocatorFunc = _SoureListLocator };
        static Func<BindableBase, ValueContainer<IncrementalLoadingCollection<PostSource, PostDetail>>> _SoureListLocator = RegisterContainerLocator<IncrementalLoadingCollection<PostSource, PostDetail>>("SoureList", model => model.Initialize("SoureList", ref model._SoureList, ref _SoureListLocator, _SoureListDefaultValueFactory));
        static Func<IncrementalLoadingCollection<PostSource, PostDetail>> _SoureListDefaultValueFactory = () => default(IncrementalLoadingCollection<PostSource, PostDetail>);
        #endregion



        public CommandModel<ReactiveCommand, String> CommandGotoPost
        {
            get { return _CommandGotoPostLocator(this).Value; }
            set { _CommandGotoPostLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandGotoPost Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandGotoPost = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandGotoPostLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandGotoPostLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandGotoPost", model => model.Initialize("CommandGotoPost", ref model._CommandGotoPost, ref _CommandGotoPostLocator, _CommandGotoPostDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandGotoPostDefaultValueFactory =
            model =>
            {
                var resource = "CommandGotoPost";           // Command resource  
                var commandId = "CommandGotoPost";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            var item = e.EventArgs.Parameter as PostDetail;
                            if (item != null)
                            {
                                
                                await vm.StageManager.DefaultStage.Show(new PostDetailPage_Model(item));

                            }

                            //Todo: Add GotoPost logic here, or
                            await MVVMSidekick.Utilities.TaskExHelper.Yield();


                        })
                    .DoNotifyDefaultEventRouter(vm, commandId)
                    .Subscribe()
                    .DisposeWith(vm);
                   

                var cmdmdl = cmd.CreateCommandModel(resource);

                cmdmdl.ListenToIsUIBusy(
                    model: vm,
                    canExecuteWhenBusy: false);
                return cmdmdl;
            };

        #endregion


        public CommandModel<ReactiveCommand, String> CommandRefresh
        {
            get { return _CommandRefreshLocator(this).Value; }
            set { _CommandRefreshLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandRefresh Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandRefresh = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandRefreshLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandRefreshLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandRefresh", model => model.Initialize("CommandRefresh", ref model._CommandRefresh, ref _CommandRefreshLocator, _CommandRefreshDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandRefreshDefaultValueFactory =
            model =>
            {
                var resource = "CommandRefresh";           // Command resource  
                var commandId = "CommandRefresh";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            vm.Init();
                            //Todo: Add Refresh logic here, or
                            await MVVMSidekick.Utilities.TaskExHelper.Yield();
                        })
                    .DoNotifyDefaultEventRouter(vm, commandId)
                    .Subscribe()
                    .DisposeWith(vm);

                var cmdmdl = cmd.CreateCommandModel(resource);

                cmdmdl.ListenToIsUIBusy(
                    model: vm,
                    canExecuteWhenBusy: false);
                return cmdmdl;
            };

        #endregion



    }

}

