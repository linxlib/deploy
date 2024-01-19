using Entity;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace DeployServer.Middleware
{
    /// <summary>
    /// 需要token校验的注解
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthAttribute : Attribute
    {
    }
    /// <summary>
    /// 需要token校验的注解
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class WebsocketAuthAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NonAuthAttribute : Attribute
    {
    }

    public static class AuthHelper {
         public static Guid CurrentUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("UserId").ToObjectId();
        }
        public static Guid CurrentUserId(this ControllerBase user)
        {
            return user.HttpContext.User.FindFirstValue("UserId").ToObjectId();
        }
        public static string CurrentUserName(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("UserName");
        }
        public static string CurrentUserName(this ControllerBase user)
        {
            return user.HttpContext.User.FindFirstValue("UserName");
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return Convert.ToBoolean( user.FindFirstValue("IsAdmin"));
        }
        public static bool IsAdmin(this ControllerBase user)
        {
            return Convert.ToBoolean(user.HttpContext.User.FindFirstValue("IsAdmin"));
        }
        public static string CurrentToken(this ControllerBase user)
        {
            return Convert.ToString(user.HttpContext.User.FindFirstValue("token"));
        }
        public static string CurrentSession(this ControllerBase user)
        {
            return Convert.ToString(user.HttpContext.User.FindFirstValue("session"));
        }
    }
    public class AuthFilter : IActionFilter
    {
        private const string secretKey = "fghjkloiuytrefghj";

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as ControllerBase;
            var httpContext = controller.HttpContext;
      

            string controllerName = context.ActionDescriptor.RouteValues["controller"];
            string actionName = context.ActionDescriptor.RouteValues["action"];
           // controller.GetLogger().LogInformation($"Controller:{controllerName} Action:{actionName} AuthAttribute OnActionExecuting");
            if (controllerName == "")
            {
                return;
            }
            else
            {
                var t = context.Controller.GetType();

                if (t.GetMethod(actionName).GetCustomAttribute<AuthAttribute>(false) == null)
                {
                    if (t.GetCustomAttribute<AuthAttribute>(true) == null)
                    {
                        return;
                    }
                  
                }
                if (t.GetMethod(actionName).GetCustomAttribute<NonAuthAttribute>(false) != null)
                {
                    return;
                }
                
                var token = httpContext.Request.Headers["x-token"];
                if (token.Count() <= 0)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new JsonResult(new Resp<object>
                    {
                        code = 401,
                        message = "鉴权失败"
                    });
                    return;
                }
                byte[] key = Encoding.UTF8.GetBytes(secretKey);
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
               
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                var loginToken = decoder.DecodeToObject<LoginToken>(token,key,true);
                if (loginToken.Expire<DateTime.Now)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new JsonResult(new Resp<object>
                    {
                        code = 401,
                        message = "已过期"
                    });
                    return;
                }
                var claims = new Claim[] {
                    new Claim("UserId", loginToken.UserId),
                    new Claim("UserName", loginToken.Username),
                    new Claim("IsAdmin",loginToken.IsAdmin.ToString()),
                    new Claim("token",token),
                    new Claim("session",loginToken.sessionId)
                
                };
                httpContext.User.AddIdentity(new ClaimsIdentity(claims));


            }
        }
    }
}
