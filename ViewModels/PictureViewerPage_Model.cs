using MVVMSidekick.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MVVMSidekick.Reactive;
using SLWeek.Models;
namespace SLWeek.ViewModels
{

    [DataContract]
    public class PictureViewerPage_Model : ViewModelBase<PictureViewerPage_Model>
    {
        public PictureViewerPage_Model()
        {
            _isfirstTimeLoad = false;
            Init();
           
        }

        private bool _isfirstTimeLoad;

        protected override Task OnBindedViewLoad(MVVMSidekick.Views.IView view)
        {

            if (!_isfirstTimeLoad)
            {
                PropScribe();
                this._isfirstTimeLoad = true;

            }
            return base.OnBindedViewLoad(view);
        }

        private void Init()
        {
            ListPictures = new List<Picture>();
            PictureIndexOf = String.Empty;
        }


        private void PropScribe()
        {
            GetValueContainer<Picture>(vm => vm.SelectPicture).GetEventObservable().Subscribe(e =>
            {
                
                var picture = e.EventArgs.NewValue;
                if (picture!=null)
                {
                    PictureIndexOf = picture.Index + "/" + ListPictures.Count;
                }

                

            }).DisposeWith(this);
        }

        public List<Picture> ListPictures
        {
            get { return _ListPicturesLocator(this).Value; }
            set { _ListPicturesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property List<Picture> ListPictures Setup        
        protected Property<List<Picture>> _ListPictures = new Property<List<Picture>> { LocatorFunc = _ListPicturesLocator };
        static Func<BindableBase, ValueContainer<List<Picture>>> _ListPicturesLocator = RegisterContainerLocator<List<Picture>>("ListPictures", model => model.Initialize("ListPictures", ref model._ListPictures, ref _ListPicturesLocator, _ListPicturesDefaultValueFactory));
        static Func<List<Picture>> _ListPicturesDefaultValueFactory = () => default(List<Picture>);
        #endregion

        public string PictureIndexOf
        {
            get { return _PictureIndexOfLocator(this).Value; }
            set { _PictureIndexOfLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PictureIndexOf Setup        
        protected Property<string> _PictureIndexOf = new Property<string> { LocatorFunc = _PictureIndexOfLocator };
        static Func<BindableBase, ValueContainer<string>> _PictureIndexOfLocator = RegisterContainerLocator<string>("PictureIndexOf", model => model.Initialize("PictureIndexOf", ref model._PictureIndexOf, ref _PictureIndexOfLocator, _PictureIndexOfDefaultValueFactory));
        static Func<string> _PictureIndexOfDefaultValueFactory = () => default(string);
        #endregion




        public Picture SelectPicture
        {
            get { return _SelectPictureLocator(this).Value; }
            set { _SelectPictureLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property Picture SelectPicture Setup        
        protected Property<Picture> _SelectPicture = new Property<Picture> { LocatorFunc = _SelectPictureLocator };
        static Func<BindableBase, ValueContainer<Picture>> _SelectPictureLocator = RegisterContainerLocator<Picture>("SelectPicture", model => model.Initialize("SelectPicture", ref model._SelectPicture, ref _SelectPictureLocator, _SelectPictureDefaultValueFactory));
        static Func<Picture> _SelectPictureDefaultValueFactory = () => default(Picture);
        #endregion



        public CommandModel<ReactiveCommand, String> CommandSavePicture
        {
            get { return _CommandSavePictureLocator(this).Value; }
            set { _CommandSavePictureLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property CommandModel<ReactiveCommand, String> CommandSavePicture Setup        

        protected Property<CommandModel<ReactiveCommand, String>> _CommandSavePicture = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandSavePictureLocator };
        static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandSavePictureLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandSavePicture", model => model.Initialize("CommandSavePicture", ref model._CommandSavePicture, ref _CommandSavePictureLocator, _CommandSavePictureDefaultValueFactory));
        static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandSavePictureDefaultValueFactory =
            model =>
            {
                var resource = "CommandSavePicture";           // Command resource  
                var commandId = "CommandSavePicture";
                var vm = CastToCurrentType(model);
                var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model }; //New Command Core

                cmd.DoExecuteUIBusyTask(
                        vm,
                        async e =>
                        {
                            //Todo: Add SavePicture logic here, or
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
                            //Todo: Add Refresh logic here, or
                            var picture = vm.SelectPicture;
                            var url = picture.PictureUrl;
                            picture.PictureUrl = string.Empty;
                            picture.PictureUrl = url;
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

