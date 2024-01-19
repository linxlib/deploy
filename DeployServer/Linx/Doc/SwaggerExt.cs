using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag.Generation.Processors;
using System.Collections.Generic;
using System.Reflection;
namespace Linx.Doc
{
    /// <summary>
    /// swagger文档扩展
    /// </summary>
    public static class SwaggerExt
    {
        private static string _name = Assembly.GetEntryAssembly().GetName().Name;
        /// <summary>
        /// 添加Swagger服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="name">名称</param>
        /// <param name="ops">IOperationProcessor列表, 用于处理一些特定的注解</param>
        public static void AddQjSwagger(this IServiceCollection services,string name="",List<IOperationProcessor> ops =null) 
        {
            if (name == "")
            {
                name = _name;
            }
            services.AddSwaggerDocument(doc =>
            {
                doc.Title = name;
                doc.Description = $"{name}的文档";
                doc.UseControllerSummaryAsTagDescription = true;
                doc.SchemaSettings.UseXmlDocumentation = true;
                doc.SchemaSettings.GenerateEnumMappingDescription = true;
                if (ops!=null)
                {
                    foreach (var op in ops)
                    {
                        doc.OperationProcessors.Add(op);
                    }
                }
                
            });
        }
        /// <summary>
        /// 使用swagger服务
        /// </summary>
        /// <param name="app"></param>
        public static void UseQjSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }
    }
}
