using ArticlesService.Domain.Dto;
using ArticlesService.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArticlesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public ArticleController(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        [HttpGet("articles")]
        public IActionResult GetArticlesByDesc()
        {
            return Ok(_articleRepository.GetArticles());
        }

        [HttpGet("article-page/{articleId}")]
        public IActionResult GetArticleToPage(int articleId)
        {
            return Ok(_articleRepository.GetArticleToPage(articleId));            
        }

        [HttpGet("articles-by-title")]
        public IActionResult GetArticlesByTitle(string title)
        {
            return Ok(_articleRepository.GetArticlesByTitle(title));
        }

        [HttpGet("articles-by-author")]
        public IActionResult GetArticlesByAuthorLogin(string login)
        {
            return Ok(_articleRepository.GetArticlesByAuthorLogin(login));
        }

        [HttpPost("articles-by-categories")]
        public IActionResult GetArticlesByCategories(List<int> categories)
        {
            return Ok(_articleRepository.GetArticlesByCategories(categories));
        }

        [HttpGet("get-user-articles")]
        [Authorize]
        public IActionResult GetUserArticles()
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(_articleRepository.GetArticleByUserId(userId));
        }

        [HttpDelete("delete-own-article/{articleId}")]
        [Authorize]
        public IActionResult DeleteOwnArticle(int articleId)
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (!_articleRepository.IsUserAuthorOfArticle(userId, articleId))
            {
                return BadRequest();
            }

            try
            {
                _articleRepository.Delete(articleId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("create-article")]
        [Authorize]
        public IActionResult CreateArticle(CreateArticleDto createArticleDto)
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

            try
            {
                _articleRepository.Create(createArticleDto, _userRepository.GetUserById(userId));
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("edit-article/{articleId}")]
        [Authorize]
        public IActionResult EditArticle(int articleId, CreateArticleDto createArticleDto)
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            
            if (!_articleRepository.IsUserAuthorOfArticle(userId, articleId))
            {
                return BadRequest();
            }

            try
            {
                _articleRepository.Edit(articleId, createArticleDto);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("article/{articleId}")]
        public IActionResult GetArticle(int articleId)
        {
            return Ok(_articleRepository.GetArticle(articleId));
        }
    }
}
