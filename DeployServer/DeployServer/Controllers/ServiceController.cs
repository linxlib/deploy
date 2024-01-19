using DeployServer.Middleware;
using Entity;
using Ext;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Administration;

namespace DeployServer.Controllers
{
    /// <summary>
    /// 服务
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Auth]
    public class ServiceController : ControllerBase
    {
        private ILiteCollection<Service> _services;

        public ServiceController(LiteDatabase lite)
        {
            _services = lite.GetCollection<Service>();
        }

        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<Service>> AddService(Service service)
        {
            if (_services.Find(e=>e.Name==service.Name && e.ServerId == service.ServerId).Count() > 0)
            {
                return Resp.Fail<Service>("同一服务器下不能存在重复服务");
            }
            service.InDate = DateTime.Now;
            _services.Insert(service);
            return Resp.OK(_services.FindOne(e => e.Id == service.Id));
        }
        /// <summary>
        /// 删除服务
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> DeleteService(string serviceId)
        {
            return Resp.OK(_services.DeleteMany(e=>e.Id==serviceId.ToObjectId())>0);
        }
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<Service>> Get(string serviceId)
        {
            return Resp.OK(_services.FindById(serviceId.ToObjectId()));
        }
        /// <summary>
        /// 根据服务器id获取服务
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<List<Service>>> GetByServer(string serverId)
        {
            return Resp.OK(_services.FindAll().OrderByDescending(e=>e.LastDeployTime).ToList());
        }

        
        /// <summary>
        /// 修改服务
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> UpdateService(Service service)
        {
           return Resp.OK(_services.Update(service));
        }
        /// <summary>
        /// 服务状态
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<ServiceStatus>> ServiceStatus(string serviceId)
        {
            var service = _services.FindOne(e => e.Id == serviceId.ToObjectId());
            return Resp.OK(service.GetStatus());
        }
        /// <summary>
        /// 服务操作
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="actionType"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<ServiceStatus>> ServiceAction(string serviceId,ActionType actionType)
        {
            //重启时 如果服务是关闭的 只要启动即可
            var service = _services.FindOne(e => e.Id == serviceId.ToObjectId());
            switch (actionType)
            {
                case ActionType.ActionReboot:
                    service.Stop();
                    service.Start();
                    return Resp.OK(service.GetStatus());
                case ActionType.ActionStop:
                    service.Stop();
                    return Resp.OK(service.GetStatus());
                case ActionType.ActionStart:
                    service.Start();
                    return Resp.OK(service.GetStatus());
                default:
                    return Resp.OK(service.GetStatus());
            }

        }
        /// <summary>
        /// 目录树
        /// </summary>
        /// <param name="path"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<List<PathItem>>> DirTree(string path,string serverId)
        { 
            var list2 = DirectoryFetch.ListAll(path);
            return Resp.OK(list2);
        }
        /// <summary>
        /// IIS服务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<List<Service>>> IISServiceList()
        {
            var manager = new ServerManager();
            var list = new List<Service>();
            foreach (var site in manager.Sites)
            {
                list.Add(new Service
                {
                    Name = site.Name,
                    ServiceName = site.Name,
                    RealPath = site.Applications[0].VirtualDirectories[0].PhysicalPath,
                    Arg = site.Applications[0].ApplicationPoolName,
                    ListenUrl = site.Bindings[0].EndPoint.Address.ToString() + ":" +site.Bindings[0].EndPoint.Port.ToString(),
                });
            }
            return Resp.OK(list);
    
        }
    }
}
