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
    public class FeaturesRepository : IFeaturesRepository
    {
        private readonly FeaturesContext _appDbContext;

        public FeaturesRepository(FeaturesContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public void Add(Features features)
        {
            _appDbContext.Add(features);
        }

        public Task<List<Features>> GetAll()
        {
            return _appDbContext.Features.ToListAsync();
        }

        public Task<List<Features>> GetFeatures(Expression<Func<Features, bool>> predicate)
        {
            return _appDbContext.Features.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _appDbContext.SaveChangesAsync();
        }
        public IEnumerable<Features> AllFeatures => _appDbContext.Features;
    }

}
