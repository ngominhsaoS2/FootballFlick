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
    public class PlayerDao
    {
        FootballFlickDbContext db = null;

        public PlayerDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get Player when having ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player GetByID(long id)
        {
            return db.Players.Find(id);
        }

        /// <summary>
        /// Get PlayerViewModel when having ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlayerViewModel GetViewModelByID(long id)
        {
            return db.vPlayers.Find(id);
        }

        /// <summary>
        /// Insert one Player to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Player entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            if (entity.UserID == null)
            {
                entity.UserID = 0;
            }
            db.Players.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Player in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Player entity)
        {
            try
            {
                var player = db.Players.Find(entity.ID);
                if (entity.UserID == null)
                {
                    entity.UserID = 0;
                }
                player.UserID = entity.UserID;
                player.Name = entity.Name;
                player.MetaTitle = entity.MetaTitle;
                player.Identification = entity.Identification;
                player.Address = entity.Address;
                player.Email = entity.Email;
                player.Phone = entity.Phone;
                player.Image = entity.Image;
                player.ModifiedDate = DateTime.Now;
                player.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one Player in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var player = db.Players.Find(id);
                db.Players.Remove(player);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List Player into a table with search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<PlayerViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PlayerViewModel> model = db.vPlayers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Identification.Contains(searchString)
                || x.Email.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Get Player list when having a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Player> ListPlayer(string keyword)
        {
            var listPlayer =     (from a in db.Players
                                 where a.Identification.Contains(keyword) || a.Name.Contains(keyword)
                                  select new
                                 {
                                     ID = a.ID,
                                     Name = a.Name,
                                     Identification = a.Identification,
                                     Address = a.Address,
                                     Email = a.Email,
                                     Phone = a.Phone,
                                     Image = a.Image,
                                     CreatedDate = a.CreatedDate,
                                     CreatedBy = a.CreatedBy,
                                     ModifiedDate = a.ModifiedDate,
                                     ModifiedBy = a.ModifiedBy,
                                     Status = a.Status
                                 }).AsEnumerable().Select(x => new Player()
                                 {
                                     ID = x.ID,
                                     Name = x.Name,
                                     Identification = x.Identification,
                                     Address = x.Address,
                                     Email = x.Email,
                                     Phone = x.Phone,
                                     Image = x.Image,
                                     CreatedDate = x.CreatedDate,
                                     CreatedBy = x.CreatedBy,
                                     ModifiedDate = x.ModifiedDate,
                                     ModifiedBy = x.ModifiedBy,
                                     Status = x.Status
                                 });
            return listPlayer.ToList();
        }

        /// <summary>
        /// Check if a Identification of Player already exists or not yet
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckIdentification(string iden)
        {
            int result = db.Players.Count(x => x.Identification == iden);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Rank all Players
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<PlayerViewModel> DisplayListRankedPlayer(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            totalRecord = db.vPlayers.Count();
            IQueryable<PlayerViewModel> model = db.vPlayers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Identification.Contains(searchString)
                || x.Email.Contains(searchString) || x.Phone.Contains(searchString)
                || x.UserName.Contains(searchString) || x.NameOfUser.Contains(searchString)
                || x.UserEmail.Contains(searchString) || x.UserPhone.Contains(searchString));
            }

            return model.OrderByDescending(x => x.TotalPoint).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// List all the Matches that the Player has played
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public List<MatchDetailViewModel> ListPlayedMatches(long playerId, ref int totalRecord, int pageIndex = 1, int pageSize = 9)
        {
            totalRecord = db.vMatchDetails.Count(x => x.PlayerID == playerId);
            var model = db.vMatchDetails.Where(x => x.PlayerID == playerId).OrderByDescending(x => x.MatchID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }










    }
}
