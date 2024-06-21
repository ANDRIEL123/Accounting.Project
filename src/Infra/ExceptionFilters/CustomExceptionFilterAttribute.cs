using Accounting.Project.src.Infra.Exceptions;
using Accounting.Project.src.Infra.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        // Verifique se a exceção é do tipo que você deseja manipular
        if (
            context.Exception is BusinessException ||
            context.Exception is Exception
        )
        {
            context.Result = new JsonResult(new ResponseBody
            {
                Code = 500,
                Message = context.Exception.Message,
                Content = null
            })
            {
                StatusCode = 500
            };
        }

        base.OnException(context);
    }
}
