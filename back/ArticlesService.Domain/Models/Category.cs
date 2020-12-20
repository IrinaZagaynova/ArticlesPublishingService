using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("category")]
    public class Category
    {
        [Column("id_category")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        public List<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();
    }
}
