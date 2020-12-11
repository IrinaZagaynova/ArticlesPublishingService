using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class ArticleImage
    {
        public int Id { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        [Required]
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
