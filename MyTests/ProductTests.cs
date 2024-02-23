using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myLibrary.Models;
using myApi.Controllers;


namespace MyTests
{
    public class ProductTests
    {
        [Fact]
        public void GetAllProducts_ReturnsAllProducts()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new ProductController(dbContext);
            var expectedProducts = dbContext.Products.ToList();
            // Act
            var result = controller.GetAllProducts();
            // Assert
            Assert.Equal(expectedProducts, result);
        }
        [Fact]
        public void GetProductsByCategory_ReturnsProductsByCategory()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new ProductController(dbContext);
            var categoryId = 1;
            var expectedProducts = dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
            // Act
            var result = controller.GetProductsByCategory(categoryId);
            // Assert
            Assert.Equal(expectedProducts, result);
        }
        [Fact]
        public void AddProduct_ReturnsProductAddedSuccessfully()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new ProductController(dbContext);
            var product = new Product();
            // Act
            var result = controller.AddProduct(product);
            // Assert
            Assert.Equal("Product added successfully", result);
        }
    }
}
```