using Clothes_Online_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Data
{
    public class CartContext : DbContext
    {

        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }

    }
}
