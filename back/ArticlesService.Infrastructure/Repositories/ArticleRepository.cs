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
            var articles = _context.Articles.Include(a => a.User).Include(a => a.Categories).Include(a => a.Images);
            var result = new List<ArticleDto>();

            foreach (var article in articles)
            {
                result.Add(GetArticleDto(article));
            }
            
            return result;
        }

        public Article GetArticle(int articleId)
        {
            return _context.Articles.Include(a => a.User).Include(a => a.Categories).Include(a => a.Images).SingleOrDefault(a => a.Id == articleId);
        }

        public ArticleDto GetArticleDto(int articleId)
        {
            return GetArticleDto(GetArticle(articleId));
        }
        public List<ArticleDto> GetArticlesByTitle(string title)
        {
            var articles = _context.Articles.Include(a => a.User).Where(a => a.Title.Contains(title));
            var result = new List<ArticleDto>();

            foreach (var article in articles)
            {
                result.Add(GetArticleDto(article));
            }

            return result;
        }

        public List<ArticleDto> GetArticlesByAuthorLogin(string login)
        {
            var articles = _context.Articles.Include(a => a.User).Where(a => a.User.Login.Contains(login));
            var result = new List<ArticleDto>();

            foreach (var article in articles)
            {
                result.Add(GetArticleDto(article));
            }

            return result;
        }

        public List<ArticleDto> GetArticlesByCategories(List<int> categories)
        {
            var articles = _context.Articles.Include(a => a.User).Include(a => a.Categories).Include(a => a.Images);
            var result = new List<ArticleDto>();

            foreach (var article in articles)
            {
                foreach (var categody in categories)
                {
                    if (article.Categories.Any(c => c.CategoryId == categody))
                    {
                        result.Add(GetArticleDto(article));
                        break;
                    }
                }
            }

            return result;
        }

        public List<ArticleDto> GetArticleByUserId(int userId)
        {
            var articles = _context.Articles.Include(a => a.User).Where(a => a.User.Id == userId);
            var result = new List<ArticleDto>();

            foreach (var article in articles)
            {
                result.Add(GetArticleDto(article));
            }

            return result;
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
            var article = GetArticle(articleId);

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

            var id = article.Id;

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
