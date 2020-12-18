using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticlesService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetUser(Login login)
        {
            return _context.Users.SingleOrDefault(u => u.EMail == login.EMail && u.Password == login.Password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public User Register(UserDto userDto)
        {
            if (_context.Users.Any(u => u.EMail == userDto.EMail || u.Login == userDto.Login))
            {
                return null;
            }

            var user = new User
            {
                EMail = userDto.EMail,
                Login = userDto.Login,
                Name = userDto.Name,
                Password = userDto.Password
            };

            _context.Add(user);
            _context.SaveChanges();

            return user;
        }

    }
}
