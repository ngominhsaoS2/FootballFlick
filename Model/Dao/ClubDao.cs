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
        public bool Update(Club entity, int typeUpdate)
        {
            try
            {
                if (typeUpdate == 1)
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
                    club.OwnerID = entity.OwnerID;
                    club.MetaKeywords = entity.MetaKeywords;
                    club.MetaDescriptions = entity.MetaDescriptions;
                    club.ModifiedDate = DateTime.Now;
                    club.Status = entity.Status;
                    db.SaveChanges();
                    return true;
                }
                else if (typeUpdate == 2)
                {
                    var club = db.Clubs.Find(entity.ID);
                    club.Code = entity.Code;
                    club.Name = entity.Name;
                    club.Description = entity.Description;
                    club.Phone = entity.Phone;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                    
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
        public IEnumerable<ClubViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ClubViewModel> model = db.vClubs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Code.Contains(searchString) || x.Name.Contains(searchString)
                || x.CaptainName.Contains(searchString) || x.Detail.Contains(searchString) || x.Phone.Contains(searchString));
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

        /// <summary>
        /// Check if a Code of Club already exists or not yet
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode (string code)
        {
            int result = db.Clubs.Count(x => x.Code == code);
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
        /// Get Club list when having a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Club> ListClub(string keyword)
        {
            var listClub =    (from a in db.Clubs
                              where a.Code.Contains(keyword) || a.Name.Contains(keyword)
                              select new
                              {
                                  ID = a.ID,
                                  Code = a.Code,
                                  Name = a.Name,
                                  MetaTitle = a.MetaTitle,
                                  Description = a.Description,
                                  Image = a.Image,
                                  MoreImages = a.MoreImages,
                                  Detail = a.Detail,
                                  CaptainID = a.CaptainID,
                                  Phone = a.Phone,
                                  Address = a.Address,
                                  MetaKeywords = a.MetaKeywords,
                                  MetaDescriptions = a.MetaDescriptions,
                                  CreatedDate = a.CreatedDate,
                                  CreatedBy = a.CreatedBy,
                                  ModifiedDate = a.ModifiedDate,
                                  ModifiedBy = a.ModifiedBy,
                                  Status = a.Status
                              }).AsEnumerable().Select(x => new Club()
                              {
                                  ID = x.ID,
                                  Code = x.Code,
                                  Name = x.Name,
                                  MetaTitle = x.MetaTitle,
                                  Description = x.Description,
                                  Image = x.Image,
                                  MoreImages = x.MoreImages,
                                  Detail = x.Detail,
                                  CaptainID = x.CaptainID,
                                  Phone = x.Phone,
                                  Address = x.Address,
                                  MetaKeywords = x.MetaKeywords,
                                  MetaDescriptions = x.MetaDescriptions,
                                  CreatedDate = x.CreatedDate,
                                  CreatedBy = x.CreatedBy,
                                  ModifiedDate = x.ModifiedDate,
                                  ModifiedBy = x.ModifiedBy,
                                  Status = x.Status
                              });
            return listClub.ToList();
        }

        /// <summary>
        /// List all Clubs when having OwnerID
        /// </summary>
        /// <param name="productCategoryID"></param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Club> ListAllByOwnerID(long ownerID, ref int totalRecord, int pageIndex = 1, int pageSize = 9)
        {
            totalRecord = db.Clubs.Count(x => x.OwnerID == ownerID && x.Status == true);
            var model = db.Clubs.Where(x => x.OwnerID == ownerID && x.Status == true).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }














    }
}
