using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Net;

namespace CampaignManager.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JWTMiddleware
    {
        private AccountUnitOfWork UnitOfWork = new();
        private readonly RequestDelegate _next;
        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var tokenString = await context.GetTokenAsync("access_token");
            if (!string.IsNullOrEmpty(tokenString))
            {
                var token = new JwtSecurityToken(tokenString);
                Guid accountId = new(token.Claims.FirstOrDefault(claim => claim.Type == "sub").Value);
                if (UnitOfWork.Repository.GetById(accountId) == null)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.StartAsync();
                }
                else
                {
                    await _next(context);
                };
            }
            else
            {
                await _next(context);
            }
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JWTMiddleware>();
        }
    }
}