using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface IArticleRepository
    {
        //void Create(Article article);
        //void Delete(int id);
        List<ArticleDto> GetArticles();
        ArticleDto GetArticle(int articleId);
        List<ArticleDto> GetArticlesByTitle(string title);
        List<ArticleDto> GetArticlesByAuthorLogin(string login);
        List<ArticleDto> GetArticlesByCategories(List<int> categories);
        List<ArticleDto> GetArticleByUserId(int userId);
    }
}
