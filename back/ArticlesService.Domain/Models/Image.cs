using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("image")]
    public class Image
    {
        [Column("id_image")]
        public int Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(200)")]
        public string Name { get; set; }
        public List<ArticleImage> ArticleImages { get; set; } = new List<ArticleImage>();
    }
}
