﻿using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        FootballFlickDbContext db = null;

        public ProductCategoryDao()
        {
            db = new FootballFlickDbContext();
        }

        /// <summary>
        /// Get ProductCategory when having ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductCategory GetByID(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public List<ProductCategory> ListAll(int? top = null)
        {
            if(top != null)
            {
                return db.ProductCategories.Where(x => x.Status == true && x.ShowInHome==true).OrderByDescending(x => x.CreatedDate).Take((int)top).ToList();
            }
            else
            {
                return db.ProductCategories.Where(x => x.Status == true && x.ShowInHome == true).ToList();
            }
            
        }

        /// <summary>
        /// Insert one ProductCategory to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(ProductCategory entity)
        {
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
            entity.Status = true;
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// Update one ProductCategory in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ProductCategory entity)
        {
            try
            {
                var productCategory = db.ProductCategories.Find(entity.ID);
                productCategory.Name = entity.Name;
                productCategory.MetaTitle = entity.MetaTitle;
                productCategory.ParentID = entity.ParentID;
                productCategory.DisplayOrder = entity.DisplayOrder;
                productCategory.Image = entity.Image;
                productCategory.SeoTitle = entity.SeoTitle;
                productCategory.MetaKeywords = entity.MetaKeywords;
                productCategory.MetaDescriptions = entity.MetaDescriptions;
                productCategory.ShowInHome = entity.ShowInHome;
                productCategory.ModifiedDate = DateTime.Now;
                productCategory.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete one ProductCategory in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var productCategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productCategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// List ProductCategory into a table with search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }














    }
}
