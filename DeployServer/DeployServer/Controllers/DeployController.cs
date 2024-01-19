using DeployServer.Middleware;
using Entity;
using Ext;
using LiteDB;
using Masuit.Tools.Files;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DeployServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Auth]
    public class DeployController : ControllerBase
    {
        private ILiteCollection<Service> _serviceCollection;
        public DeployController(LiteDatabase lite)
        {
            _serviceCollection = lite.GetCollection<Service>();
        }
        /// <summary>
        /// 客户端上传文件进行部署
        /// </summary>
        /// <param name="file"></param>
        /// <param name="hash"></param>
        /// <param name="size"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
       
        [HttpPost]
        public Task<Resp<string>> Deploy([FromForm] IFormFile file, [FromForm] string hash, [FromForm] long size, [FromForm] string serviceId)
        {
            
            //获取服务相关信息
            //发起部署进程
            //向客户端发送部署进度信息(需要管理服务端的websocket连接信息)
            Console.WriteLine($"查找服务:{serviceId}");
            var service = _serviceCollection.FindOne(e => e.Id == serviceId.ToObjectId());
            if (service == null)
            {
                return Resp.Fail<string>("未找到服务");
            }

            //获取当前服务器
            //如果和服务对应的服务器不同, 则需要转发到对应的服务器进行部署
            if (size!=file.Length)
            {
                Console.WriteLine($"文件大小不匹配:{size}");
                return Resp.Fail<string>("文件大小不匹配, 可能传输过程出现问题");
            }
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Seek(0, SeekOrigin.Begin);
                var h = stream.GetFileSha1();
                if (h != hash)
                {
                    Console.WriteLine($"文件hash校验不通过:{hash}");
                    return Resp.Fail<string>("文件hash校验不通过, 文件已损坏");
                }
                var tmpEx =Path.Join(Directory.GetCurrentDirectory(), "tmp");
                Directory.CreateDirectory(tmpEx);
                stream.Seek(0, SeekOrigin.Begin);
                stream.UnZip(tmpEx);
                Console.WriteLine(service.Stop());
                Thread.Sleep(3000);
                if (!service.OverwriteFrom(tmpEx))
                {
                    Console.WriteLine($"文件覆盖失败:{tmpEx}");
                    return Resp.Fail<string>("文件覆盖失败");
                }
                if (!service.Start())
                {
                    Console.WriteLine($"服务启动失败:{service.Name}");
                    return Resp.Fail<string>("服务启动失败");
                }
                service.LastDeployTime = DateTime.Now;
                _serviceCollection.Update(service);
                Directory.Delete(tmpEx, true);
            }
            Console.WriteLine($"服务完成部署:{service.Name}");
            return Resp.OK<string>("complete");
    

            //部署流程
            //1. 根据服务类型获取相应的关闭服务和启动服务需要的命令
            //2. 对已有服务文件进行备份(需要测试服务运行时能否直接复制)
            //3. 解压上传的文件到临时目录
            //4. 停止服务(根据服务类型)
            //5. 进行覆盖
            //6. 重新启动服务(根据服务类型)
            //7. 定期删除临时目录内容
            //8. 记录每次部署的相关版本记录(需要很详细, 方便后续回滚的时候查找)
            //9. 更新服务的部署时间等

            //上传上来的文件(本次部署)不需要进行备份


            //IIS部署
            // 需要准备操控IIS的相关库(停止网站 启动网站 获取网站状态等)



        }
    }
}
