using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
            return _context.Images.Include(i => i.ArticleImages).Where(a => a.ArticleImages.Any(i => i.ArticleId == articleId))
                .Select(i => new ImageDto
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .ToList();
        }


        public int AddImage(string name)
        {
            var image = new Image
            {
                Name = name
            };

            _context.Add(image);
            _context.SaveChanges();

            return image.Id;
        }       
    }
}
