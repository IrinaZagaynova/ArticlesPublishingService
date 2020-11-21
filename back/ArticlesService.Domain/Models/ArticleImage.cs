using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class ArticleImage
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
