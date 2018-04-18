using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClubStadiumDao
    {
        FootballFlickDbContext db = null;

        public ClubStadiumDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Insert one ClubStadium to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ClubStadium entity)
        {
            try
            {
                entity.Status = true;
                db.ClubStadiums.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Update one ClubStadium in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ClubStadium entity)
        {
            try
            {
                var clubStadium = db.ClubStadiums.Single(x => x.ClubID == entity.ClubID && x.StadiumID == entity.StadiumID);
                clubStadium.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one ClubStadium in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long clubId, long stadiumId)
        {
            try
            {
                var clubStadium = db.ClubStadiums.Single(x => x.ClubID == clubId && x.StadiumID == stadiumId);
                db.ClubStadiums.Remove(clubStadium);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List all Stadiums of the Club
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public List<ClubStadiumViewModel> ListClubStadium(long clubId)
        {
            return db.vClubStadiums.Where(x => x.ClubID == clubId && x.Status == true).ToList();
        }

        /// <summary>
        /// Check if a ClubStadium row already exists of not yet
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="stadiumId"></param>
        /// <returns></returns>
        public bool CheckExistRow(long clubId, long stadiumId)
        {
            var count = db.ClubStadiums.Where(x => x.ClubID == clubId && x.StadiumID == stadiumId).Count();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }





    }
}
