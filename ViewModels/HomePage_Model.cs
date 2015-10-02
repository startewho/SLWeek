using System;
using System.Runtime.Serialization;
using MVVMSidekick.ViewModels;
using SLWeek.Models;
using SLWeek.Source;

namespace SLWeek.ViewModels
{

    [DataContract]
    public class HomePage_Model : ViewModelBase<HomePage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property。
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性


        public HomePage_Model( )
        {
            //shehui
            SoureList = new IncrementalLoadingCollection<TopPostSource, PostDetail>("960", 20);
        }


        public IncrementalLoadingCollection<TopPostSource,PostDetail> SoureList
        {
            get { return _SoureListLocator(this).Value; }
            set { _SoureListLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property IncrementalLoadingCollection<TopPostSource,PostDetail> SoureList Setup        
        protected Property<IncrementalLoadingCollection<TopPostSource,PostDetail>> _SoureList = new Property<IncrementalLoadingCollection<TopPostSource,PostDetail>> { LocatorFunc = _SoureListLocator };
        static Func<BindableBase, ValueContainer<IncrementalLoadingCollection<TopPostSource,PostDetail>>> _SoureListLocator = RegisterContainerLocator("SoureList", model => model.Initialize("SoureList", ref model._SoureList, ref _SoureListLocator, _SoureListDefaultValueFactory));
        static Func<IncrementalLoadingCollection<TopPostSource,PostDetail>> _SoureListDefaultValueFactory = () => default(IncrementalLoadingCollection<TopPostSource,PostDetail>);
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






    }

}

