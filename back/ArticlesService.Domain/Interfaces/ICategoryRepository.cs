﻿using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
    }
}