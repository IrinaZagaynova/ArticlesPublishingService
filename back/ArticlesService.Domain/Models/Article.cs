using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public List<ArticleCategory> Categories { get; set; }
        public List<ArticleImage> Images { get; set; }
    }
}
