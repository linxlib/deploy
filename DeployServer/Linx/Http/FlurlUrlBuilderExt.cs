using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace Linx.Http
{
    /// <summary>
    /// url地址扩展
    /// </summary>
    public static class FlurlUrlBuilderExt
    {
        /// <summary>
        /// 转为IFlurlRequest对象
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public static  IFlurlRequest NewRequest(this string baseUrl) { return new FlurlRequest(baseUrl); }

        /// <summary>
        /// 添加Query参数
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Url AddQuery(this string baseUrl, string key, object value)
        {
            return baseUrl.AppendQueryParam(key, value);
        }
        /// <summary>
        /// 批量添加Query参数到当前url
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="queries">query字典</param>
        /// <returns></returns>
        public static Url AddQuerys(this string baseUrl, IDictionary<string,string> queries)
        {
            Url tmp  = Url.Parse(baseUrl);
            foreach (var item in queries)
            {
                tmp = tmp.AppendQueryParam(item.Key, item.Value);
            }
            return tmp;
        }
        /// <summary>
        /// 批量添加Query参数到当前IFlurlRequest
        /// </summary>
        /// <param name="req"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static IFlurlRequest AddQuerys(this IFlurlRequest req, IDictionary<string, string> queries)
        {
            foreach (var item in queries)
            {
                req = req.AppendQueryParam(item.Key, item.Value);
            }
            return req;
        }
        /// <summary>
        /// 设置Query参数
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Url SetQuery(this string baseUrl, string key, object value)
        {
            return baseUrl.SetQueryParam(key, value);
        }
        public static IFlurlRequest SetQuery(this IFlurlRequest req, string key, object value)
        {
            return req.SetQueryParam(key, value);
        }
        /// <summary>
        /// 删除query参数
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Url RemoveQuery(this Url baseUrl, string key)
        {
            return baseUrl.RemoveQueryParam(key);
        }
        public static IFlurlRequest RemoveQuery(this IFlurlRequest req, string key)
        {
            return req.RemoveQueryParam(key);
        }
        /// <summary>
        /// 移除url中的query参数
        /// 
        /// ?号后面的部分全部删除
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string TrimUrl(this string url)
        {
            int index = url.IndexOf("?");
            string str = url;
            if (index >= 0)
            {
                str = url.Substring(0, index);
                Console.WriteLine("-- orignal url=" + url);
                Console.WriteLine("-- new url=" + str);
            }
            return str;
        }

        /// <summary>
        /// 将字典中以key排序后&拼接
        /// 
        /// 很多需要签名的接口需要使用
        /// 
        /// 还有需要通过querystring传到body里的情况下使用(application/x-www-form-urlencoded)
        /// 与此对应, 需要使用PostUrlEncodedAsync发起请求
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string ParamToQueryString(this IDictionary<string, string> param)
        {
            if (param == null || param.Count == 0)
            {
                return null;
            }

            var keys = param.Keys.OrderBy(m => m).ToList();
            StringBuilder paramString = new StringBuilder();
            bool first = true;
            foreach (string key in keys)
            {
                object value = param[key];
                if (!first)
                {
                    paramString.Append("&");
                }
                paramString.Append(key + "=" + value?.ToString());
                first = false;
            }

            return paramString.ToString();
        }
        /// <summary>
        /// 以Sha256算法进行签名
        /// </summary>
        /// <param name="signStr">待签名字符串</param>
        /// <param name="signKey">算法使用的key</param>
        /// <returns>已签名</returns>
        public static string SignSHA256(this string signStr, string signKey)
        {
            HMACSHA256 sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(signKey));
            byte[] signData = sha256.ComputeHash(Encoding.UTF8.GetBytes(signStr));
            return Convert.ToBase64String(signData);
        }
        /// <summary>
        /// 以Md5算法签名为32位的字符串
        /// </summary>
        /// <param name="signStr">待签名字符串</param>
        /// <param name="isUpper">是否大写</param>
        /// <returns>已签名字符</returns>
        public static string SignMd5(this string signStr,bool isUpper = false)
        {
            string rule = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(signStr));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                if (isUpper)
                {
                    rule = rule + s[i].ToString("X2");
                } else
                {
                    rule = rule + s[i].ToString("x2"); // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                }
                
            }
            return rule;
        }
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString(string format= "yyMMddHHmmss")
        {
            return DateTime.UtcNow.ToString(format) + new Random().Next(1000, 9999);
        }
        /// <summary>
        /// 将对象转为querystring形式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToQueryString<T>(this T obj)
        {
            var properties = from p in obj?
                             .GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select $"{HttpUtility.UrlEncode(p.GetAlias())}" + $"={HttpUtility.UrlEncode(p.GetValue(obj)?.ToString())}";
            return string.Join("&", properties);
        }
        /// <summary>
        /// 如果有JsonPropertyAttribute 获取其名称作为序列化的Name
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string GetAlias(this PropertyInfo p)
        {
            var tmp = p.Name;
            var jp = p.GetCustomAttribute<JsonPropertyAttribute>();
            if (jp != null)
            {
                tmp = jp.PropertyName;
            }
            return tmp;
        }
        

    }
}
