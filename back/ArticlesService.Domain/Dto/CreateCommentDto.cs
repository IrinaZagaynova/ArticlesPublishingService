using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class CreateCommentDto
    {
        public int ArticleId { get; set; }
        public string Text { get; set; }
    }
}
