using Accounting.Project.src.Infra.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Accounting.Project.src.Controllers.Base
{
    [Route("[api]")]
    public class AppControllerBase : Controller
    {
        // Este método é chamado quando ocorre uma exceção durante a execução de uma ação.
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null && !context.ExceptionHandled)
            {
                // Manipule a exceção e retorne uma resposta personalizada.
                context.Result = new JsonResult(new ResponseBody
                {
                    Code = 500,
                    Message = context.Exception.Message,
                    Content = context.Exception.StackTrace
                })
                {
                    StatusCode = 500
                };

                // Marca a exceção como tratada para evitar tratamento adicional pelo ASP.NET Core.
                context.ExceptionHandled = true;
            }

            base.OnActionExecuted(context);
        }
    }
}