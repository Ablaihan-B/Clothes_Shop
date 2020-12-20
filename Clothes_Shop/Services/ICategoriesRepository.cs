using Clothes_Shop.Models;
using Clothes_Shop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public interface ICategoriesRepository
    {
        void Add(Category category);
        Task Save();

        Category GetOneById(string id);
        Task<List<Category>> GetCategories(Expression<Func<Category, bool>> predicate);
        Task<List<Category>> GetAll();
        IEnumerable<Category> AllCategories { get; }
    }
}
