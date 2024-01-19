using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using Serilog;
using Serilog.Sinks.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Linx.Log
{
    /// <summary>
    /// Serilog日志扩展
    /// </summary>
    public static class SerilogExt
    {
        //获取当前程序入口项目的名称 作为默认的日志名
        private static string _name = Assembly.GetEntryAssembly().GetName().Name;
        public static void AddQjSerilog(string name = "")
        {
            if (name == "")
            {
                name = _name;
            }
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information) //忽略一下微软框架中的日志
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning) //忽略EF里的一些等级的日志
                .Enrich.FromLogContext() //输出上下文信息
                .WriteTo.Console() //输出到终端
                .WriteTo.File($"./logs/{name}.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, retainedFileCountLimit: 3) //每天滚动一个日志文件
                .CreateLogger();
        }
        /// <summary>
        /// 注入Serilog服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="name">日志文件名.log</param>
        public static void AddQjSerilog(this IServiceCollection services,string name = "")
        {
            if (name=="")
            {
                name = _name;
            }
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File($"./logs/{name}.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, retainedFileCountLimit: 3)
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose:true);
            });
        }
    }
}
