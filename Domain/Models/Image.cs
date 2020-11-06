using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public List<ArticleImage> Articles { get; set; }
    }
}
