using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface IArticleRepository
    {
        List<ArticleCardDto> GetArticles();
        ArticleDto GetArticle(int articleId);
        List<ArticleCardDto> GetArticlesByTitle(string title);
        List<ArticleCardDto> GetArticlesByAuthorLogin(string login);
        List<ArticleCardDto> GetArticlesByCategories(List<int> categories);
        List<UserArticleCardDto> GetArticleByUserId(int userId);
        bool IsUserAuthorOfArticle(int userId, int articleId);
        void Delete(int articleId);
        void Create(CreateArticleDto createArticleDto, User user);
    }
}
