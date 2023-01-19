using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.MVC.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter, IAsyncResourceFilter
    {
        private readonly string[] _headers;

        public CustomResourceFilter(params string[] headers)
        {
            _headers = headers;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (_headers == null) return;

            if (!_headers.All(m => context.HttpContext.Request.Headers.ContainsKey(m)))
            {
                context.Result = new JsonResult(
                    new { Error = "Headers Missing" }
                )
                { StatusCode = 400 };
                ;
            }
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (_headers == null) return;

            if (!_headers.All(m => context.HttpContext.Request.Headers.ContainsKey(m)))
            {
                context.Result = new JsonResult(new { Error = "Headers Missing" })
                { StatusCode = 400 };
                ;
                return;

                throw new NotImplementedException();
            }
            ResourceExecutedContext executedContext = await next();

        }
    }
}
