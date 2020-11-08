using Domain.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
