using System;
using SLWeek.Source;
using MVVMSidekick.ViewModels;
using SLWeek.Utils;

namespace SLWeek.Models
{
    public   class Channel:BindableBase<Channel>
    {

        public Channel(string postkind,int pagecount,bool isselected)
        {
            //shehui
            SoureList = new IncrementalLoadingCollection<PostSource, PostDetail>(postkind, 20);
            PostKind = new PostType() {Name = postkind, CNName = Strings.PostTypeDic[postkind]};
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
        static Func<BindableBase, ValueContainer<IncrementalLoadingCollection<PostSource, PostDetail>>> _SoureListLocator = RegisterContainerLocator<IncrementalLoadingCollection<PostSource, PostDetail>>("SoureList", model => model.Initialize("SoureList", ref model._SoureList, ref _SoureListLocator, _SoureListDefaultValueFactory));
        static Func<IncrementalLoadingCollection<PostSource, PostDetail>> _SoureListDefaultValueFactory = () => default(IncrementalLoadingCollection<PostSource, PostDetail>);
        #endregion


        public bool IsSelected
        {
            get { return _IsSelectedLocator(this).Value; }
            set { _IsSelectedLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsSelected Setup        
        protected Property<bool> _IsSelected = new Property<bool> { LocatorFunc = _IsSelectedLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsSelectedLocator = RegisterContainerLocator<bool>("IsSelected", model => model.Initialize("IsSelected", ref model._IsSelected, ref _IsSelectedLocator, _IsSelectedDefaultValueFactory));
        static Func<bool> _IsSelectedDefaultValueFactory = () => default(bool);
        #endregion





        public PostType PostKind
        {
            get { return _PostKindLocator(this).Value; }
            set { _PostKindLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property PostType PostKind Setup        
        protected Property<PostType> _PostKind = new Property<PostType> { LocatorFunc = _PostKindLocator };
        static Func<BindableBase, ValueContainer<PostType>> _PostKindLocator = RegisterContainerLocator<PostType>("PostKind", model => model.Initialize("PostKind", ref model._PostKind, ref _PostKindLocator, _PostKindDefaultValueFactory));
        static Func<PostType> _PostKindDefaultValueFactory = () => default(PostType);
        #endregion








    }
}
