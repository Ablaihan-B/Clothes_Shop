using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class CartsService
    {
        private readonly ICartsRepository _cartRepo;

        public CartsService(ICartsRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public async Task<List<Cart>> GetCarts()
        {
            return await _cartRepo.GetAll();
        }

        public async Task AddAndSave(Cart cart)
        {
            _cartRepo.Add(cart);
            await _cartRepo.Save();
        }

        public async Task<List<Cart>> Search(string text)
        {
            text = text.ToLower();
            var searchedCarts = await _cartRepo.GetCarts(cart => cart.Id.ToLower().Contains(text));

            return searchedCarts;
        }
    }
}
