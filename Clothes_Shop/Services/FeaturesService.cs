using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class FeaturesService
    {

        private readonly IFeaturesRepository _featRepo;

        public FeaturesService(IFeaturesRepository featRepo)
        {
            _featRepo = featRepo;
        }

        public async Task<List<Features>> GetFeatures()
        {
            return await _featRepo.GetAll();
        }

        public async Task AddAndSave(Features features)
        {
            _featRepo.Add(features);
            await _featRepo.Save();
        }

        public async Task<List<Features>> Search(string text)
        {
            text = text.ToLower();
            var searchedFeatures = await _featRepo.GetFeatures(Features => Features.Id.ToLower().Contains(text));

            return searchedFeatures;
        }
    }
}
