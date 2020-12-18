using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class UserDto
    {
        public string Login { get; set; }
        public string EMail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
