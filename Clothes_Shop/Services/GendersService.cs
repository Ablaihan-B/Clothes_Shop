using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class GendersService
    {
        private readonly IGendersRepository _genRepo;

        public GendersService(IGendersRepository genRepo)
        {
            _genRepo = genRepo;
        }

        public async Task<List<Gender>> GetGenders()
        {
            return await _genRepo.GetAll();
        }

        public async Task AddAndSave(Gender gender)
        {
            _genRepo.Add(gender);
            await _genRepo.Save();
        }

        public async Task<List<Gender>> Search(string text)
        {
            text = text.ToLower();
            var searchedGenders = await _genRepo.GetGenders(gender => gender.Id.ToLower().Contains(text));

            return searchedGenders;
        }

    }
}
