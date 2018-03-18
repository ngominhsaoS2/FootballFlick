using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentCategoryDao
    {
        FootballFlickDbContext db = null;

        public ContentCategoryDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get ContentCategory when having ID - Lấy ra ContentCategory khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContentCategory GetByID(long id)
        {
            return db.ContentCategories.Find(id);
        }

        /// <summary>
        /// Insert one ContentCategory to database -  Thêm mới một ContentCategory vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(ContentCategory entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.ContentCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one ContentCategory in the database -  Cập nhật một ContentCategory trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ContentCategory entity)
        {
            try
            {
                var contentCategory = db.ContentCategories.Find(entity.ID);
                contentCategory.Name = entity.Name;
                contentCategory.MetaTitle = entity.MetaTitle;
                contentCategory.ParentID = entity.ParentID;
                contentCategory.DisplayOrder = entity.DisplayOrder;
                contentCategory.SeoTitle = entity.SeoTitle;
                contentCategory.Language = entity.Language;
                contentCategory.MetaKeywords = entity.MetaKeywords;
                contentCategory.MetaDescriptions = entity.MetaDescriptions;
                contentCategory.ShowInHome = entity.ShowInHome;
                contentCategory.ModifiedDate = DateTime.Now;
                contentCategory.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one ContentCategory in the database - Xóa một ContentCategory khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var contentCategory = db.ContentCategories.Find(id);
                db.ContentCategories.Remove(contentCategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List all active ContentCategory
        /// </summary>
        /// <returns></returns>
        public List<ContentCategory> ListAll()
        {
            return db.ContentCategories.Where(x => x.Status == true).ToList();
        }

        /// <summary>
        /// List ContentCategory into a table with search string - Liệt kê danh sách ContentCategory có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<ContentCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ContentCategory> model = db.ContentCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }






    }
}
