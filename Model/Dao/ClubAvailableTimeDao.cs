using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClubAvailableTimeDao
    {
        FootballFlickDbContext db = null;

        public ClubAvailableTimeDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Insert one ClubAvailableTime to database -  Thêm mới một ClubAvailableTime vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ClubAvailableTime entity)
        {
            try
            {
                entity.Status = true;
                db.ClubAvailableTimes.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one ClubAvailableTime in the database - Xóa một ClubAvailableTime khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long clubId, int stt)
        {
            try
            {
                var clubAvailableTime = db.ClubAvailableTimes.Single(x => x.ClubID == clubId && x.Stt == stt);
                db.ClubAvailableTimes.Remove(clubAvailableTime);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List all AvailableTimes of the Club
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public List<ClubAvailableTimeViewModel> ListClubAvailableTime(long clubId)
        {
            return db.vClubAvailableTimes.Where(x => x.ClubID == clubId && x.Status == true).ToList();
        }

        public bool CheckExistRow(long clubId, string day, TimeSpan startTime, TimeSpan endTime)
        {
            var count = db.ClubAvailableTimes.Where(x => x.ClubID == clubId && x.Day == day && x.StartTime == startTime && x.EndTime == endTime).Count();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }















    }
}
