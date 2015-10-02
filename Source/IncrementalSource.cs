using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SLWeek.Source
{
    public interface IIncrementalSource<T>
    {
        /// <summary>
        /// 数据源接口
        /// </summary>
        /// <param name="query">查询语句</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetPagedItems(string query,int pageIndex, int pageSize);
    }

    public class IncrementalLoadingCollection<T, I> : ObservableCollection<I>,
         ISupportIncrementalLoading
         where T : IIncrementalSource<I>, new()
    {
        private T source;
        private int pageSize;
        private bool hasMoreItems;
        private int currentPage;
        private string query;

        public IncrementalLoadingCollection(string query,int pageSize )
        {
            source = new T();
            this.pageSize = pageSize;
            hasMoreItems = true;
            this.query = query;
        }

        public bool HasMoreItems
        {
            get { return hasMoreItems; }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
          
            var dispatcher = Window.Current.Dispatcher;

            return Task.Run(
                async () =>
                {
                    uint resultCount = 0;
                   
                    var result = await source.GetPagedItems(query,currentPage++, pageSize);
                   
                    if (result != null && dispatcher != null && result.Any())
                    {
                        resultCount = (uint) result.Count();
                      
                            await dispatcher.RunAsync(
                                CoreDispatcherPriority.High,
                                () =>
                                {
                                    foreach (I item in result)
                                        Add(item);
                                   
                                });
                        if (resultCount < pageSize)
                        {
                            hasMoreItems = false;
                        }
                    }
                    else
                    {
                        hasMoreItems = false;
                    }

                    Debug.WriteLine("Already Loading count{0},Everytime loading count:{1}",Items.Count, count);
                    return new LoadMoreItemsResult { Count = resultCount };

                }).AsAsyncOperation();
        }
    }


}
