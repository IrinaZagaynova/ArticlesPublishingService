using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class CreateArticleDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        public List<int> CategoryIds { get; set; }
        //public List<string> ImageNames { get; set; }
    }
}
