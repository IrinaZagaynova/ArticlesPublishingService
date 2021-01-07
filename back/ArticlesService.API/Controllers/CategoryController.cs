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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("categories/{articleId}")]
        public IActionResult GetCategories(int articleId)
        {
            return Ok(_repository.GetArtilceCategories(articleId));
        }

        [HttpGet("all-categories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_repository.GetCategories());
        }

        [HttpGet("selected-categories/{articleId}")]
        public IActionResult GetSelectedCategories(int articleId)
        {
            return Ok(_repository.GetSelectedCategories(articleId));
        }
    }
}
