using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLWeek.Source;
using SLWeek.Models;
using MVVMSidekick.ViewModels;
using SLWeek.Utils;

namespace SLWeek.Models
{
    public   class Channel:BindableBase<Channel>
    {

        public Channel(string postkind,int pagecount)
        {
            //shehui
            SoureList = new IncrementalLoadingCollection<PostSource, PostDetail>(postkind, 20);
            PostKind = new PostType() {Name = postkind, CNName = Strings.PostTypeDic[postkind]};
        }

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
