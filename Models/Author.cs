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
    public class Author:BindableBase<Author>
    {

        public string AddTime { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Intro { get; set; }


        public IncrementalLoadingCollection<AuthorPostSource, PostDetail> AuthorPostList
        {
            get { return _AuthorPostListLocator(this).Value; }
            set { _AuthorPostListLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property IncrementalLoadingCollection<AuthorPostSource, PostDetail> AuthorPostList Setup        
        protected Property<IncrementalLoadingCollection<AuthorPostSource, PostDetail>> _AuthorPostList = new Property<IncrementalLoadingCollection<AuthorPostSource, PostDetail>> { LocatorFunc = _AuthorPostListLocator };
        static Func<BindableBase, ValueContainer<IncrementalLoadingCollection<AuthorPostSource, PostDetail>>> _AuthorPostListLocator = RegisterContainerLocator<IncrementalLoadingCollection<AuthorPostSource, PostDetail>>("AuthorPostList", model => model.Initialize("AuthorPostList", ref model._AuthorPostList, ref _AuthorPostListLocator, _AuthorPostListDefaultValueFactory));
        static Func<IncrementalLoadingCollection<AuthorPostSource, PostDetail>> _AuthorPostListDefaultValueFactory = () => default(IncrementalLoadingCollection<AuthorPostSource, PostDetail>);
        #endregion

    
        public string Icon
        {
            get { return _IconLocator(this).Value; }
            set { _IconLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string Icon Setup        
        protected Property<string> _Icon = new Property<string> { LocatorFunc = _IconLocator };
        static Func<BindableBase, ValueContainer<string>> _IconLocator = RegisterContainerLocator<string>("Icon", model => model.Initialize("Icon", ref model._Icon, ref _IconLocator, _IconDefaultValueFactory));
        static Func<string> _IconDefaultValueFactory = () => default(string);
        #endregion

    
    }
}
