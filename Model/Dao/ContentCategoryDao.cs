using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentCategoryDao
    {
        FootballFlickDbContext db = null;

        public ContentCategoryDao()
        {
            db = new FootballFlickDbContext();
        }

        public List<ContentCategory> ListAll()
        {
            return db.ContentCategories.Where(x => x.Status == true).ToList();
        }


    }
}
