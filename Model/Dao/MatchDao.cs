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
    public class MatchDao
    {
        FootballFlickDbContext db = null;

        public MatchDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get Match when having ID - Lấy ra Match khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Match GetByID(long id)
        {
            return db.Matches.Find(id);
        }

        /// <summary>
        /// Get MatchViewModel when having ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MatchViewModel GetViewModelByID(long id)
        {
            return db.vMatches.Find(id);
        }

        /// <summary>
        /// Insert one Match to database -  Thêm mới một Match vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(Match entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = 1;
            db.Matches.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one Match in the database -  Cập nhật một Match trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Match entity)
        {
            try
            {
                var match = db.Matches.Find(entity.ID);
                match.Code = entity.Code;
                match.Name = entity.Name;
                match.MetaTitle = entity.MetaTitle;
                match.Description = entity.Description;
                match.Image = entity.Image;
                match.HomeClubID = entity.HomeClubID;
                match.VisitingClubID = entity.VisitingClubID;
                match.StadiumID = entity.StadiumID;
                match.Date = entity.Date;
                match.ExpectedStartTime = entity.ExpectedStartTime;
                match.ExpectedEndTime = entity.ExpectedEndTime;
                match.HoldAddress = entity.HoldAddress;
                match.Price = entity.Price;
                match.PromotionPrice = entity.PromotionPrice;
                match.ExpiredDateToSign = entity.ExpiredDateToSign;
                match.Detail = entity.Detail;
                match.RealStartTime = entity.RealStartTime;
                match.RealEndTime = entity.RealEndTime;
                match.HomeClubGoal = entity.HomeClubGoal;
                match.VisitingClubGoal = entity.VisitingClubGoal;
                match.MetaKeywords = entity.MetaKeywords;
                match.MetaDescriptions = entity.MetaDescriptions;
                match.ModifiedDate = DateTime.Now;
                match.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one Match in the database - Xóa một Match khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var match = db.Matches.Find(id);
                db.Matches.Remove(match);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List Match into a table with search string - Liệt kê danh sách Match có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<MatchViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<MatchViewModel> model = db.vMatches;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Code.Contains(searchString) || x.HomeClubCode.Contains(searchString)
                || x.VisitingClubCode.Contains(searchString) || x.StadiumCode.Contains(searchString)
                || x.StadiumName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }


        /// <summary>
        /// List all MatchViewModel
        /// </summary>
        /// <param name="productCategoryID"></param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<MatchViewModel> ListAll(ref int totalRecord, int pageIndex = 1, int pageSize = 9)
        {
            totalRecord = db.vMatches.Count();
            var model = db.vMatches.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        /// <summary>
        /// List top recetn matches
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<MatchViewModel> ListRecentMatch(int top)
        {
            return db.vMatches.OrderByDescending(x => x.ID).Take(top).ToList();
        }






    }
}
