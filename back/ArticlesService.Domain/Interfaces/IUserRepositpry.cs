using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(Login login);
    }
}
