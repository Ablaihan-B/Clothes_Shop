using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clothes_Online_Shop.Models;

namespace Clothes_Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Clothes_Online_Shop.Models.Cart> Cart { get; set; }
        public DbSet<Clothes_Online_Shop.Models.Category> Category { get; set; }
        public DbSet<Clothes_Online_Shop.Models.Comments> Comments { get; set; }
        public DbSet<Clothes_Online_Shop.Models.Features> Features { get; set; }
        public DbSet<Clothes_Online_Shop.Models.Gender> Gender { get; set; }
        public DbSet<Clothes_Online_Shop.Models.Item> Item { get; set; }
    }
}
