﻿using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Abstract
{
    public interface ICategoryService
    {
        CategoryModel GetCategoryById(int id);
        List<CategoryModel> GetAllCategories();

        int SaveCategory(CategoryModel category);

        bool DeleteCategory(int id);
    }
}
