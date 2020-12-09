using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Text { get; set; }
    }
}
