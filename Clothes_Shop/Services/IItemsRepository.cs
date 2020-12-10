using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public interface IItemsRepository
    {
        void Add(Item item);
        Task Save();
        Task<List<Item>> GetItems(Expression<Func<Item, bool>> predicate);
        Task<List<Item>> GetAll();
        IEnumerable<Item> AllItems { get; }
    }
}
