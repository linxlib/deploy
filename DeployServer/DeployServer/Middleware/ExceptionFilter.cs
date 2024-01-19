using AsyncFriendlyStackTrace;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeployServer.Middleware
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {

                context.Result = new JsonResult(new Resp<object?>
                {
                    code = 500,
                    message = context.Exception.Message,
                    data = null,
                    ex = context.Exception.ToAsyncString().Split("\r\n").ToList(),
                });
               
                context.ExceptionHandled = true; //表示错误已经处理过
            }
        }
    }
}
