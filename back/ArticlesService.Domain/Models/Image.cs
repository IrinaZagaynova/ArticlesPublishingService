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
        public string Path { get; set; }
        public List<ArticleImage> Articles { get; set; }
    }
}
