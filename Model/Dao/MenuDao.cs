﻿using Model.EntityFramework;
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

        public List<Menu> ListByTypeId(int typeId)
        {
            return db.Menus.Where(x => x.TypeID == typeId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

    }
}
