using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myLibrary.Models;
using myApi.Controllers;

namespace MyTests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void GetAllShoppingCarts_ReturnsAllShoppingCarts()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new ShoppingCartController(dbContext);
            var expectedShoppingCarts = dbContext.ShoppingCarts.ToList();
            // Act
            var result = controller.GetAllShoppingCarts();
            // Assert
            Assert.Equal(expectedShoppingCarts, result);
        }
        [Fact]
        public void GetShoppingCartById_ReturnsShoppingCartById()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new ShoppingCartController(dbContext);
            var shoppingCartId = 1;
            var expectedShoppingCart = dbContext.ShoppingCarts.Find(shoppingCartId);
            // Act
            var result = controller.GetShoppingCartById(shoppingCartId);
            // Assert
            Assert.Equal(expectedShoppingCart, result);
        }
        [Fact]
        public void AddShoppingCart_ReturnsShoppingCartAddedSuccessfully()
        {
            // Arrange
            var dbContext = new AppDbContext();
            var controller = new ShoppingCartController(dbContext);
            var shoppingCart = new ShoppingCart();
            // Act
            var result = controller.AddShoppingCart(shoppingCart);
            // Assert
            Assert.Equal("ShoppingCart added successfully", result);
        }
    }
}