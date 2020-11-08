using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ArticleCategory> Articles { get; set; }
    }
}
