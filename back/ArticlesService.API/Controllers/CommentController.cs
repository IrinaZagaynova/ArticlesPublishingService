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
    public class CommentController : Controller
    {
        private readonly ICommentRepository _repository;

        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("comments-count/{articleId}")]
        public IActionResult GetCommentsCount(int articleId)
        {
            return Ok( _repository.GetCommentsCount(articleId));
        }

        [HttpGet("comments/{articleId}")]
        public IActionResult GetComments(int articleId)
        {
            return Ok(_repository.GetComments(articleId));
        }

        [HttpPost("create-comment")]
        [Authorize]
        public IActionResult CreateComment(CreateCommentDto createCommentDto)
        {
            var userId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            try
            {
                _repository.CreateComment(userId, createCommentDto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
