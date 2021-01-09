using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class CategoryWithCountDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
    }
}
