using Model.EntityFramework;
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
        /// Get Player when having ID - Lấy ra Player khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player GetByID(long id)
        {
            return db.Players.Find(id);
        }

        /// <summary>
        /// Insert one Player to database -  Thêm mới một Player vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Player entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.Players.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Player in the database -  Cập nhật một Player trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Player entity)
        {
            try
            {
                var player = db.Players.Find(entity.ID);
                player.Name = entity.Name;
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
        /// Delete one Player in the database - Xóa một Player khỏi cơ sở dữ liệu
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
        /// List Player into a table with search string - Liệt kê danh sách Player có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Player> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Player> model = db.Players;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Identification.Contains(searchString)
                || x.Email.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }





    }
}
