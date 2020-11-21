using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
