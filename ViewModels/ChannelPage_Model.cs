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

        private void Init()
        {
            SoureList = new IncrementalLoadingCollection<PostSource, PostModel>("shehui",20);
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

        public string Postkind
        {
            get { return _PostkindLocator(this).Value; }
            set { _PostkindLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Postkind Setup        
        protected Property<string> _Postkind = new Property<string> { LocatorFunc = _PostkindLocator };
        static Func<BindableBase, ValueContainer<string>> _PostkindLocator = RegisterContainerLocator<string>("Postkind", model => model.Initialize("Postkind", ref model._Postkind, ref _PostkindLocator, _PostkindDefaultValueFactory));
        static Func<string> _PostkindDefaultValueFactory = () => default(string);
        #endregion






        public IncrementalLoadingCollection<PostSource,PostModel> SoureList
        {
            get { return _MyPropertyLocator(this).Value; }
            set { _MyPropertyLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property IncrementalLoadingCollection<PersonSource,PostModel> MyProperty Setup        
        protected Property<IncrementalLoadingCollection<PostSource,PostModel>> _MyProperty = new Property<IncrementalLoadingCollection<PostSource,PostModel>> { LocatorFunc = _MyPropertyLocator };
        static Func<BindableBase, ValueContainer<IncrementalLoadingCollection<PostSource,PostModel>>> _MyPropertyLocator = RegisterContainerLocator<IncrementalLoadingCollection<PostSource,PostModel>>("MyProperty", model => model.Initialize("MyProperty", ref model._MyProperty, ref _MyPropertyLocator, _MyPropertyDefaultValueFactory));
        static Func<IncrementalLoadingCollection<PostSource,PostModel>> _MyPropertyDefaultValueFactory = () => default(IncrementalLoadingCollection<PostSource,PostModel>);
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
                            var item = e.EventArgs.Parameter as PostModel;
                            if (item != null)
                            {

                                var postvm = new PostDetailPage_Model(item);
                                await vm.StageManager.DefaultStage.Show(postvm);

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




    }

}

