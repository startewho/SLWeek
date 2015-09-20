using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteWinRT;
using SLWeek.Utils;
namespace SLWeek.Database
{
    public class BookmarkDatabase : IDatabase
    {
        private static readonly string DbPath = AppStrings.BookmarkDbName;



        public void Drop()
        {
            
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
