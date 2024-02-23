using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string User { get; set; }
        public List<Product> Products { get; set; }
    }
}