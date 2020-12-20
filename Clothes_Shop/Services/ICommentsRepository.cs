using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public interface ICommentsRepository
    {

        void Add(Comments comments);
        Task Save();
        Task<List<Comments>> GetComments(Expression<Func<Comments, bool>> predicate);
        Task<List<Comments>> GetAll();
        IEnumerable<Comments> AllComments { get; }
    }
}
