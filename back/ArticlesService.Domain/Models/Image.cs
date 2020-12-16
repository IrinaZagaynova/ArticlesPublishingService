using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ArticleImage> Images { get; set; } = new List<ArticleImage>();
    }
}
