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
        ArticleDto GetArticleById(int id);
        //List<Category> GetCategories();
    }
}
