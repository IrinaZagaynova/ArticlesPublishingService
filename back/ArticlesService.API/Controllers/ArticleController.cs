﻿using ArticlesService.Domain.Dto;
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
        private readonly IArticleRepository _repository;

        public ArticleController(IArticleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("articles")]
        public IActionResult GetArticles()
        {
            return Ok(_repository.GetArticles());
        }

        [HttpGet("article/{articleId}")]
        public IActionResult GetArticleById(int articleId)
        {
            return Ok(_repository.GetArticleDto(articleId));            
        }

        [HttpGet("articles-by-title")]
        public IActionResult GetArticlesByTitle(string title)
        {
            return Ok(_repository.GetArticlesByTitle(title));
        }

        [HttpGet("articles-by-author")]
        public IActionResult GetArticlesByAuthorLogin(string login)
        {
            return Ok(_repository.GetArticlesByAuthorLogin(login));
        }

        [HttpPost("articles-by-categories")]
        public IActionResult GetArticlesByCategories(List<int> categories)
        {
            return Ok(_repository.GetArticlesByCategories(categories));
        }

        [HttpGet("get-user-articles")]
        [Authorize]
        public IActionResult GetUserArticles()
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(_repository.GetArticleByUserId(userId));
        }

        [HttpDelete("delete-own-article/{articleId}")]
        [Authorize]
        public IActionResult DeleteOwnArticle(int articleId)
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (!_repository.IsUserAuthorOfArticle(userId, articleId))
            {
                return BadRequest();
            }

            try
            {
                _repository.Delete(articleId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
