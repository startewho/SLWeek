using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLWeek.Source;
using SLWeek.Models;
using MVVMSidekick.ViewModels;

namespace SLWeek.Models
{
    public   class Channel:BindableBase<Channel>
    {

        public Channel(string postkind,int pagecount)
        {
            //shehui
            SoureList = new IncrementalLoadingCollection<PostSource, PostDetail>(postkind, 20);
            PostKind = postkind;
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



        public string PostKind
        {
            get { return _PostKindLocator(this).Value; }
            set { _PostKindLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PostKind Setup        
        protected Property<string> _PostKind = new Property<string> { LocatorFunc = _PostKindLocator };
        static Func<BindableBase, ValueContainer<string>> _PostKindLocator = RegisterContainerLocator<string>("PostKind", model => model.Initialize("PostKind", ref model._PostKind, ref _PostKindLocator, _PostKindDefaultValueFactory));
        static Func<string> _PostKindDefaultValueFactory = () => default(string);
        #endregion










    }
}
