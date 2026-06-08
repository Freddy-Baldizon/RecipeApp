using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipeApp.Exceptions;

namespace RecipeApp.Api.Filter;

public class MessageExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MessageException ex)
        {
            context.Result = new ObjectResult(new { message = ex.Message })
            {
                StatusCode = ex.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}
