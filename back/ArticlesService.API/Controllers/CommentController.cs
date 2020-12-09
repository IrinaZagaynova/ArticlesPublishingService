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
    public class CommentController : Controller
    {
        private readonly ICommentRepository _repository;

        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("comments-count/{id}")]
        public IActionResult GetCommentsCount(int id)
        {
            return Ok( _repository.GetCommentsCount(id));
        }

        [HttpGet("comments/{id}")]
        public IActionResult GetComments(int id)
        {
            return Ok(_repository.GetComments(id));
        }
    }
}
