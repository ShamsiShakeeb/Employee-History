using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest.Models
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apikey = config.GetValue<string>("ApiKey");

            if (!apikey.Equals(potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
