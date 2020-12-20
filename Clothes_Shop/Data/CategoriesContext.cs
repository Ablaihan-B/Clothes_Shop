using Clothes_Shop.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Category> Category{ get; set; }

        internal Category Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}
