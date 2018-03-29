using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common;

namespace Model.Dao
{
    public class UserDao
    {
        FootballFlickDbContext db = null;

        public UserDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get User when having ID - Lấy ra User khi có ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetByID(long id)
        {
            return db.Users.Find(id);
        }

        /// <summary>
        /// Get User when having UserName - Lấy ra User khi có UserName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        /// <summary>
        /// Insert one User to database -  Thêm mới một User vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(User entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one User in the database -  Cập nhật một User trong cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.UserName = entity.UserName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.GroupID = entity.GroupID;
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedDate = DateTime.Now;
                user.Image = entity.Image;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one User in the database - Xóa một User khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List User into a table with search string - Liệt kê danh sách User có thể sử dụng tìm kiếm search
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)
                || x.Email.Contains(searchString) || x.Address.Contains(searchString) || x.Phone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Login method, used for AdminLogin and MemberLogin and ModeLogin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="isLoginAdmin"></param>
        /// <returns></returns>
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            var isLoginAdmin = false;
            if (result.GroupID == CommonConstants.MEMBER_GROUP)
            {
                isLoginAdmin = false;
            }
            else
            {
                isLoginAdmin = true;
            }

            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        /// <summary>
        /// Check if UserName exists or not
        /// </summary>
        /// <returns></returns>
        public bool CheckUserName(string userName)
        {
            var result = db.Users.Count(x => x.UserName == userName);
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
        /// Check if Emai exists or not
        /// </summary>
        /// <returns></returns>
        public bool CheckEmail(string email)
        {
            var result = db.Users.Count(x => x.Email == email);
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
        /// Get list Permission one User has
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<string> GetListPermission(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Permissions
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Permission()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });

            return data.Select(x => x.RoleID).ToList();
        }

        /// <summary>
        /// Get User list when having a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<User> ListUser(string keyword)
        {
            var listUser = (from a in db.Users
                            where a.UserName.Contains(keyword) || a.Name.Contains(keyword) || a.Phone.Contains(keyword) || a.Email.Contains(keyword)
                            select new
                              {
                                  ID = a.ID,
                                  UserName = a.UserName,
                                  GroupID = a.GroupID,
                                  Name = a.Name,
                                  Address = a.Address,
                                  Email = a.Email,
                                  Phone = a.Phone,
                                  Image = a.Image,
                                  CreatedDate = a.CreatedDate,
                                  CreatedBy = a.CreatedBy,
                                  ModifiedDate = a.ModifiedDate,
                                  ModifiedBy = a.ModifiedBy,
                                  Status = a.Status
                              }).AsEnumerable().Select(x => new User()
                              {
                                  ID = x.ID,
                                  UserName = x.UserName,
                                  GroupID = x.GroupID,
                                  Name = x.Name,
                                  Address = x.Address,
                                  Email = x.Email,
                                  Phone = x.Phone,
                                  Image = x.Image,
                                  CreatedDate = x.CreatedDate,
                                  CreatedBy = x.CreatedBy,
                                  ModifiedDate = x.ModifiedDate,
                                  ModifiedBy = x.ModifiedBy,
                                  Status = x.Status
                              });
            return listUser.ToList();
        }














    }
}
