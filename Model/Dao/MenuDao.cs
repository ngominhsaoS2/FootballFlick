using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        FootballFlickDbContext db = null;

        public MenuDao()
        {
            db = new FootballFlickDbContext();
        }

        public List<Menu> ListMenu(int parentId, int typeId)
        {
            return db.Menus.Where(x => x.ParentID == parentId && x.TypeID == typeId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

    }
}
