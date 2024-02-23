using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MyLibrary.Models;
using System.Linq;
using System;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
    // Endpoints implementation
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _dbContext.Products.ToList();
        return Ok(products);
    }

    [HttpGet("{categoryId}")]
    public IActionResult GetProductsByCategory(int categoryId)
    {
        // Implement logic to get products by category
        // For example, you can query the database to retrieve products with the specified categoryId
        var products = _dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();

        return Ok(products);
    }


    [HttpPost]
    public IActionResult AddProduct([FromBody] Product product)
    {
        // Implement logic to add a product to the database
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();

        return Ok("Product added successfully");

    }

}