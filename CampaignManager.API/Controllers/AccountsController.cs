using Microsoft.AspNetCore.Mvc;
using System;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;
using System.Collections.Generic;
using CampaignManager.API.Model.Auth;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        protected AccountUnitOfWork UnitOfWork { get; } = new();
        protected readonly IConfiguration Configuration;
        public AccountsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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
            if (createAttempt.ValidateCreateDetails(out string error))
            {
                if (!UnitOfWork.Repository.IsUsernameUnique(createAttempt.Username))
                {
                    return BadRequest("Username must be unique");
                }
                if (!UnitOfWork.Repository.IsEmailUnique(createAttempt.Email))
                {
                    return BadRequest("Email must be unique");
                }
                Account user = Account.FromCreate(createAttempt);
                UnitOfWork.Repository.Insert(user);
                int result = UnitOfWork.Save();

                if (result > 0)
                {
                    return Ok(Token.BuildToken(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"], user));
                }
                else
                {
                    throw new Exception($"Error creating {user.GetType().Name}");
                }
            }
            else
            {
                return BadRequest(error);
            }
        }

        [HttpGet("validate/username/{username}")]
        public ActionResult<bool> ValidateUsername(string username) => UnitOfWork.Repository.IsUsernameUnique(username);

        [HttpGet("validate/email/{email}")]
        public ActionResult<bool> ValidateEmail(string email) => UnitOfWork.Repository.IsEmailUnique(email);

        // DELETE: api/accounts/{uuid}
        [HttpDelete("{id}")]
        public ActionResult<AccountDto> DeleteAccount(Guid id)
        {
            UnitOfWork.Repository.Delete(id);
            int result = UnitOfWork.Save();
            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                throw new Exception($"Error deleting Account {id}");
            }
        }
    }
}
