﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Dto
{
    public class SelectedCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean Checked { get; set; }
    }
}
