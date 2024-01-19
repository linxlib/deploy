using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entity
{
    public  enum ServerType
    {
        Windows,
        Linux
    }

    public class Server: BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// 服务器监听的端口
        /// </summary>
        public int Port { get; set; }
        public string Host { get; set; }
        /// <summary>
        /// 服务器监听的api地址
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// 服务器类型
        /// 不同服务器执行部署时的命令不同
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ServerType ServerType { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 心跳在线
        /// </summary>
        public bool Online { get; set; }
        /// <summary>
        /// 上线时间
        /// </summary>
        public DateTime OnlineTime { get; set; }
        /// <summary>
        /// 网卡MAC地址, 服务器心跳上报时获取
        /// </summary>
        public string Mac { get; set; }
        /// <summary>
        /// 网卡IP
        /// </summary>
        public string LocalIP { get; set; }
        /// <summary>
        /// 外网IP
        /// </summary>
        public string PublicIP { get; set; }

        public DateTime InDate { get; set; }
        public DateTime EditDate { get; set; }
        /// <summary>
        /// 排序, 一般后加入的显示在后面
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 服务器的版本
        /// </summary>
        public string Version { get; set; }


    }
}
