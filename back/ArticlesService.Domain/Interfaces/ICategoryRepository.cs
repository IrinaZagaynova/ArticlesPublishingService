using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<CategoryDto> GetArtilceCategories(int articleId);
        List<SelectedCategoryDto> GetSelectedCategories(int articleId);
        List<CategoryDto> GetCategories();
    }
}
