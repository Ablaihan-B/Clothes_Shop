using Clothes_Online_Shop.Models;
using Clothes_Shop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly CommentsContext _appDbContext;

        public CommentsRepository(CommentsContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public void Add(Comments comments)
        {
            _appDbContext.Add(comments);
        }

        public Task<List<Comments>> GetAll()
        {
            return _appDbContext.Comments.ToListAsync();
        }

        public Task<List<Comments>> GetComments(Expression<Func<Comments, bool>> predicate)
        {
            return _appDbContext.Comments.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _appDbContext.SaveChangesAsync();
        }
        public IEnumerable<Comments> AllComments => _appDbContext.Comments;
    }

}
