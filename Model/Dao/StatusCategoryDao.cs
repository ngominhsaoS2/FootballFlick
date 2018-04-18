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
        /// Get StatusCategory when having ForTable and Stt
        /// </summary>
        /// <param name="forTable"></param>
        /// <param name="stt"></param>
        /// <returns></returns>
        public StatusCategory GetByStt(string forTable, int stt)
        {
            return db.StatusCategories.SingleOrDefault(x => x.ForTable == forTable && x.Stt == stt);
        }

        /// <summary>
        /// List all StatusCategory when having ForTable, Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<StatusCategory> ListStatus(string forTable, int type)
        {
            return db.StatusCategories.Where(x => x.ForTable == forTable && x.Type == type).OrderBy(x => x.Stt).ToList();
        }


    }
}
