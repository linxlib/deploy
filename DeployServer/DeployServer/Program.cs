using DeployServer.Middleware;
using Entity;
using Entity.LiteDB;
using Linx.Cors;
using Linx.Log;
using Linx.Doc;
using Microsoft.AspNetCore.WebSockets;
using DeployServer.Queues;
using System.Collections.Concurrent;

namespace DeployServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseIISIntegration();
            builder.WebHost.UseKestrel(options =>
            {
                options.ListenAnyIP(5000);
                options.Limits.MaxRequestBodySize = 200 * 1024 * 1024;
            });

            builder.Services.AddMvcCore(opt =>
            {
                opt.Filters.Add<AuthFilter>();
                opt.Filters.Add<ExceptionFilter>();
            }).AddApiExplorer();
            builder.Services.AddQjCors();
            builder.Services.AddQjSerilog();
            builder.Services.AddQjSwagger();
            builder.Services.AddWebSockets(options =>
            {
                options.KeepAliveInterval = TimeSpan.FromSeconds(5);
                
            });
            builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").AddInMemoryCollection();
            builder.Services.Configure<ServerOption>(builder.Configuration.GetSection("ServerOption"));

            builder.Services.AddLiteDatabase(configure =>
            {
                configure.ConnectionString.Filename = "deploy.db";
                configure.Mapper.EmptyStringToNull = false;
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<IMessageQueue<string, MsgType, object>>(new MessageQueue<string, MsgType,object>());

            var app = builder.Build();
            app.UseQjCors();

            app.UseWebSockets();

            app.UseQjSwagger();
            app.MapControllers();
            app.Run();
        }

      
    }
}