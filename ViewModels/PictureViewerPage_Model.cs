using MVVMSidekick.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SLWeek.Models;
namespace SLWeek.ViewModels
{

    [DataContract]
    public class PictureViewerPage_Model : ViewModelBase<PictureViewerPage_Model>
    {
        public PictureViewerPage_Model()
        {
            ListPictures=new List<Picture>();
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


    }

}

