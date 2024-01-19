using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployClient.Common
{
    /// <summary>
    /// 为Refit库的Http请求添加自定义的鉴权Header
    /// </summary>
    public class AuthHeaderHandler:DelegatingHandler
    {
        private IAuthTokenStore _authStore;
        public AuthHeaderHandler(IAuthTokenStore authTokenStore)
        {
            _authStore = authTokenStore;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _authStore.GetAuthToken();
            request.Headers.Add("x-token", token);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
