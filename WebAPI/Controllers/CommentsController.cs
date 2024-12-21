using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _commentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypostid")]
        public IActionResult GetCommentByPostId(int postId)
        {
            var result = _commentService.GetCommentByPostId(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcommentdetail")]
        public IActionResult GetCommentDetail()
        {
            var result = _commentService.GetCommentDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AddCommentRequest request) 
        {
            var result = _commentService.Add(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateCommentRequest request)
        {
            var result = _commentService.Update(request);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
           
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int commentId) 
        {
            var result = _commentService.Delete(commentId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
           
        }
    }
}
