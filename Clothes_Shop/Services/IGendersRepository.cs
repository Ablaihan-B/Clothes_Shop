using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public interface IGendersRepository
    {
        void Add(Gender gender);
        Task Save();
        Task<List<Gender>> GetGenders(Expression<Func<Gender, bool>> predicate);
        Task<List<Gender>> GetAll();
        IEnumerable<Gender> AllGenders { get; }

    }
}
