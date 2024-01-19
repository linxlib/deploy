using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entity
{
    public enum ServiceType
    {
        IIS, //iis项目, 需要重启网站
        Console, //终端, 或者直接运行的服务
        Service, //windows服务
        Systemd, //linux systemd 管理的服务
        Dir //纯目录, 可直接覆盖
    }

    public class Service: BaseEntity
    {

        /// <summary>
        /// 服务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// eg. IIS项目为IIS网站名. Console 则为可执行文件的名称(包含后缀)
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 附带参数, 有些服务可能需要带参数执行
        /// </summary>
        public string Arg { get; set; }
        /// <summary>
        /// 服务所在路径
        /// </summary>
        public string RealPath { get; set; }
        /// <summary>
        /// 监听地址
        /// </summary>
        public string ListenUrl { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ServiceType ServiceType { get; set; }
        public string ServerId { get; set; }
        /// <summary>
        /// 上次部署时间
        /// </summary>
        public DateTime LastDeployTime { get; set; }
        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditDate { get; set; }



    }

    public class ServiceStatus
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }
        public int PID { get; set; }
        public string CmdLine { get; set; }
    }

    public enum Status
    {
        Running,
        Stoped,
        NotFound
    }
}
