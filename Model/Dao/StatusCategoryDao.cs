using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class StatusCategoryDao
    {
        FootballFlickDbContext db = null;

        public StatusCategoryDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get StatusCategory when having ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StatusCategory GetByID(long id)
        {
            return db.StatusCategories.Find(id);
        }

        /// <summary>
        /// List all StatusCategory when having ForTable, Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<StatusCategory> ListStatus(string forTable, int type)
        {
            return db.StatusCategories.Where(x => x.ForTable == forTable && x.Type == type).OrderBy(x => x.ID).ToList();
        }


    }
}
