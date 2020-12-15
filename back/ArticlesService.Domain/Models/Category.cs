using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<ArticleCategory> Categories { get; set; } = new List<ArticleCategory>();
    }
}
