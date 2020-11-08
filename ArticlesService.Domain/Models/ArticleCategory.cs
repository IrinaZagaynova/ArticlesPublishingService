using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class ArticleCategory
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
