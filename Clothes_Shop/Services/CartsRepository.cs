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
    public class CartsRepository : ICartsRepository
    {
        private readonly CartContext _appDbContext;

        public CartsRepository(CartContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

     

        public void Add(Cart cart)
        {
            _appDbContext.Add(cart);
        }

        public Task<List<Cart>> GetAll()
        {
            return _appDbContext.Carts.ToListAsync();
        }

        public Task<List<Cart>> GetCarts(Expression<Func<Cart, bool>> predicate)
        {
            return _appDbContext.Carts.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _appDbContext.SaveChangesAsync();
        }
        public IEnumerable<Cart> AllCarts => _appDbContext.Carts;
    }
}
