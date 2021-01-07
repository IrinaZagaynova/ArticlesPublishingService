using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticlesService.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetArtilceCategories(int articleId)
        {
            return _context.Categories.Include(c => c.ArticleCategories).Where(a => a.ArticleCategories.Any(c => c.ArticleId == articleId))
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Title = c.Title
                })
                .ToList();
        }

        public List<SelectedCategoryDto> GetSelectedCategories(int articleId)
        {
            var categories = GetCategories();
            var articleCategories = GetArtilceCategories(articleId);
            List<SelectedCategoryDto> result = new List<SelectedCategoryDto>();

            foreach (var category in categories)
            {
                var item = new SelectedCategoryDto()
                { 
                    Id = category.Id,               
                    Title = category.Title
                };

                if (articleCategories.Any(ac => ac.Id == category.Id))
                {
                    item.Checked = true;               
                }
                else
                {
                    item.Checked = false;
                }

                result.Add(item);
            }

            return result;
        }

        public List<CategoryDto> GetCategories()
        {
            return _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Title = c.Title
                })
                .ToList();
        }
    }
}
