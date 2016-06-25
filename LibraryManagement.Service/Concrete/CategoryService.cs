using LibraryManagement.Repository.Concrete;
using LibraryManagement.Repository.DatabaseEntities;
using LibraryManagement.Service.Abstract;
using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        CategoryRepository categoryRepository = null;
        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public List<CategoryModel> GetAllCategories()
        {
            try
            {
                List<CategoryModel> modelList = null;
                var categories = categoryRepository.GetCategories();
                if (categories != null && categories.Any())
                {
                    modelList = categories.Select(cat => new CategoryModel()
                    {
                        CategoryID = cat.CategoryID,
                        CategoryName = cat.CategoryName
                    }).ToList();
                }
                return modelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveCategory(CategoryModel category)
        {
            try
            {
                if (category != null)
                {
                    if (category.CategoryID > 0)
                    {
                        var extCategory = categoryRepository.GetCategoryById(category.CategoryID);
                        if (extCategory != null)
                        {
                            extCategory.CategoryName = category.CategoryName;
                            categoryRepository.UpdateCategory(extCategory);
                            return extCategory.CategoryID;
                        }
                    }
                    else
                    {
                        Category newCategory = new Category()
                        {
                            CategoryName = category.CategoryName
                        };
                        return categoryRepository.AddCategory(newCategory);
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
