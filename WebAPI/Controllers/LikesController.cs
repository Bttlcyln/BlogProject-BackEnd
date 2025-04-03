using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Like;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        ILikeService _likeServive;

        public LikesController(ILikeService likeServive)
        {
            _likeServive = likeServive;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _likeServive.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(AddLikeRequest request)
        {
            var result = _likeServive.Add(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(Like like)
        {
            var result = _likeServive.Update(like);
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
        public IActionResult Delete(int likeId)
        {
            var result = _likeServive.Delete( likeId);
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
