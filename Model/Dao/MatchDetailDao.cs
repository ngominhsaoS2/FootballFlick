using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MatchDetailDao
    {
        FootballFlickDbContext db = null;

        public MatchDetailDao()
        {
            db = new FootballFlickDbContext();
        }

        public List<MatchDetail> ListMatchDetail (string matchCode)
        {
            return db.MatchDetails.Where(x => x.MatchCode == matchCode).ToList();
        }

        public bool Delete (string matchCode)
        {
            try
            {
                var list = db.MatchDetails.Where(x => x.MatchCode == matchCode).ToList();
                db.MatchDetails.RemoveRange(list);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }














    }
}
