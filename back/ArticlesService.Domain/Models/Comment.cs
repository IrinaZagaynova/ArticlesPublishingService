using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
