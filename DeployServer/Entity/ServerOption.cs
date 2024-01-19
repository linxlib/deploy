using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ServerOption
    {
        /// <summary>
        /// 是否主节点
        /// </summary>
        public bool IsMain { get; set; }
        /// <summary>
        /// LiteDB数据库的路径, 仅IsMain为true时有用
        /// </summary>
        public string DBPath { get; set; }
        public int Port { get; set; }
        /// <summary>
        /// 用于进行websocket连接时, 这个是内部通讯用
        /// </summary>
        public string WebsocketUrl { get; set; }
        /// <summary>
        /// 用于进行websocket连接时,这个是外部通讯用, 可以和上面的的一致.
        /// 如果需要内部通讯使用内网ip进行, 外部通讯使用域名转发 则需要两个都配置
        /// </summary>
        public string WebsocketUr1 { get; set; }
        /// <summary>
        /// api地址, 默认为网卡地址+端口, 可进行重写
        /// 例如通过代理转发的情况或者nginx转发的情况(域名)
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// api地址, 默认为网卡地址+端口, 可进行重写
        /// 例如通过代理转发的情况或者nginx转发的情况(域名)
        /// 同WebsocketUr1
        /// </summary>
        public string ApiUrl1 { get; set; }
    }
}
