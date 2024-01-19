using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Helper
{
    public static class ObjExt
    {
        /// <summary>
        /// 序列化到json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 字符串反序列化到对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObj<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
