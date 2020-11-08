using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IArticleRepository
    {
        void Delete(int id);
        void Create(Article article);
        Article GetById(int id);
        User GetAutor(int id);
        List<Article> Find(string title = null, string author = null);
    }
}
