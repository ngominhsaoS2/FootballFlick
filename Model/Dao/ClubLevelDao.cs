using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClubLevelDao
    {
        FootballFlickDbContext db = null;

        public ClubLevelDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get the LevelID of the Club before a date
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public ClubLevel GetBeforeDate(long clubId, DateTime date)
        {
            var list = db.ClubLevels.Where(x => x.ClubID == clubId && x.Date <= date).OrderByDescending(x=>x.Date).Take(1);
            return list.FirstOrDefault();
        }

        /// <summary>
        /// Insert a ClubLevel to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert (ClubLevel entity)
        {
            try
            {
                db.ClubLevels.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }




    }
}
