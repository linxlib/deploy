using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public static class Resp
    {
        public static Task<Resp<R>> Fail<R>(string message = "fail")
        {
            return Task.FromResult( new Resp<R>
            {
                code = 500,
                message = message,
                data = default,
            });
        }
        public static Task<Resp<R>> Fail<R>(R data, string message = "fail")
        {
            return Task.FromResult(new Resp<R>
            {
                code = 500,
                message = message,
                data = data
            });
        }
  
        public static Task<Resp<R>> OK<R>(R data, string message = "ok")
        {
            return Task.FromResult(new Resp<R>
            {
                code = 200,
                message = message,
                data = data
            });

        }

    }
    public class Resp<T>
    {
        public int code { get; set; }
        public string message{ get; set; }
        public T data { get; set; }
        public List<string> ex { get; set; }
    }
}
