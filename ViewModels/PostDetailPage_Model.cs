using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using MVVMSidekick.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Controls;
using SLWeek.Models;
using SLWeek.ViewModels;
using SLWeek.Views;

// ReSharper disable InconsistentNaming
namespace SLWeek.ViewModels
{

    [DataContract]
    public class PostDetailPage_Model : ViewModelBase<PostDetailPage_Model>
    {
        public PostDetailPage_Model()
        {
                
        }

        public PostDetailPage_Model(PostDetail model)
        {
            if (IsInDesignMode)
            {
                VM.Title = "文章标题";
               
            }
            this.VM = model;
  
        }

      
        public PostDetail VM { get; set; }



        public CommandModel<ReactiveCommand, String> CommandAddScript
        {
            get { return _CommandAddScriptLocator(this).Value; }
            set { _CommandAddScriptLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandAddScript Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandAddScript = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandAddScriptLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandAddScriptLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandAddScript", model => model.Initialize("CommandAddScript", ref model._CommandAddScript, ref _CommandAddScriptLocator, _CommandAddScriptDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandAddScriptDefaultValueFactory =
            model =>
            {
                var resource = "CommandAddScript";           // Command resource  
                var commandId = "CommandAddScript";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            //Todo: Add AddScript logic here, or
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


        /// <summary>
        /// 返回导航前的页面
        /// </summary>
        public CommandModel<ReactiveCommand, String> CommandBack
        {
            get { return _CommandBackLocator(this).Value; }
            set { _CommandBackLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandBack Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandBack = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandBackLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandBackLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandBack", model => model.Initialize("CommandBack", ref model._CommandBack, ref _CommandBackLocator, _CommandBackDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandBackDefaultValueFactory =
            model =>
            {
                var resource = "CommandBack";           // Command resource  
                var commandId = "CommandBack";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            vm.StageManager.DefaultStage.Frame.GoBack();
                            await MVVMSidekick.Utilities.TaskExHelper.Yield();
                        
                           //vm.StageManager.DefaultStage.Frame.Navigate(typeof(ChannelPage));
                          //vm.StageManager.DefaultStage.Frame.GoBack();
                          //await vm.StageManager.DefaultStage.Show(new ChannelPage_Model());
                          //  vm.CloseViewAndDispose();
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



        public CommandModel<ReactiveCommand, String> CommandGoToNewPostPage
        {
            get { return _CommandGoToNewPostPageLocator(this).Value; }
            set { _CommandGoToNewPostPageLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandGoToNewPostPage Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandGoToNewPostPage = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandGoToNewPostPageLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandGoToNewPostPageLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandGoToNewPostPage", model => model.Initialize("CommandGoToNewPostPage", ref model._CommandGoToNewPostPage, ref _CommandGoToNewPostPageLocator, _CommandGoToNewPostPageDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandGoToNewPostPageDefaultValueFactory =
            model =>
            {
                var resource = "CommandGoToNewPostPage";           // Command resource  
                var commandId = "CommandGoToNewPostPage";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            var args = e.EventArgs.Parameter as WebViewUnsupportedUriSchemeIdentifiedEventArgs;
                            var item=new PostDetail(Convert.ToInt32(args.Uri.Host));
                           // item.Id = Convert.ToInt32(args.Uri.Host);
                            args.Handled = true;
                            await vm.StageManager.DefaultStage.Show(new PostDetailPage_Model(item));
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


        public CommandModel<ReactiveCommand, String> CommandViewPicturePage
        {
            get { return _CommandViewPicturePageLocator(this).Value; }
            set { _CommandViewPicturePageLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandViewPicturePage Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandViewPicturePage = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandViewPicturePageLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandViewPicturePageLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandViewPicturePage", model => model.Initialize("CommandViewPicturePage", ref model._CommandViewPicturePage, ref _CommandViewPicturePageLocator, _CommandViewPicturePageDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandViewPicturePageDefaultValueFactory =
            model =>
            {
                var resource = "CommandViewPicturePage";           // Command resource  
                var commandId = "CommandViewPicturePage";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            var strfromweb = e.EventArgs.Parameter as string;

                            //Todo: Add ViewPicturePage logic here, or
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

