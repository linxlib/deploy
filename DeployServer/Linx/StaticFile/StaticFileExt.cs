using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.StaticFile
{
    /// <summary>
    /// 静态目录扩展
    /// </summary>
    public static class StaticFileExt
    {
        /// <summary>
        /// 使用静态目录
        /// </summary>
        /// <param name="app"></param>
        /// <param name="dir">目录(相对路径)</param>
        /// <param name="requestPath">http请求路径</param>
        public static void UseStaticDir(this IApplicationBuilder app,string dir,string requestPath)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.GetFullPath(dir)),
                RequestPath = requestPath
            });
        }
    }
}
