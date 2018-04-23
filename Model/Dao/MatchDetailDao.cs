using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MatchDetailDao
    {
        FootballFlickDbContext db = null;

        public MatchDetailDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// List all MatchDetail when having MatchID
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public List<MatchDetail> ListMatchDetail(long matchId)
        {
            return db.MatchDetails.Where(x => x.MatchID == matchId).ToList();
        }

        /// <summary>
        /// List all MatchDetailViewModel when having MatchID
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public List<MatchDetailViewModel> ListMatchDetailViewModel (long? clubId,long matchId)
        {
            IQueryable<MatchDetailViewModel> listDetail = db.vMatchDetails;
            listDetail = listDetail.Where(x => x.MatchID == matchId);
            if(clubId != null)
            {
                listDetail = listDetail.Where(x => x.ClubID == clubId);
            }
            return listDetail.OrderBy(x => x.PlayerID).ToList();


        }

        /// <summary>
        /// Insert one MatchDetail to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(MatchDetail entity)
        {
            try
            {
                entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
                entity.Status = true;
                db.MatchDetails.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Delete one MatchDetail row in database
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="clubId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public bool Delete (long matchId, long clubId, long playerId)
        {
            try
            {
                var detail = db.MatchDetails.Single(x => x.MatchID == matchId && x.ClubID == clubId && x.PlayerID == playerId);
                db.MatchDetails.Remove(detail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete all MatchDetail of a Match
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public bool DeleteAll(long matchId)
        {
            try
            {
                var list = db.MatchDetails.Where(x => x.MatchID == matchId).ToList();
                db.MatchDetails.RemoveRange(list);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if a MatchDetail already exists or not
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="stt"></param>
        /// <returns></returns>
        public bool CheckExistRow(long matchId, long clubId, long playerId)
        {
            var count = db.MatchDetails.Where(x => x.MatchID == matchId && x.ClubID == clubId && x.PlayerID == playerId).Count();
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
