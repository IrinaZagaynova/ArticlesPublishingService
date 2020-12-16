using ArticlesService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface IImageRepository
    {
        List<ImageDto> GetImages(int articleId);
    }
}
