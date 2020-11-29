using ArticlesService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _repository;

        public ArticleController(IArticleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-articles")]
        public IActionResult GetArticles()
        {
            return Ok(_repository.GetArticles());
        }

        [HttpGet("get-article/{id}")]
        public IActionResult GetArticleById(int id)
        {
            return Ok(_repository.GetArticleById(id));            
        }
    }
}
