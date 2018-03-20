using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class StadiumDao
    {
        FootballFlickDbContext db = null;

        public StadiumDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get Stadium when having ID - Lấy ra Stadium khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stadium GetByID(long id)
        {
            return db.Stadiums.Find(id);
        }

        /// <summary>
        /// Insert one Stadium to database -  Thêm mới một Stadium vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Stadium entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.Stadiums.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Stadium in the database -  Cập nhật một Stadium trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Stadium entity)
        {
            try
            {
                var stadium = db.Stadiums.Find(entity.ID);
                stadium.Name = entity.Name;
                stadium.Address = entity.Address;
                stadium.Email = entity.Email;
                stadium.Phone = entity.Phone;
                stadium.Image = entity.Image;
                stadium.ModifiedDate = DateTime.Now;
                stadium.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one Stadium in the database - Xóa một Stadium khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var stadium = db.Stadiums.Find(id);
                db.Stadiums.Remove(stadium);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List Stadium into a table with search string - Liệt kê danh sách Stadium có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Stadium> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Stadium> model = db.Stadiums;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Address.Contains(searchString)
                || x.Email.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Update MoreImages
        /// </summary>
        /// <param name="stadiumId"></param>
        /// <param name="images"></param>
        public void UpdateImages(long stadiumId, string images)
        {
            var stadium = db.Stadiums.Find(stadiumId);
            stadium.MoreImages = images;
            db.SaveChanges();
        }

        /// <summary>
        /// Get Stadium list when having a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Stadium> ListStadium(string keyword)
        {
            var listStadium = (from a in db.Stadiums
                               where a.Code.Contains(keyword) || a.Name.Contains(keyword)
                              select new
                              {
                                  ID = a.ID,
                                  Code = a.Code,
                                  Name = a.Name,
                                  Address = a.Address,
                                  Email = a.Email,
                                  Phone = a.Phone,
                                  Image = a.Image,
                                  Description = a.Description,
                                  Detail = a.Detail,
                                  CreatedDate = a.CreatedDate,
                                  CreatedBy = a.CreatedBy,
                                  ModifiedDate = a.ModifiedDate,
                                  ModifiedBy = a.ModifiedBy,
                                  Status = a.Status
                              }).AsEnumerable().Select(x => new Stadium()
                              {
                                  ID = x.ID,
                                  Code = x.Code,
                                  Name = x.Name,
                                  Address = x.Address,
                                  Email = x.Email,
                                  Phone = x.Phone,
                                  Image = x.Image,
                                  Description = x.Description,
                                  Detail = x.Detail,
                                  CreatedDate = x.CreatedDate,
                                  CreatedBy = x.CreatedBy,
                                  ModifiedDate = x.ModifiedDate,
                                  ModifiedBy = x.ModifiedBy,
                                  Status = x.Status
                              });
            return listStadium.ToList();
        }









    }
}
