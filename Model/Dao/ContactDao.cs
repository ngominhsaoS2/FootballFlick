using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        FootballFlickDbContext db = null;

        public ContactDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get one active content int Contact table
        /// </summary>
        /// <returns></returns>
        public Contact GetActiveContent()
        {
            return db.Contacts.SingleOrDefault(x => x.Status == true);
        }







    }
}
