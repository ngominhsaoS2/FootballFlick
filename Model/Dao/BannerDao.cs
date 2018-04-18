using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BannerDao
    {
        FootballFlickDbContext db = null;

        public BannerDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get Banner when having ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Banner GetByID(long id)
        {
            return db.Banners.Find(id);
        }

        /// <summary>
        /// Insert one Banner to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Banner entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.Banners.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Banner in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Banner entity)
        {
            try
            {
                var banner = db.Banners.Find(entity.ID);
                banner.Name = entity.Name;
                banner.Image = entity.Image;
                banner.Description = entity.Description;
                banner.ModifiedDate = DateTime.Now;
                banner.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one Banner in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var banner = db.Banners.Find(id);
                db.Banners.Remove(banner);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List Banner into a table with search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Banner> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Banner> model = db.Banners;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }


        /// <summary>
        /// Get the newest Banner
        /// </summary>
        /// <returns></returns>
        public Banner GetNewestBanner()
        {
            return db.Banners.OrderByDescending(x=>x.CreatedDate).FirstOrDefault(x => x.Status == true);
        }




    }
}
