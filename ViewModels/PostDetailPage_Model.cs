using MVVMSidekick.ViewModels;
using MVVMSidekick.Reactive;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Controls;
using SLWeek.Models;

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
        public string Pictures { get;  set; }




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

        /// <summary>
        /// 导航到图片查看页
        /// </summary>
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
                            var notifyEventArgs = e.EventArgs.Parameter as NotifyEventArgs;
                            if (notifyEventArgs != null)
                            {

                                var link = notifyEventArgs.Value as string;

                                switch (link.Substring(0, Math.Min(4, link.Length)))
                                {
                                    case "pict":
                                        vm.Pictures = link.Replace("picturelist", "");
                                        break;

                                    case "http":
                                        var picviewrvm = new PictureViewerPage_Model();
                                        picviewrvm.ListPictures = new List<Picture>();
                                        var listpicurl = vm.Pictures.Split(new char[] {'\t'},
                                            StringSplitOptions.RemoveEmptyEntries);
                                        for (var i = 0; i < listpicurl.Length; i++)
                                        {
                                            if (listpicurl[i] == link)
                                            {
                                                picviewrvm.SelectIndex = i;
                                            }
                                            picviewrvm.ListPictures.Add(
                                                new Picture()
                                            {
                                                PictureUrl = listpicurl[i],
                                                Index = i + 1
                                            });
                                        }
                                        await vm.StageManager.DefaultStage.Show(picviewrvm);
                                        break;

                                    case "link":
                                        var listpost = link.Split(new char[] {'|'},
                                            StringSplitOptions.RemoveEmptyEntries);

                                        listpost[0] = listpost[0].Remove(0, 7).Replace('/', ' ');

                                        var item = new PostDetail(Convert.ToInt32(listpost[0]), listpost[1]);
                                        await vm.StageManager.DefaultStage.Show(new PostDetailPage_Model(item));
                                        break;

                                    default:
                                        await MVVMSidekick.Utilities.TaskExHelper.Yield();
                                        break;
                                }

                            }
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

