using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class ItemsService
    {

        private readonly IItemsRepository _itemRepo;

        public ItemsService(IItemsRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public async Task<List<Item>> GetItems()
        {
            return await _itemRepo.GetAll();
        }

        public async Task AddAndSave(Item item)
        {
            _itemRepo.Add(item);
            await _itemRepo.Save();
        }

        public async Task<List<Item>> Search(string text)
        {
            text = text.ToLower();
            var searchedItems = await _itemRepo.GetItems(item => item.Id.ToLower().Contains(text));

            return searchedItems;
        }
    }
}
