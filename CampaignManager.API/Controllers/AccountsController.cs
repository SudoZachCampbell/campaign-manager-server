using Microsoft.AspNetCore.Mvc;
using System;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : GenericController<Account>
    {
        protected override AccountUnitOfWork UnitOfWork { get; } = new();
        public AccountsController(IConfiguration configuration) : base(configuration) { }

        // PUT: api/accounts/login
        [HttpPost("[action]")]
        public ActionResult<string> Login(LoginAttempt attempt)
        {
            if (attempt.ValidateLoginDetails())
            {
                Account returnedUser = string.IsNullOrEmpty(attempt.Username)
                    ? UnitOfWork.Repository.GetUserByEmail(attempt.Email)
                    : UnitOfWork.Repository.GetUserByUsername(attempt.Username);

                if (returnedUser?.CheckPassword(attempt.Password) ?? false)
                {
                    return Ok(Token.BuildToken(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"], returnedUser));
                }
                else
                {
                    return BadRequest("Invalid login attempt");
                }
            }
            else
            {
                return BadRequest("Missing login details");
            }
        }

        // POST: api/accounts
        [HttpPost]
        public ActionResult<string> CreateAccount(CreateAttempt createAttempt)
        {
            if (createAttempt.ValidateCreateDetails())
            {
                Account user = Account.FromCreate(createAttempt);
                CreatedResult userResult = PostGen(user);
                return Ok(Token.BuildToken(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"], user));
            }
            else
            {
                return BadRequest("Invalid Create Attempt");
            }
        }

        // DELETE: api/accounts/{uuid}
        [HttpDelete("{id}")]
        public ActionResult<Account> DeleteAccount(Guid id)
        {
            return DeleteGen(id);
        }
    }
}
