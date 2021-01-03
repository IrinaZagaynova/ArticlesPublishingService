using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticlesService.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CommentDto> GetComments(int articleId)
        {
            return _context.Comments.Include(c => c.User).Where(c => c.ArticleId == articleId)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Login = c.User.Login,
                    Text = c.Text
                }).ToList();        
        }

        public int GetCommentsCount(int articleId)
        {
            return _context.Comments.Where(c => c.ArticleId == articleId).Count();
        }

        public void CreateComment(int userId, CreateCommentDto createCommentDto)
        {
            var comment = new Comment
            {
                ArticleId = createCommentDto.ArticleId,
                UserId = userId,
                Text = createCommentDto.Text
            };

            _context.Add(comment);
            _context.SaveChanges();
        }
    }
}
