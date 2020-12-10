using Clothes_Online_Shop.Models;
using Clothes_Shop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class ItemsRepository : IItemsRepository
    {

        private readonly ItemsContext _appDbContext;

        public ItemsRepository(ItemsContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public void Add(Item item)
        {
            _appDbContext.Add(item);
        }

        public Task<List<Item>> GetAll()
        {
            return _appDbContext.Items.ToListAsync();
        }

        public Task<List<Item>> GetItems(Expression<Func<Item, bool>> predicate)
        {
            return _appDbContext.Items.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _appDbContext.SaveChangesAsync();
        }
        public IEnumerable<Item> AllItems => _appDbContext.Items;
    }
}
