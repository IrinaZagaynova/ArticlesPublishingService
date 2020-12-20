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

        public List<CategoryDto> GetCategories(int articleId)
        {
            return _context.Categories.Include(c => c.ArticleCategories).Where(a => a.ArticleCategories.Any(c => c.ArticleId == articleId))
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Title = c.Title
                })
                .ToList();
        }
    }
}
