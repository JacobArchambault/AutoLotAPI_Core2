using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AutoLotAPI_Core2.Filters
{
    public class AutoLotExceptionFilter : IExceptionFilter
    {
        private readonly bool _isDevelopment;
        public AutoLotExceptionFilter(IWebHostEnvironment env)
        {
            _isDevelopment = env.IsDevelopment();
        }
        public void OnException(ExceptionContext context) 
        {
            var ex = context.Exception;
            string stackTrace = (_isDevelopment) ? context.Exception.StackTrace : string.Empty;
            IActionResult actionResult;
            string message = ex.Message;
            if (ex is DbUpdateConcurrencyException)
            {
                if (!_isDevelopment)
                {
                    message = "There was an error updating the database. Another user has altered the record.";
                }
                actionResult = new BadRequestObjectResult(
                    new { Error = "Concurrency Issue.", ex.Message, StackTrace = stackTrace });
            }
            else
            {
                if (!_isDevelopment)
                {
                    message = "There was an unknown error. Please try again.";
                }
                actionResult = new ObjectResult(
                    new { Error = "General Error.", ex.Message, StackTrace = stackTrace })
                { StatusCode = 500 };
            }
            context.Result = actionResult;
        }
    }
}
