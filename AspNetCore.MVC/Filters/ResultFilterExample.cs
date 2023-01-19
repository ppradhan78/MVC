using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace AspNetCore.MVC.Filters
{
    public class ResultFilterExample : IResultFilter, IAsyncResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}
