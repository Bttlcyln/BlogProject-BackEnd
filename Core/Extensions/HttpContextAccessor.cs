using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class HttpContextAccessor
    {
        public static int GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            HttpContext httpContext = httpContextAccessor.HttpContext;
            HttpRequest request = httpContext?.Request;

            string accessToken = request?.Headers["Authorization"].FirstOrDefault();
            int userId;

            if(accessToken == "Bearer null")
                throw new UnauthorizedAccessException("Yetkisiz giriş");

            if (!string.IsNullOrEmpty(accessToken))
            {
                if (accessToken.StartsWith("Bearer")) 
                    accessToken = accessToken.Replace("Bearer ", "").Replace("\"", "").Trim();

                JwtSecurityToken securityToken = new JwtSecurityToken(accessToken);

                if (securityToken.Claims.Any())
                {
                    List<Claim> claim = securityToken.Claims.ToList();
                    userId = Convert.ToInt32(claim.FirstOrDefault()?.Value);
                
                    return userId;
                }
            }

            return 0;
        }
    }
}
