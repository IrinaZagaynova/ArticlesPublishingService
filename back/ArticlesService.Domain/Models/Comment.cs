using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticlesService.Domain.Models
{
    [Table("comment")]
    public class Comment
    {
        [Column("id_comment")]
        public int Id { get; set; }
        [Required]
        [Column("id_article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        [Required]
        [Column("id_user")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [Column("text", TypeName = "varchar(200)")]
        public string Text { get; set; }
    }
}
