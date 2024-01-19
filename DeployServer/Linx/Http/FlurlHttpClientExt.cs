using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Linx.Http
{
    /// <summary>
    /// Flurl扩展
    /// </summary>
    public static class FlurlHttpClientExt
    {
        /// <summary>
        /// 全局配置Flurl参数
        /// 
        /// 超时20s
        /// 忽略https证书错误
        /// </summary>
        /// <param name="app"></param>
        public static void UseGlobalHttp(this IApplicationBuilder app)
        {
            FlurlHttp.Clients.WithDefaults(builder =>
            {
                builder.WithTimeout(TimeSpan.FromSeconds(20));
                builder.ConfigureInnerHandler(handler =>
                {
                    handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
                });
            });
        }
        /// <summary>
        /// Console使用, 配置全局的Flurl
        /// </summary>
        public static void ConfigureGlobalHttp()
        {
            FlurlHttp.Clients.WithDefaults(builder =>
            {
                builder.WithTimeout(TimeSpan.FromSeconds(20));
                builder.ConfigureInnerHandler(handler =>
                {
                    handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
                });
            });
        }
        /// <summary>
        /// 注入Flurl库
        /// 
        /// 使用: IFlurlClientCache.
        /// </summary>
        /// <param name="services"></param>
        public static void AddGlobalHttp(this IServiceCollection services,string baseUrl)
        {
            services.AddSingleton(_ => new FlurlClientCache()
            .WithDefaults(builder =>
            {
                builder.WithTimeout(TimeSpan.FromSeconds(20));
                builder.ConfigureInnerHandler(handler => { handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true; });
            }).Add("Cli", baseUrl));
        }

        /// <summary>
        /// POST请求, 带body和headers
        /// </summary>
        /// <typeparam name="T">返回结构体</typeparam>
        /// <param name="url"></param>
        /// <param name="headers">请求头</param>
        /// <param name="body">json body 可以为null</param>
        /// <returns></returns>
        public static Task<T> PostJson<T>(this string url, IDictionary<string,string> headers,object body=null)
        {
            if (!headers.ContainsKey("Content-Type"))
            {
                headers.TryAdd("Content-Type", "application/json");
            } else
            {
                headers.Remove("Content-Type");
                headers.TryAdd("Content-Type", "application/json");
            }
            try
            {
                if (body == null)
                {
                    return url.WithHeaders(headers).PostAsync().ReceiveJson<T>();
                }
                return url.WithHeaders(headers).PostJsonAsync(body).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseStringAsync().Result;
                var res = $@"请求失败: {url}
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                throw new Exception(res);
            }
            
        }
        /// <summary>
        /// POST请求 无body
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static Task<T> Post<T>(this string url, IDictionary<string,string> headers)
        {
            if (!headers.ContainsKey("Content-Type"))
            {
                headers.TryAdd("Content-Type", "application/x-www-form-urlencoded");
            }
            try
            {
                return url.WithHeaders(headers).PostAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseStringAsync().Result;
                var res = $@"请求失败: {url}
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                throw new Exception(res);
            }
            
        }
        /// <summary>
        /// 仅POST, 无body, 不关心返回
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static Task<string> JustPost(this string url, IDictionary<string,string> headers = null)
        {
            if (headers==null || headers.Count()<=0)
            {
                return url.PostAsync().ReceiveString();
            }
            try
            {
                return url.WithHeaders(headers).PostAsync().ReceiveString();
            } catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseStringAsync().Result;
                var res = $@"请求失败: {url}
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                throw new Exception(res);
            }

        }
   
        /// <summary>
        /// GET请求
        /// </summary>
        /// <typeparam name="T">返回结构体</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static Task<T> Get<T> (this string url, IDictionary<string, string> headers)
        {
            try
            {
                return url.WithHeaders(headers).GetAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseStringAsync().Result;
                var res = $@"请求失败: {url}
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                throw new Exception(res);
            }
    
        }
        /// <summary>
        /// 仅GET 不关心返回结构体
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static Task<string> JustGet(this string url, IDictionary<string, string> headers)
        {
            try
            {
                return url.WithHeaders(headers).GetAsync().ReceiveString();
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseStringAsync().Result;
                var res = $@"请求失败: {url}
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                throw new Exception(res);
            }
   
        }
        public static TResponse DoRequest<TRequest,TResponse>(this string url, TRequest request,string method, IDictionary<string, string> headers)
        {
            try
            {
                switch (method)
                {
                    case "GET":
                        return url.WithHeaders(headers).GetJsonAsync<TResponse>().Result;
                     case "POST":
                        return url.WithHeaders(headers).PostJsonAsync(request).ReceiveJson<TResponse>().Result;
                    default:
                        throw new Exception($"not support method:{method}");
                }
                
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseStringAsync().Result;
                var res = $@"请求失败: {url}
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                throw new Exception(res);
            }
        }



    }
}
