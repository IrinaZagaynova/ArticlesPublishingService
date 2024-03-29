﻿using ArticlesService.Domain.Dto;
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

        List<ArticleCardDto> IArticleRepository.GetArticles()
        {
            return _context.Articles.Include(a => a.User)
                .Select(a => new ArticleCardDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    UserLogin = a.User.Login,
                    CreationDate = a.CreationDate
                })
                .OrderByDescending(a => a.CreationDate).ToList();
        }

        public ArticlePageDto GetArticleToPage(int articleId)
        {
            return _context.Articles.Include(a => a.User)
                .Select(a => new ArticlePageDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    UserLogin = a.User.Login,
                    CreationDate = a.CreationDate
                })
                .SingleOrDefault(a => a.Id == articleId);
        }

        public List<ArticleCardDto> GetArticlesByTitle(string title)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.Title.Contains(title))
                .Select(a => new ArticleCardDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    UserLogin = a.User.Login,
                    CreationDate = a.CreationDate
                })
                .OrderByDescending(a => a.CreationDate).ToList();
        }

        public List<ArticleCardDto> GetArticlesByAuthorLogin(string login)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.User.Login.Contains(login))
                .Select(a => new ArticleCardDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    UserLogin = a.User.Login,
                    CreationDate = a.CreationDate
                })
                .OrderByDescending(a => a.CreationDate).ToList();
        }

        private ArticleCardDto GetArticleCardDto(Article article)
        {
            return new ArticleCardDto()
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                UserLogin = article.User.Login,
                CreationDate = article.CreationDate
            };
        }

        public List<ArticleCardDto> GetArticlesByCategories(List<int> categories)
        {
            var articles = _context.Articles.Include(a => a.User).Include(a => a.ArticleCategories).OrderByDescending(a => a.CreationDate);
            var result = new List<ArticleCardDto>();

            foreach (var article in articles)
            {
                var categoryIds = article.ArticleCategories
                    .Select(a => a.CategoryId).ToList();

                if (categories.All(categoryIds.Contains))
                {
                    result.Add(GetArticleCardDto(article));
                }
            }

            return result;
        }

        public List<UserArticleCardDto> GetArticleByUserId(int userId)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.User.Id == userId)
                .Select(a => new UserArticleCardDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    CreationDate = a.CreationDate
                })
                .OrderByDescending(a => a.CreationDate).ToList();
        }

        public bool IsUserAuthorOfArticle(int userId, int articleId)
        {
            return GetArticleByUserId(userId).Any(a => a.Id == articleId);
        }

        public void Delete(int articleId)
        {
            var article = _context.Articles.Include(a => a.User).Include(a => a.ArticleCategories).Include(a => a.ArticleImages).SingleOrDefault(a => a.Id == articleId);

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
                CreationDate = DateTime.Now,
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

            if (createArticleDto.ImageIds.Count() != 0)
            {
                foreach (var imageId in createArticleDto.ImageIds)
                {
                    _context.Add(new ArticleImage { ArticleId = article.Id, ImageId = imageId });
                }
            }

            _context.SaveChanges();
        }

        public void Edit(int articleId, CreateArticleDto createArticleDto)
        {
            var article = _context.Articles.SingleOrDefault(a => a.Id == articleId);

            article.Title = createArticleDto.Title;
            article.Description = createArticleDto.Description;
            article.Content = createArticleDto.Content;

            _context.Update(article);

            var articleCategories = _context.ArticleCategories.Where(ac => ac.ArticleId == articleId);

            foreach (var articleCategory in articleCategories)
            {
                if (!createArticleDto.CategoryIds.Contains(articleCategory.CategoryId))
                {
                    _context.Remove(articleCategory);
                }
            }
  
            foreach (var categoryId in createArticleDto.CategoryIds)
            {
                if (!articleCategories.Any(ac => ac.CategoryId == categoryId))
                {
                    _context.Add(new ArticleCategory { ArticleId = article.Id, CategoryId = categoryId });
                }
            }

            var articleImages = _context.ArticleImages.Where(ac => ac.ArticleId == articleId);

            foreach (var articleImage in articleImages)
            {
                if (!createArticleDto.ImageIds.Contains(articleImage.ImageId))
                {
                    _context.Remove(articleImage);
                }
            }

            foreach (var imageId in createArticleDto.ImageIds)
            {
                if (!articleImages.Any(ai => ai.ImageId == imageId))
                {
                    _context.Add(new ArticleImage { ArticleId = article.Id, ImageId = imageId });
                }
            }

            _context.SaveChanges();
        }

        public ArticleDto GetArticle(int articleId)
        {
            return _context.Articles
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                })
                .SingleOrDefault(a => a.Id == articleId);
        }
    }
}
