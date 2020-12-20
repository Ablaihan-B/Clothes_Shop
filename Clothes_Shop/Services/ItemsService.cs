using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class ItemsService
    {

        private readonly IItemsRepository _itemRepo;
        private readonly IGendersRepository _gendersContext;
        private readonly IFeaturesRepository _featuresContext;
        private readonly ICategoriesRepository _categoryContext;

        public ItemsService(IItemsRepository itemRepo, IGendersRepository gendersContext, IFeaturesRepository featuresContext, ICategoriesRepository categoryContext)
        {
            _itemRepo = itemRepo;
            _gendersContext = gendersContext;
            _featuresContext = featuresContext;
            _categoryContext = categoryContext;
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
            var searchedItems = await _itemRepo.GetItems(item => item.Name.ToLower().Contains(text));

            return searchedItems;
        }

        
        public async Task<List<Item>> Filter(string CategoryId, string GenderId, string SizeId)
        {

            var catId =  _categoryContext.AllCategories;

            var genId = _gendersContext.AllGenders;

            var features = _featuresContext.AllFeatures.ToList();


            //var items7 = _itemRepo.GetAll(false).Where(m=>m.CategoryId = CategoryId && m.GenderId == GenderId);

            var items =  _itemRepo.AllItems.ToList();



            List<Item> it = new List<Item>();

            foreach (var t in items) {
                foreach (var p in features)
                {
                    /*
                      foreach (var y in genId) {
                          foreach (var o in sizId){
                              foreach (var e in catId){*/


                    if (t.GenderId == GenderId && p.Size == SizeId && t.CategoryId == CategoryId && t.FeaturesId == p.Id)
                    {
                        it.Add(t);
                    }
                
                }
                            /*
                        }
                    }
                } */
            }
           


            //var searchedItems = await _itemRepo.GetItems(item => item.ToLower().Contains(text));

            return it;
        }

    }
}
