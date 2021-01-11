using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class ArticleCardDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserLogin { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
