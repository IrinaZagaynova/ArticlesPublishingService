using ArticlesService.Domain.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesService.Domain.Interfaces
{
    public interface IImageRepository
    {
        List<ImageDto> GetImages(int articleId);
        int AddImage(string name);
    }
}
