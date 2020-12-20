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

        List<ArticleDto> IArticleRepository.GetArticles()
        {
            return _context.Articles.Include(a => a.User)
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                    UserLogin = a.User.Login
                }).ToList();
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

        public ArticleDto GetArticleDto(int articleId)
        {
            return GetArticleDto(_context.Articles.Include(a => a.User).SingleOrDefault(a => a.Id == articleId));
        }
        public List<ArticleDto> GetArticlesByTitle(string title)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.Title.Contains(title))
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                    UserLogin = a.User.Login
                }).ToList();

        }

        public List<ArticleDto> GetArticlesByAuthorLogin(string login)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.User.Login.Contains(login))
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                    UserLogin = a.User.Login
                }).ToList();
        }

        public List<ArticleDto> GetArticlesByCategories(List<int> categories)
        {
            var articles = _context.Articles.Include(a => a.User).Include(a => a.ArticleCategories);
            var result = new List<ArticleDto>();

            foreach (var article in articles)
            {
                var categoryIds = article.ArticleCategories
                    .Select(a => a.CategoryId).ToList();

                if (categories.All(categoryIds.Contains))
                {
                    result.Add(GetArticleDto(article));
                }
            }

            return result;
        }

        public List<ArticleDto> GetArticleByUserId(int userId)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.User.Id == userId)
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                    UserLogin = a.User.Login
                }).ToList();
        }

        public bool IsUserAuthorOfArticle(int userId, int articleId)
        {
            var articles = GetArticleByUserId(userId);

            if (articles.Any(a => a.Id == articleId))
            {
                return true;
            }

            return false;
        }

        public void Delete(int articleId)
        {
            var article = _context.Articles.Include(a => a.User).Include(a => a.ArticleCategories).Include(a => a.ArticleImages).SingleOrDefault(a => a.Id == articleId);

            if (article == null)
            {
                throw new Exception();
            }

            _context.Remove(article);
            _context.SaveChanges();
        }

        public void Create(CreateArticleDto createArticleDto, User user)
        {
            var article = new Article
            {
                Title = createArticleDto.Title,
                Description = createArticleDto.Description,
                Content = createArticleDto.Content,
                User = user
            };

            _context.Add(article);
            _context.SaveChanges();

            if (createArticleDto.CategoryIds.Count() != 0)
            {
                foreach (var categoryId in createArticleDto.CategoryIds)
                {
                    _context.Add(new ArticleCategory { ArticleId = article.Id, CategoryId = categoryId });
                }
            }

            _context.SaveChanges();
        }
    }
}
