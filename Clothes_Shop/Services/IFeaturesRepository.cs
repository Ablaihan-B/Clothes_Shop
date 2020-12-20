using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public interface IFeaturesRepository
    {
        void Add(Features features);
        Task Save();
        Task<List<Features>> GetFeatures(Expression<Func<Features, bool>> predicate);
        Task<List<Features>> GetAll();
        IEnumerable<Features> AllFeatures { get; }

    }
}
