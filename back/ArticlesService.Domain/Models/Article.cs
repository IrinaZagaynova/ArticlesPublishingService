using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        public User User { get; set; }
        public List<ArticleCategory> Categories { get; set; } = new List<ArticleCategory>();
        public List<ArticleImage> Images { get; set; } = new List<ArticleImage>();
    }
}
