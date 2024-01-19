using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class LoginToken
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 头像id
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expire { get; set; }
        /// <summary>
        /// session 用于websocket连接区分不同客户端, 需要通过x-session的header加入到请求中
        /// </summary>
        public string sessionId { get; set; }
    }
}
