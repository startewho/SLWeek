using SQLite.Net;
using SLWeek.Utils;
using SQLite.Net.Platform.WinRT;
using SLWeek.Models;
using System.IO;
using Windows.Storage;

namespace SLWeek.Database
{
    public static class BookmarkDatabase 
    {
      private static readonly string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, AppStrings.BookmarkDbName);

        private static SQLiteConnection GetDatabse()
        {
           var connection = new SQLiteConnection(new SQLitePlatformWinRT(), DbPath);
           // 创建 Person 模型对应的表,如果已存在,则忽略该操作。
           connection.CreateTable<PostDetail>();
           return connection;
        }

        public static PostDetail QueryPost(int id)
        {

            return (from t in GetDatabse().Table<PostDetail>()
                where t.Id == id
                select t).FirstOrDefault();

        }

        public static void DeletPost(PostDetail post)
        {
            using (var connect=GetDatabse())
            {
                connect.Delete(post);
            }
           
        }

        public static void AddPost(PostDetail post)
        {
            using (var connect = GetDatabse())
            {
                connect.InsertOrReplace(post);
            }
          
        }

        public static bool FindPost(PostDetail post)
        {
            using (var connect = GetDatabse())
            {
                var isbookmarked = connect.Find<PostDetail>(item => item.Id == post.Id);
                return isbookmarked != null;
            }

        }
    }
}
