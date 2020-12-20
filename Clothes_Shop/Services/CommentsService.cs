using Clothes_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Services
{
    public class CommentsService
    {

        private readonly ICommentsRepository _commRepo;

        public CommentsService(ICommentsRepository commRepo)
        {
            _commRepo = commRepo;
        }

        public async Task<List<Comments>> GetComments()
        {
            return await _commRepo.GetAll();
        }

        public async Task AddAndSave(Comments comments)
        {
            _commRepo.Add(comments);
            await _commRepo.Save();
        }

        public async Task<List<Comments>> Search(string text)
        {
            text = text.ToLower();
            var searchedComments = await _commRepo.GetComments(comments => comments.Id.ToLower().Contains(text));

            return searchedComments;
        }
    }
}
