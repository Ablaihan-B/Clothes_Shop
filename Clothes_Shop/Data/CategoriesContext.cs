using Clothes_Online_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Data
{
    public class CategoriesContext : DbContext
    {

        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}
