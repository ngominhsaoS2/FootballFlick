using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClubDao
    {
        FootballFlickDbContext db = null;

        public ClubDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get Club when having ID - Lấy ra Club khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Club GetByID(long id)
        {
            return db.Clubs.Find(id);
        }

        /// <summary>
        /// Insert one Club to database -  Thêm mới một Club vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Club entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.Clubs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Club in the database -  Cập nhật một Club trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Club entity)
        {
            try
            {
                var club = db.Clubs.Find(entity.ID);
                club.Code = entity.Code;
                club.Name = entity.Name;
                club.MetaTitle = entity.MetaTitle;
                club.Description = entity.Description;
                club.Image = entity.Image;
                club.MoreImages = entity.MoreImages;
                club.Detail = entity.Detail;
                club.CaptainID = entity.CaptainID;
                club.Phone = entity.Phone;
                club.Address = entity.Address;
                club.Detail = entity.Detail;
                club.MetaKeywords = entity.MetaKeywords;
                club.MetaDescriptions = entity.MetaDescriptions;
                club.ModifiedDate = DateTime.Now;
                club.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one Club in the database - Xóa một Club khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var club = db.Clubs.Find(id);
                db.Clubs.Remove(club);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List Club into a table with search string - Liệt kê danh sách Club có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Club> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Club> model = db.Clubs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Code.Contains(searchString) || x.Name.Contains(searchString)
                || x.Description.Contains(searchString) || x.Detail.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Update MoreImages
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="images"></param>
        public void UpdateImages(long clubId, string images)
        {
            var club = db.Clubs.Find(clubId);
            club.MoreImages = images;
            db.SaveChanges();
        }






    }
}
