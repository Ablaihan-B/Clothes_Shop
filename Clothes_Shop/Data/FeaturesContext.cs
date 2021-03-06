﻿using Clothes_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Data
{
    public class FeaturesContext : DbContext
    {
        public FeaturesContext(DbContextOptions<FeaturesContext> options) : base(options)
        {
        }

        public DbSet<Features> Features { get; set; }
    }
}
