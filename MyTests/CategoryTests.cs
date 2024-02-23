using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myLibrary.Models;
using myApi.Controllers;

namespace MyTests
{
    public class CategoryTests
    {
        [Fact]
        public void GetAllCategories_ReturnsAllCategories()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new CategoryController(dbContext);
            var expectedCategories = dbContext.Categories.ToList();
            // Act
            var result = controller.GetAllCategories();
            // Assert
            Assert.Equal(expectedCategories, result);
        }
        [Fact]
        public void GetCategoryById_ReturnsCategoryById()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new CategoryController(dbContext);
            var categoryId = 1;
            var expectedCategory = dbContext.Categories.Find(categoryId);
            // Act
            var result = controller.GetCategoryById(categoryId);
            // Assert
            Assert.Equal(expectedCategory, result);
        }
        [Fact]
        public void AddCategory_ReturnsCategoryAddedSuccessfully()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new CategoryController(dbContext);
            var category = new Category();
            // Act
            var result = controller.AddCategory(category);
            // Assert
            Assert.Equal("Category added successfully", result);
        }
    }
}