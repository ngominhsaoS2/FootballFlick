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
    public class ClubPointDao
    {
        FootballFlickDbContext db = null;

        public ClubPointDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get one ClubPoint row in the database when having MatchID and ClubID
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public ClubPointViewModel GetRow(long matchId, long clubId)
        {
            return db.vClubPoints.Single(x => x.MatchID == matchId && x.ClubID == matchId);
        }

        /// <summary>
        /// Insert one ClubPoint to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ClubPoint entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.ClubPoints.Add(entity);
            db.SaveChanges();
            return true;
            
        }

        /// <summary>
        /// Check if a row already exists or not
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public bool CheckExist (long matchId, long clubId)
        {
            var count = db.ClubPoints.Count(x => x.MatchID == matchId && x.ClubID == clubId);
            if(count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Update a ClubPoint row
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ClubPoint entity)
        {
            try
            {
                var clubPoint = db.ClubPoints.Find(entity.MatchID, entity.ClubID);
                clubPoint.JoinPoint = entity.JoinPoint;
                clubPoint.WinPoint = entity.WinPoint;
                clubPoint.DrawPoint = entity.DrawPoint;
                clubPoint.GoalPoint = entity.GoalPoint;
                clubPoint.RivalLevelID = entity.RivalLevelID;
                clubPoint.ModifiedDate = DateTime.Now;
                clubPoint.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List ClubPoint into a table with search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<ClubPointViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ClubPointViewModel> model = db.vClubPoints;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MatchCode.Contains(searchString) || x.ClubCode.Contains(searchString)
                || x.ClubName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MatchID).ToPagedList(page, pageSize);
        }








    }
}
