using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("user")]
    public class User
    {
        [Column("id_user")]
        public int Id { get; set; }
        [Required]
        [Column("login", TypeName = "nvarchar(50)")]
        public string Login { get; set; }
        [Required]
        [Column("email", TypeName = "nvarchar(50)")]
        public string EMail { get; set; }
        [Column("name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column("password", TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
