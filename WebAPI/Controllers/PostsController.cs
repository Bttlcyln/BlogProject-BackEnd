using Business.Abstract;
using Entities.DTOs.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost]
        public IActionResult Add(AddPostRequest request)
        {
            var result = _postService.Add(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public IActionResult Update (UpdatePostRequest request)
        {
            var result = _postService.Update(request);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
       public IActionResult Delete(int postId)
        {
            var result = _postService.Delete(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
