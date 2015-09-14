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
namespace SLWeek.ViewModels
{

    [DataContract]
    public class PictureViewerPage_Model : ViewModelBase<PictureViewerPage_Model>
    {

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


        public int SelectIndex
        {
            get { return _SelectIndexLocator(this).Value; }
            set { _SelectIndexLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int SelectIndex Setup        
        protected Property<int> _SelectIndex = new Property<int> { LocatorFunc = _SelectIndexLocator };
        static Func<BindableBase, ValueContainer<int>> _SelectIndexLocator = RegisterContainerLocator<int>("SelectIndex", model => model.Initialize("SelectIndex", ref model._SelectIndex, ref _SelectIndexLocator, _SelectIndexDefaultValueFactory));
        static Func<int> _SelectIndexDefaultValueFactory = () => default(int);
        #endregion

    }

}

