using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public interface ICartsRepository
    {
        void Add(Cart cart);
        Task Save();
        Task<List<Cart>> GetCarts(Expression<Func<Cart, bool>> predicate);
        Task<List<Cart>> GetAll();
        IEnumerable<Cart> AllCarts { get; }
    }
}
