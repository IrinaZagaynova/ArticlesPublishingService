using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public void Create(Article article)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> Find(string title = null, string author = null)
        {
            throw new NotImplementedException();
        }

        public User GetAutor(int id)
        {
            throw new NotImplementedException();
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IUserRepository GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, string title = null, string description = null, string content = null, int idUser = 0)
        {
            throw new NotImplementedException();
        }
    }
}
