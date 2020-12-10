using Clothes_Online_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Data
{
    public class GendersContext : DbContext
    {

        public GendersContext(DbContextOptions<GendersContext> options) : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }
    }
}
