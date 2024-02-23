using System;
using System.Collections.Generic;

namespace MyLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
        public Category Category { get; set; } // Navigation property
    }
}