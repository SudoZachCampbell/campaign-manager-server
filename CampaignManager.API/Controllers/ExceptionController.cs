using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace CampaignManager.API.Controllers
{
    [ApiController]
    public class ExceptionController : Controller
    {
        private readonly static Dictionary<string, int> _httpStatus = new()
        {
            { "FileNotFoundException", 400 },
            { "ArgumentException", 400 },
            { "InvalidEnumArgumentException", 400 },
            { "AuthenticationException", 401 },
            { "AccessViolationException", 403 },
            { "Exception", 500 },
            { "InvalidOperationException", 422 },
            { "OutOfMemoryException", 508 }
        };

        /// <summary>
        /// The Error handling controller for parsing and delivering concise error messages in a live environment
        /// </summary>
        /// <param name="webHostEnvironment">The host environment of the exception</param>
        /// <returns>Exception Body in JSON string format</returns>
        [Route("error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            string errorType = context.Error.GetType().ToString();
            bool statusCheck = _httpStatus.TryGetValue(errorType.Split('.').Last(), out var status);
            int statusCode = statusCheck ? status : 500;
            ExceptionBody exBody = new ExceptionBody()
            {
                HttpStatusCode = statusCode,
                HttpStatus = ((HttpStatusCode)statusCode).ToString(),
                ErrorCode = ((HttpStatusCode)statusCode).ToString(),
                ErrorMessage = $"|{DateTime.UtcNow}| {context.Error.Message}",
                ErrorId = HttpContext.TraceIdentifier
            };

            return StatusCode(statusCode, exBody);
        }

        /// <summary>
        /// The Error handling controller for parsing and delivering verbose error messages in a local environment
        /// </summary>
        /// <param name="webHostEnvironment">The host environment of the exception</param>
        /// <returns>Exception Body in JSON string format</returns>
        [Route("error-local-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ErrorLocal([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            string errorType = context.Error.GetType().ToString();
            bool statusCheck = _httpStatus.TryGetValue(errorType.Split('.').Last(), out var status);
            int statusCode = statusCheck ? status : 500;
            ExceptionBody exBody = new()
            {
                HttpStatusCode = statusCode,
                HttpStatus = ((HttpStatusCode)statusCode).ToString(),
                ErrorCode = ((HttpStatusCode)statusCode).ToString(),
                ErrorMessage = $"{context.Error.Message}",
                InnerErrorMessage = context.Error.InnerException?.Message,
                ErrorDateTime = DateTime.UtcNow,
                ErrorId = HttpContext.TraceIdentifier,
                StackTrace = context.Error.StackTrace,
                InnerStackTrace = context.Error.InnerException?.StackTrace
            };

            return StatusCode(statusCode, exBody);
        }

        private class ExceptionBody
        {
            public string ErrorCode { get; set; }
            public List<string> ErrorDetails { get; set; }
            public string ErrorId { get; set; }
            public string ErrorMessage { get; set; }
            public string InnerErrorMessage { get; set; }
            public DateTime ErrorDateTime { get; set; }
            public string HttpStatus { get; set; }
            public int HttpStatusCode { get; set; }
            public string StackTrace { get; set; }
            public string InnerStackTrace { get; set; }
        }
    }
}
