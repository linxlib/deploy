using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Cors
{
    /// <summary>
    /// 跨域扩展
    /// </summary>
    public static class CorsExt
    {
        private static string C_ALLOW_ANY = "AllowAnyOrigin";
        public static void AddQjCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(C_ALLOW_ANY, policy =>
                {
                    policy.AllowAnyMethod()
                   .SetIsOriginAllowed(_ => true)
                   .AllowAnyHeader()
                   .AllowCredentials();
                });
            });
        }
        public static void UseQjCors(this IApplicationBuilder app)
        {
            app.UseCors(C_ALLOW_ANY);
        }
    }
}
