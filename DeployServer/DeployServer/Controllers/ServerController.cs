using DeployServer.Middleware;
using Entity;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;


namespace DeployServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        [NonAuth]
        [HttpGet]
        public Task<string> Health()
        {
            return Task.FromResult("ok");
        }




    }
}
