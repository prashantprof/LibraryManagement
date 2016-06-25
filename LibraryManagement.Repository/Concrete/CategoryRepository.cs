using LibraryManagement.Repository.Abstract;
using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        LibraryManagementEntities db = null;

        public CategoryRepository()
        {
            db = new LibraryManagementEntities();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Where(x => x.CategoryID.Equals(id)).FirstOrDefault();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public int AddCategory(Category newCategory)
        {
            db.Categories.Add(newCategory);
            db.SaveChanges();
            return newCategory.CategoryID;
        }

        public bool UpdateCategory(Category category)
        {
            var existingCategory = db.Categories.Where(x => x.CategoryID.Equals(category.CategoryID)).FirstOrDefault();
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                db.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public bool DeleteCategory(int id)
        {
            var existingCategory = db.Categories.Where(x => x.CategoryID.Equals(id)).FirstOrDefault();
            if (existingCategory != null)
            {
                db.Categories.Remove(existingCategory);
                return true;
            }
            else
                return false;
        }


    }
}
