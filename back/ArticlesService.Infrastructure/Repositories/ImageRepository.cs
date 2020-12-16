using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticlesService.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository 
    {
        private readonly AppDbContext _context;

        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ImageDto> GetImages(int articleId)
        {
            return _context.Images.Include(i => i.Images).Where(a => a.Images.Any(i => i.ArticleId == articleId))
                .Select(i => new ImageDto
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .ToList();
        }
    }
}
