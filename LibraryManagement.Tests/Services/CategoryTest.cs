using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Service.Concrete;
using LibraryManagement.Service.Models;

namespace LibraryManagement.Tests.Services
{
    [TestClass]
    public class CategoryTest
    {
        CategoryService categoryService = null;

        public CategoryTest()
        {
            categoryService = new CategoryService();
        }



        [TestMethod]
        public void SaveCategoryTest()
        {
            //Arrange
            CategoryModel category = new CategoryModel()
            {
                CategoryID = 0,
                CategoryName = "Suspense"
            };

            //Act
            var result = categoryService.SaveCategory(category);
            //Assert
            Assert.AreNotEqual(0, result);
        }
    }
}
