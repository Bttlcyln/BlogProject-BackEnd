using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _notificationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId() // -> Parametre
        { var result = _notificationService.GetAllByUserId();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        
        }

        [HttpPost("add")]
        public IActionResult Add(AddNotificationRequest request)
        {
            var result = _notificationService.Add(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Notification notification) 
        {
            var result = _notificationService.Update(notification);
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
        public IActionResult Delete(int notificationId)
        {
            var result = _notificationService.Delete(notificationId);
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
