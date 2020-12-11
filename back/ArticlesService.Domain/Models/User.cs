using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string EMail { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
