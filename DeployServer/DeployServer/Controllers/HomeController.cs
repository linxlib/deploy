using DeployServer.Middleware;
using DeployServer.Queues;
using Masuit.Tools;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;

namespace DeployServer.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ContentResult Index()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = @"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>部署服务</title>
</head>
<body>
    <span id='mytext'>当前服务地址: </span>
</br>
<a id='mydownload' href=''>下载最新版</a>
</br>
    <a id='myurl' href='deploy://'>启动部署客户端</a>
    
    <script>
        document.getElementById('mytext').innerHTML = '当前服务地址:'+window.location.href
        document.getElementById('myurl').setAttribute('href','deploy://'+window.location.href)
        document.getElementById('mydownload').setAttribute('href',window.location.href+'api/Version/DownloadLatest')
    </script>
</body>
</html>"
            };
        }
        /// <summary>
        /// websocket 心跳连接
        /// 
        /// 发送当前用户,时间,是否管理员
        /// </summary>
        /// <param name="contextAccessor"></param>
        /// <returns></returns>
        [Route("/ws/heartbeat")]
        [Auth]
        public async Task Heartbeat([FromServices] IHttpContextAccessor contextAccessor)
        {
            var manager = contextAccessor.HttpContext.WebSockets;
           
            if (manager.IsWebSocketRequest)
            {
                using var websocket = await manager.AcceptWebSocketAsync();

                while (websocket.State == WebSocketState.Open)
                {
                    Thread.Sleep(3000);
                    byte[] bs = JsonConvert.SerializeObject(new { data = DateTime.Now,name= this.CurrentUserName(),isAdmin = this.IsAdmin()}).ToByteArray();
                    await websocket.SendAsync(bs, WebSocketMessageType.Text, true, CancellationToken.None);
                }

                await websocket.CloseAsync(
                    WebSocketCloseStatus.Empty,
                    "server closed",
                    CancellationToken.None);
            }
        }
        /// <summary>
        /// websocket消息
        /// 
        /// 发送管理员给其他客户端发送的消息
        /// </summary>
        /// <param name="contextAccessor"></param>
        /// <returns></returns>
        [Route("/ws/message")]
        [Auth]
        public async Task Message([FromServices] IHttpContextAccessor contextAccessor, [FromServices] IMessageQueue<string, MsgType, object> queue)
        {
            var manager = contextAccessor.HttpContext.WebSockets;

            if (manager.IsWebSocketRequest)
            {
                using var websocket = await manager.AcceptWebSocketAsync();
                var clientId = this.CurrentToken();

                while (websocket.State == WebSocketState.Open)
                {
                    //这里要准备一个等待队列
                    //有消息了就发送, 没有消息则进入循环等待
                    Thread.Sleep(2000);
                     var m= await queue.DeQueue(clientId,MsgType.MESSAGE);
                    if (m!=null)
                    {
                        byte[] bs = JsonConvert.SerializeObject(m.msg).ToByteArray();
                        await websocket.SendAsync(bs, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                    
                    
                }

                await websocket.CloseAsync(
                    WebSocketCloseStatus.Empty,
                    "server closed",
                    CancellationToken.None);
            }
        }
        /// <summary>
        /// 下发新版本发布的消息
        /// 
        /// 让客户端进行升级
        /// </summary>
        /// <param name="contextAccessor"></param>
        /// <returns></returns>
        [Route("/ws/version")]
        [Auth]
        public async Task Version([FromServices] IHttpContextAccessor contextAccessor, [FromServices] IMessageQueue<string, MsgType, object> queue)
        {
            var manager = contextAccessor.HttpContext.WebSockets;

            if (manager.IsWebSocketRequest)
            {
                using var websocket = await manager.AcceptWebSocketAsync();
                var clientId = this.CurrentToken();

                while (websocket.State == WebSocketState.Open)
                {
                    //这里要准备一个等待队列
                    //有消息了就发送, 没有消息则进入循环等待
                    Thread.Sleep(2000);
                    var m = await queue.DeQueue(clientId, MsgType.VERSION);
                    if (m != null)
                    {
                        byte[] bs = JsonConvert.SerializeObject(m.msg).ToByteArray();
                        await websocket.SendAsync(bs, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }

                await websocket.CloseAsync(
                    WebSocketCloseStatus.Empty,
                    "server closed",
                    CancellationToken.None);
            }
        }
        [HttpGet("/api/message")]
        [Auth]
        public async Task PublishMessage([FromServices] IMessageQueue<string, MsgType, object> queue)
        {
            queue.EnQueue(this.CurrentToken(), MsgType.MESSAGE, new { msg = "Hello World" });
        }
    }
}
