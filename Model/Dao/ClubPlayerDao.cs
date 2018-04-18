using Model.EntityFramework;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClubPlayerDao
    {
        FootballFlickDbContext db = null;

        public ClubPlayerDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Insert one ClubPlayer to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ClubPlayer entity)
        {
            try
            {
                entity.Status = true;
                db.ClubPlayers.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Update one ClubPlayer in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ClubPlayer entity)
        {
            try
            {
                var clubPlayer = db.ClubPlayers.Single(x => x.ClubID == entity.ClubID && x.PlayerID == entity.PlayerID);
                clubPlayer.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one ClubPlayer in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long clubId, int playerId)
        {
            try
            {
                var clubPlayer = db.ClubPlayers.Single(x => x.ClubID == clubId && x.PlayerID == playerId);
                db.ClubPlayers.Remove(clubPlayer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List all Players of the Club
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public List<ClubPlayerViewModel> ListClubPlayer (long clubId)
        {
            return db.vClubPlayers.Where(x => x.ClubID == clubId && x.Status == true).ToList();
        }

        /// <summary>
        /// List all Players of the Club with page list in client side
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public List<ClubPlayerViewModel> ListClubPlayerPageList(long clubId, ref int totalRecord, int pageIndex = 1, int pageSize = 9)
        {
            totalRecord = db.vClubPlayers.Count(x => x.ClubID == clubId && x.Status == true);
            var model = db.vClubPlayers.Where(x => x.ClubID == clubId && x.Status == true).OrderBy(x => x.PlayerID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        /// <summary>
        /// Check if a row (with ClubId and Stt to find an exact row)
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="stt"></param>
        /// <returns></returns>
        public bool CheckExistRow(long clubId, long playerId)
        {
            var count = db.ClubPlayers.Where(x => x.ClubID == clubId && x.PlayerID == playerId).Count();
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
