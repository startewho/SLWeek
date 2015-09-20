using MVVMSidekick.ViewModels;
using MVVMSidekick.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Controls;
using SLWeek.Models;
using SLWeek.Database;
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
            Init();
            Pictures=new List<Picture>();
            
        }

        private void Init()
        {
            using (var connection =new BookmarkDatabase().GetDatabse())
            {
                var isbookmarked = connection.Find<PostDetail>((item) => item.Id == VM.Id);
                if (isbookmarked!=null)
                {
                    IsBookmarked = true;
                }

            }

        }
      
        public PostDetail VM { get; set; }




        public bool IsBookmarked
        {
            get { return _IsBookmarkedLocator(this).Value; }
            set
            {
                if (VM!=null)
                {
                    using (var connection=new BookmarkDatabase().GetDatabse())
                    {
                        if (value)
                        {
                            connection.InsertOrReplace(VM);

                        }
                        else
                            connection.Delete(VM);
                    }
               

                }
                _IsBookmarkedLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsBookmarked Setup        
        protected Property<bool> _IsBookmarked = new Property<bool> { LocatorFunc = _IsBookmarkedLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsBookmarkedLocator = RegisterContainerLocator<bool>("IsBookmarked", model => model.Initialize("IsBookmarked", ref model._IsBookmarked, ref _IsBookmarkedLocator, _IsBookmarkedDefaultValueFactory));
        static Func<bool> _IsBookmarkedDefaultValueFactory = () => default(bool);
        #endregion


        public List<Picture> Pictures
        {
            get { return _PicturesLocator(this).Value; }
            set { _PicturesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property List<Picture> Pictures Setup        
        protected Property<List<Picture>> _Pictures = new Property<List<Picture>> { LocatorFunc = _PicturesLocator };
        static Func<BindableBase, ValueContainer<List<Picture>>> _PicturesLocator = RegisterContainerLocator<List<Picture>>("Pictures", model => model.Initialize("Pictures", ref model._Pictures, ref _PicturesLocator, _PicturesDefaultValueFactory));
        static Func<List<Picture>> _PicturesDefaultValueFactory = () => default(List<Picture>);
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

                                var link = notifyEventArgs.Value;
                                var links = link.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                switch (link.Substring(0, Math.Min(4, link.Length)))
                                {
                                    case "pict":
                                        var picturls = link.Replace("picturelist", "").Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries); 
                                        for (int i = 0; i < picturls.Length; i++)
                                        {
                                            var pic=picturls[i].Split(new[] { '|' },StringSplitOptions.RemoveEmptyEntries);
                                            vm.Pictures.Add(new Picture()
                                            {
                                                PictureUrl = pic[0],
                                                Des=pic[1],
                                                Index = i + 1
                                            });
                                        }
                                      
                                        break;

                                    case "http":
                                       
                                        var selectpic =(from picture in vm.Pictures where picture.PictureUrl == links[0] select picture).First();

                                        var picviewrvm = new PictureViewerPage_Model
                                        {
                                            ListPictures = vm.Pictures,
                                            SelectPicture = selectpic
                                        };
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



        public CommandModel<ReactiveCommand, String> CommandBookmark
        {
            get { return _CommandBookmarkLocator(this).Value; }
            set { _CommandBookmarkLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandBookmark Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandBookmark = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandBookmarkLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandBookmarkLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandBookmark", model => model.Initialize("CommandBookmark", ref model._CommandBookmark, ref _CommandBookmarkLocator, _CommandBookmarkDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandBookmarkDefaultValueFactory =
            model =>
            {
                var resource = "CommandBookmark";           // Command resource  
                var commandId = "CommandBookmark";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            //Todo: Add Bookmark logic here, or
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

