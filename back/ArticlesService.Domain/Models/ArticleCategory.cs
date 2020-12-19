using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("article_has_category")]
    public class ArticleCategory
    {
        [Column("id_article_has_category")]
        public int Id { get; set; }
        [Column("id_article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        [Column("id_category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
