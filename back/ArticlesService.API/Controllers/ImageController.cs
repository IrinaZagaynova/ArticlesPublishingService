using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArticlesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IImageRepository _repository;
        public static IWebHostEnvironment _enviroment;
        private static readonly String imagesPath = "../../front/src/assets";

        public ImageController(IImageRepository repository, IWebHostEnvironment enviroment)
        {
            _repository = repository;
            _enviroment = enviroment;
        }

        [HttpGet("images/{articleId}")]
        public IActionResult GetCategories(int articleId)
        {
            return Ok(_repository.GetImages(articleId));
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload([FromForm] FileUpload objectFiles)
        {
            try
            {
                List<int> imagesIds = new List<int>();
                var path = Path.Combine(_enviroment.ContentRootPath, imagesPath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (var file in objectFiles.Files)
                {
                    if (file.Length > 0)
                    {

                        var fileName = "img_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + file.FileName;
                        using FileStream stream = System.IO.File.Create(Path.Combine(path, fileName));
                        file.CopyTo(stream);
                        stream.Flush();
                        imagesIds.Add(_repository.AddImage(fileName));
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

                return Ok(imagesIds);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
