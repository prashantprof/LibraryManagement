using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    interface ICategoryRepository
    {
        Category GetCategoryById(int id);

        List<Category> GetCategories();

        int AddCategory(Category newCategory);

        bool UpdateCategory(Category category);

        bool DeleteCategory(int id);

    }
}
