using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface IArticleRepository
    {
        List<ArticleDto> GetArticles();
        ArticleDto GetArticleDto(int articleId);
        List<ArticleDto> GetArticlesByTitle(string title);
        List<ArticleDto> GetArticlesByAuthorLogin(string login);
        List<ArticleDto> GetArticlesByCategories(List<int> categories);
        List<ArticleDto> GetArticleByUserId(int userId);
        bool IsUserAuthorOfArticle(int userId, int articleId);
        void Delete(int articleId);
        void Create(CreateArticleDto createArticleDto, User user);
    }
}
