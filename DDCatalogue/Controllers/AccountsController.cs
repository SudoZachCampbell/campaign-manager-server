using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using DDCatalogue.Model.Auth;
using DDCatalogue.Data;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;

namespace DDCatalogue.Controllers
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
            Account returnedUser = string.IsNullOrEmpty(attempt.Username)
                ? UnitOfWork.Repository.GetUserByEmail(attempt.Email)
                : UnitOfWork.Repository.GetUserByUsername(attempt.Username);

            if (returnedUser?.CheckPassword(attempt.Password) ?? false)
            {
                return Ok(Token.BuildToken(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"], returnedUser));
            }
            else
            {
                throw new AuthenticationException("Invalid login attempt");
            }
        }

        // POST: api/accounts
        [HttpPost]
        public ActionResult<Account> CreateAccount(Account user)
        {
            CreatedResult userResult = PostGen(user);
            return userResult;
        }

        // DELETE: api/accounts/{uuid}
        [HttpDelete("{id}")]
        public ActionResult<Account> DeleteAccount(Guid id)
        {
            return DeleteGen(id);
        }
    }
}
