using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticlesService.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }
        private ArticleDto GetArticleDto(Article article)
        {
            return new ArticleDto()
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                Content = article.Content,
                UserLogin = article.User.Login
            };
        }

        List<ArticleDto> IArticleRepository.GetArticles()
        {
            var result = new List<ArticleDto>();
            var articles = _context.Articles.Include(a => a.User).Include(a => a.Categories).Include(a => a.Images);

            foreach (var article in articles)
            {
                result.Add(GetArticleDto(article));
            }
            
            return result;
        }

        ArticleDto IArticleRepository.GetArticleById(int id)
        {
            return GetArticleDto(_context.Articles.Include(a => a.User).Include(a => a.Categories).Include(a => a.Images).SingleOrDefault(a => a.Id == id));
        }
    }
}
