using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SLWeek.Utils;
using JetBrains.Annotations;
using SQLite.Net.Platform.WinRT;
using SLWeek.Models;
using System.IO;
using Windows.Storage;

namespace SLWeek.Database
{
    public  class BookmarkDatabase 
    {
        private static readonly string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, AppStrings.BookmarkDbName);

        public static SQLiteConnection Connection;

        public BookmarkDatabase()
        {
            Connection = new SQLiteConnection(new SQLitePlatformWinRT(), DbPath);
            // 创建 Person 模型对应的表，如果已存在，则忽略该操作。
            Connection.CreateTable<PostDetail>();
                    
        }
       
        public  SQLiteConnection GetDatabse()
        {
            return Connection;
        }

        public static PostDetail QueryPost(int id)
        {
            return (from t in Connection.Table<PostDetail>()
                where t.Id == id
                select t).FirstOrDefault();

        }

       

    }
}
