﻿using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserGroupDao
    {
        FootballFlickDbContext db = null;

        public UserGroupDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// List all UserGroup
        /// </summary>
        /// <returns></returns>
        public List<UserGroup> ListAll()
        {
            return db.UserGroups.ToList();
        }












    }
}
