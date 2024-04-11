using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using CampaignManager.API.Model.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CampaignManager.API.ModelBinder
{
    public class AccountModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var tokenString = await bindingContext.HttpContext.GetTokenAsync("access_token");
            if (!string.IsNullOrEmpty(tokenString))
            {
                var token = new JwtSecurityToken(tokenString);
                bindingContext.Result = ModelBindingResult.Success(
                    new AccountDto()
                    {
                        Id = new Guid(token.Claims.FirstOrDefault(claim => claim.Type == "sub").Value),
                        Email = token.Claims.FirstOrDefault(claim => claim.Type == "email").Value,
                        Username = token.Claims.FirstOrDefault(claim => claim.Type == "nameid").Value
                    });
            }
        }
    }
}