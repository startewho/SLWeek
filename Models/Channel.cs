using System;
using MVVMSidekick.ViewModels;
using SLWeek.Source;
using SLWeek.Utils;

namespace SLWeek.Models
{
    public   class Channel:BindableBase<Channel>
    {

        public Channel(string postkind,int pagesize,bool isselected)
        {
            PageSize = pagesize;
            SoureList = new IncrementalLoadingCollection<PostSource, PostDetail>(postkind, pagesize);
            PostKind = new PostType {Name = postkind, CNName = AppStrings.PostTypeDic[postkind]};
            IsSelected = isselected;
        }

        public IncrementalLoadingCollection<PostSource, PostDetail> SoureList
        {
            get { return _SoureListLocator(this).Value; }
            set
            {
                _SoureListLocator(this).SetValueAndTryNotify(value);
               
            }
        }


        #region Property IncrementalLoadingCollection<PostSource,PostDetailPage_Model> SoureList Setup        
        protected Property<IncrementalLoadingCollection<PostSource, PostDetail>> _SoureList = new Property<IncrementalLoadingCollection<PostSource, PostDetail>> { LocatorFunc = _SoureListLocator };
        static Func<BindableBase, ValueContainer<IncrementalLoadingCollection<PostSource, PostDetail>>> _SoureListLocator = RegisterContainerLocator("SoureList", model => model.Initialize("SoureList", ref model._SoureList, ref _SoureListLocator, _SoureListDefaultValueFactory));
        static Func<IncrementalLoadingCollection<PostSource, PostDetail>> _SoureListDefaultValueFactory = () => default(IncrementalLoadingCollection<PostSource, PostDetail>);
        #endregion


        public bool IsSelected
        {
            get { return _IsSelectedLocator(this).Value; }
            set { _IsSelectedLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsSelected Setup        
        protected Property<bool> _IsSelected = new Property<bool> { LocatorFunc = _IsSelectedLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsSelectedLocator = RegisterContainerLocator("IsSelected", model => model.Initialize("IsSelected", ref model._IsSelected, ref _IsSelectedLocator, _IsSelectedDefaultValueFactory));
        static Func<bool> _IsSelectedDefaultValueFactory = () => default(bool);
        #endregion





        public PostType PostKind
        {
            get { return _PostKindLocator(this).Value; }
            set { _PostKindLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property PostType PostKind Setup        
        protected Property<PostType> _PostKind = new Property<PostType> { LocatorFunc = _PostKindLocator };
        static Func<BindableBase, ValueContainer<PostType>> _PostKindLocator = RegisterContainerLocator("PostKind", model => model.Initialize("PostKind", ref model._PostKind, ref _PostKindLocator, _PostKindDefaultValueFactory));
        static Func<PostType> _PostKindDefaultValueFactory = () => default(PostType);
        #endregion





        public int PageSize
        {
            get { return _PageSizeLocator(this).Value; }
            set { _PageSizeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int PageSize Setup        
        protected Property<int> _PageSize = new Property<int> { LocatorFunc = _PageSizeLocator };
        static Func<BindableBase, ValueContainer<int>> _PageSizeLocator = RegisterContainerLocator<int>("PageSize", model => model.Initialize("PageSize", ref model._PageSize, ref _PageSizeLocator, _PageSizeDefaultValueFactory));
        static Func<int> _PageSizeDefaultValueFactory = () => default(int);
        #endregion




    }
}
