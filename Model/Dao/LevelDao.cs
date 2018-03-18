using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LevelDao
    {
        FootballFlickDbContext db = null;

        public LevelDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get Level when having ID - Lấy ra Level khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Level GetByID(long id)
        {
            return db.Levels.Find(id);
        }

        /// <summary>
        /// Insert one Level to database -  Thêm mới một Level vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Level entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.Levels.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Level in the database -  Cập nhật một Level trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Level entity)
        {
            try
            {
                var level = db.Levels.Find(entity.ID);
                level.Code = entity.Code;
                level.Name = entity.Name;
                level.ModifiedDate = DateTime.Now;
                level.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one Level in the database - Xóa một Level khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var level = db.Levels.Find(id);
                db.Levels.Remove(level);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List Level into a table with search string - Liệt kê danh sách Level có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Level> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Level> model = db.Levels;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Code.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }









    }
}
