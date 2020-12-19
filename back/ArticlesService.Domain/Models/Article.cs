using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("article")]
    public class Article
    {
        [Column("id_article")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("content")]
        public string Content { get; set; }
        [Column("id_user")]
        public User User { get; set; }
        public List<ArticleCategory> Categories { get; set; } = new List<ArticleCategory>();
        public List<ArticleImage> Images { get; set; } = new List<ArticleImage>();
    }
}
