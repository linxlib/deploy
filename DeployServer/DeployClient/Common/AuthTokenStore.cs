using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployClient.Common
{
    /// <summary>
    /// token缓存服务
    /// </summary>
    public interface IAuthTokenStore
    {
        /// <summary>
        /// 获取token值
        /// </summary>
        /// <returns></returns>
        string GetAuthToken();
        string GetSession();
        /// <summary>
        /// 获取token类
        /// </summary>
        /// <returns></returns>
        LoginToken GetAuthLoginToken();
        /// <summary>
        /// 缓存token
        /// </summary>
        /// <param name="token"></param>
        void SetAuthToken(LoginToken token);
    }
    public class AuthTokenStore : IAuthTokenStore
    {
        private  Options options;

        public AuthTokenStore(Options options)
        {
            this.options = options;
        }
        public LoginToken GetAuthLoginToken()
        {
            return JsonConvert.DeserializeObject<LoginToken>(this.options.From().LoginToken);
        }

        public string GetAuthToken()
        {
            var loginToken = JsonConvert.DeserializeObject<LoginToken>(this.options.From().LoginToken);
            return loginToken?.Token ?? "";
        }

        public string GetSession()
        {
            var loginToken = JsonConvert.DeserializeObject<LoginToken>(this.options.From().LoginToken);
            return loginToken?.sessionId??"";
        }

        public void SetAuthToken(LoginToken token)
        {
            this.options.From().LoginToken = JsonConvert.SerializeObject(token);
            this.options.Save();
        }
    }
}
