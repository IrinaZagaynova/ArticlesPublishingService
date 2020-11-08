using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Article Article { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
    }
}
