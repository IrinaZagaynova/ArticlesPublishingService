using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class ArticlePageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserLogin { get; set; }
    }
}
