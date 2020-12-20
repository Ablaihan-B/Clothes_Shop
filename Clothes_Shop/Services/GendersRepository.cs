using Clothes_Shop.Models;
using Clothes_Shop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class GendersRepository: IGendersRepository
    {
        private readonly GendersContext _appDbContext;

        public GendersRepository(GendersContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public void Add(Gender gender)
        {
            _appDbContext.Add(gender);
        }

        public Task<List<Gender>> GetAll()
        {
            return _appDbContext.Gender.ToListAsync();
        }

        public Task<List<Gender>> GetGenders(Expression<Func<Gender, bool>> predicate)
        {
            return _appDbContext.Gender.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _appDbContext.SaveChangesAsync();
        }
        public IEnumerable<Gender> AllGenders => _appDbContext.Gender;
    }
}
