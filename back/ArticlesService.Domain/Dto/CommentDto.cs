using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }   
        public string Login { get; set; }
        public string Text { get; set; }
    }
}
