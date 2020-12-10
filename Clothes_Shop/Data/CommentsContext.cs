using Clothes_Online_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Data
{
    public class CommentsContext : DbContext
    {

        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {
        }

        public DbSet<Comments> Comments { get; set; }
    }
}
