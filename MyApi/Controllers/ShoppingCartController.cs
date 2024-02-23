using system;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ShoppingCartController : ControllerBase
{
    private readonly ILogger<ShoppingCartController> _logger;
    private readonly AppDbContext _context;

    public ShoppingCartController(ILogger<ShoppingCartController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetShoppingCart")]
    public IEnumerable<ShoppingCart> Get()
    {
        return _context.ShoppingCarts.ToArray();
    }

    [HttpGet("{id}", Name = "GetShoppingCartById")]
    public ActionResult<ShoppingCart> GetById(int id)
    {
        var cart = _context.ShoppingCarts.Find(id);
        if (cart == null)
        {
            return NotFound();
        }
        return cart;
    }

    [HttpPost(Name = "CreateShoppingCart")]
    public ActionResult<ShoppingCart> Create(ShoppingCart cart)
    {
        _context.ShoppingCarts.Add(cart);
        _context.SaveChanges();
        return CreatedAtRoute("GetShoppingCartById", new { id = cart.Id }, cart);
    }

    [HttpPut("{id}", Name = "UpdateShoppingCart")]
    public IActionResult Update(int id, ShoppingCart cart)
    {
        if (id != cart.Id)
        {
            return BadRequest();
        }
        _context.Entry(cart).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteShoppingCart")]
    public IActionResult Delete(int id)
    {
        var cart = _context.ShoppingCarts.Find(id);
        if (cart == null)
        {
            return NotFound();
        }
        _context.ShoppingCarts.Remove(cart);
        _context.SaveChanges();
        return NoContent();
    }
}