﻿using Clothes_Online_Shop.Models;
using Clothes_Shop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly CategoriesContext _appDbContext;

        public CategoriesRepository(CategoriesContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public void Add(Category category)
        {
            _appDbContext.Add(category);
        }

        public Task<List<Category>> GetAll()
        {
            return _appDbContext.Categories.ToListAsync();
        }

        public Task<List<Category>> GetCategories(Expression<Func<Category, bool>> predicate)
        {
            return _appDbContext.Categories.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    
}
}
