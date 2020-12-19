using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("article_has_image")]
    public class ArticleImage
    {
        [Column("id_article_has_image")]
        public int Id { get; set; }
        [Column("id_article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        [Column("id_image")]
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
