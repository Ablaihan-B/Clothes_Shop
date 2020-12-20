using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class CategoriesService
    {

        private readonly ICategoriesRepository _categRepo;

        public CategoriesService(ICategoriesRepository categRepo)
        {
            _categRepo = categRepo;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categRepo.GetAll();
        }

        public async Task AddAndSave(Category category)
        {
            _categRepo.Add(category);
            await _categRepo.Save();
        }

        public async Task<List<Category>> Search(string text)
        {
            text = text.ToLower();
            var searchedCategories = await _categRepo.GetCategories(category => category.Name.ToLower().Contains(text));

            return searchedCategories;
        }
    }
}
